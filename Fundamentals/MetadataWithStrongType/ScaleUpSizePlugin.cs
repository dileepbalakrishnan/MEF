using System.ComponentModel.Composition;
using System.Drawing;
using System.Windows.Forms;

namespace MetadataWithStrongType
{
    [Export("Size", typeof(IMenuPlugin))]
    //[ExportMetadata(StringConstants.MenutextKey, "++10")]
    [MenuPluginMetadata("Size + 10")]
    internal class ScaleUpSizePlugin : IMenuPlugin
    {
        public void Transform(Label label)
        {
            label.Font = new Font(label.Font.FontFamily.Name, label.Font.Size + 10);
        }
    }
}