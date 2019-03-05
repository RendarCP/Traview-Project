<%@ Page Title="" Language="C#" MasterPageFile="~/PJ_traview/TraviewMaster.master" AutoEventWireup="true" CodeFile="EventInputpage.aspx.cs" Inherits="EventInputpage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            height: 24px;
        }
        
    </style>
   <script src="//cdn.ckeditor.com/4.10.1/basic/ckeditor.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    <table style="width:100%" >
        <tr>
            <td style="text-align:center; width:200px; border:solid 2px black">

                <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Names="맑은 고딕" Text="이벤트 명"></asp:Label>

            </td>
            <td colspan="5" style="width:800px">
                <asp:TextBox ID="txtEventtitle" runat="server" Width="100%"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="6" style="border:solid 2px black">

                <asp:TextBox ID="txtEventContent" runat="server" Height="100px" TextMode="MultiLine" Width="100%"></asp:TextBox>

            </td>
        </tr>
        <tr>
            <td colspan="6" style="text-align:right">
                <asp:FileUpload ID="FileUpload1" runat="server" Font-Bold="False" Font-Names="맑은 고딕" Width="500px" />
            </td>
        </tr>
        <tr style="width:100%;" >
            <td style="text-align:center; vertical-align:middle; width:10%;" >
                <asp:Label ID="Label1" runat="server" Text="시작일"></asp:Label>
            </td>
            <td style="width:20%">
                <asp:Calendar ID="CldStart" runat="server" OnSelectionChanged="CldStart_SelectionChanged"></asp:Calendar>
            </td>
            <td style="text-align:center; vertical-align:middle; width:10%">
                <asp:Label ID="Label3" runat="server" Text="종료일"></asp:Label>
            </td>
            <td style="width:20%">
                <asp:Calendar ID="CldEnd" runat="server" OnSelectionChanged="CldEnd_SelectionChanged"></asp:Calendar>
            </td>
            <td style="text-align:center; vertical-align:middle; width:10%">
                <asp:Label ID="Label4" runat="server" Text="발표일"></asp:Label>
            </td>
            <td style="width:20%">
                <asp:Calendar ID="CldAnnounce" runat="server" OnSelectionChanged="CldAnnounce_SelectionChanged"></asp:Calendar>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="text-align:center">
                <asp:TextBox ID="TxtStart" runat="server" ReadOnly="True"></asp:TextBox>
            </td>
            <td colspan="2" style="text-align:center">
                <asp:TextBox ID="TxtEnd" runat="server" ReadOnly="True"></asp:TextBox>
            </td>
            <td colspan="2" style="text-align:center">
                <asp:TextBox ID="TxtAnnouce" runat="server" ReadOnly="True"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="5">

            </td>
            <td style="text-align:right">
                <asp:Button ID="btnEventUpload" runat="server" Text="이벤트 올리기" OnClick="btnEventUpload_Click" />
            </td>
        </tr>
    </table>
        </div>
</asp:Content>

