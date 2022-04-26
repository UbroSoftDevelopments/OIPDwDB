<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ipdform.aspx.cs" Inherits="OIPD.ipdform" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
<div class="w3-card-4 w3-margin-left w3-margin-right w3-centered w3-border w3-border-teal w3-padding w3-margin-bottom">
    <center>
        <div class="w3-container w3-light-blue">
        <h2 class="w3-xlarge w3-text-teal"><b>IPD FORM</b></h2>
    </div>
        <asp:Label ID="lblMessage" CssClass="w3-text-red w3-xlarge" runat="server" Text=""></asp:Label>
        <div class="w3-mobile">
        <br />
        <asp:GridView ID="grdPatientDetails" runat="server" AutoGenerateColumns="False" CellPadding="0" DataKeyNames="patientno" DataSourceID="SqlDataSource1" ForeColor="#333333" CssClass="w3-table-all w3-mobile">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:TemplateField HeaderText="Patient No">
                <ItemTemplate>
                    <%# IOPD.DataManager.RegistrationUtilities.GetRegistrationNo(Convert.ToInt32(Eval("patientno"))) %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="firstname" HeaderText="First Name" SortExpression="firstname" />
            <asp:BoundField DataField="lastname" HeaderText="Last Name" SortExpression="lastname" />
            <asp:TemplateField HeaderText="Department">
                <ItemTemplate>
                    <%# IOPD.DataManager.DepartmentValidation.GetDepartmentNameByDepartmentNo(Eval("departmentno"))%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Date of Entry">
                <ItemTemplate>
                    <%# IOPD.DataManager.DateUtilities.dateFormat(Eval("dateofentry"))%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="ageyears" HeaderText="Years" SortExpression="ageyears" />
            <asp:BoundField DataField="agemonths" HeaderText="Months" SortExpression="agemonths" />
            <asp:BoundField DataField="address" HeaderText="Address" SortExpression="address" />
            <asp:BoundField DataField="fathername" HeaderText="Father/Husband" SortExpression="fathername" />
            <asp:BoundField DataField="mobileno" HeaderText="Mobile No" SortExpression="mobileno" />
            
        </Columns>
        <EditRowStyle BackColor="#999999" />
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#E9E7E2" />
        <SortedAscendingHeaderStyle BackColor="#506C8C" />
        <SortedDescendingCellStyle BackColor="#FFFDF8" />
        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:IODatabaseConnectionString %>" 
        SelectCommand="SELECT * FROM hospitals.opdform WHERE ([patientno] = @patientno)">
        <SelectParameters>
            <asp:QueryStringParameter Name="patientno" QueryStringField="patientno" 
                Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
    </div>
        <br />
        <center>
            <asp:HyperLink ID="gotoChangeDepart" runat="server" Target="_blank">
                <div class="w3-btn w3-purple w3-large w3-padding-large w3-round-large"><b>Change Department</b></div>
            </asp:HyperLink>
        </center>
        <br />
        <div class="w3-padding w3-border w3-round-medium w3-border-blue">
            <asp:Label ID="lblpType" Width="100%" CssClass="w3-blue w3-padding w3-large w3-round-medium" runat="server"><b>Patient To Be Charged As</b></asp:Label>
            <br /><br />
            <asp:RadioButtonList ID="rdoPatientType" runat="server" RepeatDirection="Horizontal" RepeatLayout="Table" CssClass="w3-center" Width="100%">
                <asp:ListItem Selected="True" Text="&nbsp;Normal" Value="1"  onClick="hideDiv()"></asp:ListItem>
                <asp:ListItem Text="&nbsp;Daily Package" Value="2" onClick="showDiv()"></asp:ListItem>
                <asp:ListItem Text="&nbsp;One Time Package" Value="3" onClick="showDiv()"></asp:ListItem>
            </asp:RadioButtonList>
            <br />
            <div runat="server" id="pkgAmtDiv" class="w3-row w3-hide">
                <asp:Label CssClass="w3-col s3 w3-text w3-padding" ID="Label1" runat="server" Text="Enter Package Amount -: " />
                <asp:TextBox CssClass="w3-input w3-sand w3-col s3" TextMode="Number" ID="txtPackageAmount" Text="0" runat="server" placeholder="Package Amount" />
                <div class="w3-col s6">&nbsp;</div>
            </div>
        </div>
        <br />
        <div class="w3-row">
            <asp:Label CssClass="w3-col s2 w3-text w3-padding" ID="lblReason" runat="server" Text="Complaint -: " />
            <asp:TextBox CssClass="w3-input w3-sand w3-col s2" ID="txtReason" runat="server" placeholder="Enter reason of admit" />
            <asp:Label CssClass="w3-col s2 w3-text w3-padding" ID="lblDoctorIncharge" runat="server" Text="Doctor Incharge -: " />
            <asp:DropDownList ID="drpdwnDoctors" CssClass="w3-left w3-sand w3-input w3-col s2" runat="server" />
            <asp:Label CssClass="w3-col s2 w3-text w3-padding" ID="lblDate" runat="server" Text="Date of Admit -: " />
            <asp:TextBox autocomplete="off" CssClass="w3-input w3-sand w3-col s2" ID="txtDate" runat="server" placeholder="Date of admit" />
        </div>
        <br />
        <div class="w3-row">
            <asp:Label CssClass="w3-col s2 w3-text w3-padding" ID="lblWard" runat="server" Text="Ward Name -: " />
            <asp:DropDownList CssClass="w3-input w3-sand w3-col s2" ID="drpdwnWard" runat="server" onselectedindexchanged="drpdwnWard_SelectedIndexChanged" AutoPostBack="true" />
            <asp:Label CssClass="w3-col s2 w3-text w3-padding" ID="lblRoom" runat="server" Text="Room -: " />
            <asp:DropDownList CssClass="w3-input w3-sand w3-col s2" ID="drpdwnRoom" runat="server" onselectedindexchanged="drpdwnRoom_SelectedIndexChanged" AutoPostBack="true"/>
            <asp:Label CssClass="w3-col s2 w3-text w3-padding" ID="lblBed" runat="server" Text="Bed No. -: " />
            <asp:DropDownList CssClass="w3-input w3-sand w3-col s2" ID="drpdwnBed" runat="server" />
        </div>
        <br />
        <div class="w3-row">
            <div class="w3-col s4"><asp:Button ID="bttnadmit" class="w3-center w3-xlarge w3-card-2 w3-round-xxlarge w3-btn w3-teal" runat="server" Text="Admit" onclick="bttnadmit_Click"/></div>
            <div class="w3-col s4" id="divPrint" runat="server" visible="">&nbsp;<asp:HyperLink Visible="false" ID="bttnPrint" Target="_blank" class="w3-center w3-xlarge w3-card-2 w3-round-xxlarge w3-btn w3-teal" runat="server" Text="Print"/></div>
            <div class="w3-col s4"><asp:Button ID="bttnreset" class="w3-center w3-xlarge w3-card-2 w3-round-xxlarge w3-btn w3-teal" runat="server" Text="Back" onclick="goBack"/></div>
        </div>
        <br />
    </center>
</div>
<script type="text/javascript">
    $(function () {
        $(function () {
            var currentYear = (new Date).getFullYear();
            var currentMonth = (new Date).getMonth() + 1;
            var currentDay = (new Date).getDate();
            $("#datepicker").datepicker({ minDate: new Date((currentYear - 1), 12, 1), dateFormat: 'dd/mm/yy', maxDate: new Date(currentYear, 11, 31) });

            $("#ContentPlaceHolder1_txtDate").datepicker({

                changeMonth: true,
                changeYear: true,
                yearRange: '1950:currentYear',
                maxDate:'0',
                dateFormat: 'dd-M-yy',
                defaultDate: 'currentdate'
            });
        });

    });
    function showDiv() {
        //document.getElementById("ContentPlaceHolder1_pkgAmtDiv").visible = "true";
        var x = document.getElementById("ContentPlaceHolder1_pkgAmtDiv");
        if (x.className.indexOf("w3-show") == -1) {
            x.className = x.className.replace(" w3-hide", " w3-show");
        }
    }
    function hideDiv() {
        //document.getElementById("ContentPlaceHolder1_pkgAmtDiv").visible = "true";
        var x = document.getElementById("ContentPlaceHolder1_pkgAmtDiv");
        if (x.className.indexOf("w3-hide") == -1) {
            x.className = x.className.replace(" w3-show", " w3-hide");
        }
    } 
</script>
</asp:Content>
