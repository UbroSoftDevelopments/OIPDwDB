<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HospitalDetails.aspx.cs" Inherits="OIPD.HospitalDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="w3-row">
        <div class="w3-col s2">&nbsp;</div>
        <div class="w3-col s8 w3-padding w3-card-4 w3-round-medium w3-border w3-border-green w3-pale-green">
            <center><asp:Label ID="lblmsg" runat="server"></asp:Label></center>
            <div class="w3-light-gray w3-padding">
                <asp:LinkButton ID="btnOPDPatientDetails" runat="server" Width="100%" OnClick="getOPDPatients" Text="OPD Patients Data<b><i class='fa fa-angle-down w3-circle highlight w3-right w3-gray w3-text-light-gray w3-hover-text-gray w3-padding'></i></b>" Font-Bold="true" class=""></asp:LinkButton>
            </div>
            <div class="w3-padding w3-light-gray" id="patientOPDDiv" runat="server" visible="false">
                <div class="w3-border w3-pale-green w3-padding w3-border-green">
                    <div class="w3-border-bottom w3-border-green">
                        <asp:RadioButtonList AutoPostBack="true" RepeatDirection="Horizontal" Width="100%" ID="rdoListTime1" runat="server" onselectedindexchanged="rdoListTime1_SelectedIndexChanged">
                            <asp:ListItem Selected="True" Text="Today" Value="1"></asp:ListItem>
                            <asp:ListItem Text="Last 7 Days" Value="2"></asp:ListItem>
                            <asp:ListItem Text="This Month" Value="3"></asp:ListItem>
                            <asp:ListItem Text="All" Value="4"></asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                    <div>
                        <div class="w3-row w3-center w3-text-white">
                            <div class="w3-col s4 w3-padding">
                                <div class="w3-round-large w3-padding w3-border w3-border-green" style="background: linear-gradient(45deg, #e94086 0%, #e5925a 100%);">
                                    <label id="lblOPDGeetanjaliPatients" class="w3-large w3-centered" runat="server"></label>
                                </div>
                            </div>
                            <div class="w3-col s4 w3-padding">
                                <div class="w3-round-large w3-padding w3-border w3-border-green" style="background: linear-gradient(45deg, #7349cc 0%, #e163e4 100%);">
                                    <label id="lblOPDAyushmanPatients" class="w3-large w3-center" runat="server"></label>
                                </div>
                            </div>
                            <div class="w3-col s4 w3-padding">
                                <div class="w3-round-large w3-padding w3-border w3-border-green" style="background: linear-gradient(45deg, #00aee0 0%, #00fedc 100%);">
                                    <label id="lblOPDCashlessPatients" class="w3-large w3-center" runat="server"></label>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <br />
            <div class="w3-light-gray w3-padding">
                <asp:LinkButton ID="btnIPDPatientDetails" runat="server" Width="100%" OnClick="getIPDPatients" Text="IPD Patients Data<b><i class='fa fa-angle-down w3-circle highlight w3-right w3-gray w3-text-light-gray w3-hover-text-gray w3-padding'></i></b>" Font-Bold="true" class=""></asp:LinkButton>
            </div>
            <div class="w3-padding w3-light-gray" id="patientIPDDiv" runat="server" visible="false">
                <div class="w3-border w3-pale-green w3-padding w3-border-green">
                    <div class="w3-border-bottom w3-border-green">
                        <asp:RadioButtonList AutoPostBack="true" RepeatDirection="Horizontal" Width="100%" ID="rdoListTime2" runat="server" onselectedindexchanged="rdoListTime2_SelectedIndexChanged">
                            <asp:ListItem Selected="True" Text="Today" Value="1"></asp:ListItem>
                            <asp:ListItem Text="Last 7 Days" Value="2"></asp:ListItem>
                            <asp:ListItem Text="This Month" Value="3"></asp:ListItem>
                            <asp:ListItem Text="All" Value="4"></asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                    <div>
                        <div class="w3-row w3-center w3-text-white">
                            <div class="w3-col s4 w3-padding">
                                <div class="w3-round-large w3-padding w3-border w3-border-green" style="background: linear-gradient(45deg, #e94086 0%, #e5925a 100%);">
                                    <label id="lblIPDGeetanjaliPatients" class="w3-large w3-centered" runat="server"></label>
                                </div>
                            </div>
                            <div class="w3-col s4 w3-padding">
                                <div class="w3-round-large w3-padding w3-border w3-border-green" style="background: linear-gradient(45deg, #7349cc 0%, #e163e4 100%);">
                                    <label id="lblIPDAyushmanPatients" class="w3-large w3-center" runat="server"></label>
                                </div>
                            </div>
                            <div class="w3-col s4 w3-padding">
                                <div class="w3-round-large w3-padding w3-border w3-border-green" style="background: linear-gradient(45deg, #00aee0 0%, #00fedc 100%);">
                                    <label id="lblIPDCashlessPatients" class="w3-large w3-center" runat="server"></label>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <br />
            <div class="w3-light-gray w3-padding">
                <asp:LinkButton ID="btnDisPatientDetails" runat="server" Width="100%" OnClick="getDisPatients" Text="Discharge Patients Data<b><i class='fa fa-angle-down w3-circle highlight w3-right w3-gray w3-text-light-gray w3-hover-text-gray w3-padding'></i></b>" Font-Bold="true" class=""></asp:LinkButton>
            </div>
            <div class="w3-padding w3-light-gray" id="patientDisDiv" runat="server" visible="false">
                <div class="w3-border w3-pale-green w3-padding w3-border-green">
                    <div class="w3-border-bottom w3-border-green">
                        <asp:RadioButtonList AutoPostBack="true" RepeatDirection="Horizontal" Width="100%" ID="rdoListTime3" runat="server" onselectedindexchanged="rdoListTime3_SelectedIndexChanged">
                            <asp:ListItem Selected="True" Text="Today" Value="1"></asp:ListItem>
                            <asp:ListItem Text="Last 7 Days" Value="2"></asp:ListItem>
                            <asp:ListItem Text="This Month" Value="3"></asp:ListItem>
                            <asp:ListItem Text="All" Value="4"></asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                    <div>
                        <div class="w3-row w3-center w3-text-white">
                            <div class="w3-col s4 w3-padding">
                                <div class="w3-round-large w3-padding w3-border w3-border-green" style="background: linear-gradient(45deg, #e94086 0%, #e5925a 100%);">
                                    <label id="lblDisGeetanjaliPatients" class="w3-large w3-centered" runat="server"></label>
                                </div>
                            </div>
                            <div class="w3-col s4 w3-padding">
                                <div class="w3-round-large w3-padding w3-border w3-border-green" style="background: linear-gradient(45deg, #7349cc 0%, #e163e4 100%);">
                                    <label id="lblDisAyushmanPatients" class="w3-large w3-center" runat="server"></label>
                                </div>
                            </div>
                            <div class="w3-col s4 w3-padding">
                                <div class="w3-round-large w3-padding w3-border w3-border-green" style="background: linear-gradient(45deg, #00aee0 0%, #00fedc 100%);">
                                    <label id="lblDisCashlessPatients" class="w3-large w3-center" runat="server"></label>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="w3-col s2">&nbsp;</div>
    </div>
    <br /><br />
</asp:Content>
