<%@ Control Language="C#" AutoEventWireup="true" CodeFile="KPIPoolTemplate.ascx.cs" Inherits="Account_forms_KPIPoolTemplate" %>
<style type="text/css">


    .style28
    {
        width: 895px;
    }
        
    .style21
    {
        width: 142px;
    }
        .style27
    {
        width: 542px;
    }
    .style16
    {
        width: 142px;
        height: 9px;
        text-align: right;
    }
        .style26
    {
        height: 9px;
        width: 542px;
    }
        .style29
    {
        width: 142px;
        background-color: #CCCCFF;
        text-align: right;
        height: 23px;
    }
    .style30
    {
        background-color: #CCCCFF;
        width: 542px;
        height: 23px;
    }
    .style32
    {
        width: 142px;
        background-color: #FFFFFF;
        text-align: right;
    }
        .style31
    {
        background-color: #FFFFFF;
        width: 542px;
    }
        .style6
    {
        /*width: 75px;*/
        width:142px;
        background-color: #CCCCFF;
        text-align: right;
    }
    .style7
    {
        background-color: #CCCCFF;
        width: 542px;
    }
    .Gridview
        {
        margin-right: 170px;
    }
        .style33
    {
        font-size: small;
    }
    .style34
    {
        text-align: right;
    }
</style>

<table style="width:77%;">
    <tr>
        <td class="style28">

<table style="width:85%;">
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
                Text="Create Employees Information"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="style16">
            Department:</td>
        <td class="style26">
            <asp:HiddenField ID="kpiTemplateId" runat="server" />
            <asp:DropDownList ID="DDLDepartments"  runat="server" Height="28px" 
                Width="293px" onselectedindexchanged="DDLDepartments_SelectedIndexChanged" 
                AutoPostBack="True">
                <asp:ListItem Value="">Select Department</asp:ListItem>
            </asp:DropDownList>
            </td>
    </tr>
    <tr>
        <td class="style29">
            </td>
        <td class="style30">
            &nbsp;</td>
    </tr>


     <tr>
        <td class="style34">Job Role /
            Position:</td><td class="style27">
            <asp:DropDownList ID="DDLPositions" runat="server" Height="28px" Width="290px" AutoPostBack="true">
                <asp:ListItem Value="">Select Position</asp:ListItem>
            </asp:DropDownList>
            
            </td>
    </tr>
    <tr>
        <td style="background-color: #CCCCFF">&nbsp;</td>
        <td style="background-color: #CCCCFF" class="style27"></td>
    </tr>




    <tr>
        <td class="style32">
            Serial No:</td>
        <td class="style31">
            <asp:TextBox ID="TxtSerialNo" runat="server" Width="290px"></asp:TextBox>
            </td>
    </tr>
    <tr>
        <td class="style6">
            &nbsp;</td>
        <td class="style7" align="left">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style32">
            KPI Dimension:</td>
        <td class="style31" align="left">
            <asp:DropDownList ID="DDLKPIDimension"  runat="server" Height="28px" 
                Width="290px">
                <asp:ListItem Selected="True">Select KPI Dimension</asp:ListItem>
                <asp:ListItem>Financial</asp:ListItem>
                <asp:ListItem>Customer</asp:ListItem>
                <asp:ListItem>Process Efficiency</asp:ListItem>
                <asp:ListItem>People</asp:ListItem>
                <asp:ListItem>Brand</asp:ListItem>
            </asp:DropDownList>
            </td>
    </tr>
    <tr>
        <td class="style6">
            &nbsp;</td>
        <td class="style7" align="left">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style32">
            KPI<em><span class="style33">(e.g. RoE)</span></em>:</td>
        <td class="style31" align="left">
            <asp:DropDownList ID="DDLKPIName"  runat="server" Height="28px" 
                Width="290px">
            </asp:DropDownList>
            </td>
    </tr>
    <tr>
        <td class="style6">
            &nbsp;</td>
        <td class="style7" align="left">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style32">
            KPI Group:</td>
        <td class="style31" align="left">
            <asp:DropDownList ID="DDLKPIGroup"  runat="server" Height="28px" 
                Width="290px">
                <asp:ListItem Selected="True">Select KPI Group</asp:ListItem>
                <asp:ListItem Value="C">Common</asp:ListItem>
                <asp:ListItem Value="S">Shared</asp:ListItem>
                <asp:ListItem Value="I">Individual</asp:ListItem>
            </asp:DropDownList>
            </td>
    </tr>
    <tr>
        <td class="style6">
            &nbsp;</td>
        <td class="style7" align="left">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style32">
            KPI Definition:</td>
        <td class="style31" align="left">
            <asp:TextBox ID="TxtKPIDefinition" runat="server" BorderStyle="Solid" 
                Height="34px" TextMode="MultiLine" Width="290px"></asp:TextBox>
            </td>
    </tr>
    <tr>
        <td class="style6">
            &nbsp;</td>
        <td class="style7" align="left">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style32">
            Formula:</td>
        <td class="style31" align="left">
            <asp:TextBox ID="TxtFormula" runat="server" BorderStyle="Solid" 
                Height="34px" TextMode="MultiLine" Width="290px"></asp:TextBox>
            </td>
    </tr>
    <tr>
        <td class="style6">
            &nbsp;</td>
        <td class="style7" align="left">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style32">
            Significance Level:</td>
        <td class="style31" align="left">
            <asp:DropDownList ID="DDLSigLevel"  runat="server" Height="28px" 
                Width="290px">
                <asp:ListItem Selected="True">Select Significance Level</asp:ListItem>
                <asp:ListItem Value="High">High</asp:ListItem>
                <asp:ListItem Value="Medium">Medium</asp:ListItem>
                <asp:ListItem Value="Low">Low</asp:ListItem>
            </asp:DropDownList>
            </td>
    </tr>
    <tr>
        <td class="style6">
            &nbsp;</td>
        <td class="style7" align="left">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style32">
            Influence Level:</td>
        <td class="style31" align="left">
            <asp:DropDownList ID="DDLInfLevel"  runat="server" Height="28px" 
                Width="290px">
                <asp:ListItem Selected="True">Select Influence Level</asp:ListItem>
                <asp:ListItem Value="High">High</asp:ListItem>
                <asp:ListItem Value="Medium">Medium</asp:ListItem>
                <asp:ListItem Value="Low">Low</asp:ListItem>
            </asp:DropDownList>
            </td>
    </tr>
    <tr>
        <td class="style6">
            &nbsp;</td>
        <td class="style7" align="left">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style32">
            Importance Factor:</td>
        <td class="style31" align="left">
            <asp:DropDownList ID="DDLImpFactor" runat="server" Width="290px">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td class="style6">
            &nbsp;</td>
        <td class="style7" align="left">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style32">
            Weight <em>(in %)</em>:</td>
        <td class="style31" align="left">
            <asp:TextBox ID="TxtWeight" runat="server" Width="290px"></asp:TextBox>
            </td>
    </tr>
    <tr>
        <td class="style6">
            &nbsp;</td>
        <td class="style7" align="left">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style32">
            Source:</td>
        <td class="style31" align="left">
            <asp:TextBox ID="TxtSource" runat="server" Width="290px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="style6">
            &nbsp;</td>
        <td class="style7" align="left">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style32">
            Responsibility:</td>
        <td class="style31" align="left">
            <asp:DropDownList ID="DDLResponsibility"  runat="server" Height="28px" 
                Width="293px">
                <asp:ListItem Value="">Select Department</asp:ListItem>
            </asp:DropDownList>
            </td>
    </tr>
    <tr>
        <td class="style6">
            &nbsp;</td>
        <td class="style7" align="left">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style32">
            Existing?:</td>
        <td class="style31" align="left">
            <asp:DropDownList ID="DDLExisting" runat="server">
                <asp:ListItem Selected="True">Select Existing</asp:ListItem>
                <asp:ListItem>Yes</asp:ListItem>
                <asp:ListItem>No</asp:ListItem>
            </asp:DropDownList>
            </td>
    </tr>
    <tr>
        <td class="style6">
            &nbsp;</td>
        <td class="style7" align="left">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style32">
            &nbsp;</td>
        <td class="style31" align="left">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style6">
            &nbsp;</td>
        <td class="style7" align="left">
            <asp:Button ID="btnSaveKPITemplate" runat="server" 
                 Text="Save KPI Template" 
                Height="31px" onclick="btnSaveKPITemplate_Click" />
            </td>
    </tr>
    <tr>
        <td class="style32">
            &nbsp;</td>
        <td class="style31" align="left">
            <asp:Label ID="lblTest" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="style6">
            &nbsp;</td>
        <td class="style7" align="left">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style32">
            Search KPI Pool Template</td>
        <td class="style31" align="left">
            <asp:DropDownList ID="DDLSearchPositions" runat="server" Height="28px" 
                Width="201px" AutoPostBack="true" 
                onselectedindexchanged="DDLSearchPositions_SelectedIndexChanged">
            </asp:DropDownList>
            
            <asp:DropDownList ID="DDLKPITemplate"  runat="server" Height="28px" 
                Width="293px" 
                onselectedindexchanged="DDLKPITemplate_SelectedIndexChanged">
            </asp:DropDownList>
            <asp:Label ID="lblTest0" runat="server"></asp:Label>
            </td>
    </tr>
    <tr>
        <td class="style6">
            &nbsp;</td>
        <td class="style7" align="left">
            <asp:Button ID="btnSearchKPIPoolTemplate" runat="server" 
                Text="Search KPI Pool Template Now" 
                Height="31px" onclick="btnSearchKPIPoolTemplate_Click" />
            </td>
    </tr>
    </table>

        </td>
    </tr>
    <tr align="center">
        <td class="style28">
           

           <asp:GridView ID="Gridview1" runat="server" AllowPaging="True" PageSize="20"
                AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" BorderWidth="1px" 
                CssClass="Gridview" DataKeyNames="id" ForeColor="#333333" GridLines ="Both" 
                OnPageIndexChanging="Gridview1_PageIndexChanging" 
                onrowcommand="GridView1_RowCommand" 
                onselectedindexchanged="Gridview1_SelectedIndexChanged" 
                OnSorting="Gridview1_Sorting" Width="979px">
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


<%--select a.id id, a.KPI_DIMENSION KPI_DIMENSION, a.KPI KPI, A.KPI_GROUP KPI_GROUP, a.KPI_DEFINITION KPI_DEFINITION, A.FORMULA FORMULA,"+ 
"A.SIGNIFICANCE_LEVEL SIGNIFICANCE_LEVEL, A.INFLUENCE_LEVEL INFLUENCE_LEVEL, A.IMPORTANCE_FACTOR IMPORTANCE_FACTOR, A.WEIGHT weight, A.SOURCE source," +
"A.RESPONSIBILITY RESPONSIBILITY, A.EXISTING_YES_NO existing, A.S_N s_n, A.POSITION_ID POSITION_ID, B.POSITION POSITION, A.DEPARTMENT_ID DEPARTMENT_ID, C.NAME department from KPI_TEMPLATE a, position_setup b," +
"department_setup c where A.POSITION_ID=B.ID and A.DEPARTMENT_ID=C.ID--%>

 <asp:BoundField DataField="id" HeaderText="ID" SortExpression="id" />
 <asp:BoundField DataField="DEPARTMENT_ID" HeaderText="DEPARTMENT_ID" SortExpression="DEPARTMENT_ID" />
 <asp:BoundField DataField="POSITION_ID" HeaderText="POSITION_ID" SortExpression="POSITION_ID" />
 <asp:BoundField DataField="s_n" HeaderText="s_n" SortExpression="s_n" />
 <asp:BoundField DataField="FORMULA" HeaderText="FORMULA" SortExpression="FORMULA" />
 <asp:BoundField DataField="SIGNIFICANCE_LEVEL" HeaderText="SIGNIFICANCE_LEVEL" SortExpression="SIGNIFICANCE_LEVEL" />
 <asp:BoundField DataField="INFLUENCE_LEVEL" HeaderText="INFLUENCE_LEVEL" SortExpression="INFLUENCE_LEVEL" />
 <asp:BoundField DataField="IMPORTANCE_FACTOR" HeaderText="IMPORTANCE_FACTOR" SortExpression="IMPORTANCE_FACTOR" />
 <asp:BoundField DataField="weight" HeaderText="weight" SortExpression="weight" />
 <asp:BoundField DataField="SOURCE" HeaderText="SOURCE" SortExpression="SOURCE" />
 <asp:BoundField DataField="RESPONSIBILITY" HeaderText="RESPONSIBILITY" SortExpression="RESPONSIBILITY" />
 <asp:BoundField DataField="EXISTING_YES_NO" HeaderText="EXISTING_YES_NO" SortExpression="EXISTING_YES_NO" />
 

 <asp:BoundField DataField="POSITION" HeaderText="POSITION" SortExpression="POSITION" />
 <asp:BoundField DataField="DEPARTMENT" HeaderText="DEPARTMENT" SortExpression="DEPARTMENT" />
 <asp:BoundField DataField="KPI_DIMENSION" HeaderText="KPI DIMENSION" SortExpression="KPI_DIMENSION" />
 <asp:BoundField DataField="KPI_NAME" HeaderText="KPI NAME" SortExpression="KPI_NAME" />
 <asp:BoundField DataField="KPI" HeaderText="KPI" SortExpression="KPI" />
 <asp:BoundField DataField="KPI_GROUP" HeaderText="KPI GROUP" SortExpression="KPI_GROUP" />
<asp:BoundField DataField="KPI_DEFINITION" HeaderText="KPI DEFINITION" SortExpression="KPI_DEFINITION" />


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





