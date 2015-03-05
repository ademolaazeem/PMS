<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EmployeesMgmt.ascx.cs" Inherits="Account_forms_EmployeesMgmt" %>
<style type="text/css">

    .style28
    {
        width: 895px;
    }
        
    .style16
    {
        width: 28px;
        height: 36px;
        text-align: right;
    }
        .style26
    {
        height: 36px;
        width: 288px;
    }
        .style29
    {
        width: 28px;
        background-color: #CCCCFF;
        text-align: right;
        height: 23px;
    }
    .style30
    {
        background-color: #CCCCFF;
        width: 288px;
        height: 23px;
    }
    .style32
    {
        width: 28px;
        background-color: #FFFFFF;
        text-align: right;
    }
        .style31
    {
        background-color: #FFFFFF;
        width: 288px;
    }
        .style6
    {
        /*width: 75px;*/
        width: 28px;
        background-color: #CCCCFF;
        text-align: right;
    }
    .style7
    {
        background-color: #CCCCFF;
        width: 288px;
    }
    .Gridview
        {
        margin-right: 170px;
    }
        .style33
    {
        text-align: left;
        height: 34px;
    }
        .style34
    {
        /*width: 75px;*/
        width: 28px;
        background-color: #CCCCFF;
        text-align: right;
        height: 35px;
    }
    .style35
    {
        background-color: #CCCCFF;
        width: 288px;
        height: 35px;
    }
        .style36
    {
        width: 28px;
        background-color: #FFFFFF;
        text-align: right;
        height: 24px;
    }
    .style37
    {
        background-color: #FFFFFF;
        width: 288px;
        height: 24px;
    }
        </style>

<table style="width:77%;">
    <tr>
        <td class="style28">

<table style="width:979px;">
    <tr>
        <td align="right" bgcolor="Silver" class="style33" colspan="2">
            <asp:Label ID="lblStatus" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td bgcolor="#CCCCFF" colspan="2">
            <asp:Label ID="Label12" runat="server" Font-Bold="True" ForeColor="Black" 
                Text="Create Employees Information"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="style16">
            Username:</td>
        <td class="style26">
            <asp:DropDownList ID="DDLUsername"  runat="server" Height="28px" 
                Width="293px">
            </asp:DropDownList>
            </td>
    </tr>
    <tr>
        <td class="style29">
            </td>
        <td class="style30">
            </td>
    </tr>
    <tr>
        <td class="style32">
            Position:</td>
        <td class="style31">
            <asp:DropDownList ID="DDLPositions" runat="server" Height="30px" Width="293px" 
                onselectedindexchanged="DDLPositions_SelectedIndexChanged" 
                AutoPostBack="True">
                <asp:ListItem Value="">Select Position</asp:ListItem>
            </asp:DropDownList>
            <asp:HiddenField ID="employeeId" runat="server" />
            </td>
    </tr>
    <tr>
        <td class="style34">
            Department:</td>
        <td class="style35" align="left">
            <asp:TextBox ID="txtDepartment" runat="server" Enabled="False" Width="288px"></asp:TextBox>
            </td>
    </tr>
    <tr>
        <td class="style36">
            </td>
        <td class="style37" align="left">
            <asp:HiddenField ID="hDeptId" runat="server" />
            </td>
    </tr>
    <tr>
        <td class="style6">
            &nbsp;</td>
        <td class="style7" align="left">
            <asp:Button ID="btnUpdateEmployees" runat="server" 
                onclick="btnUpdateEmployees_Click" Text="Update Employee" 
                Height="31px" />
            </td>
    </tr>
    <tr>
        <td class="style32">
            <%--Employee Name:--%>
            <asp:Button ID="btnRefreshDb" runat="server" onclick="btnRefreshDb_Click" 
                Text="Refresh Employee Info from Human Manager" />
        </td>
        <td class="style31" align="left">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style6">
            &nbsp;</td>
        <td class="style7" align="left">
            <asp:DropDownList ID="DDLEmployee"  runat="server" Height="28px" 
                Width="293px">
            </asp:DropDownList>
            </td>
    </tr>
    <tr>
        <td class="style32">
            &nbsp;</td>
        <td class="style31" align="left">
            <asp:Button ID="btnSearchDepartment" runat="server" 
                onclick="btnSearchEmployee_Click" Text="Search Employee Now" 
                Height="31px" />
            </td>
    </tr>
    <tr>
        <td class="style6">
            &nbsp;</td>
        <td class="style7" align="left">
            &nbsp;</td>
    </tr>
    </table>

        </td>
    </tr>
    <tr align="center">
        <td class="style28">
           

           <asp:GridView ID="Gridview1" runat="server" AllowPaging="True" PageSize="20"
                AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" BorderWidth="1px" 
                CssClass="Gridview" DataKeyNames="EMPLOYEE_NO" ForeColor="#333333" GridLines ="Both" 
                OnPageIndexChanging="Gridview1_PageIndexChanging" 
                onrowcommand="GridView1_RowCommand" 
                onselectedindexchanged="Gridview1_SelectedIndexChanged" 
                OnSorting="Gridview1_Sorting" Width="979px">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    
                    
                    <%--<asp:TemplateField HeaderText="">
                        <ItemTemplate>
                            <div style="white-space: nowrap; clear: none; width: 100%; display: inline;">
                                <asp:LinkButton ID="btnDelete" runat="server" CommandName="Delete" 
                                    OnClientClick="return confirm('Are you sure you want to delete this record?');">
                                        
                                        <asp:Image ID="imgDelete" ImageUrl="~/Account/images/imgdelete1.png" runat="server" /> 
                                </asp:LinkButton>
                            </div>
                            <div style="white-space: nowrap; clear: none; width: 100%; display: inline;">
                                <asp:LinkButton ID="btnEdit" runat="server" CommandName="Select">
                                        
                                        <asp:Image ID="Image1" ImageUrl="~/Account/images/edit.png" runat="server" /> 
                                        </asp:LinkButton>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>
                    --%>




                    <asp:TemplateField HeaderText="S/N">
                        <ItemTemplate>
                              
                                <%#Container.DataItemIndex+1 %>
                           
                        </ItemTemplate>
                    </asp:TemplateField>

 <asp:BoundField DataField="EMPLOYEE_NO" HeaderText="EMPLOYEE NO" SortExpression="EMPLOYEE_NO" />
 <asp:BoundField DataField="NAME" HeaderText="NAME" SortExpression="NAME" />
 <asp:BoundField DataField="POSITION_OR_JOBROLE" HeaderText="POSITION" SortExpression="POSITION_OR_JOBROLE" />
<asp:BoundField DataField="DEPARTMENT" HeaderText="DEPARTMENT" SortExpression="DEPARTMENT" />
<asp:BoundField DataField="GRADE_LEVEL" HeaderText="GRADE LEVEL" SortExpression="GRADE_LEVEL" />
<asp:BoundField DataField="EMAIL" HeaderText="EMAIL" SortExpression="EMAIL" />
<asp:BoundField DataField="USERNAME" HeaderText="USERNAME" SortExpression="USERNAME" />
<%--
<asp:BoundField DataField="EMPLOYMENT_DATE" HeaderText="EMPLOYMENT_DATE" SortExpression="EMPLOYMENT_DATE" />




<asp:BoundField DataField="JOB_SUMMARY" HeaderText="JOB SUMMARY" SortExpression="JOB_SUMMARY" />
<asp:BoundField DataField="PRINCIPAL_DUTIES" HeaderText="PRINCIPAL DUTIES AND RESPONSIBILITIES" SortExpression="PRINCIPAL_DUTIES" />
<asp:BoundField DataField="COMPETENCY" HeaderText="COMPETENCY AND SKILL REQUIREMENTS" SortExpression="COMPETENCY" />--%>

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




