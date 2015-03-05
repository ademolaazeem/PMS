<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ContainerUserRoleRpt.ascx.cs" Inherits="Account_forms_ContainerUserRoleRpt" %>


<%@ Register assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<CR:CrystalReportViewer ID="CRptViewer" runat="server" AutoDataBind="True" ReportSourceID="CrptSrc" EnableDatabaseLogonPrompt="false"
ToolPanelView="None" ReuseParameterValuesOnRefresh="true" HasCrystalLogo="False" />

<CR:CrystalReportSource ID="CrptSrc" runat="server">
<Report FileName="../Report/UserRole.rpt">
</Report>
</CR:CrystalReportSource>
                    

                    