<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Pm.Master" Inherits="System.Web.Mvc.ViewPage<CS631.Data.Project>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Create
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <script type="text/javascript">
        $(function () {
            $("#StartDate").datepicker({ showOn: 'both', buttonImage: "/Public/Images/calendar.gif", buttonImageOnly: true });
            $("#EndDate").datepicker({ showOn: 'both', buttonImage: "/Public/Images/calendar.gif", buttonImageOnly: true });
        });
	</script>

    <% Html.RenderPartial("SubMenu"); %>

    <div class="grid_12">
        <div class="section"> 
            <h1>New Project</h1>
            <p>Creat new project</p>
            <br />
            <% using (Html.BeginForm()) { %>
                <%: Html.ValidationSummary(true) %>
                <table class="details">
                    <tr>
                        <th><%: Html.LabelFor(model => model.ProjName) %></th>
                        <td>
                            <%: Html.EditorFor(model => model.ProjName)%>
                            <%: Html.ValidationMessageFor(model => model.ProjName)%>
                        </td>
                    </tr>
                    <tr>
                        <th> <%: Html.LabelFor(model => model.ProjBudget)%></th>
                        <td>
                            <%: Html.EditorFor(model => model.ProjBudget)%>
                            <%: Html.ValidationMessageFor(model => model.ProjBudget)%>
                        </td>
                    </tr>
                    <tr>
                        <th><%: Html.LabelFor(model => model.StartDate)%></th>
                        <td>
                            <%: Html.EditorFor(model => model.StartDate)%>
                            <%: Html.ValidationMessageFor(model => model.StartDate)%>
                        </td>
                    </tr>
                    <tr>
                        <th><%: Html.LabelFor(model => model.EndDate)%></th>
                        <td>
                            <%: Html.EditorFor(model => model.EndDate)%>
                            <%: Html.ValidationMessageFor(model => model.EndDate)%>
                        </td>
                    </tr>
                </table>
                <div class="clear"></div> 
                <div>
                    <input type="submit" value="Create" class="action_button"/>
                </div>
                <div class="clear"></div>
            <% } %>
        </div>
    </div>
    <div class="clear"></div> 
</asp:Content>

