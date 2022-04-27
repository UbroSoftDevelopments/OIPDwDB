<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="bedmaster.aspx.cs" Inherits="OIPD.bedmaster" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br /><br />
<div class="w3-row">
<div class="w3-col s3"><br /></div>
<div   class="w3-col s6 w3-center w3-padding w3-card-4 w3-centered w3-border">
<center>
<div class="w3-centered w3-round w3-deep-purple">
    <asp:Label CssClass="w3-text-light-blue w3-large" ID="lblroomname" runat="server" Text=""></asp:Label>
</div>
  <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label><br />
    <asp:Label ID="lblbedno" CssClass="w3-large w3-text-blue" runat="server" Text=" Enter Bed No."></asp:Label>
    <asp:TextBox CssClass="w3-input w3-border w3-sand w3-round" ID="txtbedno" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="lblChrg" CssClass="w3-large w3-text-blue" runat="server" Text=" Enter Bed Charge"></asp:Label>
    <asp:TextBox CssClass="w3-input w3-border w3-sand w3-round" ID="txtBedCharge" runat="server"></asp:TextBox>
    
    </center>
     <br />
     <asp:Button ID="buttonsubmit" 
            class=" w3-round-xxlarge w3-large w3-btn w3-purple" runat="server" 
        Text="Submit" onclick="buttonsubmit_Click" />
        <asp:Button ID="buttonreset"  
            class=" w3-round-xxlarge w3-large w3-btn w3-purple" runat="server" 
        Text="Reset" onclick="buttonreset_Click"  />

        </div>
    </div>
    
     <br /> <br /> <br />
    <div class="w3-row w3-mobile">
<div class="w3-col s2"><br /></div>
<div  class=" w3-col s8 w3-mobile w3-centered">
<div style="width:100%" class="w3-mobile  w3-text-deep-purple">
<center>
<div class=" w3-xlarge w3-centered w3-light-blue">
    <asp:Label  ID="lblwardname" runat="server" Text=""></asp:Label>
   </div>
   <div class=" w3-xlarge w3-centered  w3-amber w3-animate-zoom">
    <asp:Label CssClass="w3-large w3-centered" ID="lblname" runat="server" Text=""></asp:Label>
   </div>
    </center>
</div>
   </div>
   </div>
    
    
    <div class="w3-row w3-mobile">
<div class="w3-col s2"><br /></div>
<div  class=" w3-col s8 w3-mobile w3-centered">
<div style="width:100%" class="w3-mobile w3-light-blue w3-text-deep-purple">
<center>
    <asp:Label CssClass="w3-large w3-centered" ID="lblgridviewheading" runat="server" Text=""></asp:Label>
    </center>
</div>
    <asp:GridView style="width:100%" ID="GridView1" runat="server" 
        BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" 
        CellPadding="3" DataSourceID="SqlDataSource1" GridLines="Horizontal" 
        AutoGenerateColumns="False" DataKeyNames="sno">
        <AlternatingRowStyle BackColor="#F7F7F7" />
        <Columns>
          
            
            <asp:BoundField DataField="bedno" HeaderText="Bedno" SortExpression="bedno" />
           
                <asp:TemplateField HeaderText="Occupant">
                <ItemTemplate>
                <%# IOPD.DataManager.PatientUtilities.getpatientname(Convert.ToInt32(Eval("patientno"))) %>
                </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="bedcharge" HeaderText="Bed Charge" SortExpression="bedcharge" />
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
        SelectCommand="SELECT * FROM hospitals.bedmaster WHERE ([roomno] = @sno) ORDER BY [bedno]">
        <SelectParameters>
            <asp:QueryStringParameter DefaultValue="sno" Name="sno" QueryStringField="sno" 
                Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>

</div>
</div>
</asp:Content>
