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
            <h1>Edit Building</h1>
            <p>Editing bulding information </p>
            <br />
            <% using (Html.BeginForm()) { %>
                <%: Html.ValidationSummary(true) %>
                <%: Html.HiddenFor(model => model.Id) %>
                <table class="details">
                    <tr>
                        <th><%: Html.LabelFor(model => model.Name) %></th>
                        <td>
                            <%: Html.EditorFor(model => model.Name) %>
                            <%: Html.ValidationMessageFor(model => model.Name) %>
                        </td>
                    </tr>
                    <tr>
                        <th> <%: Html.LabelFor(model => model.Code)%></th>
                        <td>
                            <%: Html.EditorFor(model => model.Code) %>
                            <%: Html.ValidationMessageFor(model => model.Code)%>
                        </td>
                    </tr>
                    <tr>
                        <th><%: Html.LabelFor(model => model.Year)%></th>
                        <td>
                            <%: Html.EditorFor(model => model.Year) %>
                            <%: Html.ValidationMessageFor(model => model.Year)%>
                        </td>
                    </tr>
                    <tr>
                        <th><%: Html.LabelFor(model => model.Cost)%></th>
                        <td>
                            <%: Html.EditorFor(model => model.Cost)%>
                            <%: Html.ValidationMessageFor(model => model.Cost)%>
                        </td>
                    </tr>
                </table>
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

