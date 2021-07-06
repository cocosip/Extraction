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
            await ValidateParameterDefinationAsync(rule.ParameterDefinationId);

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
        /// <param name="parameterDefinationId"></param>
        /// <param name="selectNodeType"></param>
        /// <param name="nodeManipulationType"></param>
        /// <param name="handleStyle"></param>
        /// <param name="xPathValue"></param>
        /// <param name="preHandlers"></param>
        /// <param name="afterHandlers"></param>
        /// <param name="describe"></param>
        /// <returns></returns>
        public virtual async Task UpdateRuleAsync(Guid id,
            Guid ruleId,
            Guid parameterDefinationId,
            int selectNodeType,
            int nodeManipulationType,
            int handleStyle,
            string xPathValue,
            string preHandlers,
            string afterHandlers,
            string describe)
        {
            var extractorInfo = await ExtractorInfoRepository.GetAsync(id, true);
            var rule = extractorInfo.Rules.FirstOrDefault(x => x.Id == ruleId);
            if (rule == null)
            {
                throw new UserFriendlyException($"Could not find extractorInfo {id}’s rule by id '{ruleId}'");
            }
            await ValidateParameterDefinationAsync(parameterDefinationId);

            rule.Update(
                parameterDefinationId,
                selectNodeType,
                nodeManipulationType,
                handleStyle,
                xPathValue,
                preHandlers,
                afterHandlers,
                describe);

            await ExtractorInfoRepository.UpdateAsync(extractorInfo);
        }


        /// <summary>
        /// 校验提取器规则关联的参数
        /// </summary>
        /// <param name="parameterDefinationId"></param>
        /// <returns></returns>
        protected virtual async Task ValidateParameterDefinationAsync(Guid parameterDefinationId)
        {
            var parameterDefination = await ParameterDefinationRepository.FindAsync(parameterDefinationId, false);
            if (parameterDefination == null)
            {
                throw new UserFriendlyException($"Could not find root parameterDefinaton '{parameterDefinationId}'.");
            }
        }
    }
}
