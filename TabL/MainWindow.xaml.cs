using System;
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
    public partial class MainWindow
    {
        private int id;

        // Dictionary to manage tabs information
        // You can change the type of the value (can be any object you want to save)
        // You can easily access it through the tab ID
        private Dictionary<string, int> opened_Tabs = new Dictionary<string, int>();
        

        // All you need to do for a basic use of tabs duplication is modify those two constants
        private const string TAB_CONTROL_NAME = "TabControl";
        private const string TAB_NAME = "Tab_id_";

        private string xamlTabControlName = TAB_CONTROL_NAME;
        private string xamlTabName = TAB_NAME;

        private TabControl tabControl;
        private string currentTabId;
        private int currentTabIndex;

        public MainWindow()
        {
            InitializeComponent();
            tabControl = GetTabControl();
            KeyDown += OpenTab;
            KeyDown += CloseTab;
            tabControl.SelectionChanged += TabControlSelectionChanged;
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
            if (tabControl.Items.Count > 1 &&
                e.Key == Key.W && (Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control)
            {
                RemoveTabAtCurrent();
            }
        }

        private void TabControlSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = GetCurrentTabIndex();
            if (index == -1)
            {
                if (currentTabIndex > 0)
                    currentTabIndex -= 1; // -1 to get to the previous index because there is deletion
            }
            else
                currentTabIndex = index;
            currentTabId = GetCurrentTabId();
        }

        /// <summary>
        /// This function copies an existing tab
        /// </summary>
        /// <param name="id">The id of the tab in order to
        /// differenciate it for example, I'm just incrementing a value from 0</param>
        /// <param name="xamlTabControlName">The name of the TabControl in which you have a tab to duplicate</param>
        /// <param name="xamlTabName">The name of the TabItem (in your xaml file) you want to duplicate</param>
        private void NewTabItem()
        {
            ++id;
            string tabitem = XamlWriter.Save(FindName(xamlTabName));
            tabitem = tabitem.Replace($"Name=\"{xamlTabName}\"", $"Name=\"{xamlTabName + id}\"");
            StringReader stringReader =
                new StringReader(tabitem.Replace("_id_", id.ToString()));
            XmlReader xmlReader = XmlReader.Create(stringReader);
            TabItem newtabItem = (TabItem) XamlReader.Load(xmlReader);
            RegisterName(xamlTabName + id, newtabItem);
            tabControl?.Items.Add(newtabItem);
            tabControl.SelectedIndex = GetTabControl().Items.Count - 1;
            opened_Tabs.Add(id.ToString(), currentTabIndex); // You can add whatever you want instead of currentTabIndex
            newtabItem.Header = "Test" + id;
        }

        private void RemoveTabAtCurrent()
        {
            ItemCollection list = ((TabControl) FindName(xamlTabControlName)).Items;
            list.RemoveAt(currentTabIndex);
            // When deleting a tab you can set it to the last for example whith this line
            // tabControl.SelectedIndex = GetTabControl().Items.Count - 1;
        }

        private TabControl GetTabControl()
        {
            // Now that TabControl has been registered you can find it this way
            return (TabControl) FindName(xamlTabControlName);
        }

        private int GetCurrentTabIndex()
        {
            int index = GetTabControl().SelectedIndex;
            return index;
        }

        private string GetCurrentTabId()
        {
            int index = currentTabIndex;
            TabItem tabItem = GetTabControl().Items[index] as TabItem;
            return tabItem.Name.Replace(xamlTabName, "");
        }
    }
}