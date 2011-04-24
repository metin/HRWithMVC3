<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>

<% string curAction = ViewContext.Controller.ValueProvider.GetValue("action").RawValue as string; %> 
<% var e = ViewData.Model as CS631.Data.Employee; %>

<div id="left_menu">
    <ul id="left_list">
        <li class="<%: curAction=="Details" ? "current" : "" %>">
            <%: Html.ActionLink("Show", "Details", new { id = e.id })%>
        </li>
        <li class="<%: curAction=="Edit" ? "current" : "" %>">
            <%: Html.ActionLink("Edit", "Edit", new { id = e.id })%>
        </li>
        <li class="<%: curAction=="Employmeny History" ? "current" : "" %>">
            <%: Html.ActionLink("Salary", "Edit", new { id = e.id })%>
        </li>
        <li class="<%: curAction=="Employmeny History" ? "current" : "" %>">
            <%: Html.ActionLink("Employmeny History", "Edit", new { id = e.id })%>
        </li>

    </ul>
</div>