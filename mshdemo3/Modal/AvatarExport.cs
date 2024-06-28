namespace mshdemo3.Modal
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class AttributesExport
    {
        public MetadataExport metadata { get; set; }
        public string name { get; set; }
        public string origin { get; set; }
        public string product { get; set; }
        public string source { get; set; }
        public string source_build_id { get; set; }
        public string state { get; set; }
        public string type { get; set; }
        public Url url { get; set; }
    }

    public class DataExport
    {
        public string type { get; set; }
        public string id { get; set; }
        public AttributesExport attributes { get; set; }
        public Links links { get; set; }
    }

    public class LinksExport
    {
        public string self { get; set; }
    }

    public class MetadataExport
    {
        public ParametersExport parameters { get; set; }
        public string meshtype { get; set; }
        public string filetype { get; set; }
        public string gender { get; set; }
        public string parentID { get; set; }
    }

    public class ParametersExport
    {
        public string format { get; set; }
        public string pose { get; set; }
        public string filename { get; set; }
        public string gender { get; set; }
        public string shapeParameters { get; set; }
        public string modelVersion { get; set; }
    }

    public class AvatarExport
    {
        public DataExport data { get; set; }
    }

    public class UrlExport
    {
        public string path { get; set; }
        public string method { get; set; }
        public bool @internal { get; set; }
    }


}
