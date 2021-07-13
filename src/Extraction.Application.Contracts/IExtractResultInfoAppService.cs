using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Extraction
{
    public interface IExtractResultInfoAppService : IApplicationService
    {
        /// <summary>
        /// 根据Id查询提取结果
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ExtractResultInfoDto> GetAsync(Guid id);
    }
}
