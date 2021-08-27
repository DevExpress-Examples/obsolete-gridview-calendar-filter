<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/134060099/14.1.6%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T152511)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [HomeController.cs](./CS/T146465/Controllers/HomeController.cs) (VB: [HomeController.vb](./VB/T146465/Controllers/HomeController.vb))
* [MyModel.cs](./CS/T146465/Models/MyModel.cs) (VB: [MyModel.vb](./VB/T146465/Models/MyModel.vb))
* [_GridViewPartial.cshtml](./CS/T146465/Views/Home/_GridViewPartial.cshtml)
* [Index.cshtml](./CS/T146465/Views/Home/Index.cshtml)
* [PartialContent.cshtml](./CS/T146465/Views/Home/PartialContent.cshtml)
<!-- default file list end -->
# OBSOLETE - GridView - How to implement a custom HeaderFilter with a calendar for a date column
<!-- run online -->
**[[Run Online]](https://codecentral.devexpress.com/t152511)**
<!-- run online end -->


<p><strong>UPDATED:</strong><br><br>Starting with version v2015 vol 2 (v15.2), this functionality is available out of the box. Simply set the <a href="https://documentation.devexpress.com/#AspNet/DevExpressWebGridViewDataColumnHeaderFilterSettings_Modetopic">MVCxGridViewColumn.SettingsHeaderFilter.Mode</a> property to <strong>DateRangePicker</strong> to activate it. Please refer to the <a href="https://community.devexpress.com/blogs/aspnet/archive/2015/11/10/asp-net-grid-view-data-range-filter-adaptivity-and-more-coming-soon-in-v15-2.aspx">ASP.NET Grid View - Data Range Filter, Adaptivity and More (Coming soon in v15.2)</a> blog post and the <a href="http://demos.devexpress.com/MVCxGridViewDemos/Filtering/DateRangeHeaderFilter">Date Range Header Filter</a> demo for more information.<br>If you have version v15.2+ available, consider using the built-in functionality instead of the approach detailed below.</p>
<p><br><strong>For Older Versions: </strong><br> This example illustrates how to create a custom HeaderFilter for a date column. The main steps are: </p>
<p>1) create a custom <strong>HeaderTemplate</strong> using the  <strong>SetHeaderTemplateContent</strong> method to prevent default header filter button logic and implement a custom one;<br>2) use the PopupControl to display a Calendar and several additional filters. FormLayout is used to build  a layout;<br>3) use the client <a href="https://documentation.devexpress.com/AspNet/DevExpressWebASPxGridViewScriptsASPxClientGridView_AutoFilterByColumntopic.aspx">AutoFilterByColumn</a> method to perform filtering from the client side and the <a href="https://documentation.devexpress.com/#AspNet/DevExpressWebMVCScriptsMVCxClientGridView_PerformCallbacktopic3863">MVCxClientGridView.PerformCallback</a>  method to pass a complex filter expression to the server to implement custom filtering;;<br>4) process a custom callback in the action method defined using the CustomActionRouteValues property and pass information about the current filter command to a partial view;<br>5) assign a delegate method to the <strong>BeforeGetCallbackResult </strong>property and implement the approach described in the <a href="http://www.devexpress.com/Support/Center/Question/Details/KA18784">ASPxGridView - How to programmatically change the column's filter in the FilterExpression</a>  help article  to apply a new filter.</p>
<p>Click on the "Model Date" column to check how this works.<br><br><strong>Web Forms:<br></strong><a href="https://www.devexpress.com/Support/Center/p/T153163">T153163: OBSOLETE - ASPxGridView - How to implement a custom HeaderFilter with a calendar for a date column </a></p>

<br/>


