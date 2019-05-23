using System.ComponentModel.Composition;
using System.Drawing;
using System.Windows.Forms;

namespace MetadataWithStrongType
{
    [Export("Color", typeof(IMenuPlugin))]
    //[ExportMetadata(StringConstants.MenutextKey, "Red")]
    [MenuPluginMetadata(MenuText = "Red")]
    internal class RedColorPlugin : IMenuPlugin
    {
        public void Transform(Label label)
        {
            label.ForeColor = Color.Red;
        }
    }
}