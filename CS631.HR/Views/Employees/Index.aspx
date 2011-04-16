<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<div class="grid_2">
    <% Html.RenderPartial("LeftMenu"); %>
</div>

<div class="grid_10">
    <h2>List Of Employees</h2>
    <table width="100%">
        <thead>
            <tr>
                <th> Empoyee No </th>
                <th> First Name </th>
                <th> Last Name </th>
                <th>Show</th>
                <th>Edit</th>
                <th>Delete</th>
            </tr>
        </thead>
        <tbody>
            <% foreach (var e in ViewBag.employees)  { %>
                <tr>
                    <td><%: e.EmployeeNO%> </td>
                    <td><%: e.first_name %> </td>
                    <td><%: e.last_name %> </td>
                    <td><%: Html.ActionLink("Show", "Details", new { id = e.id} ) %></td>
                    <td><%: Html.ActionLink("Edit", "Edit", new { id = e.id} ) %></td>
                    <td><%: Html.ActionLink("Delete", "Delete", new { id = e.id} ) %></td>
                </tr>
            <% } %>
        </tbody>
    </table>

</div>
 <div class="clear"></div> 

</asp:Content>
