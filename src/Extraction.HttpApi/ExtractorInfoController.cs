using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;

namespace Extraction
{
    [RemoteService(Name = "Extraction")]
    [Area("Extraction")]
    [Route("api/extractor-info")]
    public class ExtractorInfoController : ExtractionController, IExtractorInfoAppService
    {
        private readonly IExtractorInfoAppService _extractorInfoAppService;
        public ExtractorInfoController(IExtractorInfoAppService extractorInfoAppService)
        {
            _extractorInfoAppService = extractorInfoAppService;
        }

        /// <summary>
        /// 根据id查询提取器信息
        /// </summary>
        /// <param name="id"></param>
        /// <param name="includeDetails"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        public async Task<ExtractorInfoDto> GetAsync(Guid id, bool includeDetails = true)
        {
            return await _extractorInfoAppService.GetAsync(id, includeDetails);
        }

        /// <summary>
        /// 根据名称查询提取器
        /// </summary>
        /// <param name="name"></param>
        /// <param name="includeDetails"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("find-by-name/{name}")]
        public async Task<ExtractorInfoDto> FindByNameAsync(string name, bool includeDetails = true)
        {
            return await _extractorInfoAppService.FindByNameAsync(name, includeDetails);
        }

        /// <summary>
        /// 提取器分页查询
        /// </summary>
        /// <param name="input"></param>
        /// <param name="includeDetails"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<PagedResultDto<ExtractorInfoDto>> GetPagedListAsync(ExtractorProviderPagedRequestDto input, bool includeDetails = true)
        {
            return await _extractorInfoAppService.GetPagedListAsync(input, includeDetails);
        }

        /// <summary>
        /// 创建提取器
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<Guid> CreateAsync(CreateExtractorInfoDto input)
        {
            return await _extractorInfoAppService.CreateAsync(input);
        }

        /// <summary>
        /// 修改提取器
        /// </summary>
        /// <param name="id"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("{id}")]
        public async Task UpdateAsync(Guid id, UpdateExtractorInfoDto input)
        {
            await _extractorInfoAppService.UpdateAsync(id, input);
        }

        /// <summary>
        /// 删除提取器
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id}")]
        public async Task DeleteAsync(Guid id)
        {
            await _extractorInfoAppService.DeleteAsync(id);
        }

        /// <summary>
        /// 创建提取器资源
        /// </summary>
        /// <param name="id"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("{id}/resource")]
        public async Task<Guid> CreateResourceAsync(Guid id, CreateExtractorInfoResourceDto input)
        {
            return await _extractorInfoAppService.CreateResourceAsync(id, input);
        }

        /// <summary>
        /// 根据id删除提取器资源
        /// </summary>
        /// <param name="id"></param>
        /// <param name="resourceId"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id}/resource/{resourceId}")]
        public async Task DeleteResourceAsync(Guid id, Guid resourceId)
        {
            await _extractorInfoAppService.DeleteResourceAsync(id, resourceId);
        }

        /// <summary>
        /// 创建提取器规则
        /// </summary>
        /// <param name="id"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("{id}/rule")]
        public async Task<Guid> CreateRuleAsync(Guid id, CreateExtractorInfoRuleDto input)
        {
            return await _extractorInfoAppService.CreateRuleAsync(id, input);
        }

        /// <summary>
        /// 修改提取器规则
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ruleId"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("{id}/rule/{ruleId}")]
        public async Task UpdateRuleAsync(Guid id, Guid ruleId, UpdateExtractorInfoRuleDto input)
        {
            await _extractorInfoAppService.UpdateRuleAsync(id, ruleId, input);
        }

        /// <summary>
        /// 删除提取器规则
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ruleId"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id}/rule/{ruleId}")]
        public async Task DeleteRuleAsync(Guid id, Guid ruleId)
        {
            await _extractorInfoAppService.DeleteRuleAsync(id, ruleId);
        }
    }
}
