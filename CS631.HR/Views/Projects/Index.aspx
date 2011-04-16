<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<div class="grid_2">
    <% Html.RenderPartial("LeftMenu"); %>
</div>

<div class="grid_10">
    <h2>List Of Projects</h2>
    <table width="100%">
        <thead>
            <tr>
                <th>Project NO</th>
                <th>Name</th>
                <th>Budget</th>
                <th>Date Started</th>
                <th>Date Ended</th>
                <th>Show</th>
                <th>Edit</th>
                <th>Delete</th>
            </tr>
        </thead>
        <tbody>
            <% foreach (var p in ViewBag.projects)  { %>
                <tr>
                    <td><%: p.ProjectNO %> </td>
                    <td><%: p.name %> </td>
                    <td><%: p.Budget %> </td>
                    <td><%: p.DateStarted.ToString("MM/dd/yyyy")%> </td>
                    <td><%: p.DateEnded.ToString("MM/dd/yyyy")%> </td>
                    <td><%: Html.ActionLink("Show", "Details", new { id = p.id} ) %></td>
                    <td><%: Html.ActionLink("Edit", "Edit", new { id = p.id} ) %></td>
                    <td><%: Html.ActionLink("Delete", "Delete", new { id = p.id} ) %></td>
                </tr>
            <% } %>
        </tbody>
    </table>

</div>
 <div class="clear"></div> 

</asp:Content>
