<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>

<ul>
    <li><%: Html.ActionLink("All Departments", "Index", "Departments")%></li>
    <li><%: Html.ActionLink("New Department", "Create", "Departments")%></li>
</ul>