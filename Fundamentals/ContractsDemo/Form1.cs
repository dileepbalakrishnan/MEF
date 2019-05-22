using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Windows.Forms;

namespace ContractsDemo
{
    public partial class Form1 : Form
    {
        [ImportMany("Color")] private IEnumerable<IMenuPlugin> _colorPlugins;

        [ImportMany("Size")] private IEnumerable<IMenuPlugin> _sizePlugins;

        public Form1()
        {
            InitializeComponent();
        }

        private void AddMenuItems()
        {
            var menuStrip = new MenuStrip();
            var sizeMenu = new ToolStripMenuItem("Size");
            var colorMenu = new ToolStripMenuItem("Color");
            foreach (var p in _sizePlugins)
                sizeMenu.DropDownItems.Add(BuildMenuPlugin(p));

            foreach (var p in _colorPlugins)
                colorMenu.DropDownItems.Add(BuildMenuPlugin(p));

            menuStrip.Items.AddRange(new[] {sizeMenu, colorMenu});
            Controls.Add(menuStrip);
        }

        private ToolStripMenuItem BuildMenuPlugin(IMenuPlugin menuPlugin)
        {
            var tm = new ToolStripMenuItem(menuPlugin.Name);
            tm.Click += Tm_Click;
            tm.Tag = menuPlugin;
            return tm;
        }

        private void Tm_Click(object sender, EventArgs e)
        {
            var plugin = ((ToolStripMenuItem) sender).Tag as IMenuPlugin;
            plugin.Transform(label1);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AddMenuItems();
        }
    }
}