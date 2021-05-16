using System;
using Volo.Abp.Domain.Entities;

namespace Extraction
{
    /// <summary>
    /// 管道的对象
    /// </summary>
    public class ProviderObject : Entity<Guid>
    {
        /// <summary>
        /// 管道项的Id
        /// </summary>
        public virtual Guid ProviderItemId { get; set; }

        /// <summary>
        /// 字段名称
        /// </summary>
        public virtual string Name { get; set; }

        /// <summary>
        /// 值类型
        /// </summary>
        public virtual string ValueType { get; set; }

        public ProviderObject()
        {

        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="id"></param>
        /// <param name="providerItemId"></param>
        /// <param name="name"></param>
        /// <param name="valueType"></param>
        public ProviderObject(Guid id, Guid providerItemId, string name, string valueType)
        {
            Id = id;
            ProviderItemId = providerItemId;
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
