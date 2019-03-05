<%@ Page Title="" Language="C#" MasterPageFile="~/PJ_traview/TraviewMaster.master" AutoEventWireup="true" CodeFile="Info_traview.aspx.cs" Inherits="Info_traview" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <style>
            /*div컨테이너 지정*/
        .container {
  position: relative;
  max-width: 1920px;
  text-align: center;
  margin:auto;
  margin-top:5px;
}
        .h1 {
            position: absolute;
            top: 20%;
            left: 50%;
            font-size: 50px;
            font-family: 맑은 고딕;
            color: white;
            text-align:center;
        }
        ul {
             display: table;
             vertical-align: middle;
              position: absolute;
                top: 35%;
                left: 50%;
                transform: translate(-60%, 30%);
                -ms-transform: translate(-50%, -50%);
            float:left; 
            list-style:none; 
            margin:1px;
            color:white;
            text-align:center;
        }
        li{
            display:inline-block;
                        float:left; 
            list-style:none; 
            margin:1px;
            color:white;
                padding: 30px 60px 50px 50px;
                background-color: #003300;
                background-color: rgba( 56, 56, 56, 0.7 );
        }
       .ul_size{
           width: 500px;
       }
        /*A태그 CSS 제목클릭시 나타나는것들 제거*/
     a,a:hover{
         color:#000000;
         text-decoration:none;
     }
    </style>
      <div class="container">
    <asp:Image ID="img_Info" runat="server"/>
        <h1 class="h1"><asp:Label ID="lblCountry" runat="server"></asp:Label></h1>
        <div class="ul_size">
        <ul>
            <li runat="server" id="li_time">
                <asp:Image ID="Image2" runat="server" ImageUrl="~/image/시계.png" />
                <br />
                <asp:Label ID="Label1" runat="server" Text="현지시간" Font-Size="30px" Font-Bold="True" Font-Names="맑은 고딕"></asp:Label>
                <br />
                <asp:Label ID="lblParallax" runat="server" Text="" Visible="False"></asp:Label>
                <br />

                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick" />
                    </Triggers>
                    <ContentTemplate>               
                         <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                <asp:Timer ID="Timer1" runat="server" Interval="1000" OnTick="Timer1_Tick"></asp:Timer>
                        <asp:Label ID="lbltime" runat="server" Font-Bold="True"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
                
            </li>
            <li runat="server" id="li_season" visible="false">
                <asp:Image ID="Image3" runat="server" ImageUrl="~/image/달력.png" />
                <br />
                <asp:Label ID="Label3" runat="server" Text="여행 시기" Font-Size="30px" Font-Bold="True" Font-Names="맑은 고딕"></asp:Label>
                <br />
                <br />
                <asp:Label ID="lblSeason" runat="server" Font-Bold="True"></asp:Label>
            </li>
             <li runat="server" id="li_voltage" visible="false">
                <asp:Image ID="Image8" runat="server" ImageUrl="~/image/전압.png" />
                <br />
                <asp:Label ID="Label14" runat="server" Text="전압" Font-Size="30px" Font-Bold="True" Font-Names="맑은 고딕"></asp:Label>
                <br />
                <br />
                <asp:Label ID="lblvoltage" runat="server" Font-Bold="True"></asp:Label>
            </li>
            <li runat="server" id="li_place" visible="false">
                <asp:Image ID="Image4" runat="server" ImageUrl="~/image/명소.png" />
                <br />
                <asp:Label ID="Label5" runat="server" Text="명소" Font-Size="30px" Font-Bold="True" Font-Names="맑은 고딕"></asp:Label>
                <br />
                <br />
                <asp:Label ID="lblplace" runat="server" Font-Bold="True"></asp:Label>
            </li>
            <li runat="server" id="li_flying" visible="false">
                <asp:Image ID="Image5" runat="server" ImageUrl="~/image/비행기.png" />
                <br />
                <asp:Label ID="Label7" runat="server" Text="비행시간" Font-Size="30px" Font-Bold="True" Font-Names="맑은 고딕"></asp:Label>
                <br />
                <br />
                <asp:Label ID="lblFlying" runat="server"  Font-Bold="True"></asp:Label>

            </li>
            <li runat="server" id="li_visa" visible="false">
                <asp:Image ID="Image9" runat="server" ImageUrl="~/image/비자.png" />
                <br />
                <asp:Label ID="Label16" runat="server" Text="비자" Font-Size="30px" Font-Bold="True" Font-Names="맑은 고딕"></asp:Label>
                <br />
                <br />
                <asp:Label ID="lblVisa" runat="server" Font-Bold="True"></asp:Label>
                
            </li>
            <li runat="server" id="li_festival" visible="false">
                <asp:Image ID="Image10" runat="server" ImageUrl="~/image/축제.png" />
                <br />
                <asp:Label ID="Label18" runat="server" Text="축제" Font-Size="30px" Font-Bold="True" Font-Names="맑은 고딕"></asp:Label>
                <br />
                <br />
                <asp:Label ID="lblFestival" runat="server" Font-Bold="True"></asp:Label>

            </li>
            <li runat="server" id="li_experience" visible="false">
                <asp:Image ID="Image6" runat="server" ImageUrl="~/image/관광체험.png" />
                <br />
                <asp:Label ID="Label8" runat="server" Text="체험" Font-Size="30px" Font-Bold="True" Font-Names="맑은 고딕"></asp:Label>
                <br />
                <br />
                <asp:Label ID="lblexperience" runat="server" Font-Bold="True"></asp:Label>
                
            </li>
            <li runat="server" id="li_food" visible="false">
                <asp:Image ID="Image7" runat="server" ImageUrl="~/image/특산물.png" />
                <br />
                <asp:Label ID="Label2" runat="server" Text="특산물" Font-Size="30px" Font-Bold="True" Font-Names="맑은 고딕"></asp:Label>
                <br />
                <br />
                <asp:Label ID="lblfood" runat="server" Font-Bold="True"></asp:Label>
                </li>
        </ul>
            </div>
        <div>
<table style="width:1024px; margin:auto">
<tr>
<td style="text-align:left">
<asp:Label ID="Label12" runat="server" Text="여행후기" Font-Bold="True" Font-Names="맑은 고딕" Font-Size="30px"></asp:Label>
    &nbsp&nbsp<asp:LinkButton ID="lkbtnReview" runat="server" OnClick="lkbtnReview_Click">+더보기</asp:LinkButton>

</td>
<td style="text-align:left">
<asp:Label ID="Label13" runat="server" Text="여행QnA" Font-Bold="True" Font-Names="맑은 고딕" Font-Size="30px"></asp:Label>
     &nbsp&nbsp<asp:LinkButton ID="lkbtnQnA" runat="server" OnClick="lkbtnQnA_Click">+더보기</asp:LinkButton>
</td>
</tr>
<tr>
<td style="border:solid 2px black">
<asp:GridView ID="Info_Review" runat="server" AutoGenerateColumns="False" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2" ForeColor="Black" GridLines="None" Font-Bold="False" Width="500px" OnPageIndexChanging="Info_Review_PageIndexChanging">
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
<asp:GridView ID="Info_QnA" runat="server" BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Horizontal" AutoGenerateColumns="False" Width="500px" OnPageIndexChanging="Info_QnA_PageIndexChanging">
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
</div>
<div style="padding-top:20px; margin:auto">
    <center>
<asp:DataList ID="Ddllist" runat="server"></asp:DataList>
        </center>
</div>
        </div>
</asp:Content>

