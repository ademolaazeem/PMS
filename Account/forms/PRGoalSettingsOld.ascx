<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PRGoalSettingsOld.ascx.cs" Inherits="Account_forms_PRGoalSettingsOld" %>
<script runat="server">


</script>
<style type="text/css">


    .style21
    {
        width: 306px;
    }
    .style16
    {
        width: 246px;
        height: 22px;
        text-align: left;
    }
    .style26
    {
        height: 22px;
        width: 629px;
        text-align: left;
    }
        .style14
    {
        width: 246px;
        height: 17px;
        text-align: left;
    }
        .style24
    {
        height: 17px;
        width: 629px;
        text-align: left;
    }
    .style13
    {
        width: 246px;
        height: 23px;
        background-color: #CCCCFF;
        text-align: left;
    }
    .Gridview
        {
        margin-right: 170px;
    }
        .style27
    {
        width: 629px;
        height: 23px;
        background-color: #CCCCFF;
        text-align: left;
    }
    .style28
    {
        height: 23px;
    }
        .style29
    {
        width: 93%;
        border-style: solid;
        border-width: 1px;
    }
    .style30
    {
        height: 19px;
        background-color: #CCCCCC;
    }
    .style32
    {
        height: 19px;
        width: 262px;
        background-color: #C0C0C0;
    }
    .style34
    {
        height: 19px;
        width: 202px;
        text-align: left;
    }
    .style36
    {
        width: 202px;
        text-align: left;
        height: 27px;
        background-color: #CCCCCC;
    }
    .style38
    {
        width: 262px;
        height: 27px;
    }
    .style39
    {
        height: 27px;
    }
    .style40
    {
        height: 25px;
        width: 202px;
        text-align: left;
        background-color: #CCCCCC;
    }
    .style42
    {
        height: 25px;
        width: 262px;
    }
    .style43
    {
        height: 25px;
        color: #CCCCCC;
    }
    .style44
    {
        width: 202px;
        text-align: left;
        height: 30px;
        background-color: #CCCCCC;
    }
    .style45
    {
        height: 30px;
    }
    .style46
    {
        width: 262px;
        height: 30px;
    }
    .style49
    {
        width: 202px;
        height: 27px;
        background-color: #CCCCCC;
    }
    .style50
    {
        height: 14px;
        width: 202px;
        text-align: left;
    }
    .style51
    {
        height: 14px;
        background-color: #CCCCCC;
    }
    .style52
    {
        height: 14px;
        width: 262px;
        background-color: #C0C0C0;
    }
    .style53
    {
        height: 31px;
        text-align: left;
    }
    .style55
    {
        height: 26px;
        width: 262px;
        background-color: #FFFFFF;
    }
    .style56
    {
        height: 26px;
        background-color: #FFFFFF;
    }
    .style57
    {
        height: 26px;
        width: 312px;
    }
    .style58
    {
        height: 27px;
        text-align: left;
    }
    .style59
    {
        height: 25px;
        width: 312px;
    }
    .style60
    {
        height: 30px;
        width: 312px;
    }
    .style61
    {
        height: 14px;
        width: 312px;
    }
    .style62
    {
        height: 19px;
        width: 312px;
    }
    .style63
    {
        height: 31px;
        width: 312px;
        background-color: #CCCCCC;
    }
    .style64
    {
        height: 26px;
        width: 202px;
        text-align: left;
        background-color: #CCCCCC;
    }
    .style65
    {
        height: 31px;
        background-color: #CCCCCC;
    }
        .style66
    {
        height: 12px;
    }
    .style67
    {
        height: 31px;
        background-color: #CCCCCC;
        width: 262px;
    }
    .style68
    {
        height: 31px;
        text-align: left;
        background-color: #CCCCCC;
    }
    .style69
    {
        height: 26px;
        width: 202px;
        text-align: center;
        background-color: #999999;
        color: #FFFFFF;
    }
    .style70
    {
        height: 26px;
        width: 312px;
        color: #FFFFFF;
        background-color: #999999;
    }
    .style71
    {
        height: 26px;
        background-color: #999999;
        color: #FFFFFF;
        width: 232px;
    }
    .style72
    {
        height: 26px;
        width: 262px;
        background-color: #999999;
        color: #FFFFFF;
    }
    .style73
    {
        height: 27px;
        color: #CCCCCC;
        background-color: #CCCCCC;
        width: 232px;
    }
    .style74
    {
        width: 262px;
        height: 27px;
        background-color: #CCCCCC;
    }
    .style75
    {
        width: 262px;
        height: 30px;
        background-color: #CCCCCC;
    }
    .style76
    {
        height: 25px;
        width: 262px;
        background-color: #CCCCCC;
    }
    .style78
    {
        height: 30px;
        background-color: #CCCCCC;
        width: 232px;
    }
        .style81
    {
        width: 202px;
        text-align: center;
        height: 30px;
        background-color: #CCCCCC;
    }
    .style82
    {
        height: 25px;
        width: 202px;
        text-align: center;
        background-color: #CCCCCC;
    }
        .style83
    {
        width: 202px;
        text-align: center;
        height: 27px;
        background-color: #FFFFFF;
    }
        </style>

<table style="width:100%;">
    <tr>
        <td>

<table style="width: 950px">
    <tr>
        <td align="right" bgcolor="Silver" class="style21">
            &nbsp;</td>
        <td bgcolor="Silver">
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
    <tr align="center">
        <td>
           <%--<table cellpadding="0" cellspacing="0" style="width: 950px">--%>
           <table cellpadding="0" cellspacing="0" class="style29" style="width: 950px">
           <tr>
        <td class="style16">
            Name:</td>
        <td class="style26">
               </td>
    </tr>
    <tr>
        <td class="style13">
            Grade Level:</td>
        <td class="style27">
            </td>
    </tr>
    <tr>
        <td class="style14">
            Group/Department:</td>
        <td class="style24">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style13">
            </td>
        <td class="style27">
            &nbsp;</td>
    </tr>
           </table>

            </td>
    </tr>
    <tr align="center">
        <td>
           

            &nbsp;</td>
    </tr>
    <tr align="center">
        <td>
           

            <table cellpadding="0" cellspacing="0" class="style29" style="width: 950px">
                <tr>
                    <td class="style53">
                    </td>
                    <td class="style63">
                        Total Number of KPIs</td>
                    <td class="style65">
                        Total Obtainable Score</td>
                    <td class="style67">
                        Individual Performance Score</td>
                </tr>
                <tr>
                    <td class="style64">
                        Financial</td>
                    <td class="style57">
                    </td>
                    <td class="style56">
                    </td>
                    <td class="style55">
                    </td>
                </tr>
                <tr>
                    <td class="style49" style="text-align: left">
                        Customer</td>
                    <td class="style58">
                    </td>
                    <td class="style39">
                    </td>
                    <td class="style38">
                    </td>
                </tr>
                <tr>
                    <td class="style40">
                        Process Efficiency</td>
                    <td class="style59">
                    </td>
                    <td class="style43">
                    </td>
                    <td class="style42">
                    </td>
                </tr>
                <tr>
                    <td class="style44">
                        People</td>
                    <td class="style60">
                    </td>
                    <td class="style45">
                    </td>
                    <td class="style46">
                    </td>
                </tr>
                <tr>
                    <td class="style36">
                        Brand</td>
                    <td class="style58">
                    </td>
                    <td class="style39">
                    </td>
                    <td class="style38">
                    </td>
                </tr>
                <tr>
                    <td class="style50">
                    </td>
                    <td class="style61">
                    </td>
                    <td class="style51">
                        100%</td>
                    <td class="style52">
                    </td>
                </tr>
                <tr>
                    <td class="style34">
                    </td>
                    <td class="style62">
                        Weighted Score</td>
                    <td class="style30">
                        70%</td>
                    <td class="style32">
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr align="center">
        <td class="style66">
           

            </td>
    </tr>
    <tr align="center">
        <td>
           

            <table cellpadding="0" cellspacing="0" class="style29" style="width: 950px">
                <tr>
                    <td class="style68" colspan="4">
                        Financial (Job holder’s direct contribution to CDL&#39;s profitability in 
                        quantitative terms and financial management capabilities)</td>
                </tr>
                <tr>
                    <td class="style69">
                        KPI</td>
                    <td class="style70">
                        KPI Type</td>
                    <td class="style71">
                        Weight</td>
                    <td class="style72">
                        Target</td>
                </tr>
                <tr>
                    <td class="style49">
                        &nbsp;</td>
                    <td class="style58">
                    </td>
                    <td class="style73">
                    </td>
                    <td class="style74">
                    </td>
                </tr>
                <tr>
                    <td class="style82">
                        &nbsp;</td>
                    <td class="style59">
                    </td>
                    <td class="style73">
                        &nbsp;</td>
                    <td class="style76">
                    </td>
                </tr>
                <tr>
                    <td class="style81">
                        &nbsp;</td>
                    <td class="style60">
                    </td>
                    <td class="style78">
                    </td>
                    <td class="style75">
                    </td>
                </tr>
                <tr>
                    <td class="style83">
                        Comments</td>
                    <td class="style58" colspan="3">
                    </td>
                </tr>
                </table>
        </td>
    </tr>
    <tr align="center">
        <td>
           

            &nbsp;</td>
    </tr>
    <tr align="center">
        <td>
           

            <table cellpadding="0" cellspacing="0" class="style29" style="width: 950px">
                <tr>
                    <td class="style68" colspan="4">
                        Customer (Job holder’s ability to grow, maintain and retain CDL&#39;s customer base)</td>
                </tr>
                <tr>
                    <td class="style69">
                        KPI</td>
                    <td class="style70">
                        KPI Type</td>
                    <td class="style71">
                        Weight</td>
                    <td class="style72">
                        Target</td>
                </tr>
                <tr>
                    <td class="style49">
                        &nbsp;</td>
                    <td class="style58">
                    </td>
                    <td class="style73">
                    </td>
                    <td class="style74">
                    </td>
                </tr>
                <tr>
                    <td class="style82">
                        &nbsp;</td>
                    <td class="style59">
                    </td>
                    <td class="style73">
                        &nbsp;</td>
                    <td class="style76">
                    </td>
                </tr>
                <tr>
                    <td class="style81">
                        &nbsp;</td>
                    <td class="style60">
                    </td>
                    <td class="style78">
                    </td>
                    <td class="style75">
                    </td>
                </tr>
                <tr>
                    <td class="style83">
                        Comments</td>
                    <td class="style58" colspan="3">
                    </td>
                </tr>
                </table>
        </td>
    </tr>
    <tr align="center">
        <td>
           

            &nbsp;</td>
    </tr>
    <tr align="center">
        <td>
           

            <table cellpadding="0" cellspacing="0" class="style29" style="width: 950px">
                <tr>
                    <td class="style68" colspan="4">
                        Process Efficiency (Job holder’s ability to achieve CDL&#39;s defined internal 
                        process standards)</td>
                </tr>
                <tr>
                    <td class="style69">
                        KPI</td>
                    <td class="style70">
                        KPI Type</td>
                    <td class="style71">
                        Weight</td>
                    <td class="style72">
                        Target</td>
                </tr>
                <tr>
                    <td class="style49">
                        &nbsp;</td>
                    <td class="style58">
                    </td>
                    <td class="style73">
                    </td>
                    <td class="style74">
                    </td>
                </tr>
                <tr>
                    <td class="style82">
                        &nbsp;</td>
                    <td class="style59">
                    </td>
                    <td class="style73">
                        &nbsp;</td>
                    <td class="style76">
                    </td>
                </tr>
                <tr>
                    <td class="style81">
                        &nbsp;</td>
                    <td class="style60">
                    </td>
                    <td class="style78">
                    </td>
                    <td class="style75">
                    </td>
                </tr>
                <tr>
                    <td class="style83">
                        Comments</td>
                    <td class="style58" colspan="3">
                    </td>
                </tr>
                </table>
        </td>
    </tr>
    <tr align="center">
        <td>
           

            &nbsp;</td>
    </tr>
    <tr align="center">
        <td>
           

            <table cellpadding="0" cellspacing="0" class="style29" style="width: 950px">
                <tr>
                    <td class="style68" colspan="4">
                        People (Job holder&#39;s innovation and learning capabilities)</td>
                </tr>
                <tr>
                    <td class="style69">
                        KPI</td>
                    <td class="style70">
                        KPI Type</td>
                    <td class="style71">
                        Weight</td>
                    <td class="style72">
                        Target</td>
                </tr>
                <tr>
                    <td class="style49">
                        &nbsp;</td>
                    <td class="style58">
                    </td>
                    <td class="style73">
                    </td>
                    <td class="style74">
                    </td>
                </tr>
                <tr>
                    <td class="style82">
                        &nbsp;</td>
                    <td class="style59">
                    </td>
                    <td class="style73">
                        &nbsp;</td>
                    <td class="style76">
                    </td>
                </tr>
                <tr>
                    <td class="style81">
                        &nbsp;</td>
                    <td class="style60">
                    </td>
                    <td class="style78">
                    </td>
                    <td class="style75">
                    </td>
                </tr>
                <tr>
                    <td class="style83">
                        Comments</td>
                    <td class="style58" colspan="3">
                    </td>
                </tr>
                </table>
        </td>
    </tr>
    <tr align="center">
        <td>
           

            &nbsp;</td>
    </tr>
    <tr align="center">
        <td>
           

            <table cellpadding="0" cellspacing="0" class="style29" style="width: 950px">
                <tr>
                    <td class="style68" colspan="4">
                        Brand (How external parties view CDL)</td>
                </tr>
                <tr>
                    <td class="style69">
                        KPI</td>
                    <td class="style70">
                        KPI Type</td>
                    <td class="style71">
                        Weight</td>
                    <td class="style72">
                        Target</td>
                </tr>
                <tr>
                    <td class="style49">
                        &nbsp;</td>
                    <td class="style58">
                    </td>
                    <td class="style73">
                    </td>
                    <td class="style74">
                    </td>
                </tr>
                <tr>
                    <td class="style82">
                        &nbsp;</td>
                    <td class="style59">
                    </td>
                    <td class="style73">
                        &nbsp;</td>
                    <td class="style76">
                    </td>
                </tr>
                <tr>
                    <td class="style81">
                        &nbsp;</td>
                    <td class="style60">
                    </td>
                    <td class="style78">
                    </td>
                    <td class="style75">
                    </td>
                </tr>
                <tr>
                    <td class="style83">
                        Comments</td>
                    <td class="style58" colspan="3">
                    </td>
                </tr>
                </table>
        </td>
    </tr>
    <tr align="center">
        <td>
           

            &nbsp;</td>
    </tr>
</table>




