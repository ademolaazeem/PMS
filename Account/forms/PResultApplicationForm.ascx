<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PResultApplicationForm.ascx.cs" Inherits="Account_forms_PResultApplicationForm" %>


<style type="text/css">


.stylehr
    {
        color:White;
    }
    .style21
    {
        width: 306px;
    }
    .style28
    {
        height: 23px;
    }
        .style29
    {
        width: 800px;
        border-style: solid;
        border-width: 1px;
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
        width: 314px;
        height: 23px;
        background-color: #CCCCFF;
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
        .style66
    {
        width: 882px;
        text-align: left;
    }
        .Gridview
        {
        margin-right: 170px;
    }
        .style86
    {
        text-align: left;
        height: 27px;
        background-color: #FFFFFF;
    }
        .style88
    {
        width: 942px;
    }
    .style92
    {
        text-align: left;
        height: 27px;
        background-color: #FFFFFF;
        width: 942px;
    }
    .style93
    {
        width: 882px;
    }
        .style99
    {
        width: 607px;
    }
        </style>
   <style type="text/css">
    .GVheader
    {
        /* background-color:#3E3E3E;        
         font-family:Calibri;
         color:black;
         text-align:center; 
        
        */
        color:black;
        height: 31px;
        text-align: left;
        background-color: #CCCCCC;       
    }
       .style100
       {
           text-align: left;
       }
       .style102
       {
           height: 42px;
       }
       .style103
       {
           background-color: #CCCCFF;
           height: 32px;
       }
       .style104
       {
           background-color: #CCCCFF;
           height: 30px;
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
    <legend>Select Date</legend>
    Year: <asp:DropDownList ID="ddlYearSub" runat="server" AutoPostBack="True"></asp:DropDownList> 
    Month: <asp:DropDownList ID="ddlMonthSub" runat="server" AutoPostBack="True"></asp:DropDownList> 
       
    </fieldset> 
                
                </td>
        </tr>
        <tr>
            <td class="style104">
                </td>
            <td class="style104">
                </td>
        </tr>
        <tr>
            <td class="style102">
                <asp:Label ID="LblSubName" runat="server" Text="Select Subordinate name:"></asp:Label>
            </td>
            <td class="style102">
                 <asp:DropDownList ID="DDLSubName" runat="server" Height="28px" Width="293px">
                 </asp:DropDownList>
            </td>
        </tr>
        
        <tr>
            <td class="style103">
                </td>
            <td class="style103">
               <%-- <asp:HyperLink ID="HLnkShowSubPRGoalSettings" runat="server" 
                NavigateUrl="~/Account/forms/PResultGoalSettings.ascx" 
                ondatabinding="btnShowSubPRGoalSettings_Click">Show Subordinate PR Goal Settings</asp:HyperLink>--%>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style42">
                &nbsp;</td>
            <td class="style41">
                <asp:Button ID="btnShowSubPRGoalSettings" runat="server" Height="31px" 
                    onclick="btnShowSubPRGoalSettings_Click" 
                    Text="Show Subordinate PR Goal Settings" />
                <%-- <asp:HyperLink ID="HLnkShowSubPRGoalSettings" runat="server" 
                NavigateUrl="~/Account/forms/PResultGoalSettings.ascx" 
                ondatabinding="btnShowSubPRGoalSettings_Click">Show Subordinate PR Goal Settings</asp:HyperLink>--%>
            </td>
        </tr>
        <tr>
            <td class="style32" colspan="2">
                
            </td>
        </tr>
    </table>
</asp:Panel>

<asp:Panel ID="PnlMain" runat="server">
<%--<asp:UpdatePanel ID="PnlMain" runat="server">
               <ContentTemplate>--%>
<table style="width:100%;">
    <tr>
        <td class="style93">

<table style="width: 925px" class="style29">
    <tr>
        <td align="right" bgcolor="Silver" class="style21">
            &nbsp;</td>
        <td bgcolor="Silver" class="style99">
            <asp:Label ID="lblStatusMain" runat="server"></asp:Label>
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
                        <%--<fieldset style="width:300px">
    <legend>Select Date</legend>
    Year: <asp:DropDownList ID="ddlYear" runat="server" AutoPostBack="True"></asp:DropDownList> 
    Month: <asp:DropDownList ID="ddlMonth" runat="server" AutoPostBack="True"></asp:DropDownList> 
       
    </fieldset>--%>


                        <asp:Label ID="LblAppraisalPeriod" runat="server"></asp:Label>
    
    
    
    <fieldset style="width:300px">
    <legend>Select Date</legend>
    Year: <asp:DropDownList ID="ddlYear" runat="server" AutoPostBack="True"></asp:DropDownList> 
    Month: <asp:DropDownList ID="ddlMonth" runat="server" AutoPostBack="True"></asp:DropDownList> 
    </fieldset> 
    
    
    </td>
                    </tr>
           </table>

            </td>
    </tr>
    <tr align="center">
        <td class="style93">
           

            <table align="left" cellpadding="5" cellspacing="5">
                <tr>
                    <td>
           

           <asp:GridView ID="GrdViewKPI" runat="server" 
                AllowPaging="True" PageSize="6"
                AllowSorting="True" AutoGenerateColumns="False" CellPadding="5" BorderWidth="2px" 
                CssClass="Gridview" DataKeyNames="KPI_DIMENSION" ForeColor="#333333" GridLines="Both" 
                OnPageIndexChanging="GrdViewKPI_PageIndexChanging" OnRowDataBound="GrdViewKPI_RowDataBound"
                onselectedindexchanged="GrdViewKPI_SelectedIndexChanged" 
                OnSorting="GrdViewKPI_Sorting" Width="930px" ShowFooter="True">
                <AlternatingRowStyle BackColor="White" />
                <%--<asp:TemplateField HeaderText="">
                        <ItemTemplate>
                            <div style="white-space: nowrap; clear: none; width: 100%; display: inline;">
                                <asp:LinkButton ID="btnDelete" runat="server" CommandName="Delete" 
                                    OnClientClick="return confirm('Are you sure you want to delete this record?');">
                                        
                                        <asp:Image ID="imgDelete" ImageUrl="~/Account/images/imgdelete1.png" runat="server" /> 
                                        </asp:LinkButton>
                            </div>
                            <div style="white-space: nowrap; clear: none; width: 100%; display: inline;">
                                <asp:LinkButton ID="btnEdit4" runat="server" CommandName="Select">
                                        
                                        <asp:Image ID="Image6" ImageUrl="~/Account/images/edit.png" 
                                    runat="server" /> 
                                        </asp:LinkButton>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>--%>

                   <%-- <asp:TemplateField HeaderText="S/N">
                        <ItemTemplate>
                              
                                <%#Container.DataItemIndex+1 %>
                           
                        </ItemTemplate>
                    </asp:TemplateField>--%>
                    <%-- <asp:BoundField DataField="TOTAL_OBTAINABLE_SCORE" HeaderText="Total Obtainable Score" SortExpression="TOTAL_OBTAINABLE_SCORE">
                        </asp:BoundField>--%>
                        
                        
                        
             <Columns>
                             <asp:BoundField DataField="KPI_DIMENSION" HeaderText="" SortExpression="KPI_DIMENSION" />
                             <%--<asp:BoundField DataField="TOTAL_KPI_NUMBER" HeaderText="Total Number of KPIs" SortExpression="TOTAL_KPI_NUMBER" />--%>
                              
                              <asp:TemplateField HeaderText="Total Number of KPIs" ItemStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center" >
                             <ItemTemplate>
                                <asp:label id="TOTAL_KPI_NUMBER1" Text= '<%# Eval("TOTAL_KPI_NUMBER")%>' runat="server"/> 
                             </ItemTemplate>
                                <FooterTemplate>
                                <br />
                                <asp:Label ID="lblWeightedScore" runat="server" />
                                </FooterTemplate>
                                
                             </asp:TemplateField>

                             <asp:TemplateField HeaderText="Total Obtainable Score" ItemStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center" >
                             <ItemTemplate>
                               <%--<asp:Label ID="TOTAL_OBTAINABLE_SCORE1" runat="server" Text='<%#Eval("TOTAL_OBTAINABLE_SCORE"%>' />--%>
                               <%--<asp:label id="TOTAL_OBTAINABLE_SCORE1" Text= '<%# Eval("TOTAL_OBTAINABLE_SCORE") %>' runat="server"/> .ToString()+"%"--%>
                                <asp:label id="TOTAL_OBTAINABLE_SCORE1" Text= '<%# Eval("TOTAL_OBTAINABLE_SCORE")%>' runat="server"/> 
                              
                             </ItemTemplate>
                                 <FooterTemplate>
                                   <asp:Label ID="lbl100percent" runat="server"  /><br /><hr class="stylehr" />
                                    <asp:Label ID="lbl70percent" runat="server" />
                                 </FooterTemplate>
                                <%-- <FooterTemplate>
                                    <asp:Label ID="lbl70percent" runat="server" Text='<%#Eval("70.0%") %>'/>
                                 </FooterTemplate>--%>
                             </asp:TemplateField>

                             <asp:TemplateField HeaderText="Individual Performance Score" ItemStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center" >
                             <ItemTemplate>
                                <asp:label id="INDIVIDUAL_PERFORMANCE_SCORE1" Text= '<%# Eval("INDIVIDUAL_PERFORMANCE_SCORE").ToString()+"%"%>' runat="server"/> 
                             </ItemTemplate>
                                <FooterTemplate>
                                <asp:Label ID="Lbl001" runat="server" /><br /><hr class="stylehr"/>
                                <asp:Label ID="lbl002" runat="server" />
                                </FooterTemplate>
                                
                             </asp:TemplateField>

                            <%-- 
                            <asp:BoundField DataField="INDIVIDUAL_PERFORMANCE_SCORE" HeaderText="Individual Performance Score" SortExpression="INDIVIDUAL_PERFORMANCE_SCORE" DataFormatString="{0:P}" />
                             DataFormatString="{0:C}"--%>
                             <asp:BoundField DataField="EMPLOYEE_NO" HeaderText="EMPLOYEE_NO" SortExpression="EMPLOYEE_NO" />
                             
            </Columns>
               
               
                <%--<EditRowStyle BackColor="#2461BF" />--%>
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
            

        </td>
    </tr>
    <tr align="center">
        <td class="style66">
           
          
           
   <table>
         <tr>
            <td class="style88">
           

           <asp:GridView ID="GrdViewFinancial" runat="server" EnableViewState="false" AllowPaging="True" 
                AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" BorderWidth="1px" 
                CssClass="Gridview" DataKeyNames="id" ForeColor="#333333" GridLines="Both" 
                OnPageIndexChanging="GrdViewFinancial_PageIndexChanging" OnRowDataBound="GrdViewFinancial_RowDataBound"
                onselectedindexchanged="GrdViewFinancial_SelectedIndexChanged" 
                OnSorting="GrdViewFinancial_Sorting" Width="930px">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
           <%-- <asp:TemplateField HeaderText="">
                <ItemTemplate>
                           
                    <div style="white-space: nowrap; clear: none; width: 100%; display: inline;">
                        <asp:LinkButton ID="btnEdit" runat="server" CommandName="Select">
                                        
                                <asp:Image ID="Image1" ImageUrl="~/Account/images/edit.png" runat="server" /> 
                                </asp:LinkButton>
                    </div>
                </ItemTemplate>
            </asp:TemplateField>--%>

 <asp:BoundField DataField="id" HeaderText="ID" SortExpression="id" />
 <asp:BoundField DataField="KPI_ID" HeaderText="KPI ID" SortExpression="KPI_ID" />
 

 <asp:BoundField DataField="KPI_NAME" HeaderText="KPI" SortExpression="KPI_NAME" />
 
<%--<asp:BoundField DataField="KPI_TYPE" HeaderText="KPI Type" SortExpression="KPI_TYPE" />--%>


         <%--<asp:TemplateField HeaderText = "KPI Type">
            <ItemTemplate>--%>


               <%-- <asp:Label ID="KPI_TYPE" runat="server" Text='<%# Eval("Country") %>' Visible = "false" />
                <asp:DropDownList ID="ddlCountries" runat="server">
                </asp:DropDownList>--%>
                <%-- OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"
    AutoPostBack="True"--%>
    
    <%--<asp:DropDownList ID="KPI_TYPE" runat="server">
                    <asp:ListItem>Absolute</asp:ListItem>
                    <asp:ListItem>Range</asp:ListItem>
                    <asp:ListItem>Metric</asp:ListItem>
                </asp:DropDownList>
            </ItemTemplate>
        </asp:TemplateField>--%>


  <asp:BoundField DataField="KPI_TYPE" HeaderText="KPI Type" SortExpression="KPI_TYPE" />
  <asp:BoundField DataField="WEIGHT" HeaderText="Weight" SortExpression="WEIGHT" />
  <asp:BoundField DataField="TARGET" HeaderText="Target" SortExpression="TARGET" />
 
 <%-- <asp:BoundField DataField="TARGET" HeaderText="Target" SortExpression="TARGET" />--%>
  <asp:TemplateField HeaderText = "Actual">
        <ItemTemplate>
            <asp:TextBox ID="ACTUAL" runat="server" ValidationGroup="check"  Text='<%#Eval("ACTUAL") %>'></asp:TextBox>
           <asp:CompareValidator ID="CompareValidator1" runat="server" Operator="DataTypeCheck" Type="Double" ControlToValidate="ACTUAL" ErrorMessage="Value must be a number" />
           <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ACTUAL" Display="Dynamic" ErrorMessage="should not be blank!"></asp:RequiredFieldValidator>
            
            <%--<asp:TextBox ID="TextBox1" runat="server" Style="z-index: 100; left: 259px; position: absolute;
top: 283px" ValidationGroup="check"></asp:TextBox>--%>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText = "Score">
        <ItemTemplate>
            <asp:TextBox ID="SCORE" runat="server" ValidationGroup="check"  Text='<%#Eval("SCORE") %>'></asp:TextBox>
           <asp:CompareValidator ID="CompareValidator1" runat="server" Operator="DataTypeCheck" Type="Double" ControlToValidate="SCORE" ErrorMessage="Value must be a number" />
           <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="SCORE" Display="Dynamic" ErrorMessage="should not be blank!"></asp:RequiredFieldValidator>
            
            <%--<asp:TextBox ID="TextBox1" runat="server" Style="z-index: 100; left: 259px; position: absolute;
top: 283px" ValidationGroup="check"></asp:TextBox>--%>
</ItemTemplate>
</asp:TemplateField>



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
            <tr>
                <td class="style92">
                    <asp:Label ID="lblFinancialComments" runat="server">Comments:</asp:Label>
                    <asp:TextBox ID="TxtFinancialComments" runat="server" BorderStyle="Solid" 
                    Height="49px" TextMode="MultiLine" Width="492px" style="text-align: left"></asp:TextBox>
                </td>
             </tr>
        </table>
                   


            </td>
    </tr>
    <tr align="center">
        <td class="style66">
           

            <%--<asp:TemplateField HeaderText="">
                        <ItemTemplate>
                            <div style="white-space: nowrap; clear: none; width: 100%; display: inline;">
                                <asp:LinkButton ID="btnDelete" runat="server" CommandName="Delete" 
                                    OnClientClick="return confirm('Are you sure you want to delete this record?');">
                                        
                                        <asp:Image ID="imgDelete" ImageUrl="~/Account/images/imgdelete1.png" runat="server" /> 
                                        </asp:LinkButton>
                            </div>
                            <div style="white-space: nowrap; clear: none; width: 100%; display: inline;">
                                <asp:LinkButton ID="btnEdit4" runat="server" CommandName="Select">
                                        
                                        <asp:Image ID="Image6" ImageUrl="~/Account/images/edit.png" 
                                    runat="server" /> 
                                        </asp:LinkButton>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>--%>
            
<table>
    <tr>
        <td class="style88">
           

           <asp:GridView ID="GrdViewCustomer" runat="server" EnableViewState="false" AllowPaging="True" 
                AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" BorderWidth="1px" 
                CssClass="Gridview" DataKeyNames="id" ForeColor="#333333" GridLines="Both" 
                OnPageIndexChanging="GrdViewCustomer_PageIndexChanging" OnRowDataBound="GrdViewCustomer_RowDataBound"
                onselectedindexchanged="GrdViewCustomer_SelectedIndexChanged" 
                OnSorting="GrdViewCustomer_Sorting" Width="930px">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <%--removed edit button from here--%>
   
   <%-- <asp:TemplateField HeaderText="">
    <ItemTemplate>
        <div style="white-space: nowrap; clear: none; width: 100%; display: inline;">
            <asp:LinkButton ID="btnEdit0" runat="server" CommandName="Select">
                                        
                    <asp:Image ID="Image2" ImageUrl="~/Account/images/edit.png" 
                runat="server" /> 
                    </asp:LinkButton>
        </div>
    </ItemTemplate>
</asp:TemplateField>

                    <asp:TemplateField HeaderText="S/N">
                        <ItemTemplate>
                              
                                <%#Container.DataItemIndex+1 %>
                           
                        </ItemTemplate>
                    </asp:TemplateField>--%>




 <asp:BoundField DataField="id" HeaderText="ID" SortExpression="id" />
  <asp:BoundField DataField="KPI_ID" HeaderText="KPI ID" SortExpression="KPI_ID" />
 <asp:BoundField DataField="KPI_NAME" HeaderText="KPI" SortExpression="KPI_NAME" />
 
<%--<asp:BoundField DataField="KPI_TYPE" HeaderText="KPI Type" SortExpression="KPI_TYPE" />--%>


         <%--<asp:TemplateField HeaderText = "KPI Type">
            <ItemTemplate>--%>


               <%-- <asp:Label ID="KPI_TYPE" runat="server" Text='<%# Eval("Country") %>' Visible = "false" />
                <asp:DropDownList ID="ddlCountries" runat="server">
                </asp:DropDownList>--%>
                <%-- OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"
    AutoPostBack="True"--%>
    
    <%--<asp:DropDownList ID="KPI_TYPE" runat="server">
                    <asp:ListItem>Absolute</asp:ListItem>
                    <asp:ListItem>Range</asp:ListItem>
                    <asp:ListItem>Metric</asp:ListItem>
                </asp:DropDownList>
            </ItemTemplate>
        </asp:TemplateField>--%>


  <asp:BoundField DataField="KPI_TYPE" HeaderText="KPI Type" SortExpression="KPI_TYPE" />
  <asp:BoundField DataField="WEIGHT" HeaderText="Weight" SortExpression="WEIGHT" />
  <asp:BoundField DataField="TARGET" HeaderText="Target" SortExpression="TARGET" />
 
 <%-- <asp:BoundField DataField="TARGET" HeaderText="Target" SortExpression="TARGET" />--%>
  <asp:TemplateField HeaderText = "Actual">
        <ItemTemplate>
            <asp:TextBox ID="ACTUAL" runat="server" ValidationGroup="check"  Text='<%#Eval("ACTUAL") %>'></asp:TextBox>
           <asp:CompareValidator ID="CompareValidator1" runat="server" Operator="DataTypeCheck" Type="Double" ControlToValidate="ACTUAL" ErrorMessage="Value must be a number" />
           <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ACTUAL" Display="Dynamic" ErrorMessage="should not be blank!"></asp:RequiredFieldValidator>
            
            <%--<asp:TextBox ID="TextBox1" runat="server" Style="z-index: 100; left: 259px; position: absolute;
top: 283px" ValidationGroup="check"></asp:TextBox>--%>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText = "Score">
        <ItemTemplate>
            <asp:TextBox ID="SCORE" runat="server" ValidationGroup="check"  Text='<%#Eval("SCORE") %>'></asp:TextBox>
           <asp:CompareValidator ID="CompareValidator1" runat="server" Operator="DataTypeCheck" Type="Double" ControlToValidate="SCORE" ErrorMessage="Value must be a number" />
           <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="SCORE" Display="Dynamic" ErrorMessage="should not be blank!"></asp:RequiredFieldValidator>
            
            <%--<asp:TextBox ID="TextBox1" runat="server" Style="z-index: 100; left: 259px; position: absolute;
top: 283px" ValidationGroup="check"></asp:TextBox>--%>
</ItemTemplate>
</asp:TemplateField>





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


                              <tr><td class="style100"> 
            <asp:Label ID="lblCustomerComments" runat="server">Comments:</asp:Label>
        &nbsp;<asp:TextBox ID="TxtCustomerComments" runat="server" BorderStyle="Solid" 
                Height="49px" TextMode="MultiLine" Width="492px" style="text-align: left"></asp:TextBox></td></tr>
                        </table>
                
                        
                   

        </td>
    </tr>
    <tr align="center">
        <td class="style66">
           

             <table>
                            <tr>
                                <td class="style88">
           

           <asp:GridView ID="GrdViewProcessEfficiency" runat="server" EnableViewState="false" AllowPaging="True" 
                AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" BorderWidth="1px" 
                CssClass="Gridview" DataKeyNames="id" ForeColor="#333333" GridLines="Both" 
                OnPageIndexChanging="GrdViewProcessEfficiency_PageIndexChanging" OnRowDataBound="GrdViewProcessEfficiency_RowDataBound"
                onselectedindexchanged="GrdViewProcessEfficiency_SelectedIndexChanged" 
                OnSorting="GrdViewProcessEfficiency_Sorting" Width="930px">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
            <%--<asp:TemplateField HeaderText="">
                <ItemTemplate>
                           
                    <div style="white-space: nowrap; clear: none; width: 100%; display: inline;">
                        <asp:LinkButton ID="btnEdit1" runat="server" CommandName="Select">
                                        
                                <asp:Image ID="Image3" ImageUrl="~/Account/images/edit.png" 
                            runat="server" /> 
                                </asp:LinkButton>
                    </div>
                </ItemTemplate>
            </asp:TemplateField>--%>


 <asp:BoundField DataField="id" HeaderText="ID" SortExpression="id" />
  <asp:BoundField DataField="KPI_ID" HeaderText="KPI ID" SortExpression="KPI_ID" />
 <asp:BoundField DataField="KPI_NAME" HeaderText="KPI" SortExpression="KPI_NAME" />
 
<%--<asp:BoundField DataField="KPI_TYPE" HeaderText="KPI Type" SortExpression="KPI_TYPE" />--%>


        <%--<asp:BoundField DataField="KPI_TYPE" HeaderText="KPI Type" SortExpression="KPI_TYPE" />--%>


         <%--<asp:TemplateField HeaderText = "KPI Type">
            <ItemTemplate>--%>


               <%-- <asp:Label ID="KPI_TYPE" runat="server" Text='<%# Eval("Country") %>' Visible = "false" />
                <asp:DropDownList ID="ddlCountries" runat="server">
                </asp:DropDownList>--%>
                <%-- OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"
    AutoPostBack="True"--%>
    
    <%--<asp:DropDownList ID="KPI_TYPE" runat="server">
                    <asp:ListItem>Absolute</asp:ListItem>
                    <asp:ListItem>Range</asp:ListItem>
                    <asp:ListItem>Metric</asp:ListItem>
                </asp:DropDownList>
            </ItemTemplate>
        </asp:TemplateField>--%>


  <asp:BoundField DataField="KPI_TYPE" HeaderText="KPI Type" SortExpression="KPI_TYPE" />
  <asp:BoundField DataField="WEIGHT" HeaderText="Weight" SortExpression="WEIGHT" />
  <asp:BoundField DataField="TARGET" HeaderText="Target" SortExpression="TARGET" />
 
 <%-- <asp:BoundField DataField="TARGET" HeaderText="Target" SortExpression="TARGET" />--%>
  <asp:TemplateField HeaderText = "Actual">
        <ItemTemplate>
            <asp:TextBox ID="ACTUAL" runat="server" ValidationGroup="check"  Text='<%#Eval("ACTUAL") %>'></asp:TextBox>
           <asp:CompareValidator ID="CompareValidator1" runat="server" Operator="DataTypeCheck" Type="Double" ControlToValidate="ACTUAL" ErrorMessage="Value must be a number" />
           <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ACTUAL" Display="Dynamic" ErrorMessage="should not be blank!"></asp:RequiredFieldValidator>
            
            <%--<asp:TextBox ID="TextBox1" runat="server" Style="z-index: 100; left: 259px; position: absolute;
top: 283px" ValidationGroup="check"></asp:TextBox>--%>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText = "Score">
        <ItemTemplate>
            <asp:TextBox ID="SCORE" runat="server" ValidationGroup="check"  Text='<%#Eval("SCORE") %>'></asp:TextBox>
           <asp:CompareValidator ID="CompareValidator1" runat="server" Operator="DataTypeCheck" Type="Double" ControlToValidate="SCORE" ErrorMessage="Value must be a number" />
           <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="SCORE" Display="Dynamic" ErrorMessage="should not be blank!"></asp:RequiredFieldValidator>
            
            <%--<asp:TextBox ID="TextBox1" runat="server" Style="z-index: 100; left: 259px; position: absolute;
top: 283px" ValidationGroup="check"></asp:TextBox>--%>
</ItemTemplate>
</asp:TemplateField>



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
                    <tr>
                    <td class="style86">
            <asp:Label ID="lblProcessEfficiencyComments" runat="server">Comments:</asp:Label>
            <asp:TextBox ID="TxtProcessEfficiencyComments" runat="server" BorderStyle="Solid" 
                Height="49px" TextMode="MultiLine" Width="492px" style="text-align: left"></asp:TextBox>
                    </td>
                </tr>
                        </table>
                   
                
               








            </td>
    </tr>
    <tr align="center">
        <td class="style66">
           



                        <table>
                            <tr>
                                <td class="style92">
           

           <asp:GridView ID="GrdViewPeople" runat="server" EnableViewState="false" AllowPaging="True" 
                AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" BorderWidth="1px" 
                CssClass="Gridview" DataKeyNames="id" ForeColor="#333333" GridLines="Both" 
                OnPageIndexChanging="GrdViewPeople_PageIndexChanging" OnRowDataBound="GrdViewPeople_RowDataBound"
                onselectedindexchanged="GrdViewPeople_SelectedIndexChanged" 
                OnSorting="GrdViewPeople_Sorting" Width="930px">
                <AlternatingRowStyle BackColor="White" />
  <Columns>
<%--                    <asp:TemplateField HeaderText="">
                        <ItemTemplate>
                            <div style="white-space: nowrap; clear: none; width: 100%; display: inline;">
                                <asp:LinkButton ID="btnEdit2" runat="server" CommandName="Select">
                                        
                                        <asp:Image ID="Image4" ImageUrl="~/Account/images/edit.png" 
                                    runat="server" /> 
                                        </asp:LinkButton>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>--%>
            
            <asp:BoundField DataField="id" HeaderText="ID" SortExpression="id" />
            <asp:BoundField DataField="KPI_ID" HeaderText="KPI ID" SortExpression="KPI_ID" />
            <asp:BoundField DataField="KPI_NAME" HeaderText="KPI" SortExpression="KPI_NAME" />
                  <%--<asp:TemplateField HeaderText = "KPI Type">
            <ItemTemplate>--%>


               <%-- <asp:Label ID="KPI_TYPE" runat="server" Text='<%# Eval("Country") %>' Visible = "false" />
                <asp:DropDownList ID="ddlCountries" runat="server">
                </asp:DropDownList>--%>
                <%-- OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"
    AutoPostBack="True"--%>
    
    <%--<asp:DropDownList ID="KPI_TYPE" runat="server">
                    <asp:ListItem>Absolute</asp:ListItem>
                    <asp:ListItem>Range</asp:ListItem>
                    <asp:ListItem>Metric</asp:ListItem>
                </asp:DropDownList>
            </ItemTemplate>
        </asp:TemplateField>--%>


  <asp:BoundField DataField="KPI_TYPE" HeaderText="KPI Type" SortExpression="KPI_TYPE" />
  <asp:BoundField DataField="WEIGHT" HeaderText="Weight" SortExpression="WEIGHT" />
  <asp:BoundField DataField="TARGET" HeaderText="Target" SortExpression="TARGET" />
 
 <%-- <asp:BoundField DataField="TARGET" HeaderText="Target" SortExpression="TARGET" />--%>
  <asp:TemplateField HeaderText = "Actual">
        <ItemTemplate>
            <asp:TextBox ID="ACTUAL" runat="server" ValidationGroup="check"  Text='<%#Eval("ACTUAL") %>'></asp:TextBox>
           <asp:CompareValidator ID="CompareValidator1" runat="server" Operator="DataTypeCheck" Type="Double" ControlToValidate="ACTUAL" ErrorMessage="Value must be a number" />
           <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ACTUAL" Display="Dynamic" ErrorMessage="should not be blank!"></asp:RequiredFieldValidator>
            
            <%--<asp:TextBox ID="TextBox1" runat="server" Style="z-index: 100; left: 259px; position: absolute;
top: 283px" ValidationGroup="check"></asp:TextBox>--%>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText = "Score">
        <ItemTemplate>
            <asp:TextBox ID="SCORE" runat="server" ValidationGroup="check"  Text='<%#Eval("SCORE") %>'></asp:TextBox>
           <asp:CompareValidator ID="CompareValidator1" runat="server" Operator="DataTypeCheck" Type="Double" ControlToValidate="SCORE" ErrorMessage="Value must be a number" />
           <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="SCORE" Display="Dynamic" ErrorMessage="should not be blank!"></asp:RequiredFieldValidator>
            
            <%--<asp:TextBox ID="TextBox1" runat="server" Style="z-index: 100; left: 259px; position: absolute;
top: 283px" ValidationGroup="check"></asp:TextBox>--%>
</ItemTemplate>
</asp:TemplateField>


  </Columns>
         <%--<asp:BoundField DataField="KPI_TYPE" HeaderText="KPI Type" SortExpression="KPI_TYPE" />--%>
         <%-- <asp:Label ID="KPI_TYPE" runat="server" Text='<%# Eval("Country") %>' Visible = "false" />
                <asp:DropDownList ID="ddlCountries" runat="server">
                </asp:DropDownList>--%>
                <%-- OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"
    AutoPostBack="True"--%>
    <%-- <asp:BoundField DataField="TARGET" HeaderText="Target" SortExpression="TARGET" />--%>
 <%--<asp:TextBox ID="TextBox1" runat="server" Style="z-index: 100; left: 259px; position: absolute;
top: 283px" ValidationGroup="check"></asp:TextBox>--%>
       
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

            <tr>
                    <td>
            <asp:Label ID="lblPeopleComments" runat="server">Comments:</asp:Label>
        &nbsp;<asp:TextBox ID="TxtPeopleComments" runat="server" BorderStyle="Solid" 
                Height="49px" TextMode="MultiLine" Width="492px" style="text-align: left"></asp:TextBox>
                    </td>
                </tr>
          </table>







        </td>
    </tr>
    <tr align="center">
        <td class="style66">
           

            <table>
                            <tr>
                                <td class="style88">
           

           <asp:GridView ID="GrdViewBrand" runat="server" EnableViewState="false" AllowPaging="True" 
                AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" BorderWidth="1px" 
                CssClass="Gridview" DataKeyNames="id" ForeColor="#333333" GridLines="Both" 
                OnPageIndexChanging="GrdViewBrand_PageIndexChanging" OnRowDataBound="GrdViewBrand_RowDataBound"
                onselectedindexchanged="GrdViewBrand_SelectedIndexChanged" 
                OnSorting="GrdViewBrand_Sorting" Width="930px">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
<%--                    <asp:TemplateField HeaderText="">
                        <ItemTemplate>
                            <div style="white-space: nowrap; clear: none; width: 100%; display: inline;">
                                <asp:LinkButton ID="btnEdit3" runat="server" CommandName="Select">
                                        
                                        <asp:Image ID="Image5" ImageUrl="~/Account/images/edit.png" 
                                    runat="server" /> 
                                        </asp:LinkButton>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>--%>

                    
 <asp:BoundField DataField="id" HeaderText="ID" SortExpression="id" />
  <asp:BoundField DataField="KPI_ID" HeaderText="KPI ID" SortExpression="KPI_ID" />
 <asp:BoundField DataField="KPI_NAME" HeaderText="KPI" SortExpression="KPI_NAME" />
 
               <%-- <asp:Label ID="KPI_TYPE" runat="server" Text='<%# Eval("Country") %>' Visible = "false" />
                <asp:DropDownList ID="ddlCountries" runat="server">
                </asp:DropDownList>--%>
                <%-- OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"
    AutoPostBack="True"--%>
    
    <%--<asp:DropDownList ID="KPI_TYPE" runat="server">
                    <asp:ListItem>Absolute</asp:ListItem>
                    <asp:ListItem>Range</asp:ListItem>
                    <asp:ListItem>Metric</asp:ListItem>
                </asp:DropDownList>
            </ItemTemplate>
        </asp:TemplateField>--%>


  <asp:BoundField DataField="KPI_TYPE" HeaderText="KPI Type" SortExpression="KPI_TYPE" />
  <asp:BoundField DataField="WEIGHT" HeaderText="Weight" SortExpression="WEIGHT" />
  <asp:BoundField DataField="TARGET" HeaderText="Target" SortExpression="TARGET" />
 
 <%-- <asp:BoundField DataField="TARGET" HeaderText="Target" SortExpression="TARGET" />--%>
  <asp:TemplateField HeaderText = "Actual">
        <ItemTemplate>
            <asp:TextBox ID="ACTUAL" runat="server" ValidationGroup="check"  Text='<%#Eval("ACTUAL") %>'></asp:TextBox>
           <asp:CompareValidator ID="CompareValidator1" runat="server" Operator="DataTypeCheck" Type="Double" ControlToValidate="ACTUAL" ErrorMessage="Value must be a number" />
           <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ACTUAL" Display="Dynamic" ErrorMessage="should not be blank!"></asp:RequiredFieldValidator>
            
            <%--<asp:TextBox ID="TextBox1" runat="server" Style="z-index: 100; left: 259px; position: absolute;
top: 283px" ValidationGroup="check"></asp:TextBox>--%>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText = "Score">
        <ItemTemplate>
            <asp:TextBox ID="SCORE" runat="server" ValidationGroup="check"  Text='<%#Eval("SCORE") %>'></asp:TextBox>
           <asp:CompareValidator ID="CompareValidator1" runat="server" Operator="DataTypeCheck" Type="Double" ControlToValidate="SCORE" ErrorMessage="Value must be a number" />
           <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="SCORE" Display="Dynamic" ErrorMessage="should not be blank!"></asp:RequiredFieldValidator>
            
            <%--<asp:TextBox ID="TextBox1" runat="server" Style="z-index: 100; left: 259px; position: absolute;
top: 283px" ValidationGroup="check"></asp:TextBox>--%>
</ItemTemplate>
</asp:TemplateField>



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
                            <tr>
                    <td class="style92">
            <asp:Label ID="lblBrandComments" runat="server">Comments:</asp:Label>
        <asp:TextBox ID="TxtBrandComments" runat="server" BorderStyle="Solid" 
                Height="49px" TextMode="MultiLine" Width="492px" style="text-align: left"></asp:TextBox>
                    </td>
                </tr>
                        </table>






        </td>
    </tr>
    <tr align="center">
        <td class="style66">
           

            
           

            <%--<asp:UpdatePanel ID="UpdatePnelSavePRGS" runat="server">
               <ContentTemplate>--%>
            <asp:Button ID="btnSavePRGS" runat="server" onclick="btnSavePRGS_Click" 
                Text="Save PR Goal Settings" Width="181px" />
               <%-- </ContentTemplate>
            </asp:UpdatePanel>--%>
           

            &nbsp;<asp:LinkButton ID="lnkbtnSavePRGS" runat="server" 
                onclick="lnkbtnSavePRGS_Click">Save PR Goal Settings</asp:LinkButton>
           

            </td>
    </tr>
</table>

</asp:Panel>



