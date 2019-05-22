using System.Windows.Forms;

namespace ContractsDemo
{
    internal interface IMenuPlugin
    {
        string Name { get; }
        void Transform(Label label);
    }
}