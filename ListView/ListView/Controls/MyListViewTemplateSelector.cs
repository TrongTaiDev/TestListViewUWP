using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace ListView.Controls
{
    public class MyListViewTemplateSelector : DataTemplateSelector
    {
        public DataTemplate FirstItem { get; set; }
        public DataTemplate DefaultItem { get; set; }
        public DataTemplate LastItem { get; set; }

        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {
            Room tempRoom = item as Room;
            if (tempRoom.id.Equals("1")) return FirstItem;
            if (tempRoom.id.Equals("2")) return DefaultItem;
            return LastItem;
        }
    }
}
