<%@ Control Language="C#" AutoEventWireup="true" CodeFile="JobDescriptionsMgmt.ascx.cs" Inherits="Account_forms_JobDescriptionsMgmt" %>
<style type="text/css">

    .style21
    {
        width: 306px;
    }
    .style16
    {
        width: 306px;
        height: 36px;
        text-align: right;
    }
    .style26
    {
        height: 36px;
    }
        .style6
    {
        width: 306px;
        background-color: #CCCCFF;
        text-align: right;
    }
    .style7
    {
        background-color: #CCCCFF;
        }
    .style3
    {
        width: 320px;
        background-color: #CCCCFF;
        text-align: right;
    }
    .style22
    {
        height: 50px;
        width: 306px;
        background-color: #FFFFFF;
    }
    .style18
    {
        height: 50px;
        background-color: #FFFFFF;
    }
    .style11
    {
        width: 306px;
        background-color: #CCCCFF;
        text-align: right;
        height: 73px;
    }
    .style2
    {
        background-color: #CCCCFF;
        height: 73px;
    }
    .style23
    {
        width: 306px;
        background-color: #FFFFFF;
        text-align: right;
    }
    .style12
    {
        background-color: #FFFFFF;
    }
    .style13
    {
        width: 306px;
        height: 23px;
        background-color: #CCCCFF;
    }
    .style25
    {
        background-color: #CCCCFF;
        height: 23px;
    }
    .Gridview
        {
        margin-right: 170px;
    }
        .style27
    {
        width: 993px;
    }
    .style28
    {
        width: 987px;
    }
        .style29
    {
        background-color: #FFFFFF;
        height: 26px;
    }
    .style30
    {
        width: 306px;
        background-color: #FFFFFF;
        height: 26px;
        text-align: right;
    }
        .style31
    {
        width: 306px;
        background-color: #CCCCFF;
        text-align: right;
        height: 124px;
    }
    .style32
    {
        background-color: #CCCCFF;
        height: 124px;
    }
        </style>

<table class="style27">
    <tr>
        <td class="style28">

<table style="width:85%;">
    <tr>
        <td align="right" bgcolor="Silver" class="style21">
            &nbsp;</td>
        <td bgcolor="Silver">
            <asp:Label ID="lblStatus" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td bgcolor="#CCCCFF" colspan="2">
            <asp:Label ID="Label12" runat="server" Font-Bold="True" ForeColor="Black" 
                Text="Create Job Descriptions"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="style16">
            Position:</td>
        <td class="style26">
            <asp:DropDownList ID="DDLPositions" runat="server" 
                style="margin-left: 0px" Width="295px">
                <asp:ListItem Selected="True" Value="0">Select Position</asp:ListItem>
            </asp:DropDownList>
            </td>
    </tr>
    <tr>
        <td class="style6">
            Reports to:</td>
        <td class="style7">
            <asp:DropDownList ID="DDLReportsTo" runat="server" Width="295px">
                <asp:ListItem Selected="True" Value="0">Select Reports To</asp:ListItem>
            </asp:DropDownList>
            </td>
    </tr>
    <tr>
        <td class="style30">
            Concurrent Sign off</td>
        <td class="style29">
            <asp:DropDownList ID="DDLConcurrent" runat="server" Width="295px">
                <asp:ListItem Selected="True" Value="0">Select Concurrent Signoff</asp:ListItem>
            </asp:DropDownList>
            </td>
    </tr>
    <tr>
        <td class="style31">
            Supervises:</td>
        <td class="style32">
            <asp:ListBox ID="DDLSupervises" runat="server" SelectionMode="Multiple" 
                Height="175px" Width="198px"></asp:ListBox>
            <asp:ListBox ID="DDLSupervisesHide" runat="server" SelectionMode="Multiple" 
                Visible="False" Height="175px" Width="100px"></asp:ListBox>
            </td>
    </tr>
    <tr class="style3">
        <td class="style22">
            Job Summary:</td>
        <td class="style18" style="text-align: left">
            <asp:TextBox ID="TxtJobSummary" runat="server" BorderStyle="Solid" 
                Height="77px" TextMode="MultiLine" Width="295px"></asp:TextBox>
            </td>
    </tr>
    <tr>
        <td class="style11">
            Principal Duties and Responsibilities:</td>
        <td class="style2">
            <asp:TextBox ID="TxtPDnResp" runat="server" BorderStyle="Solid" Height="96px" 
                TextMode="MultiLine" Width="295px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="style23">
            Competency and Skill Requirements:</td>
        <td class="style12">
            <asp:TextBox ID="TxtCnSReq" runat="server" BorderStyle="Solid" Height="105px" 
                TextMode="MultiLine" Width="295px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="style21">
            </td>
        <td>
            </td>
    </tr>
    <tr>
        <td class="style13">
            <asp:HiddenField ID="positionId" runat="server" />
            <asp:HiddenField ID="JDId" runat="server" />
            </td>
        <td class="style25">
            <asp:Button ID="btnUpdateJD" runat="server" 
                onclick="btnUpdateJD_Click" Text="Save Job Description Now" 
                Height="31px" />
        </td>
    </tr>
</table>

        </td>
    </tr>
    <tr align="center">
        <td class="style28">
           

           <asp:GridView ID="Gridview1" runat="server" AllowPaging="True" PageSize="6"
                AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" 
                CssClass="Gridview" DataKeyNames="id" ForeColor="#333333" GridLines="Both" 
                OnPageIndexChanging="Gridview1_PageIndexChanging" 
                onselectedindexchanged="Gridview1_SelectedIndexChanged" 
                OnSorting="Gridview1_Sorting" Width="987px">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:TemplateField HeaderText="">
                        <ItemTemplate>
                            <div style="white-space: nowrap; clear: none; width: 100%; display: inline;">
                                <%--<asp:LinkButton ID="btnDelete" runat="server" CommandName="Delete" 
                                    OnClientClick="return confirm('Are you sure you want to delete this record?');">
                                        
                                        <asp:Image ID="imgDelete" ImageUrl="~/Account/images/imgdelete1.png" runat="server" /> 
                                        </asp:LinkButton>--%>
                            </div>
                            <div style="white-space: nowrap; clear: none; width: 100%; display: inline;">
                                <asp:LinkButton ID="btnEdit" runat="server" CommandName="Select">
                                        
                                        <asp:Image ID="Image1" ImageUrl="~/Account/images/edit.png" runat="server" /> 
                                        </asp:LinkButton>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>
 <asp:BoundField DataField="id" HeaderText="ID" SortExpression="id" />
 <asp:BoundField DataField="position_id" HeaderText="position_id" SortExpression="position_id" />
 <%--<asp:BoundField DataField="superv_id" HeaderText="superv_id" SortExpression="superv_id" /> --%>
 <asp:BoundField DataField="position" HeaderText="POSITION" SortExpression="position" />

<asp:BoundField DataField="reports_to" HeaderText="REPORTS TO" SortExpression="reports_to" />
<asp:BoundField DataField="SUPERVISES" HeaderText="SUPERVISES" SortExpression="SUPERVISES" />

<asp:BoundField DataField="JOB_SUMMARY" HeaderText="JOB SUMMARY" SortExpression="JOB_SUMMARY" />
<asp:BoundField DataField="PRINCIPAL_DUTIES" HeaderText="PRINCIPAL DUTIES AND RESPONSIBILITIES" SortExpression="PRINCIPAL_DUTIES" />
<asp:BoundField DataField="COMPETENCY" HeaderText="COMPETENCY AND SKILL REQUIREMENTS" SortExpression="COMPETENCY" />
<asp:BoundField DataField="CONCURRENT_SIGN_OFF" HeaderText="CONCURRENT SIGNOFF" SortExpression="CONCURRENT_SIGN_OFF" />
<asp:BoundField DataField="reports_to_id" HeaderText="Reports to id" SortExpression="reports_to_id" />
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
            

        </td>
    </tr>
</table>



