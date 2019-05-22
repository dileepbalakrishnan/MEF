using System.ComponentModel.Composition;
using System.Drawing;
using System.Windows.Forms;

namespace ContractsDemo
{
    [Export("Color", typeof(IMenuPlugin))]
    internal class GreenColorPlugin : IMenuPlugin
    {
        public string Name => "Green";

        public void Transform(Label label)
        {
            label.ForeColor = Color.Green;
        }
    }
}