namespace Extraction
{
    public interface IParameterCalculator
    {
        /// <summary>
        /// 计算Hash值
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        string CalculateHash(string value);
    }
}
