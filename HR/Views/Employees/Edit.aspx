<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Edit
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Edit</h2>
<% using (Html.BeginForm("Edit", "Employees", FormMethod.Post, new { id = ViewBag.employee.id })) %>
<% { %>
    <table>
        <tr>
            <td> First Name </td>
            <td> <%= Html.TextBox("first_name", (string) ViewBag.employee.first_name) %> </td>
        </tr>

        <tr>
            <td> Last Name </td>
             <td> <%= Html.TextBox("last_name", (string) ViewBag.employee.last_name)%> </td>
        </tr>

    </table>

    <div>
        <input type="submit" value="Update" /> 
    </div>
<% } %>
</asp:Content>
