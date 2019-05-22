using System.ComponentModel.Composition;
using System.Drawing;
using System.Windows.Forms;

namespace ContractsDemo
{
    [Export("Color", typeof(IMenuPlugin))]
    internal class RedColorPlugin : IMenuPlugin
    {
        public string Name => "Red";

        public void Transform(Label label)
        {
            label.ForeColor = Color.Red;
        }
    }
}