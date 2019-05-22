using System;
using System.ComponentModel.Composition;
using System.Drawing;
using System.Windows.Forms;

namespace ContractsDemo
{
    [Export("Size", typeof(IMenuPlugin))]
    internal class ScaleDownSizePlugin : IMenuPlugin
    {
        public string Name => "Decrease by 10";

        public void Transform(Label label)
        {
            label.Font = new Font(label.Font.FontFamily.Name, Math.Max(label.Font.Size - 10, 10));
        }
    }
}