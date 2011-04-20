<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<CS631.Data.Building>" %>

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

            <h1>Building Details</h1>
            <p>Details of building</p>

            <table class="details">
                <tr>
                    <th><%: Html.LabelFor(model => model.Name) %></th>
                    <td>
                        <%: Model. Name  %>
                    </td>
                </tr>
                <tr>
                    <th> <%: Html.LabelFor(model => model.Code)%></th>
                    <td>
                        <%: Model.Code %>
                    </td>
                </tr>
                <tr>
                    <th><%: Html.LabelFor(model => model.Year)%></th>
                    <td>
                        <%: Model.Year %>
                    </td>
                </tr>
                <tr>
                    <th><%: Html.LabelFor(model => model.Cost)%></th>
                    <td>
                        <%: String.Format("${0:F}", Model.Cost) %>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <div class="clear"></div> 



</asp:Content>

