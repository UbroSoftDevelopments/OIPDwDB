<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="OIPD.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <div class="w3-row w3-mobile">
        <div class="w3-col s4 w3-mobile"><br /></div>
        <div class="w3-col s4 w3-mobile w3-center w3-pale-green w3-card-4 w3-padding w3-round"><br />
            <asp:Label ID="lblHeading" runat="server" CssClass="w3-card w3-blue-gray w3-center w3-xxlarge" Width="100%"><b>Log In Here</b></asp:Label>
            <asp:Label ID="lblError" runat="server"/><br />
            <label class="w3-xlarge w3-margin-left"><b>User Name</b></label>
            <asp:TextBox CssClass="w3-input w3-center w3-padding w3-card w3-margin-bottom" ID="txtUserName" runat="server" placeholder="Enter User Name" TextMode="SingleLine" />
            <label class="w3-xlarge"><b>Password</b></label>
            <asp:TextBox CssClass="w3-input w3-padding w3-center w3-card w3-margin-bottom" ID="txtPassword" runat="server" placeholder="Enter Password" TextMode="Password" />
            <asp:Button runat="server" ID="btnLogIn" Font-Bold="true" CssClass="w3-hover-white w3-round-xxlarge w3-button w3-card w3-blue-gray w3-text-white w3-xlarge" Text="LOG IN" onclick="btnLogIn_Click"/>
        </div>
        <div class="w3-col s4 w3-mobile"></div>
    </div>
</asp:Content>
