using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace Extraction
{
    /// <summary>
    /// 提取器管道
    /// </summary>
    public class ExtractorProvider : AggregateRoot<Guid>
    {
        /// <summary>
        /// 提取器管道名称
        /// </summary>
        public virtual string Name { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        public virtual string Title { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public virtual string Describe { get; set; }

        /// <summary>
        /// 资源
        /// </summary>
        public virtual ICollection<ExtractorProviderResource> Resources { get; protected set; }

        /// <summary>
        /// 管道项
        /// </summary>
        public virtual ICollection<ExtractorProviderItem> Items { get; set; }

        public ExtractorProvider()
        {
            Resources = new List<ExtractorProviderResource>();
            Items = new List<ExtractorProviderItem>();
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="title"></param>
        /// <param name="describe"></param>
        public ExtractorProvider(
            Guid id,
            string name,
            string title,
            string describe) : this()
        {
            Id = id;
            Name = name;
            Title = title;
            Describe = describe;
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="name"></param>
        /// <param name="title"></param>
        /// <param name="describe"></param>
        public void Update(string name, string title, string describe)
        {
            Name = name;
            Title = title;
            Describe = describe;
        }

        /// <summary>
        /// 添加资源
        /// </summary>
        /// <param name="resource"></param>
        /// <returns></returns>
        public void AddResource(ExtractorProviderResource resource)
        {
            Resources.Add(resource);
        }

        /// <summary>
        /// 添加项
        /// </summary>
        /// <param name="item"></param>
        public void AddItem(ExtractorProviderItem item)
        {
            Items.Add(item);
        }

    }
}
