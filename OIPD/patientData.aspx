<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="patientData.aspx.cs" Inherits="OIPD.patientData" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
<center>
    <div id="mod" class="w3-modal w3-padding">
        <br /><br />
        <div class="w3-modal-content w3-padding-large">
            <span onclick="hideImage()" class="w3-button w3-display-topright">&times;</span>
            <div class="w3-padding w3-center">
                <img src="" alt="" id="documentBigImage" width="80%" />
            </div>
        </div>
    </div>
</center>
<script type="text/javascript">
    function displayImage(src) {
        document.getElementById("mod").style.display = "block";
        var imgSrc = document.getElementById("documentBigImage");
        imgSrc.src = "" + src;
    }
    function hideImage() {
        document.getElementById("mod").style.display = "none";
    }
</script>
<div class="w3-row">
    <div class="w3-col s3 w3-padding">
        <asp:Button ID="btnOPDDetails" Width="100%" runat="server" Font-Bold="true" CssClass="w3-padding-24 w3-border-0 buttonUnclicked w3-text-white w3-teal w3-large" Text="OPD Details" onclick="opdDetailsClick" />
        <asp:Button ID="btnIPDDetails" Width="100%" runat="server" Font-Bold="true" CssClass="w3-padding-24 w3-border-0 buttonUnclicked w3-text-white w3-teal w3-large" Text="IPD Details" onclick="ipdDetailsClick" />
        <asp:Button ID="btnDischargeDetails" Width="100%" runat="server" Font-Bold="true" CssClass="w3-padding-24 w3-border-0 buttonUnclicked w3-text-white w3-teal w3-large" Text="Discharge Details" onclick="dischargeDetailsClick" />
        <asp:Button ID="btnTreatementDetails" Width="100%" runat="server" Font-Bold="true" CssClass="w3-padding-24 w3-border-0 buttonUnclicked w3-text-white w3-teal w3-large" Text="Treatment Details" onclick="treatementDetailsClick" />
        <asp:Button ID="btnDocuments" Width="100%" runat="server" Font-Bold="true" CssClass="w3-padding-24 w3-border-0 buttonUnclicked w3-text-white w3-teal w3-large" Text="Documents/Photos" onclick="documentDetailsClick" />
        <asp:Button ID="btnAmountDetails" Width="100%" runat="server" Font-Bold="true" CssClass="w3-padding-24 w3-border-0 buttonUnclicked w3-text-white w3-teal w3-large" Text="Amount Details" onclick="amountDetailsClick" />
    </div>
    <div   class="w3-col s8 w3-center w3-pale-yellow w3-padding w3-card-4 w3-centered w3-border">
        <div id="opdData" class="w3-large" runat="server" visible="true">
            <div class="w3-padding w3-xlarge w3-center w3-teal">
                <b>OPD DETAILS</b>
            </div>
            <br style="line-height:0.5" />
            <div class="w3-circle w3-black w3-card-2" style="height:3px"></div>
            <br style="line-height:0.5" />
            <div class="w3-row">
                <div class="w3-col s8">
                    <div class="w3-row">
                        <div class="w3-col s5"><asp:Label ID="lblPatientIPNumber" Font-Bold="true" runat="server" CssClass="w3-left" Text="IP Number -: "/></div>
                        <div class="w3-col s7"><asp:Label ID="lblIPNumber" runat="server" CssClass="w3-left" Text="GLC/2019/12/06/198"/></div>
                    </div>
                    <br style="line-height:0.5" />
                    <div class="w3-row">
                        <div class="w3-col s5"><asp:Label ID="lblTypeOfPatient" Font-Bold="true" runat="server" CssClass="w3-left" Text="Under -: "/></div>
                        <div class="w3-col s7"><asp:Label ID="lblPatientType" runat="server" CssClass="w3-left" Text="Geetanjali"/></div>
                    </div>
                    <br style="line-height:0.5" />
                    <div class="w3-row">
                        <div class="w3-col s5"><asp:Label ID="lblPatientName" Font-Bold="true" runat="server" CssClass="w3-left" Text="Patient Name -: "/></div>
                        <div class="w3-col s7"><asp:Label ID="lblPatient" runat="server" CssClass="w3-left" Text=""/></div>
                    </div>
                    <br style="line-height:0.5" />
                    <div class="w3-row">
                        <div class="w3-col s5"><asp:Label ID="lblDateOfOPD" Font-Bold="true" runat="server" CssClass="w3-left" Text="Date -: "/></div>
                        <div class="w3-col s7"><asp:Label ID="lblDate" runat="server" CssClass="w3-left" Text=""/></div>
                    </div>
                </div>
                <div class="w3-col s4 w3-center">
                    <asp:Label ID="lblPic" runat="server" CssClass="w3-center" Width="100%" Font-Bold="true" Text="Photo"></asp:Label>
                    <img src="~/Resources/geetanjaliLogo.png" class="w3-gray" style="width:110px; height:135px" alt="patientPic" id="imgPatientPic" runat="server" />
                </div>
            </div>
            <br style="line-height:0.5" />
            <div class="w3-row">
                <div class="w3-col s3"><asp:Label ID="lblPateintGender" Font-Bold="true" CssClass="w3-left" runat="server" Text="Department -: " /></div>
                <div class="w3-col s4"><asp:Label ID="lblGender" CssClass="w3-left" runat="server" Text="Male"/></div>
                <div class="w3-col s2"><asp:Label ID="lblPatientAge" Font-Bold="true" runat="server" CssClass="w3-left" Text="Age -: "/></div>
                <div class="w3-col s3"><asp:Label ID="lblAge" runat="server" CssClass="w3-left" Text="10Y 0M 0D"/></div>
            </div>
            <br style="line-height:0.5" />
            <div class="w3-row">
                <div class="w3-col s3"><asp:Label ID="lblPatientAddress" Font-Bold="true" runat="server" CssClass="w3-left" Text="Address -: "/></div>
                <div class="w3-col s4"><asp:Label ID="lblAddress" runat="server" CssClass="w3-left" Text=""/></div>
                <div class="w3-col s2"><asp:Label ID="lblPatientMobile" Font-Bold="true" runat="server" CssClass="w3-left" Text="Mobile No -: "/></div>
                <div class="w3-col s3"><asp:Label ID="lblMobile" runat="server" CssClass="w3-left" Text=""/></div>
            </div>
            <br style="line-height:0.5" />
            <div class="w3-row">
                <div class="w3-col s3"><asp:Label ID="lblDepartName" Font-Bold="true" CssClass="w3-left" runat="server" Text="Department -: " /></div>
                <div class="w3-col s9"><asp:Label ID="lblDepart" CssClass="w3-left" runat="server" Text=""/></div>
            </div>
            <br style="line-height:0.5" />
            <div class="w3-row">
                <div class="w3-col s3"><asp:Label ID="lblReffered" Font-Bold="true" CssClass="w3-left" runat="server" Text="Reffered By -: " /></div>
                <div class="w3-col s9"><asp:Label ID="lblRef" CssClass="w3-left" runat="server" Text=""/></div>
            </div>
        </div>
        <%--<asp:ScriptManager id="scriptManager1" runat="server" EnablePageMethods="true">
        </asp:ScriptManager>--%>

        <script type="text/javascript">
            function checking(docNumber) {

                PageMethods.removeDocument(docNumber, onSuccess, onError);

                function onSuccess(result) {
                    location.reload();
                }

                function onError(result) {
                    alert('Cannot delete at the moment, please try later.');
                }
            }
        </script>

        <div id="documentData" class="w3-large" runat="server" visible="false">
            <div class="w3-padding w3-xlarge w3-center w3-teal">
                <b>DOCUMENTS</b>
            </div>
            <br style="line-height:0.5" />
            <div class="w3-circle w3-black w3-card-2" style="height:3px"></div>
            <br style="line-height:0.5" />
        </div>
        <div id="ipdData" class="w3-large" runat="server" visible="false">
            <div class="w3-padding w3-xlarge w3-center w3-teal">
                <b>IPD DETAILS</b>
            </div>
            <br style="line-height:0.5" />
            <div class="w3-circle w3-black w3-card-2" style="height:3px"></div>
            <br style="line-height:0.5" />
            <div class="w3-row">
                <div class="w3-col s3"><asp:Label ID="lblAdmitReason" Font-Bold="true" CssClass="w3-left" runat="server" Text="Admited For -: " /></div>
                <div class="w3-col s4"><asp:Label ID="lblReason" CssClass="w3-left" runat="server" Text=""/></div>
                <div class="w3-col s2"><asp:Label ID="lblDateOfAdmit" Font-Bold="true" runat="server" CssClass="w3-left" Text="Date -: "/></div>
                <div class="w3-col s3"><asp:Label ID="lblIPDDate" runat="server" CssClass="w3-left" Text="Geetanjali"/></div>
            </div>
            <br style="line-height:0.5" />
            <div class="w3-row">
            <br style="line-height:0.5" />
                <div class="w3-col s3"><asp:Label ID="lblDoctorIncharge" Font-Bold="true" runat="server" CssClass="w3-left" Text="Doctor Incharge -: "/></div>
                <div class="w3-col s4"><asp:Label ID="lblDoctor" runat="server" CssClass="w3-left" Text="GLC/2019/12/06/198"/></div>
                <div class="w3-col s2"><asp:Label ID="lblToBeChargedAs" Font-Bold="true" runat="server" CssClass="w3-left" Text="Charged As -: "/></div>
                <div class="w3-col s3"><asp:Label ID="lblChargedAs" runat="server" CssClass="w3-left" Text="Geetanjali"/></div>
            </div>
            <br />
            <div class="w3-border w3-border-teal w3-padding-small">
                <div class="w3-teal w3-text-white"><asp:Label ID="lblHospDetails" runat="server"><b>Admitted In</b></asp:Label></div>
                <br style="line-height:0.5" />
                <div class="w3-row">
                    <div class="w3-col s2"><asp:Label ID="lblWardNo" Font-Bold="true" runat="server" CssClass="w3-left" Text="Ward -: "/></div>
                    <div class="w3-col s2"><asp:Label ID="lblWard" CssClass="w3-left" runat="server" Text=""/></div>
                    <div class="w3-col s2"><asp:Label ID="lblRoomNo" Font-Bold="true" runat="server" Text="Room -: "/></div>
                    <div class="w3-col s2"><asp:Label ID="lblRoom" CssClass="w3-left" runat="server" Text=""/></div>
                    <div class="w3-col s2"><asp:Label ID="lblBedNo" Font-Bold="true" runat="server" Text="Bed No -: "/></div>
                    <div class="w3-col s2"><asp:Label ID="lblBed" CssClass="w3-left" runat="server" Text=""/></div>
                </div>
                <br style="line-height:0.5" />
            </div>
        </div>
        <div id="treatementData" runat="server" visible="false">
            <div class="w3-padding w3-xlarge w3-center w3-teal">
                <b>TREATEMENT DETAILS</b>
            </div>
            <br style="line-height:0.5" />
            <div class="w3-circle w3-black w3-card-2" style="height:3px"></div>
            <br style="line-height:0.5" />
            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataKeyNames="sno" DataSourceID="SqlDataSource3" CssClass="w3-table-all" CellPadding="4" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:TemplateField HeaderText="Date of Entry" ItemStyle-Width="20%">
                        <ItemTemplate><%# IOPD.DataManager.DateUtilities.onlyDateFormat(Eval("dateOfEntry"))%></ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="nameOfTreatement" ItemStyle-Width="20%" HeaderText="Treatement" SortExpression="nameOfTreatement" />
                    <asp:BoundField DataField="details" ItemStyle-Width="50%" HeaderText="Details" SortExpression="details" />
                    <asp:TemplateField HeaderText="Action" ItemStyle-Width="10%">
                        <ItemTemplate><a href="prescription.aspx?treatno=<%# Eval("sno") %>">Print</a></ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <EditRowStyle BackColor="#7C6F57" />
                <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#E3EAEB" />
                <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F8FAFA" />
                <SortedAscendingHeaderStyle BackColor="#246B61" />
                <SortedDescendingCellStyle BackColor="#D4DFE1" />
                <SortedDescendingHeaderStyle BackColor="#15524A" />
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource3" runat="server"
                ConnectionString="<%$ ConnectionStrings:IODatabaseConnectionString %>" 
                SelectCommand="SELECT * FROM hospitals.treatement WHERE ([patientno] = @patientno) ORDER BY [dateOfEntry] DESC, [nameOfTreatement]">
                <SelectParameters>
                    <asp:QueryStringParameter Name="patientno" QueryStringField="patientno" Type="Int32" />
                </SelectParameters>
            </asp:SqlDataSource>
        </div>
        <div id="dischargeData" class="w3-large" runat="server" visible="false">
            <div class="w3-padding w3-xlarge w3-center w3-teal">
                <b>DISCHARGE DETAILS</b>
            </div>
            <br style="line-height:0.5" />
            <div class="w3-circle w3-black w3-card-2" style="height:3px"></div>
            <br style="line-height:0.5" />
            <div class="w3-row">
                <div class="w3-col s3"><asp:Label ID="lblDisDate" Font-Bold="true" CssClass="w3-left" runat="server" Text="Discharged On -: " /></div>
                <div class="w3-col s9"><asp:Label ID="lblDischargeDate" CssClass="w3-left" runat="server" Text=""/></div>
            </div><br />
            <div class="w3-row">
                <div class="w3-col s4"><asp:Label ID="lblDisAppr" Font-Bold="true" runat="server" CssClass="w3-left" Text="Discharge Approved -: "/></div>
                <div class="w3-col s2"><asp:Label ID="lblDischargeApproved" CssClass="w3-left" runat="server" Text=""/></div>
                <div class="w3-col s4"><asp:Label ID="lblDisTreat" Font-Bold="true" runat="server" Text="Further Treatment -: "/></div>
                <div class="w3-col s2"><asp:Label ID="lblDischargeTreat" CssClass="w3-left" runat="server" Text=""/></div>
            </div><br />
            <div class="w3-row">
                <div class="w3-col s3"><asp:Label ID="lblDisRes" Font-Bold="true" runat="server" Text="Discharge Reason -: "/></div>
                <div class="w3-col s3"><asp:Label ID="lblDischargeReason" CssClass="w3-left" runat="server" Text=""/></div>
                <div class="w3-col s3"><asp:Label ID="lblDisBy" Font-Bold="true" runat="server" CssClass="w3-left" Text="Discharging Physian-: "/></div>
                <div class="w3-col s3"><asp:Label ID="lblDischargeBy" CssClass="w3-right" runat="server" Text=""/></div>
            </div><br/>
            <asp:Label ID="Label4" CssClass="w3-large" runat="server"><b>Case Summary</b></asp:Label>
            <div class="w3-row">
                <div class="w3-col s4"><asp:Label ID="lbl1" CssClass="w3-left" runat="server"><b>CHIEF COMPLAINT &<br />RELEVANT HISTORY :</b></asp:Label></div>
                <div class="w3-col s8"><asp:Label ID="lblChiefComplain" CssClass="w3-left" runat="server" Text=""/></div>
            </div><br />
            <div class="w3-row">
                <div class="w3-col s4"><asp:Label ID="Label6" CssClass="w3-left" runat="server"><b>PHYSICAL FINDINGS :</b></asp:Label></div>
                <div class="w3-col s8"><asp:Label ID="lblPhysical" CssClass="w3-left" runat="server" Text=""/></div>
            </div><br />
            <div class="w3-row">
                <div class="w3-col s4"><asp:Label ID="Label8" CssClass="w3-left" runat="server"><b>INVESTIGATION<br />(Lab. & X-Ray) :</b></asp:Label></div>
                <div class="w3-col s8"><asp:Label ID="lblInvestigation" CssClass="w3-left" runat="server" Text=""/></div>
            </div><br />
            <div class="w3-row">
                <div class="w3-col s4"><asp:Label ID="Label10" CssClass="w3-left" runat="server"><b>TREATEMENT :</b></asp:Label></div>
                <div class="w3-col s8"><asp:Label ID="lblTreatement" CssClass="w3-left" runat="server" Text=""/></div>
            </div><br />
            <div class="w3-row">
                <div class="w3-col s4"><asp:Label ID="Label12" CssClass="w3-left" runat="server"><b>OPERATION :</b></asp:Label></div>
                <div class="w3-col s8"><asp:Label ID="lblOperation" CssClass="w3-left" runat="server" Text=""/></div>
            </div><br />
            <div class="w3-row">
                <div class="w3-col s4"><asp:Label ID="Label14" CssClass="w3-left" runat="server"><b>BIOPSY REPORT :</b></asp:Label></div>
                <div class="w3-col s8"><asp:Label ID="lblBiopsy" CssClass="w3-left" runat="server" Text=""/></div>
            </div><br />
            <div class="w3-row">
                <div class="w3-col s4"><asp:Label ID="Label16" CssClass="w3-left" runat="server"><b>FINAL DIAGNOSIS :</b></asp:Label></div>
                <div class="w3-col s8"><asp:Label ID="lblFinal" CssClass="w3-left" runat="server" Text=""/></div>
            </div><br />
            <div class="w3-row">
                <div class="w3-col s4"><asp:Label ID="Label18" CssClass="w3-left" runat="server"><b>RESULT :</b></asp:Label></div>
                <div class="w3-col s8"><asp:Label ID="lblResult" CssClass="w3-left" runat="server" Text=""/></div>
            </div><br />
            <div class="w3-row">
                <div class="w3-col s4"><asp:Label ID="Label20" CssClass="w3-left" runat="server"><b>INSTRUCTION TO<br />THE PATIENT :</b></asp:Label></div>
                <div class="w3-col s8"><asp:Label ID="lblInstruction" CssClass="w3-left" runat="server" Text=""/></div>
            </div><br />
            <div class="w3-row">
                <div class="w3-col s4"><asp:Label ID="Label21" CssClass="w3-left" runat="server"><b>DISCHARGE MEDICINE :</b></asp:Label></div>
                <div class="w3-col s8"><asp:Label ID="lblDischargeMedicine" CssClass="w3-left" runat="server" Text=""/></div>
            </div><br />
        </div>
        <div id="amountData" runat="server" visible="false">
            <div class="w3-padding w3-xlarge w3-center w3-teal">
                <b>BILL DETAILS</b>
            </div>
            <br style="line-height:0.5" />
            <div class="w3-circle w3-black w3-card-2" style="height:3px"></div>
            <br style="line-height:0.5" />
            <asp:Label ID="lblamount" CssClass="w3-xlarge" runat="server"></asp:Label>
            <asp:Label ID="lblDueAmount" CssClass="w3-xlarge fa fa-inr" runat="server"></asp:Label>
            <br />
            <div class="">
                <div class="w3-center w3-padding-small">
                    <asp:Label runat="server" ID="Label2" CssClass="w3-large w3-text-deep-purple" ><b>Total Expenses</b></asp:Label>
                    <asp:GridView ID="totalCharges" runat="server" CssClass="w3-table-all" CellPadding="4" ForeColor="#333333" GridLines="None">
                    <AlternatingRowStyle BackColor="White" />
                    <EditRowStyle BackColor="#2461BF" />
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#EFF3FB" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F5F7FB" />
                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                    <SortedDescendingHeaderStyle BackColor="#4870BE" />
                </asp:GridView>
                </div>
                <div class="w3-center w3-padding-small">
                    <asp:Label runat="server" ID="Label5" CssClass="w3-large w3-text-deep-purple" ><b>Total Discounts</b></asp:Label>
                    <asp:GridView runat="server" ID="GridView3" AutoGenerateColumns="False" DataKeyNames="sno" DataSourceID="SqlDataSource1" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%" ShowFooter="true">
                        <AlternatingRowStyle BackColor="White" />
                        <EmptyDataTemplate>
                            <div class="w3-border w3-border-green w3-card-4 w3-padding w3-text-green w3-center"><b>No Discounts Provided</b></div>
                        </EmptyDataTemplate>
                        <Columns>
                            <asp:TemplateField HeaderText="Date">
                                <ItemTemplate><%# IOPD.DataManager.DateUtilities.onlyDateFormat(Convert.ToDateTime(Eval("date"))) %></ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="comment" HeaderText="Particulars" SortExpression="comment" />
                            <asp:BoundField DataField="discountamount" HeaderText="Amount" SortExpression="discountamount" />
                        </Columns>
                        <EditRowStyle BackColor="#2461BF" />
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EFF3FB" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                    </asp:GridView>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server"
                        ConnectionString="<%$ ConnectionStrings:IODatabaseConnectionString %>" 
                        SelectCommand="SELECT * FROM hospitals.discountdata WHERE ([patientno] = @patientno)">
                        <SelectParameters>
                            <asp:QueryStringParameter DefaultValue="1" Name="patientno" QueryStringField="patientno" Type="Int32" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </div>
                <div class="w3-center w3-padding-small">
                    <asp:Label runat="server" ID="Label1" CssClass="w3-large w3-text-deep-purple" ><b>Total Payments</b></asp:Label>
                    <asp:GridView runat="server" ID="GridView1" AutoGenerateColumns="False" DataKeyNames="sno" DataSourceID="SqlDataSource2" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%" ShowFooter="true">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:TemplateField HeaderText="Date">
                                <ItemTemplate><%# IOPD.DataManager.DateUtilities.onlyDateFormat(Eval("dateofpayment")) %></ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="comments" HeaderText="Particulars" SortExpression="comments" />
                            <asp:BoundField DataField="amount" HeaderText="Amount" SortExpression="amount" />
                            <asp:BoundField DataField="currentuser" HeaderText="User" SortExpression="currentuser" />
                        </Columns>
                        <EditRowStyle BackColor="#2461BF" />
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EFF3FB" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                    </asp:GridView>
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:IODatabaseConnectionString %>" 
                        SelectCommand="SELECT * FROM hospitals.payments WHERE ([patientno] = @patientno)">
                        <SelectParameters>
                            <asp:QueryStringParameter DefaultValue="1" Name="patientno" QueryStringField="patientno" Type="Int32" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </div>
            </div>
        </div>
    </div>
    <div class="w3-col s1">&nbsp;</div>
</div>
<br />
</asp:Content>
