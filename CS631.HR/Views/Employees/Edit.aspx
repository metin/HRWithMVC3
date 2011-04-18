<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<CS631.Data.Employee>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Edit
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <% Html.RenderPartial("SubMenu"); %>

    <div class="grid_2 nopadding">
        <% Html.RenderPartial("LeftMenu", Model, new ViewDataDictionary(Model)); %>
    </div>

    <div class="grid_10">
        <div class="section">
            <h1>Edit Employee</h1>
            <p>Edit employee <%: Model.first_name %></p>
            <br />

            <% using (Html.BeginForm()) { %>
                <%: Html.ValidationSummary(true) %>

                <%: Html.HiddenFor(model => model.id) %>

                <table class="details">
                    <tr>
                        <th><%: Html.LabelFor(model => model.first_name) %></th>
                        <td>
                            <%: Html.EditorFor(model => model.first_name) %>
                            <%: Html.ValidationMessageFor(model => model.first_name) %>
                        </td>
                    </tr>
                    <tr>
                        <th><%: Html.LabelFor(model => model.last_name) %></th>
                        <td>
                            <%: Html.EditorFor(model => model.last_name) %>
                            <%: Html.ValidationMessageFor(model => model.last_name) %>
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

