using System;
using System.ComponentModel.Composition;

namespace MetadataWithStrongType
{
    [MetadataAttribute]
    public class MenuPluginMetadataAttribute : Attribute, IMenuPluginMetadata
    {
        public string MenuText { get; private set; }

        public MenuPluginMetadataAttribute(string menuText)
        {
            MenuText = menuText;
        }
    }
}