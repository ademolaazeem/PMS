<%@ Control Language="C#" AutoEventWireup="true" CodeFile="GroupDepartmentalKPIMgmt.ascx.cs" Inherits="Account_forms_GroupDepartmentalKPIMgmt" %>
<style type="text/css">

    .style34
    {
        width: 895px;
        height: 250px;
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
        .style38
    {
        width: 152px;
        height: 19px;
        text-align: right;
        background-color: #CCCCFF;
    }
        .style37
    {
        height: 19px;
        width: 288px;
        background-color: #CCCCFF;
    }
        .style6
    {
        width: 152px;
        background-color: #CCCCFF;
        text-align: right;
    }
    .style32
    {
        background-color: #CCCCFF;
        width: 288px;
    }
    .style36
    {
        width: 152px;
        background-color: #FFFFFF;
        text-align: right;
    }
        .style35
    {
        background-color: #FFFFFF;
        width: 288px;
    }
    .style30
    {
        width: 152px;
        background-color: #FFFFFF;
        text-align: right;
        height: 13px;
    }
        .style29
    {
        background-color: #FFFFFF;
        height: 13px;
        width: 288px;
    }
        .style31
    {
        height: 39px;
    }
    .style33
    {
        height: 39px;
        width: 288px;
    }
    
    .style28
    {
        width: 895px;
    }
        
    .Gridview
        {
        margin-right: 170px;
    }
        .style39
    {
        height: 19px;
        width: 288px;
        background-color: #FFFFFF;
    }
    .style40
    {
        width: 152px;
        height: 19px;
        text-align: right;
        background-color: #FFFFFF;
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
                Text="Create Group/Department KPIs"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="style16">
            KPI Name:</td>
        <td class="style26">
        <asp:TextBox ID="TxtKPIName" runat="server" BorderStyle="Solid" Height="25px" 
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
        <td class="style40">
            Department:</td>
        <td class="style39">
            <asp:DropDownList ID="DDLDepartments"  runat="server" Height="28px" 
                Width="293px" ondatabound="DDLDepartments_DataBound">
            </asp:DropDownList>
            </td>
    </tr>
    <tr>
        <td class="style38">
            </td>
        <td class="style37">
            </td>
    </tr>
    <tr>
        <td class="style40">
            KPI Type:</td>
        <td class="style39">
            <asp:DropDownList ID="DDLKPIType"  runat="server" Height="28px" 
                Width="293px">
                <asp:ListItem Value="" Selected="True">Select KPI Type</asp:ListItem>
                <asp:ListItem>Common KPIs</asp:ListItem>
                <asp:ListItem>Shared KPIs</asp:ListItem>
                <asp:ListItem>Individual KPIs</asp:ListItem>
            </asp:DropDownList>
            </td>
    </tr>
    <tr>
        <td class="style38">
            &nbsp;</td>
        <td class="style37">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style16">
            Departmental Functions:</td>
        <td class="style26">
            <asp:DropDownList ID="DDLDeptFxn"  runat="server" Height="28px" 
                Width="293px">
                <asp:ListItem Value="" Selected="True">Select Departmental Fxn</asp:ListItem>
                <asp:ListItem>Market Facing</asp:ListItem>
                <asp:ListItem>Support</asp:ListItem>
                <asp:ListItem>Both</asp:ListItem>
            </asp:DropDownList>
            <asp:Button ID="btnUpdateKPIInfo" runat="server" 
                onclick="btnUpdateKPIInfo_Click" Text="Save KPI Information" Height="31px" />
            </td>
    </tr>
    <tr>
        <td class="style6">
            &nbsp;</td>
        <td class="style32">
            <asp:HiddenField ID="groupDeptId" runat="server" />
            </td>
    </tr>
    <tr>
        <td class="style36">
            &nbsp;</td>
        <td class="style35">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style6">
            &nbsp;</td>
        <td class="style32">
            <asp:DropDownList ID="DDLKPIName"  runat="server" Height="28px" 
                Width="293px">
            </asp:DropDownList>
            </td>
    </tr>
    <tr>
        <td class="style30">
            Search KPI:</td>
        <td class="style29">
            <asp:Button ID="btnSearch" runat="server" 
                onclick="btnSearch_Click" Text="Search KPI Info" 
                Height="31px" />
            </td>
    </tr>
    <tr class="style6">
        <td class="style31">
            &nbsp;</td>
        <td class="style33" >
            &nbsp;</td>
    </tr>
    </table>

        </td>
    </tr>
    <tr align="center">
        <td class="style28">
           

           <asp:GridView ID="Gridview1" runat="server" AllowPaging="True" PageSize="20"
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
 <asp:BoundField DataField="KPI_NAME" HeaderText="KPI NAME" SortExpression="KPI_NAME" />
 <asp:BoundField DataField="DEPARTMENT" HeaderText="DEPARTMENT" SortExpression="DEPARTMENT" />
<asp:BoundField DataField="KPI_TYPE" HeaderText="KPI TYPE" SortExpression="KPI_TYPE" />
<asp:BoundField DataField="KPI_KIND" HeaderText="DEPARTMENTAL FXN" SortExpression="KPI_KIND" />
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





