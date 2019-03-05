<%@ Page Title="" Language="C#" MasterPageFile="~/PJ_traview/TraviewMaster.master" AutoEventWireup="true" CodeFile="RegisterPage.aspx.cs" Inherits="RegisterPage" %>

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
                
              border-top: 2px solid #ff7b00;
                border-collapse: collapse;
              }
        th, td {
            border-bottom: 1px solid #444444;
            padding: 10px;
        }

    </style>
    <script type="text/javascript">
        function SelectedTextvalue(ele) {
            if (ele.selectedIndex > 0) {
                var selectedText = ele.options[ele.selectedIndex].innerHTML;
                var selectedValue = ele.value;
                document.getElementById("txtEmail").value = selectedText;
            }
            else {
                document.getElementById("txtEmail").value = "";
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
       <center>
         <h3 class="h3font">회원가입</h3>
          <div>
           <strong class="subfont">트레뷰와 함께 즐거운 여행이 되세요</strong>
          </div>
       </center>
    </div>
    <div>
        <center>
          <table style="width:1000px">
              <tr>
                  <th class="th">
                      <asp:Label ID="Label1" runat="server" Text="이름"></asp:Label>
                  </th>
                  <td style="text-align:left">
                        <asp:TextBox ID="txtname" runat="server" Height="20px" Width="200px"></asp:TextBox>
                  </td>
              </tr>
                   <tr>
                  <th class="th">
                      <asp:Label ID="Label5" runat="server" Text="아이디"></asp:Label>
                  </th>
                  <td style="text-align:left">
                      <asp:TextBox ID="txtId" runat="server" Height="20px" Width="200px"></asp:TextBox>&nbsp&nbsp<asp:Button ID="btnIDcheck" runat="server" Text="ID중복검사" CausesValidation="False" OnClick="btnIDcheck_Click" />
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtId" ErrorMessage="아이디는 필수 입력사항입니다" Font-Bold="True" ForeColor="Red">*</asp:RequiredFieldValidator>
                      <asp:Label ID="lblIDCheckmessage" runat="server" Font-Bold="True" Font-Names="맑은 고딕" ForeColor="#009933"></asp:Label>
                  </td>
              </tr>
              <tr>
                  <th class="th">
                      <asp:Label ID="Label2" runat="server" Text="이메일"></asp:Label>
                  </th>
                  <td style="text-align:left">
                      <asp:TextBox ID="txtEmailID" runat="server" Height="20px" Width="200px"></asp:TextBox>&nbsp@&nbsp<asp:TextBox ID="txtEmail" runat="server" Height="20px" Width="200px" Font-Names="맑은 고딕" ForeColor="Black" ReadOnly="True"></asp:TextBox>&nbsp&nbsp<asp:DropDownList ID="DdlEmail" runat="server" Height="30px" Width="150px" AutoPostBack="True" OnSelectedIndexChanged="DdlEmail_SelectedIndexChanged" >
                          <asp:ListItem Selected="True">이메일선택</asp:ListItem>
                          <asp:ListItem Value="naver.com">naver.com</asp:ListItem>
                          <asp:ListItem Value="daum.net">daum.net</asp:ListItem>
                          <asp:ListItem Value="nate.com">nate.com</asp:ListItem>
                          <asp:ListItem Value="gmail.com">gmail.com</asp:ListItem>
                          <asp:ListItem Value="outlook.com">outlook.com</asp:ListItem>
                          <asp:ListItem Value="직접입력">직접입력</asp:ListItem>
                      </asp:DropDownList>
                  </td>
              </tr>
              <tr>
                  <th class="th">
                      <asp:Label ID="Label3" runat="server" Text="비밀번호"></asp:Label>
                  </th>
                  <td style="text-align:left">
                      <asp:TextBox ID="txtPw" runat="server" Height="20px" Width="200px" TextMode="Password">비밀번호</asp:TextBox>&nbsp&nbsp<asp:TextBox ID="txtPwcheck" runat="server" Height="20px" Width="200px" TextMode="Password" Font-Bold="False" ForeColor="#666666">비밀번호 확인</asp:TextBox>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtPw" ErrorMessage="비밀번호는 필수입력사항입니다." Font-Bold="True" ForeColor="Red">*</asp:RequiredFieldValidator>
                      <br />
                      <asp:CompareValidator ID="CompareValidator1" runat="server" CultureInvariantValues="False" ControlToCompare="txtPw" ControlToValidate="txtPwcheck" ErrorMessage="비밀번호가 일치하지 않습니다" Font-Bold="True" Font-Names="맑은 고딕" ForeColor="Red"></asp:CompareValidator>
                  </td>
              </tr>
              <tr>
                  <th class="th">
                      <asp:Label ID="Label4" runat="server" Text="닉네임"></asp:Label>
                  </th>
                  <td style="text-align:left">
                      <asp:TextBox ID="txtnickname" runat="server" Height="20px" Width="200px"></asp:TextBox>
                  </td>
              </tr>
              <tr>
                  <td colspan="2" style="text-align:center">
                      <asp:Button ID="btnRegister" runat="server" Font-Bold="True" Font-Names="맑은 고딕" Font-Size="15pt" Height="30px" Text="회원가입" Width="200px" OnClick="btnRegister_Click" />&nbsp&nbsp&nbsp<asp:Label ID="lblresultmessage" runat="server" Font-Bold="True" Font-Names="맑은 고딕" ForeColor="#0099FF"></asp:Label>
                      <asp:ValidationSummary ID="ValidationSummary1" runat="server" Font-Bold="True" Font-Names="맑은 고딕" ForeColor="Red" />
                  </td>
              </tr>
          </table>
        </center>
    </div>
</asp:Content>

