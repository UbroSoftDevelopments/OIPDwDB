<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="OIPD.ChangePassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
<div class="w3-row">

<div class="w3-col s3" ><br /></div>
<div class="w3-col s6 w3-card-4 w3-border w3-border-amber w3-padding w3-center">

<asp:Label ID="lblUserDetails" runat="server" Width="100%" CssClass="w3-xxlarge w3-purple w3-text-aqua"><b>New User Details</b></asp:Label><br />
<asp:Label ID="lblErrors" runat="server" Text="" /><br />
<div>
<asp:Label ID="lblUserName" runat="server" CssClass="w3-col s5 w3-left w3-input w3-border-0"><b>User Name -: </b></asp:Label>
<p class="w3-col s1"></p>
<asp:Label ID="lblUser" runat="server" CssClass="w3-input w3-sand w3-card w3-col s6"/><br /><br />

<asp:Label ID="lblUserPassword" runat="server" CssClass="w3-col s5 w3-left w3-input w3-border-0"><b>Current Password -: </b></asp:Label>
<p class="w3-col s1"></p>
<asp:TextBox TextMode="password" ID="txtCrrPassword" runat="server" CssClass="w3-input w3-sand w3-card w3-col s6" placeholder="Enter Current Password"/>
<br /><br />

<asp:Label ID="Label1" runat="server" CssClass="w3-col s5 w3-left w3-input w3-border-0"><b>New Password -: </b></asp:Label>
<p class="w3-col s1"></p>
<asp:TextBox TextMode="password" ID="txtNewPassword" runat="server" CssClass="w3-input w3-sand w3-card w3-col s6" placeholder="Enter New Password"/>
<br /><br />

<asp:Label ID="lblRetypePassword" runat="server" CssClass="w3-col s5 w3-left w3-input w3-border-0"><b>Re-enter Password -: </b></asp:Label>
<p class="w3-col s1"></p>
<asp:TextBox ID="txtRetypePassword" runat="server" TextMode="Password" CssClass="w3-input w3-sand w3-card w3-col s6" placeholder="Re-type New password" />
</div>
<br /><br /><br />
<asp:Button ID="btnregister" CssClass=" w3-round-xxlarge w3-btn w3-purple"  runat="server" Text="Change Password" OnClick="changePass" />
</div>

</div>
<br />
</asp:Content>
