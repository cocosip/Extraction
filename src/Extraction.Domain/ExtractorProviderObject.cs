using System;
using Volo.Abp.Domain.Entities;

namespace Extraction
{
    /// <summary>
    /// 管道的对象
    /// </summary>
    public class ExtractorProviderObject : Entity<Guid>
    {
        /// <summary>
        /// 管道项的Id
        /// </summary>
        public virtual Guid ExtractorProviderItemId { get; set; }

        /// <summary>
        /// 字段名称
        /// </summary>
        public virtual string Name { get; set; }

        /// <summary>
        /// 值类型
        /// </summary>
        public virtual string ValueType { get; set; }

        public ExtractorProviderObject()
        {

        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="id"></param>
        /// <param name="extractorProviderItemId"></param>
        /// <param name="name"></param>
        /// <param name="valueType"></param>
        public ExtractorProviderObject(
            Guid id,
            Guid extractorProviderItemId, 
            string name, 
            string valueType)
        {
            Id = id;
            ExtractorProviderItemId = extractorProviderItemId;
            Name = name;
            ValueType = valueType;
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="name"></param>
        /// <param name="valueType"></param>
        public void Update(string name, string valueType)
        {
            Name = name;
            ValueType = valueType;
        }
    }
}
