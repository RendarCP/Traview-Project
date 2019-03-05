<%@ Page Title="" Language="C#" MasterPageFile="~/PJ_traview/TraviewMaster.master" AutoEventWireup="true" CodeFile="TraviewPicture.aspx.cs" Inherits="TraviewPicture" %>

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
    top: 80%;
    left: 50%;
    transform: translate(-50%, -50%);
      color: #000000;
  font-size: 40px;
}
.sub {
     position: absolute;
    top: 90%;
    left: 50%;
    transform: translate(-50%, -50%);
      color: #ffc044;
      font-size: 20px;
        } 
 /*A태그 CSS 제목클릭시 나타나는것들 제거*/
     a,a:hover{
         color:#000000;
         text-decoration:none;
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
    </style>
        <div class="container">
        <img src="image/여행사진게시판.jpg" style="width:100%; height:400px;"/>
        <div class="main"><h2>자랑할만한 여행사진</h2> </div>
        <div class="sub"><h3>사진을 함께 공유해봐요</h3></div>
    </div>
    <div class="outdiv">
        <div class="indiv">
            <div style="text-align:left">
                <asp:Label ID="lblAlbumTitle" runat="server" Text="여행 사진" Font-Bold="True" Font-Names="맑은 고딕" Font-Size="Large" Width="600px"></asp:Label>
            </div>
            <div style="border:1px solid gray;">
               <div style="text-align:left; margin:15px">
                   <asp:DataList ID="dblCommunity" runat="server" RepeatColumns="7"
                     RepeatDirection="Horizontal" Width="500px" CellPadding="5">
                     <ItemTemplate>
                         <asp:Image ID="ImgBtn" runat="server" ImageUrl='<%#GetImageUrl(Eval("no"),Eval("fname")) %>' Width="150px" AlternateText="사진" Height="170px"  />
                         <br />
                         <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl='<%#GetShowUrl(Eval("no")) %>' Target="_blank" Font-Bold="True" Font-Names="맑은 고딕">
                             <br />
                             <asp:Label ID="Label2" runat="server" Text="" Font-Bold="True" Font-Names="맑은 고딕" /> <%#Eval("title") %>
                         </asp:HyperLink></ItemTemplate></asp:DataList></div></div><div style="text-align:left; margin:5px" >
                 <asp:Button ID="btnSave" runat="server" Font-Size="Large" Style="font-size:small; font-weight:700; font-family:'맑은 고딕'"
                         Text="사진올리기" OnClick="btnSave_Click" UseSubmitBehavior="false" BackColor="#009933" ForeColor="White" Height="30px" Width="100px"  /></div>
               
            <noscript>Please enable JavaScript to view the <a href="https://disqus.com/?ref_noscript">comments powered by Disqus.</a></noscript>
        </div>
    </div>  
</asp:Content>

