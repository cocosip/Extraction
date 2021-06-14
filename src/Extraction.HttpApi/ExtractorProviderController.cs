using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;

namespace Extraction
{
    [RemoteService(Name = "Extraction")]
    [Area("Extraction")]
    [Route("api/extractor-provider")]
    public class ExtractorProviderController : ExtractionController, IExtractorProviderAppService
    {
        private readonly IExtractorProviderAppService _extractorProviderAppService;
        public ExtractorProviderController(IExtractorProviderAppService extractorProviderAppService)
        {
            _extractorProviderAppService = extractorProviderAppService;
        }

        /// <summary>
        /// 根据id查询提取器管道
        /// </summary>
        /// <param name="id"></param>
        /// <param name="includeDetails"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        public async Task<ExtractorProviderDto> GetAsync(Guid id, bool includeDetails = true)
        {
            return await _extractorProviderAppService.GetAsync(id, includeDetails);
        }

        /// <summary>
        /// 根据名称查询提取器管道
        /// </summary>
        /// <param name="name"></param>
        /// <param name="includeDetails"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("find-by-name/{name}")]
        public async Task<ExtractorProviderDto> FindByNameAsync(string name, bool includeDetails = true)
        {
            return await _extractorProviderAppService.FindByNameAsync(name, includeDetails);
        }

        /// <summary>
        /// 查询全部的提取器管道
        /// </summary>
        /// <param name="includeDetails"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("get-all")]
        public async Task<List<ExtractorProviderDto>> GetAllAsync(bool includeDetails = false)
        {
            return await _extractorProviderAppService.GetAllAsync(includeDetails);
        }

        /// <summary>
        /// 分页查询提取器管道
        /// </summary>
        /// <param name="input"></param>
        /// <param name="includeDetails"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<PagedResultDto<ExtractorProviderDto>> GetPagedListAsync(ExtractorProviderPagedRequestDto input, bool includeDetails = true)
        {
            return await _extractorProviderAppService.GetPagedListAsync(input, includeDetails);
        }

        /// <summary>
        /// 创建提取器管道
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<Guid> CreateAsync(CreateExtractorProviderDto input)
        {
            return await _extractorProviderAppService.CreateAsync(input);
        }

        /// <summary>
        /// 修改提取器管道
        /// </summary>
        /// <param name="id"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("{id}")]
        public async Task UpdateAsync(Guid id, UpdateExtractorProviderDto input)
        {
            await _extractorProviderAppService.UpdateAsync(id, input);
        }

        /// <summary>
        /// 删除提取器管道
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id}")]
        public async Task DeleteAsync(Guid id)
        {
            await _extractorProviderAppService.DeleteAsync(id);
        }

        /// <summary>
        /// 创建提取器管道参数
        /// </summary>
        /// <param name="id"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("{id}/parameter-defination")]
        public async Task<Guid> CreateParameterDefinationAsync(Guid id, CreateParameterDefinationDto input)
        {
            return await _extractorProviderAppService.CreateParameterDefinationAsync(id, input);
        }

        /// <summary>
        /// 删除提取器管道参数
        /// </summary>
        /// <param name="id"></param>
        /// <param name="parameterDefinationId"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id}/parameter-defination/{parameterDefinationId}")]
        public async Task DeleteParameterDefinationAsync(Guid id, Guid parameterDefinationId)
        {
            await _extractorProviderAppService.DeleteParameterDefinationAsync(id, parameterDefinationId);
        }

        /// <summary>
        /// 创建提取器管道资源
        /// </summary>
        /// <param name="id"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("{id}/resource")]
        public async Task<Guid> CreateResourceAsync(Guid id, CreateExtractorProviderResourceDto input)
        {
            return await _extractorProviderAppService.CreateResourceAsync(id, input);
        }

        /// <summary>
        /// 更新提取器管道资源
        /// </summary>
        /// <param name="id"></param>
        /// <param name="parameterDefinationId"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("{id}/resource/{resourceId}")]
        public async Task UpdateParameterDefinationAsync(Guid id, Guid parameterDefinationId, UpdateParameterDefinationDto input)
        {
            await _extractorProviderAppService.UpdateParameterDefinationAsync(id, parameterDefinationId, input);
        }

        /// <summary>
        /// 删除提取器管道资源
        /// </summary>
        /// <param name="id"></param>
        /// <param name="resourceId"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id}/resource/{resourceId}")]
        public async Task DeleteResourceAsync(Guid id, Guid resourceId)
        {
            await _extractorProviderAppService.DeleteResourceAsync(id, resourceId);
        }
    }
}
