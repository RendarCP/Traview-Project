<%@ Page Title="" Language="C#" MasterPageFile="~/PJ_traview/TraviewMaster.master" AutoEventWireup="true" CodeFile="Photo_show.aspx.cs" Inherits="Photo_show" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
                  <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1">
  <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
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
        .Indivin{
            display:inline-block;
            width:50%;
            height:100%;
            padding:10px;
            text-align:center;
          display: inline-block;
          vertical-align:middle;
        }
        .middle {
            text-align: left;
            display: inline-block;
        }
    </style>
   <div class="outdiv">
            <center>
        <div class="indiv">
            <div style="text-align:left">
                <asp:Label ID="Label1" runat="server" Text="여행사진" Font-Bold="True" Font-Names="한컴 고딕" Font-Size="20pt"></asp:Label>
            </div>
            <div style="border:1px solid gray;">
               <div style="text-align:left; margin:15px">
                     <asp:Label ID="lblTitle" runat="server" Font-Bold="True" Font-Names="맑은 고딕"></asp:Label>&nbsp&nbsp&nbsp</div>
               <div style="text-align:left; margin:15px"><asp:Label ID="lblUser" runat="server" Font-Names="맑은 고딕"></asp:Label>&nbsp;|&nbsp;<asp:Label ID="lblDate" runat="server" Font-Names="맑은 고딕"></asp:Label>&nbsp;|&nbsp;<asp:Label ID="Label2" runat="server" Text="조회수:"></asp:Label>&nbsp;<asp:Label ID="lblHits" runat="server" Font-Names="맑은 고딕"></asp:Label></div>
            </div>
            <div style="border:1px solid gray">
                <asp:Image ID="imgMain" runat="server" Height="500px" Width="900px" />
                <br />
                <br />
                <asp:Label ID="lblContents" runat="server" Font-Names="맑은 고딕"></asp:Label>
            </div>
            <div style="text-align:right; margin:5px" >
                <asp:Button ID="Button1" runat="server" Text="목록" Height="25px" Width="71px" OnClick="Button1_Click" Font-Bold="True" Font-Names="맑은 고딕" CssClass="btn-primary" />
         <asp:Button ID="btnUpdate" runat="server" Text="수정"  OnClick="btnUpdate_Click" Height="25px" Width="71px"  Visible="False" CssClass="btn-success"  Font-Bold="True" Font-Names="맑은 고딕"></asp:Button>
        <asp:Button ID="btnDelete" runat="server" Text="삭제" onclick="btnDelete_Click" OnClientClick="javascript:if(confirm('정말 삭제하시겠습니까? \n\n 삭제하면 복구가 불가능합니다.')) {return true;} else{return false;}" Height="25px" Width="71px" Visible="False" Font-Bold="True" Font-Names="맑은 고딕" CssClass="btn-danger" />
                &nbsp;</div>
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
                <div><asp:Label ID="Label3" runat="server" Text="댓글" Font-Bold="True" Font-Names="맑은 고딕" Font-Size="15px"></asp:Label>&nbsp<asp:TextBox ID="txtReply" runat="server" Height="50px" TextMode="MultiLine" Width="700px"></asp:TextBox>&nbsp<asp:Button ID="btnReply" runat="server" Text="등록" BackColor="#006666" Font-Bold="False" Font-Names="맑은 고딕" ForeColor="White" Height="40px" OnClick="btnReply_Click" Width="50px"></asp:Button></div>
            </div>
            <hr />
            <div style="text-align:center">
                <asp:Label ID="Label4" runat="server" Text="게스트 댓글 작성" Font-Bold="True" Font-Names="맑은 고딕" Font-Size="20px"></asp:Label>
                <br />
                <asp:Label ID="Label5" runat="server" Text="간단한 소셜로그인으로 댓글을 작성해보세요!" Font-Bold="False" Font-Names="맑은 고딕" ForeColor="#660066"></asp:Label>
            </div>
                        <div id="disqus_thread"></div>
               <script>

                   /**
                      *  RECOMMENDED CONFIGURATION VARIABLES: EDIT AND UNCOMMENT THE SECTION BELOW TO INSERT DYNAMIC VALUES FROM YOUR PLATFORM OR CMS.
                      *  LEARN WHY DEFINING THESE VARIABLES IS IMPORTANT: https://disqus.com/admin/universalcode/#configuration-variables*/
                   /*
                            var disqus_config = function () {
                            this.page.url = PAGE_URL;  // Replace PAGE_URL with your page's canonical URL variable
                            this.page.identifier = PAGE_IDENTIFIER; // Replace PAGE_IDENTIFIER with your page's unique identifier variable
                              };
                               */
                   (function () { // DON'T EDIT BELOW THIS LINE
                       var d = document, s = d.createElement('script');
                       s.src = 'https://traview.disqus.com/embed.js';
                       s.setAttribute('data-timestamp', +new Date());
                       (d.head || d.body).appendChild(s);
                   })();
                                      </script>
            <noscript>Please enable JavaScript to view the <a href="https://disqus.com/?ref_noscript">comments powered by Disqus.</a></noscript>
            </div>
   </div>
</asp:Content>

