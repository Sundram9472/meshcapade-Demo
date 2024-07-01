namespace mshdemo3.Modal
{
    public class AttributesAvatarMeshes
    {
        public int created_at { get; set; }
        public MetadataAvatarMeshes metadata { get; set; }
        public string name { get; set; }
        public string origin { get; set; }
        public string product { get; set; }
        public string source { get; set; }
        public string source_build_id { get; set; }
        public string state { get; set; }
        public string type { get; set; }
        public int updated_at { get; set; }
        public UrlAvatarMeshes url { get; set; }
    }

    public class DataAvatarMeshes
    {
        public string type { get; set; }
        public string id { get; set; }
        public AttributesAvatarMeshes attributes { get; set; }
        public LinksAvatarMeshes links { get; set; }
    }

    public class LinksAvatarMeshes
    {
        public string self { get; set; }
    }

    public class MetadataAvatarMeshes
    {
        public string gender { get; set; }
        public string filetype { get; set; }
        public string meshtype { get; set; }
        public string parentID { get; set; }
        public ParametersAvatarMeshes parameters { get; set; }
    }

    public class ParametersAvatarMeshes
    {
        public string pose { get; set; }
        public string format { get; set; }
        public string gender { get; set; }
        public string filename { get; set; }
        public string modelVersion { get; set; }
        public string shapeParameters { get; set; }
    }

    public class AvatarMeshes
    {
        public DataAvatarMeshes data { get; set; }
    }

    public class UrlAvatarMeshes
    {
        public string path { get; set; }
        public string method { get; set; }
        public bool @internal { get; set; }
    }


}
