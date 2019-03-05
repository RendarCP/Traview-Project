<%@ Page Title="" Language="C#" MasterPageFile="~/PJ_traview/TraviewMaster.master" AutoEventWireup="true" CodeFile="Info_master.aspx.cs" Inherits="Info_master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <style>
        table{
            width:70%;
            height:100%;
            margin: auto;
            text-align:center;
            table-layout:fixed;
            border:1px solid black;
        }
        .textleft{
            text-align:left;
        }
      /*  .auto-style4{
            position:absolute;
            display:table-cell;
            line-height: 30px;
            text-align:center;
            vertical-align: middle;
            margin-left: auto;
            margin-right: auto;
        }  */
        .middle{         
         text-align:left;
         display: inline-block;
        }
        .auto-style1{
            height:50px;
        }
         /*A태그 CSS 제목클릭시 나타나는것들 제거*/
     a,a:hover{
         color:#000000;
         text-decoration:none;
     }
    </style>
     <div style="text-align:center;">
        <h1>여행정보</h1>
    </div>
   <div>
      <table style="height:400px;">
          <tr>
              <td style="border-right:1px solid #d6d4d4; background-color:#efefef;" class="auto-style1">
                  <asp:Label ID="Label1" runat="server" Text="아시아" Font-Bold="True" Font-Names="돋움체" Font-Size="20px"></asp:Label></td>
              <td style="border-right:1px solid #d6d4d4; background-color:#efefef;" class="auto-style1">
                  <asp:Label ID="Label2" runat="server" Text="동남아시아" Font-Bold="True" Font-Names="돋움체" Font-Size="20px"></asp:Label>
              </td>
              <td style="border-right:1px solid #d6d4d4; background-color:#efefef;" class="auto-style1">
                  <asp:Label ID="Label3" runat="server" Text="유럽" Font-Bold="True" Font-Names="돋움체" Font-Size="20px"></asp:Label>
              </td>
              <td style="border-right:1px solid #d6d4d4; background-color:#efefef;" class="auto-style1">
                  <asp:Label ID="Label4" runat="server" Text="아메리카" Font-Bold="True" Font-Names="돋움체" Font-Size="20px"></asp:Label>
              </td>
              <td style="background-color:#efefef;" class="auto-style1">
                  <asp:Label ID="Label5" runat="server" Text="한국" Font-Bold="True" Font-Names="돋움체" Font-Size="20px"></asp:Label>
              </td>
          </tr>
          <tr>
              <td class="auto-style4">
                  <div class="middle">
                  <asp:Image ID="imgHong" runat="server" ImageUrl="~/image/홍콩.png" />&nbsp<asp:HyperLink ID="HyperLink1" runat="server" Font-Bold="True" Font-Names="맑은 고딕" Font-Size="15pt" NavigateUrl="Info_traview.aspx?country=hong_kong" >홍콩</asp:HyperLink><br />
                  <asp:Image ID="imgOsaka" runat="server" ImageUrl="~/image/일본.png" />&nbsp<asp:HyperLink ID="HyperLink2" runat="server" Font-Bold="True" Font-Names="맑은 고딕" Font-Size="15pt" NavigateUrl="Info_traview.aspx?country=osaka"  >오사카</asp:HyperLink><br />
                  <asp:Image ID="ImgFukuoka" runat="server" ImageUrl="~/image/일본.png" />&nbsp<asp:HyperLink ID="HyperLink3" runat="server" Font-Bold="True" Font-Names="맑은 고딕" Font-Size="15pt" NavigateUrl="Info_traview.aspx?country=fukuoka"  >후쿠오카</asp:HyperLink><br />
                  <asp:Image ID="ImgTokyo" runat="server" ImageUrl="~/image/일본.png" />&nbsp<asp:HyperLink ID="HyperLink4" runat="server" Font-Bold="True" Font-Names="맑은 고딕" Font-Size="15pt" NavigateUrl="Info_traview.aspx?country=tokyo"  >도쿄</asp:HyperLink><br />
                  <asp:Image ID="ImgBeijing" runat="server" ImageUrl="~/image/중국.png" />&nbsp<asp:HyperLink ID="HyperLink21" runat="server" Font-Bold="True" Font-Names="맑은 고딕" Font-Size="15pt" NavigateUrl="Info_traview.aspx?country=Beijing"  >베이징</asp:HyperLink><br />
                  <asp:Image ID="ImgShanghai" runat="server" ImageUrl="~/image/중국.png" />&nbsp<asp:HyperLink ID="HyperLink22" runat="server" Font-Bold="True" Font-Names="맑은 고딕" Font-Size="15pt" NavigateUrl="Info_traview.aspx?country=Shanghai" >상하이</asp:HyperLink><br />
                  <asp:Image ID="ImgTapei" runat="server" ImageUrl="~/image/대만.png" />&nbsp<asp:HyperLink ID="HyperLink23" runat="server" Font-Bold="True" Font-Names="맑은 고딕" Font-Size="15pt" NavigateUrl="Info_traview.aspx?country=taipei" >타이베이</asp:HyperLink><br />
                  <asp:Image ID="ImgMacau" runat="server" ImageUrl="~/image/마카오.png" />&nbsp<asp:HyperLink ID="HyperLink24" runat="server" Font-Bold="True" Font-Names="맑은 고딕" Font-Size="15pt" NavigateUrl="Info_traview.aspx?country=macao"  >마카오</asp:HyperLink><br />
                  </div>
              </td>
              <td class="auto-style4">
                                    <div class="middle">
                  <asp:Image ID="Image5" runat="server" ImageUrl="~/image/싱가포르.png" />&nbsp<asp:HyperLink ID="HyperLink5" runat="server" Font-Bold="True" Font-Names="맑은 고딕" Font-Size="15pt" NavigateUrl="Info_traview.aspx?country=Singapore" >싱가포르</asp:HyperLink><br />
                  <asp:Image ID="Image6" runat="server" ImageUrl="~/image/태국.png" />&nbsp<asp:HyperLink ID="HyperLink6" runat="server" Font-Bold="True" Font-Names="맑은 고딕" Font-Size="15pt" NavigateUrl="Info_traview.aspx?country=Bangkok" >방콕</asp:HyperLink><br />
                  <asp:Image ID="Image7" runat="server" ImageUrl="~/image/필리핀.png" />&nbsp<asp:HyperLink ID="HyperLink7" runat="server" Font-Bold="True" Font-Names="맑은 고딕" Font-Size="15pt" NavigateUrl="Info_traview.aspx?country=Boracay" >보라카이</asp:HyperLink><br />
                  <asp:Image ID="Image8" runat="server" ImageUrl="~/image/베트남.png" />&nbsp<asp:HyperLink ID="HyperLink8" runat="server" Font-Bold="True" Font-Names="맑은 고딕" Font-Size="15pt" NavigateUrl="Info_traview.aspx?country=danang" >다낭</asp:HyperLink><br />
                  <asp:Image ID="Image25" runat="server" ImageUrl="~/image/베트남.png" />&nbsp<asp:HyperLink ID="HyperLink25" runat="server" Font-Bold="True" Font-Names="맑은 고딕" Font-Size="15pt" NavigateUrl="Info_traview.aspx?country=hochiminh" >호치민</asp:HyperLink><br />
                  <asp:Image ID="Image26" runat="server" ImageUrl="~/image/라오스.png" />&nbsp<asp:HyperLink ID="HyperLink26" runat="server" Font-Bold="True" Font-Names="맑은 고딕" Font-Size="15pt" NavigateUrl="Info_traview.aspx?country=Laos" >라오스</asp:HyperLink><br />
                                        </div>
              </td>
              <td class="auto-style4">
                  <div class="middle">
                  <asp:Image ID="Image9" runat="server" ImageUrl="~/image/프랑스.png" />&nbsp<asp:HyperLink ID="HyperLink9" runat="server" Font-Bold="True" Font-Names="맑은 고딕" Font-Size="15pt" NavigateUrl="Info_traview.aspx?country=Paris" >파리</asp:HyperLink><br />
                  <asp:Image ID="Image10" runat="server" ImageUrl="~/image/이탈리아.png" />&nbsp<asp:HyperLink ID="HyperLink10" runat="server" Font-Bold="True" Font-Names="맑은 고딕" Font-Size="15pt" NavigateUrl="Info_traview.aspx?country=Rome" >로마</asp:HyperLink><br />
                  <asp:Image ID="Image11" runat="server" ImageUrl="~/image/영국.png" />&nbsp<asp:HyperLink ID="HyperLink11" runat="server" Font-Bold="True" Font-Names="맑은 고딕" Font-Size="15pt" NavigateUrl="Info_traview.aspx?country=London" >런던</asp:HyperLink><br />
                  <asp:Image ID="Image12" runat="server" ImageUrl="~/image/러시아.png" />&nbsp<asp:HyperLink ID="HyperLink12" runat="server" Font-Bold="True" Font-Names="맑은 고딕" Font-Size="15pt" NavigateUrl="Info_traview.aspx?country=Moscow" >모스크바</asp:HyperLink><br />
                      </div>
              </td>
              <td class="auto-style4">
                  <div class="middle">
                  <asp:Image ID="Image13" runat="server" ImageUrl="~/image/미국.png" />&nbsp<asp:HyperLink ID="HyperLink13" runat="server" Font-Bold="True" Font-Names="맑은 고딕" Font-Size="15pt" NavigateUrl="Info_traview.aspx?country=New_York" >뉴욕</asp:HyperLink><br />
                  <asp:Image ID="Image14" runat="server" ImageUrl="~/image/미국.png" />&nbsp<asp:HyperLink ID="HyperLink14" runat="server" Font-Bold="True" Font-Names="맑은 고딕" Font-Size="15pt" NavigateUrl="Info_traview.aspx?country=Hawaii" >하와이</asp:HyperLink><br />
                  <asp:Image ID="Image15" runat="server" ImageUrl="~/image/미국.png" />&nbsp<asp:HyperLink ID="HyperLink15" runat="server" Font-Bold="True" Font-Names="맑은 고딕" Font-Size="15pt" NavigateUrl="Info_traview.aspx?country=San_Francisco" >샌프란시스코</asp:HyperLink><br />
                  <asp:Image ID="Image16" runat="server" ImageUrl="~/image/미국.png"  />&nbsp<asp:HyperLink ID="HyperLink16" runat="server" Font-Bold="True" Font-Names="맑은 고딕" Font-Size="15pt" NavigateUrl="Info_traview.aspx?country=Las_Vegas"  >라스베이거스</asp:HyperLink><br />
                      </div>
              </td>
              <td class="auto-style4">
                  <div class="middle">
                  <asp:Image ID="Image17" runat="server" ImageUrl="~/image/한국.png" />&nbsp<asp:HyperLink ID="HyperLink17" runat="server" Font-Bold="True" Font-Names="맑은 고딕" Font-Size="15pt" NavigateUrl="Info_traview.aspx?country=seoul" >서울</asp:HyperLink><br />
                  <asp:Image ID="Image18" runat="server" ImageUrl="~/image/한국.png" />&nbsp<asp:HyperLink ID="HyperLink18" runat="server" Font-Bold="True" Font-Names="맑은 고딕" Font-Size="15pt" NavigateUrl="Info_traview.aspx?country=busan" >부산</asp:HyperLink><br />
                  <asp:Image ID="Image19" runat="server" ImageUrl="~/image/한국.png" />&nbsp<asp:HyperLink ID="HyperLink19" runat="server" Font-Bold="True" Font-Names="맑은 고딕" Font-Size="15pt" NavigateUrl="Info_traview.aspx?country=jeju" >제주</asp:HyperLink><br />
                  <asp:Image ID="Image20" runat="server" ImageUrl="~/image/한국.png" />&nbsp<asp:HyperLink ID="HyperLink20" runat="server" Font-Bold="True" Font-Names="맑은 고딕" Font-Size="15pt" NavigateUrl="Info_traview.aspx?country=jeonju" >전주</asp:HyperLink><br />
                      </div>
              </td>
          </tr>
      </table>
  </div> 
    <div style="text-align:center">
        <asp:Button ID="btnInputinfo" runat="server" Text="여행정보삽입" OnClick="btnInputinfo_Click" Visible="False" CssClass="btn-success" />
    </div>
</asp:Content>

