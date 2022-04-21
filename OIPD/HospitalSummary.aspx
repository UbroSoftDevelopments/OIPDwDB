<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HospitalSummary.aspx.cs" Inherits="OIPD.HospitalSummary" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <div class="w3-row">
    <div class="w3-col s1">&nbsp;</div>
    <div class="w3-col w3-padding s10">
        <asp:HiddenField ID="dt" runat="server" />
        <asp:HiddenField ID="from" runat="server" />
        <asp:HiddenField ID="to" runat="server" />
        <div class="w3-row">
            <div class="w3-col s1">&nbsp;</div>
            <div class="w3-col s10 w3-padding w3-round-large w3-card-4 w3-center">
                <asp:Label ID="lblErr" runat="server" Text="" CssClass=""></asp:Label>
                <div class="w3-row">
                    <div class="w3-col s3">
                <asp:Label ID="lblSumType" runat="server" Text="Select Summary Type" CssClass="" Font-Bold="true"></asp:Label><br />
                <asp:DropDownList ID="drpDwnSumType" runat="server" AutoPostBack="true" CssClass="w3-padding-small w3-border-0 w3-round-small w3-card" onselectedindexchanged="drpDwnSumType_SelectedIndexChanged">
                    <asp:ListItem Selected="True" Text="Today" Value="0" />
                    <asp:ListItem Text="Other Date" Value="1" />
                    <asp:ListItem Text="Date Range" Value="2" />
                    <asp:ListItem Text="Monthly" Value="3" />
                </asp:DropDownList>
                </div>
                    <div class="w3-col s6">
                <center>
                    <div>
                        <div id="monthFilter" runat="server">
                            <div class="w3-row w3-border w3-border-teal w3-light-blue w3-round">
                                <div class="w3-col s6 w3-center w3-padding">
                                    <asp:Label ID="lblSelMon" runat="server" Text="Select Month"></asp:Label><br />
                                    <asp:DropDownList ID="drpDwnMonth" runat="server" CssClass="w3-padding-small w3-border-0 w3-round-small w3-card">
                                        <asp:ListItem Selected="True" Text="January" Value="1" />
                                        <asp:ListItem Text="Febraury" Value="2" />
                                        <asp:ListItem Text="March" Value="3" />
                                        <asp:ListItem Text="April" Value="4" />
                                        <asp:ListItem Text="May" Value="5" />
                                        <asp:ListItem Text="June" Value="6" />
                                        <asp:ListItem Text="July" Value="7" />
                                        <asp:ListItem Text="August" Value="8" />
                                        <asp:ListItem Text="September" Value="9" />
                                        <asp:ListItem Text="October" Value="10" />
                                        <asp:ListItem Text="November" Value="11" />
                                        <asp:ListItem Text="December" Value="12" />
                                    </asp:DropDownList>
                                </div>
                                <div class="w3-col s6 w3-center w3-padding">
                                    <asp:Label ID="lblSelYear" runat="server" Text="Select Year"></asp:Label><br />
                                    <asp:DropDownList ID="drpDwnYear" runat="server" CssClass="w3-padding-small w3-border-0 w3-round-small w3-card"></asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div id="dateRangeFilter" runat="server">
                            <div class="w3-row w3-border w3-border-teal w3-light-blue w3-round">
                                <div class="w3-col s6 w3-center w3-padding">
                                    <asp:Label ID="lblFrom" runat="server" Text="From"></asp:Label><br />
                                    <asp:TextBox ID="txtFrom" TextMode="Date" runat="server" CssClass="w3-input"></asp:TextBox>
                                </div>
                                <div class="w3-col s6 w3-center w3-padding">
                                    <asp:Label ID="lblTo" runat="server" Text="To"></asp:Label><br />
                                    <asp:TextBox ID="txtTo" TextMode="Date" runat="server" CssClass="w3-input"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div id="dateFilter" runat="server">
                            <asp:Label ID="lblOnDate" runat="server" Text="Select Date"></asp:Label><br />
                            <asp:TextBox ID="txtOnDate" TextMode="Date" runat="server" CssClass="w3-padding-small w3-border-0 w3-card w3-round-small"></asp:TextBox>
                        </div>
                    </div>
                </center>
                </div>
                    <div class="w3-col s3">
                    <asp:Button ID="btnFilter" CssClass="w3-button glossButton w3-round-large w3-card-4 w3-teal" Font-Bold="true" runat="server" Text="Filter Summary" onclick="btnFilter_Click" />
                </div>
                </div>
            </div>
            <div class="w3-col s1">&nbsp;</div>
        </div>
        <div class="w3-padding w3-center">
            <asp:Label ID="ttlEarning" runat="server" CssClass="w3-xlarge w3-text-blue" Font-Bold="true"></asp:Label>
        </div>
        <div class="w3-card-4 w3-round-large w3-padding">
            <asp:GridView ID="grdHospSummary" CssClass="w3-table-all" runat="server" OnRowDataBound="onRowBound" 
                AutoGenerateColumns="False" DataKeyNames="sno" OnDataBound="setTotal">
                <EmptyDataTemplate>
                    <div class="w3-padding w3-pale-blue w3-round-large w3-card-4 w3-border w3-border-blue w3-text-blue w3-large">
                        <b>Sorry No Records Found !!!</b>
                    </div>
                </EmptyDataTemplate>
                <Columns>
                    <asp:TemplateField ItemStyle-Width="13%" HeaderText="Date"><ItemTemplate><%# IOPD.DataManager.DateUtilities.onlyDateFormat(Eval("dateofpayment"))%></ItemTemplate></asp:TemplateField>
                    <asp:TemplateField ItemStyle-Width="18%" HeaderText="IP Number"><ItemTemplate><%# IOPD.DataManager.Patient.getPatientIPNumber(Convert.ToInt32(Eval("patientno")))%></ItemTemplate></asp:TemplateField>
                    <asp:TemplateField ItemStyle-Width="20%" HeaderText="Patient Name"><ItemTemplate><%# IOPD.DataManager.PatientUtilities.getpatientname(Convert.ToInt32(Eval("patientno")))%></ItemTemplate></asp:TemplateField>
                    <asp:BoundField ItemStyle-Width="9%" DataField="amount" HeaderText="Amount" SortExpression="amount" />
                    <asp:BoundField ItemStyle-Width="20%" DataField="comments" HeaderText="Comments" SortExpression="comments" />
                    <asp:BoundField ItemStyle-Width="10%" DataField="paymentmode" HeaderText="Pay Mode" SortExpression="paymentmode" />
                    <asp:BoundField ItemStyle-Width="10%" DataField="currentuser" HeaderText="User" SortExpression="currentuser" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                ConnectionString="<%$ ConnectionStrings:IODatabaseConnectionString %>" 
                SelectCommand="SELECT * FROM hospitals.payments WHERE (dateofpayment = @dateofpayment) ORDER BY dateofpayment">
                <SelectParameters>
                    <asp:ControlParameter ControlID="dt" Name="dateofpayment" PropertyName="Value" Type="DateTime" />
                </SelectParameters>
            </asp:SqlDataSource>
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                ConnectionString="<%$ ConnectionStrings:IODatabaseConnectionString %>" 
                SelectCommand="SELECT * FROM hospitals.payments WHERE (dateofpayment >= @fromdate) AND (dateofpayment <= @todate) ORDER BY dateofpayment">
                <SelectParameters>
                    <asp:ControlParameter ControlID="from" Name="fromdate" PropertyName="Value" Type="DateTime" />
                    <asp:ControlParameter ControlID="to" Name="todate" PropertyName="Value" Type="DateTime" />
                </SelectParameters>
            </asp:SqlDataSource>
        </div>
    </div>
    <div class="w3-col s1">&nbsp;</div>
</div>

</asp:Content>
