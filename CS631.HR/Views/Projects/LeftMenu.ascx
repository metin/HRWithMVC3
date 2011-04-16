<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>


<ul class = "left_menu">
    <li><%: Html.ActionLink("All Projects", "Index", "Projects")%></li>
    <li><%: Html.ActionLink("New Project", "Create", "Projects")%></li>
</ul>