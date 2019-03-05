<%@ Page Title="" Language="C#" MasterPageFile="~/PJ_traview/TraviewMaster.master" AutoEventWireup="true" CodeFile="TripInfo_Input.aspx.cs" Inherits="TripInfo_Input" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
        <style type="text/css">
          /*회원가입 글자*/
        .h3font{
            font-size:30px;
            font-family:"맑은 고딕";
        }
          /*회원가입 아래글자*/
        .subfont{
            font-size:15px;
            font-family:"맑은 고딕";
        }
          /*th클래스 지정*/
        .th{
            width:200px;
            height:40px;
        }
          /*테이블,th,td의 테두리 지정 */
          table {
                
              border-top: 2px solid #000000;
                border-collapse: collapse;
              }
        th, td {
            border-bottom: 1px solid #444444;
            border-right:1px solid #444444;
            padding: 10px;
        }

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="text-align:center">
        <asp:Label ID="Label1" runat="server" Text="여행정보입력" Font-Bold="True" Font-Size="30px"></asp:Label>
    </div>
    <div style="width:100%">
        <table style="width:100%;text-align:center">
          <tr>
              <td style="width:30%">
                  <asp:Label ID="lblCountryname" runat="server" Text="나라이름:" Height="20px" Width="200px" Font-Bold="True" Font-Names="맑은 고딕" Font-Size="20px"></asp:Label>
              </td>
              <td>
                  <asp:TextBox ID="txtCountry" runat="server" Width="1000px" Height="20px"></asp:TextBox>
              </td>
          </tr>
            <tr>
                <td>
                   <asp:Label ID="lblSeason" runat="server" Text="여행시기:" Height="20px" Width="200px" Font-Bold="True" Font-Names="맑은 고딕" Font-Size="20px"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlSeason1" runat="server" Height="20px" Width="300px">
                        <asp:ListItem>1월</asp:ListItem>
                        <asp:ListItem>2월</asp:ListItem>
                        <asp:ListItem>3월</asp:ListItem>
                        <asp:ListItem>4월</asp:ListItem>
                        <asp:ListItem>5월</asp:ListItem>
                        <asp:ListItem>6월</asp:ListItem>
                        <asp:ListItem>7월</asp:ListItem>
                        <asp:ListItem>8월</asp:ListItem>
                        <asp:ListItem>9월</asp:ListItem>
                        <asp:ListItem>10월</asp:ListItem>
                        <asp:ListItem>11월</asp:ListItem>
                        <asp:ListItem>12월</asp:ListItem>
                    </asp:DropDownList>&nbsp&nbsp~&nbsp&nbsp<asp:DropDownList ID="ddlSeason2" runat="server" Width="300px">
                                                <asp:ListItem>1월</asp:ListItem>
                        <asp:ListItem>2월</asp:ListItem>
                        <asp:ListItem>3월</asp:ListItem>
                        <asp:ListItem>4월</asp:ListItem>
                        <asp:ListItem>5월</asp:ListItem>
                        <asp:ListItem>6월</asp:ListItem>
                        <asp:ListItem>7월</asp:ListItem>
                        <asp:ListItem>8월</asp:ListItem>
                        <asp:ListItem>9월</asp:ListItem>
                        <asp:ListItem>10월</asp:ListItem>
                        <asp:ListItem>11월</asp:ListItem>
                        <asp:ListItem>12월</asp:ListItem>
                                                            </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblElect" runat="server" Text="전압:" Height="20px" Width="200px" Font-Bold="True" Font-Names="맑은 고딕" Font-Size="20px"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlElect" runat="server" Width="500px">
                        <asp:ListItem>110V</asp:ListItem>
                        <asp:ListItem>115V</asp:ListItem>
                        <asp:ListItem>120V</asp:ListItem>
                        <asp:ListItem>127V</asp:ListItem>
                        <asp:ListItem>200V</asp:ListItem>
                        <asp:ListItem>220V</asp:ListItem>
                        <asp:ListItem>230V</asp:ListItem>
                        <asp:ListItem>240V</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                  <asp:Label ID="lblFlying" runat="server" Text="비행시간:" Height="20px" Width="200px" Font-Bold="True" Font-Names="맑은 고딕" Font-Size="20px"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="Label4" runat="server" Text="비행타입" Font-Bold="True" Font-Names="맑은 고딕"></asp:Label>&nbsp<asp:TextBox ID="txtFlyingtype" runat="server" Height="20px" Width="300px"></asp:TextBox>&nbsp&nbsp<asp:DropDownList ID="ddltime1" runat="server" Width="200px">
                        <asp:ListItem>1</asp:ListItem>
                        <asp:ListItem>2</asp:ListItem>
                        <asp:ListItem>3</asp:ListItem>
                        <asp:ListItem>4</asp:ListItem>
                        <asp:ListItem>5</asp:ListItem>
                        <asp:ListItem>6</asp:ListItem>
                        <asp:ListItem>7</asp:ListItem>
                        <asp:ListItem>8</asp:ListItem>
                        <asp:ListItem>9</asp:ListItem>
                        <asp:ListItem>10</asp:ListItem>
                        <asp:ListItem>11</asp:ListItem>
                        <asp:ListItem>12</asp:ListItem>
                        <asp:ListItem>13</asp:ListItem>
                        <asp:ListItem>14</asp:ListItem>
                        <asp:ListItem>15</asp:ListItem>
                        <asp:ListItem>16</asp:ListItem>
                        <asp:ListItem>17</asp:ListItem>
                        <asp:ListItem>18</asp:ListItem>
                        <asp:ListItem>19</asp:ListItem>
                        <asp:ListItem>20</asp:ListItem>
                        <asp:ListItem>21</asp:ListItem>
                        <asp:ListItem>22</asp:ListItem>
                        <asp:ListItem>23</asp:ListItem>
                        <asp:ListItem>24</asp:ListItem>
                    </asp:DropDownList>&nbsp<asp:Label ID="Label2" runat="server" Text="시간" Font-Bold="True" Font-Names="맑은 고딕"></asp:Label>&nbsp<asp:DropDownList ID="ddltime2" runat="server" Width="200px">
                        <asp:ListItem>5</asp:ListItem>
                        <asp:ListItem>10</asp:ListItem>
                        <asp:ListItem>15</asp:ListItem>
                        <asp:ListItem>20</asp:ListItem>
                        <asp:ListItem>25</asp:ListItem>
                        <asp:ListItem>30</asp:ListItem>
                        <asp:ListItem>35</asp:ListItem>
                        <asp:ListItem>40</asp:ListItem>
                        <asp:ListItem>45</asp:ListItem>
                        <asp:ListItem>50</asp:ListItem>
                        <asp:ListItem>55</asp:ListItem>
                    </asp:DropDownList>&nbsp<asp:Label ID="Label3" runat="server" Text="분" Font-Bold="True" Font-Names="맑은 고딕"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                   <asp:Label ID="Visa" runat="server" Text="비자시간:" Height="20px" Width="200px" Font-Bold="True" Font-Names="맑은 고딕" Font-Size="20px"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlVisa" runat="server" Width="500px">
                        <asp:ListItem>15</asp:ListItem>
                        <asp:ListItem>30</asp:ListItem>
                        <asp:ListItem>45</asp:ListItem>
                        <asp:ListItem>60</asp:ListItem>
                        <asp:ListItem>75</asp:ListItem>
                        <asp:ListItem>90</asp:ListItem>
                        <asp:ListItem>105</asp:ListItem>
                        <asp:ListItem>120</asp:ListItem>
                        <asp:ListItem>135</asp:ListItem>
                         <asp:ListItem>150</asp:ListItem>
                         <asp:ListItem>180</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                  <asp:Label ID="lblplace" runat="server" Text="명소:" Height="20px" Width="200px" Font-Bold="True" Font-Names="맑은 고딕" Font-Size="20px"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtplace" runat="server" Width="1000px" Height="20px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                   <asp:Label ID="lblfestival" runat="server" Text="축제:" Height="20px" Width="200px" Font-Bold="True" Font-Names="맑은 고딕" Font-Size="20px"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtfestival" runat="server" Width="1000px" Height="20px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                  <asp:Label ID="lblExprience" runat="server" Text="체험:" Height="20px" Width="200px" Font-Bold="True" Font-Names="맑은 고딕" Font-Size="20px"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtexprience" runat="server" Width="1000px" Height="20px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                  <asp:Label ID="lblfood" runat="server" Text="특산물:" Height="20px" Width="200px" Font-Bold="True" Font-Names="맑은 고딕" Font-Size="20px"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtfood" runat="server" Width="1000px" Height="20px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td style="text-align:left">
                    <asp:FileUpload ID="FileUpload1" runat="server" />
                </td>
            </tr>
            <tr>
                <td>

                </td>
                <td style="text-align:right">
                    <asp:Button ID="btnInfoinput" runat="server" Text="정보삽입" Width="200px" Height="30px" BackColor="#009933" Font-Bold="True" Font-Names="맑은 고딕" ForeColor="White" OnClick="btnInfoinput_Click" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

