using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Volo.Abp.DependencyInjection;

namespace Extraction
{
    public class ParameterCalculator : IParameterCalculator, ITransientDependency
    {
        /// <summary>
        /// 计算Hash值
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public virtual string CalculateHash(string value)
        {
            var buffer = Encoding.UTF8.GetBytes(value);
            using var sha1 = SHA1.Create();
            var hashBuffer = sha1.ComputeHash(buffer);
            return hashBuffer.Aggregate("", (current, b) => current + b.ToString("X2"));
        }

    }
}
