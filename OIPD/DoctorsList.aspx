<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DoctorsList.aspx.cs" Inherits="OIPD.DoctorList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
<div class="w3-row w3-mobile">
<div class="w3-col s2"><br /></div>
<div   class="w3-col s8 w3-center w3-padding w3-card-4 w3-centered w3-border">

<div style="width:100%" class="w3 w3-light-blue">
  <h2>Doctor's List Management</h2>
    <asp:Label ID="lblmessage" runat="server" Text=""></asp:Label>
</div>
<br />
<div class="w3-row-padding w3-mobile">
  <div class="w3-col s6">
      <asp:Label ID="lbltitle" runat="server" Text="Title"></asp:Label>
      <asp:TextBox CssClass="w3-border w3-round w3-input w3-sand" ID="txttilte" runat="server" Text="Dr."></asp:TextBox>
       <asp:Label ID="lblqualification" runat="server" Text="Qualification"></asp:Label>
      <asp:TextBox CssClass="w3-border w3-round w3-input w3-sand" ID="txtqualification" runat="server"></asp:TextBox>
            <asp:Label ID="lbltype" runat="server" Text="Type"></asp:Label>
      <asp:DropDownList CssClass=" w3-border w3-round w3-input w3-sand" ID="ddtype" runat="server">
      <asp:ListItem Text="--Select Type--"></asp:ListItem>
      <asp:ListItem Text="Permanent" Value="Permanent"></asp:ListItem>
      <asp:ListItem Text="Visiting" Value="Visiting"></asp:ListItem>
 </asp:DropDownList>
  </div>
  <div class="w3-col s6">
    <asp:Label ID="lblname" runat="server" Text="Doctor Name"></asp:Label>
      <asp:TextBox CssClass="w3-border w3-round w3-input w3-sand" ID="txtname" runat="server"></asp:TextBox>
      <asp:Label ID="lbldepartment" runat="server" Text="Department"></asp:Label><br />
      <asp:DropDownList CssClass="w3-input w3-border w3-round w3-sand w3-mobile" 
          ID="DropDownList1" runat="server" DataSourceID="SqlDataSource2" 
          DataTextField="departname" DataValueField="departmentno">

      </asp:DropDownList>
          <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
          ConnectionString="<%$ ConnectionStrings:IODatabaseConnectionString %>" 
          SelectCommand="SELECT * FROM hospitals.departments"></asp:SqlDataSource>
          <asp:Label ID="lblcharge" runat="server" Text="Doctor Charge"></asp:Label>
      <asp:TextBox CssClass="w3-border w3-round w3-input w3-sand" ID="txtcharge" runat="server"></asp:TextBox>
      
      <br />
   
  </div>
     <center>       
         <asp:Button ID="buttonsubmit" 
            class=" w3-round-xxlarge w3-large w3-btn w3-purple" runat="server" 
        Text="Submit" onclick="buttonsubmit_Click"/>&nbsp;&nbsp;
        <asp:Button ID="buttonreset" 
            class=" w3-round-xxlarge w3-large w3-btn w3-purple" runat="server" 
        Text="Reset  " onclick="buttonreset_Click"/>
        </center>
        <br />
</div>
<br />
<div  class=" w3-row">
<div class="w3-col s1"><br /></div>
<div class="w3-col s10 w3-center">
<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="doctorno" 
        DataSourceID="SqlDataSource1" BackColor="White" BorderColor="#E7E7FF" 
        BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Horizontal" style="width:100%">
    <AlternatingRowStyle BackColor="#F7F7F7" />
    <Columns>
        <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
        <asp:BoundField DataField="title" HeaderText="Title" SortExpression="title" ReadOnly="true"/>
        <asp:BoundField DataField="doctorname" HeaderText="Doctor Name" 
            SortExpression="doctorname" />

            <asp:TemplateField HeaderText="Department">
                <ItemTemplate>
                <%# IOPD.DataManager.DepartmentValidation.GetDepartmentNameByDepartmentNo(Eval("departmentno"))%>
                </ItemTemplate>
                </asp:TemplateField>

        <asp:BoundField DataField="qualification" HeaderText="Qualification" 
            SortExpression="qualification" />
        <asp:BoundField DataField="type" HeaderText="Type" SortExpression="type" />
        <asp:BoundField DataField="charge" HeaderText="Charge" 
            SortExpression="charge" />
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
    <br />
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:IODatabaseConnectionString %>" 
        DeleteCommand="DELETE FROM hospitals.doctorslist WHERE [doctorno] = @doctorno" 
        SelectCommand="SELECT doctorno, title, doctorname, departmentno, qualification, type, charge FROM hospitals.doctorslist WHERE [doctorno]>'1' ORDER BY doctorno" 
        
        UpdateCommand="UPDATE hospitals.doctorslist SET [doctorname] = @doctorname, [qualification] = @qualification, [type] = @type, [charge] = @charge WHERE [doctorno] = @doctorno">
        <DeleteParameters>
            <asp:Parameter Name="doctorno" Type="Int32" />
        </DeleteParameters>
        <UpdateParameters>
            <asp:Parameter Name="doctorname" Type="String" />
            <asp:Parameter Name="qualification" Type="String" />
            <asp:Parameter Name="type" Type="String" />
            <asp:Parameter Name="charge" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>
</div>
</div>
</div>
</div><br /><br />
</asp:Content>
