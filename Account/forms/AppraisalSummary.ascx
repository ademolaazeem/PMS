<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AppraisalSummary.ascx.cs" Inherits="Account_forms_AppraisalSummary" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<style type="text/css">


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
            .font5
	{color:windowtext;
	font-size:16.0pt;
	font-weight:400;
	font-style:italic;
	text-decoration:none;
	font-family:Arial, sans-serif;
	}
            .style125
            {
                background-color: #CCCCCC;
                width: 122px;
            }
            .style126
            {
                height: 71px;
            }
            .style127
            {
                background-color: #FFFFFF;
                color: #FFFFFF;
                }
            .style128
            {
                background-color: #999999;
                color: #FFFFFF;
                height: 34px;
                text-align: left;
                width: 145px;
            }
            .style129
            {
                height: 34px;
                width: 122px;
            }
            .style130
            {
                background-color: #999999;
                color: #FFFFFF;
                width: 108px;
                font-weight: bold;
            }
            .style131
            {
                height: 34px;
                width: 108px;
            }
            .style133
            {
                background-color: #FF0000;
                width: 108px;
            }
            .style136
            {
                width: 332px;
                color: #FFFFFF;
                background-color: #999999;
            }
            .style137
            {
                width: 859px;
                height: 150px;
            }
            .font6
	{color:white;
	font-size:16.0pt;
	font-weight:700;
	font-style:normal;
	text-decoration:none;
	font-family:Arial, sans-serif;
	}
.font7
	{color:white;
	font-size:16.0pt;
	font-weight:400;
	font-style:italic;
	text-decoration:none;
	font-family:Arial, sans-serif;
	}
            .style145
            {
                width: 859px;
            }
            .style146
            {
                width: 859px;
                text-align: left;
            }
            .style147
            {
                width: 713px;
            }
        .style100
        {
        width: 400px;
        text-align: center;
        background-color: #CCCCCC;
    }
        .style101
        {
        width: 350px;
        text-align: center;
    }
        .style103
    {
        width: 142px;
        text-align: center;
        background-color: #CCCCCC;
    }
        .style102
        {
        width: 500px;
        background-color: #FFFFFF;
    }
            .style148
            {
                background-color: #999999;
                color: #FFFFFF;
                height: 8px;
                text-align: left;
                width: 145px;
            }
            .style149
            {
                height: 8px;
                width: 122px;
            }
            .style150
            {
                height: 8px;
                width: 108px;
            }
            .style151
            {
                width: 145px;
                background-color: #FFFFFF;
            }


.stylehr
    {
        color:White;
    }
            .style152
            {
                background-color: #999999;
                color: #FFFFFF;
                font-weight: bold;
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
                <asp:CheckBox ID="chkSignConcurrent" runat="server" AutoPostBack="True" 
                    oncheckedchanged="chkSignConcurrent_CheckedChanged" Text="Sign Concurrent Signature" 
                    Visible="False" />
            </td>
        </tr>
        <tr>
            <td class="style35">
                <asp:Label ID="LblSubName" runat="server" Text="Select Subordinate name:"></asp:Label>
            </td>
            <td class="style36" rowspan="2">
                 <asp:DropDownList ID="DDLSubName" runat="server" Height="28px" Width="293px">
                 </asp:DropDownList>
            </td>
        </tr>
        
        <tr>
            <td class="style35">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style40">
                <asp:Label ID="LblConcurrent" runat="server" 
                    Text="Select Employee for Concurrent Review:"></asp:Label>
            </td>
            <td class="style39">
                <asp:DropDownList ID="DDLConcurrent" runat="server" Height="28px" Width="293px">
                </asp:DropDownList>
            </td>
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
    <table>
        <tr>
    <td>
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
            <td class="style145">
                <table style="width: 925px" class="style29">
                    <tr>
                        <td align="right" bgcolor="Silver" class="style21">
                            &nbsp;</td>
                        <td bgcolor="Silver" class="style99">
                            <asp:Label ID="lblStatus" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td bgcolor="#CCCCFF" colspan="2" class="style126">
                            <asp:Label ID="Label12" runat="server" Font-Bold="True" ForeColor="Black" 
                Text="Appraisal Summary"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr align="center" style="text-align: left">
            <td class="style145">
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
                 
                </table>
 </td>
        </tr>
        <tr align="center">
            <td class="style137">
                <table align="left" cellpadding="5" cellspacing="5" style="width: 921px">
                    <tr>
                        <td class="style151">
                            &nbsp;</td>
                        <td class="style152">
                            Weight</td>
                        <td class="style130">
                            Score</td>
                    </tr>
                    <tr>
                        <td class="style128">
                            Performance Results</td>
                        <td class="style129">
                            70%</td>
                        <td class="style131">
                            <asp:Label ID="lblPR" runat="server" Text="0.0"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="style148">
                            Behavioural Competencies</td>
                        <td class="style149">
                            30%</td>
                        <td class="style150">
                            <asp:Label ID="lblBC" runat="server" Text="0.0"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="style151">
                            &nbsp;</td>
                        <td class="style125">
                            100%</td>
                        <td class="style133">
                            <asp:Label ID="lblTotalPerformanceScore" runat="server" Text="0.0"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="style145"> 
                <table align="left" cellpadding="5" cellspacing="5" style="width: 921px">
                    <tr>
                        <td class="style136">
                            Overall Rating/Category</td>
                        <td class="style127">
                            <asp:TextBox ID="TxtRating" runat="server" TextMode="MultiLine" Width="557px" 
                                ></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
     </table>
            </td>
        </tr>
        <tr align="center">
            <td class="style146">
            <table style="width: 936px">
                     <tr>
                        <td style="color: #FFFFFF; background-color: #999999">
                            <strong>Key Achievements- To Be Completed by Job Holder </strong>
                            <br />
                            (Document below key contributions/strength areas relative to the agreed 
                            goals/targets)
                        </td>
                   
                       
                    </tr>
                    <tr>
                        <td>
                            &nbsp;<asp:TextBox ID="TxtKeyAch" runat="server" TextMode="MultiLine" Width="733px"></asp:TextBox>
                        </td>
                    </tr>
                </table>



            </td>
        </tr>



        <tr align="center">
            <td class="style146">
            <table style="width: 936px">
                     <tr>
                        <td style="color: #FFFFFF; background-color: #999999">
                            <strong>Key Strengths- To Be Completed by Supervisor</strong>
                            <br />
                            (Document below key contributions/strength areas of the job holder relative to the agreed goals/targets)
                        </td>
                   
                       
                    </tr>
                    <tr>
                        <td>
                            &nbsp;<asp:TextBox ID="TxtKeyStr" runat="server" TextMode="MultiLine" Width="733px"></asp:TextBox>
                        </td>
                    </tr>
                </table>



            </td>
        </tr>

        <tr align="center">
            <td class="style146">
            <table style="width: 936px">
                     <tr>
                        <td style="color: #FFFFFF; background-color: #999999">
                            <strong>Areas for Improvement - To Be Completed by Supervisor                                                                                                                                   </strong>
                            <br />
                            (Document below key areas for improvement for the job holder relative to the agreed goals/targets)</td>
                                       
                    </tr>
                    <tr>
                        <td>
                            &nbsp;<asp:TextBox ID="TxtImpArea" runat="server" TextMode="MultiLine" 
                                Width="733px"></asp:TextBox>
                        </td>
                    </tr>
                </table>



            </td>
        </tr>


        <tr align="center">
            <td class="style146">
            <table style="width: 936px">
                     <tr>
                        <td style="color: #FFFFFF; background-color: #999999">
                            <strong>Proposed Development Activities  - To Be Completed by Supervisor</strong>
                            <br />
                            (Document below the key areas where performance improvement is required relative to the defined goals)
                        </td>
                   
                       
                    </tr>
                    <tr>
                        <td>
                            &nbsp;<asp:TextBox ID="TxtProposedDev" runat="server" TextMode="MultiLine" 
                                Width="733px"></asp:TextBox>
                        </td>
                    </tr>
                </table>



            </td>
        </tr>


        <tr align="center">
            <td class="style146">
            <table style="width: 936px">
                     <tr>
                        <td style="color: #FFFFFF; background-color: #999999">
                            <strong>Concurrent Supervisor's Comments </strong>
                           
                        </td>
                   
                       
                    </tr>
                    <tr>
                        <td>
                            &nbsp;<asp:TextBox ID="TxtConcurrentCmt" runat="server" TextMode="MultiLine" 
                                Width="733px"></asp:TextBox>
                        </td>
                    </tr>
                </table>



            </td>
        </tr>


        <tr align="center">
            <td class="style146">
            <table style="width: 936px; height: 31px;">
                     <tr>
                        <td style="color: #000000; background-color: #FFFFFF" class="style147">
                            <strong>I have read and discussed this evaluation with my supervisor and I agree with the overall appraisal and its contents.  </strong>
                           
                        </td>
                   
                       
                         <td style="color: #000000; background-color: #999999">
                             <asp:RadioButton ID="rdoAccept" runat="server" GroupName="accRej" 
                                 Text="Accept" />
                         </td>
                   
                       
                    </tr>
                </table>



            </td>
        </tr>


        <tr align="center">
            <td class="style146">
           
           <table style="width: 936px; height: 31px;">
                     <tr>
                        <td style="color: #000000; background-color: #FFFFFF" class="style147">
                            <strong>I have read and discussed this evaluation with my supervisor and I do  not agree with the overall appraisal and its contents. </strong>
                           
                        </td>
                   
                       
                         <td style="color: #000000; background-color: #999999">
                             <asp:RadioButton ID="rdoReject" runat="server" GroupName="accRej" 
                                 Text="Reject" />
                         </td>
                   
                       
                    </tr>
                </table>



            </td>
        </tr>


        <tr align="center">
            <td class="style146">
            <table style="width: 936px">
                     <tr>
                        <td style="color: #FFFFFF; background-color: #999999">
                            <strong>Document reason(s) for rejecting appraisal </strong>
                           
                        </td>
                   
                       
                    </tr>
                    <tr>
                        <td>
                            &nbsp;<asp:TextBox ID="TxtReasons" runat="server" TextMode="MultiLine" 
                                Width="733px" Height="60px"></asp:TextBox>
                        </td>
                    </tr>
                </table>



            </td>
        </tr>

        <tr align="center">
            <td class="style146">
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
                           
                            <asp:DropDownList ID="DDLHolderYear" runat="server">
                           
                            </asp:DropDownList>
                            &nbsp;
                            <asp:DropDownList ID="DDLHolderMonth" runat="server">
                            <%--onselectedindexchanged="DDLHolderMonth_SelectedIndexChanged"--%>
                            </asp:DropDownList>
                            &nbsp;
                            <asp:DropDownList ID="DDLHolderDay" runat="server">
                            </asp:DropDownList>
                            
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
                 <asp:DropDownList ID="DDLAppraiserYear" runat="server" AutoPostBack="True">
                 </asp:DropDownList>
           &nbsp;<asp:DropDownList ID="DDLAppraiserMonth" runat="server" AutoPostBack="True"></asp:DropDownList>
           &nbsp;<asp:DropDownList ID="DDLAppraiserDay" runat="server"></asp:DropDownList>
                           
                        </td>
                    </tr>
                    <tr>
                        <td class="style100">
                            <asp:Label ID="LblConcurrentSign" runat="server">Concurrent Reviewer&#39;s Signature</asp:Label>
                        </td>
                        <td class="style101">
                            <asp:Label ID="LblConcurrentSignShow" runat="server"></asp:Label>
                        </td>
                        <td class="style103">
                            <asp:Label ID="LblAppraiserDate0" runat="server">Date <i>yyyy/m/d</i></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="DDLConcurrentYear" runat="server" AutoPostBack="True">
                            </asp:DropDownList>
                            <asp:DropDownList ID="DDLConcurrentMonth" runat="server" AutoPostBack="True" ></asp:DropDownList>
                            <asp:DropDownList ID="DDLConcurrentDay" runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>
                </table>
           



            </td>
        </tr>

        
        <tr align="center">
            <td class="style146">
              
<asp:Button ID="btnRateSubordinate" runat="server" Text="Rate your Subordinate" Width="181px" 
                    onclick="btnRateSubordinate_Click" />
                 
            </td>
        </tr>
    </table>

    </asp:Panel>
