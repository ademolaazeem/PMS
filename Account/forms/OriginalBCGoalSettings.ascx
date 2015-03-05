<%@ Control Language="C#" AutoEventWireup="true" CodeFile="OriginalBCGoalSettings.ascx.cs" Inherits="Account_forms_OriginalBCGoalSettings" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<style type="text/css">


    .style93
    {
        width: 882px;
    }
        .style29
    {
        width: 800px;
        border-style: solid;
        border-width: 1px;
    }
    .style21
    {
        width: 306px;
    }
        .style99
    {
        width: 607px;
    }
        .style28
    {
        height: 23px;
    }
        .style16
    {
        width: 314px;
        height: 22px;
        text-align: left;
    }
    .style26
    {
        height: 22px;
        width: 580px;
        text-align: left;
    }
        .style13
    {
        width: 314px;
        height: 23px;
        background-color: #CCCCFF;
        text-align: left;
    }
        .style27
    {
        width: 580px;
        height: 23px;
        background-color: #CCCCFF;
        text-align: left;
    }
        .style14
    {
        width: 314px;
        height: 17px;
        text-align: left;
    }
        .style24
    {
        height: 17px;
        width: 580px;
        text-align: left;
    }
        .Gridview
        {
        margin-right: 170px;
    }
        

        .style66
    {
        width: 882px;
        text-align: left;
    }
        .style88
    {
        width: 942px;
    }
    .style92
    {
        text-align: left;
        height: 27px;
        background-color: #FFFFFF;
        width: 942px;
    }
        .style100
        {
        width: 400px;
        text-align: center;
        background-color: #CCCCCC;
    }
    .stylefieldset
        {
       width:400px
        text-align: left;
        background-color: #CCCCCC;
    }
        .style101
        {
        width: 350px;
        text-align: center;
    }
        .style102
        {
        width: 500px;
        background-color: #FFFFFF;
    }
        .style103
    {
        width: 142px;
        text-align: center;
        background-color: #CCCCCC;
    }
        </style>
        <style type="text/css">
        .Background
        {
            background-color: Black;
            filter: alpha(opacity=90);
            opacity: 0.8;
        }
        .Popup
        {
            background-color: #FFFFFF;
            border-width: 3px;
            border-style: solid;
            border-color: black;
            padding-top: 10px;
            padding-left: 10px;
            width: 700px;
            height: 200px;
        }
        .lbl
        {
            font-size:16px;
            font-style:italic;
            font-weight:bold;
        }
        .style35
    {
        width: 152px;
        background-color: #FFFFFF;
        text-align: right;
        height: 36px;
    }
    .style36
    {
        background-color: #FFFFFF;
        width: 288px;
        height: 36px;
    }
    .style40
    {
        width: 152px;
        background-color: #CCCCFF;
        text-align: right;
        height: 36px;
    }
    .style39
    {
        background-color: #CCCCFF;
        width: 288px;
        height: 36px;
    }
    .style42
    {
        width: 152px;
        background-color: #FFFFFF;
        text-align: right;
    }
    .style41
    {
        background-color: #FFFFFF;
        width: 288px;
    }
    .style32
    {
        background-color: #FFFFFF;
        text-align: center;
    }
        .style38
    {
        width: 100%;
    }
    </style>






    <asp:Panel ID="Panl1" runat="server" CssClass="Popup" align="center" 
    style = "display:none">
        <table>
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" CssClass="lbl" Text="Appraiser's Comment"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TxtComment" runat="server" BorderStyle="Solid" BorderColor="Blue" 
           Height="30px" TextMode="MultiLine" Width="300px" style="text-align: left"></asp:TextBox>
                </td>
            </tr>
        </table>
        <br />
        
        <%--<asp:Button ID="btnSendReview" runat="server" Text="Send Review to Holder" onclick="btnSendReview_Click" />
        <asp:Button ID="btnClose" runat="server" Text="Close" />--%>
    </asp:Panel>
    <table style="width:100%;">
        <tr>
            <td class="style93">
                <table style="width: 925px" class="style29">
                    <tr>
                        <td align="right" bgcolor="Silver" class="style21">
                            &nbsp;</td>
                        <td bgcolor="Silver" class="style99">
                            <asp:Label ID="lblStatus" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td bgcolor="#CCCCFF" colspan="2" class="style28">
                            <asp:Label ID="Label12" runat="server" Font-Bold="True" ForeColor="Black" 
                Text="Goal Settings - Performance Results"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr align="center" style="text-align: left">
            <td class="style93">
                <%--<table cellpadding="0" cellspacing="0" style="width: 950px">--%>
                <table cellpadding="5" cellspacing="5" class="style29" style="width: 925px" 
                border="0">
                    <tr>
                        <td class="style16">
                            Name:</td>
                        <td class="style26">
                            <asp:Label ID="LblName" runat="server"></asp:Label>
                            &nbsp;<asp:Label ID="LblEmpNo" runat="server" Visible="False"></asp:Label>
                            &nbsp;<asp:Label ID="LblPositionId" runat="server" Visible="False"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="style13">
                            Grade Level:</td>
                        <td class="style27">
                            <asp:Label ID="LblGradeLevel" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="style14">
                            Group/Department:</td>
                        <td class="style24">
                            <asp:Label ID="LblGroupDepartment" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="style13">
                            Appraisal Period:</td>
                        <td class="style27">
                           
                            
                            
                            <fieldset style="width:300px">
                    <legend>Select Date</legend>Year:
                    <asp:DropDownList ID="ddlYear" runat="server" AutoPostBack="True">
                    </asp:DropDownList>
                    Month:
                    <asp:DropDownList ID="ddlMonth" runat="server" AutoPostBack="True">
                    </asp:DropDownList>
                </fieldset>
                
                </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr align="center">
            <td class="style93">
                <table align="left" cellpadding="5" cellspacing="5">
                    <tr>
                        <td>
                            <asp:GridView ID="GrdViewKPI" runat="server" 
                AllowPaging="True" PageSize="8"
                AllowSorting="True" AutoGenerateColumns="False" CellPadding="5" BorderWidth="2px" 
                CssClass="Gridview" DataKeyNames="KPI_DIMENSION" ForeColor="#333333" GridLines="Both" 
                OnPageIndexChanging="GrdViewKPI_PageIndexChanging" OnRowDataBound="GrdViewKPI_RowDataBound"
                OnSorting="GrdViewKPI_Sorting" Width="930px" ShowFooter="True">
                                <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                    <asp:BoundField DataField="KPI_DIMENSION" HeaderText="" 
                                 SortExpression="KPI_DIMENSION" />
                                    <asp:TemplateField HeaderText="WEIGHT" ItemStyle-HorizontalAlign="Center" 
                                 FooterStyle-HorizontalAlign="Center" >
                                        <ItemTemplate>
                                            <asp:label id="WEIGHT1" Text= '<%# Eval("WEIGHT")%>' runat="server"/>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalWeight" runat="server" />
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign= "Center" />
                                <RowStyle BackColor="#EFF3FB" />
                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                <SortedDescendingHeaderStyle BackColor="#4870BE" />
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr align="center">
            <td class="style66">
                <table>
                    <tr>
                        <td class="style88">
                            <asp:GridView ID="GrdViewProfessionalism" runat="server" 
                                EnableViewState="false" AllowPaging="True" 
                AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" BorderWidth="1px" 
                CssClass="Gridview" DataKeyNames="id" ForeColor="#333333" GridLines="Both" 
                OnPageIndexChanging="GrdViewProfessionalism_PageIndexChanging" 
                OnSorting="GrdViewProfessionalism_Sorting" Width="930px">
                                <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                    <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" />
                                    <asp:BoundField DataField="KPI_DIMENSION_DETAILS" HeaderText="Professionalism" 
                 SortExpression="KPI_DIMENSION_DETAILS" />
                                    <asp:TemplateField HeaderText = "Goals/Action Plans">
                                        <ItemTemplate>
                                       <%-- Text='<%#Eval("ACTION_PLANS") %>'--%>
           <asp:TextBox ID="ACTION_PLANS_PROF" runat="server" BorderStyle="Solid" 
           Height="49px" TextMode="MultiLine" Width="492px" style="text-align: left"></asp:TextBox>
                                           
                                           <%-- <asp:RequiredFieldValidator ID="RqdFldValidatorProf" runat="server" 
                 ControlToValidate="ACTION_PLANS_PROF" Display="Dynamic" 
                 ErrorMessage="should not be blank!"></asp:RequiredFieldValidator>--%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <EditRowStyle BackColor="#2461BF" />
                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign= "Center" />
                                <RowStyle BackColor="#EFF3FB" />
                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                <SortedDescendingHeaderStyle BackColor="#4870BE" />
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr align="center">
            <td class="style66">
                <table>
                    <tr>
                        <td class="style88">
                            <asp:GridView ID="GrdViewCommunication" runat="server" 
                EnableViewState="false" AllowPaging="True" 
                AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" BorderWidth="1px" 
                CssClass="Gridview" DataKeyNames="id" ForeColor="#333333" GridLines="Both" 
                OnPageIndexChanging="GrdViewCommunication_PageIndexChanging"
                OnSorting="GrdViewCommunication_Sorting" Width="930px">
                                <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                    <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" />
                                    <asp:BoundField DataField="KPI_DIMENSION_DETAILS" HeaderText="Communication" 
                 SortExpression="KPI_DIMENSION_DETAILS" />
       <asp:TemplateField HeaderText = "Goals/Action Plans">
        <ItemTemplate>
        <%--Text='<%#Eval("ACTION_PLANS") %>'--%>
           <asp:TextBox ID="ACTION_PLANS_COMM" runat="server" BorderStyle="Solid" 
           Height="49px" TextMode="MultiLine" Width="492px" style="text-align: left"></asp:TextBox>
           <%-- <asp:RequiredFieldValidator ID="RqdFldValidatorComm" runat="server" 
                ControlToValidate="ACTION_PLANS_COMM" Display="Dynamic" 
                ErrorMessage="should not be blank!"></asp:RequiredFieldValidator>--%>
          </ItemTemplate>
        </asp:TemplateField>
                                    <%--<asp:TemplateField HeaderText = "Goals/Action Plans">
                                        <ItemTemplate>
                                            <asp:TextBox ID="ACTION_PLANS_COMM" runat="server" BorderStyle="Solid" 
           Height="49px" TextMode="MultiLine" Width="492px" style="text-align: left"></asp:TextBox>
                                           
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                 ControlToValidate="ACTION_PLANS_COMM" Display="Dynamic" 
                 ErrorMessage="should not be blank !!"></asp:RequiredFieldValidator>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                </Columns>
                                <EditRowStyle BackColor="#2461BF" />
                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign= "Center" />
                                <RowStyle BackColor="#EFF3FB" />
                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                <SortedDescendingHeaderStyle BackColor="#4870BE" />
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr align="center">
            <td class="style66">
                <table>
                    <tr>
                        <td class="style88">
                            <asp:GridView ID="GrdViewTeamwork" runat="server" EnableViewState="false" AllowPaging="True" 
                AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" BorderWidth="1px" 
                CssClass="Gridview" DataKeyNames="id" ForeColor="#333333" GridLines="Both" 
                OnPageIndexChanging="GrdViewTeamwork_PageIndexChanging" 
                OnSorting="GrdViewTeamwork_Sorting" Width="930px">
                                <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                    <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" />
                                    <asp:BoundField DataField="KPI_DIMENSION_DETAILS" HeaderText="Teamwork" 
                 SortExpression="KPI_DIMENSION_DETAILS" />
     <asp:TemplateField HeaderText = "Goals/Action Plans">
        <ItemTemplate>
        <%--Text='<%#Eval("ACTION_PLANS") %>'--%>
            <asp:TextBox ID="ACTION_PLANS_TEAM" runat="server" BorderStyle="Solid"  
            Height="49px" TextMode="MultiLine" Width="492px" style="text-align: left"></asp:TextBox>
           <%-- <asp:RequiredFieldValidator ID="RqdFldValidatorTeam" runat="server" 
                ControlToValidate="ACTION_PLANS_TEAM" Display="Dynamic" 
                ErrorMessage="should not be blank!"></asp:RequiredFieldValidator>--%>
            </ItemTemplate>
        </asp:TemplateField>
      
       <%--<asp:TemplateField HeaderText = "Goals/Action Plans">
                                        <ItemTemplate>
                                            <asp:TextBox ID="ACTION_PLANS_TEAM" runat="server" BorderStyle="Solid" 
           Height="49px" TextMode="MultiLine" Width="492px" style="text-align: left"></asp:TextBox>
                                            
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                 ControlToValidate="ACTION_PLANS_TEAM" Display="Dynamic" 
                 ErrorMessage="should not be blank !!"></asp:RequiredFieldValidator>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                </Columns>
                                <EditRowStyle BackColor="#2461BF" />
                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign= "Center" />
                                <RowStyle BackColor="#EFF3FB" />
                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                <SortedDescendingHeaderStyle BackColor="#4870BE" />
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr align="center">
            <td class="style66">
                <table>
                    <tr>
                        <td class="style92">
                            <asp:GridView ID="GrdViewCustomerCentricity" runat="server" 
                                EnableViewState="false" AllowPaging="True" 
                AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" BorderWidth="1px" 
                CssClass="Gridview" DataKeyNames="id" ForeColor="#333333" GridLines="Both" 
                OnPageIndexChanging="GrdViewCustomerCentricity_PageIndexChanging" 
                OnSorting="GrdViewCustomerCentricity_Sorting" Width="930px">
                                <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                    <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" />
                                    <asp:BoundField DataField="KPI_DIMENSION_DETAILS" HeaderText="Customer Centricity" 
                 SortExpression="KPI_DIMENSION_DETAILS" />
       <asp:TemplateField HeaderText = "Goals/Action Plans">
        <ItemTemplate>
        <%--Text='<%#Eval("ACTION_PLANS") %>'--%>
           <asp:TextBox ID="ACTION_PLANS_CUST" runat="server" BorderStyle="Solid" 
           Height="49px" TextMode="MultiLine" Width="492px" style="text-align: left"></asp:TextBox>
            <%--<asp:RequiredFieldValidator ID="RqdFldValidatorCust" runat="server" 
                ControlToValidate="ACTION_PLANS_CUST" Display="Dynamic" 
                ErrorMessage="should not be blank!"></asp:RequiredFieldValidator>--%>
          </ItemTemplate>
        </asp:TemplateField>
                                    <%--<asp:TemplateField HeaderText = "Goals/Action Plans">
                                        <ItemTemplate>
                                            <asp:TextBox ID="ACTION_PLANS2" runat="server" BorderStyle="Solid" 
           Height="49px" TextMode="MultiLine" Width="492px" style="text-align: left"></asp:TextBox>
                                            
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                 ControlToValidate="ACTION_PLANS" Display="Dynamic" 
                 ErrorMessage="should not be blank !!"></asp:RequiredFieldValidator>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                </Columns>
                                <EditRowStyle BackColor="#2461BF" />
                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign= "Center" />
                                <RowStyle BackColor="#EFF3FB" />
                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                <SortedDescendingHeaderStyle BackColor="#4870BE" />
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr align="center">
            <td class="style66">
                <table>
                    <tr>
                        <td class="style88">
                            <asp:GridView ID="GrdViewInnovation" runat="server" EnableViewState="false" AllowPaging="True" 
                AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" BorderWidth="1px" 
                CssClass="Gridview" DataKeyNames="id" ForeColor="#333333" GridLines="Both" 
                OnPageIndexChanging="GrdViewInnovation_PageIndexChanging" 
                OnSorting="GrdViewInnovation_Sorting" Width="930px">
                                <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                    <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" />
                                    <asp:BoundField DataField="KPI_DIMENSION_DETAILS" HeaderText="Innovation" 
                 SortExpression="KPI_DIMENSION_DETAILS" />
       <asp:TemplateField HeaderText = "Goals/Action Plans">
        <ItemTemplate>
        <%--Text='<%#Eval("ACTION_PLANS") %>'--%>
           <asp:TextBox ID="ACTION_PLANS_INNO" runat="server" BorderStyle="Solid" 
           Height="49px" TextMode="MultiLine" Width="492px" style="text-align: left"></asp:TextBox>
            <%--<asp:RequiredFieldValidator ID="RqdFldValidatorInno" runat="server" 
                ControlToValidate="ACTION_PLANS_INNO" Display="Dynamic" 
                ErrorMessage="should not be blank!"></asp:RequiredFieldValidator>--%>
          </ItemTemplate>
        </asp:TemplateField>
                                    <%--<asp:TemplateField HeaderText = "Goals/Action Plans">
                                        <ItemTemplate>
                                            <asp:TextBox ID="ACTION_PLANS3" runat="server" BorderStyle="Solid" 
           Height="49px" TextMode="MultiLine" Width="492px" style="text-align: left"></asp:TextBox>
                                           
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                 ControlToValidate="ACTION_PLANS" Display="Dynamic" 
                 ErrorMessage="should not be blank!"></asp:RequiredFieldValidator>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                </Columns>
                                <EditRowStyle BackColor="#2461BF" />
                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign= "Center" />
                                <RowStyle BackColor="#EFF3FB" />
                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                <SortedDescendingHeaderStyle BackColor="#4870BE" />
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr align="center">
            <td class="style66">
                <table>
                    <tr>
                        <td class="style88">
                            <asp:GridView ID="GrdViewLeadership" runat="server" EnableViewState="false" AllowPaging="True" 
                AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" BorderWidth="1px" 
                CssClass="Gridview" DataKeyNames="id" ForeColor="#333333" GridLines="Both" 
                OnPageIndexChanging="GrdViewLeadership_PageIndexChanging" 
                OnSorting="GrdViewLeadership_Sorting" Width="930px">
                                <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                    <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" />
                                    <asp:BoundField DataField="KPI_DIMENSION_DETAILS" HeaderText="Leadership" 
                 SortExpression="KPI_DIMENSION_DETAILS" />
       <asp:TemplateField HeaderText = "Goals/Action Plans">
        <ItemTemplate>
        <%--Text='<%#Eval("ACTION_PLANS") %>'--%>
           <asp:TextBox ID="ACTION_PLANS_LEAD" runat="server" BorderStyle="Solid" 
           Height="49px" TextMode="MultiLine" Width="492px" style="text-align: left"></asp:TextBox>
            <%--<asp:RequiredFieldValidator ID="RqdFldValidatorLead" runat="server" 
                ControlToValidate="ACTION_PLANS_LEAD" Display="Dynamic" 
                ErrorMessage="should not be blank!"></asp:RequiredFieldValidator>--%>
          </ItemTemplate>
        </asp:TemplateField>
                                    <%--<asp:TemplateField HeaderText = "Goals/Action Plans">
                                        <ItemTemplate>
                                            <asp:TextBox ID="ACTION_PLANS4" runat="server" BorderStyle="Solid" 
           Height="49px" TextMode="MultiLine" Width="492px" style="text-align: left"></asp:TextBox>
                                           
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                 ControlToValidate="ACTION_PLANS" Display="Dynamic" 
                 ErrorMessage="should not be blank !!"></asp:RequiredFieldValidator>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                </Columns>
                                <EditRowStyle BackColor="#2461BF" />
                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign= "Center" />
                                <RowStyle BackColor="#EFF3FB" />
                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                <SortedDescendingHeaderStyle BackColor="#4870BE" />
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr align="center">
            <td class="style66">
                <table>
                    <tr>
                        <td class="style88">
                            <asp:GridView ID="GrdViewPersEffectAccount" runat="server" 
                                EnableViewState="false" AllowPaging="True" 
                AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" BorderWidth="1px" 
                CssClass="Gridview" DataKeyNames="id" ForeColor="#333333" GridLines="Both" 
                OnPageIndexChanging="GrdViewPersEffectAccount_PageIndexChanging"
                OnSorting="GrdViewPersEffectAccount_Sorting" Width="930px">
                                <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                    <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" />
                                    <asp:BoundField DataField="KPI_DIMENSION_DETAILS" 
                 HeaderText="Personal Effectiveness & Accountability" 
                 SortExpression="KPI_DIMENSION_DETAILS" />
        <asp:TemplateField HeaderText = "Goals/Action Plans">
        <ItemTemplate>
        <%--Text='<%#Eval("ACTION_PLANS") %>'--%>
        <%--Text='<%#Eval("ACTION_PLANS") %>'--%>
           <asp:TextBox ID="ACTION_PLANS_PEA" runat="server" BorderStyle="Solid" 
           Height="49px" TextMode="MultiLine" Width="492px" style="text-align: left"></asp:TextBox>
           <%-- <asp:RequiredFieldValidator ID="RqdFldValidatorPea" runat="server" 
                ControlToValidate="ACTION_PLANS_PEA" Display="Dynamic" 
                ErrorMessage="should not be blank!"></asp:RequiredFieldValidator>--%>
          </ItemTemplate>
        </asp:TemplateField>
                                    <%--<asp:TemplateField HeaderText = "Goals/Action Plans">
                                        <ItemTemplate>
                                            <asp:TextBox ID="ACTION_PLANS" runat="server" BorderStyle="Solid" 
           Height="49px" TextMode="MultiLine" Width="492px" style="text-align: left"></asp:TextBox>
                                           
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                 ControlToValidate="ACTION_PLANS" Display="Dynamic" 
                 ErrorMessage="should not be blank !!"></asp:RequiredFieldValidator>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                </Columns>
                                <EditRowStyle BackColor="#2461BF" />
                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign= "Center" />
                                <RowStyle BackColor="#EFF3FB" />
                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                <SortedDescendingHeaderStyle BackColor="#4870BE" />
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr align="center">
            <td class="style66">
                <table style="width: 998px">
                    <tr>
                        <td class="style100">
                            <asp:Label ID="LblHolderSign" runat="server">Job Holder&#39;s Signature</asp:Label>
                        </td>
                        <td class="style101">
                            <asp:Label ID="LblHolderSignature" runat="server"></asp:Label>
                        </td>
                        <td class="style103">
                            <asp:Label ID="LblHolderDate" runat="server">Date <i>yyyy/m/d</i></asp:Label>
                        </td>
<td class="style102">


            <%-- Text='<%#Eval("ACTION_PLANS") %>'--%>                     <%-- <asp:RequiredFieldValidator ID="RqdFldValidatorProf" runat="server" 
                 ControlToValidate="ACTION_PLANS_PROF" Display="Dynamic" 
                 ErrorMessage="should not be blank!"></asp:RequiredFieldValidator>--%>&nbsp;
                     <asp:DropDownList ID="DDLHolderYear" runat="server" >
                     <%--onselectedindexchanged="DDLHolderYear_SelectedIndexChanged"     AutoPostBack="True"--%>
                     </asp:DropDownList>
                      &nbsp;
                     <asp:DropDownList ID="DDLHolderMonth" runat="server" onselectedindexchanged="DDLHolderMonth_SelectedIndexChanged">
                     </asp:DropDownList>
                      &nbsp;
                     <asp:DropDownList ID="DDLHolderDay" runat="server"></asp:DropDownList>
            <%--Text='<%#Eval("ACTION_PLANS") %>'--%>
                 <%-- <asp:RequiredFieldValidator ID="RqdFldValidatorComm" runat="server" 
                ControlToValidate="ACTION_PLANS_COMM" Display="Dynamic" 
                ErrorMessage="should not be blank!"></asp:RequiredFieldValidator>--%>


</td>
                    </tr>
                    <tr>
                        <td class="style100">
                            <asp:Label ID="LblAppraisalSign" runat="server">Appraisal&#39;s Signature</asp:Label>
                        </td>
                        <td class="style101">
                            <asp:Label ID="LblAppraiserSignature" runat="server"></asp:Label>
                        </td>
                        <td class="style103">
                            <asp:Label ID="LblAppraiserDate" runat="server">Date <i>yyyy/m/d</i></asp:Label>
                        </td>
                        <td>
                            <%--<asp:TemplateField HeaderText = "Goals/Action Plans">
                                        <ItemTemplate>
                                            <asp:TextBox ID="ACTION_PLANS_COMM" runat="server" BorderStyle="Solid" 
           Height="49px" TextMode="MultiLine" Width="492px" style="text-align: left"></asp:TextBox>
                                           
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                 ControlToValidate="ACTION_PLANS_COMM" Display="Dynamic" 
                 ErrorMessage="should not be blank !!"></asp:RequiredFieldValidator>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>&nbsp;<asp:DropDownList ID="DDLAppraiserYear" runat="server" AutoPostBack="True"
            onselectedindexchanged="DDLAppraiserYear_SelectedIndexChanged" >
                            </asp:DropDownList>
                            &nbsp;<asp:DropDownList ID="DDLAppraiserMonth" runat="server" AutoPostBack="True"
            onselectedindexchanged="DDLAppraiserMonth_SelectedIndexChanged">
                            </asp:DropDownList>
                            &nbsp;<asp:DropDownList ID="DDLAppraiserDay" runat="server">
                            </asp:DropDownList>
                            <%--Text='<%#Eval("ACTION_PLANS") %>'--%>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr align="center">
            <td class="style66">
                
                <%-- <asp:RequiredFieldValidator ID="RqdFldValidatorTeam" runat="server" 
                ControlToValidate="ACTION_PLANS_TEAM" Display="Dynamic" 
                ErrorMessage="should not be blank!"></asp:RequiredFieldValidator>--%>                <%--<asp:TemplateField HeaderText = "Goals/Action Plans">
                                        <ItemTemplate>
                                            <asp:TextBox ID="ACTION_PLANS_TEAM" runat="server" BorderStyle="Solid" 
           Height="49px" TextMode="MultiLine" Width="492px" style="text-align: left"></asp:TextBox>
                                            
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                 ControlToValidate="ACTION_PLANS_TEAM" Display="Dynamic" 
                 ErrorMessage="should not be blank !!"></asp:RequiredFieldValidator>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
<asp:Button ID="btnSendToSupervisor" runat="server" Text="Send To Supervisor" Width="181px" onclick="btnSendToSupervisor_Click" 
style="height: 26px" />
                <%--Text='<%#Eval("ACTION_PLANS") %>'--%>           <%--<asp:RequiredFieldValidator ID="RqdFldValidatorCust" runat="server" 
                ControlToValidate="ACTION_PLANS_CUST" Display="Dynamic" 
                ErrorMessage="should not be blank!"></asp:RequiredFieldValidator>--%>

                



                <asp:Button ID="btnApprove" runat="server" 
                Text="Approve" Width="181px" onclick="btnApprove_Click" />
                <asp:Button ID="btnReview" runat="server" 
                Text="Send Back to Holder for Review" Width="277px" onclick="btnReview_Click" 
                     />
                <cc1:ModalPopupExtender ID="mp1" runat="server" PopupControlID="Panl1" TargetControlID="btnReview"
    CancelControlID="btnClose" BackgroundCssClass="Background">
                </cc1:ModalPopupExtender>
            </td>
        </tr>
    </table>








