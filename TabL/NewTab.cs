using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Xml;

namespace TabL
{
    public class NewTab : MainWindow
    {
        private int id;
        private string title;
        private TabItem tabXaml;
        private TabControl tabControlXaml;
        /// <summary>
        /// The Class NewTab should herit from MainWindow
        /// Basically a tab will have an id in order to recognize it
        /// It has a title, which will be displayed.
        /// Also there are parameters that I use in order to duplicate the tabs such as tabXaml and tabControlXaml
        /// which are in fact the TabItems and TabControls themselves in the xaml code
        /// </summary>
        public NewTab(MainWindow mainWindow, int id, string title) : base(mainWindow)
        {
            TabItem tabitem = GetTabName();
            this.id = id;
            this.title = title;
            this.tabXaml = tabitem;
            this.tabControlXaml = GetTabControlName();
            this.tabControlXaml.SelectionChanged += (sender, args) => 
                throw new NotImplementedException("Implement on selection changed");
            mainWindow.KeyDown += (sender, args) =>
            {
                if (args.Key == Key.T && (Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control)
                {
                    // I have absolutely no idea if this works but it does.
                    NewTabItem();
                }
            };
        }

        private TabControl GetTabControlName()
        {
            // Need to parse the xml document and return the tabcontrol
            throw new NotImplementedException();
        }

        private TabItem GetTabName()
        {
            // Need to parse the xml document and find a tab
            // Return the name or xkey of the tab
            throw new NotImplementedException();
        }

        private void NewTabItem()
        {
            // This function will be called every time you want to add a Tab in your window.
            // Therefore it will duplicate the code from your xaml file
            string tabitem = XamlWriter.Save(FindName(tabXaml.Name + (++id))!);
            StringReader stringReader =
                new StringReader(tabitem + (++id));
            XmlReader xmlReader = XmlReader.Create(stringReader);
            TabItem newTabItem = (TabItem) XamlReader.Load(xmlReader);
            RegisterName(tabXaml.Name + (++id), newTabItem);
            ((TabControl) FindName(tabControlXaml.Name))?.Items.Add(newTabItem);
        }
    }
}