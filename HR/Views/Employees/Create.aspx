<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<HR.Models.Employee>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Create
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Create</h2>

<script src="<%: Url.Content("~/Scripts/jquery.validate.min.js") %>" type="text/javascript"></script>
<script src="<%: Url.Content("~/Scripts/jquery.validate.unobtrusive.min.js") %>" type="text/javascript"></script>

<% using (Html.BeginForm()) { %>
    <%: Html.ValidationSummary(true) %>
    <fieldset>
        <legend>Employee</legend>

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
            <input type="submit" value="Create" />
        </p>
    </fieldset>
<% } %>

<div>
    <%: Html.ActionLink("Back to List", "Index") %>
</div>

</asp:Content>

