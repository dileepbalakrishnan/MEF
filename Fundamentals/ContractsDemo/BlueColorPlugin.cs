using System.ComponentModel.Composition;
using System.Drawing;
using System.Windows.Forms;

namespace ContractsDemo
{
    [Export("Color", typeof(IMenuPlugin))]
    internal class BlueColorPlugin : IMenuPlugin
    {
        public string Name => "Blue";

        public void Transform(Label label)
        {
            label.ForeColor = Color.Blue;
        }
    }
}