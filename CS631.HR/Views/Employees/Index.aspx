<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <% Html.RenderPartial("SubMenu"); %>

    <div class="grid_12">
        <h2>List Of Employees</h2>
        <table width="100%">
            <thead>
                <tr>
                    <th> Empoyee No </th>
                    <th> First Name </th>
                    <th> Last Name </th>
                    <th>Actions</th>
                </tr>
            </thead>
            <tbody>
                <% foreach (var e in ViewBag.employees)  { %>
                    <tr>
                        <td><%: e.EmployeeNO%> </td>
                        <td><%: e.first_name %> </td>
                        <td><%: e.last_name %> </td>
                        <td class="action_buttons"> 
                            <%: Html.ActionLink("Show", "Details", new { id = e.id }, new { @class="jqui_button_show", style="padding: 0px;" })%> 
                            <%: Html.ActionLink("Edit", "Edit", new { id = e.id }, new { @class = "jqui_button_edit" })%> 
                            <%: Html.ActionLink("Delete", "Delete", new { id = e.id }, new { @class = "jqui_button_delete" })%>
                        </td>

                    </tr>
                <% } %>
            </tbody>
        </table>

    </div>
     <div class="clear"></div> 

</asp:Content>
