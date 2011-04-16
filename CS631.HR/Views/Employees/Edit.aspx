<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<CS631.Data.Employee>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Edit
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="grid_2">
        <% Html.RenderPartial("LeftMenu"); %>
    </div>

    <div class="grid_10">

        <% using (Html.BeginForm()) { %>
            <%: Html.ValidationSummary(true) %>
            <fieldset>
                <legend>Edit Employee</legend>

                <%: Html.HiddenFor(model => model.id) %>

                <div class="editor-label">
                    <%: Html.LabelFor(model => model.first_name) %>
                </div>
                <div class="editor-field">
                    <%: Html.EditorFor(model => model.first_name) %>
                    <%: Html.ValidationMessageFor(model => model.first_name) %>
                </div>

                <div class="editor-label">
                    <%: Html.LabelFor(model => model.last_name) %>
                </div>
                <div class="editor-field">
                    <%: Html.EditorFor(model => model.last_name) %>
                    <%: Html.ValidationMessageFor(model => model.last_name) %>
                </div>

                <p>
                    <input type="submit" value="Save" />
                </p>
            </fieldset>
        <% } %>
    </div>

</asp:Content>

