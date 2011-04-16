<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>

<% string curAction = ViewContext.Controller.ValueProvider.GetValue("action").RawValue as string; %> 
<% var d = ViewData.Model as CS631.Data.Division; %>

<div id="left_menu">
    <ul id="left_list">
        <li class="<%: curAction=="Details" ? "current" : "" %>">
            <%: Html.ActionLink("Show", "Details", new { id = d.id })%>
        </li>
        <li class="<%: curAction=="Edit" ? "current" : "" %>">
            <%: Html.ActionLink("Edit", "Edit", new { id = d.id })%>
        </li>
    </ul>
</div>