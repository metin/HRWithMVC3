<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>

<% string curAction = ViewContext.Controller.ValueProvider.GetValue("action").RawValue as string; %> 
<% string curController =  ViewContext.Controller.ValueProvider.GetValue("controller").RawValue as string; %> 

<% var b = ViewData.Model as CS631.Data.Building; %>

<div id="left_menu">
    <ul id="left_list">
        <li class="<%: curAction=="Details" ? "current" : "" %>">
            <%: Html.ActionLink("Show", "Details", new { id = b.Id })%>
        </li>
        <li class="<%: curAction=="Edit" ? "current" : "" %>">
            <%: Html.ActionLink("Edit", "Edit", new { id = b.Id })%>
        </li>

        <li class="<%: curAction=="Rooms" ? "current" : "" %>">
            <%: Html.ActionLink("Rooms", "Index", "Rooms", new { id = b.Id },  new{}  ) %>
        </li>   
     </ul>
</div>