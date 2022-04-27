<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Treatment.aspx.cs" Inherits="OIPD.Treatment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
<br />
<div class="w3-row">
<div class="w3-col s3"><br /></div>
<div class="w3-col s6 w3-card-4 w3-border w3-border-teal w3-padding w3-pale-yellow">
    <div class="w3-amber w3-xxlarge w3-center">
    <asp:Label ID="heading" runat="server" CssClass="w3-text-blue"><b>Add Treatement</b></asp:Label>
    </div>
    <br />
    <asp:Label ID="lblmsg" runat="server" ></asp:Label>
    <br />
    <div>
    <div class="w3-col s2"><br /></div>
    <asp:Label ID="lbldate" runat="server" CssClass="w3-col s3"><b>Date : </b></asp:Label>
    <asp:TextBox CssClass="w3-input w3-sand w3-col s6" ID="txtdate" runat="server" placeholder="Date of Treatement" /><br /><br />
    <div class="w3-col s2"><br /></div>
    <asp:Label ID="lblname" runat="server" CssClass="w3-col s3"><b>Name : </b></asp:Label>
    <asp:TextBox ID="txtname" runat="server" CssClass="w3-col s6 w3-sand w3-input" placeholder="Enter Treatment Name"></asp:TextBox><br /><br />
    <div class="w3-col s2"><br /></div>
    <asp:Label ID="lbldetails" runat="server" CssClass="w3-col s3"><b>Details : </b></asp:Label>
    <asp:TextBox ID="txtdetails" runat="server" CssClass="w3-col s6 w3-sand w3-input" TextMode="MultiLine" placeholder="Enter Treatment Details"></asp:TextBox><br /><br />
    </div><br /><br />
    <center><b><asp:Button ID="bttnadd" class="w3-center w3-large w3-card-2 w3-round-xlarge w3-btn w3-teal" runat="server" OnClick="addTreatment" Text="Add Treatment"/></b></center>
    <br />
    <div class="w3-center">
    
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            DataKeyNames="sno" DataSourceID="SqlDataSource1" CssClass="w3-table-all" 
            CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:TemplateField HeaderText="Patient No">
                <ItemTemplate>
                <%# IOPD.DataManager.RegistrationUtilities.GetRegistrationNo(Convert.ToInt32(Eval("patientno"))) %>
                </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Date of Entry">
                <ItemTemplate>
                <%# IOPD.DataManager.DateUtilities.dateFormat(Eval("dateOfEntry"))%>
                </ItemTemplate>
                </asp:TemplateField>

                <asp:BoundField DataField="nameOfTreatement" HeaderText="Treatement" 
                    SortExpression="nameOfTreatement" />
                <asp:BoundField DataField="details" HeaderText="Details" 
                    SortExpression="details" />
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
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:IODatabaseConnectionString %>" 
            
            SelectCommand="SELECT * FROM hospitals.treatement WHERE ([patientno] = @patientno) ORDER BY [dateOfEntry] DESC, [nameOfTreatement]">
            <SelectParameters>
                <asp:QueryStringParameter Name="patientno" QueryStringField="patientno" 
                    Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>
    
    </div>
</div>
<br />
</div>
<br />
<br />
<script type="text/javascript">
    $(function () {
        $(function () {
            var currentYear = (new Date).getFullYear();
            var currentMonth = (new Date).getMonth() + 1;
            var currentDay = (new Date).getDate();
            $("#datepicker").datepicker({ minDate: new Date((currentYear - 1), 12, 1), dateFormat: 'dd/mm/yy', maxDate: new Date(currentYear, 11, 31) });

            $("#ContentPlaceHolder1_txtdate").datepicker({

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
</asp:Content>
