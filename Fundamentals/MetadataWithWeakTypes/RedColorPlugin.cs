using System.ComponentModel.Composition;
using System.Drawing;
using System.Windows.Forms;

namespace MetadataWithWeakTypes
{
    [Export("Color", typeof(IMenuPlugin))]
    [ExportMetadata(StringConstants.MenutextKey, "Red")]
    internal class RedColorPlugin : IMenuPlugin
    {
        public void Transform(Label label)
        {
            label.ForeColor = Color.Red;
        }
    }
}