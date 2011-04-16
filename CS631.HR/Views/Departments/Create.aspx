<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<CS631.Data.Department>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Create
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="grid_2">
        <% Html.RenderPartial("LeftMenu"); %>
    </div>

    <div class="grid_10">

        <% using (Html.BeginForm()) { %>
            <%: Html.ValidationSummary(true) %>
            <fieldset>
                <legend>New Department</legend>

                <div class="editor-label">
                    <%: Html.LabelFor(model => model.name) %>
                </div>
                <div class="editor-field">
                    <%: Html.EditorFor(model => model.name) %>
                    <%: Html.ValidationMessageFor(model => model.name) %>
                </div>

                <p>
                    <input type="submit" value="Create" />
                </p>
            </fieldset>
        <% } %>
    </div>

</asp:Content>

