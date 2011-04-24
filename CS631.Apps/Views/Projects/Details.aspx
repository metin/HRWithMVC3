<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Pm.Master" Inherits="System.Web.Mvc.ViewPage<CS631.Data.Project>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <% Html.RenderPartial("SubMenu"); %>

    <div class="grid_2 nopadding">
        <% Html.RenderPartial("LeftMenu", Model, new ViewDataDictionary(Model)); %>
    </div>

    <div class="grid_10">
        <div class="section">

            <h1>Project Details</h1>
            <p>Details of project that</p>

            <table class="details">
                <tr>
                    <th><%: Html.LabelFor(model => model.name) %></th>
                    <td>
                        <%: Model.name  %>
                    </td>
                </tr>
                <tr>
                    <th> <%: Html.LabelFor(model => model.Budget)%></th>
                    <td>
                        <%: Model.Budget %>
                    </td>
                </tr>
                <tr>
                    <th><%: Html.LabelFor(model => model.DateStarted)%></th>
                    <td>
                        <%: Model.DateStarted %>
                    </td>
                </tr>
                <tr>
                    <th><%: Html.LabelFor(model => model.DateEnded)%></th>
                    <td>
                        <%: Model.DateEnded %>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <div class="clear"></div> 
</asp:Content>

