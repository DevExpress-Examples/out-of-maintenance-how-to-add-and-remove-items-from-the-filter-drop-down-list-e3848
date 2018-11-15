<!-- default file list -->
*Files to look at*:

* [MainPage.xaml](./CS/DXPivotGrid_CustomFilterItems/MainPage.xaml) (VB: [MainPage.xaml](./VB/DXPivotGrid_CustomFilterItems/MainPage.xaml))
* [MainPage.xaml.cs](./CS/DXPivotGrid_CustomFilterItems/MainPage.xaml.cs) (VB: [MainPage.xaml](./VB/DXPivotGrid_CustomFilterItems/MainPage.xaml))
<!-- default file list end -->
# How to add and remove items from the filter drop-down list


<p>The following example shows how to add and remove items from the filter dropdown list.</p><p>In this example, the 'UK' item is hidden from the filter dropdown list of the Country field, and a dummy item is created and added to the list. To do this, the CustomFilterPopupItems event is handled. In the event handler, the 'UK' item is removed from the event parameter's Items collection, and a new item ('Dummy Item') is added to the collection.</p><br />


<br/>


