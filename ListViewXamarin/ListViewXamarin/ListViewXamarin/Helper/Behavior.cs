using Syncfusion.ListView.XForms;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ListViewXamarin
{
    public class Behavior : Behavior<SfListView>
    {
        SfListView listView;
        protected override void OnAttachedTo(SfListView bindable)
        {
            listView = bindable;
            listView.SelectionChanging += ListView_SelectionChanging;
            base.OnAttachedTo(bindable);
        }

        private void ListView_SelectionChanging(object sender, ItemSelectionChangingEventArgs e)
        {
            if (listView.SelectionMode == Syncfusion.ListView.XForms.SelectionMode.Single)
            {
                if (e.AddedItems.Count > 0)
                {
                    var item = e.AddedItems[0] as Contacts;
                    item.LabelTextColor = Color.Red;
                }
                if (e.RemovedItems.Count > 0)
                {
                    var item = e.RemovedItems[0] as Contacts;
                    item.LabelTextColor = Color.Black;
                }
            }
        }

        protected override void OnDetachingFrom(SfListView bindable)
        {
            listView.SelectionChanging -= ListView_SelectionChanging;

            base.OnDetachingFrom(bindable);
        }
    }
}
