namespace mshdemo3.Modal
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Attributes
    {
        public int created_at { get; set; }
        public Metadata metadata { get; set; }
        public string name { get; set; }
        public string origin { get; set; }
        public string product { get; set; }
        public string source { get; set; }
        public string source_build_id { get; set; }
        public string state { get; set; }
        public string type { get; set; }
        public int updated_at { get; set; }
        public Url url { get; set; }
    }

    public class BodyShape
    {
        public string id { get; set; }
        public string gender { get; set; }
        public string modelVersion { get; set; }
        public List<double> shapeParameters { get; set; }
        public MeshMeasurements mesh_measurements { get; set; }
    }

    public class MeshMeasurements
    {
        public double Height { get; set; }
        public double Weight { get; set; }
        public double Bust_girth { get; set; }
        public double Ankle_girth { get; set; }
        public double Foot_length { get; set; }
        public double Thigh_girth { get; set; }
        public double Waist_girth { get; set; }
        public double Armscye_girth { get; set; }
        public double Top_hip_girth { get; set; }
        public double Neck_base_girth { get; set; }
        public double Shoulder_length { get; set; }
        public double Lower_arm_length { get; set; }
        public double Upper_arm_length { get; set; }
        public double Inside_leg_height { get; set; }
        public double Back_shoulder_width { get; set; }
    }

    public class Metadata
    {
        public BodyShape bodyShape { get; set; }
        public PoseSequence poseSequence { get; set; }
    }

    public class PoseSequence
    {
    }

    public class AvatarMeasurements
    {
        public Data data { get; set; }
    }

}
