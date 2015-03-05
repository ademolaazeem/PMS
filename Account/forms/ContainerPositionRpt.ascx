<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ContainerPositionRpt.ascx.cs" Inherits="Account_forms_ContainerPositionRpt" %>
<%@ Register assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>
            

<%--<CR:CrystalReportViewer ID="CRptViewer" runat="server" AutoDataBind="true" EnableDatabaseLogonPrompt="false"  
ToolPanelView="None" ReuseParameterValuesOnRefresh="true" HasCrystalLogo="False" oninit="CRptViewer_Init" />--%>

<CR:CrystalReportViewer ID="CRptViewer" runat="server" AutoDataBind="True" ReportSourceID="CrptSrc" EnableDatabaseLogonPrompt="false"
ToolPanelView="None" ReuseParameterValuesOnRefresh="true" HasCrystalLogo="False" />
<CR:CrystalReportSource ID="CrptSrc" runat="server">
<Report FileName="../Report/PositionReport.rpt">
</Report>
</CR:CrystalReportSource>
                    
