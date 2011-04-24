<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Pm.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    <% Html.RenderPartial("SubMenu"); %>

    <div class="grid_12">

    </div>
    
    <div class="clear"></div> 

</asp:Content>
