<%@ Control Language="C#" AutoEventWireup="true" CodeFile="userManager.ascx.cs" Inherits="Account_forms_userManager"%>
<script runat="server">
    protected void dsGridview_Deleted(object sender, SqlDataSourceStatusEventArgs e)
    {
        if (e.Exception == null)
        {
            if (e.AffectedRows == 1)
            {
                lblShow.Text = "Record deleted successfully.";
            }
            else
            {
                lblShow.Text = "An error occurred during the delete operation.";
            }
        }
        else
        {
            lblShow.Text = "An error occurred while attempting to delete the row.";
            e.ExceptionHandled = true;
        }
    }
    
</script>

<style type="text/css">
        .Gridview
        {
        margin-right: 170px;
    }
        .input_outl
    {}
        .style1
        {
            width: 650px;
            
        }
        .style559
        {
        width: 588px;
    }
        .style558
        {
            width: 215px;
        }
        .style562
    {
        height: 9px;
    }
    .style560
    {
        width: 588px;
        height: 45px;
    }
    .style561
    {
        width: 215px;
        height: 45px;
    }
    .style563
    {
        width: 588px;
        height: 46px;
    }
    .style564
    {
        width: 215px;
        height: 46px;
    }
    .style565
    {
        width: 799px;
    }
    </style>
<table style="width:100%;">
    <tr>
        <td>
<table class="style1">
    <tr>
        <td align="right" bgcolor="Silver" class="style559">
            &nbsp;</td>
        <td bgcolor="Silver" class="style558" colspan="2">
            <asp:Label ID="lblstatus" runat="server"></asp:Label>
            <asp:Label ID="lblstatus0" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td align="left" bgcolor="#CCCCFF" class="style9" colspan="3">
            <asp:Label ID="Label12" runat="server" Font-Bold="True" ForeColor="Black" 
                Text="Grant User Role and Permision"></asp:Label>
        </td>
    </tr>
    <tr>
        <td align="right" class="style559">
            <asp:Label ID="Label2" runat="server" Text="Username"></asp:Label>
        </td>
        <td class="style558" colspan="2">
            <asp:DropDownList ID="txtuser" runat="server" Height="24px" Width="285px" 
                AutoPostBack="True">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td align="right" class="style559">
            &nbsp;</td>
        <td class="style558" colspan="2">
            &nbsp;</td>
    </tr>
    <tr>
        <td align="right" bgcolor="#99CCFF" class="style559">
            Position/Job Role</td>
        <td bgcolor="#99CCFF" class="style558" colspan="2">
            <asp:DropDownList ID="DDLPositions" runat="server" Height="28px" Width="285px" 
                AutoPostBack="True">
                <asp:ListItem Value="0" Selected="True">Select Position</asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td align="right" bgcolor="#99CCFF" class="style559">
            &nbsp;</td>
        <td bgcolor="#99CCFF" class="style558" colspan="2">
            &nbsp;</td>
    </tr>
    <tr>
        <td align="right" class="style559">
            Department</td>
        <td class="style558" colspan="2">
            <asp:DropDownList ID="DDLDepartment" runat="server" Height="28px" Width="285px" 
                AutoPostBack="True">
                <asp:ListItem Value="0" Selected="True">Select Department</asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td align="right" class="style559">
            &nbsp;</td>
        <td class="style558" colspan="2">
            &nbsp;</td>
    </tr>
    <tr>
        <td align="left" bgcolor="#CCCCFF" class="style10" colspan="3">
            <asp:Label ID="Label8" runat="server" Font-Bold="True" ForeColor="Black" 
                Text="Modules"></asp:Label>
        </td>
    </tr>
    <tr>
        <td align="right" class="style560">
            <%--<asp:Panel ID="Panel3" runat="server">
                <asp:CheckBox ID="chkAccess_user" runat="server" 
                    Text="Grant access to User Management" Width="300px" />
                    </asp:Panel>--%>
            <asp:CheckBox ID="chkAccess_user" runat="server" 
                Text="Grant access to User Management" Width="300px" />
        </td>
        <td class="style558" colspan="2">
            <asp:Panel ID="Panel2" runat="server" Width="300px">
                <asp:CheckBox ID="chkAccess_appraisal" runat="server" 
                    Text="Grant access to User Appraisal Management" />
                        <br />
                    </asp:Panel>
        </td>
    </tr>
    <tr>
        <td align="left" bgcolor="#CCCCFF" class="style562" colspan="3">
        </td>
    </tr>
    <tr>
        <td align="right" class="style560">
            <asp:CheckBox ID="chkAccess_goal" runat="server" 
                Text="Grant Access to Goal Settings Management" Width="300px" />
        </td>
        <td class="style561" colspan="2">
            <asp:CheckBox ID="chkAccess_beh" runat="server" 
                Text="Grant Access to Application Form Management" Width="400px" />
           
            <br />
        </td>
    </tr>

    <tr>
        <td align="right" class="style560">
            <asp:CheckBox ID="chkAccess_v_goal_settings" runat="server" 
                Text="Grant Access to View Goal Settings" Width="300px" />
        </td>
        <td class="style561" colspan="2">
            <asp:CheckBox ID="chkAccess_v_app_form" runat="server" 
                Text="Grant Access to View Application Form" Width="400px" />
           
            <br />
        </td>
    </tr>
    <tr>
        <td align="right" class="style563">
        </td>
        <td class="style564" colspan="2">
            <asp:Button ID="btnUpdateProfileNow" runat="server" 
                onclick="btnUpdateProfileNow_Click" Text="Update Profile" />
        </td>
    </tr>
    <tr>
        <td align="right" class="style559">
            <asp:Label ID="Label13" runat="server" Text="Enter User Name"></asp:Label>
        </td>
        <td class="style565">
            <asp:TextBox ID="txtuser0" runat="server" Width="201px"></asp:TextBox>
        </td>
        <!--<td class="style558">
            &nbsp;</td>-->
        <td class="style565">
            <asp:Button ID="Button1" runat="server" Text="Search" />
        </td>
    </tr>
    <tr><td class="style559"></td>
        <%--align="right" class="style559"--%>
        <td align="center" class="style565" colspan="2">
            

            &nbsp;</td>
    </tr>
</table>


        </td>
    </tr>
    <tr align="center">
    <td>
            

           <asp:GridView ID="Gridview1" runat="server" AllowPaging="True" 
                AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" 
                CssClass="Gridview" DataKeyNames="user_id" ForeColor="#333333" GridLines="None" 
                OnPageIndexChanging="Gridview1_PageIndexChanging" 
                onselectedindexchanged="Gridview1_SelectedIndexChanged" 
                OnSorting="Gridview1_Sorting" Width="867px">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:TemplateField HeaderText="">
                        <ItemTemplate>
                            <div style="white-space: nowrap; clear: none; width: 100%; display: inline;">
                               <%-- <asp:LinkButton ID="btnDelete" runat="server" CommandName="Delete" 
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
 <asp:BoundField DataField="username" HeaderText="USERNAME" SortExpression="username" />

<asp:BoundField DataField="POSITION" HeaderText="POSITION" SortExpression="POSITION" />
<asp:BoundField DataField="DEPARTMENT" HeaderText="DEPARTMENT" SortExpression="DEPARTMENT" />

<asp:BoundField DataField="IP_ADDRESS" HeaderText="IP ADDRESS" SortExpression="IP_ADDRESS" />
<asp:BoundField DataField="LAST_LOGON" HeaderText="LAST LOGON" SortExpression="LAST_LOGON" />

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
            

            <asp:Label ID="lblShow" runat="server" ForeColor="DarkRed"></asp:Label>
        </td>
    </tr>
</table>



