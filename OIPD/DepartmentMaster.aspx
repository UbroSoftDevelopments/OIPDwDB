<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DepartmentMaster.aspx.cs" Inherits="OIPD.DepartmentMaster" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br /><br />
<div class="w3-row">
<div class="w3-col s3"><br /></div>
<div   class="w3-col s6 w3-center w3-padding w3-card-4 w3-centered w3-border">

<center>
<h2 class="w3-light-blue">Enter Department</h2>
  <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label><br />
    <asp:Label ID="lbldepartname" CssClass="w3-large w3-text-blue" runat="server" Text="Department Name"></asp:Label>
    <asp:TextBox CssClass="w3-input w3-border w3-sand w3-round" ID="txtdepartname" runat="server"></asp:TextBox>
     <asp:Label ID="lbldescription" CssClass="w3-large w3-text-blue"  runat="server" Text="Description"></asp:Label>
    <asp:TextBox CssClass="w3-input w3-sand w3-round w3-border" TextMode="MultiLine" ID="txtdescription" runat="server"></asp:TextBox><br />
    </center>
     <asp:Button ID="buttonsubmit" style="width:35%;margin-left:15%" 
            class=" w3-round-xxlarge w3-btn w3-purple" runat="server" 
        Text="Submit" onclick="buttonsubmit_Click" />
        <asp:Button ID="buttonreset" style="width:35%" 
            class=" w3-round-xxlarge w3-btn w3-purple" runat="server" 
        Text="Reset" onclick="buttonreset_Click"  />


</div>
</div>
<br /><br />
<div class="w3-row w3-mobile">
<div class="w3-col s2"><br /></div>
<div  class=" w3-col s8 w3-mobile w3-centered">

    <asp:GridView style="width:100%" ID="GridView1" runat="server" AutoGenerateColumns="False" 
        BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" 
        CellPadding="3" DataKeyNames="departmentno" DataSourceID="SqlDataSource1" 
        GridLines="Horizontal" onrowupdated="GridView1_RowUpdated" 
        onrowdeleted="GridView1_RowDeleted">
        <AlternatingRowStyle BackColor="#F7F7F7" />
        <Columns>
            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
           
            <asp:BoundField DataField="departname" HeaderText="Departname" 
                SortExpression="departname" />
            <asp:BoundField DataField="description" HeaderText="Description" 
                SortExpression="description" />
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
    <br /><br />
    </div>
    </div>
    
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:IODatabaseConnectionString %>" 
        SelectCommand="SELECT * FROM hospitals.departments where departmentno>1 ORDER BY [departmentno]"
         UpdateCommand="update hospitals.departments set departname=@departname,description=@description where departmentno=@departmentno"
         DeleteCommand="delete from hospitals.departments where departmentno=@departmentno">
    </asp:SqlDataSource>
<br />
</asp:Content>
