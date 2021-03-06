using System;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace Extraction
{
    public interface IExtractorInfoManager : IDomainService
    {
        /// <summary>
        /// 创建提取器
        /// </summary>
        /// <param name="extractorInfo"></param>
        /// <returns></returns>
        Task CreateAsync(ExtractorInfo extractorInfo);

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
        Task UpdateAsync(Guid id, string name, string match, string domain, string url, string describe);

        /// <summary>
        /// 创建提取器资源
        /// </summary>
        /// <param name="id"></param>
        /// <param name="resource"></param>
        /// <returns></returns>
        Task CreateResourceAsync(Guid id, ExtractorInfoResource resource);

        /// <summary>
        /// 删除提取器资源
        /// </summary>
        /// <param name="id"></param>
        /// <param name="resourceId"></param>
        /// <returns></returns>
        Task DeleteResourceAsync(Guid id, Guid resourceId);

        /// <summary>
        /// 添加提取规则
        /// </summary>
        /// <param name="id"></param>
        /// <param name="rule"></param>
        /// <returns></returns>
        Task CreateRuleAsync(Guid id, ExtractorInfoRule rule);

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
        Task UpdateRuleAsync(Guid id, Guid ruleId, Guid parameterDefinationId, int selectNodeType, int nodeManipulationType, int handleStyle, string xPathValue, string preHandlers, string afterHandlers, string describe);

        /// <summary>
        /// 删除提取规则
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ruleId"></param>
        /// <returns></returns>
        Task DeleteRuleAsync(Guid id, Guid ruleId);
    }
}
