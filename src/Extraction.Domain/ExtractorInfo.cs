using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace Extraction
{
    /// <summary>
    /// 提取器信息
    /// </summary>
    public class ExtractorInfo : AggregateRoot<Guid>
    {
        /// <summary>
        /// 提取器管道Id
        /// </summary>
        public virtual Guid ExtractorProviderId { get; set; }

        /// <summary>
        /// 提取器的名称
        /// </summary>
        public virtual string Name { get; set; }

        /// <summary>
        /// 域名地址
        /// </summary>
        public virtual string Domain { get; set; }

        /// <summary>
        /// 提取器对应的Url地址
        /// </summary>
        public virtual string Url { get; set; }

        /// <summary>
        /// 资源
        /// </summary>
        public virtual ICollection<ExtractorInfoResource> Resources { get; protected set; }

        /// <summary>
        /// 规则
        /// </summary>
        public virtual ICollection<ExtractorInfoRule> Rules { get; protected set; }

        public ExtractorInfo()
        {
            Resources = new List<ExtractorInfoResource>();
            Rules = new List<ExtractorInfoRule>();
        }


        public ExtractorInfo(Guid id, Guid extractorProviderId, string name, string domain, string url) : this()
        {
            Id = id;
            ExtractorProviderId = extractorProviderId;
            Name = name;
            Domain = domain;
            Url = url;
        }

        public void Update(string name, string domain, string url)
        {
            Name = name;
            Domain = domain;
            Url = url;
        }


        public void AddResource(ExtractorInfoResource resource)
        {
            Resources.Add(resource);
        }

        public void AddRule(ExtractorInfoRule rule)
        {
            Rules.Add(rule);
        }
    
    }
}
