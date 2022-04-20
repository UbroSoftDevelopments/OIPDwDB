<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateCharges.aspx.cs" Inherits="OIPD.CreateCharges" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
<div class="w3-row">
<div class="w3-col s3"><br /></div>
<div class="w3-col s6 w3-center w3-padding w3-pale-yellow w3-border w3-border-cyan w3-round">
<div class="w3-teal w3-padding"><asp:Label ID="heading" runat="server" CssClass="w3-xlarge w3-text-white"><b><u>Add Charges</u></b></asp:Label></div>
<br />
<div class="w3-row">
<asp:Label ID="lblErr" runat="server"></asp:Label><br /><br />
<asp:Label ID="lblChargeName" runat="server" CssClass="w3-left w3-col s6"><b> Charge Name :- </b></asp:Label>
<asp:TextBox ID="txtchargeName" runat="server" CssClass="w3-input w3-col s6 w3-sand" placeholder="Enter Charge Name"></asp:TextBox><br /><br />
<asp:Label ID="lblapplied" runat="server" CssClass="w3-left w3-col s6"><b> Applied For :- </b></asp:Label>
<asp:DropDownList ID="txtappliedfor" runat="server" CssClass="w3-input w3-col s6 w3-sand" placeholder="Enter Ward Name"></asp:DropDownList><br /><br />
<asp:Label ID="lblamt" runat="server" CssClass="w3-left w3-col s6"><b> Amount :- </b></asp:Label>
<asp:TextBox ID="txtamount" runat="server" CssClass="w3-input w3-col s6 w3-sand" placeholder="Enter Charge Amount"></asp:TextBox><br /><br /><br />
<b><asp:Button ID="bttnSubmit" runat="server" OnClick="addChargesToTable" Text="Add Charge" cssclass="w3-teal w3-round-xlarge w3-text-white w3-padding"/></b>
</div>
<br /><br />
<div class="w3-center w3-row">
<div class="w3-col s1"><br /></div>
    <div class="w3-center w3-col s10">

    <asp:GridView ID="charges" runat="server" AutoGenerateColumns="False" 
            DataKeyNames="sno" DataSourceID="SqlDataSource1" CellPadding="4" 
            ForeColor="#333333" GridLines="None" Width="100%">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
            <asp:BoundField DataField="chargeName" HeaderText="Charge Name" 
                SortExpression="chargeName" />
            <asp:BoundField DataField="applied" HeaderText="Applied On" 
                SortExpression="applied" />
            <asp:BoundField DataField="amount" HeaderText="Amount" 
                SortExpression="amount" />
        </Columns>
        <EditRowStyle BackColor="#7C6F57" />
        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#E3EAEB" />
        <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F8FAFA" />
        <SortedAscendingHeaderStyle BackColor="#246B61" />
        <SortedDescendingCellStyle BackColor="#D4DFE1" />
        <SortedDescendingHeaderStyle BackColor="#15524A" />
    </asp:GridView>

        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConflictDetection="CompareAllValues" 
            ConnectionString="<%$ ConnectionStrings:IODatabaseConnectionString %>" 
            DeleteCommand="DELETE FROM hospitals.charges WHERE [sno] = @original_sno AND [chargeName] = @original_chargeName AND [applied] = @original_applied AND [amount] = @original_amount" 
            InsertCommand="INSERT INTO hospitals.charges ([chargeName], [applied], [amount]) VALUES (@chargeName, @applied, @amount)" 
            OldValuesParameterFormatString="original_{0}" 
            SelectCommand="SELECT * FROM hospitals.charges ORDER BY [applied]" 
            UpdateCommand="UPDATE hospitals.charges SET [chargeName] = @chargeName, [applied] = @applied, [amount] = @amount WHERE [sno] = @original_sno AND [chargeName] = @original_chargeName AND [applied] = @original_applied AND [amount] = @original_amount">
            <DeleteParameters>
                <asp:Parameter Name="original_sno" Type="Int32" />
                <asp:Parameter Name="original_chargeName" Type="String" />
                <asp:Parameter Name="original_applied" Type="String" />
                <asp:Parameter Name="original_amount" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="chargeName" />
                <asp:Parameter Name="applied" />
                <asp:Parameter Name="amount" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="chargeName" Type="String" />
                <asp:Parameter Name="applied" Type="String" />
                <asp:Parameter Name="amount" Type="Int32" />
                <asp:Parameter Name="original_sno" Type="Int32" />
                <asp:Parameter Name="original_chargeName" Type="String" />
                <asp:Parameter Name="original_applied" Type="String" />
                <asp:Parameter Name="original_amount" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>

    </div>
</div>
</div>
</div>
<br />
</asp:Content>
