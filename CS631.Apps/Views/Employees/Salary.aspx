<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<CS631.Data.Employee>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Salary
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        $(function () {
            $("#SalaryStartDate").datepicker({ showOn: 'both', buttonImage: "/Public/Images/calendar.gif", buttonImageOnly: true });
        });
	</script>

    <% Html.RenderPartial("SubMenu"); %>

    <div class="grid_2 nopadding">
        <% Html.RenderPartial("LeftMenu", Model, new ViewDataDictionary(Model)); %>
    </div>

    <div class="grid_10">
        <div class="section">
            <h1>Employe salary</h1>
            <p>Update employee salay, see salary history</p>
            <br />

            <% using (Html.BeginForm("Salary", "Employees", FormMethod.Post)) { %>
                <%: Html.ValidationSummary(true) %>

                <%: Html.HiddenFor(model => model.EmpID)%>
                <table class="details">
                    <tr>
                        <th><%: Html.Label("Salary", "Salary") %></th>
                        <td>
                            <%: Html.Editor("AnnualSalary") %>
                        </td>
                    </tr>

                    <tr>
                        <th><%: Html.Label("Salary", "Salary Date")%></th>
                        <td>
                            <%: Html.Editor("SalaryStartDate")%>
                        </td>
                    </tr>
                </table>

                <div class="clear"></div> 
                <div>
                    <input type="submit" value="Save" class="action_button"/>
                </div>
                <div class="clear"></div> 


            <% } %>
            <br />
            <br />

            <h1>History</h1>
            <p>Previous salaries </p>
            <table width="100%">
                <thead>
                    <tr>
                        <th> Date </th>
                        <th> Annual Salary </th>
                    </tr>
                </thead>
                <tbody>
                    <% bool isFirst = true; %>
                    <% foreach (var d in Model.SalaryHistory())
                        { %>
                        <tr style="background-color:<%: isFirst ? "#fcc" : "" %>">
                            <td><%: d.SalaryStartDate.ToString("MM/dd/yyyy")%> </td>
                            <td><%: d.AnnualSalary %> </td>
                        </tr>
                        <% isFirst = false; %>
                    <% } %>
                </tbody>
            </table>
        </div>
    </div>
    <div class="clear"></div> 

</asp:Content>
