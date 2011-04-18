<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<CS631.Data.Department>" %>

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
            <h1>Show Department</h1>
            <p>Details of department</p>
            <br />
            <div>
                <label>Department Name</label>
                 : <%: Model.name %>
            </div>
            <div class="clear"></div> 

        </div>
                
    </div>
    
    <div class="clear"></div> 

</asp:Content>

