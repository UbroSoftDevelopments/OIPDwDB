<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="prescription.aspx.cs" Inherits="OIPD.prescription" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Print</title>
    <link rel="Stylesheet" href="https://www.w3schools.com/w3css/4/w3.css" />
    <link rel="stylesheet" type="text/css" href="http://cdn.webrupee.com/font"/>
    <link rel="stylesheet" href="//maxcdn.bootstrapcdn.com/font-awesome/4.3.0/css/font-awesome.min.css"/>
    <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css"/>
    <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script  src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>

    <script type="text/javascript">
        function printpage() {
            var printButton = document.getElementById("printForm");
            document.getElementById("txtPresType").style.borderWidth = 0;
            document.getElementById("txtPresData").style.borderWidth = 0;
            document.getElementById("txtName").style.borderWidth = 0;
            document.getElementById("txtAge").style.borderWidth = 0;
            document.getElementById("txtDate").style.borderWidth = 0;
            document.getElementById("txtAddress").style.borderWidth = 0;
            document.getElementById("div").style.left = "230px";
            printButton.style.visibility = 'hidden';
            window.print()
            printButton.style.visibility = 'visible';
            document.getElementById("txtPresType").style.borderWidth = "1px";
            document.getElementById("txtPresData").style.borderWidth = "1px";
            document.getElementById("txtName").style.borderWidth = "1px";
            document.getElementById("txtAge").style.borderWidth = "1px";
            document.getElementById("txtDate").style.borderWidth = "1px";
            document.getElementById("txtAddress").style.borderWidth = "1px";
            document.getElementById("div").style.left = "425px";
        }
    </script>
    <style>
        .floating_div
        {
            position:absolute;
            z-index:200;
            top:280px;
            left:420px;
        }
        .floating_name
        {
            font-size:18px;
            margin-left:115px;
            width:520px;
            font-family:'Helvetica Neue', 'Helvetica', Helvetica, Arial, sans-serif;
            background:rgba(0,0,0,0);
            line-height:1.4;
            border-style:solid;
            border-width:1px;
        }
        .floating_age
        {
            font-size:18px;
            margin-left:67px;
            font-family:'Helvetica Neue', 'Helvetica', Helvetica, Arial, sans-serif;
            background:rgba(0,0,0,0);
            border-style:solid;
            line-height:1.6;
            border-width:1px;
        }
        .floating_date
        {
            font-size:18px;
            margin-left:215px;
            width:128px;
            font-family:'Helvetica Neue', 'Helvetica', Helvetica, Arial, sans-serif;
            background:rgba(0,0,0,0);
            border-style:solid;
            line-height:1.6;
            border-width:1px;
        }
        .floating_address
        {
            font-size:18px;
            margin-left:70px;
            width:568px;
            font-family:'Helvetica Neue', 'Helvetica', Helvetica, Arial, sans-serif;
            background:rgba(0,0,0,0);
            border-style:solid;
            line-height:0.5;
            border-width:1px;
        }
        .floating_label 
        {
            margin-left:80px;
            width:600px;
            
            font-size:20px;
            font-weight:bold;
            font-family:'Helvetica Neue', 'Helvetica', Helvetica, Arial, sans-serif;
            background:rgba(0,0,0,0);
            border-style:solid;
            border-width:1px;
        }
        .floating_label_data
        {
            width:670px;
            background:rgba(0,0,0,0);
            height:650px;
            font-size:20px;
            font-family:'Helvetica Neue', 'Helvetica', Helvetica, Arial, sans-serif;
            border-width:1px;
        }
    .invoice-box {
        max-width: 800px;
        margin: auto;
        border: 1px solid #eee;
        box-shadow: 0 0 10px rgba(0, 0, 0, .15);
        font-size: 15px;
        line-height: 24px;
        font-family: 'Helvetica Neue', 'Helvetica', Helvetica, Arial, sans-serif;
        color: #333;
    }
    
    .invoice-box table {
        width: 100%;
        line-height: inherit;
        text-align: left;
    }
    
    .invoice-box table td {
        padding: 5px;
        vertical-align: top;
    }
    
    .invoice-box table tr td:nth-child(2) {
        text-align: right;
    }
    
    .invoice-box table tr.top table td {
        padding-bottom: 20px;
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
<body>
    <form id="form1" runat="server">
    <div class="w3-center">
    <table class="invoice-box" cellpadding="0" cellspacing="0">
        <tr>
            <td>
            <img src="Resources/pad.png" alt="pad" />
            
            </td>
        </tr> 
    </table>
    <div class="floating_div" id="div">
        <asp:TextBox ID="txtName" runat="server" placeholder="Patient Name" CssClass="floating_name"></asp:TextBox><br />
        <asp:TextBox ID="txtAge" runat="server" placeholder="Patient Age" CssClass="floating_age"></asp:TextBox>
        <asp:TextBox ID="txtDate" runat="server" placeholder="Date" CssClass="floating_date"></asp:TextBox><br />
        <asp:TextBox ID="txtAddress" runat="server" placeholder="Patient Address" CssClass="floating_address"></asp:TextBox><br /><br /><br />
        <asp:TextBox ID="txtPresType" placeholder="Enter Prescription Type" CssClass="floating_label" runat="server" ></asp:TextBox><br style="line-height:0.5" /><br style="line-height:0.5" />
        <textarea id="txtPresData" runat="server" class="floating_label_data" placeholder="Enter Prescription"></textarea>
    </div>
    <center><input type="button" value="Print" id="printForm" onclick="printpage()" /></center>
    </div>
    </form>
    <script type="text/javascript">
        $(function () {
            $(function () {
                var currentYear = (new Date).getFullYear();
                var currentMonth = (new Date).getMonth() + 1;
                var currentDay = (new Date).getDate();
                $("#txtDate").datepicker({
                    minDate: new Date((currentYear - 1), 12, 1),
                    dateFormat: 'dd/mm/yy',
                    maxDate: new Date(currentYear, 11, 31)
                });
            });
        });
    </script>
</body>
</html>

