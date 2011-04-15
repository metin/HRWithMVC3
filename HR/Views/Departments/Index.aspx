﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<div class="grid_2">
    <% Html.RenderPartial("LeftMenu"); %>
</div>

<div class="grid_10">
    <h2>List Of Departments</h2>
    <table width="100%">
        <thead>
            <tr>
                <th> Department ID </th>
                <th> Name </th>
                <th>Show</th>
                <th>Edit</th>
                <th>Delete</th>
            </tr>
        </thead>
        <tbody>
            <% foreach (var d in ViewBag.departments) { %>
                <tr>
                    <td><%: d.id %> </td>
                    <td><%: d.name %> </td>
                    <td><%: Html.ActionLink("Show", "Details", new { id = d.id} ) %></td>
                    <td><%: Html.ActionLink("Edit", "Edit", new { id = d.id} ) %></td>
                    <td><%: Html.ActionLink("Delete", "Delete", new { id = d.id} ) %></td>
                </tr>
            <% } %>
        </tbody>
    </table>

</div>
 <div class="clear"></div> 

</asp:Content>
