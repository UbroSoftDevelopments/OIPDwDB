<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="filter.aspx.cs" Inherits="OIPD.filter" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style type="text/css">
    .activeTop
    {
        border-top-style:solid;
        border-left-style:solid;
        border-right-style:solid;
        border-width:5px;
        border-color:White;
        border-top-left-radius:20px;
        border-top-right-radius:20px;
    }
    .inactiveTop
    {
        border-bottom-style:solid;
        border-width:5px;
        border-color:White;
    }
    .activeLeft
    {
        border-top-style:solid;
        border-left-style:solid;
        border-bottom-style:solid;
        border-width:5px;
        border-color:White;
        border-top-left-radius:20px;
        border-bottom-left-radius:20px;
    }
    .inactiveLeft
    {
        border-right-style:solid;
        border-width:5px;
        border-color:White;
    }
    .pagination
    {
        font-size: 100%;
    }
    .pagination a, .pagination span
    {
        color: Black !important;
    }
</style>
    <div class="w3-row w3-padding-large">
    <div class="w3-col s1">&nbsp;</div>
    <div class="w3-col s10 w3-card-4 w3-padding-small w3-round-large w3-gray">
        <div class="w3-row">
            <div class="w3-col s12 w3-center">
                <br style="line-height:0.5" />
                <center><asp:Label ID="casesCount" runat="server" Text="Cases" CssClass="w3-padding w3-text-white w3-xlarge" Font-Overline="true" Font-Underline="true" Width="100%" Font-Bold="true"></asp:Label></center>
                <br style="line-height:0.5" />
                <div class="w3-row w3-padding-small w3-card-4">
                    <div class="w3-col s6 w3-row w3-padding-small" style="border-right-style:solid; border-width:2.5px; border-color:Black">
                        <div class="w3-col s5 w3-padding w3-text-white"><b>Select Department</b></div>
                        <asp:DropDownList ID="ddDepartments" runat="server" CssClass="w3-col s7 w3-input" AutoPostBack="true" DataTextField="departname" DataValueField="departmentno" DataSourceID="SqlDataSource2" ondatabound="ddDepartments_DataBound" onselectedindexchanged="ddDepartments_SelectedIndexChanged"></asp:DropDownList>
                        <asp:SqlDataSource ID="SqlDataSource2" runat="server"
                            ConnectionString="<%$ ConnectionStrings:IODatabaseConnectionString %>" 
                            SelectCommand="SELECT * FROM hospitals.departments ORDER BY [departname]"></asp:SqlDataSource>
                    </div>
                    <div class="w3-col s6 w3-row w3-padding-small" style="border-left-style:solid; border-width:2.5px; border-color:Black">
                        <div class="w3-col s3 w3-padding w3-text-white">
                            <b>Monthly</b>
                        </div>
                        <div class="w3-col s4">
                            <asp:DropDownList ID="ddMonths" CssClass="w3-padding" runat="server" Width="100%">
                                <asp:ListItem Selected="True" Text="All" Value="0"></asp:ListItem>
                                <asp:ListItem Text="January" Value="1"></asp:ListItem>
                                <asp:ListItem Text="Febraury" Value="2"></asp:ListItem>
                                <asp:ListItem Text="March" Value="3"></asp:ListItem>
                                <asp:ListItem Text="April" Value="4"></asp:ListItem>
                                <asp:ListItem Text="May" Value="5"></asp:ListItem>
                                <asp:ListItem Text="June" Value="6"></asp:ListItem>
                                <asp:ListItem Text="July" Value="7"></asp:ListItem>
                                <asp:ListItem Text="August" Value="8"></asp:ListItem>
                                <asp:ListItem Text="September" Value="9"></asp:ListItem>
                                <asp:ListItem Text="October" Value="10"></asp:ListItem>
                                <asp:ListItem Text="November" Value="11"></asp:ListItem>
                                <asp:ListItem Text="December" Value="12"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="w3-col s3">
                            <asp:DropDownList ID="ddYears" CssClass="w3-padding" runat="server" Width="100%"></asp:DropDownList>
                        </div>
                        <div class="w3-col s2">
                            <asp:Button ID="btnFilter" style="cursor:pointer" OnClick="filterMonth" CssClass="w3-button glossButton w3-round-large w3-teal w3-text-white" Font-Bold="true" runat="server" Text="Filter" />
                        </div>
                    </div>
                </div>
                <br style="line-height:0.5" />
                <div class="w3-row w3-text-white w3-large" style="font-weight:bold">
                    <div class="w3-col s2">
                        &nbsp;
                    </div>
                    <div class="w3-col s10">
                        <div class="w3-col s4 back1 activeTop" id="topopd" style="cursor:pointer" runat="server"><asp:Button Width="100%" onclick="opdList" id="top1" runat="server" CssClass="w3-padding-large w3-text-white" style="border-width:0px; background-color:rgba(255,255,255,0); cursor:pointer" Text-="OPD" /></div>
                        <div class="w3-col s4 back2 inactiveTop" id="topipd" style="cursor:pointer" runat="server"><asp:Button Width="100%" onclick="ipdList" id="top2" runat="server" CssClass="w3-padding-large w3-text-white" style="border-width:0px; background-color:rgba(255,255,255,0); cursor:pointer" Text="IPD" /></div>
                        <div class="w3-col s4 back3 inactiveTop" id="topdis" style="cursor:pointer" runat="server"><asp:Button Width="100%" onclick="disList" id="top3" runat="server" CssClass="w3-padding-large w3-text-white" style="border-width:0px; background-color:rgba(255,255,255,0); cursor:pointer" Text="Discharge" /></div>
                    </div>
                </div>
                <div class="w3-row">
                    <div class="w3-col s2 w3-large w3-center w3-text-white" style="font-weight:bold">
                        <div class="w3-padding-small backA activeLeft" style="cursor:pointer" id="leftAll" runat="server" >
                            <asp:Button Width="100%" onclick="allList" id="leftA" runat="server" CssClass="w3-padding-large w3-text-white" style="border-width:0px; background-color:rgba(255,255,255,0); cursor:pointer" Text-="All" />
                        </div>
                        <div class="w3-padding-small back1 inactiveLeft" style="cursor:pointer" id="leftGeet" runat="server" >
                            <asp:Button Width="100%" onclick="geetList" id="left1" runat="server" CssClass="w3-padding-large w3-text-white" style="border-width:0px; background-color:rgba(255,255,255,0); cursor:pointer" Text-="Geetanjali" />
                        </div>
                        <div class="w3-padding-small back2 inactiveLeft" style="cursor:pointer" id="leftAyush" runat="server">
                            <asp:Button Width="100%" onclick="ayushList" id="left2" runat="server" CssClass="w3-padding-large w3-text-white" style="border-width:0px; background-color:rgba(255,255,255,0); cursor:pointer" Text-="Ayushman" />
                            
                        </div>
                        <div class="w3-padding-small back3 inactiveLeft" style="cursor:pointer" id="leftCash" runat="server">
                            <asp:Button Width="100%" onclick="cashList" id="left3" runat="server" CssClass="w3-padding-large w3-text-white" style="border-width:0px; background-color:rgba(255,255,255,0); cursor:pointer" Text-="Cashless" />
                        </div>
                    </div>
                    <div class="w3-col s10 w3-padding-small" style="border-left-style:solid; border-top-style:solid; border-width:2px; border-color:White; ">
                        <asp:GridView ID="mainGrid" Width="100%" runat="server" AutoGenerateColumns="False"  CssClass="w3-table-all" ForeColor="#333333" GridLines="None">
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:TemplateField HeaderText="Patient No" ControlStyle-Width="20%">
                                    <ItemTemplate><%# IOPD.DataManager.RegistrationUtilities.GetRegistrationNo(Convert.ToInt32(Eval("patientno"))) %></ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Department" ControlStyle-Width="15%">
                                    <ItemTemplate><%# IOPD.DataManager.DepartmentValidation.GetDepartmentNameByDepartmentNo(Eval("departmentno"))%></ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Date of Entry" ControlStyle-Width="15%">
                                    <ItemTemplate><%# IOPD.DataManager.DateUtilities.onlyDateFormat(Eval("dateofentry"))%></ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Name" ControlStyle-Width="20%">
                                    <ItemTemplate><%# (Eval("firstname"))+" "+(Eval("lastname"))%></ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Age" ControlStyle-Width="15%">
                                    <ItemTemplate><%# (Eval("ageyears"))+"Y "+(Eval("agemonths"))+"M "+(Eval("agedays"))+"D"%></ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Action" ControlStyle-Width="15%">
                                    <ItemTemplate><a href="patientData.aspx?patientno=<%# Eval("patientno") %>" >Details</a></ItemTemplate>
                                </asp:TemplateField>
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
                            <PagerStyle CssClass="pagination" HorizontalAlign="Center"/>
                        </asp:GridView>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:IODatabaseConnectionString %>"  ></asp:SqlDataSource>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="w3-col s1">&nbsp;</div>
</div>
</asp:Content>
