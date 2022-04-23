<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PrintPad.aspx.cs" Inherits="OIPD.PrintPad" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
<div class="w3-row">
<div class="w3-col s3"><br /></div>
<div class="w3-col s6 w3-center w3-pale-blue w3-padding">

<div class="w3-teal w3-text-white">
<asp:Label ID="docs" runat="server" Text="Print Pad"></asp:Label>
<asp:Label ID="lblerr" runat="server" ></asp:Label>
</div>
<br />
<asp:Label CssClass="w3-col s3" ID="lblDocName" runat="server" Text="Doctor's Name"></asp:Label>
<asp:TextBox placeholder="Enter Doctor's name here" ID="txtdoc" CssClass="w3-input w3-sand w3-col s9" runat="server"></asp:TextBox><br /><br />
<asp:Button ID="btndone" runat="server" Text="Done" OnClick="assign" /><br />
<asp:HyperLink ID="hypPrint" runat="server" Target="_blank" Text="Print Pad" Visible="false"></asp:HyperLink>
</div>
</div>
<br />
</asp:Content>
