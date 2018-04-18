using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Notifications;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace ListView.Controls
{
    public sealed partial class ListViewSelector : UserControl
    {
        List<Room> allRooms = new List<Room>
        {
                new Room("1", "Fujinet1"),
                new Room("2", "Fujinet1"),
                new Room("2", "Fujinet1"),
                new Room("2", "Fujinet1"),
                new Room("3", "Fujinet1"),
        };
        ItemList items;
        public ListViewSelector()
        {
            this.InitializeComponent();
            items = new ItemList(allRooms);
            DemoList.ItemsSource = items.Items;
        }

        private void ShowToastNotification(string title, string stringContent)
        {
            ToastNotifier ToastNotifier = ToastNotificationManager.CreateToastNotifier();
            Windows.Data.Xml.Dom.XmlDocument toastXml = ToastNotificationManager.GetTemplateContent(ToastTemplateType.ToastText02);
            Windows.Data.Xml.Dom.XmlNodeList toastNodeList = toastXml.GetElementsByTagName("text");
            toastNodeList.Item(0).AppendChild(toastXml.CreateTextNode(title));
            toastNodeList.Item(1).AppendChild(toastXml.CreateTextNode(stringContent));
            Windows.Data.Xml.Dom.IXmlNode toastNode = toastXml.SelectSingleNode("/toast");
            Windows.Data.Xml.Dom.XmlElement audio = toastXml.CreateElement("audio");
            audio.SetAttribute("src", "ms-winsoundevent:Notification.SMS");

            ToastNotification toast = new ToastNotification(toastXml);
            toast.ExpirationTime = DateTime.Now.AddSeconds(4);
            ToastNotifier.Show(toast);
        }

        private void btnDown_Click(object sender, RoutedEventArgs e)
        {

            //ShowToastNotification("Clicked!", e.OriginalSource.ToString());
            var item = (Button)sender;
            Room listitem = (from itm in allRooms
                             where itm.id == item.CommandParameter.ToString()
                             select
                             itm).FirstOrDefault<Room>();
            int index = allRooms.IndexOf(listitem);
            SwapTwoItem(items, index, index + 1);
            //ShowToastNotification("Clicked!",index.ToString());
        }
        private void btnUp_Click(object sender, RoutedEventArgs e)
        {

            //ShowToastNotification("Clicked!", e.OriginalSource.ToString());
            var item = (Button)sender;
            Room listitem = (from itm in allRooms
                             where itm.id == item.CommandParameter.ToString()
                             select
                             itm).FirstOrDefault<Room>();
            int index = allRooms.IndexOf(listitem);
            SwapTwoItem(items, index, index - 1);
            //ShowToastNotification("Clicked!", index.ToString());
        }

        private void SwapTwoItem(ItemList list, int x, int y)
        {
            Room temp = list.Items[x];
            list.Items[x] = list.Items[y];
            list.Items[y] = temp;
        }

    }
}
