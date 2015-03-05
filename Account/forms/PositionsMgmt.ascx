<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PositionsMgmt.ascx.cs" Inherits="Account_forms_PositionsMgmt" %>
<style type="text/css">

    .style28
    {
        width: 895px;
    }
        
    .style21
    {
        width: 152px;
    }
        .style27
    {
        width: 288px;
    }
    .style16
    {
        width: 152px;
        height: 36px;
        text-align: right;
    }
        .style26
    {
        height: 36px;
        width: 288px;
    }
        .style6
    {
        width: 152px;
        background-color: #CCCCFF;
        text-align: right;
    }
    .style7
    {
        background-color: #FFFFFF;
        }
    .Gridview
        {
        margin-right: 170px;
    }
        .style29
    {
        background-color: #FFFFFF;
        height: 13px;
        width: 288px;
    }
    .style30
    {
        width: 152px;
        background-color: #FFFFFF;
        text-align: right;
        height: 13px;
    }
        .style31
    {
        height: 39px;
    }
    .style32
    {
        background-color: #CCCCFF;
        width: 288px;
    }
    .style33
    {
        height: 39px;
        width: 288px;
        text-align: left;
    }
    .style34
    {
        width: 895px;
        height: 250px;
    }
        .style35
    {
        background-color: #FFFFFF;
        width: 288px;
    }
    .style36
    {
        width: 152px;
        background-color: #FFFFFF;
        text-align: right;
    }
    .style37
    {
        height: 19px;
        width: 288px;
        background-color: #CCCCFF;
    }
    .style38
    {
        width: 152px;
        height: 19px;
        text-align: right;
        background-color: #CCCCFF;
    }
        </style>

<table style="width:77%;">
    <tr>
        <td class="style34">

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
                Text="Create Positions"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="style16">
            Position:</td>
        <td class="style26">
        <asp:TextBox ID="TxtPositions" runat="server" BorderStyle="Solid" Height="25px" 
                Width="295px" BorderColor="#CCCCFF"></asp:TextBox>
            </td>
    </tr>
    <tr>
        <td class="style38">
            </td>
        <td class="style37">
            </td>
    </tr>
    <tr>
        <td class="style16">
            Department:</td>
        <td class="style26">
            <asp:DropDownList ID="DDLDepartments"  runat="server" Height="28px" 
                Width="293px">
            </asp:DropDownList>
            <asp:Button ID="btnUpdatePositions" runat="server" onclick="btnUpdatePositions_Click" Text="Save Position" Height="31px" />
            </td>
    </tr>
    <tr>
        <td class="style6">
            &nbsp;</td>
        <td class="style32">
            <asp:HiddenField ID="positionId" runat="server" />
        <asp:TextBox ID="TxtPositions0" runat="server" BorderStyle="Solid" Height="25px" 
                Width="295px" BorderColor="#CCCCFF" Visible="False"></asp:TextBox>
            </td>
    </tr>
    <tr>
        <td class="style36">
            &nbsp;</td>
        <td class="style35">
            <asp:HiddenField ID="deptId" runat="server" />
            </td>
    </tr>
    <tr>
        <td class="style6">
            &nbsp;</td>
        <td class="style32">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style30">
            Search Position:</td>
        <td class="style29">
            <asp:DropDownList ID="DDLSearchPosition"  runat="server" Height="28px" 
                Width="293px">
            </asp:DropDownList>
            </td>
    </tr>
    <tr class="style6">
        <td class="style31">
            &nbsp;</td>
        <td class="style33" >
            <asp:Button ID="btnSearchPosition" runat="server" 
                onclick="btnSearchPosition_Click" Text="Search Position Now" 
                Height="31px" />
            </td>
    </tr>
    </table>

        </td>
    </tr>
    <tr align="center">
        <td class="style28">
           

           <asp:GridView ID="Gridview1" runat="server" AllowPaging="True" 
                AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" BorderWidth="1px" 
                CssClass="Gridview" DataKeyNames="id" ForeColor="#333333" GridLines="Both" 
                OnPageIndexChanging="Gridview1_PageIndexChanging" 
                onselectedindexchanged="Gridview1_SelectedIndexChanged" 
                OnSorting="Gridview1_Sorting" Width="880px" PageSize="20">
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

                    <asp:TemplateField HeaderText="S/N">
                        <ItemTemplate>
                              
                                <%#Container.DataItemIndex+1 %>
                           
                        </ItemTemplate>
                    </asp:TemplateField>

 <asp:BoundField DataField="id" HeaderText="ID" SortExpression="id" />
 <asp:BoundField DataField="position" HeaderText="POSITION" SortExpression="position" />
 <asp:BoundField DataField="DEPARTMENT" HeaderText="DEPARTMENT" SortExpression="DEPARTMENT" />
 <asp:BoundField DataField="DEPARTMENT_ID" HeaderText="DEPARTMENT_ID" SortExpression="DEPARTMENT_ID" />
<asp:BoundField DataField="creator" HeaderText="CREATOR" SortExpression="creator" />
<asp:BoundField DataField="created_date" HeaderText="CREATED DATE" SortExpression="created_date" />
<%--
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




