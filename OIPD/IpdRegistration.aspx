<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="IpdRegistration.aspx.cs" Inherits="OIPD.IpdRegistration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
<div class=" w3-container w3-card-4 w3-padding w3-center w3-centered w3-border w3-border-teal">

  <div class="w3-row">
      <div class="w3-col s3"><br /></div>
      <div class="w3-container w3-col s6 w3-light-blue w3-center">
        <h2 class="w3-xlarge w3-center w3-text-teal"><b>SEARCH PATIENT</b></h2>
      </div>
  </div>

  <div class="w3-row">
      <div class="w3-col s3"><br /></div>
      <asp:Label ID="lblErrMsg" runat="server" CssClass="w3-col s6 w3-center w3-half w3-centered w3-padding w3-text-red" Text=""/><br />
  </div>

  <div class="w3-row">
      <div class="w3-col s3"><br /></div>
      <asp:TextBox ID="txtPatientNumber" runat="server" placeholder="Enter Patient Name" CssClass="w3-col s6 w3-center w3-input w3-padding"/><br />
  </div>
  <br />
  <asp:Button ID="btnSearch" class="w3-center w3-round-xxlarge w3-large w3-btn w3-teal"  runat="server" Text="Search" OnClick="searching"/>
  <br /><br />
 <div class="w3-container">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"  CssClass="w3-table-all"
        DataKeyNames="patientno" DataSourceID="SqlDataSource1" CellPadding="4" 
        ForeColor="#333333" GridLines="None">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
                <asp:TemplateField HeaderText="Patient No">
                <ItemTemplate>
                <%# IOPD.DataManager.RegistrationUtilities.GetRegistrationNo(Convert.ToInt32(Eval("patientno"))) %>
                
                </ItemTemplate>
                </asp:TemplateField>
           

                    <asp:TemplateField HeaderText="Department">
                <ItemTemplate>
                <%# IOPD.DataManager.DepartmentValidation.GetDepartmentNameByDepartmentNo(Eval("departmentno"))%>
                </ItemTemplate>
                </asp:TemplateField>


                <asp:TemplateField HeaderText="Date of Entry">
                <ItemTemplate>
                <%# IOPD.DataManager.DateUtilities.dateFormat(Eval("dateofentry"))%>
                </ItemTemplate>
                </asp:TemplateField>
       
            <asp:BoundField DataField="firstname" HeaderText="First Name" 
                SortExpression="firstname" />
            <asp:BoundField DataField="lastname" HeaderText="Last Name" 
                SortExpression="lastname" />
                  <asp:BoundField DataField="ageyears" HeaderText="Years" 
                SortExpression="ageyears" />
            <asp:BoundField DataField="agemonths" HeaderText="Months" 
                SortExpression="agemonths" />
          <asp:TemplateField HeaderText="Action">
          <ItemTemplate>
          <a href="ipdform.aspx?patientno=<%# Eval("patientno") %>" >Admit</a>
          </ItemTemplate>
          </asp:TemplateField>
          
          
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
        SelectCommand="SELECT * FROM hospitals.opdform WHERE ((([firstname] LIKE '%' + @firstname + '%') OR ([lastname] LIKE '%' + @lastname + '%')) AND ([patientno] > '1'))
        and patientno not in (
        SELECT        patientno
FROM            hospitals.bedallotment
WHERE        (sno NOT IN
                             (SELECT        allotmentno
                               FROM            hospitals.bedleaving)) 
                               )
                               and patientno not in(select patientno from hospitals.discharge)
        
        
         ORDER BY [patientno] DESC">
        <SelectParameters>
            <asp:ControlParameter ControlID="txtPatientNumber" DefaultValue="%" 
                Name="firstname" PropertyName="Text" Type="String" />
            <asp:ControlParameter ControlID="txtPatientNumber" DefaultValue="%" 
                Name="lastname" PropertyName="Text" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
    </div>

</div>
<br />

</asp:Content>
