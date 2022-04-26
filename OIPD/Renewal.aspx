<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Renewal.aspx.cs" Inherits="OIPD.Renewal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
<div class=" w3-container w3-card-4 w3-padding w3-center w3-centered w3-border w3-border-teal">

  <div class="w3-row">
      <div class="w3-col s3"><br /></div>
      <div class="w3-container w3-col s6 w3-light-blue w3-center">
        <h2 class="w3-xlarge w3-center w3-text-teal"><b>OPD PATIENTS LIST</b></h2>
      </div>
  </div>

  <div class="w3-row">
      <div class="w3-col s3"><br /></div>
      <asp:Label ID="lblErrMsg" runat="server" CssClass="w3-col s6 w3-center w3-half w3-centered w3-padding w3-text-red" Text=""/><br />
  </div>

  
  <br />
  <div class="w3-row">
      <div class="w3-col s3"><br /></div>
      <asp:TextBox ID="txtPatientNumber" runat="server" placeholder="Enter Patient Name" CssClass="w3-col s6 w3-center w3-input w3-padding"/><br />
  </div>
  <br />
  <asp:Button ID="btnSearch" class="w3-center w3-round-xxlarge w3-large w3-btn w3-teal"  runat="server" Text="Search" OnClick="searching"/>
  <br /><br />
 <div class="w3-container">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="w3-table-all"
         DataKeyNames="patientno" DataSourceID="SqlDataSource1" BackColor="White" 
         BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" 
         GridLines="Vertical">
        <AlternatingRowStyle BackColor="#DCDCDC" />
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
          <asp:Button ID="btnsno" runat="server" Text="Renew" OnClick="check" CommandArgument='<%#Eval("patientno") %>' CommandName="serialno"/>
          </ItemTemplate>
          </asp:TemplateField>
        </Columns>
        <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
        <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
        <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#0000A9" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#000065" />
     </asp:GridView>
     <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
         ConnectionString="<%$ ConnectionStrings:IODatabaseConnectionString %>" 
         
         SelectCommand="SELECT * FROM hospitals.opdform WHERE ((firstname LIKE '%' + @firstname + '%') OR (lastname LIKE '%' + @lastname + '%')) AND (patientno > '1') ORDER BY patientno DESC">
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

<script type="text/javascript">
    $(function () {
        $(function () {
            var currentYear = (new Date).getFullYear();
            var currentMonth = (new Date).getMonth() + 1;
            var currentDay = (new Date).getDate();
            $("#datepicker").datepicker({

                minDate: new Date((currentYear - 1), 12, 1),
                dateFormat: 'dd/mm/yy',
                maxDate: new Date(currentYear, 11, 31)
            });

            $("#ContentPlaceHolder1_txtStartDate").datepicker({

                changeMonth: true,
                changeYear: true,
                maxDate: '0',
                yearRange: '1950:currentYear',
                dateFormat: 'dd-M-yy',
                defaultDate: 'currentdate'
            });
            $("#ContentPlaceHolder1_txtEndDate").datepicker({

                changeMonth: true,
                changeYear: true,
                maxDate: '0',
                yearRange: '1950:currentYear',
                dateFormat: 'dd-M-yy',
                defaultDate: 'currentdate'
            });

        });

    });
</script>
</asp:Content>
