<%@ Page Title="" Language="C#" MasterPageFile="~/PJ_traview/TraviewMaster.master" AutoEventWireup="true" CodeFile="TraviewCommunity.aspx.cs" Inherits="TraviewCommunity" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <style>
        .container {
  position: relative;
  max-width: 1920px;
  text-align: center;
  margin: auto;
  margin-top:5px;
}
    .main {
    position: absolute;
    top: 80%;
    left: 50%;
    transform: translate(-50%, -50%);
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
        <img src="image/커뮤니티메인.jpg" width="100%" style="height: 500px"/>
        <div class="main"><h2>여행정보들을 공유할수 있는 공간</h2> </div>
        <div class="sub"><h3>일정 후기 질문등을 남길수 있는공간</h3></div>
    </div>
    <div class="container">
        <center>
<table style="width:1024px" >

<tr>
<td style="text-align:left" class="auto-style1">
<asp:Label ID="Label11" runat="server" Text="여행후기" Font-Bold="True" Font-Names="맑은 고딕" Font-Size="30px"></asp:Label>
    &nbsp<asp:LinkButton ID="lkbtnReview" runat="server" OnClick="LinkButton1_Click">+더보기</asp:LinkButton>
</td>
<td style="text-align:left" class="auto-style1">
<asp:Label ID="Label12" runat="server" Text="여행QnA" Font-Bold="True" Font-Names="맑은 고딕" Font-Size="30px"></asp:Label>
        &nbsp<asp:LinkButton ID="lkbtnQnA" runat="server" OnClick="lkbtnQnA_Click">+더보기</asp:LinkButton>
</td>
</tr>
<tr>
<td style="border:solid 2px black">
<asp:GridView ID="CommunityRV" runat="server" AutoGenerateColumns="False" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2" ForeColor="Black" GridLines="None" Font-Bold="False" Width="500px" OnPageIndexChanging="CommunityRV_PageIndexChanging">
    <AlternatingRowStyle BackColor="PaleGoldenrod" />
<Columns>
                <asp:TemplateField HeaderText="제목">
                    <ItemTemplate>
                        <asp:HyperLink ID="hyperLink1" runat="server" NavigateUrl='<%#GetShowReview(Eval("no")) %>' Text='<%#Eval("title") %>'>
                        </asp:HyperLink>
                    </ItemTemplate>
                    <ItemStyle Width="500px" />
                </asp:TemplateField>
                <asp:BoundField HeaderText="작성자"  DataField="nickname" ItemStyle-Width="80px" ItemStyle-HorizontalAlign="Center">
<ItemStyle HorizontalAlign="Center" Width="80px"></ItemStyle>
                </asp:BoundField>
                <asp:TemplateField HeaderText="작성일" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <%#Eval("uploadTime","{0:yyyy/MM/dd}") %>
                    </ItemTemplate>

<ItemStyle HorizontalAlign="Center" Width="100px"></ItemStyle>
                </asp:TemplateField>
</Columns>
    <FooterStyle BackColor="Tan" />
    <HeaderStyle BackColor="Tan" Font-Bold="True" />
    <PagerSettings PageButtonCount="5" />
    <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
    <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
    <SortedAscendingCellStyle BackColor="#FAFAE7" />
    <SortedAscendingHeaderStyle BackColor="#DAC09E" />
    <SortedDescendingCellStyle BackColor="#E1DB9C" />
    <SortedDescendingHeaderStyle BackColor="#C2A47B" />
</asp:GridView>
</td>
<td style="border:solid 2px black">
<asp:GridView ID="CommunityQnA" runat="server" BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Horizontal" AutoGenerateColumns="False" Width="500px" OnPageIndexChanging="CommunityQnA_PageIndexChanging">
<Columns>
                <asp:TemplateField HeaderText="제목">
                    <ItemTemplate>
                        <asp:HyperLink ID="hyperLink1" runat="server" NavigateUrl='<%#GetShowQnA(Eval("no")) %>' Text='<%#Eval("title") %>'>
                        </asp:HyperLink>
                    </ItemTemplate>
                    <ItemStyle Width="500px" />
                </asp:TemplateField>
                <asp:BoundField HeaderText="작성자"  DataField="nickname" ItemStyle-Width="80px" ItemStyle-HorizontalAlign="Center">
<ItemStyle HorizontalAlign="Center" Width="80px"></ItemStyle>
                </asp:BoundField>
                <asp:TemplateField HeaderText="작성일" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <%#Eval("uploadTime","{0:yyyy/MM/dd}") %>
                    </ItemTemplate>

<ItemStyle HorizontalAlign="Center" Width="100px"></ItemStyle>
                </asp:TemplateField>
</Columns>
    <AlternatingRowStyle BackColor="#F7F7F7" />
    <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
    <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
    <PagerSettings PageButtonCount="5" />
    <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
    <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
    <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
    <SortedAscendingCellStyle BackColor="#F4F4FD" />
    <SortedAscendingHeaderStyle BackColor="#5A4C9D" />
    <SortedDescendingCellStyle BackColor="#D8D8F0" />
    <SortedDescendingHeaderStyle BackColor="#3E3277" />
    </asp:GridView>
</td>
</tr>
</table>

        </center>
        </div>
                <div class="outdiv">
        <div class="indiv">
            <div style="text-align:left">
                <asp:Label ID="lblAlbumTitle" runat="server" Text="여행 사진" Font-Bold="True" Font-Names="맑은 고딕" Font-Size="Large" Width="80px"></asp:Label>
                 &nbsp<asp:LinkButton ID="lkbtnPic" runat="server" OnClick="lkbtnPic_Click">+더보기</asp:LinkButton>
            </div>
            <div style="border:1px solid gray;">
               <div style="text-align:left; margin:15px">
                   <asp:DataList ID="dblCommunity" runat="server" RepeatColumns="7"
                     RepeatDirection="Horizontal" Width="500px">
                     <ItemTemplate>
                         <asp:Image ID="ImgBtn" runat="server" ImageUrl='<%#GetImageUrl(Eval("no"),Eval("fname")) %>' Width="150px" AlternateText="사진" Height="170px"  />
                         <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl='<%#GetShowUrl(Eval("no")) %>' Target="_blank" Font-Bold="True" Font-Names="맑은 고딕" ForeColor="#3366CC" PostBackUrl="'<%#GetShowUrl(Eval(&quot;no&quot;)) %>'">
                             <br />
                             <asp:Label ID="Label2" runat="server" Text="" Font-Bold="True" Font-Names="맑은 고딕" ForeColor="#660066" /> <%#Eval("title") %>
                         </asp:HyperLink></ItemTemplate></asp:DataList></div></div><div style="text-align:left; margin:5px" >
                 </div>
               
            <noscript>Please enable JavaScript to view the <a href="https://disqus.com/?ref_noscript">comments powered by Disqus.</a></noscript>
        </div>
    </div>  
  
       
</asp:Content>

