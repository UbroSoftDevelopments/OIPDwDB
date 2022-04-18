<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateUser.aspx.cs" Inherits="OIPD.CreateUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
<div class="w3-row">

<div class="w3-col s3" ><br /></div>
<div class="w3-col s6 w3-card-4 w3-border w3-border-amber w3-padding w3-center">

<asp:Label ID="lblUserDetails" runat="server" Width="100%" CssClass="w3-xxlarge w3-purple w3-text-aqua"><b>New User Details</b></asp:Label><br />
<asp:Label ID="lblErrors" runat="server" Text="" /><br />
<div>
<asp:Label ID="lblUserName" runat="server" CssClass="w3-col s5 w3-left w3-input w3-border-0"><b>User Name -: </b></asp:Label>
<p class="w3-col s1"></p>
<asp:TextBox ID="txtUserName" runat="server" CssClass="w3-input w3-sand w3-card w3-col s6" placeholder="Enter User Name" /><br /><br />
<asp:Label ID="lblUserType" runat="server" CssClass="w3-col s5 w3-left w3-input w3-border-0"><b>User Type -: </b></asp:Label>
<p class="w3-col s1"></p>
<asp:DropDownList ID="drpdwnUserType" runat="server" CssClass="w3-input w3-sand w3-card w3-col s6" >

</asp:DropDownList>
<br /><br />
<asp:Label ID="lblUserPassword" runat="server" CssClass="w3-col s5 w3-left w3-input w3-border-0"><b>User Password -: </b></asp:Label>
<p class="w3-col s1"></p>
<asp:TextBox TextMode="password" ID="txtPassword" runat="server" CssClass="w3-input w3-sand w3-card w3-col s6" placeholder="Enter User Password"/>

<br /><br />
<asp:Label ID="lblRetypePassword" runat="server" CssClass="w3-col s5 w3-left w3-input w3-border-0"><b>Re-enter Password -: </b></asp:Label>
<p class="w3-col s1"></p>
<asp:TextBox ID="txtRetypePassword" runat="server" TextMode="Password" CssClass="w3-input w3-sand w3-card w3-col s6" placeholder="Re-type above password" />
</div>
<br /><br /><br />
<asp:Button ID="btnregister" CssClass=" w3-round-xxlarge w3-btn w3-purple"  runat="server" Text="Add User" OnClick="addUser" />
<br /><br />
<div class="w3-center">

<asp:GridView ID="GridView1" runat="server" CssClass="w3-table-all" 
        AutoGenerateColumns="False" CellPadding="4" DataKeyNames="userno" 
        DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None">
    <AlternatingRowStyle BackColor="White" />
    <Columns>
        <asp:BoundField DataField="userno" HeaderText="userno" 
            SortExpression="userno" InsertVisible="False" ReadOnly="True" />
        <asp:BoundField DataField="username" HeaderText="username" 
            SortExpression="username" />
        <asp:BoundField DataField="password" HeaderText="password" SortExpression="password" />
        <asp:BoundField DataField="status" HeaderText="status" SortExpression="status" />
        <asp:BoundField DataField="usertype" HeaderText="usertype" SortExpression="usertype" />
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
        SelectCommand="SELECT userno, username, password, status, usertype FROM hospitals.siteusers WHERE (username &lt;&gt; @username) AND (username &lt;&gt; 'admin')">
        <SelectParameters>
            <asp:SessionParameter DefaultValue=" " Name="username" SessionField="username" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>

</div>
</div>
</div>
<br />
</asp:Content>
