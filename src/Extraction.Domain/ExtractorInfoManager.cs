using System;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Extraction
{
    public class ExtractorInfoManager : DomainService, IExtractorInfoManager
    {
        protected IExtractorProviderRepository ExtractorProviderRepository { get; }
        protected IRepository<ParameterDefination, Guid> ParameterDefinationRepository { get; }
        protected IExtractorInfoRepository ExtractorInfoRepository { get; }

        public ExtractorInfoManager(
            IExtractorProviderRepository extractorProviderRepository,
            IRepository<ParameterDefination, Guid> parameterDefinationRepository,
            IExtractorInfoRepository extractorInfoRepository)
        {
            ExtractorProviderRepository = extractorProviderRepository;
            ParameterDefinationRepository = parameterDefinationRepository;
            ExtractorInfoRepository = extractorInfoRepository;
        }

        /// <summary>
        /// 创建提取器
        /// </summary>
        /// <param name="extractorInfo"></param>
        /// <returns></returns>
        public virtual async Task CreateAsync(ExtractorInfo extractorInfo)
        {
            var provider = await ExtractorProviderRepository.FindByNameAsync(extractorInfo.ProviderName, false);
            if (provider == null)
            {
                throw new UserFriendlyException($"Could not find provider by name '{provider.Name}'.");
            }

            var queryExtractorInfo = await ExtractorInfoRepository.FindExpectedByNameAsync(extractorInfo.Name);
            if (queryExtractorInfo != null)
            {
                throw new UserFriendlyException($"Duplicate extractorInfo '{extractorInfo.Name}'.");
            }

            await ExtractorInfoRepository.InsertAsync(extractorInfo);
        }

        /// <summary>
        /// 更新提取器
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="match"></param>
        /// <param name="domain"></param>
        /// <param name="url"></param>
        /// <param name="describe"></param>
        /// <returns></returns>
        public virtual async Task UpdateAsync(Guid id, string name, string match, string domain, string url, string describe)
        {
            var extractorInfo = await ExtractorInfoRepository.GetAsync(id);
            var queryExtractorInfo = await ExtractorInfoRepository.FindExpectedByNameAsync(name, id);
            if (queryExtractorInfo != null)
            {
                throw new UserFriendlyException($"Duplicate extractorInfo '{name}'.");
            }

            var provider = await ExtractorProviderRepository.FindByNameAsync(extractorInfo.Name, false);
            if (provider == null)
            {
                throw new UserFriendlyException($"Could not find provider by name '{provider.Name}'.");
            }

            extractorInfo.Update(name, match, domain, url, describe);

            await ExtractorInfoRepository.UpdateAsync(extractorInfo);
        }

        /// <summary>
        /// 创建提取器资源
        /// </summary>
        /// <param name="id"></param>
        /// <param name="resource"></param>
        /// <returns></returns>
        public virtual async Task CreateResourceAsync(Guid id, ExtractorInfoResource resource)
        {
            var extractorInfo = await ExtractorInfoRepository.GetAsync(id, true);
            if (resource.ExtractorInfoId == null || resource.ExtractorInfoId == default)
            {
                resource.ExtractorInfoId = id;
            }
            extractorInfo.AddResource(resource);

            await ExtractorInfoRepository.UpdateAsync(extractorInfo);
        }

        /// <summary>
        /// 删除提取器资源
        /// </summary>
        /// <param name="id"></param>
        /// <param name="resourceId"></param>
        /// <returns></returns>
        public virtual async Task DeleteResourceAsync(Guid id, Guid resourceId)
        {
            var extractorInfo = await ExtractorInfoRepository.GetAsync(id, true);
            extractorInfo.RemoveResource(resourceId);
            await ExtractorInfoRepository.UpdateAsync(extractorInfo);
        }

        /// <summary>
        /// 添加提取规则
        /// </summary>
        /// <param name="id"></param>
        /// <param name="rule"></param>
        /// <returns></returns>
        public virtual async Task CreateRuleAsync(Guid id, ExtractorInfoRule rule)
        {
            var extractorInfo = await ExtractorInfoRepository.GetAsync(id, true);
            if (rule.ExtractorInfoId == null || rule.ExtractorInfoId == default)
            {
                rule.ExtractorInfoId = id;
            }
            //RootDefinationId, CurrentDefinationId
            await ValidateParameterDefinationAsync(rule.RootDefinationId, rule.CurrentDefinationId);

            extractorInfo.AddRule(rule);
            await ExtractorInfoRepository.UpdateAsync(extractorInfo);
        }

        /// <summary>
        /// 删除提取规则
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ruleId"></param>
        /// <returns></returns>
        public virtual async Task DeleteRuleAsync(Guid id, Guid ruleId)
        {
            var extractorInfo = await ExtractorInfoRepository.GetAsync(id, true);
            extractorInfo.RemoveRule(ruleId);
            await ExtractorInfoRepository.UpdateAsync(extractorInfo);
        }

        /// <summary>
        /// 更新提取器规则
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ruleId"></param>
        /// <param name="rootDefinationId"></param>
        /// <param name="currentDefinationId"></param>
        /// <param name="extractStyle"></param>
        /// <param name="handleStyle"></param>
        /// <param name="dataType"></param>
        /// <param name="ruleValue"></param>
        /// <param name="describe"></param>
        /// <returns></returns>
        public virtual async Task UpdateRuleAsync(Guid id,
            Guid ruleId,
            Guid rootDefinationId,
            Guid currentDefinationId,
            int extractStyle,
            int handleStyle,
            int dataType,
            string ruleValue,
            string describe)
        {
            var extractorInfo = await ExtractorInfoRepository.GetAsync(id, true);
            var rule = extractorInfo.Rules.FirstOrDefault(x => x.Id == ruleId);
            if (rule == null)
            {
                throw new UserFriendlyException($"Could not find extractorInfo {id}’s rule by id '{ruleId}'");
            }
            await ValidateParameterDefinationAsync(rootDefinationId, currentDefinationId);

            rule.Update(
                rootDefinationId,
                currentDefinationId,
                extractStyle,
                handleStyle,
                dataType,
                ruleValue,
                describe);

            await ExtractorInfoRepository.UpdateAsync(extractorInfo);
        }


        /// <summary>
        /// 校验提取器规则关联的参数
        /// </summary>
        /// <param name="rootDefinationId"></param>
        /// <param name="currentDefinationId"></param>
        /// <returns></returns>
        protected virtual async Task ValidateParameterDefinationAsync(Guid rootDefinationId, Guid currentDefinationId)
        {
            var rootParameterDefination = await ParameterDefinationRepository.FindAsync(rootDefinationId, false);
            if (rootParameterDefination == null)
            {
                throw new UserFriendlyException($"Could not find root parameterDefinaton '{rootDefinationId}'.");
            }
            if (rootParameterDefination.ParentId.HasValue)
            {
                throw new UserFriendlyException($"Invalid root parameterDefinaton, it's not root.");
            }

            ParameterDefination currentParameterDefination;
            if (rootDefinationId == currentDefinationId)
            {
                currentParameterDefination = rootParameterDefination;
            }
            else
            {
                currentParameterDefination = await ParameterDefinationRepository.FindAsync(currentDefinationId, false);
            }

            if (currentParameterDefination == null)
            {
                throw new UserFriendlyException($"Could not find current parameterDefinaton '{currentDefinationId}'.");
            }

            //当前级别跟根级的不是同一个,才进行判断
            if (rootDefinationId != currentDefinationId)
            {
                if (!currentParameterDefination.ParentId.HasValue)
                {
                    throw new UserFriendlyException($"Root parameterDefinaton not match current parameterDefinaton (Current parentId is null).");
                }

                //当前的上级不是Root
                if (currentParameterDefination.ParentId != rootDefinationId)
                {
                    var parentParameterDefination = await ParameterDefinationRepository.FindAsync(currentParameterDefination.ParentId.Value, false);
                    if (!parentParameterDefination.ParentId.HasValue)
                    {
                        throw new UserFriendlyException($"Root parameterDefinaton not match current parameterDefinaton (Parent parentId is null).");
                    }
                    //如果上级的上级Id还不是根节点,那么就超过3级,直接出错
                    if (parentParameterDefination.ParentId.Value != rootDefinationId)
                    {
                        throw new UserFriendlyException($"Root parameterDefinaton not match current parameterDefinaton.");
                    }
                }
            }
        }


    }
}
