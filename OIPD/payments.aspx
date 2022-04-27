<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="payments.aspx.cs" Inherits="OIPD.payments" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<br />
<div class=" w3-container w3-card-4 w3-padding w3-center w3-centered w3-border w3-border-teal">
<br />
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
  <asp:Button ID="btnSearch" class="w3-center w3-round-xxlarge w3-large w3-btn w3-teal"  runat="server" Text="Search"/>
  <br /><br />
  <!--DataKeyNames="patientno" DataSourceID="SqlDataSource1"-->
  <asp:GridView ID="tempGrid" runat="server" CssClass="w3-hide"></asp:GridView>
 <div class="w3-container">
    <asp:GridView ID="GridView1" runat="server" CssClass="w3-table-all"
         CellPadding="4" 
        ForeColor="#333333" GridLines="None" onrowdatabound="GridView1_RowDataBound">
        <AlternatingRowStyle BackColor="White" />
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
        SelectCommand="SELECT * FROM hospitals.opdform WHERE ((([firstname] LIKE '%' + @firstname + '%') OR ([lastname] LIKE '%' + @lastname + '%')) AND ([patientno]>'1')) OR  (patientno IN (SELECT patientno FROM currentbedpatients)) OR (patientno NOT IN (SELECT p.patientno FROM payments AS p INNER JOIN expenses AS e ON p.patientno = e.patientno GROUP BY p.patientno HAVING (SUM(p.amount) <> SUM(e.amount)))) ORDER BY [patientno] DESC">
        <SelectParameters>
            <asp:ControlParameter ControlID="txtPatientNumber" DefaultValue="%" 
                Name="firstname" PropertyName="Text" Type="String" />
            <asp:ControlParameter ControlID="txtPatientNumber" DefaultValue="%" 
                Name="lastname" PropertyName="Text" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
    </div>
    <br />
</div>
<br />
<!----------------------
    SELECT        sno, patientno, dateofpayment, amount, comments, paymentmode, paymentdata, currentuser
FROM            payments
WHERE        (patientno IN
                             (SELECT        patientno
                               FROM            currentbedpatients)) OR
                         (patientno IN
                             (SELECT        payments_1.patientno
                               FROM            payments AS payments_1 INNER JOIN
                                                         expenses ON payments_1.patientno = expenses.patientno AND SUM(payments_1.amount) <> SUM(expenses.amount)
                               GROUP BY payments_1.patientno))


SELECT        patientno, departmentno, dateofentry, firstname, lastname, agemonths, ageyears, gender, address, fathername, referredfrom, mobileno, title, doctorno, currentuser, 
                         nextrenewdate, totalrenews, agedays, patienttype, ipnumber, patientdata
FROM            opdform
WHERE        (patientno IN
                             (SELECT        payments_1.patientno
                               FROM            payments AS payments_1 INNER JOIN
                                                         expenses AS e1 ON payments_1.patientno = e1.patientno
                               GROUP BY payments_1.patientno
                               HAVING         (SUM(payments_1.amount) <> SUM(e1.amount))))
---------------------------->
</asp:Content>
