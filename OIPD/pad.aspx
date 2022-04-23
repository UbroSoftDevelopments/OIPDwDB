<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pad.aspx.cs" Inherits="OIPD.pad" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Print</title>
    <link rel="Stylesheet" href="https://www.w3schools.com/w3css/4/w3.css" />
    <link rel="stylesheet" type="text/css" href="http://cdn.webrupee.com/font"/>
    <link rel="stylesheet" href="//maxcdn.bootstrapcdn.com/font-awesome/4.3.0/css/font-awesome.min.css"/>

    <script type="text/javascript">
        function printpage() {
            var printButton = document.getElementById("printForm");
            document.getElementById("tAreaPres").style.borderWidth = 0;
            printButton.style.visibility = 'hidden';
            window.print()
            printButton.style.visibility = 'visible';
            document.getElementById("tAreaPres").style.borderWidth = "1px";
        }
    </script>
    <style type="text/css">
        .floating_label 
        {
            position:absolute;
            z-index:200;
            top:250px;
            left:350px;
            font-size:25px;
            font-weight:bold;
            font-family:'Helvetica Neue', 'Helvetica', Helvetica, Arial, sans-serif;
            font-style:italic
        }
    .invoice-box {
        max-width: 800px;
        margin: auto;
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
    <table border="0" style="background-image:url('Resources/padNew.jpg'); height:1132px; width:800px; padding:0px; border-spacing:0px" class="invoice-box" cellpadding="0" cellspacing="0">
        <tr>
            <td style="height:175px">
             &nbsp;
            </td>
        </tr>
        <tr>
            <td style="height:1px">
                <table border="0" cellspacing="0" cellpadding="0" style="padding:0px; height:10px" width="100%">
                    <tr style="padding:0px">
                        <td>
                            <div class="w3-left"><asp:Label ID="lblDocName" CssClass="" Font-Italic="true" runat="server" Width="100%" style="padding:0px; font-size:20px;"></asp:Label></div>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="height:1px">
                <table border="0" cellpadding="0" style="padding:0px; font-size:17px; height:10px; margin-top:3px" cellspacing="0" width="100%">
                    <tr style="padding:0px">
                        <td style="padding:0px; width:41%">&nbsp</td>
                        <td style="padding:0px; width:59%;">
                            <div class="w3-left"><asp:Label ID="txtName" Width="100%" style="background:rgba(0,0,0,0); padding:0px;" runat="server"></asp:Label></div>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="height:1px">
                <table border="0" cellpadding="0" style="padding:0px; font-size:17px; height:10px; margin-top:12px" cellspacing="0" width="100%">
                    <tr style="padding:0px">
                        <td style="padding:0px; width:33%">&nbsp</td>
                        <td style="padding:0px; width:20%;">
                            <div class="w3-left" style="margin-top:-6px"><asp:Label ID="lblAge" Width="100%" style="background:rgba(0,0,0,0); padding:0px;" runat="server"></asp:Label></div>
                        </td>
                        <td style="padding:0px; width:6%">&nbsp</td>
                        <td style="padding:0px; width:15%;">
                            <div class="w3-left" style="margin-top:-6px"><asp:Label ID="lblSex" Width="100%" style="background:rgba(0,0,0,0); padding:0px;" runat="server"></asp:Label></div>
                        </td>
                        <td style="padding:0px; width:11%">&nbsp</td>
                        <td style="padding:0px; width:15%;">
                            <div class="w3-left" style="margin-top:-6px"><asp:Label ID="lblDt" Width="100%" style="background:rgba(0,0,0,0); padding:0px;" runat="server"></asp:Label></div>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="height:1px">
                <table border="0" cellpadding="0" style="padding:0px; font-size:17px; height:10px; margin-top:10px;" cellspacing="0" width="100%">
                    <tr style="padding:0px">
                        <td style="padding:0px; width:37%">&nbsp</td>
                        <td style="padding:0px; width:63%;">
                            <div class="w3-left" style="margin-top:-10px"><asp:Label ID="lblAddress" Width="100%" style="background:rgba(0,0,0,0); padding:0px;" runat="server"></asp:Label></div>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <table border="0" cellpadding="0" cellspacing="0" style="padding:0px; height:775px; margin-top:10px; background:rgba(150,150,150,0)" width="100% ">
                    <tr>
                        <td width="33%"></td>
                        <td>
                            <textarea id="tAreaPres" class="" style="width:100%; height:630px; background:rgba(0,0,0,0)"></textarea>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    
    <input type="button" value="Print" id="printForm" onclick="printpage()" />
    </div>
    </form>
</body>
</html>

