<%@ Page Title="" Language="C#" MasterPageFile="~/PJ_traview/TraviewMaster.master" AutoEventWireup="true" CodeFile="Eventdetail.aspx.cs" Inherits="Eventdetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
            <style>
        .outdiv{
            margin:auto;
            padding:10px;
        }
        .indiv{
            display:inline-block;
            width:80%;
            height:100%;
            padding:10px
        }
        .userid{
            text-align:left;
        }
        .layer{
  position:absolute;
  top:50%;
  left:50%;
  background:skyblue;
  transform:translate(-50%, -50%)
}

    </style>
        <div class="outdiv">
            <center>
        <div class="indiv">
            <div style="text-align:center">
                <asp:Label ID="Label1" runat="server" Text="EVENT" Font-Bold="True" Font-Names="한컴 고딕" Font-Size="20pt"></asp:Label>
            </div>
            <div style="border:1px solid gray;">
               <div style="text-align:center; margin:15px">
                     <asp:Label ID="lblTitle" runat="server" Font-Bold="True" Font-Names="맑은 고딕"></asp:Label></div>
               <div style="text-align:center; margin:15px"><asp:Label ID="lblUser" runat="server" Font-Names="맑은 고딕"></asp:Label> | <asp:Label ID="Label5" runat="server" Text="이벤트 시작일" Font-Bold="True" Font-Names="맑은 고딕"></asp:Label> : <asp:Label ID="lblstart" runat="server" Font-Names="맑은 고딕" ForeColor="#0066CC"></asp:Label> | <asp:Label ID="Label7" runat="server" Text="이벤트 종료일" Font-Bold="True" Font-Names="맑은 고딕"></asp:Label> : <asp:Label ID="lblend" runat="server" Font-Names="맑은 고딕" ForeColor="#990033"></asp:Label></div>
            </div>
            <div style="border:1px solid gray">
               <div class="Indivin">
                   <div class="middle">
                <asp:Image ID="imgEvnet" runat="server" Width="600px" Height="700px"></asp:Image>
                       <br />
                <asp:Label ID="lblContents" runat="server" Font-Names="맑은 고딕"></asp:Label>
                       <br />
                       <asp:Label ID="Label6" runat="server" Text="이벤트 발표일" Font-Bold="True" Font-Names="맑은 고딕"></asp:Label> : <asp:Label ID="lblannounce" runat="server" ForeColor="#009933"></asp:Label>
                   </div>
               </div>
                 <div style="text-align:right; margin:5px" >
                &nbsp;&nbsp;&nbsp;<asp:Button ID="btnUpdate" runat="server" Text="수정" Font-Bold="True" OnClick="btnUpdate_Click" Width="75px" Visible="False" CssClass="btn-success" BackColor="#339933" ForeColor="White"></asp:Button><asp:Button ID="btnDelete" runat="server" Text="삭제" Font-Bold="True" OnClick="btnDelete_Click" Width="75px" Visible="False" CssClass="btn-danger" BackColor="#CC0000" ForeColor="White" style="height: 21px"></asp:Button>
            </div>
            </div>
            <div style="text-align:center">
                <asp:Label ID="Label2" runat="server" Text="이벤트 참가용" Font-Bold="True" Font-Names="맑은 고딕" Font-Size="30px" ForeColor="Blue"></asp:Label>
                <br />
                <asp:Label ID="Label4" runat="server" Text="참가방법 : 댓글에 &quot;참여하겠습니다&quot;,&quot;등록합니다&quot; 등의 댓글작성 " Font-Names="맑은 고딕" ForeColor="#CC00CC"></asp:Label>
            </div>
                <div>
                <asp:DataList ID="DDlreply" runat="server" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="10" GridLines="Horizontal" Width="1000px">
                    <FooterStyle BackColor="White" ForeColor="#333333" />
                    <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
                    <ItemStyle BackColor="White" ForeColor="#333333" />
                    <ItemTemplate>
                        <div style="text-align:left">                        
                            &nbsp&nbsp&nbsp<asp:Label ID="lblnickname" runat="server" Font-Bold="True" Font-Names="맑은 고딕" Text="" Font-Size="15px"><%#Eval("nickname") %></asp:Label>
                        &nbsp;<asp:Label ID="lbldate" runat="server" Font-Size="11px" Text=""><%#Eval("uploadtime","{0:yyyy/MM/dd HH:mm}") %></asp:Label>

                        </div>
                        <br />
                        <div style="text-align:center">
                        <asp:Label ID="lblreply" runat="server" Font-Names="맑은 고딕" Text=""><%#Eval("contents") %></asp:Label>
                        </div>
                    </ItemTemplate>
                    <SelectedItemStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
                </asp:DataList>
                <div><asp:Label ID="Label3" runat="server" Text="참가 댓글" Font-Bold="True" Font-Names="맑은 고딕" Font-Size="15px"></asp:Label>&nbsp<asp:TextBox ID="txtReply" runat="server" Height="50px" TextMode="MultiLine" Width="700px"></asp:TextBox>&nbsp<asp:Button ID="btnReply" runat="server" Text="등록" BackColor="#006666" Font-Bold="False" Font-Names="맑은 고딕" ForeColor="White" Height="40px" OnClick="btnReply_Click" Width="50px"></asp:Button></div>
            </div>
            </div>
        </div>
</asp:Content>

