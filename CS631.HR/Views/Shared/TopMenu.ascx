<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>

<% string curAction = ViewContext.Controller.ValueProvider.GetValue("action").RawValue as string; %> 
<% string curController =  ViewContext.Controller.ValueProvider.GetValue("controller").RawValue as string; %> 

<div class="grid_12" style="height:20px; background-color:#D10000"></div> 
<div class="clear"></div> 

<div class="top_menu grid_8">
    <ul>
        <li class="<%: curController=="Home" ? "current" : "" %>">
            <%: Html.ActionLink("Home", "Index", "Home") %>
        </li>
        <li class="<%: curController=="Divisions" ? "current" : "" %>">
             <%: Html.ActionLink("Divisions", "Index", "Divisions")%>
        </li>    

        <li class="<%: curController=="Employees" ? "current" : "" %>">
             <%: Html.ActionLink("Employees", "Index", "Employees") %>
        </li>
        <li class="<%: curController=="Projects" ? "current" : "" %>">
             <%: Html.ActionLink("Projects", "Index", "Projects") %>
        </li>    
        <li class="<%: curController=="Departments" ? "current" : "" %>">
             <%: Html.ActionLink("Departments", "Index", "Departments")%>
        </li>    
    </ul>
</div>
<div class="top_menu grid_4">
    <form id="search_from">
        <input type="text" class="textinput" /> <input class="submit" type="submit" value="Find" />
    </form>
</div>
<div class="clear"></div> 
