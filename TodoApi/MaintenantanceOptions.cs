namespace TodoApi
{
    public class MaintenantanceOptions
    {
        public const string MaintenantanceSection = "MaintenantanceMode";

        public bool IsInMaintenantanceMode { get; set; }
        public string MaintenantanceMessage { get; set; }
    }
}
