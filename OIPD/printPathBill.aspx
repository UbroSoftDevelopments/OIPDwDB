<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="printPathBill.aspx.cs" Inherits="OIPD.printPathBill" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Print</title>
    <link rel="Stylesheet" href="https://www.w3schools.com/w3css/4/w3.css" />
    <link rel="stylesheet" type="text/css" href="http://cdn.webrupee.com/font"/>
    <link rel="stylesheet" href="//maxcdn.bootstrapcdn.com/font-awesome/4.3.0/css/font-awesome.min.css"/>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css"/>
    <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css"/>
    <script type="text/javascript" src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script type="text/javascript" src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>

    <script type="text/javascript">
        function printpage() {
            var printButton = document.getElementById("printForm");
            var editButton = document.getElementById("btnEdit");
            printButton.style.visibility = 'hidden';
            editButton.style.visibility = 'hidden';
            window.print()
            printButton.style.visibility = 'visible';
            editButton.style.visibility = 'visible';
        }
        
    $(function () {
        $(function () {
            var currentYear = (new Date).getFullYear();
            var currentMonth = (new Date).getMonth() + 1;
            var currentDay = (new Date).getDate();
            $("#datepicker").datepicker({ minDate: new Date((currentYear - 1), 12, 1), dateFormat: 'dd/mm/yy', maxDate: new Date(currentYear, 11, 31) });

            $("#dateOfEntry").datepicker({
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
    <style type="text/css">
    .invoice-box {
        max-width: 800px;
        margin: auto;
        padding: 20px;
        border: 1px solid #eee;
        box-shadow: 0 0 10px rgba(0, 0, 0, .15);
        font-size: 14px;
        line-height: 20px;
        font-family: 'Helvetica Neue', 'Helvetica', Helvetica, Arial, sans-serif;
        color: #333;
    }
    
    .invoice-box table {
        width: 100%;
        line-height: inherit;
        text-align: left;
    }
    
    .invoice-box table td {
        padding: 3px;
        vertical-align: top;
    }
    
    .invoice-box table tr td:nth-child(2) {
        text-align: right;
    }
    
    .invoice-box table tr.top table td {
        padding-bottom: 10px;
    }
    
    .invoice-box table tr.top table td.title {
        font-size: 40px;
        line-height: 40px;
        color: #333;
    }
    
    .invoice-box table tr.information table td {
        padding-bottom: 40px;
    }
    
    .invoice-box table tr.heading td {
        background: #eee;
        border-bottom: 1px solid #ddd;
        font-weight: bold;
    }
    
    .invoice-box table tr.details td {
        padding-bottom: 20px;
    }
    
    .invoice-box table tr.item td{
        border-bottom: 1px solid #eee;
    }
    
    .invoice-box table tr.item.last td {
        border-bottom: none;
    }
    
    .invoice-box table tr.total td:nth-child(2) {
        border-top: 2px solid #eee;
        font-weight: bold;
    }
    
    @media only screen and (max-width: 600px) {
        .invoice-box table tr.top table td {
            width: 100%;
            display: block;
            text-align: center;
        }
        
        .invoice-box table tr.information table td {
            width: 100%;
            display: block;
            text-align: center;
        }
    }
    
    /** RTL **/
    .rtl {
        direction: rtl;
        font-family: Tahoma, 'Helvetica Neue', 'Helvetica', Helvetica, Arial, sans-serif;
    }
    
    .rtl table {
        text-align: right;
    }
    
    .rtl table tr td:nth-child(2) {
        text-align: left;
    }
    </style>
</head>
<body><br />
    <form id="form1" runat="server">
    <div class="w3-center invoice-box w3-card">
<table cellspacing="0" cellpadding="0">
<tr class="top">
    <td>
        <table width="100%">
        <tr>
            <td colspan="1" class="w3-left"><img src="Resources/geetanjaliLogo.png" alt="hospital_logo" height="100" width="100" /></td>
            <td colspan="2">
                <div>
                    <center><label style="font-size:2">AN ISO : 9001:2015 CERTIFIED HOSPITAL</label><br/>
                    <label style="font-size:2">Reged No. : CMO/HOP/21/MZP</label><br/>
                    <label class="w3-xlarge w3-center title"><b>Geetanjali Life Care & Surgical Pvt. Ltd. Trauma & Critical Care</b></label>
                    <!--<label class="w3-xlarge w3-center title"><b>गीतांजलि लाइफ केयर एंड सर्जिकल सेंटर ट्रामा एंड क्रिटिकल केयर</b></label>-->
                    <br />
                    <label class="w3-large w3-center">Mirzapur - Varanasi Road, Milkipur</label>
                    <br />
                    <label class="w3-large w3-center">Uttar Pradesh 231305</label></center>
                </div>
            </td>
            <td colspan="1" class="w3-right"><b>Email -:</b><br/>geetanjalihospitalvns@gmail.com<br/>
                <b>Phone -:</b><br/>9839980333,7565000033<br /><b>GSTIN -: </b>09AAHCG0111A1ZF
            </td>
        </tr>
        </table>
        <asp:Label CssClass="w3-border-bottom w3-border-black" Width="100%" ID="ksjd" runat="server" Text=""/>
    </td>
</tr>
<tr>
    <td>
        <table width="100%" border="0">
        <tr>
            <td colspan="6"><center><label class="w3-large w3-center w3-xlarge w3-border w3-border-black"><b>&nbsp;&nbsp;BILL&nbsp;&nbsp;</b></label></center></td>
        </tr>
        <tr>
            <td class="heading" style="width:20%"><b>Receipt No -:</b></td>
            <td colspan="2" style="width:30%"><asp:TextBox BorderWidth="0" ReadOnly="true" ID="receiptNo" Width="100%" CssClass="details" runat="server"/></td>
            <td class="heading" style="width:20%" valign="top"><b>Date -:</b></td>
            <td colspan="2" style="width:30%"><asp:TextBox ID="dateOfEntry" Width="100%" runat="server" CssClass="w3-left details"/></td>
        </tr>
        <tr>
            <td class="w3-left heading"><b>Name -: </b></td>
            <td colspan="2"><asp:TextBox Width="100%" ID="lbllastname" CssClass="w3-left details" runat="server"/></td>
            <td class="w3-left heading"><b>Father/Husband-: </b></td>
            <td colspan="2"><asp:TextBox Width="100%" ID="lblfather_w_o" runat="server" CssClass="w3-left details"/></td>
        </tr>
        <tr>
            <td class="w3-left heading"><b>Age -: </b></td>
            <td class="details"><asp:TextBox Width="100%" ID="lblage" CssClass="w3-left details" placeholder="Example 5Yrs 8Mnth" runat="server"/></td>
            <td class="w3-left heading"><b>Gender-: </b></td>
            <td class="details"><asp:TextBox Width="100%" ID="lblgender" CssClass="w3-left" runat="server"/></td>
            <td class="w3-left heading"><b>Address-: </b></td>
            <td class="details"><asp:TextBox Width="100%" ID="lbladdress" runat="server" CssClass="w3-left"/></td>
        </tr>
        <tr>
            <td class="w3-left heading"><b>Mobile no-:  </b></td>
            <td class="details" colspan="2"><asp:TextBox Width="100%" ID="lblmobileNumber" CssClass="w3-left" runat="server"/>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="lblMobileNumber" runat="server" ErrorMessage="Only Numbers allowed" Font-Bold="true" ValidationExpression="\d+"></asp:RegularExpressionValidator>
            </td>
            <td class="w3-left heading" valign="top"><b>Reffered By-: </b></td>
            <td class="details" colspan="2"><asp:TextBox Width="100%" ID="lblrefFrom" CssClass="w3-left" runat="server"/></td>
        </tr>
        <tr>
            <td colspan="6" class="w3-center">
                <asp:Label ID="lbldetail" runat="server" CssClass="w3-large"><b>Details</b></asp:Label><br />
                <asp:Label ID="lblErr" runat="server" Text="" Font-Bold="true" ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="6">
                <div class="w3-row" id="takeTests" runat="server">
                    <asp:TextBox ID="txtTest" runat="server" CssClass="w3-col s5" placeholder="Enter Test Name"></asp:TextBox>
                    <div class="w3-col s1"><br /></div>
                    <asp:TextBox ID="txtAmount" runat="server" CssClass="w3-col s3" placeholder="Enter Amount Example 8500"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ControlToValidate="txtAmount" runat="server" ErrorMessage="Only Numbers allowed" Font-Bold="true" ValidationExpression="\d+"></asp:RegularExpressionValidator>
                    <div class="w3-col s1"><br /></div>
                    <asp:Button ID="btnAddTest" OnClick="addTest" CssClass="w3-col s2" runat="server" Text="Add" />
                </div>
                <div class="w3-center w3-centered">
                    <center><asp:GridView ID="GridView" CssClass="w3-center" Width="80%" runat="server" AutoGenerateColumns="False" 
                            DataSourceID="SqlDataSource1" CellPadding="4" ForeColor="#333333" 
                        GridLines="Both">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:BoundField DataField="testname" ControlStyle-Width="80%" HeaderText="Test Name" 
                                SortExpression="testname" >
                                <ControlStyle Width="80%"></ControlStyle>
                            </asp:BoundField>

                            <asp:BoundField DataField="amount" ControlStyle-Width="20%" HeaderText="Amount" 
                                SortExpression="amount" >
                                <ControlStyle Width="20%"></ControlStyle>
                            </asp:BoundField>

                        </Columns>
                        <EditRowStyle BackColor="#999999" />
                        <FooterStyle BackColor="#555555" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#555555" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#ffffff" ForeColor="#000000" />
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#E9E7E2" />
                        <SortedAscendingHeaderStyle BackColor="#506C8C" />
                        <SortedDescendingCellStyle BackColor="#FFFDF8" />
                        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                    </asp:GridView>

                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                            ConnectionString="<%$ ConnectionStrings:IODatabaseConnectionString %>" 
                            SelectCommand="SELECT [testname], [amount] FROM hospitals.xraypathTests WHERE ([xraypatient] = @xraypatient)">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="receiptNo" Name="xraypatient" 
                                    PropertyName="Text" Type="Int32" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                        </center>
                </div>
                <br /><br />
                <div class="w3-row">
                    <asp:Label ID="Label2" CssClass="w3-col s1" Font-Bold="true" runat="server" Text="Total"></asp:Label>
                    <asp:Label ID="lblTotal" CssClass="w3-col s2" Font-Bold="true" runat="server"><i class="fa fa-inr" ></i>0/-</asp:Label>
                    <asp:Label ID="Label4" CssClass="w3-col s2" Font-Bold="true" runat="server" Text="Amount in Words"></asp:Label>
                    <asp:Label ID="lblTotalInWords" CssClass="w3-col s7" Font-Bold="true" runat="server" Text="ZERO RUPEES ONLY"></asp:Label>
                </div>
            </td>
        </tr>
        </table>
        <asp:Label CssClass="w3-border-bottom w3-border-black" Width="100%" ID="Label1" runat="server" Text=""/>
    </td>
</tr>
<tr><td></td></tr>
<tr><td></td></tr>
</table>
<asp:Button ID="btnDone" runat="server" Text="Done" OnClick="doneEditing" />
<input type="button" runat="server" value="Print" id="printForm" onclick="printpage()" />
<asp:Button ID="btnEdit" runat="server" Text="Edit" OnClick="edit"/>
</div>
    
</form>
</body>
</html>