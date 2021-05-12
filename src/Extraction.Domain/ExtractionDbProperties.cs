namespace Extraction
{
    public static class ExtractionDbProperties
    {
        public static string DbTablePrefix { get; set; } = "Extraction";

        public static string DbSchema { get; set; } = null;

        public const string ConnectionStringName = "Extraction";
    }
}
