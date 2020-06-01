﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;

namespace TabL
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int id;
        private string xamlTabControlName = "TabControl";
        private string xamlTabName = "Tab";
        public MainWindow()
        {
            InitializeComponent();
            KeyDown += OpenTab;
            KeyDown += CloseTab;
            this.id = 0;
        }
        private void OpenTab(object sender, KeyEventArgs e)
        {
            // There I'm opening a tab only if the user presses CTRL + T
            if (e.Key == Key.T && (Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control)
            {
                NewTabItem();
            }
        }

        private void CloseTab(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.W && (Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control)
            {
                NewTabItem();
            }
        }
        /// <summary>
        /// This function copies an existing tab
        /// </summary>
        /// <param name="id">The id of the tab in order to differenciate it for example, I'm just incrementing a value from 0</param>
        /// <param name="xamlTabControlName">The name of the TabControl in which you have a tab to duplicate</param>
        /// <param name="xamlTabName">The name of the TabItem (in your xaml file) you want to duplicate</param>
        private void NewTabItem()
        {
            ++id;
            string tabitem = XamlWriter.Save(FindName(xamlTabName));
            tabitem = tabitem.Replace($"Name=\"{xamlTabName}\"", $"Name=\"{xamlTabName+id}\"");
            StringReader stringReader =
                new StringReader(tabitem.Replace("_id_", id.ToString()));
            XmlReader xmlReader = XmlReader.Create(stringReader);
            TabItem newTabControl = (TabItem) XamlReader.Load(xmlReader);
            RegisterName(xamlTabName + id, newTabControl);
            ((TabControl) FindName(xamlTabControlName))?.Items.Add(newTabControl);
        }

        private void UnregisterTabById(int myId)
        {
            // You should unregister the name of the deleted tab
            UnregisterName(xamlTabName + myId);
        }

        private void RemoveTabAt(int index)
        {
            ((TabControl) FindName(xamlTabControlName)).Items.RemoveAt(index);
            // When deleting a tab you can set it to the last for example whith this line
            TabControl.SelectedIndex = GetTabControlById(id).Items.Count - 1;
        }

        private TabControl GetTabControlById(int myId)
        {
            // Now that TabControl has been registered you can find it this way
            return (TabControl) FindName(xamlTabControlName + myId);
        }
        private TabItem GetTabById(int myId)
        {
            // Now that Tabs have been registered you can find them this way
            return (TabItem) FindName(xamlTabName + myId);
        }
    }
}