<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<CS631.Data.Division>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <% Html.RenderPartial("SubMenu"); %>

    <div class="grid_12">
        <div class="section" > 
            <h1>List Of Divisions</h1>
            <p />
            <table width="100%">
                <thead>
                    <tr>
                        <th>Division No</th>
                        <th>Name</th>
                        <th>Actions</th>
                    </tr>
                </thead>
                <tbody>
                    <% foreach (var d in ViewBag.divisions)  { %>
                        <tr>
                            <td><%: d.DivisionNo %> </td>
                            <td><%: d.name %> </td>
                            <td class="action_buttons"> 
                                <%: Html.ActionLink("Show", "Details", new { id = d.id }, new { @class="jqui_button_show", style="padding: 0px;" })%> 
                                <%: Html.ActionLink("Edit", "Edit", new { id = d.id }, new { @class = "jqui_button_edit" })%> 
                                <%: Html.ActionLink("Delete", "Delete", new { id = d.id }, new { @class = "jqui_button_delete" })%>
                            </td>
                        </tr>
                    <% } %>
                </tbody>
            </table>
        </div>

    </div>
    <div class="clear"></div> 

</asp:Content>
