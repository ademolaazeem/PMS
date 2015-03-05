<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DepartmentsMgmt.ascx.cs" Inherits="Account_forms_DepartmentsMgmt" %>
<style type="text/css">

    .style21
    {
        width: 152px;
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
        width: 288px;
    }
    .Gridview
        {
        margin-right: 170px;
    }
        .style27
    {
        width: 288px;
    }
    .style28
    {
        width: 895px;
    }
        .style29
    {
        width: 152px;
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
    .style31
    {
        background-color: #FFFFFF;
        width: 288px;
    }
    .style32
    {
        width: 152px;
        background-color: #FFFFFF;
        text-align: right;
    }
        .style33
    {
        width: 152px;
        background-color: #FFFFFF;
        text-align: right;
        height: 29px;
    }
    .style34
    {
        background-color: #FFFFFF;
        width: 288px;
        height: 29px;
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
    .style37
    {
        background-color: #CCCCFF;
        width: 288px;
    }
        </style>

<table style="width:77%;">
    <tr>
        <td class="style28">

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
        <td class="style16">
            Department Name:</td>
        <td class="style26">
        <asp:TextBox ID="TxtDepartments" runat="server" BorderStyle="Solid" Height="25px" 
                Width="295px" BorderColor="#CC99FF"></asp:TextBox>
            <asp:HiddenField ID="departmentId" runat="server" />
            </td>
    </tr>
    <tr>
        <td class="style29">
            </td>
        <td class="style30">
            </td>
    </tr>
    <tr>
        <td class="style33">
            Group Name:</td>
        <td class="style34">
        <asp:TextBox ID="TxtGroupName" runat="server" BorderStyle="Solid" Height="25px" 
                Width="295px" BorderColor="#CC99FF"></asp:TextBox>
            </td>
    </tr>
    <tr>
        <td class="style6">
            &nbsp;</td>
        <td class="style7">
            <asp:Button ID="btnUpdateDepartments" runat="server" 
                onclick="btnUpdateDepartments_Click" Text="Save  Department" 
                Height="31px" Width="209px" />
            </td>
    </tr>
    <tr>
        <td class="style32">
            &nbsp;</td>
        <td class="style31">
            &nbsp;</td>
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
            <asp:Button ID="btnSearchDepartment" runat="server" 
                onclick="btnSearchDeparment_Click" Text="Search Department Now" 
                Height="31px" />
            </td>
    </tr>
    <tr>
        <td class="style32">
            &nbsp;</td>
        <td class="style31">
            &nbsp;</td>
    </tr>
    </table>

        </td>
    </tr>
    <tr align="center">
        <td class="style28">
           

           <asp:GridView ID="Gridview1" runat="server" EnableViewState="false" AllowPaging="True" 
                AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" BorderWidth="1px" 
                CssClass="Gridview" DataKeyNames="id" ForeColor="#333333" GridLines="Both" 
                OnPageIndexChanging="Gridview1_PageIndexChanging" 
                onselectedindexchanged="Gridview1_SelectedIndexChanged" 
                OnSorting="Gridview1_Sorting" Width="880px">
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

                    <asp:TemplateField HeaderText="S/N">
                        <ItemTemplate>
                              
                                <%#Container.DataItemIndex+1 %>
                           
                        </ItemTemplate>
                    </asp:TemplateField>
 <asp:BoundField DataField="id" HeaderText="ID" SortExpression="id" />
 <asp:BoundField DataField="name" HeaderText="NAME" SortExpression="name" />
 
<asp:BoundField DataField="groupname" HeaderText="GROUP NAME" SortExpression="groupname" />
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



