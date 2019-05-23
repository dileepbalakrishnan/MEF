using System;
using System.ComponentModel.Composition;
using System.Drawing;
using System.Windows.Forms;
using ConstructorImportDemo;

namespace ConstructorImportDemo
{
    [Export("Size", typeof(IMenuPlugin))]
    [ExportMetadata(StringConstants.MenutextKey, "--10")]
    internal class ScaleDownSizePlugin : IMenuPlugin
    {
        public void Transform(Label label)
        {
            label.Font = new Font(label.Font.FontFamily.Name, Math.Max(label.Font.Size - 10, 10));
        }
    }
}