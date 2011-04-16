<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<CS631.Data.Project>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <% Html.RenderPartial("SubMenu"); %>

    <div class="grid_2">
        <% Html.RenderPartial("LeftMenu", Model, new ViewDataDictionary(Model)); %>
    </div>

    <div class="grid_10">
        <fieldset>
            <legend>Project Details</legend>
            <div class="display-label">name</div>
            <div class="display-field"><%: Model.name %></div>
        </fieldset>
    </div>
    <div class="clear"></div> 
</asp:Content>

