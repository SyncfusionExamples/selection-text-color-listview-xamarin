# How to change the ListView selected item text color in Xamarin.Forms (SfListView)

In Xamarin.Forms [ListView](https://help.syncfusion.com/xamarin/listview/overview?), you can change the text color of selected item by using [SelectionChanging](https://help.syncfusion.com/cr/xamarin/Syncfusion.SfListView.XForms~Syncfusion.ListView.XForms.SfListView~SelectionChanging_EV.html?) event.

You can also refer the following article.

https://www.syncfusion.com/kb/11363/how-to-change-the-listview-selected-item-text-color-in-xamarin-forms-sflistview

**C#**

TextColor updated in SelectionChanging event, based on selection added or removed.

``` c#
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
```
**XAML**

LabelTextColor bound to the Label added to **SfListView** in the [ItemTemplate](https://help.syncfusion.com/cr/xamarin/Syncfusion.SfListView.XForms~Syncfusion.ListView.XForms.SfListView~ItemTemplate.html?) and Behaviour.

``` xml
<syncfusion:SfListView x:Name="listView" ItemSpacing="1" SelectionMode="Single"
                        SelectionBackgroundColor="LightGray" AutoFitMode="Height" 
                        ItemsSource="{Binding contactsinfo}">
    <syncfusion:SfListView.Behaviors>
        <local:Behavior/>
    </syncfusion:SfListView.Behaviors>
    <syncfusion:SfListView.ItemTemplate >
        <DataTemplate>
            <ViewCell>
                <ViewCell.View>
                    <Grid x:Name="grid" RowSpacing="0">
                        <Grid.RowDefinitions>
                            <RowDefinition Height="*" />
                            <RowDefinition Height="1" />
                        </Grid.RowDefinitions>
                        <Grid RowSpacing="0">
                            <Grid.ColumnDefinitions>
                                <ColumnDefinition Width="70" />
                                <ColumnDefinition Width="*" />
                                <ColumnDefinition Width="Auto" />
                            </Grid.ColumnDefinitions>
 
                            <Image Source="{Binding ContactImage}"
                                    VerticalOptions="Center"
                                    HorizontalOptions="Center"
                                    HeightRequest="50" WidthRequest="50"/>
 
                            <Grid Grid.Column="1" RowSpacing="1" Padding="10,0,0,0" VerticalOptions="Center">
                                <Grid.RowDefinitions>
                                    <RowDefinition Height="*" />
                                    <RowDefinition Height="*" />
                                </Grid.RowDefinitions>
 
                                <Label LineBreakMode="NoWrap"  Text="{Binding ContactName}" 
                                        TextColor="{Binding LabelTextColor}"/>
                                <Label Grid.Row="1" Grid.Column="0"
                                        TextColor="{Binding LabelTextColor}"
                                        LineBreakMode="NoWrap" Text="{Binding ContactNumber}"/>
                            </Grid>
                        </Grid>
                    </Grid>
                </ViewCell.View>
            </ViewCell>
        </DataTemplate>
    </syncfusion:SfListView.ItemTemplate>
</syncfusion:SfListView>
```

**Output**

![SelectionTextColor](https://github.com/SyncfusionExamples/selection-text-color-listview-xamarin/blob/master/ScreeShots/SelectionTextColor.png)

