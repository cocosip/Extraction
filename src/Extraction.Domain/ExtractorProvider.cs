﻿using System;
using System.Collections.Generic;
using System.Linq;
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
        /// 管道参数定义
        /// </summary>
        public virtual ICollection<ParameterDefination> Definations { get; protected set; }

        public ExtractorProvider()
        {
            Resources = new List<ExtractorProviderResource>();
            Definations = new List<ParameterDefination>();
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
        /// 删除资源
        /// </summary>
        /// <param name="resourceId"></param>
        public void RemoveResource(Guid resourceId)
        {
            var resource = Resources.FirstOrDefault(x => x.Id == resourceId);
            if (resource != null)
            {
                Resources.Remove(resource);
            }
        }

        /// <summary>
        /// 添加参数定义
        /// </summary>
        /// <param name="parameterDefination"></param>
        public void AddParameterDefination(ParameterDefination parameterDefination)
        {
            Definations.Add(parameterDefination);
        }

        /// <summary>
        /// 删除参数定义
        /// </summary>
        /// <param name="parameterDefinationId"></param>
        public void RemoveParameterDefination(Guid parameterDefinationId)
        {
            var parameterDefination = Definations.FirstOrDefault(x => x.Id == parameterDefinationId);
            if (parameterDefination != null)
            {
                Definations.Remove(parameterDefination);
            }
        }

    }
}
