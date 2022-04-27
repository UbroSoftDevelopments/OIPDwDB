<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="generateID.aspx.cs" Inherits="OIPD.generateID" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="w3-row">
    <div class="w3-col s3">&nbsp;</div>
    <div class="w3-col s6 w3-center w3-padding w3-light-gray w3-card-4">
        <div class="w3-xlarge"><b>Staff Details</b></div>
        <div class="w3-circle w3-red" style="height:2px">&nbsp;</div>
        <br />
        <asp:Label ID="lblMsg" runat="server"></asp:Label>
        <div class="w3-row w3-padding-small">
            <div class="w3-col s2 w3-padding">Name</div>
            <div class="w3-col s4"><asp:TextBox ID="txtName" placeholder="Enter Name" runat="server" CssClass="w3-input"></asp:TextBox></div>
            <label class="w3-col s3 w3-padding">Post</label>
            <div class="w3-col s3"><asp:TextBox ID="txtDesignation" placeholder="Enter Post" runat="server" CssClass="w3-input"></asp:TextBox></div>
        </div>
        <div class="w3-row w3-padding-small">
            <div class="w3-col s3 w3-padding">Date of Birth</div>
            <div class="w3-col s3"><asp:TextBox ID="txtDob" TextMode="Date" placeholder="Select DOB" runat="server" CssClass="w3-input"></asp:TextBox></div>
            <label class="w3-col s3 w3-padding">Mobile Num</label>
            <div class="w3-col s3"><asp:TextBox ID="txtMobile" TextMode="Number" placeholder="Enter Mobile Number" runat="server" CssClass="w3-input"></asp:TextBox></div>
        </div>
        <div class="w3-row w3-padding-small">
            <div class="w3-col s2 w3-padding">Email</div>
            <div class="w3-col s4"><asp:TextBox ID="txtEmail" placeholder="Enter Email ID" runat="server" CssClass="w3-input"></asp:TextBox></div>
            <label class="w3-col s3 w3-padding">Blood Group</label>
            <div class="w3-col s3"><asp:TextBox ID="txtBloodGroup" placeholder="Enter Blood Group" runat="server" CssClass="w3-input"></asp:TextBox></div>
        </div>
        <div class="w3-row">
            <div class="w3-col s6">
                <center><img src="Resources/geetanjaliLogo.png" alt="pic" style="display:none" width="100px" height="125px" id="image" /></center>
                <asp:FileUpload ID="uploadPic" onChange="displayImage()" Accept=".jpg,.jpeg,.bmp,.png" runat="server" />
            </div>
            <div class="w3-col s6">
                <br /><br /><br />
                <asp:Button ID="submit" OnClick="addStaff" runat="server" Text="Click To Submit" CssClass="w3-button w3-teal glossButton" />
            </div>
        </div>
        <script>
            function displayImage() {
                var f = document.getElementById("ContentPlaceHolder1_uploadPic");
                var totalfiles = f.files;
                var numberoffiles = totalfiles.length;
                var div = document.getElementById("image");
                var imagearr = totalfiles[0];
                var src = URL.createObjectURL(imagearr);
                div.src = "" + src;
                div.style.display = 'block';
            }
        </script>
    </div>
    <div class="w3-col s3">&nbsp;</div>
</div>

<br />

<div class="w3-row">
    <div class="w3-col s1">&nbsp;</div>
    <div class="w3-col s10">
        <asp:GridView ID="grdStaff" runat="server" CssClass="w3-table-all" AutoGenerateColumns="False" 
            DataKeyNames="sno" DataSourceID="SqlDataSource1">
            <Columns>
                <asp:BoundField DataField="name" HeaderText="Name" SortExpression="name" />
                <asp:TemplateField HeaderText="Photo">
                    <ItemTemplate>
                        <center><img src='<%# Eval("photo") %>' alt="pic" width='50%' /></center>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="designation" HeaderText="Post" SortExpression="designation" />
                <asp:TemplateField HeaderText="DOB">
                    <ItemTemplate>
                        <label><%# IOPD.DataManager.DateUtilities.onlyDateFormat(Eval("dob")) %></label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="mobile_number" HeaderText="Mobile Number" SortExpression="mobile_number" />
                <asp:BoundField DataField="emailid" HeaderText="Email Id" SortExpression="emailid" />
                <asp:BoundField DataField="bloodgroup" HeaderText="Blood Group" SortExpression="bloodgroup" />
                <asp:TemplateField HeaderText="Print ID">
                    <ItemTemplate>
                        <a href='printIDportrait.aspx?sno=<%# Eval("sno") %>' target="_blank" class='w3-button w3-green glossButton w3-round-large'>Print ID</a>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:IODatabaseConnectionString %>"  SelectCommand="SELECT * FROM hospitals.staff ORDER BY sno desc">
        </asp:SqlDataSource>
    </div>
    <div class="w3-col s1">&nbsp;</div>
</div>

<br />
</asp:Content>
