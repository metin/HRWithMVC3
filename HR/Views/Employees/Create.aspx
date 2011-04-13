<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Create
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Add New Employee</h2>
<% using(Html.BeginForm("Create", "Employees", FormMethod.Post)) %>
<% { %>
    <table>
        <tr>
            <td> First Name </td>
            <td> <%= Html.TextBox("first_name") %> </td>
        </tr>

        <tr>
            <td> Last Name </td>
             <td> <%= Html.TextBox("last_name") %> </td>
        </tr>

    </table>

    <div>
        <input type="submit" value="Create" /> 
    </div>
<% } %>


</asp:Content>
