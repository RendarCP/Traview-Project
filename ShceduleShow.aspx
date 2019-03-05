<%@ Page Title="" Language="C#" MasterPageFile="~/PJ_traview/TraviewMaster.master" AutoEventWireup="true" CodeFile="ShceduleShow.aspx.cs" Inherits="ShceduleShow" %>

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
      color: #0087ff;
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
            border:1px solid black;
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
        .gridview{
                display: inline-block;
                margin:0 auto;
               width:1000px;
               text-align:center;
        }
    </style>
<div class="container">
    <asp:Image ID="Image1" runat="server" ImageUrl="~/image/여행리뷰.jpg" Height="50%" Width="100%" />
        <div class="main"><h2>나만의 여행일정</h2> </div>
        <div class="sub"><h3>자신만의 여행일정을 만들어보아요</h3></div>
    </div>
     <div class="outdiv">
        <div class="indiv">
            <div style="text-align:left;">
                <asp:Label ID="Label1" runat="server" Text="나만의 일정" Font-Bold="True" Font-Names="한컴 고딕" Font-Size="20pt"></asp:Label>
            </div>
            <div class="gridview" >
                <asp:GridView ID="grvScdule" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:TemplateField HeaderText="여행별 일정 제목">
                            <ItemTemplate>
                                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%#GetShowUrl(Eval("no")) %>' Text='<%#Eval("title") %>'></asp:HyperLink>
                            </ItemTemplate>
                            <ItemStyle Width="700px" />
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="작성자" DataField="author" ItemStyle-Width="80px" ItemStyle-HorizontalAlign="Center" />
                        <asp:TemplateField HeaderText="작성일">
                          <ItemTemplate>
                              <%#Eval("uploaddate","{0:yyyy/MM/dd}") %>
                           </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle BackColor="#CCCC99" />
                    <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                    <RowStyle BackColor="#F7F7DE" />
                    <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#FBFBF2" />
                    <SortedAscendingHeaderStyle BackColor="#848384" />
                    <SortedDescendingCellStyle BackColor="#EAEAD3" />
                    <SortedDescendingHeaderStyle BackColor="#575357" />
                </asp:GridView>
            </div>
   </div>
                </div>
</asp:Content>

