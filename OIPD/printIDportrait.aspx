<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="printIDportrait.aspx.cs" Inherits="OIPD.printIDportrait" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link rel="Stylesheet" href="css/w3.css" />
    <!--style>
        /*@media print
        {
            @page
            {
                size:3.375in 2.175in;
            }
        }*/
    </style-->
    <style type="text/css">
    .invoice-box {
        /*width: 3.375in;
        height:2.175in;*/
        width:2.375in;
        height:3.575in;
        border: 1px solid #eee;
        margin-left:50px;
        margin-top:50px;
        padding:0px;
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
        padding: 0px;
        vertical-align: top;
    }
    
    .invoice-box table tr td:nth-child(2) {
        text-align: left;
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
    <script type="text/javascript">
        function printpage() {
            var printButton = document.getElementById("printForm");
            printButton.style.visibility = 'hidden';
            window.print()
            printButton.style.visibility = 'visible';
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="invoice-box w3-border w3-border-red" style="padding:0px">
        <table cellpadding="0" cellspacing="0">
            <tr class="top">
                <td>
                    <table width="100%" style="background:linear-gradient(to bottom, #ffffCC 0%, #ffED98 100%); border-bottom-style:solid; border-bottom-color:Black; border-bottom-width:1px">
                        <tr>
                            <td width="100%">
                                <div>
                                    <center>
                                        <div class="w3-row" style='margin-bottom:-4px'>
                                             <div class="w3-col s3 w3-center">
                                                <img src="Resources/geetanjaliLogo.png" style="" alt="hospital_logo" width="55%" />
                                            </div>
                                            <div class="w3-col s9">
                                                <div style="font-size:0.58em; margin-bottom:-10px;">ISO : 9001:2015 CERTIFIED</div>
                                                <div style="font-size:0.58em; margin-bottom:-8px; margin-top:-10px">Reged No. : CMO/HOP/21/MZP</div>
                                            </div>
                                        </div>
                                        <div style="font-size:1em; color:#CC4400; margin-bottom:-3px;" class="w3-center title"><b>Geetanjali Life Care & Surgical</b></div>
                                        <div style="font-size:0.9em; color:#CC4400; margin-bottom:-7px;" class="w3-center title"><b>Pvt. Ltd. | Trauma & Critical Care</b></div>
                                        <div style="font-size:0.540em; margin-bottom:-15px;" class="w3-center"><b>Mirzapur - Varanasi Road, Milkipur | Uttar Pradesh 231305</b></div>
                                    </center>
                                </div>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td style="border-bottom-style:solid; border-bottom-color:Black; border-bottom-width:1px; padding:0px; background-color:#FFF5CD">
                    <table width="100%" cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                <table style="font-size:0.8em;" cellpadding="0" cellspacing="0" border="0" width="100%">
                                    <tr>
                                        <td colspan="2">
                                            <center>
                                                <img class="w3-round-large" src="~/IDPic/FarhanTalib/IMG_20160722_180922_1.jpg" style="width:39.8%; border-style:solid; border-width:1px;" alt="pic" id="staffPhoto" runat="server" /><br />
                                                <b>Blood Group :</b> <asp:Label ID="lblBloodGroup" CssClass="w3-text-red" Font-Bold="true" runat="server" Text=""></asp:Label>
                                            </center>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td ><b style="margin-bottom:-20px">Name:</b></td>
                                        <td style="text-align:left; white-space:nowrap">
                                            <asp:Label style="margin-bottom:-20px" Font-Bold="true" ID="lblName" runat="server" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="30%"><b>Email:</b></td>
                                        <td width="70%" style="text-align:left">
                                            <asp:Label ID="lblEmail" runat="server" Text=""></asp:Label>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td colspan="2" style="padding:0">
                                            <table width="100%" cellpadding="0" cellspacing="0" style="table-layout:fixed">
                                                <tr>
                                                    <td width="60%">
                                                        <table width="100%" cellpadding="0" cellspacing="0" style="table-layout:fixed">
                                                            <tr>
                                                                <td width="35%"><b>Desig.:</b></td>
                                                                <td width="65%" style="text-align:left; white-space:nowrap">
                                                                    <asp:Label ID="lblDesign" runat="server" Text=""></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td width="35%" class=""><b>DOB:</b></td>
                                                                <td width="65%" style="text-align:left; white-space:nowrap">
                                                                    <asp:Label ID="lblDob" runat="server" Text=""></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td width="35%"><b>Mob.:</b></td>
                                                                <td width="65%" style="text-align:left; white-space:nowrap">
                                                                    <asp:Label ID="lblMobile" runat="server" Text=""></asp:Label>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td width="40%" class="" style="text-align:center">
                                                        <center>
                                                            <br style="line-height:1" />
                                                            <img width="55%" src="Resources/signature2.png" alt='signature' /><br />
                                                            <b>Signature</b>
                                                        </center>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>

                                    
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td style="background-color:Red">
                    <center><label style="font-size:0.61em; margin-top:-10px" class="w3-center w3-text-white"><b>+91 9839980333 | geetanjalihospitalvns@gmail.com</b></label></center>
                </td>
            </tr>
        </table>
    </div>
    <center><input type="button" value="Print" id="printForm" onclick="printpage()" /></center>
    </form>
</body>
</html>

