using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace Extraction
{
    /// <summary>
    /// 管道项
    /// </summary>
    public class ExtractorProviderItem : Entity<Guid>
    {
        /// <summary>
        /// 提取器管道Id
        /// </summary>
        public Guid ExtractorProviderId { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public virtual string Name { get; set; }

        /// <summary>
        /// 类型
        /// </summary>
        public virtual int ItemType { get; set; }

        /// <summary>
        /// 管道对象
        /// </summary>
        public virtual ICollection<ExtractorProviderObject> Objects { get; protected set; }

        public ExtractorProviderItem()
        {
            Objects = new List<ExtractorProviderObject>();
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="id"></param>
        /// <param name="extractorProviderId"></param>
        /// <param name="name"></param>
        /// <param name="itemType"></param>
        public ExtractorProviderItem(
            Guid id,
            Guid extractorProviderId,
            string name,
            int itemType) : this()
        {
            Id = id;
            ExtractorProviderId = extractorProviderId;
            Name = name;
            ItemType = itemType;
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="name"></param>
        /// <param name="itemType"></param>
        public void Update(string name, int itemType)
        {
            Name = name;
            ItemType = itemType;
        }

        /// <summary>
        /// 添加原子对象
        /// </summary>
        /// <param name="providerObject"></param>
        public void AddObject(ExtractorProviderObject providerObject)
        {
            Objects.Add(providerObject);
        }


    }
}
