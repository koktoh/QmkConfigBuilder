using QmkConfigBuilder.Models.KeyboardDefinitions;

namespace QmkConfigBuilder.Shared.KeyboardCommonDefinitionsViewer
{
    public class KeyboardCommonDefinitions
    {
        public string VID { get; set; } = string.Empty;
        public string PID { get; set; } = string.Empty;
        public string Manufacturer { get; set; } = string.Empty;
        public string Maintainer { get; set; } = string.Empty;
        public string KeyboardName { get; set; } = string.Empty;
        public DiodeDirection DiodeDirection { get; set; } = DiodeDirection.COL2ROW;
    }
}
