<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<CS631.Data.Employee>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Create
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <% Html.RenderPartial("SubMenu"); %>

    <div class="grid_12">
        <div class="section"> 
            <h1>New Employee</h1>
            <p>Add new employee</p>
            <br />

             <% using (Html.BeginForm()) { %>
                <%: Html.ValidationSummary(true) %>


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
                    <input type="submit" value="Create" class="action_button"/>
                </div>
                <div class="clear"></div>
            <% } %>
        </div>
    </div>
    <div class="clear"></div> 

</asp:Content>

