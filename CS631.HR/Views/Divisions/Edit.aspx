<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<CS631.Data.Division>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Edit
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <% Html.RenderPartial("SubMenu"); %>

    <div class="grid_2">
        <% Html.RenderPartial("LeftMenu", Model, new ViewDataDictionary(Model)); %>
    </div>

    <div class="grid_10">
        <div class="form">
            <h1>Edit Division</h1>
            <p>Edit division <%: Model.name %></p>
            <br />


            <% using (Html.BeginForm()) { %>
                <%: Html.HiddenFor(model => model.id) %>
                <%: Html.ValidationSummary(true) %>
                <div>
                    <%: Html.LabelFor(model => model.name) %>
                    <%: Html.EditorFor(model => model.name) %>
                    <%: Html.ValidationMessageFor(model => model.name) %>
                </div>
                <div class="clear"></div> 
                <div>
                    <input type="submit" value="Save" class="action_button"/>
                </div>
                <div class="clear"></div> 
            <% } %>
        </div>
    </div>
    <div class="clear"></div> 
</asp:Content>

