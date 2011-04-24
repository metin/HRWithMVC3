<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>

<% string curAction = ViewContext.Controller.ValueProvider.GetValue("action").RawValue as string; %> 
<% string curController =  ViewContext.Controller.ValueProvider.GetValue("controller").RawValue as string; %> 


<div id="menu_container">
    <ul id="menu">
        <li class="<%: curController=="PmHome" ? "current" : "" %>">
            <%: Html.ActionLink("Home", "Index", "PmHome") %>
        </li>
        <li class="<%: curController=="Projects" ? "current" : "" %>">
            <%: Html.ActionLink("Projects", "Index", "Projects") %>
        </li>
    </ul>

</div>


