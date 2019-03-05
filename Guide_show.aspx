<%@ Page Title="" Language="C#" MasterPageFile="~/PJ_traview/TraviewMaster.master" AutoEventWireup="true" CodeFile="Guide_show.aspx.cs" Inherits="Guide_show" %>

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
                <asp:Label ID="Label1" runat="server" Text="가이드북" Font-Bold="True" Font-Names="한컴 고딕" Font-Size="20pt"></asp:Label>
            </div>
            <div style="border:1px solid gray;">
               <div style="text-align:left; margin:15px">
                     <asp:Label ID="lblTitle" runat="server" Font-Bold="True" Font-Names="맑은 고딕"></asp:Label>&nbsp&nbsp&nbsp</div>
               <div style="text-align:left; margin:15px"><asp:Label ID="lblUser" runat="server" Font-Names="맑은 고딕"></asp:Label>&nbsp;|&nbsp;<asp:Label ID="lblDate" runat="server" Font-Names="맑은 고딕"></asp:Label>&nbsp;|&nbsp;<asp:Label ID="Label2" runat="server" Text="조회수:"></asp:Label>&nbsp;<asp:Label ID="lblHits" runat="server" Font-Names="맑은 고딕"></asp:Label></div>
            </div>
            <div style="border:1px solid gray">
                <asp:Image ID="imgMain" runat="server" Height="500px" Width="350px" />

                <br />
                &nbsp;&nbsp;&nbsp;<asp:Label ID="Label7" runat="server" Text="첨부파일" Font-Bold="True" Font-Italic="False" Font-Size="Large"></asp:Label>
                <asp:Label ID="lblFname" runat="server" Font-Names="맑은 고딕"></asp:Label>
&nbsp;<asp:Label ID="Label5" runat="server" Text="파일크기" Font-Bold="True" Font-Size="Large"></asp:Label>
                <asp:Label ID="lblFsize" runat="server" Font-Names="맑은 고딕"></asp:Label>
&nbsp;
                <asp:Button ID="btnDownload" runat="server" Text="다운로드" OnClick="btnDownload_Click" CssClass="btn btn-info"/>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
                <br />

                <asp:Label ID="lblContents" runat="server" Font-Names="맑은 고딕"></asp:Label>
            </div>
            <div style="text-align:right; margin:5px" >
                <asp:Button ID="Button1" runat="server" Text="목록" Height="20px" Width="71px" OnClick="Button1_Click" CssClass="btn-primary" />
&nbsp;          <asp:Button ID="btnUpdate" runat="server" Text="수정"  OnClick="btnUpdate_Click" Height="20px" Width="71px"  Visible="False" CssClass="btn-success"></asp:Button>
&nbsp;          <asp:Button ID="btnDelete" runat="server" Text="삭제" onclick="btnDelete_Click" OnClientClick="javascript:if(confirm('정말 삭제하시겠습니까? \n\n 삭제하면 복구가 불가능합니다.')) {return true;} else{return false;}" Height="20px" Width="71px" Visible="False" CssClass="btn-danger" />
                &nbsp;</div>
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

