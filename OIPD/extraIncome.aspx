<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="extraIncome.aspx.cs" Inherits="OIPD.extraIncome" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="w3-row">
    <div class="w3-col s3">&nbsp;</div>
    <div class="w3-col s6 w3-card-4 w3-round-large w3-padding">
        <div class="w3-round-large w3-border w3-padding w3-border-green">
            <div class="w3-xlarge w3-padding w3-teal w3-center">
                <b>Additional Income</b>
                <asp:Label ID="lblMsg" runat="server"></asp:Label>
            </div>
            <br />
            <div class="w3-center">
                <div class="w3-row">
                    <div class="w3-col s6 w3-padding">
                        <asp:Label ID="Label1" runat="server" Text="Select Date :" CssClass="w3-padding-small" Font-Bold="true"></asp:Label><br />
                        <asp:TextBox ID="txtDate" runat="server" TextMode="Date" placeholder="Select Date" CssClass="w3-input"></asp:TextBox>
                    </div>
                    <div class="w3-col s6 w3-padding">
                        <asp:Label ID="Label2" runat="server" Text="Enter Amount :" CssClass="w3-padding-small" Font-Bold="true"></asp:Label><br />
                        <asp:TextBox ID="txtAmount" runat="server" TextMode="Number" placeholder="Enter Amount" CssClass="w3-input"></asp:TextBox>
                    </div>
                </div>
                <div class="w3-padding">
                    <asp:Label ID="lbl1" runat="server" Text="Enter Particulars :" CssClass="w3-padding-small" Font-Bold="true"></asp:Label><br />
                    <asp:TextBox ID="txtParticulars" runat="server" TextMode="MultiLine" placeholder="Enter Particulars" CssClass="w3-input"></asp:TextBox>
                </div>
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" 
                    CssClass="w3-purple w3-button w3-round-medium glossButton" onclick="btnSubmit_Click" />
            </div>
        </div>
    </div>
    <div class="w3-col s3">&nbsp;</div>
</div>
<br />
</asp:Content>
