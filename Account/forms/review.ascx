<%@ Control Language="C#" AutoEventWireup="true" CodeFile="review.ascx.cs" Inherits="Account_forms_review" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1">
    <title></title>
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
            width: 400px;
            height: 350px;
        }
        .lbl
        {
            font-size:16px;
            font-style:italic;
            font-weight:bold;
        }
    </style>
</head>
<body >

<%--<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>--%>
<asp:Button ID="Button1" runat="server" Text="Fill Form in Popup" />

<!-- ModalPopupExtender -->
<cc1:ModalPopupExtender ID="mp1" runat="server" PopupControlID="Panl1" TargetControlID="Button1"
    CancelControlID="Button2" BackgroundCssClass="Background">
</cc1:ModalPopupExtender>
<asp:Panel ID="Panl1" runat="server" CssClass="Popup" align="center" style = "display:none">
    <table>
    <tr>
    <td>
    <asp:Label ID="Label1" runat="server" CssClass="lbl" Text="Appraiser's Comment"></asp:Label>
    </td>
    <td>
    <%--<asp:TextBox ID="TxtComment" runat="server" Font-Size="14px"></asp:TextBox>--%>
    <asp:TextBox ID="TxtComment" runat="server" BorderStyle="Solid" BorderColor="Blue" 
           Height="49px" TextMode="MultiLine" Width="492px" style="text-align: left"></asp:TextBox>
    </td>
    </tr>
    
    <%--
    <tr>
    <td>
    <asp:Label ID="Label7" runat="server" CssClass="lbl" Text="State"></asp:Label>
    </td>
    <td>
    <asp:TextBox ID="TextBox7" runat="server" Font-Size="14px" ></asp:TextBox>
    </td>
    </tr>--%>
   
    </table>
    <br />
    btnSendReview
    <asp:Button ID="btnSendReview" runat="server" Text="Send Review to Holder" />
    <asp:Button ID="Button2" runat="server" Text="Close" />
</asp:Panel>
<!-- ModalPopupExtender -->

</body>
</html>

