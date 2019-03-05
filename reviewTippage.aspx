<%@ Page Title="" Language="C#" MasterPageFile="~/PJ_traview/TraviewMaster.master" AutoEventWireup="true" CodeFile="reviewTippage.aspx.cs" Inherits="reviewTippage" %>

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
    </style>
    <script language="javascript" type="text/javascript">
       function Login() {
           if (confirm("로그인이 필요한 작업입니다. 로그인 하시겠습니까?")) {
               location.replace = "~/Login.aspx";
           } else {
               location.replace = "~/reviewTippage.aspx";
            }
          }
</script>
    <div class="container">
        <img src="image/여행리뷰.jpg" style="width:100%; height:400px;"/>
        <div class="main"><h2>즐거운 여행 함께 나눠봐요</h2> </div>
        <div class="sub"><h3>자신의 이야기를 공유해요</h3></div>
    </div>
    <div>
        <center>
        <asp:DropDownList ID="DDlsearch" runat="server" Height="20px" Width="100px">
            <asp:ListItem>닉네임</asp:ListItem>
            <asp:ListItem>내용</asp:ListItem>
            <asp:ListItem>제목</asp:ListItem>
        </asp:DropDownList>
        <asp:TextBox ID="txtSearch" runat="server" Width="500px"></asp:TextBox>
        <asp:Button ID="btnSearch" runat="server" Text="검색" Width="100px" OnClick="btnSearch_Click" />
          &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp     
            <asp:Button ID="btnWrite" runat="server" Text="글쓰기" BackColor="#009933" Font-Bold="True" ForeColor="White" Height="30px" OnClick="BtnWrite" Width="100px"></asp:Button>
        </center>
    </div>
    <div style="text-align:center">
        <center>
        <asp:GridView ID="grvBbs" runat="server" AllowPaging="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" Font-Bold="False" OnPageIndexChanging="grvBbs_PageIndexChanging" Width="1000px">
            <Columns>
                <asp:TemplateField HeaderText="제목">
                    <ItemTemplate>
                        <asp:HyperLink ID="hyperLink1" runat="server" NavigateUrl='<%#GetShowUrl(Eval("no")) %>' Text='<%#Eval("title") %>'>
                        </asp:HyperLink>
                    </ItemTemplate>
                    <ItemStyle Width="400px" />
                </asp:TemplateField>
                <asp:BoundField HeaderText="작성자"  DataField="nickname" ItemStyle-Width="80px" ItemStyle-HorizontalAlign="Center"/>
                <asp:TemplateField HeaderText="작성일" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <%#Eval("uploadTime","{0:yyyy/MM/dd}") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField HeaderText="조회수"  DataField="hits" ItemStyle-Width="80px" ItemStyle-HorizontalAlign="Center"/>
            </Columns>
            <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
            <HeaderStyle BackColor="#ffffff" Font-Bold="True" ForeColor="Black" />
            <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F7F7F7" />
            <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
            <SortedDescendingCellStyle BackColor="#E5E5E5" />
            <SortedDescendingHeaderStyle BackColor="#242121" />
        </asp:GridView>
            </center>
    </div>
</asp:Content>

