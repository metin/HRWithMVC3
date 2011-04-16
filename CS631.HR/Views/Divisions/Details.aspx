<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<CS631.Data.Division>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="grid_2">
        <% Html.RenderPartial("LeftMenu"); %>
    </div>

    <div class="grid_10">

        <fieldset>
            <legend>Division</legend>

            <div class="display-label">name</div>
            <div class="display-field"><%: Model.name %></div>

            <div class="display-label">DivisionNo</div>
            <div class="display-field"><%: Model.DivisionNo %></div>
        </fieldset>
        <p>

            <%: Html.ActionLink("Edit", "Edit", new { id=Model.id }) %> |
            <%: Html.ActionLink("Back to List", "Index") %>
        </p>

    </div>

</asp:Content>

