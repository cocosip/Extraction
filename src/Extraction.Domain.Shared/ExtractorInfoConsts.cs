namespace Extraction
{
    public static class ExtractorInfoConsts
    {
        /// <summary>
        /// Default value:32
        /// </summary>
        public static int MaxProviderNameLength { get; set; } = 32;

        /// <summary>
        /// Default value:32
        /// </summary>
        public static int MaxNameLength { get; set; } = 32;

        /// <summary>
        /// Default value:256
        /// </summary>
        public static int MaxMatchLength { get; set; } = 256;

        /// <summary>
        /// Default value:256
        /// </summary>
        public static int MaxDomainLength { get; set; } = 256;

        /// <summary>
        /// Default value:256
        /// </summary>
        public static int MaxUrlLength { get; set; } = 256;

        /// <summary>
        /// Default value:256
        /// </summary>
        public static int MaxDescribeLength { get; set; } = 256;
    }
}
