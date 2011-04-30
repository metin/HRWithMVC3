<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<CS631.Data.Employee>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Payroll
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <script type="text/javascript">
        $(function () {
            $("#PayDate").datepicker({ showOn: 'both', buttonImage: "/Public/Images/calendar.gif", buttonImageOnly: true });
            $("#PayDate").val("");
        });
	</script>

    <% Html.RenderPartial("SubMenu"); %>

    <div class="grid_2 nopadding">
        <% Html.RenderPartial("LeftMenu", Model, new ViewDataDictionary(Model)); %>
    </div>

    <div class="grid_10">
        <div class="section">
            <h1>Employe payroll</h1>
            <p>Make a payment to employee, show payroll  history</p>

            <% Html.RenderPartial("NewPayroll", new CS631.Data.Payroll() ); %>
<!--
            <% using (Html.BeginForm("Payroll", "Employees", FormMethod.Post)) { %>
                <%: Html.ValidationSummary(true) %>

                <%: Html.HiddenFor(model => model.EmpID)%>
                <table class="details">
                    <tr>
                        <th><%: Html.Label("Payroll", "Pay Date") %></th>
                        <td>
                            <%: Html.Editor("PayDate")%>
                        </td>
                    </tr>

                    <tr>
                        <th><%: Html.Label("Payroll", "Payment")%></th>
                        <td>
                            <%: Html.Editor("MonthSalary")%>
                        </td>
                    </tr>

                    <tr>
                        <th><%: Html.Label("Payroll", "Hours Worked")%></th>
                        <td>
                            <%: Html.Editor("MonthHours")%>
                        </td>
                    </tr>
                    <tr>
                        <th><%: Html.Label("Payroll", "FedTax")%></th>
                        <td>
                            <%: Html.Editor("FedTax")%>
                        </td>
                    </tr>
                    <tr>
                        <th><%: Html.Label("Payroll", "StateTax")%></th>
                        <td>
                            <%: Html.Editor("StateTax")%>
                        </td>
                    </tr>
                    <tr>
                        <th><%: Html.Label("Payroll", "OtherTax")%></th>
                        <td>
                            <%: Html.Editor("OtherTax")%>
                        </td>
                    </tr>
                    <tr>
                        <th><%: Html.Label("Payroll", "Net Payment")%></th>
                        <td>
                            <%: Html.Editor("NetPay")%>
                        </td>
                    </tr>
                </table>

                <div class="clear"></div> 
                <div>
                    <input type="submit" value="Save" class="action_button"/>
                </div>
                <div class="clear"></div> 


            <% } %>
-->
            <br />
            <br />

            <h1>History</h1>
            <p>Previous salaries </p>
            <table width="100%">
                <thead>
                    <tr>
                        <th> Date </th>
                        <th> Payment </th>
                        <th> Fed Tax </th>
                        <th> State Tax </th>
                        <th> Net Pay </th>
                    </tr>
                </thead>
                <tbody>
                    <% foreach (var d in Model.PayrollHistory())
                        { %>
                        <tr>
                            <td><%: d.PayDate.ToString("MM/dd/yyyy")%> </td>
                            <td><%: String.Format("${0:F}", d.MonthSalary) %> </td>
                            <td><%: String.Format("${0:F}", d.FedTax)%> </td>
                            <td><%: String.Format("${0:F}", d.StateTax)%> </td>
                            <td><%: String.Format("${0:F}", d.NetPay)%> </td>
                        </tr>
                    <% } %>
                </tbody>
            </table>
        </div>
    </div>
    <div class="clear"></div> 


</asp:Content>
