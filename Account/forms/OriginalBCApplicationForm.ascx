<%@ Control Language="C#" AutoEventWireup="true" CodeFile="OriginalBCApplicationForm.ascx.cs" Inherits="Account_forms_OriginalBCApplicationForm" %>
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
        height: 23px;
        background-color: #CCCCCC;
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
    }
    .stylefieldset
        {
       width:400px
        text-align: left;
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
            .style104
            {
                width: 130px;
                background-color: #999999;
                color: #FFFFFF;
                font-weight: bold;
            }
            .style105
            {
                height: 30pt;
                width: 400pt;
                color: windowtext;
                font-weight: 400;
                font-style: normal;
                text-decoration: none;
                text-align: general;
                vertical-align: middle;
                white-space: normal;
                border-left: .5pt solid #969696;
                border-right-style: none;
                border-right-color: inherit;
                border-right-width: medium;
                border-top: 1.0pt solid windowtext;
                border-bottom: .5pt solid #969696;
                padding: 0px;
                background: silver;
            }
            .style106
            {
                width: 130px;
                background-color: #999999;
                height: 15px;
                color: #FFFFFF;
                font-weight: bold;
            }
            .style107
            {
                height: 15px;
            }
            .style109
            {
                text-align: center;
                color: #FFFFFF;
                font-weight: bold;
                background-color: #666666;
            }
            .style111
            {
                width: 130px;
            }
            .style112
            {
                text-align: center;
                color: #FFFFFF;
                font-weight: bold;
                background-color: #666666;
                width: 196px;
            }
            .style113
            {
                width: 196px;
            }
        .font5
	{color:windowtext;
	font-size:16.0pt;
	font-weight:400;
	font-style:italic;
	text-decoration:none;
	font-family:Arial, sans-serif;
	}
            .style115
            {
                color: windowtext;
                font-weight: 400;
                font-style: italic;
                text-decoration: none;
            }
            .style118
            {
                width: 578px;
                text-align: left;
                height: 172px;
            }
            .style119
            {
                width: 196px;
                background-color: #666666;
            }
            .style121
            {
                background-color: #666666;
                color: #000000;
                font-weight: bold;
            }
            .style122
            {
                background-color: #FFFFFF;
            }
            .style123
            {
                width: 130px;
                background-color: #FFFFFF;
                color: #FFFFFF;
                font-weight: bold;
            }
            .style124
            {
                background-color: #999999;
            }
            .style125
            {
                background-color: #CCCCCC;
            }
        </style>



<asp:Panel ID="PnlSub" runat="server">
    <table style="width:94.8%;">
        <tr>
            <td align="right" bgcolor="Silver" class="style21">
                &nbsp;</td>
            <td bgcolor="Silver" class="style27">
                <asp:Label ID="lblStatusSub" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td bgcolor="#CCCCFF" colspan="2" class="style28">
                <asp:Label ID="Label13" runat="server" Font-Bold="True" ForeColor="Black" 
                Text="Select Subordinates"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style42">
                Appraisal Period:</td>
            <td class="style41">
                <fieldset style="width:300px">
                    <legend>Select Date</legend>Year:
                    <asp:DropDownList ID="ddlYear" runat="server" AutoPostBack="True">
                    </asp:DropDownList>
                    Month:
                    <asp:DropDownList ID="ddlMonth" runat="server" AutoPostBack="True">
                    </asp:DropDownList>
                </fieldset></td>
        </tr>
        <tr>
            <td class="style40">
                &nbsp;</td>
            <td class="style39">
                <asp:CheckBox ID="chkMyDetails" runat="server" AutoPostBack="True" 
                    oncheckedchanged="chkMyDetails_CheckedChanged" Text="View My Details" />
            </td>
        </tr>
        <tr>
            <td class="style35">
                <asp:Label ID="LblSubName" runat="server" Text="Select Subordinate name:"></asp:Label>
            </td>
            <td class="style36">
                 <asp:DropDownList ID="DDLSubName" runat="server" Height="28px" Width="293px">
                 </asp:DropDownList>
            </td>
        </tr>
        
        <tr>
            <td class="style40">
                &nbsp;</td>
            <td class="style39">
             
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style42">
                &nbsp;</td>
            <td class="style41">
                <asp:Button ID="btnShowSubBCAppraisalForm" runat="server" Height="31px" 
                    onclick="btnShowSubBCAppraisalForm_Click" 
                    Text="Show Subordinate BC Appraisal Form" />
               
            </td>
        </tr>
        <tr>
            <td class="style32" colspan="2">
                <table class="style38">
                    <tr>
                        <td>
                            &nbsp;</td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Panel>



    <asp:Panel ID="PnlMain" runat="server">







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
                            <%-- <fieldset style="width:300px">
                                <legend>Select Date</legend>Year:
                                <asp:DropDownList ID="ddlYear" runat="server" AutoPostBack="True">
                                </asp:DropDownList>
                                Month:
                                <asp:DropDownList ID="ddlMonth" runat="server" AutoPostBack="True">
                                </asp:DropDownList>
                            </fieldset>--%>
                            <asp:Label ID="LblAppraisalPeriod" runat="server"></asp:Label>
                            
                            
                
                </td>
                    </tr>
                  <tr>
                        <td class="style13" colspan="2">
                            Behavioural Assessment<br />
&nbsp;<font class="style115">(Jobholder’s level of<span style="mso-spacerun:yes">&nbsp; </span>interactions and 
                            communications between the job holder and his other colleagues and 
                            demonstrations of defined competencies for grade level)</font></td>
                    </tr>
                </table>
















            </td>
        </tr>
        <tr align="center">
            <td class="style93">
                <table align="left" cellpadding="5" cellspacing="5" style="width: 658px">
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td class="style125">
                            Total Obtainable
                            <br />
                            Score</td>
                        <td class="style125">
                            Individual Performance<br />
                            Score</td>
                    </tr>
                    <tr>
                        <td class="style124">
                            Professionalism</td>
                        <td>
                            4.3%</td>
                        <td>
                            <asp:Label ID="lblIndProf" runat="server" Text="0.0"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="style124">
                            Communication</td>
                        <td>
                            4.3%</td>
                        <td>
                            <asp:Label ID="lblIndComm" runat="server" Text="0.0"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="style124">
                            Teamwork</td>
                        <td>
                            4.3%</td>
                        <td>
                            <asp:Label ID="lblIndTeam" runat="server" Text="0.0"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="style124">
                            Customer Focus</td>
                        <td>
                            4.3%</td>
                        <td>
                            <asp:Label ID="lblIndCust" runat="server" Text="0.0"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="style124">
                            Innovation</td>
                        <td>
                            4.3%</td>
                        <td>
                            <asp:Label ID="lblInno" runat="server" Text="0.0"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="style124">
                            Leadership</td>
                        <td>
                            4.3%</td>
                        <td>
                            <asp:Label ID="lblLead" runat="server" Text="0.0"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="style124">
                            Personal Effectiveness</td>
                        <td>
                            4.3%</td>
                        <td>
                            <asp:Label ID="lblPEffect" runat="server" Text="0.0"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td class="style125">
                            30%</td>
                        <td class="style125">
                            <asp:Label ID="lblTotalPerformanceScore" runat="server" Text="0.0"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr align="center">
            <td class="style66">
                <table style="width: 936px">
                    <tr>
                        <td class="style106">
                            &nbsp;Professionalism</td>
                        <td class="style107" colspan="7">
                            <table border="0" cellpadding="0" cellspacing="0" style="border-collapse:
 collapse;width:614pt">
                               
                                <tr>
                                    <td class="style105">
                                        • Ability to build and protect the reputation of self and CDL through the 
                                        quality of work, knowledge and experience; and by behaving with integrity.<br />
                                        • Maintains and promotes social, ethical and firm values in conducting internal 
                                        and external business activities. Trustworthy and able to maintain 
                                        confidentiality.</td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td class="style111">
                           </td>
                        <td class="style109" colspan="5">
                            <strong>Rating</strong></td>
                        <td class="style109">
                            Comments</td>
                        <td class="style112" rowspan="2">
                            Score (%)</td>
                    </tr>
                    <tr>
                        <td class="style104">
                            &nbsp;
                            Job Holder</td>
                       
                       
                       
                        <td class="style88">
                        <asp:RadioButton ID="rdoJHProfAlways" runat="server" GroupName="prof" 
                                Text="Always (5)" />
                        </td>

                        <td class="style88">
                              <asp:RadioButton ID="rdoJHProfRegular" runat="server" GroupName="prof" 
                                  Text="Regularly (4)" />
                         </td>
                        <td class="style88">
                           <asp:RadioButton ID="rdoJHProfOften" runat="server" GroupName="prof" 
                                Text="Often (3)" />
                        </td>
                        <td class="style88">
                           <asp:RadioButton ID="rdoJHProfStimes" runat="server" GroupName="prof" 
                                Text="Sometimes (2)" />
                        </td>
                        <td class="style88">
                        <asp:RadioButton ID="rdoJHProfRare" runat="server" GroupName="prof" 
                                Text="Rarely (1)" />
                        </td>
                        <td class="style88">
                            <asp:TextBox ID="TxtProfJHolder" runat="server" TextMode="MultiLine" 
                                Width="149px"></asp:TextBox>
                        </td>
                   
                       
                    </tr>
                    <tr>
                        <td class="style104">
                            &nbsp;
                            Supervisor</td>





                        <td class="style88">
                        <asp:RadioButton ID="rdoProfSupAlways" runat="server" GroupName="profSup" 
                                Text="Always (5)" oncheckedchanged="rdoProfSupAlways_CheckedChanged" 
                                AutoPostBack="True" />
                        </td>

                        <td class="style88">
                              <asp:RadioButton ID="rdoProfSupRegular" runat="server" GroupName="profSup" 
                                  Text="Regularly (4)" AutoPostBack="True" 
                                  oncheckedchanged="rdoProfSupRegular_CheckedChanged" />
                         </td>
                        <td class="style88">
                           <asp:RadioButton ID="rdoProfSupOften" runat="server" GroupName="profSup" 
                                Text="Often (3)" AutoPostBack="True" 
                                oncheckedchanged="rdoProfSupOften_CheckedChanged" />
                        </td>
                        <td class="style88">
                           <asp:RadioButton ID="rdoProfSupStimes" runat="server" GroupName="profSup" 
                                Text="Sometimes (2)" AutoPostBack="True" 
                                oncheckedchanged="rdoProfSupStimes_CheckedChanged" />
                        </td>
                        <td class="style88">
                        <asp:RadioButton ID="rdoProfSupRare" runat="server" GroupName="profSup" 
                                Text="Rarely (1)" AutoPostBack="True" 
                                oncheckedchanged="rdoProfSupRare_CheckedChanged" />
                        </td>
                        <td class="style88">
                            <asp:TextBox ID="TxtProfSupervisor" runat="server" TextMode="MultiLine" 
                                Width="149px"></asp:TextBox>
                        </td>
                        <td class="style113">
                            <asp:Label ID="LblProfessionalism" runat="server" Text="0.0"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr align="center">
            <td class="style66">
            <table style="width: 936px">
                    <tr>
                        <td class="style106">
                            &nbsp;Communication</td>
                        <td class="style107" colspan="7">
                            <table border="0" cellpadding="0" cellspacing="0" style="border-collapse:
 collapse;width:614pt">
                               
                                <tr>
<td class="style105">
• Presents appropriate information - oral or written, using language, style and tone – in a clear and concise manner with adequate consideration for the objectives of communication and target audience.											
</td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td class="style111">
                           </td>
                        <td class="style109" colspan="5">
                            <strong>Rating</strong></td>
                        <td class="style109">
                            Comments</td>
                        <td class="style112" rowspan="2">
                            Score (%)</td>
                    </tr>
                    <tr>
                        <td class="style104">
                            &nbsp;
                            Job Holder</td>
                       
                       
                       
                        <td class="style88">
                        <asp:RadioButton ID="rdoCommAlways" runat="server" GroupName="comm" Text="Always (5)" />
                        </td>

                        <td class="style88">
                              <asp:RadioButton ID="rdoCommRegular" runat="server" GroupName="comm" Text="Regularly (4)" />
                         </td>
                        <td class="style88">
                           <asp:RadioButton ID="rdoCommOften" runat="server" GroupName="comm" Text="Often (3)" />
                        </td>
                        <td class="style88">
                           <asp:RadioButton ID="rdoCommStimes" runat="server" GroupName="comm" Text="Sometimes (2)" />
                        </td>
                        <td class="style88">
                        <asp:RadioButton ID="rdoCommRare" runat="server" GroupName="comm" Text="Rarely (1)" />
                        </td>
                        <td class="style88">
                            <asp:TextBox ID="TxtCommJHolder" runat="server" TextMode="MultiLine" 
                                Width="149px"></asp:TextBox>
                        </td>
                   
                       
                    </tr>
                    <tr>
                        <td class="style104">
                            &nbsp;
                            Supervisor</td>





                        <td class="style88">
                        <asp:RadioButton ID="rdoComSupAlways" runat="server" GroupName="comSup" 
                                Text="Always (5)" AutoPostBack="True" 
                                oncheckedchanged="rdoComSupAlways_CheckedChanged" />
                        </td>

                        <td class="style88">
                              <asp:RadioButton ID="rdoComSupRegular" runat="server" GroupName="comSup" 
                                  Text="Regularly (4)" AutoPostBack="True" 
                                  oncheckedchanged="rdoComSupRegular_CheckedChanged" />
                         </td>
                        <td class="style88">
                           <asp:RadioButton ID="rdoComSupOften" runat="server" GroupName="comSup" 
                                Text="Often (3)" AutoPostBack="True" 
                                oncheckedchanged="rdoComSupOften_CheckedChanged" />
                        </td>
                        <td class="style88">
                           <asp:RadioButton ID="rdoComSupStimes" runat="server" GroupName="comSup" 
                                Text="Sometimes (2)" AutoPostBack="True" 
                                oncheckedchanged="rdoComSupStimes_CheckedChanged" />
                        </td>
                        <td class="style88">
                        <asp:RadioButton ID="rdoComSupRare" runat="server" GroupName="comSup" 
                                Text="Rarely (1)" AutoPostBack="True" 
                                oncheckedchanged="rdoComSupRare_CheckedChanged" />
                        </td>
                        <td class="style88">
                            <asp:TextBox ID="TxtCommSupervisor" runat="server" TextMode="MultiLine" 
                                Width="149px"></asp:TextBox>
                        </td>
                        <td class="style113">
                            <asp:Label ID="LblCommunication" runat="server">0.0</asp:Label>
                        </td>
                    </tr>
                </table>



            </td>
        </tr>
        <tr align="center">
            <td class="style66">
                <table style="width: 936px">
                    <tr>
                        <td class="style106">
                            &nbsp; Teamwork&nbsp;</td>
                        <td class="style107" colspan="7">
                            <table border="0" cellpadding="0" cellspacing="0" style="border-collapse:
 collapse;width:614pt">
                               
                                <tr>
                                    <td class="style105">
• Ability to develop and maintain effective relationships with others, as well as work in a cooperative and respectful manner with colleagues, interconnected groups and the wider community.
• Ability to persuade or convince others to adopt a specific course of action in order to achieve desired results.											
</td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td class="style111">
                           </td>
                        <td class="style109" colspan="5">
                            <strong>Rating</strong></td>
                        <td class="style109">
                            Comments</td>
                        <td class="style112" rowspan="2">
                            Score (%)</td>
                    </tr>
                    <tr>
                        <td class="style104">
                            &nbsp;
                            Job Holder</td>
                       
                       
                       
                        <td class="style88">
                        <asp:RadioButton ID="rdoTeamAlways" runat="server" GroupName="team" Text="Always (5)" />
                        </td>

                        <td class="style88">
                              <asp:RadioButton ID="rdoTeamRegular" runat="server" GroupName="team" Text="Regularly (4)" />
                         </td>
                        <td class="style88">
                           <asp:RadioButton ID="rdoTeamOften" runat="server" GroupName="team" Text="Often (3)" />
                        </td>
                        <td class="style88">
                           <asp:RadioButton ID="rdoTeamStimes" runat="server" GroupName="team" Text="Sometimes (2)" />
                        </td>
                        <td class="style88">
                        <asp:RadioButton ID="rdoTeamRare" runat="server" GroupName="team" Text="Rarely (1)" />
                        </td>
                        <td class="style88">
                            <asp:TextBox ID="TxtTeamJHolder" runat="server" TextMode="MultiLine" 
                                Width="149px"></asp:TextBox>
                        </td>
                   
                       
                    </tr>
                    <tr>
                        <td class="style104">
                            &nbsp;
                            Supervisor</td>





                        <td class="style88">
                        <asp:RadioButton ID="rdoTeamSupAlways" runat="server" GroupName="teamSup" 
                                Text="Always (5)" AutoPostBack="True" 
                                oncheckedchanged="rdoTeamSupAlways_CheckedChanged" />
                        </td>

                        <td class="style88">
                              <asp:RadioButton ID="rdoTeamSupRegular" runat="server" GroupName="teamSup" 
                                  Text="Regularly (4)" AutoPostBack="True" 
                                  oncheckedchanged="rdoTeamSupRegular_CheckedChanged" />
                         </td>
                        <td class="style88">
                           <asp:RadioButton ID="rdoTeamSupOften" runat="server" GroupName="teamSup" 
                                Text="Often (3)" AutoPostBack="True" 
                                oncheckedchanged="rdoTeamSupOften_CheckedChanged" />
                        </td>
                        <td class="style88">
                           <asp:RadioButton ID="rdoTeamSupStimes" runat="server" GroupName="teamSup" 
                                Text="Sometimes (2)" AutoPostBack="True" 
                                oncheckedchanged="rdoTeamSupStimes_CheckedChanged" />
                        </td>
                        <td class="style88">
                        <asp:RadioButton ID="rdoTeamSupRare" runat="server" GroupName="teamSup" 
                                Text="Rarely (1)" AutoPostBack="True" 
                                oncheckedchanged="rdoTeamSupRare_CheckedChanged" />
                        </td>
                        <td class="style88">
                            <asp:TextBox ID="TxtTeamSupervisor" runat="server" TextMode="MultiLine" 
                                Width="149px"></asp:TextBox>
                        </td>
                        <td class="style113">
                            <asp:Label ID="LblTeamwork" runat="server">0.0</asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr align="center">
            <td class="style66">
               <table style="width: 936px">
                    <tr>
                        <td class="style106">
                            &nbsp; Customer Centricity&nbsp;</td>
                        <td class="style107" colspan="7">
                            <table border="0" cellpadding="0" cellspacing="0" style="border-collapse:
 collapse;width:614pt">
                               
                                <tr>
                                    <td class="style105">
• Ability to identify and anticipate present and future external/ internal customer needs. Provide service excellence to customer.
• Understanding of CDL’s strategy and ideology, structure, products and services, core processes that operates within these parameters.											
</td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td class="style111">
                           </td>
                        <td class="style109" colspan="5">
                            <strong>Rating</strong></td>
                        <td class="style109">
                            Comments</td>
                        <td class="style112" rowspan="2">
                            Score (%)</td>
                    </tr>
                    <tr>
                        <td class="style104">
                            &nbsp;
                            Job Holder</td>
                       
                       
                       
                        <td class="style88">
                        <asp:RadioButton ID="rdoCCAlways" runat="server" GroupName="cc" Text="Always (5)" />
                        </td>

                        <td class="style88">
                              <asp:RadioButton ID="rdoCCRegular" runat="server" GroupName="cc" Text="Regularly (4)" />
                         </td>
                        <td class="style88">
                           <asp:RadioButton ID="rdoCCOften" runat="server" GroupName="cc" Text="Often (3)" />
                        </td>
                        <td class="style88">
                           <asp:RadioButton ID="rdoCCStimes" runat="server" GroupName="cc" Text="Sometimes (2)" />
                        </td>
                        <td class="style88">
                        <asp:RadioButton ID="rdoCCRare" runat="server" GroupName="cc" Text="Rarely (1)" />
                        </td>
                        <td class="style88">
                            <asp:TextBox ID="TxtCCJHolder" runat="server" TextMode="MultiLine" 
                                Width="149px"></asp:TextBox>
                        </td>
                   
                       
                    </tr>
                    <tr>
                        <td class="style104">
                            &nbsp;
                            Supervisor</td>





                        <td class="style88">
                        <asp:RadioButton ID="rdoCCSupAlways" runat="server" GroupName="ccSup" 
                                Text="Always (5)" AutoPostBack="True" 
                                oncheckedchanged="rdoCCSupAlways_CheckedChanged" />
                        </td>

                        <td class="style88">
                              <asp:RadioButton ID="rdoCCSupRegular" runat="server" GroupName="ccSup" 
                                  Text="Regularly (4)" AutoPostBack="True" 
                                  oncheckedchanged="rdoCCSupRegular_CheckedChanged" />
                         </td>
                        <td class="style88">
                           <asp:RadioButton ID="rdoCCSupOften" runat="server" GroupName="ccSup" 
                                Text="Often (3)" AutoPostBack="True" 
                                oncheckedchanged="rdoCCSupOften_CheckedChanged" />
                        </td>
                        <td class="style88">
                           <asp:RadioButton ID="rdoCCSupStimes" runat="server" GroupName="ccSup" 
                                Text="Sometimes (2)" AutoPostBack="True" 
                                oncheckedchanged="rdoCCSupStimes_CheckedChanged" />
                        </td>
                        <td class="style88">
                        <asp:RadioButton ID="rdoCCSupRare" runat="server" GroupName="ccSup" 
                                Text="Rarely (1)" AutoPostBack="True" 
                                oncheckedchanged="rdoCCSupRare_CheckedChanged" />
                        </td>
                        <td class="style88">
                            <asp:TextBox ID="TxtCCSupervisor" runat="server" TextMode="MultiLine" 
                                Width="149px"></asp:TextBox>
                        </td>
                        <td class="style113">
                            <asp:Label ID="LblCustCentricity" runat="server">0.0</asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr align="center">
            <td class="style66">
                <table style="width: 936px">
                    <tr>
                        <td class="style106">
                            &nbsp; Innovation&nbsp;</td>
                        <td class="style107" colspan="7">
                            <table border="0" cellpadding="0" cellspacing="0" style="border-collapse:
 collapse;width:614pt">
                               
                                <tr>
                                    <td class="style105">
                                        • Ability to respond effectively to changing priorities and tasks.
• Ability to demonstrate systemic thinking and appreciate the holistic (direct and indirect) consequences of a course of actions or inactions.										
</td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td class="style111">
                           </td>
                        <td class="style109" colspan="5">
                            <strong>Rating</strong></td>
                        <td class="style109">
                            Comments</td>
                        <td class="style112" rowspan="2">
                            Score (%)</td>
                    </tr>
                    <tr>
                        <td class="style104">
                            &nbsp;
                            Job Holder</td>
                       
                       
                       
                        <td class="style88">
                        <asp:RadioButton ID="rdoInnoAlways" runat="server" GroupName="inno" Text="Always (5)" />
                        </td>

                        <td class="style88">
                              <asp:RadioButton ID="rdoInnoRegular" runat="server" GroupName="inno" Text="Regularly (4)" />
                         </td>
                        <td class="style88">
                           <asp:RadioButton ID="rdoInnoOften" runat="server" GroupName="inno" Text="Often (3)" />
                        </td>
                        <td class="style88">
                           <asp:RadioButton ID="rdoInnoStimes" runat="server" GroupName="inno" Text="Sometimes (2)" />
                        </td>
                        <td class="style88">
                        <asp:RadioButton ID="rdoInnoRare" runat="server" GroupName="inno" Text="Rarely (1)" />
                        </td>
                        <td class="style88">
                            <asp:TextBox ID="TxtInnoJHolder" runat="server" TextMode="MultiLine" 
                                Width="149px"></asp:TextBox>
                        </td>
                   
                       
                    </tr>
                    <tr>
                        <td class="style104">
                            &nbsp;
                            Supervisor</td>





                        <td class="style88">
                        <asp:RadioButton ID="rdoInnoSupAlways" runat="server" GroupName="innoSup" 
                                Text="Always (5)" AutoPostBack="True" 
                                oncheckedchanged="rdoInnoSupAlways_CheckedChanged" />
                        </td>

                        <td class="style88">
                              <asp:RadioButton ID="rdoInnoSupRegular" runat="server" GroupName="innoSup" 
                                  Text="Regularly (4)" AutoPostBack="True" 
                                  oncheckedchanged="rdoInnoSupRegular_CheckedChanged" />
                         </td>
                        <td class="style88">
                           <asp:RadioButton ID="rdoInnoSupOften" runat="server" GroupName="innoSup" 
                                Text="Often (3)" AutoPostBack="True" 
                                oncheckedchanged="rdoInnoSupOften_CheckedChanged" />
                        </td>
                        <td class="style88">
                           <asp:RadioButton ID="rdoInnoSupStimes" runat="server" GroupName="innoSup" 
                                Text="Sometimes (2)" AutoPostBack="True" 
                                oncheckedchanged="rdoInnoSupStimes_CheckedChanged" />
                        </td>
                        <td class="style88">
                        <asp:RadioButton ID="rdoInnoSupRare" runat="server" GroupName="innoSup" 
                                Text="Rarely (1)" AutoPostBack="True" 
                                oncheckedchanged="rdoInnoSupRare_CheckedChanged" />
                        </td>
                        <td class="style88">
                            <asp:TextBox ID="TxtInnoSupervisor" runat="server" TextMode="MultiLine" 
                                Width="149px"></asp:TextBox>
                        </td>
                        <td class="style113">
                            <asp:Label ID="LblInnovation" runat="server">0.0</asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr align="center">
            <td class="style66">
               <table style="width: 936px">
                    <tr>
                        <td class="style106">
                            &nbsp; Leadership&nbsp;</td>
                        <td class="style107" colspan="7">
                            <table border="0" cellpadding="0" cellspacing="0" style="border-collapse:
 collapse;width:614pt">
                               
                                <tr>
                                    <td class="style105">
              • Ability to make things happen by articulating a clear direction for completion of tasks and allocating skilled resources.
• Ability to provide focus and encourage others, taking initiative to provide assistance to other persons that will facilitate achievement of the key objectives of CDL.</td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td class="style111">
                           </td>
                        <td class="style109" colspan="5">
                            <strong>Rating</strong></td>
                        <td class="style109">
                            Comments</td>
                        <td class="style112" rowspan="2">
                            Score (%)</td>
                    </tr>
                    <tr>
                        <td class="style104">
                            &nbsp;
                            Job Holder</td>
                       
                       
                       
                        <td class="style88">
                        <asp:RadioButton ID="rdoLeadAlways" runat="server" GroupName="lead" Text="Always (5)" />
                        </td>

                        <td class="style88">
                              <asp:RadioButton ID="rdoLeadRegular" runat="server" GroupName="lead" Text="Regularly (4)" />
                         </td>
                        <td class="style88">
                           <asp:RadioButton ID="rdoLeadOften" runat="server" GroupName="lead" Text="Often (3)" />
                        </td>
                        <td class="style88">
                           <asp:RadioButton ID="rdoLeadStimes" runat="server" GroupName="lead" Text="Sometimes (2)" />
                        </td>
                        <td class="style88">
                        <asp:RadioButton ID="rdoLeadRare" runat="server" GroupName="lead" Text="Rarely (1)" />
                        </td>
                        <td class="style88">
                            <asp:TextBox ID="TxtLeadJHolder" runat="server" TextMode="MultiLine" 
                                Width="149px"></asp:TextBox>
                        </td>
                   
                       
                    </tr>
                    <tr>
                        <td class="style104">
                            &nbsp;
                            Supervisor</td>





                        <td class="style88">
                        <asp:RadioButton ID="rdoLeadSupAlways" runat="server" GroupName="leadSup" 
                                Text="Always (5)" AutoPostBack="True" 
                                oncheckedchanged="rdoLeadSupAlways_CheckedChanged" />
                        </td>

                        <td class="style88">
                              <asp:RadioButton ID="rdoLeadSupRegular" runat="server" GroupName="leadSup" 
                                  Text="Regularly (4)" AutoPostBack="True" 
                                  oncheckedchanged="rdoLeadSupRegular_CheckedChanged" />
                         </td>
                        <td class="style88">
                           <asp:RadioButton ID="rdoLeadSupOften" runat="server" GroupName="leadSup" 
                                Text="Often (3)" AutoPostBack="True" 
                                oncheckedchanged="rdoLeadSupOften_CheckedChanged" />
                        </td>
                        <td class="style88">
                           <asp:RadioButton ID="rdoLeadSupStimes" runat="server" GroupName="leadSup" 
                                Text="Sometimes (2)" AutoPostBack="True" 
                                oncheckedchanged="rdoLeadSupStimes_CheckedChanged" />
                        </td>
                        <td class="style88">
                        <asp:RadioButton ID="rdoLeadSupRare" runat="server" GroupName="leadSup" 
                                Text="Rarely (1)" AutoPostBack="True" 
                                oncheckedchanged="rdoLeadSupRare_CheckedChanged" />
                        </td>
                        <td class="style88">
                            <asp:TextBox ID="TxtLeadSupervisor" runat="server" TextMode="MultiLine" 
                                Width="149px"></asp:TextBox>
                        </td>
                        <td class="style113">
                            <asp:Label ID="LblLeadership" runat="server">0.0</asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr align="center">
            <td class="style118">
                <table style="width: 936px">
                    <tr>
                        <td class="style106">
                            Personal Effectiveness&nbsp;</td>
                        <td class="style107" colspan="7">
                            <table border="0" cellpadding="0" cellspacing="0" style="border-collapse:
 collapse;width:614pt">
                               
                                <tr>
                                    <td class="style105">
       • Ability to demonstrate essential skills which ensure that work is performed in the most efficient manner and tasks are accomplished as planned, while minimising stress and maximising learning opportunities.											
</td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td class="style111">
                           </td>
                        <td class="style109" colspan="5">
                            <strong>Rating</strong></td>
                        <td class="style109">
                            Comments</td>
                        <td class="style112" rowspan="2">
                            Score (%)</td>
                    </tr>
                    <tr>
                        <td class="style104">
                            &nbsp;
                            Job Holder</td>
                       
                       
                       
                        <td class="style88">
                        <asp:RadioButton ID="rdoPEAlways" runat="server" GroupName="pe" Text="Always (5)" />
                        </td>

                        <td class="style88">
                              <asp:RadioButton ID="rdoPERegular" runat="server" GroupName="pe" Text="Regularly (4)" />
                         </td>
                        <td class="style88">
                           <asp:RadioButton ID="rdoPEOften" runat="server" GroupName="pe" Text="Often (3)" />
                        </td>
                        <td class="style88">
                           <asp:RadioButton ID="rdoPEStimes" runat="server" GroupName="pe" Text="Sometimes (2)" />
                        </td>
                        <td class="style88">
                        <asp:RadioButton ID="rdoPERare" runat="server" GroupName="pe" Text="Rarely (1)" />
                        </td>
                        <td class="style88">
                            <asp:TextBox ID="TxtPEJHolder" runat="server" TextMode="MultiLine" 
                                Width="149px"></asp:TextBox>
                        </td>
                   
                       
                    </tr>
                    <tr>
                        <td class="style104">
                            &nbsp;
                            Supervisor</td>





                        <td class="style88">
                        <asp:RadioButton ID="rdoPESupAlways" runat="server" GroupName="peSup" 
                                Text="Always (5)" AutoPostBack="True" 
                                oncheckedchanged="rdoPESupAlways_CheckedChanged" />
                        </td>

                        <td class="style88">
                              <asp:RadioButton ID="rdoPESupRegular" runat="server" GroupName="peSup" 
                                  Text="Regularly (4)" AutoPostBack="True" 
                                  oncheckedchanged="rdoPESupRegular_CheckedChanged" />
                         </td>
                        <td class="style88">
                           <asp:RadioButton ID="rdoPESupOften" runat="server" GroupName="peSup" 
                                Text="Often (3)" AutoPostBack="True" 
                                oncheckedchanged="rdoPESupOften_CheckedChanged" />
                        </td>
                        <td class="style88">
                           <asp:RadioButton ID="rdoPESupStimes" runat="server" GroupName="peSup" 
                                Text="Sometimes (2)" AutoPostBack="True" 
                                oncheckedchanged="rdoPESupStimes_CheckedChanged" />
                        </td>
                        <td class="style88">
                        <asp:RadioButton ID="rdoPESupRare" runat="server" GroupName="peSup" 
                                Text="Rarely (1)" AutoPostBack="True" 
                                oncheckedchanged="rdoPESupRare_CheckedChanged" />
                        </td>
                        <td class="style88">
                            <asp:TextBox ID="TxtPESupervisor" runat="server" TextMode="MultiLine" 
                                Width="149px"></asp:TextBox>
                        </td>
                        <td class="style113">
                            <asp:Label ID="LblPerEffect" runat="server">0.0</asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="style123">
                            &nbsp;</td>





                        <td class="style122">
                            &nbsp;</td>

                        <td class="style88">
                              &nbsp;</td>
                        <td class="style88">
                            &nbsp;</td>
                        <td class="style88">
                            &nbsp;</td>
                        <td class="style88">
                            &nbsp;</td>
                        <td class="style88">
                            &nbsp;</td>
                        <td class="style113">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style121" colspan="7">
                            Total Score (%)</td>





                        <td class="style119">
                            <asp:Label ID="LblTotalScore" runat="server">0.0</asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr align="center">
            <td class="style66">
                &nbsp;</td>
        </tr>
        <tr align="center">
            <td class="style66">
              
<asp:Button ID="btnRateSubordinate" runat="server" Text="Rate your Subordinate" Width="181px" 
                    onclick="btnRateSubordinate_Click" />
                 
            </td>
        </tr>
    </table>

    </asp:Panel>