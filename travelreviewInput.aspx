<%@ Page Title="" Language="C#" MasterPageFile="~/PJ_traview/TraviewMaster.master" AutoEventWireup="true" CodeFile="travelreviewInput.aspx.cs" Inherits="travelreviewInput" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <!-- include libraries(jQuery, bootstrap) -->
<link href="http://netdna.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap.css" rel="stylesheet">
<script src="http://cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.js"></script> 
<script src="http://netdna.bootstrapcdn.com/bootstrap/3.3.5/js/bootstrap.js"></script> 

<!-- include summernote css/js -->
<link href="http://cdnjs.cloudflare.com/ajax/libs/summernote/0.8.9/summernote.css" rel="stylesheet">
<script src="http://cdnjs.cloudflare.com/ajax/libs/summernote/0.8.9/summernote.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <style>
        textarea{
            resize:none;
        }
        .auto-style1 {
            height: 25px;
        }
        .auto-style2 {
            height: 26px;
        }
    </style>
    <div style="width:100%">
        <table style="width:100%">
            <tr>
                <td rowspan="4" width=200px style="word-break:break-all">
                    <asp:Image ID="Image2" runat="server" ImageUrl="~/image/설명배너.jpg" />
                </td>
                <td style="border:2px solid blue; text-align:center;">

                    <asp:Label ID="Label2" runat="server" Font-Bold="True" Text="리뷰제목"></asp:Label>

                </td>
                <td colspan="2">

                    <asp:TextBox ID="txtTitle" runat="server" Width="700px"></asp:TextBox>
                    &nbsp&nbsp 도시명:<asp:DropDownList ID="ddlCity" runat="server">
                        <asp:ListItem>홍콩</asp:ListItem>
                        <asp:ListItem>오사카</asp:ListItem>
                        <asp:ListItem>후쿠오카</asp:ListItem>
                        <asp:ListItem>도쿄</asp:ListItem>
                        <asp:ListItem>베이징</asp:ListItem>
                        <asp:ListItem>상하이</asp:ListItem>
                        <asp:ListItem>타이베이</asp:ListItem>
                        <asp:ListItem>마카오</asp:ListItem>
                        <asp:ListItem>싱가포르</asp:ListItem>
                        <asp:ListItem>방콕</asp:ListItem>
                        <asp:ListItem>보라카이</asp:ListItem>
                        <asp:ListItem>다낭</asp:ListItem>
                        <asp:ListItem>호치민</asp:ListItem>
                        <asp:ListItem>라오스</asp:ListItem>
                        <asp:ListItem>파리</asp:ListItem>
                        <asp:ListItem>로마</asp:ListItem>
                        <asp:ListItem>런던</asp:ListItem>
                        <asp:ListItem>모스크바</asp:ListItem>
                        <asp:ListItem>뉴욕</asp:ListItem>
                        <asp:ListItem>하와이</asp:ListItem>
                        <asp:ListItem>샌프란시스코</asp:ListItem>
                        <asp:ListItem>라스베이거스</asp:ListItem>
                        <asp:ListItem>서울</asp:ListItem>
                        <asp:ListItem>부산</asp:ListItem>
                        <asp:ListItem>제주</asp:ListItem>
                        <asp:ListItem>전주</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td rowspan="4" width=200px style="word-break:break-all">
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/image/배너테스트.jpg" />
                </td>
            </tr>  
            <tr>
                <td colspan="3" class="auto-style1" style="border:2px solid green;">

                    <asp:TextBox ID="txtContents" runat="server" Height="400px" TextMode="MultiLine" Width="99.7%"></asp:TextBox>

                </td>
            </tr>
            <tr>
                <td colspan="3" style="text-align:right" class="auto-style2">

                    <asp:FileUpload ID="FileUpload1" runat="server" Font-Names="맑은 고딕" Width="500px" />
                </td>
            </tr>
            <tr>
                <td colspan="2" class="auto-style1">
                    </td>
                <td style="text-align:right;" class="auto-style1">
                    
                    <asp:Button ID="btnRewEn" runat="server" Text="등록" Width="100px" Font-Bold="True" OnClick="btnRewEn_Click" CssClass="btn-success" />

                </td>
            </tr>
        </table>
    </div>
</asp:Content>

