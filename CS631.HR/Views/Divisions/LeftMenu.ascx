<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>

<ul>
    <li><%: Html.ActionLink("All Divisions", "Index", "Divisions")%></li>
    <li><%: Html.ActionLink("New Division", "Create", "Divisions")%></li>
</ul>