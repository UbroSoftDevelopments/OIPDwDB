<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Renewform.aspx.cs" Inherits="OIPD.Renewform" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
<br />
<div class="w3-row">
<div class="w3-col s3"><br /></div>
<div   class="w3-col s6 w3-center w3-padding w3-card-4 w3-centered w3-border">


<center>
  <div class="w3-container w3-deep-purple">
    <h2>OPD FORM</h2>
  </div>
  <div class="w3-container w3-deep-purple">
    <asp:Label ID="message" runat="server" Text=""></asp:Label>
  </div>
    <div class="w3-mobile w3-row">
    <div class="w3-col s6 w3-mobile w3-padding ">
    <p>
        <asp:Label CssClass="w3-large w3-text-blue" ID="lbldepartment" runat="server" Text="Consultant Department"></asp:Label>
        <asp:Label CssClass="w3-input w3-sand w3-border w3-round" ID="lbldepart" runat="server" Text=""></asp:Label>
        <asp:Label CssClass="w3-large w3-text-blue" Width="100%" ID="lblfirstname" runat="server" Text="First Name"></asp:Label>
        <asp:Label CssClass="w3-input w3-col s3 w3-round w3-sand w3-border w3-centered" ID="lbltitle" runat="server"  TabIndex="2"></asp:Label>
        <asp:Label CssClass="w3-sand w3-col s9 w3-round w3-input w3-border" ID="txtfirstname" runat="server" TabIndex="3"></asp:Label>
        <asp:Label CssClass="w3-large w3-text-blue" ID="lblage" Width="100%" runat="server" Text="Age"></asp:Label>
        <asp:Label CssClass="w3-sand w3-round w3-col s4 w3-input w3-border" ID="txtYears" placeholder="Years" runat="server" TabIndex="5"></asp:Label>
        <asp:Label CssClass="w3-sand w3-round w3-col s4 w3-input w3-border" ID="txtMonths" placeholder="Months" Text="0" runat="server" TabIndex="6"></asp:Label>
        <asp:Label CssClass="w3-sand w3-round w3-col s4 w3-input w3-border" ID="txtDays" placeholder="Days" Text="0" runat="server" TabIndex="6"></asp:Label>
        <asp:Label CssClass="w3-large w3-text-blue" ID="lbladdress" runat="server" Text="Address"></asp:Label>
        <asp:Label CssClass=" w3-round w3-sand w3-input w3-border" ID="txtaddress" runat="server" TabIndex="8"></asp:Label>
        <asp:Label CssClass="w3-large w3-text-blue" ID="lblreffered" runat="server" Text="Reffered By"></asp:Label>
        <asp:Label CssClass="w3-input w3-col s3 w3-round w3-sand w3-border w3-centered" ID="drpdwnRef" Width="100%"  runat="server" TabIndex="10"></asp:Label>
        
        <asp:Label CssClass="w3-large w3-text-blue" ID="lblDocNumber" Visible="false" runat="server" Width="100%"    Text="Doctor's Number"></asp:Label>
        <asp:Label CssClass=" w3-round w3-sand w3-input w3-border" Visible="false" ID="txtDocNumber" runat="server" TabIndex="12"></asp:Label>
    </p>
    </div>


    <div class="w3-col s6 w3-mobile w3-padding  ">
    <p>  
        <asp:Label CssClass="w3-large w3-text-blue" Width="100%" ID="lbldate" runat="server" Text="Date"></asp:Label>
        <asp:TextBox CssClass="w3-sand w3-round w3-input w3-border" ID="txtdate" runat="server"  TabIndex="1"></asp:TextBox>    
        <asp:Label CssClass="w3-large w3-text-blue" ID="lbllastname" runat="server" Text="Last Name"></asp:Label>
        <asp:Label CssClass=" w3-round w3-sand w3-input w3-border" ID="txtlastname" runat="server"  TabIndex="4"></asp:Label>
        <asp:Label CssClass="w3-large w3-text-blue" ID="lblgender" runat="server" Text="Gender" ></asp:Label><br />
        <asp:Label CssClass="w3-input w3-round w3-sand w3-border w3-centered" ID="dropdowngender" runat="server"  TabIndex="7"></asp:Label>
        <asp:Label CssClass="w3-large w3-text-blue" ID="lblfathersname" runat="server" Text="Fathers Name / Wife Of"></asp:Label>
        <asp:Label CssClass=" w3-round w3-sand w3-input w3-border" ID="txtfathersname" runat="server" TabIndex="9"></asp:Label>

        <asp:Label CssClass="w3-large w3-text-blue" Width="100%" ID="lblmobileno" runat="server" Text="Patient's Mobile No."></asp:Label>
        <asp:Label CssClass=" w3-round w3-sand w3-input w3-border" ID="txtnumber" runat="server"  TabIndex="11"></asp:Label>
        <asp:Label CssClass="w3-large w3-text-blue" ID="Label2" runat="server" Text="Amount"></asp:Label>
        <asp:Label CssClass=" w3-round w3-sand w3-input w3-border" ID="txtamount" Text="100" ReadOnly="true" runat="server"></asp:Label>
        </p>
    </div>
    </div>
    
     </center>
    <div class="w3-row w3-mobile w3-center">
        <div class="w3-col s4">
            <asp:Button ID="HyperLink1" CssClass="w3-round-xxlarge w3-btn w3-purple" OnClick="renew" runat="server" Text="Renew" />
        </div>
        <div class="w3-col s4" runat="server" id="pri" visible="false">
            <asp:HyperLink ID="btnPrint" NavigateUrl="" CssClass="w3-round-xxlarge w3-btn w3-purple"  runat="server" Target="_blank" Text="Print"></asp:HyperLink>
        </div>
        <div class="w3-col s4">
            <asp:Hyperlink ID="btnreset" CssClass=" w3-round-xxlarge w3-btn w3-purple" runat="server" Text="Home" NavigateUrl="home.aspx"/>
        </div>
    </div>
    
   

   <br /><br />
     
    
  
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
                         maxDate: '0',
                         dateFormat: 'dd-M-yy',
                         defaultDate: 'currentdate'
                     });
                 });

             });
         </script>

</asp:Content>
