<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<HR.Data.Employee>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Edit
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Edit</h2>

<% using (Html.BeginForm()) { %>
    <%: Html.ValidationSummary(true) %>
    <fieldset>
        <legend>Employee</legend>

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

<div>
    <%: Html.ActionLink("Back to List", "Index") %>
</div>

</asp:Content>

