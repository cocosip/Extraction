using System;
using System.Collections.Generic;
using System.Linq;
using Volo.Abp.Domain.Entities;

namespace Extraction
{
    /// <summary>
    /// 提取器信息
    /// </summary>
    public class ExtractorInfo : AggregateRoot<Guid>
    {
        /// <summary>
        /// 管道的名称
        /// </summary>
        public virtual string ProviderName { get; set; }

        /// <summary>
        /// 提取器的名称
        /// </summary>
        public virtual string Name { get; set; }

        /// <summary>
        /// 匹配的正则表达式
        /// </summary>
        public virtual string Match { get; set; }

        /// <summary>
        /// 域名地址
        /// </summary>
        public virtual string Domain { get; set; }

        /// <summary>
        /// 提取器对应的Url地址
        /// </summary>
        public virtual string Url { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public virtual string Describe { get; set; }

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


        public ExtractorInfo(
            Guid id,
            string providerName,
            string name,
            string match,
            string domain,
            string url,
            string describe) : this()
        {
            Id = id;
            ProviderName = providerName;
            Name = name;
            Match = match;
            Domain = domain;
            Url = url;
            Describe = describe;
        }

        public void Update(string name, string match, string domain, string url, string describe)
        {
            Name = name;
            Match = match;
            Domain = domain;
            Url = url;
            Describe = describe;
        }

        public void AddResource(ExtractorInfoResource resource)
        {
            Resources.Add(resource);
        }

        public void RemoveResource(Guid resourceId)
        {
            var resource = Resources.FirstOrDefault(x => x.Id == resourceId);
            if (resource != null)
            {
                Resources.Remove(resource);
            }
        }

        public void AddRule(ExtractorInfoRule rule)
        {
            Rules.Add(rule);
        }

        public void RemoveRule(Guid ruleId)
        {
            var rule = Rules.FirstOrDefault(x => x.Id == ruleId);
            if (rule != null)
            {
                Rules.Remove(rule);
            }
        }
    }
}
