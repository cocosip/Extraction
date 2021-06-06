using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Services;

namespace Extraction
{
    public class ExtractorProviderManager : DomainService, IExtractorProviderManager
    {
        protected IExtractorProviderRepository ExtractorProviderRepository { get; }
        public ExtractorProviderManager(IExtractorProviderRepository extractorProviderRepository)
        {
            ExtractorProviderRepository = extractorProviderRepository;
        }

        /// <summary>
        /// 创建管道
        /// </summary>
        /// <param name="provider"></param>
        /// <returns></returns>
        public virtual async Task CreateAsync(ExtractorProvider provider)
        {
            var queryProvider = await ExtractorProviderRepository.FindExpectedByNameAsync(provider.Name);
            if (queryProvider != null)
            {
                throw new UserFriendlyException($"Duplicate provider '{provider.Name}'.");
            }

            await ExtractorProviderRepository.InsertAsync(provider);
        }

        /// <summary>
        /// 修改管道
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="title"></param>
        /// <param name="describe"></param>
        /// <returns></returns>
        public virtual async Task UpdateAsync(Guid id, string name, string title, string describe)
        {
            var provider = await ExtractorProviderRepository.GetAsync(id);
            var queryProvider = await ExtractorProviderRepository.FindExpectedByNameAsync(provider.Name, id);
            if (queryProvider != null)
            {
                throw new UserFriendlyException($"Duplicate provider '{name}'.");
            }

            provider.Update(name, title, describe);
            await ExtractorProviderRepository.UpdateAsync(provider);
        }

        /// <summary>
        /// 添加资源
        /// </summary>
        /// <param name="id"></param>
        /// <param name="resource"></param>
        /// <returns></returns>
        public virtual async Task AddResourceAsync(Guid id, ExtractorProviderResource resource)
        {
            var provider = await ExtractorProviderRepository.GetAsync(id, true);
            if (resource.ExtractorProviderId == null || resource.ExtractorProviderId == default)
            {
                resource.ExtractorProviderId = id;
            }
            provider.AddResource(resource);

            await ExtractorProviderRepository.UpdateAsync(provider);
        }

        /// <summary>
        /// 删除资源
        /// </summary>
        /// <param name="id"></param>
        /// <param name="resourceId"></param>
        /// <returns></returns>
        public virtual async Task RemoveResourceAsync(Guid id, Guid resourceId)
        {
            var provider = await ExtractorProviderRepository.GetAsync(id, true);
            provider.RemoveResource(resourceId);
            await ExtractorProviderRepository.UpdateAsync(provider);
        }

        /// <summary>
        /// 添加参数定义
        /// </summary>
        /// <param name="id"></param>
        /// <param name="parameterDefination"></param>
        /// <returns></returns>
        public virtual async Task AddParameterDefinationAsync(Guid id, ParameterDefination parameterDefination)
        {
            var provider = await ExtractorProviderRepository.GetAsync(id, true);
            if (parameterDefination.ExtractorProviderId == null || parameterDefination.ExtractorProviderId == default)
            {
                parameterDefination.ExtractorProviderId = id;
            }
            provider.AddParameterDefination(parameterDefination);
            await ExtractorProviderRepository.UpdateAsync(provider);
        }


    }
}
