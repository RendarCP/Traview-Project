<%@ Page Title="" Language="C#" MasterPageFile="~/PJ_traview/TraviewMaster.master" AutoEventWireup="true" CodeFile="Guide_Upload.aspx.cs" Inherits="Guide_Upload" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1">
  <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="width:100%">
        <table style="width:100%">
            <tr>
                <td style="border:2px ; text-align:center;">
                    <asp:Label ID="Label1" runat="server" Font-Bold="True" Text="작성자"></asp:Label>
                    
                    </td>
                <td colspan="2">
                <asp:TextBox ID="txtId" runat="server" ReadOnly="true" Width="700px" BorderStyle="None" style="font-family:'맑은 고딕'"></asp:TextBox>
                    &nbsp;</td>
                    </tr>
            <tr>
                <td style="border:2px ; text-align:center;">

                    <asp:Label ID="Label2" runat="server" Font-Bold="True" Text="제목"></asp:Label>

                </td>
                <td colspan="2">

                    <asp:TextBox ID="txtTitle" runat="server" Width="700px"></asp:TextBox>
                    &nbsp;</td>
                
            </tr>  
            <tr>
                <td style="border:2px ; text-align:center;">
                    <asp:Label ID="Label3" runat="server" Font-Bold="True" Text="내용"></asp:Label>
            </tr>
            <tr>
                <td colspan="3" class="auto-style1" style="border:2px solid green;">

                    <asp:TextBox ID="txtComment" runat="server" Height="403px" TextMode="MultiLine" Width="100%"></asp:TextBox>

                </td>
            </tr>
            <tr>
                <td colspan="3" style="text-align:right" class="auto-style2">
                    <asp:FileUpload ID="FileUpload1" runat="server" Font-Names="맑은 고딕" Width="500px" />
                </td>

            </tr>
             <tr>
                <td colspan="3" style="text-align:right" class="auto-style2">
                    <asp:FileUpload ID="FileUpload2" runat="server" Font-Names="맑은 고딕" Width="500px" />
                </td>

            </tr>
            <tr>
                <td colspan="2" class="auto-style1">
                    </td>
                <td style="text-align:right;" class="auto-style1">
                    
                    <asp:Button ID="btnWrite" runat="server" Text="등록" Width="100px" Font-Bold="True" OnClick="btnWrite_Click" CssClass="btn-success" />
                    <asp:Button ID="btnCancel" runat="server" Text="취소" Width="100px" Font-Bold="True" OnClick="btnCancel_Click" CssClass="btn-danger" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

