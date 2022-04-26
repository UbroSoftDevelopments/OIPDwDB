<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="dischargePatient.aspx.cs" Inherits="OIPD.dischargePatient" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
<div class="w3-row">
    <div class="w3-col s3">
        <br />
    </div>
    <div   class="w3-col s6 w3-center w3-pale-yellow w3-padding w3-card-4 w3-centered w3-border">
        <div class="w3-container w3-deep-purple">
            <h2><b>DISCHARGE FORM</b></h2>
        </div>
        <br />
        <asp:Label ID="lblPatientDetails" Width="100%" runat="server" CssClass="w3-large w3-teal"><b>Patient Details</b></asp:Label>
        <br />
        <br />
        <div class="w3-row">
            <div class="w3-col s3"><asp:Label ID="lblPatientName" runat="server" Text="Patient Name -: "/></div>
            <div class="w3-col s3"><asp:Label ID="lblPatient" runat="server" Text=""/></div>
            <div class="w3-col s3"><asp:Label ID="lblDateOfAdmit" runat="server" Text="Date Of Admit -: "/></div>
            <div class="w3-col s3"><asp:Label ID="lblDate" runat="server" Text=""/></div>
        </div>
        <br/>
        <div class="w3-row">
            <div class="w3-col s3"><asp:Label ID="lblDepartName" runat="server" Text="Department -: " /></div>
            <div class="w3-col s9"><asp:Label ID="lblDepart" CssClass="w3-left" runat="server" Text=""/></div>
        </div>
        <br />
        <div class="w3-row">
            <div class="w3-col s3"><asp:Label ID="lblAdmitReason" runat="server" Text="Admited For -: " /></div>
            <div class="w3-col s9"><asp:Label ID="lblReason" CssClass="w3-left" runat="server" Text="Reason From IPD Table"/></div>
        </div>
        <br />
        <asp:Label ID="lblHospDetails" runat="server"><b>Admitted In</b></asp:Label>
        <div class="w3-row">
            <div class="w3-col s2"><asp:Label ID="lblWardNo" runat="server" Text="Ward -: "/></div>
            <div class="w3-col s2"><asp:Label ID="lblWard" CssClass="w3-left" runat="server" Text=""/></div>
            <div class="w3-col s2"><asp:Label ID="lblRoomNo" runat="server" Text="Room -: "/></div>
            <div class="w3-col s2"><asp:Label ID="lblRoom" CssClass="w3-left" runat="server" Text=""/></div>
            <div class="w3-col s2"><asp:Label ID="lblBedNo" runat="server" Text="Bed No -: "/></div>
            <div class="w3-col s2"><asp:Label ID="lblBed" CssClass="w3-left" runat="server" Text=""/></div>
        </div>
        <br/>
        <asp:Label ID="lblDischargeDetails" Width="100%" runat="server" CssClass="w3-large w3-teal"><b>DISCHARGE DETAILS</b></asp:Label>
        <br />
        <asp:Label ID="lblErr" runat="server"></asp:Label>
        <br />
        <div class="w3-row">
            <div class="w3-col s3"><asp:Label ID="lblDschrgDate" CssClass="w3-left" runat="server" Text="Discharge Date -: " /></div>
            <div class="w3-col s6"><asp:TextBox CssClass="w3-left w3-input" placeholder="Select Discharge Date" ID="txtdate" runat="server"/></div>
        </div>
        <br />
        <div class="w3-row">
            <div class="w3-col s6"><asp:Label ID="lblPhysianApproval" CssClass="w3-left" runat="server" Text="Is Discharge Physian Approved ? "/></div>
            <div class="w3-col s6">
            <asp:RadioButtonList ID="rdoPhysian" runat="server" RepeatDirection="Horizontal" Width="50%">
            <asp:ListItem Text="Yes" Selected="True" Value="Yes"></asp:ListItem>
            <asp:ListItem Text="No" Selected="False" Value="No"></asp:ListItem>
            </asp:RadioButtonList>
            </div>
        </div>
        <br />
        <div class="w3-row">
            <div class="w3-col s4"><asp:Label ID="lblDischargeReason" CssClass="w3-left" runat="server" Text="Reason for discharge -: "/></div>
            <div class="w3-col s4">
                <asp:DropDownList ID="drpdwnDschrgReason" CssClass="w3-input" runat="server">
                <asp:ListItem Selected="True" Text="-----Select Reason-----" Value="---------Select Reason for Discharge--------"></asp:ListItem>
                <asp:ListItem Text="Patient Treated" Value="Patient Treated"></asp:ListItem>
                <asp:ListItem Text="Patient Transfered" Value="Patient Transfered"></asp:ListItem>
                <asp:ListItem Text="Patient Improved" Value="Patient Improved"></asp:ListItem>
                <asp:ListItem Text="Patient Expired" Value="Patient Expired"></asp:ListItem>
                <asp:ListItem Text="Satisfactory" Value="Satisfactory"></asp:ListItem>
                <asp:ListItem Text="Cured" Value="Cured"></asp:ListItem>
                <asp:ListItem Text="LAMA" Value="LAMA"></asp:ListItem>
                <asp:ListItem Text="DOPR" Value="DOPR"></asp:ListItem>
                <asp:ListItem Text="Other" Value="Other"></asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
        <br />
        <div class="w3-row">
            <div class="w3-col s6"><asp:Label ID="lblIsTreatmenNeeded" CssClass="w3-left" runat="server" Text="Is Further Treatment Needed ? "/></div>
            <div class="w3-col s6">
            <asp:RadioButtonList ID="rdoTreament" runat="server" RepeatDirection="Horizontal" Width="50%">
            <asp:ListItem Text="Yes" Selected="False" Value="Yes"></asp:ListItem>
            <asp:ListItem Text="No" Selected="True" Value="No"></asp:ListItem>
            </asp:RadioButtonList>
            </div>
        </div>
        <br />
        <div class="w3-row">
            <div class="w3-col s5"><asp:Label ID="lblDschrgngPhysician" CssClass="w3-left" runat="server" Text="Discharging Physician Name -: " /></div>
            <div class="w3-col s7"><asp:TextBox Width="100%" CssClass="w3-left w3-input" ID="txtDischargingPhysician" placeholder="Enter Discharging Physician Name" runat="server"/></div>
        </div>
        <div class="w3-row w3-padding">
            <div class="w3-col s12 w3-teal"><asp:Label ID="lblExtra" CssClass="w3-large" runat="server"><b>CASE SUMMARY</b></asp:Label></div>
            <br />
            <br />
            <div class="w3-row">
                <asp:Label ID="lblChiefComplaint" CssClass="w3-col s4" runat="server"><b>CHIEF COMPLAINT &<br />RELEVANT HISTORY :</b></asp:Label>
                <asp:TextBox ID="txtChiefComplaint" CssClass="w3-col s8" runat="server" TextMode="MultiLine"></asp:TextBox>
            </div>
            <br />
            <div class="w3-row">
                <asp:Label ID="lblPhysicalFindings" CssClass="w3-col s4" runat="server"><b>PHYSICAL FINDINGS :</b></asp:Label>
                <asp:TextBox ID="txtPhysicalFindings" CssClass="w3-col s8" runat="server" TextMode="MultiLine"></asp:TextBox>
            </div>
            <br />
            <div class="w3-row">
                <asp:Label ID="lblInvestigation" CssClass="w3-col s4" runat="server"><b>INVESTIGATION<br />(Lab. & X-Ray) :</b></asp:Label>
                <asp:TextBox ID="txtInvestigation" CssClass="w3-col s8" runat="server" TextMode="MultiLine"></asp:TextBox>
            </div>
            <br />
            <div class="w3-row">
                <asp:Label ID="lblTreatement" CssClass="w3-col s4" runat="server"><b>TREATMENT :</b></asp:Label>
                <asp:TextBox ID="txtTreatment" CssClass="w3-col s8" runat="server" TextMode="MultiLine"></asp:TextBox>
            </div>
            <br />
            <div class="w3-row">
                <asp:Label ID="lblOperation" CssClass="w3-col s4" runat="server"><b>OPERATION :</b></asp:Label>
                <asp:TextBox ID="txtOperation" CssClass="w3-col s8" runat="server" TextMode="MultiLine"></asp:TextBox>
            </div>
            <br />
            <div class="w3-row">
                <asp:Label ID="lblBiopsy" CssClass="w3-col s4" runat="server"><b>BIOPSY REPORT :</b></asp:Label>
                <asp:TextBox ID="txtBiopsy" CssClass="w3-col s8" runat="server" TextMode="MultiLine"></asp:TextBox>
            </div>
            <br />
            <div class="w3-row">
                <asp:Label ID="lblFinalDiagnosis" CssClass="w3-col s4" runat="server"><b>FINAL DIAGNOSIS :</b></asp:Label>
                <asp:TextBox ID="txtFinalDiagnosis" CssClass="w3-col s8" runat="server" TextMode="MultiLine"></asp:TextBox>
            </div>
            <br />
            <div class="w3-row">
                <asp:Label ID="lblResult" CssClass="w3-col s4" runat="server"><b>RESULT :</b></asp:Label>
                <asp:TextBox ID="txtResult" CssClass="w3-col s8" runat="server" TextMode="MultiLine"></asp:TextBox>
            </div>
            <br />
            <div class="w3-row">
                <asp:Label ID="lblInstruction" CssClass="w3-col s4" runat="server"><b>INSTRUCTION TO<br />THE PATIENT :</b></asp:Label>
                <asp:TextBox ID="txtInstruction" CssClass="w3-col s8" runat="server" TextMode="MultiLine"></asp:TextBox>
            </div>
            <br />
            <div class="w3-row">
                <asp:Label ID="lblDischargeMedicine" CssClass="w3-col s4" runat="server"><b>DISCHARGE MEDICINE :</b></asp:Label>
                <asp:TextBox ID="txtDischargeMedicine" CssClass="w3-col s8" runat="server" TextMode="MultiLine"></asp:TextBox>
            </div>
        </div>
        <br />
        <asp:Button ID="btnSave" CssClass="w3-round-xxlarge w3-btn w3-large w3-purple" runat="server" Text="Save" OnClick="saveHalfForm" />
        <asp:Button ID="btnDischarge" CssClass="w3-round-xxlarge w3-btn w3-large w3-purple" runat="server" Text="Discharge" OnClick="discharging" />
        <asp:Button ID="btnreset" CssClass="w3-round-xxlarge w3-btn w3-large w3-purple" runat="server" Text="Reset" OnClick="reset" />
        <br /><br />
        <asp:HyperLink ID="btnBill" Visible="false" CssClass="w3-round-xxlarge w3-btn w3-large w3-purple" runat="server" NavigateUrl="" Target="_blank" Text="Go To Bills" ></asp:HyperLink>
        <asp:HyperLink ID="btnPrint" Visible="false" CssClass="w3-round-xxlarge w3-btn w3-large w3-purple" runat="server" NavigateUrl="" Target="_blank" Text="Print" ></asp:HyperLink>
    </div>
</div>
<br />


<script type="text/javascript">
$(function () {
    $(function () {
        var currentYear = (new Date).getFullYear();
        var currentMonth = (new Date).getMonth() + 1;
        var currentDay = (new Date).getDate();
        $("#datepicker").datepicker({ minDate: new Date((currentYear - 1), 12, 1), dateFormat: 'dd/mm/yy', maxDate: new Date(currentYear, 11, 31) });

        $("#ContentPlaceHolder1_txtdate").datepicker({
            changeMonth: true,
            changeYear: true,
            yearRange: '1950:currentYear',
            maxDate:'0',
            dateFormat: 'dd-M-yy',
            defaultDate: 'currentdate'
        });
    });
});
</script>

</asp:Content>
