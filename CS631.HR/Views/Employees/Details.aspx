<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<CS631.Data.Employee>" %>

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

            <h1>Show Employee</h1>
            <p>Details of employee</p>
            
            <table class="details">
                <tr>
                    <th><label>Employee NO:</label></th>
                    <td><%: Model.EmployeeNO %></td>
                </tr>
                <tr>
                    <th><label>Fist Name</label>:</th>
                    <td><%: Model.first_name %></td>
                </tr>
                <tr>
                    <th><label> Last Name </label>:</th>
                    <td><%: Model.last_name %></td>
                </tr>
            </table>
        </div>
    </div>
    <div class="clear"></div> 
</asp:Content>
