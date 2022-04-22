<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="departmentlist.aspx.cs" Inherits="OIPD.departmentlist" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br /><br />
<div class="w3-row">
<div class="w3-col s2"><br /></div>
<div   class="w3-col s8 w3-center  w3-centered w3-light-blue w3-card-4">


<center>
<h2 class="w3-text-deep-purple">Department List</h2>
</center>
</div>
</div>
<div class="w3-row w3-mobile">
<div class="w3-col s2"><br /></div>
<div  class=" w3-col w3-card-4 w3-padding w3-pale-green s8 w3-mobile w3-centered ">
    <asp:GridView style="width:100%" ID="GridView1" runat="server" 
           AutoGenerateColumns="False" BackColor="White" BorderColor="#E7E7FF" 
           BorderStyle="None" BorderWidth="1px" CellPadding="3" 
           DataKeyNames="departmentno" DataSourceID="SqlDataSource1" 
           GridLines="Horizontal">
        <AlternatingRowStyle BackColor="#F7F7F7" />
        <Columns>
           
            <asp:BoundField DataField="departmentno" HeaderText="departmentno" 
                SortExpression="departmentno" InsertVisible="False" ReadOnly="True" />
            
                 <asp:BoundField DataField="departname" HeaderText="departname" SortExpression="departname" />
            <asp:BoundField DataField="description" HeaderText="description" SortExpression="description" />
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
           SelectCommand="SELECT departmentno, departname, description FROM hospitals.departments WHERE (departmentno > 1) ORDER BY departmentno">
       </asp:SqlDataSource>
    </div>
    </div>
    <br /><br /><br /><br /><br /><br />

</asp:Content>
