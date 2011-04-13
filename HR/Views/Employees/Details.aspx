<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Details</h2>
    <table>
        <tr>
            <td> First Name </td>
            <td> <%= ViewBag.employee.first_name %> </td>
        </tr>

        <tr>
            <td> Last Name </td>
             <td> <%= ViewBag.employee.last_name%> </td>
        </tr>

    </table>
</asp:Content>
