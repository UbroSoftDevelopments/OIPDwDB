<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="roommaster.aspx.cs" Inherits="OIPD.roommaster" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br /><br />
<div class="w3-row">
<div class="w3-col s3"><br /></div>
<div   class="w3-col s6 w3-center w3-padding w3-card-4 w3-centered w3-border">
<center>
<div class="w3-centered w3-round w3-deep-purple">
    <asp:Label CssClass="w3-text-light-blue w3-large" ID="lblwardname" runat="server" Text=""></asp:Label>
</div>
  <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label><br />
    <asp:Label ID="lblroomno" CssClass="w3-large w3-text-blue" runat="server" Text=" Enter Room No."></asp:Label>
    <asp:TextBox CssClass="w3-input w3-border w3-sand w3-round" ID="txtroomno" runat="server"></asp:TextBox>
    
    </center>
    <div class="w3-container w3-margin w3-large w3-text-blue">
  <label>Room Type</label><br />
 
  <asp:DropDownList ID="ddTypes"  runat="server" CssClass=" w3-center w3-input w3-border w3-round w3-sand w3-dropdown-hover" 
            DataSourceID="SqlDataSource2" DataTextField="roomtype" 
            DataValueField="roomtypeno">
  </asp:DropDownList>

        <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
            ConnectionString="<%$ ConnectionStrings:IODatabaseConnectionString %>" 
            SelectCommand="SELECT * FROM hospitals.roomtypes ORDER BY [roomtypeno]">
        </asp:SqlDataSource>
     
</div>
    <br />
     <asp:Button ID="buttonsubmit" 
            class=" w3-round-xxlarge w3-large w3-btn w3-purple" runat="server" 
        Text="Submit" onclick="buttonsubmit_Click" />
        <asp:Button ID="buttonreset"  
            class=" w3-round-xxlarge w3-large w3-btn w3-purple" runat="server" 
        Text="Reset" onclick="buttonreset_Click" />


</div>
</div>
<br /><br />
<div class="w3-row w3-mobile">
<div class="w3-col s2"><br /></div>
<div  class=" w3-col s8 w3-mobile w3-centered">
<div style="width:100%" class="w3-mobile w3-light-blue w3-text-deep-purple">
<center>
    <asp:Label CssClass="w3-large w3-centered" ID="lblgridviewheading" runat="server" Text=""></asp:Label>
    </center>
</div>
    <asp:GridView style="width:100%" ID="GridView1" runat="server" 
        AutoGenerateColumns="False" BackColor="White" BorderColor="#E7E7FF" 
        BorderStyle="None" BorderWidth="1px" CellPadding="3" DataKeyNames="sno" 
        DataSourceID="SqlDataSource1" GridLines="Horizontal" 
        onrowupdated="GridView1_RowUpdated" onrowupdating="GridView1_RowUpdating">
        <AlternatingRowStyle BackColor="#F7F7F7" />
        <Columns>
           
         
            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
           
         
            <asp:BoundField DataField="roomno" HeaderText="Room No." 
                SortExpression="roomno" />
                <asp:TemplateField HeaderText="Room Type">
                <ItemTemplate>

                <%# IOPD.DataManager.RoomUtilities.getRoomTypeName( Eval("roomtype")) %>
                </ItemTemplate>
                <EditItemTemplate>
                   <asp:DropDownList ID="ddTypesEdit"  runat="server" 
        CssClass=" w3-center w3-input w3-border w3-round w3-sand w3-dropdown-hover" 
        DataSourceID="SqlDataSource3" DataTextField="roomtype" DataValueField="roomtypeno" 
         SelectedValue='<%# Bind("roomtype") %>'  >
         
  </asp:DropDownList>
     
                </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Select ">
                <ItemTemplate>
                <a title='Select<%# Eval("roomtype") %>'href='bedmaster.aspx?sno=<%# Eval("sno") %>'>Add Bed To&nbsp<%#  Eval("roomno") %></a>
                </ItemTemplate>
                
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
   
  
    <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
        ConnectionString="<%$ ConnectionStrings:IODatabaseConnectionString %>" 
        SelectCommand="SELECT * FROM hospitals.roomtypes ORDER BY [roomtypeno]">
    </asp:SqlDataSource>
  
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:IODatabaseConnectionString %>" 
        SelectCommand="SELECT sno, wardno, roomno, roomtype FROM hospitals.roommaster WHERE (wardno = @wardno) ORDER BY roomno"
        UpdateCommand="update hospitals.roommaster set roomno=@roomno,roomtype=@roomtype where sno=@sno"
        DeleteCommand="delete from hospitals.roommaster where sno=@sno"
        >
        <DeleteParameters>
            <asp:Parameter Name="wardno" />
        </DeleteParameters>
        <SelectParameters>
            <asp:QueryStringParameter Name="wardno" QueryStringField="wardno" />
        </SelectParameters>
        <UpdateParameters>
            <asp:Parameter Name="roomno" />
            <asp:Parameter Name="roomtype" />
            <asp:Parameter Name="wardno" />
        </UpdateParameters>

    </asp:SqlDataSource>


</div>
</div>
<br /><br />

</asp:Content>
