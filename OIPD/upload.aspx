<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="upload.aspx.cs" Inherits="OIPD.upload" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
<div class="w3-row">
    <div class="w3-col s3">&nbsp;</div>
    <div class="w3-col s6 w3-center w3-padding w3-card-2">
        <div class="w3-padding-large w3-purple w3-xlarge w3-card-2">
            <b>Upload Documents</b><br />
            <asp:Label ID="lblErr" runat="server" CssClass="" Text=""></asp:Label>
        </div>
        <div class="w3-left-align w3-padding-large">
            <div class="w3-row">
                <asp:Label ID="lblpIpNumber" runat="server" CssClass="w3-large w3-col s6" Text="IP Number :- GLC/2019/12/04/01"></asp:Label>
                <asp:Label ID="lblpName" runat="server" CssClass="w3-large w3-col s6" Text="Patient Name :- Farhan Talib"></asp:Label>
            </div>
            <br />
            <div class="w3-row">
                <asp:Label ID="lblpAge" runat="server" CssClass="w3-large w3-col s6" Text="Patient Age :- 26Y 0M 0D"></asp:Label>
                <asp:Label ID="lblpAddress" runat="server" CssClass="w3-large w3-col s6" Text="Patient Address :- Address Here"></asp:Label>
            </div>
        </div>
        <br />
        <center>
            <asp:CheckBox ID="chkProfile" runat="server" CssClass="w3-large" Text="&nbsp;Patient Photo" AutoPostBack="true" OnCheckedChanged="changedEvent" /><br />
            <asp:Label ID="lblDocName" runat="server" CssClass="w3-large" Text="Document Name:-"></asp:Label>
            <asp:TextBox ID="txtDocName" runat="server" CssClass="w3-round w3-card-2 w3-padding-small" style="border-width:1px" placeholder="Enter Document Name"></asp:TextBox>
        </center>
        <br />
        <asp:FileUpload ID="files" accept=".jpg,.jpeg,.png,.bmp,.gif" onChange="displayImage()" runat="server" />
        <br /><br />
        <div class="w3-row">
            <div class="w3-col s3">&nbsp;</div>
            <div class="w3-col s6"><img src="" style="display:none" id="image" alt="img" width="100%" /></div>
            <div class="w3-col s3">&nbsp;</div>
        </div>
        <br />
        <asp:Button ID="btnUpload" runat="server" 
            CssClass="w3-round-large w3-button w3-card-4 w3-large w3-amber" Text="Upload" 
            onclick="btnUpload_Click" />
    </div>
    <div class="w3-col s3">&nbsp;</div>
</div>
<script type="text/javascript">
    function displayImage() {
        var f = document.getElementById("ContentPlaceHolder1_files");
        var totalfiles = f.files;
        var numberoffiles = totalfiles.length;
        var div = document.getElementById("image");
        var imagearr = totalfiles[0];
        var src = URL.createObjectURL(imagearr);
        div.src = "" + src;
        div.style.display = 'block';
    }
</script>
</asp:Content>
