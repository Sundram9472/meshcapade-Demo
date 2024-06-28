namespace mshdemo3.Modal
{

    public class Data
    {
        public string type { get; set; }
        public string id { get; set; }
        public Attributes attributes { get; set; }
        public Links links { get; set; }
    }

    public class Links
    {
        public string self { get; set; }
        public string upload { get; set; }
    }

    public class UploadResponse
    {
        public Data data { get; set; }
    }

    public class Url
    {
        public string path { get; set; }
        public string method { get; set; }
        public bool @internal { get; set; }
    }


}
