<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ChangeDepartment.aspx.cs" Inherits="OIPD.ChangeDepartment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="w3-row">
    <div class="w3-col s2"><br/></div>
    <div class="w3-col s8 w3-padding w3-border w3-border-teal w3-card-4">
        <div>
        <div class="w3-light-green w3-center w3-large w3-text-teal"><b>PATIENT DETAILS</b></div>
        <br/>
        <div class="w3-row">
            <div class="w3-col s2"><asp:Label ID="lblPatientName" runat="server" Text="Patient Name -: "/></div>
            <div class="w3-col s4"><asp:Label ID="lblPatient" runat="server" Text=""/></div>
            <div class="w3-col s3"><asp:Label ID="lblDateOfAdmit" runat="server" Text="Date Of Admit -: "/></div>
            <div class="w3-col s3"><asp:Label ID="lblDate" runat="server" Text=""/></div>
        </div>
        <br/>
        <div class="w3-row">
            <div class="w3-col s2"><asp:Label ID="lblDepartName" runat="server" Text="Department -: " /></div>
            <div class="w3-col s5"><asp:Label ID="lblDepart"  runat="server" Text=""/></div>
            <div class="w3-col s2"><asp:Label ID="lbldctrInchrg" runat="server" Text="Doctor -: " /></div>
            <div class="w3-col s3"><asp:Label ID="lblDoctor" CssClass="w3-left" runat="server" Text=""/></div>
        </div>
        <br />
        <div class="w3-row">
            <div class="w3-col s2"><asp:Label ID="lblAdmitReason" runat="server" Text="Admited For -: " /></div>
            <div class="w3-col s10"><asp:Label ID="lblReason" CssClass="w3-left" runat="server" Text=""/></div>
        </div>
        <br />
        </div>
        <div>

        <div class="w3-light-green w3-center w3-large w3-text-teal"><b>CHANGE DEPARTMENT</b></div>
        <br/>
        <div><asp:Label ID="lblMessage" runat="server" Text="" CssClass="w3-text-red w3-large"></asp:Label></div>
        <div class="w3-row">
            <div class="w3-col s2">&nbsp;</div>
            <asp:Label ID="lblNewDepart" runat="server" CssClass="w3-col s3">Select New Department -:</asp:Label>
            <div class="w3-col s1">&nbsp;</div>
            <asp:DropDownList CssClass="w3-col s4 w3-input" ID="ddlDepartments" runat="server" AppendDataBoundItems="True" 
                DataSourceID="SqlDataSource1" DataTextField="departname" DataValueField="departmentno">
                <asp:ListItem Selected="True" Text="Select New Department" Value="-1"></asp:ListItem>
            </asp:DropDownList>
            <div class="w3-col s2">&nbsp;</div>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                ConnectionString="<%$ ConnectionStrings:IODatabaseConnectionString %>" 
                SelectCommand="SELECT * FROM hospitals.departments ORDER BY [departname]"></asp:SqlDataSource>
        </div>
        <br />
        <div class="w3-center">
            <asp:Button ID="bttnadmit" class="w3-center w3-xlarge w3-card-2 w3-round-xxlarge w3-btn w3-teal" 
                runat="server" Text="Change Department" onclick="bttnadmit_Click"/>
        </div>
        <br />

        </div>
    </div>
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
                maxDate: '0',
                dateFormat: 'dd-M-yy',
                defaultDate: 'currentdate'
            });
        });

    });
</script>
    <br />
</asp:Content>
