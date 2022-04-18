<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="OIPD.OPDIPD.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <!--div class="w3-bar w3-purple w3-large">
<marquee class="w3-card" id="MyMovingText" runat="server" direction="left">
<b class="w3-card w3-amber ">"हम प्रयास करते हैं , ठीक वो करता है "</b>
</marquee>
</div-->
<div class="w3-row w3-center w3-mobile">
    <div class="w3-col s1"><br/></div>
    <div class="w3-card-4 w3-col s10">
        <br />
        <div class="w3-row w3-padding">
            <div class="w3-col s3 w3-padding">
                <a href="opdPatientsList.aspx">
                <div class="w3-green justzoom w3-card-4 w3-padding w3-round-xlarge shine-me">
                    <div class="w3-round-xlarge w3-border w3-border-white">
                        <label class="w3-large"><b>Today's OPD</b></label>
                        <div style="border-style:solid; border-width:1px"></div>
                        <br />
                        <div class="w3-xlarge">
                            <asp:Label ID="ttlOpdPatient" runat="server" Font-Bold="true" Text="10<br />Patients"></asp:Label>
                        </div>
                        <br />
                    </div>
                </div>
                </a>
            </div>
            <div class="w3-col s3 w3-padding">
                <a href="ipdPatientsList.aspx">
                <div class="w3-purple justzoom w3-card-4 w3-padding w3-round-xlarge shine-me">
                    <div class="w3-round-xlarge w3-border w3-border-white">
                        <label class="w3-large"><b>Today's IPD</b></label>
                        <div style="border-style:solid; border-width:1px"></div>
                        <br />
                        <div class="w3-xlarge">
                            <asp:Label ID="ttlIpdPatient" runat="server" Font-Bold="true" Text="10<br />Patients"></asp:Label>
                        </div>
                        <br />
                    </div>
                </div>
                </a>
            </div>
            <div class="w3-col s3 w3-padding">
                <a href="dischargedPatient.aspx">
                <div class="w3-blue justzoom w3-card-4 w3-padding w3-round-xlarge shine-me">
                    <div class="w3-round-xlarge w3-border w3-border-white">
                        <label class="w3-large"><b>Today's Discharge</b></label>
                        <div style="border-style:solid; border-width:1px"></div>
                        <br />
                        <div class="w3-xlarge">
                            <asp:Label ID="ttlDischargePatient" runat="server" Font-Bold="true" Text="10<br />Patients"></asp:Label>
                        </div>
                        <br />
                    </div>
                </div>
                </a>
            </div>
            <div class="w3-col s3 w3-padding">
                <div class="w3-amber justzoom w3-card-4 w3-padding w3-round-xlarge shine-me">
                    <div class="w3-round-xlarge w3-text-white w3-border w3-border-white">
                        <label class="w3-large"><b>Empty Beds</b></label>
                        <div style="border-style:solid; border-width:1px"></div>
                        <br />
                        <div class="w3-xlarge">
                            <asp:Label ID="ttlEmptyBeds" runat="server" Font-Bold="true" Text="10<br />Beds"></asp:Label>
                        </div>
                        <br />
                    </div>
                </div>
            </div>
        </div>
        <br /><br />
        <div class="w3-row w3-padding">
            <div class="w3-col s3 zoom">
                <a href="departmentlist.aspx">
                    <img src="Resources/opdEntry.png" alt="opd_Logo" height="125" /><br/>
                    <asp:Label ID="lblNewEntry" runat="server" Text="Patient Entry (OPD)" CssClass="w3-text-teal"/>
                </a>
            </div>
            <div class="w3-col s3 zoom">
                <a href="ipdregistration.aspx">
                    <img src="Resources/ipdEntry.png" alt="ipd_Logo" height="125" /><br />
                    <asp:Label ID="lblIpdEntry" runat="server" Text="IPD Entry" CssClass="w3-text-teal"/>
                </a>
            </div>
            <div class="w3-col s3 zoom">
                <a href="discharge.aspx">
                    <img src="Resources/discharge.png" alt="discharge_Logo" height="125" /><br />
                    <asp:Label ID="lblDischarge" runat="server" Text="Discharge Patient" CssClass="w3-text-teal"/>
                </a>
            </div>
            <div class="w3-col s3 zoom">
                <a href="searchPatient.aspx">
                    <img src="Resources/searching.png" alt="searching_Logo" height="125" /><br />
                    <asp:Label ID="lblSearch" runat="server" Text="Search Patient" CssClass="w3-text-teal"/>
                </a>
            </div>
        </div>
        <br /><br />
    </div>
    <div class="w3-col s1">&nbsp;</div>
</div>
<br />
<br />

</asp:Content>
