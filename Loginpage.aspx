<%@ Page Title="" Language="C#" MasterPageFile="~/PJ_traview/TraviewMaster.master" AutoEventWireup="true" CodeFile="Loginpage.aspx.cs" Inherits="Loginpage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <style>
            /*div컨테이너 지정*/
        .container {
  position: relative;
  max-width: 1920px;
  text-align: center;
  margin: auto;
}    /*아이디 css지정*/
      .container .textbox {
  position: absolute;
  top: 50%;
  left: 50%;
  transform: translate(-50%, -50%);
  -ms-transform: translate(-50%, -50%);
  background-color:#ffffff;
  color: black;
  font-size: 16px;
  padding: 12px 24px;
  border: none;
  cursor: pointer;
  border-radius: 5px;
}    /*비밀번호 css지정*/
            .container .textboxsub {
  position: absolute;
  top: 55%;
  left: 50%;
  transform: translate(-50%, -50%);
  -ms-transform: translate(-50%, -50%);
  background-color:#ffffff;
  color: black;
  font-size: 16px;
  padding: 12px 24px;
  border: none;
  cursor: pointer;
  border-radius: 5px;
}    /*아이디 라벨 지정*/
            .container .label {
                position: absolute;
                top: 50%;
                left:40%;
                  transform: translate(-50%, -50%);
               -ms-transform: translate(-50%, -50%);

            }
                /*비밀번호 라벨 지정*/
            .container .labelsub {
                position: absolute;
                top: 55%;
                left: 40%;
                transform: translate(-50%, -50%);
                -ms-transform: translate(-50%, -50%);
            }
                /*로그인 버튼 지정*/
            .container .login {
                position: absolute;
                top: 52.5%;
                left: 60%;
                transform: translate(-50%, -50%);
                -ms-transform: translate(-50%, -50%);
            }
                /*회원가입 버튼 지정*/
            .container .register {
                position: absolute;
                top: 59.5%;
                left: 50%;
                transform: translate(-50%, -50%);
                -ms-transform: translate(-50%, -50%);
            }
                  /*h3 폰트  지정*/
            .container .h3{
                position: absolute;
                top: 35%;
                left: 50%;
                 transform: translate(-50%, -50%);
                -ms-transform: translate(-50%, -50%);
                font-size:50px;
                font-family:맑은 고딕;
                color:white;
            }
                              /*h2 폰트  지정*/
           .container .h2{
                position: absolute;
                top: 40%;
                left: 50%;
                 transform: translate(-50%, -50%);
                -ms-transform: translate(-50%, -50%);
                font-size:30px;
                font-family:맑은 고딕;
                color:orange;
            }
    </style>
    <div class="container">
        <h2 class="h3">Traview와 행복을 함께해요</h2>
        <br /><br />
        <h3 class="h2">즐거운 여행이 되어봐요</h3>
        <img src="image/로그인이미지(1920).jpg" />
        <asp:Label ID="Label1" runat="server" CssClass="label" Text="아이디" Font-Bold="True" Font-Names="맑은 고딕" Font-Size="16px"></asp:Label>
        <asp:TextBox ID="txtid" runat="server" CssClass="textbox"></asp:TextBox>
        <asp:Label ID="Label2" runat="server" CssClass="labelsub" Text="비밀번호" Font-Bold="True" Font-Names="맑은 고딕" Font-Size="16px"></asp:Label>
        <asp:TextBox ID="txtpwd" runat="server" CssClass="textboxsub" TextMode="Password" OnTextChanged="btnLogin_Click" ></asp:TextBox>
        <asp:Button ID="btnLogin" runat="server" CssClass="login" Text="로그인" Height="95px" Width="100px" OnClick="btnLogin_Click" />
        <asp:Button ID="btnRegister" runat="server" CssClass="register" Text="회원가입" Height="30px" Width="240px" OnClick="btnRegister_Click" />
        <br />
        <asp:Label ID="lblmessage" runat="server" ForeColor="Red" Font-Bold="True"></asp:Label>
    </div>
</asp:Content>

