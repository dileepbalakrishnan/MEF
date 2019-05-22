using System.ComponentModel.Composition;
using System.Drawing;
using System.Windows.Forms;

namespace ContractsDemo
{
    [Export("Size", typeof(IMenuPlugin))]
    internal class ScaleUpSizePlugin : IMenuPlugin
    {
        public string Name => "Increase by 10";

        public void Transform(Label label)
        {
            label.Font = new Font(label.Font.FontFamily.Name, label.Font.Size + 10);
        }
    }
}