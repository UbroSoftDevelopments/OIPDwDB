<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RefferalHospitals.aspx.cs" Inherits="OIPD.RefferalHospitals" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
<div class="w3-row">

<div class="w3-col s2" ><br /></div>
<div class="w3-col s8 w3-card-4 w3-border w3-border-amber w3-padding w3-center">

<asp:Label ID="lblUserDetails" runat="server" Width="100%" CssClass="w3-xxlarge w3-purple w3-text-aqua"><b>Hospital Details</b></asp:Label><br />
<asp:Label ID="lblErrors" runat="server" Text="" /><br />
<div>
<asp:Label ID="lblHospName" runat="server" CssClass="w3-col s5 w3-left w3-input w3-border-0"><b>Hospital Name -: </b></asp:Label>
<p class="w3-col s1"></p>
<asp:TextBox ID="txtHospName" runat="server" CssClass="w3-input w3-sand w3-card w3-col s6" placeholder="Enter Hospital Name" /><br /><br />
<asp:Label ID="lblHospAdd" runat="server" CssClass="w3-col s5 w3-left w3-input w3-border-0"><b>Hospital Address -: </b></asp:Label>
<p class="w3-col s1"></p>
<asp:TextBox ID="txtHospAddress" runat="server" CssClass="w3-input w3-sand w3-card w3-col s6" placeholder="Enter Hospital Address" /><br /><br />
<asp:Label ID="lblHospContactNo" runat="server" CssClass="w3-col s5 w3-left w3-input w3-border-0"><b>Contact Number -: </b></asp:Label>
<p class="w3-col s1"></p>
<asp:TextBox ID="txtHospContactNo" runat="server" CssClass="w3-input w3-sand w3-card w3-col s6" placeholder="Enter Hospital Contact Number"/>
<br /><br />

<asp:Label ID="lblHospMail" runat="server" CssClass="w3-col s5 w3-left w3-input w3-border-0"><b>E-Mail ID -: </b></asp:Label>
<p class="w3-col s1"></p>
<asp:TextBox ID="txtHospMail" runat="server" CssClass="w3-input w3-sand w3-card w3-col s6" placeholder="Enter Hospital E-Mail ID"/>
<br /><br />

<asp:Label ID="lblJHospShare" runat="server" CssClass="w3-col s5 w3-left w3-input w3-border-0"><b>Share (%) -: </b></asp:Label>
<p class="w3-col s1"></p>
<asp:TextBox ID="txtHospShare" runat="server" CssClass="w3-input w3-sand w3-card w3-col s6" placeholder="Enter Hospital Share"/>

</div>
<br /><br /><br />
<asp:Button ID="btnregister" CssClass=" w3-round-xxlarge w3-btn w3-purple"  runat="server" Text="Add Hospital" OnClick="addHospital" />
<br /><br />
<div class="w3-container">

<asp:GridView runat="server" ID="GridView1" AutoGenerateColumns="False" 
        DataKeyNames="sno" DataSourceID="SqlDataSource1" Width="100%" 
        BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" 
        CellPadding="2" GridLines="Horizontal">
    <AlternatingRowStyle BackColor="#F7F7F7" />
    <Columns>
        <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
        <asp:BoundField DataField="hospitalname" HeaderText="Hospital Name" 
            SortExpression="hospitalname" />
        <asp:BoundField DataField="hospitaladdress" HeaderText="Address" 
            SortExpression="hospitaladdress" />
        <asp:BoundField DataField="contactno" HeaderText="Contact No" 
            SortExpression="contactno" />
        <asp:BoundField DataField="hospitalmail" HeaderText="E-Mail ID" 
            SortExpression="hospitalmail" />
        <asp:BoundField DataField="commisionrate" HeaderText="Share" 
            SortExpression="commisionrate" />
    </Columns>
    <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
    <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
    <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
    <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
    <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
    <SortedAscendingCellStyle BackColor="#F4F4FD" />
    <SortedAscendingHeaderStyle BackColor="#5A4C9D" />
    <SortedDescendingCellStyle BackColor="#D8D8F0" />
    <SortedDescendingHeaderStyle BackColor="#3E3277" />
    </asp:GridView>

    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:IODatabaseConnectionString %>" 
        DeleteCommand="DELETE FROM hospitals.refferHospitals WHERE [sno] = @sno" 
        SelectCommand="SELECT * FROM hospitals.refferHospitals WHERE ([sno] &gt; '1')" 
        UpdateCommand="UPDATE hospitals.refferHospitals SET [hospitalname] = @hospitalname, [hospitaladdress] = @hospitaladdress, [contactno] = @contactno, [hospitalmail] = @hospitalmail, [commisionrate] = @commisionrate WHERE [sno] = @sno">
        <DeleteParameters>
            <asp:Parameter Name="sno" Type="Int32" />
        </DeleteParameters>
        <SelectParameters>
            <asp:Parameter DefaultValue="1" Name="sno" Type="Int32" />
        </SelectParameters>
        <UpdateParameters>
            <asp:Parameter Name="hospitalname" Type="String" />
            <asp:Parameter Name="hospitaladdress" Type="String" />
            <asp:Parameter Name="contactno" Type="String" />
            <asp:Parameter Name="hospitalmail" Type="String" />
            <asp:Parameter Name="commisionrate" Type="Int32" />
            <asp:Parameter Name="sno" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>

</div>

</div>

</div>
<br />
</asp:Content>
