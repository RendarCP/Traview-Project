<%@ Page Title="" Language="C#" MasterPageFile="~/PJ_traview/TraviewMaster.master" AutoEventWireup="true" CodeFile="GuideMap.aspx.cs" Inherits="GuideMap" %>

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
            padding:10px;
            margin-left: 0px;
        }

        .container {
  position: relative;
  max-width: 1920px;
  text-align: center;
  margin: auto;
  margin-top:5px;
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
    .main {
    position: absolute;
    top: 80%;
    left: 50%;
    transform: translate(-50%, -70%);
      color: #000000;
  font-size: 35px;
}
.sub {
     position: absolute;
    top: 90%;
    left: 50%;
    transform: translate(-50%, -50%);
      color: #c828b8;
      font-size: 25px;
        } 

     a,a:hover{
         color:#000000;
         text-decoration:none;
     }
        .auto-style1 {
            height: 45px;
        }
        .auto-style2 {
            height: 368px;
        }
           </style>
    <div class="outdiv">
            <center>
        <div class="indiv">
            <div style="text-align:left">
                <asp:Label ID="lblAlbumTitle" runat="server" Text="가이드북" Font-Bold="True" Font-Names="맑은 고딕" Font-Size="Large" Width="600px"></asp:Label>
            </div>
            <div style="border:1px solid gray;">
               <div style="text-align:left; margin:15px">
                   <div style="width:800px; text-align:center">
        <asp:DataList ID="dblGuideMap" runat="server" RepeatColumns="8"
                     RepeatDirection="Horizontal" CellPadding="5">
                     <ItemTemplate>
                         <asp:Image ID="ImgBtn" runat="server" ImageUrl='<%#GetImageUrl(Eval("no"),Eval("fname")) %>' Width="150px" AlternateText="사진"  />
                         <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl='<%#GetShowUrl(Eval("no")) %>' Target="_blank" Font-Bold="True">
                             <br />
                             <asp:Label ID="Label2" runat="server" Text="" Font-Bold="True" /> <%#Eval("title") %>
                         </asp:HyperLink></ItemTemplate></asp:DataList></div></div><div style="text-align:left; margin:5px" >
                 <asp:Button ID="btnSave" runat="server" Font-Size="Large" Style="font-size:small; font-weight:700; font-family:'맑은 고딕'"
                         Text="사진올리기" OnClick="btnSave_Click" UseSubmitBehavior="false" Visible="False" CssClass="btn-success" /></div>
                   </div>
           
               
            <noscript>Please enable JavaScript to view the <a href="https://disqus.com/?ref_noscript">comments powered by Disqus.</a></noscript>
        </div>
           </center>
    </div>     
</asp:Content>

