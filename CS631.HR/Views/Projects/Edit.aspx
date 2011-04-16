<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<CS631.Data.Project>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Edit
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        $(function () {
            $("#DateStarted").datepicker({ showOn: 'both' });
            $("#DateEnded").datepicker({ showOn: 'both' });
        });
	</script>

    <% Html.RenderPartial("SubMenu"); %>

    <div class="grid_2">
        <% Html.RenderPartial("LeftMenu", Model, new ViewDataDictionary(Model)); %>
    </div>


    <div class="grid_10">
        <% using (Html.BeginForm()) { %>
            <%: Html.ValidationSummary(true) %>
            <fieldset>
                <legend>Edit Project</legend>

                <%: Html.HiddenFor(model => model.id) %>

                <div class="editor-label">
                    <%: Html.LabelFor(model => model.name) %>
                </div>
                <div class="editor-field">
                    <%: Html.EditorFor(model => model.name) %>
                    <%: Html.ValidationMessageFor(model => model.name) %>
                </div>
                <div class="editor-label">
                    <%: Html.LabelFor(model => model.Budget)%>
                </div>
                <div class="editor-field">
                    <%: Html.EditorFor(model => model.Budget) %>
                    <%: Html.ValidationMessageFor(model => model.Budget)%>
                </div>

                <div class="editor-label">
                    <%: Html.LabelFor(model => model.DateStarted)%>
                </div>
                <div class="editor-field">
                    <%: Html.EditorFor(model => model.DateStarted) %>
                    <%: Html.ValidationMessageFor(model => model.DateStarted)%>
                </div>

                <div class="editor-label">
                    <%: Html.LabelFor(model => model.DateEnded)%>
                </div>
                <div class="editor-field">
                    <%: Html.EditorFor(model => model.DateEnded)%>
                    <%: Html.ValidationMessageFor(model => model.DateEnded)%>
                </div>
                <br />
                <p>
                    <input type="submit" value="Save" class="action_button" />
                </p>
            </fieldset>
        <% } %>
    </div>
    <div class="clear"></div> 

</asp:Content>

