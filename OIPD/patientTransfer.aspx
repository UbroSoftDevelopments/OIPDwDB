<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="patientTransfer.aspx.cs" Inherits="OIPD.patientTransfer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br/>
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
            <asp:Label ID="lblHospDetails" CssClass="w3-center" Width="100%" runat="server"><b>Currently In</b></asp:Label>
            <div class="w3-row">
                <div class="w3-col s2"><asp:Label ID="lblWardNo" runat="server" Text="Ward -: "/></div>
                <div class="w3-col s2"><asp:Label ID="lblWard" CssClass="w3-left" runat="server" Text=""/></div>
                <div class="w3-col s2"><asp:Label ID="lblRoomNo" runat="server" Text="Room -: "/></div>
                <div class="w3-col s2"><asp:Label ID="lblRoom" CssClass="w3-left" runat="server" Text=""/></div>
                <div class="w3-col s2"><asp:Label ID="lblBedNo" runat="server" Text="Bed No -: "/></div>
                <div class="w3-col s2"><asp:Label ID="lblBed" CssClass="w3-left" runat="server" Text=""/></div>
            </div>
            <br/>
            </div>
            <div>
                <div class="w3-light-green w3-center w3-large w3-text-teal"><b>TRANSFER DETAILS</b></div>
                <br/>
                <div>
                    <asp:Label ID="lblMessage" runat="server" Text="" CssClass="w3-text-red w3-large"></asp:Label>
                </div>
                <div class="w3-row">
                    <asp:Label CssClass="w3-col s2 w3-text" ID="lblTransferReason" runat="server" Text="Reason -: " />
                    <asp:TextBox CssClass="w3-input w3-col s2" ID="txtReason" runat="server" placeholder="Enter reason" />
                    <asp:Label CssClass="w3-col s2 w3-text" ID="Label1" runat="server" Text="Date -: " />
                    <asp:TextBox CssClass="w3-input w3-col s2" ID="txtDate" runat="server" placeholder="Date" />
                    <asp:Label CssClass="w3-col s2 w3-text" ID="Label2" runat="server" Text="Time -: " />
                    <div class="w3-col s2 w3-row">
                        <asp:DropDownList ID="trhour" runat="server" CssClass="w3-input w3-col s5">
                            <asp:ListItem>00</asp:ListItem>
                            <asp:ListItem>01</asp:ListItem>
                            <asp:ListItem>02</asp:ListItem>
                            <asp:ListItem>03</asp:ListItem>
                            <asp:ListItem>04</asp:ListItem>
                            <asp:ListItem>05</asp:ListItem>
                            <asp:ListItem>06</asp:ListItem>
                            <asp:ListItem>07</asp:ListItem>
                            <asp:ListItem>08</asp:ListItem>
                            <asp:ListItem>09</asp:ListItem>
                            <asp:ListItem>10</asp:ListItem>
                            <asp:ListItem>11</asp:ListItem>
                            <asp:ListItem>12</asp:ListItem>
                            <asp:ListItem>13</asp:ListItem>
                            <asp:ListItem>14</asp:ListItem>
                            <asp:ListItem>15</asp:ListItem>
                            <asp:ListItem>16</asp:ListItem>
                            <asp:ListItem>17</asp:ListItem>
                            <asp:ListItem>18</asp:ListItem>
                            <asp:ListItem>19</asp:ListItem>
                            <asp:ListItem>20</asp:ListItem>
                            <asp:ListItem>21</asp:ListItem>
                            <asp:ListItem>22</asp:ListItem>
                            <asp:ListItem>23</asp:ListItem>
                        </asp:DropDownList>
                        <div class="w3-col s2"><br /></div>
                        <asp:DropDownList ID="trmin" runat="server" CssClass="w3-input w3-col s5">
                            <asp:ListItem>00</asp:ListItem>
                            <asp:ListItem>01</asp:ListItem>
                            <asp:ListItem>02</asp:ListItem>
                            <asp:ListItem>03</asp:ListItem>
                            <asp:ListItem>04</asp:ListItem>
                            <asp:ListItem>05</asp:ListItem>
                            <asp:ListItem>06</asp:ListItem>
                            <asp:ListItem>07</asp:ListItem>
                            <asp:ListItem>08</asp:ListItem>
                            <asp:ListItem>09</asp:ListItem>
                            <asp:ListItem>10</asp:ListItem>
                            <asp:ListItem>11</asp:ListItem>
                            <asp:ListItem>12</asp:ListItem>
                            <asp:ListItem>13</asp:ListItem>
                            <asp:ListItem>14</asp:ListItem>
                            <asp:ListItem>15</asp:ListItem>
                            <asp:ListItem>16</asp:ListItem>
                            <asp:ListItem>17</asp:ListItem>
                            <asp:ListItem>18</asp:ListItem>
                            <asp:ListItem>19</asp:ListItem>
                            <asp:ListItem>20</asp:ListItem>
                            <asp:ListItem>21</asp:ListItem>
                            <asp:ListItem>22</asp:ListItem>
                            <asp:ListItem>23</asp:ListItem>
                            <asp:ListItem>24</asp:ListItem>
                            <asp:ListItem>25</asp:ListItem>
                            <asp:ListItem>26</asp:ListItem>
                            <asp:ListItem>27</asp:ListItem>
                            <asp:ListItem>28</asp:ListItem>
                            <asp:ListItem>29</asp:ListItem>
                            <asp:ListItem>30</asp:ListItem>
                            <asp:ListItem>31</asp:ListItem>
                            <asp:ListItem>32</asp:ListItem>
                            <asp:ListItem>33</asp:ListItem>
                            <asp:ListItem>34</asp:ListItem>
                            <asp:ListItem>35</asp:ListItem>
                            <asp:ListItem>36</asp:ListItem>
                            <asp:ListItem>37</asp:ListItem>
                            <asp:ListItem>38</asp:ListItem>
                            <asp:ListItem>39</asp:ListItem>
                            <asp:ListItem>40</asp:ListItem>
                            <asp:ListItem>41</asp:ListItem>
                            <asp:ListItem>42</asp:ListItem>
                            <asp:ListItem>43</asp:ListItem>
                            <asp:ListItem>44</asp:ListItem>
                            <asp:ListItem>45</asp:ListItem>
                            <asp:ListItem>46</asp:ListItem>
                            <asp:ListItem>47</asp:ListItem>
                            <asp:ListItem>48</asp:ListItem>
                            <asp:ListItem>49</asp:ListItem>
                            <asp:ListItem>50</asp:ListItem>
                            <asp:ListItem>51</asp:ListItem>
                            <asp:ListItem>52</asp:ListItem>
                            <asp:ListItem>53</asp:ListItem>
                            <asp:ListItem>54</asp:ListItem>
                            <asp:ListItem>55</asp:ListItem>
                            <asp:ListItem>56</asp:ListItem>
                            <asp:ListItem>57</asp:ListItem>
                            <asp:ListItem>58</asp:ListItem>
                            <asp:ListItem>59</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <br />
                <div class="w3-row">
                    <asp:Label CssClass="w3-col s2 w3-text" ID="lblWrdNm" runat="server" Text="Ward Name -: " />
                    <asp:DropDownList CssClass="w3-input w3-col s2" ID="drpdwnWard" runat="server" AutoPostBack="true" onselectedindexchanged="drpdwnWard_SelectedIndexChanged" />
                    <asp:Label CssClass="w3-col s2 w3-text" ID="lblRmNo" runat="server" Text="Room -: " />
                    <asp:DropDownList CssClass="w3-input w3-col s2" ID="drpdwnRoom" runat="server" AutoPostBack="true" onselectedindexchanged="drpdwnRoom_SelectedIndexChanged"/>
                    <asp:Label CssClass="w3-col s2 w3-text" ID="lblBdNo" runat="server" Text="Bed No. -: " />
                    <asp:DropDownList CssClass="w3-input w3-col s2" ID="drpdwnBed" runat="server" />
                </div>
                <br />
                <div class="w3-center"><asp:Button ID="bttnadmit" class="w3-center w3-xlarge w3-card-2 w3-round-xxlarge w3-btn w3-teal" runat="server" Text="Transfer" onclick="bttnadmit_Click"/></div>
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
<br/>
</asp:Content>
