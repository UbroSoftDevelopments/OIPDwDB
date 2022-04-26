<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="printReceipt.aspx.cs" Inherits="OIPD.printReceipt" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Print</title>
    <link rel="Stylesheet" href="https://www.w3schools.com/w3css/4/w3.css" />
    <link rel="stylesheet" type="text/css" href="http://cdn.webrupee.com/font"/>
    <link rel="stylesheet" href="//maxcdn.bootstrapcdn.com/font-awesome/4.3.0/css/font-awesome.min.css"/>

    <script type="text/javascript">
        function printpage() {
            var printButton = document.getElementById("printForm");
            printButton.style.visibility = 'hidden';
            window.print()
            printButton.style.visibility = 'visible';
        }
    </script>
    <style>
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
            <td colspan="6"><center><label class="w3-large w3-center w3-xlarge w3-border w3-border-black"><b>&nbsp;&nbsp;OPD FORM&nbsp;&nbsp;</b></label></center></td>
        </tr>
        <tr>
            <td class="w3-left heading"><b>Patient No -:</b></td>
            <td><asp:label ID="regNumber" CssClass="w3-left details" runat="server"/></td>
            <td class="w3-left heading"><b>Receipt No -:</b></td>
            <td><asp:label ID="receiptNo" CssClass="w3-left details" runat="server"/></td>
            <td class="w3-left heading"><b>Date -:</b></td>
            <td><asp:label ID="dateOfEntry" runat="server" CssClass="w3-left details"/></td>
        </tr>
        <tr>
            <td class="w3-left heading"><b>First Name -: </b></td>
            <td><asp:label ID="lblfirstname" CssClass="w3-left details" runat="server"/></td>
            <td class="w3-left heading"><b>Last Name-: </b></td>
            <td><asp:label ID="lbllastname" CssClass="w3-left details" runat="server"/></td>
            <td class="w3-left heading"><b>Father/Husband-: </b></td>
            <td><asp:label ID="lblfather_w_o" runat="server" CssClass="w3-left details"/></td>
        </tr>
        <tr>
            <td class="w3-left heading"><b>Age -: </b></td>
            <td class="details"><asp:label ID="lblage" CssClass="w3-left details" runat="server"/></td>
            <td class="w3-left heading"><b>Gender -: </b></td>
            <td class="details"><asp:label ID="lblgender" CssClass="w3-left" runat="server"/></td>
            <td class="w3-left heading"><b>Address -: </b></td>
            <td class="details"><asp:label ID="lbladdress" runat="server" CssClass="w3-left"/></td>
        </tr>
        <tr>
            <td class="w3-left heading"><b>Mobile no -: </b></td>
            <td class="details"><asp:label ID="lblmobileNumber" CssClass="w3-left" runat="server"/></td>
            <td></td><td></td>
            <td class="w3-left heading"><b>Reffered By -: </b></td>
            <td class="details"><asp:label ID="lblrefFrom" CssClass="w3-left" runat="server"/></td>
        </tr>
        <tr>
            <td class="w3-left heading" ><b>Department-: </b></td>
            <td colspan="3" class="details"><asp:label ID="lbldepartment" CssClass="w3-left" runat="server"/></td>
            <td class="w3-left heading"><asp:Label ID="lblreferer" runat="server"></asp:Label></td>
            <td class="details"><asp:Label ID="lblrefnumber" CssClass="w3-left" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td><b>Amount -: </b></td>
            <td><asp:label ID="lblamount" CssClass="w3-left" runat="server"><i class="fa fa-inr"/></asp:label></td>
            <td colspan="2"><b>Amount In Words -: </b></td>
            <td colspan="2"><asp:label ID="lblamtInWords" CssClass="w3-left" runat="server"></asp:label></td>
        </tr>
        </table>
        <asp:Label CssClass="w3-border-bottom w3-border-black" Width="100%" ID="Label1" runat="server" Text=""/>
    </td>
</tr>
<tr><td></td></tr>
<tr><td></td></tr>
</table>
<input type="button" value="Print" id="printForm" onclick="printpage()" />
</div>
    </form>
</body>
</html>
