using System;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace Extraction
{
    public interface IExtractRecordManager : IDomainService
    {
        /// <summary>
        /// 根据提取结果,生成提取记录
        /// </summary>
        /// <param name="resultId"></param>
        /// <returns></returns>
        Task<Guid> CreateFromResultAsync(Guid resultId);
    }
}
