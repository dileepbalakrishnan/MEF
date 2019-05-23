using System.ComponentModel.Composition;
using System.Drawing;
using System.Windows.Forms;
using ConstructorImportDemo;

namespace ConstructorImportDemo
{
    [Export("Color", typeof(IMenuPlugin))]
    [ExportMetadata(StringConstants.MenutextKey, "Green")]
    internal class GreenColorPlugin : IMenuPlugin
    {
        public void Transform(Label label)
        {
            label.ForeColor = Color.Green;
        }
    }
}