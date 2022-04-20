<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WardMaster.aspx.cs" Inherits="OIPD.WardMaster" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br /><br />
<div class="w3-row">
<div class="w3-col s3"><br /></div>
<div   class="w3-col s6 w3-center w3-padding w3-card-4 w3-centered w3-border">
<center>
<h2 class="w3-light-blue">Enter Ward</h2>
  <asp:Label ID="message" runat="server" Text=""></asp:Label><br />
    <asp:Label ID="lblwardname" CssClass="w3-large w3-text-blue" runat="server" Text="Ward Name"></asp:Label>
    <asp:TextBox CssClass="w3-input w3-border w3-sand w3-round" ID="txtwardname" runat="server"></asp:TextBox>
     <asp:Label ID="lblspeciality" CssClass="w3-large w3-text-blue"  runat="server" Text="Speciality"></asp:Label>
    <asp:TextBox CssClass="w3-input w3-sand w3-round w3-border" TextMode="MultiLine" ID="txtspeciality" runat="server"></asp:TextBox><br />
    </center>
     <asp:Button ID="buttonsubmit" 
            class=" w3-round-xxlarge w3-large w3-btn w3-purple" runat="server" 
        Text="Submit" onclick="buttonsubmit_Click" />
        <asp:Button ID="buttonreset" 
            class=" w3-round-xxlarge w3-large w3-btn w3-purple" runat="server" 
        Text="Reset  " onclick="buttonreset_Click" />


</div>
</div>
<br />
<div class="w3-row w3-mobile">
<div class="w3-col s2"><br /></div>
<div  class=" w3-col s8 w3-mobile w3-centered">
 <asp:GridView style="width:100%" ID="GridView1" runat="server" BackColor="White" 
        BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" 
        DataSourceID="SqlDataSource1" GridLines="Horizontal" 
        AutoGenerateColumns="False" DataKeyNames="wardno">
        <AlternatingRowStyle BackColor="#F7F7F7" />
        <Columns>
            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
           
        
            <asp:BoundField DataField="wardname" HeaderText="wardname" 
                SortExpression="wardname" />
            <asp:BoundField DataField="speciality" HeaderText="speciality" 
                SortExpression="speciality" />
                  <asp:TemplateField HeaderText="Action">
          <ItemTemplate><a title='Select<%# Eval("wardname") %>'href='roommaster.aspx?wardno=<%# Eval("wardno") %>'>Select<%# Eval("  wardname") %></a></ItemTemplate>
          </asp:TemplateField>
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
   </div>
   </div>
  
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:IODatabaseConnectionString %>" 
        SelectCommand="SELECT * FROM hospitals.wardmaster ORDER BY [wardno]"
         UpdateCommand="update hospitals.wardmaster set wardname=@wardname,speciality=@speciality where wardno=@wardno"
         DeleteCommand="delete from hospitals.wardmaster where wardno=@wardno">
    </asp:SqlDataSource>
   
<br /><br />
</asp:Content>
