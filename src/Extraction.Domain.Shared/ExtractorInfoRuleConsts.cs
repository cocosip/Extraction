namespace Extraction
{
    public static class ExtractorInfoRuleConsts
    {
        /// <summary>
        /// Default value: 1024
        /// </summary>
        public static int MaxXPathValueLength { get; set; } = 1024;

        /// <summary>
        /// Default value: 1024
        /// </summary>
        public static int MaxPreHandlersLength { get; set; } = 1024;

        /// <summary>
        /// Default value: 1024
        /// </summary>
        public static int MaxAfterHandlersLength { get; set; } = 1024;

        /// <summary>
        /// Default value:256
        /// </summary>
        public static int MaxDescribeLength { get; set; } = 256;
    }
}
