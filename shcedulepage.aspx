<%@ Page Title="" Language="C#" MasterPageFile="~/PJ_traview/TraviewMaster.master" AutoEventWireup="true" CodeFile="shcedulepage.aspx.cs" Inherits="shcedulepage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <style>
        .container {
    position: relative;
    text-align: center;
    color: white;
      max-width: 2560px;
  margin: auto;
}
                        /*일정만들기 버튼*/
            .container .login {
                position: absolute;
                top: 80%;
                left: 50%;
                transform: translate(-50%, -50%);
                -ms-transform: translate(-50%, -50%);
            }
                /*나의 일정 버튼*/
            .container .register {
                position: absolute;
                top: 80%;
                left: 60%;
                transform: translate(-50%, -50%);
                -ms-transform: translate(-50%, -50%);
            }
   </style>
    <div class="container">
        <img src="image/일정페이지(1600).jpg" />
        <asp:Button ID="BtnShcedule" runat="server" CssClass="login" Font-Size="Larger" Text="일정만들기" Font-Bold="True" Width="150" Height="75" OnClick="BtnShcedule_Click" />
        <asp:Button ID="BtnMyshcedule" runat="server" CssClass="register" Font-Size="Larger" Text="나의 일정" Font-Bold="True" Width="150" Height="75" OnClick="BtnMyshcedule_Click" />
    </div>

    <div class="list">
        <center>
        <asp:DataList ID="DlShcedule" runat="server"></asp:DataList>
       </center>
    </div>
</asp:Content>

