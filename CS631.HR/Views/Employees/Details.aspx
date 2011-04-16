<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<CS631.Data.Employee>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="grid_2">
        <% Html.RenderPartial("LeftMenu"); %>
    </div>

    <div class="grid_10">
        <fieldset>
            <legend>Employee</legend>
            
            <div class="display-label">Employee NO</div>
            <div class="display-field"><%: Model.EmployeeNO%></div>

            <div class="display-label">Fist Name</div>
            <div class="display-field"><%: Model.first_name %></div>

            <div class="display-label">last_name</div>
            <div class="display-field"><%: Model.last_name %></div>
        </fieldset>
        <p>
            <%: Html.ActionLink("Edit", "Edit", new { id=Model.id }) %> |
            <%: Html.ActionLink("Back to List", "Index") %>
        </p>
    </div>

</asp:Content>
