<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<CS631.Data.Employee>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Create
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <% Html.RenderPartial("SubMenu"); %>

    <div class="grid_12">

         <% using (Html.BeginForm()) { %>
            <%: Html.ValidationSummary(true) %>
            <fieldset>
                <legend>New Employee</legend>

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
                <br />
                <p>
                    <input type="submit" value="Create" class="action_button"/>
                </p>
            </fieldset>
        <% } %>
    </div>
    <div class="clear"></div> 

</asp:Content>

