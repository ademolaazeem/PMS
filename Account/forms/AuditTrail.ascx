<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AuditTrail.ascx.cs" Inherits="Account_forms_AuditTrail" %>



<style type="text/css">

    .style28
    {
        width: 895px;
    }
        
    .style21
    {
        width: 104px;
    }
        .style27
    {
        width: 288px;
    }
        .style6
    {
        width: 152px;
        background-color: #CCCCFF;
        text-align: right;
    }
    .Gridview
        {
        margin-right: 170px;
    }
        .style31
    {
        height: 39px;
        width: 104px;
    }
    .style33
    {
        height: 39px;
        width: 288px;
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
        font-weight: 700;
    }
    .style36
    {
        width: 104px;
        background-color: #FFFFFF;
        text-align: right;
    }
    .style39
    {
        width: 104px;
        background-color: #CCCCFF;
        text-align: right;
        height: 46px;
    }
    .style40
    {
        background-color: #CCCCFF;
        width: 288px;
        height: 46px;
    }
    .style42
    {
        background-color: #CCCCFF;
        width: 288px;
        height: 23px;
    }
        .style44
    {
        width: 104px;
        background-color: #CCCCFF;
        text-align: right;
        height: 34px;
    }
    .style45
    {
        height: 34px;
    }
        </style>

<table style="width:82%;">
    <tr>
        <td class="style34">

<table style="width:85%;">
    <tr>
        <td align="right" bgcolor="Silver" class="style21">
            &nbsp;</td>
        <td bgcolor="Silver" class="style27">
            <asp:Label ID="lblStatus" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="style21">
            <asp:Label ID="Label12" runat="server" Font-Bold="True" ForeColor="Black" 
                Text="Search Criteria"></asp:Label>
        </td>
    </tr>
    
    <tr>
        <td class="style39">
            Username:</td>
        <td class="style40">
            <asp:DropDownList ID="DDLUsername"  runat="server" Height="28px" 
                Width="293px">
            </asp:DropDownList>
            <asp:DropDownList ID="DDLAndOr0"  runat="server" Height="26px" 
                Width="125px">
                <asp:ListItem>Select Criteria</asp:ListItem>
                <asp:ListItem>AND</asp:ListItem>
                <asp:ListItem>OR</asp:ListItem>
            </asp:DropDownList>
            </td>
    </tr>
    <tr>
        <td class="style36">
            Operation:</td>
        <td class="style35">
            <asp:DropDownList ID="DDLOperation"  runat="server" Height="28px" 
                Width="293px">
                <asp:ListItem>Select Operation</asp:ListItem>
                <asp:ListItem>Create</asp:ListItem>
                <asp:ListItem>LoginSuccess</asp:ListItem>
                <asp:ListItem>Update</asp:ListItem>
                <asp:ListItem>View</asp:ListItem>
            </asp:DropDownList>
            <asp:DropDownList ID="DDLAndOr1"  runat="server" Height="28px" 
                Width="125px"> <asp:ListItem>Select Criteria</asp:ListItem>
                <asp:ListItem>AND</asp:ListItem>
                <asp:ListItem>OR</asp:ListItem>
            </asp:DropDownList>
            </td>
    </tr>
    <tr class="style42">
        <td class="style44">
            From Date: <i>yyyy/m/d</i></td>
        <td class="style45">
                     <asp:DropDownList ID="DDLFromYear" runat="server" >
                     </asp:DropDownList>
                     <asp:DropDownList ID="DDLFromMonth" runat="server">
                     </asp:DropDownList>
                     <asp:DropDownList ID="DDLFromDay" runat="server"></asp:DropDownList>
                     <br/>
               </td>
    </tr>
    <tr>
        <td class="style36">
            To Date:  <i>yyyy/m/d</i></td>
        <td>
                     <asp:DropDownList ID="DDLToYear" runat="server" >
                     </asp:DropDownList>
                     <asp:DropDownList ID="DDLToMonth" runat="server">
                     </asp:DropDownList>
                     <asp:DropDownList ID="DDLToDay" runat="server"></asp:DropDownList>
           </td>
    </tr>
    <tr class="style42">
        <td class="style21">
            &nbsp;</td>
        <td >
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style21">
            &nbsp;</td>
        <td>
            <asp:Button ID="btnSearchAudit" runat="server" 
                onclick="btnSearchAudit_Click" Text="Search Audit" 
                Height="31px" />
            </td>
    </tr>
    <tr class="style42">
        <td class="style21">
            &nbsp;</td>
        <td>
            &nbsp;</td>
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
           

            <asp:GridView ID="GrdAuditTrail" runat="server" AllowPaging="True" 
                AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" BorderWidth="1px" 
                CssClass="Gridview" ForeColor="#333333" GridLines="Both" 
                OnPageIndexChanging="GrdAuditTrail_PageIndexChanging" 
                OnSorting="GrdAuditTrail_Sorting" Width="974px" PageSize="50">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                   
                   

 
  <asp:BoundField DataField="USERNAME" HeaderText="USERNAME" SortExpression="USERNAME" />
 <asp:BoundField DataField="DETAILS" HeaderText="OPERATION DETAILS" SortExpression="DETAILS" />
 <asp:BoundField DataField="IPADDRESS" HeaderText="IP ADDRESS" SortExpression="IPADDRESS" />
 <asp:BoundField DataField="DATETIME" HeaderText="DATE TIME" SortExpression="DATETIME" />
 <asp:BoundField DataField="OPERATION" HeaderText="OPERATION" SortExpression="OPERATION" />



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