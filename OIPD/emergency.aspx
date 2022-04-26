<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="emergency.aspx.cs" Inherits="OIPD.emergency" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
<div class="w3-row">
<div class="w3-col s3"><br /></div>
<div   class="w3-col s6 w3-center w3-padding w3-card-4 w3-centered w3-border">


<center>
  <div class="w3-container w3-deep-purple">
    <h2>EMERGENCY FORM</h2>
    <asp:Label ID="message" runat="server" Text=""></asp:Label>
    <asp:Label ID="ipNumber" runat="server" Text="" CssClass="w3-large" Font-Bold="true"></asp:Label>
  </div>

    <center>
        <div id="mod" class="w3-modal w3-padding">
            <br /><br /><br />
            <div class="w3-modal-content w3-padding-large">
                <span onclick="closeModal()" class="w3-button w3-display-topright">&times;</span>
                <div class="w3-padding w3-center">
                    <asp:Label ID="lblMsgModal" runat="server"></asp:Label>
                    <asp:TextBox ID="txtTpaName" runat="server" CssClass="w3-input w3-sand w3-border w3-round-large"></asp:TextBox>
                    <br />
                    <asp:Button ID="btnAddTpa" runat="server" CssClass="w3-round-xxlarge w3-btn w3-purple" Text="Add TPA" onclick="btnAddTpa_Click" />
                </div>
            </div>
        </div>
    </center>
    <div class=" w3-border-bottom w3-border-blue">
        <asp:RadioButtonList Font-Bold="true" CssClass="w3-radio w3-large w3-text-blue" ID="rdoLst" 
            runat="server" DataSourceID="SqlDataSource3" DataTextField="type_of_patient" DataValueField="sno" 
            RepeatDirection="Horizontal" Width="100%" AutoPostBack="True" 
            onselectedindexchanged="rdoLst_Click"></asp:RadioButtonList>
        <asp:SqlDataSource ID="SqlDataSource3" runat="server"
            ConnectionString="<%$ ConnectionStrings:IODatabaseConnectionString %>" 
            SelectCommand="SELECT * FROM hospitals.patient_type"></asp:SqlDataSource>
        <br />
    </div>
    <div id="tpaList" runat="server" class="w3-padding" visible="false">
        <asp:DropDownList ID="drpdwntpalist" runat="server" CssClass="w3-input w3-sand w3-border w3-round w3-col s4" DataSourceID="SqlDataSource4" DataTextField="tpaname" DataValueField="sno">
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource4" runat="server" 
            ConnectionString="<%$ ConnectionStrings:IODatabaseConnectionString %>" 
            SelectCommand="SELECT * FROM hospitals.tpa ORDER BY [sno],[tpaname]"></asp:SqlDataSource>
        <div class="w3-col s4">&nbsp;</div>
        <div class="w3-center w3-col s4">
            <div class="w3-round-xxlarge w3-btn w3-purple" onclick="displayModal()"> ADD TPA </div>
        </div>
    </div>
    <script>
        function displayModal() {
            document.getElementById('mod').style.display = 'block';
        }
        function closeModal() {
            document.getElementById('mod').style.display = 'none'
        }
    </script>
    <div class="w3-mobile w3-row">
    <div class="w3-col s6 w3-mobile w3-padding ">
    <p>
         <asp:Label CssClass="w3-large w3-text-blue" ID="lbldepartment" runat="server" Text="Consultant Department"></asp:Label>
        <asp:DropDownList CssClass="w3-input w3-sand w3-border w3-round" 
             ID="drpdwndepart" runat="server" DataSourceID="SqlDataSource1" 
             DataTextField="departname" DataValueField="departmentno">
        
        </asp:DropDownList>
         <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
             ConnectionString="<%$ ConnectionStrings:IODatabaseConnectionString %>" 
             SelectCommand="SELECT * FROM hospitals.departments">
             <SelectParameters>
                 <asp:Parameter DefaultValue="1" Name="departmentno" Type="Int32" />
             </SelectParameters>
         </asp:SqlDataSource>
        <asp:Label CssClass="w3-large w3-text-blue" Width="100%" ID="lblfirstname" runat="server" Text="First Name"></asp:Label>
        <asp:DropDownList CssClass="w3-input w3-col s3 w3-round w3-sand w3-border w3-centered" ID="dropdowntitle" runat="server"  TabIndex="2">
            <asp:ListItem Text="Mr." Selected="True" Value="Mr."></asp:ListItem>
            <asp:ListItem Text="Master" Value="Master"></asp:ListItem>
            <asp:ListItem Text="Mrs." Value="Mrs."></asp:ListItem>
            <asp:ListItem Text="Miss" Value="Miss"></asp:ListItem>
        </asp:DropDownList>
        <asp:TextBox CssClass="w3-sand w3-col s9 w3-round w3-input w3-border" ID="txtfirstname" runat="server" TabIndex="3"></asp:TextBox>
        <asp:Label CssClass="w3-large w3-text-blue" ID="lblage" Width="100%" runat="server" Text="Age"></asp:Label>
        <asp:TextBox CssClass="w3-sand w3-round w3-col s4 w3-input w3-border" ID="txtYears" placeholder="Years" runat="server" TabIndex="5"></asp:TextBox>
        <asp:TextBox CssClass="w3-sand w3-round w3-col s4 w3-input w3-border" ID="txtMonths" placeholder="Months" Text="0" runat="server" TabIndex="6"></asp:TextBox>
        <asp:TextBox CssClass="w3-sand w3-round w3-col s4 w3-input w3-border" ID="txtDays" placeholder="Days" Text="0" runat="server" TabIndex="7"></asp:TextBox>
         <asp:Label CssClass="w3-large w3-text-blue" ID="lbladdress" runat="server" Text="Address"></asp:Label>
        <asp:TextBox CssClass=" w3-round w3-sand w3-input w3-border" ID="txtaddress" runat="server" TabIndex="9"></asp:TextBox>
        <asp:Label CssClass="w3-large w3-text-blue" ID="lblreffered" runat="server" Text="Reffered By"></asp:Label>
        
        <asp:DropDownList Width="100%" 
             CssClass="w3-input w3-col s3 w3-round w3-sand w3-border w3-centered" 
             ID="drpdwnRef" runat="server" 
             onselectedindexchanged="drpdwnRef_SelectedIndexChanged" AutoPostBack="true" TabIndex="11">
            <asp:ListItem Text="Self" Selected="True" Value="Self"></asp:ListItem>
            <asp:ListItem Text="Hospital" Value="Hospital"></asp:ListItem>
            <asp:ListItem Text="Doctor" Value="Doctor"></asp:ListItem>
        </asp:DropDownList>

        <asp:Label CssClass="w3-large w3-text-blue" ID="lblDocNumber" runat="server" Width="100%"    Text="Doctor's Number"></asp:Label>
        <asp:TextBox CssClass=" w3-round w3-sand w3-input w3-border" ID="txtDocNumber" runat="server" TabIndex="13"></asp:TextBox>
    </p>


    </div>


    <div class="w3-col s6 w3-mobile w3-padding  ">
    <p>  
      <asp:Label CssClass="w3-large w3-text-blue" Width="100%" ID="lbldate" runat="server" Text="Date"></asp:Label>
        <asp:TextBox CssClass="w3-sand w3-round w3-input w3-border" ID="txtdate" runat="server"  TabIndex="1"></asp:TextBox>    
      <asp:Label CssClass="w3-large w3-text-blue" ID="lbllastname" runat="server" Text="Last Name"></asp:Label>
        <asp:TextBox CssClass=" w3-round w3-sand w3-input w3-border" ID="txtlastname" runat="server"  TabIndex="4"></asp:TextBox>
          <asp:Label CssClass="w3-large w3-text-blue" ID="lblgender" runat="server" Text="Gender" ></asp:Label><br />
        <asp:DropDownList CssClass="w3-input w3-round w3-sand w3-border w3-centered" ID="dropdowngender" runat="server"  TabIndex="8">
        <asp:ListItem Text="-- Select Gender--" Selected="True" Value="default value"></asp:ListItem>
        <asp:ListItem Text="Male" Value="Male"></asp:ListItem>
        <asp:ListItem Text="Female" Value="Female"></asp:ListItem>
     </asp:DropDownList>
      <asp:Label CssClass="w3-large w3-text-blue" ID="lblfathersname" runat="server" Text="Fathers Name / Wife Of"></asp:Label>
        <asp:TextBox CssClass=" w3-round w3-sand w3-input w3-border" ID="txtfathersname" runat="server" TabIndex="10"></asp:TextBox>
        <asp:Label CssClass="w3-large w3-text-blue" ID="lblHospital" runat="server" Text="Name"></asp:Label>
        <asp:DropDownList CssClass="w3-input w3-round w3-sand w3-border w3-centered" 
            ID="drpdwnHospital" runat="server" DataSourceID="SqlDataSource2" 
            DataTextField="hospitalname" DataValueField="sno" 
            onselectedindexchanged="drpdwnHospital_SelectedIndexChanged" AutoPostBack="true" TabIndex="12">
        
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
            ConnectionString="<%$ ConnectionStrings:IODatabaseConnectionString %>" 
            SelectCommand="SELECT * FROM hospitals.refferHospitals"></asp:SqlDataSource>
        
        <asp:TextBox CssClass=" w3-round w3-sand w3-input w3-border" Width="100%" placeholder="Enter Doctor's Name" ID="txtreffered" runat="server" TabIndex="10"></asp:TextBox>

        <asp:Label CssClass="w3-large w3-text-blue" Width="100%" ID="lblmobileno" runat="server" Text="Mobile No."></asp:Label>
        <asp:TextBox CssClass=" w3-round w3-sand w3-input w3-border" ID="txtnumber" runat="server"  TabIndex="13"></asp:TextBox>
        <asp:Label CssClass="w3-large w3-text-blue" ID="Label2" runat="server" Text="Amount"></asp:Label>
        <asp:TextBox CssClass=" w3-round w3-sand w3-input w3-border" ID="txtamount" Text="200" ReadOnly="false" runat="server"></asp:TextBox>
        </p>
  
    </div>
    </div>
    
     </center>
    <div class="w3-row w3-mobile w3-center">
    <div class="w3-col s4">
        <asp:Button ID="btnregister" style="margin-left:50%" 
            class=" w3-round-xxlarge w3-btn w3-purple"  runat="server" TabIndex="11" Text="Register" 
            onclick="makeReadOnly" />
    </div>
    <div class="w3-col s4">
    <asp:HyperLink ID="btnPrint" NavigateUrl=""  runat="server" Target="_blank" Visible="false">Print</asp:HyperLink>
    </div>
    <div class="w3-col s4">
        <asp:Button ID="btnreset" style="width:35%" 
            class=" w3-round-xxlarge w3-btn w3-purple" runat="server" TabIndex="12" Text="Reset" 
            onclick="btnreset_Click" />
    </div>
    </div>
   <br /> <br />
     
    
  
</div>
</div>
 <br /> <br />



         <script type="text/javascript">
             $(function () {
                 $(function () {
                     var currentYear = (new Date).getFullYear();
                     var currentMonth = (new Date).getMonth() + 1;
                     var currentDay = (new Date).getDate();
                     $("#datepicker").datepicker({ minDate: new Date((currentYear - 1), 12, 1), dateFormat: 'dd/mm/yy', maxDate: new Date(currentYear, 11, 31) });

                     $("#ContentPlaceHolder1_txtdate").datepicker({

                         changeMonth: true,
                         changeYear: true,
                         yearRange: '1950:currentYear',
                         dateFormat: 'dd-M-yy',
                         defaultDate: 'currentdate'
                     });
                 });

             });
         </script>



</asp:Content>
