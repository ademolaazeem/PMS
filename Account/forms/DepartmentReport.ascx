<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DepartmentReport.ascx.cs" Inherits="Account_forms_DepartmentReport" %>
<%@ Register assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<style type="text/css">


    .style21
    {
        width: 152px;
    }
        .style27
    {
        width: 288px;
    }
        .style6
    {
        width: 152px;
        background-color: #CCCCFF;
        text-align: right;
    }
    .style32
    {
        background-color: #FFFFFF;
        text-align: center;
    }
        .style37
    {
        background-color: #CCCCFF;
        width: 288px;
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
    .style38
    {
        width: 100%;
    }
    </style>

<table style="width:94.8%;">
    <tr>
        <td align="right" bgcolor="Silver" class="style21">
            &nbsp;</td>
        <td bgcolor="Silver" class="style27">
            <asp:Label ID="lblStatus" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td bgcolor="#CCCCFF" colspan="2">
            <asp:Label ID="Label12" runat="server" Font-Bold="True" ForeColor="Black" 
                Text="Create Departments"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="style6">
            &nbsp;</td>
        <td class="style37">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style35">
            Select Department:</td>
        <td class="style36">
            <asp:DropDownList ID="DDLDepartments"  runat="server" Height="28px" 
                Width="293px">
            </asp:DropDownList>
            </td>
    </tr>
    <tr>
        <td class="style6">
            &nbsp;</td>
        <td class="style37">
            <asp:Button ID="btnShowReport" runat="server" 
                onclick="btnShowReport_Click" Text="Display Department Now" 
                Height="31px" />
            </td>
    </tr>
    <tr>
        <td class="style32" colspan="2">
            <table class="style38">
                <tr>
                    <td>
            <CR:CrystalReportViewer ID="CRptViewer" runat="server" 
                AutoDataBind="true" EnableDatabaseLogonPrompt="false"  ToolPanelView="None" 
                            ReuseParameterValuesOnRefresh="true" HasCrystalLogo="False" />
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    </table>

        
