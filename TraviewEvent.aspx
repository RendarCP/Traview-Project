<%@ Page Title="" Language="C#" MasterPageFile="~/PJ_traview/TraviewMaster.master" AutoEventWireup="true" CodeFile="TraviewEvent.aspx.cs" Inherits="TraviewReview" %>

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
    .main {
    position: absolute;
    bottom: 80px;
    left:50px;
    color: #f2f2f2;
    font-size: 40px;
}
.sub {
     position: absolute;
    bottom: 50px;
    left:50px;
    color: #ffc044;
    font-size: 20px;
        } 
             .outdiv{
            margin:0 auto;
            padding:10px;
            text-align:center;
            width:100%
        }
                     .indiv{
            display:inline-block;
            width:60%;
            height:100%;
            padding:10px;
            margin:0 auto;
            text-align:center;
        }
                          a,a:hover{
         color:#000000;
         text-decoration:none;
     }

    </style>
    <div class="container">
        <img src="image/이벤트.jpg" style="width:100%; height:400px;" />
        <div class="main"><h3>Traview와 함께하는 이벤트</h3></div>
        <div class="sub"><h4>다양한 이벤트에 당첨되어 보세요!!</h4></div>

    </div>
    <div class="outdiv">
        <div class="indiv">
        <asp:Button ID="btnEvent" runat="server" Text="이벤트작성" OnClick="btnEvent_Click" Visible="False" CssClass="btn-success"></asp:Button>
        <br />
        <asp:DataList ID="DdlEvent" runat="server" RepeatColumns="4" CellPadding="3">
            <ItemTemplate>
                <asp:Image ID="Image1" runat="server" ImageUrl='<%#GetImageUrl(Eval("no"),Eval("filename")) %>' Width="200px" Height="300px" />
                <br />
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# GetShowUrl(Eval("no")) %>' Target="_blank" Font-Bold="True" Font-Names="맑은 고딕">
                    <%#Eval("title") %>
                </asp:HyperLink>
                <br />
                <asp:Label ID="Label2" runat="server" Text="이벤트 시작"></asp:Label> : <asp:Label ID="Label1" runat="server" Font-Names="맑은 고딕"><%#Eval("startEvent","{0:yyyy/MM/dd}") %></asp:Label>
                <br />
                <asp:Label ID="Label3" runat="server" Text="이벤트 종료"></asp:Label> : <asp:Label ID="Label4" runat="server" Font-Names="맑은 고딕"><%#Eval("endEvent","{0:yyyy/MM/dd}") %></asp:Label>
            </ItemTemplate>
        </asp:DataList>
        </div>
        </div>
</asp:Content>

