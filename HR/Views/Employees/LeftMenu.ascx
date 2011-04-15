<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>

<ul>
    <li><%: Html.ActionLink("All Employees", "Index", "Employees")%></li>
    <li><%: Html.ActionLink("New Employee", "Create", "Employees")%></li>
</ul>