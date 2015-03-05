<%@ Control Language="C#" AutoEventWireup="true" CodeFile="OriginalPResultApplicationForm.ascx.cs" Inherits="Account_forms_OriginalPResultApplicationForm" %>
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
       </style>

<table style="width:100%;">
    <tr>
        <td class="style93">

<table style="width: 925px" class="style29">
    <tr>
        <td align="right" bgcolor="Silver" class="style21">
            &nbsp;</td>
        <td bgcolor="Silver" class="style99">
            <asp:Label ID="lblStatus" runat="server"></asp:Label>
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
                                                
    
    
    
    <fieldset style="width:300px">
    <legend>Select Date</legend>
    Year: <asp:DropDownList ID="ddlYear" runat="server" AutoPostBack="True"></asp:DropDownList> 
    Month: <asp:DropDownList ID="ddlMonth" runat="server" AutoPostBack="True" 
            onselectedindexchanged="ddlMonth_SelectedIndexChanged" 
            ontextchanged="ddlMonth_TextChanged"></asp:DropDownList> 
       
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
                
                        
             <Columns>
                             <asp:BoundField DataField="KPI_DIMENSION" HeaderText="" SortExpression="KPI_DIMENSION" />
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
           

 <asp:BoundField DataField="id" HeaderText="ID" SortExpression="id" />
 <asp:BoundField DataField="KPI_ID" HeaderText="KPI ID" SortExpression="KPI_ID" />
 

 <asp:BoundField DataField="KPI_NAME" HeaderText="KPI" SortExpression="KPI_NAME" />
 
 <%--<asp:BoundField DataField="KPI_TYPE" HeaderText="KPI Type" SortExpression="KPI_TYPE" />--%>
 <asp:BoundField DataField="WEIGHT" HeaderText="Weight" SortExpression="WEIGHT" />
 <%--<asp:BoundField DataField="TARGET" HeaderText="Target" SortExpression="TARGET" />--%>
 <asp:BoundField DataField="ACTUAL" HeaderText="Actual" SortExpression="ACTUAL" />
<%--<asp:BoundField DataField="SCORE" HeaderText="Score" SortExpression="SCORE" />
        <asp:TemplateField HeaderText = "TARGET">
        <ItemTemplate>
            <asp:TextBox ID="TARGET" runat="server" Text='<%#Eval("TARGET") %>'></asp:TextBox>
          




        </ItemTemplate>
</asp:TemplateField>--%>



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
           

            <%--<asp:Label ID="TOTAL_OBTAINABLE_SCORE1" runat="server" Text='<%#Eval("TOTAL_OBTAINABLE_SCORE"%>' />--%>
            
<table>
    <tr>
        <td class="style88">
           

           <asp:GridView ID="GrdViewCustomer" runat="server" AllowPaging="True" 
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
 <asp:BoundField DataField="WEIGHT" HeaderText="Weight" SortExpression="WEIGHT" />
 <%--<asp:BoundField DataField="TARGET" HeaderText="Target" SortExpression="TARGET" />--%>
 
 <asp:TemplateField HeaderText = "Actual">
        <ItemTemplate>
            <asp:TextBox ID="ACTUAL" runat="server" Text='<%#Eval("ACTUAL") %>'></asp:TextBox>
        </ItemTemplate>
</asp:TemplateField>
<%--<asp:BoundField DataField="SCORE" HeaderText="Score" SortExpression="SCORE" />


<asp:TemplateField HeaderText = "Score(%)">
        <ItemTemplate>
            <asp:Label ID="SCORE" runat="server" Text='<%#Eval("SCORE") %>'></asp:Label>

        </ItemTemplate>
</asp:TemplateField>--%><%--<asp:TextBox ID="SCORE" runat="server" Text='<%#Eval("SCORE") %>'></asp:TextBox>--%>
            


<%--         <asp:TemplateField HeaderText = "KPI Type">
            <ItemTemplate>
               
                <asp:DropDownList ID="KPI_TYPE" runat="server">
                    <asp:ListItem>Absolute</asp:ListItem>
                    <asp:ListItem>Range</asp:ListItem>
                    <asp:ListItem>Metric</asp:ListItem>
                </asp:DropDownList>
            </ItemTemplate>
        </asp:TemplateField>


 <asp:BoundField DataField="WEIGHT" HeaderText="Weight" SortExpression="WEIGHT" />
 
 

        <asp:TemplateField HeaderText = "TARGET">
        <ItemTemplate>
            <asp:TextBox ID="TARGET" runat="server" Text='<%#Eval("TARGET") %>'></asp:TextBox>
        </ItemTemplate>
</asp:TemplateField>--%>





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


<%-- <asp:BoundField DataField="KPI_TYPE" HeaderText="KPI Type" SortExpression="KPI_TYPE" />--%>
 <asp:BoundField DataField="WEIGHT" HeaderText="Weight" SortExpression="WEIGHT" />
<%-- <asp:BoundField DataField="TARGET" HeaderText="Target" SortExpression="TARGET" />--%>
 
 <asp:TemplateField HeaderText = "Actual">
        <ItemTemplate>
            <asp:TextBox ID="ACTUAL" runat="server" Text='<%#Eval("ACTUAL") %>'></asp:TextBox>
        </ItemTemplate>
</asp:TemplateField>
<%--<asp:BoundField DataField="SCORE" HeaderText="Score" SortExpression="SCORE" />--%>



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
            <%--<asp:BoundField DataField="KPI_TYPE" HeaderText="KPI Type" SortExpression="KPI_TYPE" />--%>
 <asp:BoundField DataField="WEIGHT" HeaderText="Weight" SortExpression="WEIGHT" />
<%-- <asp:BoundField DataField="TARGET" HeaderText="Target" SortExpression="TARGET" />--%>
 
 <asp:TemplateField HeaderText = "Actual">
        <ItemTemplate>
            <asp:TextBox ID="ACTUAL" runat="server" Text='<%#Eval("ACTUAL") %>'></asp:TextBox>
        </ItemTemplate>
</asp:TemplateField>
<%--<asp:BoundField DataField="SCORE" HeaderText="Score" SortExpression="SCORE" />--%>
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


                    
 <asp:BoundField DataField="id" HeaderText="ID" SortExpression="id" />
  <asp:BoundField DataField="KPI_ID" HeaderText="KPI ID" SortExpression="KPI_ID" />
 <asp:BoundField DataField="KPI_NAME" HeaderText="KPI" SortExpression="KPI_NAME" />
 
<%--<asp:BoundField DataField="KPI_TYPE" HeaderText="KPI Type" SortExpression="KPI_TYPE" />--%>
 <asp:BoundField DataField="WEIGHT" HeaderText="Weight" SortExpression="WEIGHT" />
 <%--<asp:BoundField DataField="TARGET" HeaderText="Target" SortExpression="TARGET" />--%>
 
 <asp:TemplateField HeaderText = "Actual">
        <ItemTemplate>
            <asp:TextBox ID="ACTUAL" runat="server" Text='<%#Eval("ACTUAL") %>'></asp:TextBox>
        </ItemTemplate>
</asp:TemplateField>
<%--<asp:BoundField DataField="SCORE" HeaderText="Score" SortExpression="SCORE" />--%>

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
           

            
           

            <%--<asp:label id="TOTAL_OBTAINABLE_SCORE1" Text= '<%# Eval("TOTAL_OBTAINABLE_SCORE") %>' runat="server"/> .ToString()+"%"--%>
            <asp:Button ID="btnSavePRAF" runat="server" onclick="btnSavePRAF_Click" 
                Text="Save PR Application Form" Width="181px" style="height: 26px" />
            <%-- 
                            <asp:BoundField DataField="INDIVIDUAL_PERFORMANCE_SCORE" HeaderText="Individual Performance Score" SortExpression="INDIVIDUAL_PERFORMANCE_SCORE" DataFormatString="{0:P}" />
                             DataFormatString="{0:C}"--%>&nbsp;</td>
    </tr>
</table>
