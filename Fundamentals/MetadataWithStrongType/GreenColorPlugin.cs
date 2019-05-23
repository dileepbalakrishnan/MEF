using System.ComponentModel.Composition;
using System.Drawing;
using System.Windows.Forms;

namespace MetadataWithStrongType
{
    [Export("Color", typeof(IMenuPlugin))]
    [MenuPluginMetadata(MenuText = "Green")]
    internal class GreenColorPlugin : IMenuPlugin
    {
        public void Transform(Label label)
        {
            label.ForeColor = Color.Green;
        }
    }
}