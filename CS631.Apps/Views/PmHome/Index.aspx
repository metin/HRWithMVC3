<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Pm.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>


<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    <% Html.RenderPartial("SubMenu"); %>

    <div class="grid_12">
        <div class="section">

            <h1>Project Management Dashboard</h1>
            <p>Select an action to see deatils</p>

            <table class="details">
                <tr>
                    <th style="width:180px;">Number Of Projects:</th>
                    <td>
                        <%: Html.ActionLink(CS631.Data.Project.FindAll().Count.ToString(), "Index", "Projects")%>
                        &nbsp;&nbsp;|&nbsp;
                        <%: Html.ActionLink("New Project", "Create", "Projects")%>
                    </td>

                </tr>
                <tr>
                    <th>Defined Milestones</th>
                    <td>
                        <%: Html.ActionLink(CS631.Data.Milestone.FindAll().Count.ToString(), "Index", "Milestones")%>
                        &nbsp;&nbsp;|&nbsp;
                        <%: Html.ActionLink("Define a milestone", "Create", "Milestones")%>
                    </td>

                </tr>

                
            </table>
        </div>
    </div>
    
    <div class="clear"></div> 

</asp:Content>
