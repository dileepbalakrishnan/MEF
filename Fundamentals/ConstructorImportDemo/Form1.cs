using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Windows.Forms;

namespace ConstructorImportDemo
{
    [Export]
    public partial class Form1 : Form
    {
        private IEnumerable<Lazy<IMenuPlugin, Dictionary<string, object>>> _colorPlugins;

        private IEnumerable<Lazy<IMenuPlugin, Dictionary<string, object>>> _sizePlugins;

        [ImportingConstructor]
        public Form1([ImportMany("Color")] IEnumerable<Lazy<IMenuPlugin, Dictionary<string, object>>> colorPlugins,
            [ImportMany("Size")] IEnumerable<Lazy<IMenuPlugin, Dictionary<string, object>>> sizePlugins)
        {
            _colorPlugins = colorPlugins;
            _sizePlugins = sizePlugins;
            InitializeComponent();
            AddMenuItems();
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

        private ToolStripMenuItem BuildMenuPlugin(Lazy<IMenuPlugin, Dictionary<string, object>> menuPlugin)
        {
            var tm = new ToolStripMenuItem(menuPlugin.Metadata[StringConstants.MenutextKey].ToString());
            tm.Click += Tm_Click;
            tm.Tag = menuPlugin;
            return tm;
        }

        private void Tm_Click(object sender, EventArgs e)
        {
            var plugin = ((ToolStripMenuItem) sender).Tag as Lazy<IMenuPlugin, Dictionary<string, object>>;
            plugin.Value.Transform(label1);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //AddMenuItems();
        }
    }
}