<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="receivePayments.aspx.cs" Inherits="OIPD.receivePayments" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br /><br />
<div class="w3-center">
    <div><asp:Label ID="lblMsg" runat="server"></asp:Label></div>
    <div>
        <asp:Label ID="lblamount" CssClass="w3-xlarge" runat="server"></asp:Label>
        <asp:Label ID="lblDueAmount" CssClass="w3-xlarge fa fa-inr" runat="server"></asp:Label>
    </div>
    <div class="w3-row">
        <div class="w3-col s6 w3-padding">
            <div class="w3-gray w3-center"><asp:Label runat="server" ID="lblEx" CssClass="w3-large w3-text-deep-purple" ><b>Total Expenses</b></asp:Label></div>
            <asp:GridView runat="server" ID="GridView" GridLines="None" CellPadding="4" ForeColor="#000000" CssClass="w3-table-all">
                <AlternatingRowStyle BackColor="White" />
                <EditRowStyle BackColor="#2461BF" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#EFF3FB" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                <SortedDescendingHeaderStyle BackColor="#4870BE" />
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                ConnectionString="<%$ ConnectionStrings:IODatabaseConnectionString %>" 
                SelectCommand="SELECT * FROM hospitals.expenses WHERE ([patientno] = @patientno)">
                <SelectParameters>
                    <asp:QueryStringParameter DefaultValue="" Name="patientno" 
                        QueryStringField="patientno" Type="Int32" />
                </SelectParameters>
            </asp:SqlDataSource>
        </div>
        <div class="w3-col s6 w3-padding">
            <div class="w3-gray w3-center"><asp:Label runat="server" ID="lblPay" CssClass="w3-large w3-text-deep-purple" ><b>Total Payments</b></asp:Label></div>
            <asp:GridView runat="server" ID="GridView1" AutoGenerateColumns="False" DataKeyNames="sno" DataSourceID="SqlDataSource2" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%" ShowFooter="true">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:TemplateField HeaderText="Patient No">
                        <ItemTemplate><%# IOPD.DataManager.RegistrationUtilities.GetRegistrationNo(Convert.ToInt32(Eval("patientno"))) %></ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="comments" HeaderText="Particulars" SortExpression="comments" />
                    <asp:BoundField DataField="amount" HeaderText="Amount" SortExpression="amount" />
                    <asp:TemplateField HeaderText="Date">
                        <ItemTemplate><%# IOPD.DataManager.DateUtilities.dateFormat(Eval("dateofpayment")) %></ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="currentuser" HeaderText="User" SortExpression="currentuser" />
                </Columns>
                <EditRowStyle BackColor="#2461BF" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#EFF3FB" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                <SortedDescendingHeaderStyle BackColor="#4870BE" />
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource2" runat="server"
                ConnectionString="<%$ ConnectionStrings:IODatabaseConnectionString %>" 
                SelectCommand="SELECT * FROM hospitals.payments WHERE ([patientno] = @patientno)">
                <SelectParameters>
                    <asp:QueryStringParameter DefaultValue="1" Name="patientno" QueryStringField="patientno" Type="Int32" />
                </SelectParameters>
            </asp:SqlDataSource>
        </div>
    </div>
    <div id="discData" class="w3-row">
        <div class="w3-col s3">&nbsp;</div>
        <div class="w3-col s6">
            <div class="w3-gray w3-center"><asp:Label runat="server" ID="lblDisc" CssClass="w3-large w3-text-deep-purple" ><b>Total Discounts</b></asp:Label></div>
            <asp:GridView ID="grdDiscounts" runat="server" AutoGenerateColumns="False" CellPadding="4" ShowFooter="true" Width="100%" DataKeyNames="sno" DataSourceID="SqlDataSource3" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" />
                <EmptyDataTemplate>
                    <div class="w3-border w3-border-green w3-card-4 w3-padding w3-text-green w3-center"><b>No Discounts Provided</b></div>
                </EmptyDataTemplate>
                <Columns>
                    <asp:TemplateField HeaderText="Patient No">
                        <ItemTemplate><%# IOPD.DataManager.RegistrationUtilities.GetRegistrationNo(Convert.ToInt32(Eval("patientno"))) %></ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="comment" HeaderText="Particulars" SortExpression="comment" />
                    <asp:BoundField DataField="discountamount" HeaderText="Amount" SortExpression="discountamount" />
                    <asp:TemplateField HeaderText="Date">
                        <ItemTemplate><%# IOPD.DataManager.DateUtilities.onlyDateFormat(Convert.ToDateTime(Eval("date"))) %></ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <EditRowStyle BackColor="#2461BF" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#EFF3FB" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                <SortedDescendingHeaderStyle BackColor="#4870BE" />
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
                ConnectionString="<%$ ConnectionStrings:IODatabaseConnectionString %>" 
                SelectCommand="SELECT * FROM hospitals.discountdata WHERE ([patientno] = @patientno) ORDER BY [sno]">
                <SelectParameters>
                    <asp:QueryStringParameter Name="patientno" QueryStringField="patientno" Type="Int32" />
                </SelectParameters>
            </asp:SqlDataSource>
        </div>
        <div class="w3-col s3">&nbsp;</div>
    </div>
    <br />
    <div class="w3-row">
        <div class="w3-center w3-col s6">
        <div id="showDiscount" class="w3-button w3-round-xlarge w3-teal glossButton" onclick="showHide()">Add Discount</div>
        <br />
        <div id="discDiv" class="" style="display:none">
            <br />
            <div class="w3-row">
                <div class="w3-col s2">&nbsp;</div>
                <div class="w3-border w3-border-green w3-round-xlarge w3-card-4 w3-col s8">
                    <br />
                    <asp:Label ID="lblDiscErr" runat="server"></asp:Label>
                    <div class="w3-row w3-padding-small">
                        <div class="w3-col s2">&nbsp;</div>
                        <asp:Label ID="lblDiscDate" runat="server" CssClass="w3-col s3 w3-large" Text="Date :"></asp:Label>
                        <asp:TextBox ID="txtDiscDate" runat="server" CssClass="w3-col s6 w3-input w3-sand" placeholder="Enter Date"></asp:TextBox>
                        <div class="w3-col s1">&nbsp;</div>
                    </div>
                    <div class="w3-row w3-padding-small">
                        <div class="w3-col s2">&nbsp;</div>
                        <asp:Label ID="lblDiscAmount" runat="server" CssClass="w3-col s3 w3-large" Text="Amount :"></asp:Label>
                        <asp:TextBox ID="txtDiscAmount" runat="server" CssClass="w3-col s6 w3-input w3-sand" placeholder="Enter Amount" TextMode="Number"></asp:TextBox>
                        <div class="w3-col s1">&nbsp;</div>
                    </div>
                    <div class="w3-row w3-padding-small">
                        <div class="w3-col s2">&nbsp;</div>
                        <asp:Label ID="lblDiscComment" runat="server" CssClass="w3-col s3 w3-large" Text="Reason :"></asp:Label>
                        <asp:TextBox ID="txtDiscComment" runat="server" CssClass="w3-col s6 w3-input w3-sand" placeholder="Enter Reason of Discount"></asp:TextBox>
                        <div class="w3-col s1">&nbsp;</div>
                    </div>
                    <br />
                    <asp:Button ID="takeDiscount" runat="server" Text="Apply Discount" OnClick="acceptDiscount" CssClass="w3-purple w3-button w3-round-xxlarge w3-large w3-center" />
                    <br /><br />
                </div>
                <div class="w3-col s2">&nbsp;</div>
            </div>
        </div>
    </div>
    <div class="w3-center w3-col s6">
        <asp:Button ID="bttnShowPay" runat="server" OnClick="showPaymentsOption" Text="Accept Payments" Visible="true" CssClass="w3-purple w3-round-xxlarge w3-xlarge w3-center" />
        <div class="w3-row" id="paymentOptions" visible="false" runat="server">
            <div class="w3-col s3"><br /></div>
            <div class="w3-col s6">
                <asp:Label ID="lblErr" runat="server"></asp:Label><br /><br />
                <asp:Label ID="lbldate" runat="server" CssClass="w3-col s6 w3-large"><b>Date  -: </b></asp:Label>
                <asp:TextBox ID="txtDate" runat="server" CssClass="w3-col s6 w3-input w3-sand" placeholder="Enter date"></asp:TextBox>
                <br /><br />
                <asp:Label ID="lblAmt" runat="server" CssClass="w3-col s6 w3-large"><b>Amount  -: </b></asp:Label>
                <asp:TextBox ID="txtAmount" runat="server" CssClass="w3-col s6 w3-input w3-sand" placeholder="Enter amount received"></asp:TextBox>
                <br /><br />
                <asp:Label ID="lblComents" runat="server" CssClass="w3-col s6 w3-large"><b>Description -: </b></asp:Label>
                <asp:TextBox ID="txtComments" runat="server" CssClass="w3-col s6 w3-input w3-sand" placeholder="Comments please"></asp:TextBox>
                <br /><br />
                <asp:Label ID="lblMode" runat="server" CssClass="w3-col s6 w3-large"><b>Mode of Payment  -: </b></asp:Label>
                <asp:DropDownList ID="drpdwnMode" runat="server" CssClass="w3-col s6 w3-input w3-sand" onselectedindexchanged="drpdwnMode_SelectedIndexChanged" AutoPostBack="true">
                    <asp:ListItem Selected="True" Text="----Select Mode of Payment----" Value="default"></asp:ListItem>
                    <asp:ListItem Text="By Cash" Value="Cash"></asp:ListItem>
                    <asp:ListItem Text="By Cheque" Value="Cheque"></asp:ListItem>
                    <asp:ListItem Text="By Credit Card" Value="Credit Card"></asp:ListItem>
                    <asp:ListItem Text="By Debit Card" Value="Debit Card"></asp:ListItem>
                </asp:DropDownList>
                <br /><br />
                <asp:Label ID="lblModeData" runat="server" Visibl="false" CssClass="w3-col s6 w3-large"></asp:Label>
                <asp:TextBox ID="txtModeData" runat="server" Visible="false" CssClass="w3-col s6 w3-input w3-sand"></asp:TextBox>
                <br /><br />
                <asp:Button ID="bttnAccept" OnClick="checkData" runat="server" Text="Accept" CssClass="w3-purple w3-round-xxlarge w3-xlarge w3-center" />
                <asp:Button ID="bttnCancel" OnClick="reset" runat="server" Text="Cancel" CssClass="w3-purple w3-round-xxlarge w3-xlarge w3-center" />
            </div>
        </div>
        <div class="w3-center">
            <asp:HyperLink ID="bttnPrintBill" Target="_blank" Visible="false" runat="server" CssClass="w3-purple w3-round-xxlarge w3-xlarge w3-center" Text="&nbsp;&nbsp;Print Bill&nbsp;&nbsp;"></asp:HyperLink>
        </div>
        <br /><br />
    </div>
</div>
</div>
<script type="text/javascript">
    $(function () {
        $(function () {
            var currentYear = (new Date).getFullYear();
            var currentMonth = (new Date).getMonth() + 1;
            var currentDay = (new Date).getDate();
            $("#datepicker").datepicker({ minDate: new Date((currentYear - 1), 12, 1), dateFormat: 'dd/mm/yy', maxDate: new Date(currentYear, 11, 31) });

            $("#ContentPlaceHolder1_txtDate").datepicker({

                changeMonth: true,
                changeYear: true,
                yearRange: '1950:currentYear',
                maxDate:'0',
                dateFormat: 'dd-M-yy',
                defaultDate: 'currentdate'
            });
            $("#ContentPlaceHolder1_txtDiscDate").datepicker({

                changeMonth: true,
                changeYear: true,
                yearRange: '1950:currentYear',
                maxDate: '0',
                dateFormat: 'dd-M-yy',
                defaultDate: 'currentdate'
            });
        });

    });
    </script>
    <script type="text/javascript">
        var isVisible = 0;
        function showHide() {
            if (isVisible == 0) {
                document.getElementById("discDiv").style.display = 'block';
                isVisible = 1;
            }
            else {
                document.getElementById("discDiv").style.display = 'none';
                isVisible = 0;
            }
        }
    </script>

</asp:Content>
