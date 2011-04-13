<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
                    <%: Html.ActionLink("Employees", "Create", "Employees")%>

                    <br />
<%: ViewBag.empid %>

<h2>List Of Employees</h2>
<table>
    <thead>
        <tr>
            <th> Empoyee ID </th>
            <th> First Name </th>
            <th> Last Name </th>
            <th>Show</th>
            <th>Edit</th>
            <th>Delete</th>
        </tr>
    </thead>
    <tbody>
        <% foreach (HR.Models.Employee e in ViewBag.employees)  { %>
            <tr>
                <td><%: e.id %> </td>
                <td><%: e.first_name %> </td>
                <td><%: e.last_name %> </td>
                <td><%: Html.ActionLink("Show", "Details", new { id = e.id} ) %></td>
                <td><%: Html.ActionLink("Edit", "Edit", new { id = e.id} ) %></td>
                <td><%: Html.ActionLink("Delete", "Delete", new { id = e.id} ) %></td>
            </tr>
        <% } %>
    </tbody>
</table>


</asp:Content>
