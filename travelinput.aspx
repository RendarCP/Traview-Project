<%@ Page Title="" Language="C#" MasterPageFile="~/PJ_traview/TraviewMaster.master" AutoEventWireup="true" CodeFile="travelinput.aspx.cs" Inherits="travelinput" validateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
                 <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1">
  <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script> 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <div class="auto-style1">
     <table style="width:100%;">
         <tr style="width:100%">
             <td style="text-align:center; width:40%;">

                 <asp:Label ID="Label2" runat="server" Text="제목" BackColor="#6699FF" Font-Bold="True" Font-Names="함초롬돋움" Width="100%"></asp:Label>

             </td>
             <td colspan="11" style="width:60%">

                 <asp:TextBox ID="txtTitle" runat="server" Width="100%"></asp:TextBox>

             </td>
         </tr>
         <tr>
             <td colspan="4">

                 <asp:Label ID="Label3" runat="server" Text="여행 일차" Font-Bold="True" Font-Names="맑은 고딕" Font-Size="20px"></asp:Label>

             </td>
             <td colspan="2" >
             </td>
             <td colspan="6">

                 <asp:Label ID="Label4" runat="server" Text="일정별 여행 일정" Font-Bold="True" Font-Names="맑은 고딕" Font-Size="20px"></asp:Label>

             </td>
         </tr>
         <tr>
             <td colspan="4" style="border:2px solid green; text-align:center; width:500px;">
                 <asp:Label ID="lblExplanation" runat="server" Text="자신만의 일정제목을 만들어보세요" Font-Bold="True" Font-Names="맑은 고딕" Font-Size="15px"></asp:Label>
                 <br />

                 <asp:Label ID="Label11" runat="server" Font-Bold="True" Font-Names="맑은 고딕" Font-Size="13px" ForeColor="#FF3300" Text="단, 일정목록에서 선택하셔야 등록이 가능합니다"></asp:Label>

                 <br />
                 <br />
                 <asp:Label ID="Label5" runat="server" Text="일차 제목" Font-Bold="True" Font-Italic="False" Font-Names="맑은 고딕" Font-Size="20px" ForeColor="#33CC33"></asp:Label><br />
                 <asp:TextBox ID="txtbox" runat="server" MaxLength="10" Height="20px"></asp:TextBox>&nbsp
                 <br />
                 <asp:Label ID="Label6" runat="server" Text="일차목록" Font-Bold="True" Font-Names="맑은 고딕" Font-Size="20px" ForeColor="#0099CC"></asp:Label>
                 <br />
                 <asp:ListBox ID="libShcedule" runat="server" Width="300px"></asp:ListBox>
                 <br />
                 <asp:Button ID="btnShceduleAdd" runat="server" Text="여행일차추가" OnClick="btnShceduleAdd_Click"  CssClass="btn btn-primary" Height="30px" Width="120px" CausesValidation="False"/>
                 <asp:Button ID="btnScdelte" runat="server" Text="일차삭제"  CssClass="btn-danger" Height="30px" OnClick="btnScdelte_Click" Width="120px" CausesValidation="False"/>
             <!--    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
                     <Columns>
                         <asp:BoundField HeaderText="일차별" />
                     </Columns>
                 </asp:GridView> -->
             <br />
                 <asp:Label ID="lblErrormessage" runat="server" Font-Bold="True" Font-Names="맑은 고딕" Font-Size="20px" ForeColor="Red"></asp:Label>
                 <br />
             </td>
             <td colspan="2" style="border-right:2px solid green; border-left:2px solid green;">
             </td>
             <td colspan="5" style="border:2px solid green; text-align:center" >
                 <asp:Label ID="Label12" runat="server" Text="일정 내용" Font-Bold="True" ForeColor="#3366CC"></asp:Label>
                 <br />
                 <asp:GridView ID="grvTour" runat="server" AutoGenerateColumns="False" Width="500px" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" GridLines="Vertical" DataSourceID="SqlDataSource1" DataKeyNames="no" ForeColor="Black">
                     <AlternatingRowStyle BackColor="White" />
                     <Columns>
                         <asp:CommandField ButtonType="Button" ShowDeleteButton="True" />
                         <asp:BoundField DataField="dayinfo" HeaderText="일차 제목" SortExpression="dayinfo" />
                         <asp:BoundField DataField="country" HeaderText="나라" SortExpression="country" />
                         <asp:BoundField DataField="city" HeaderText="도시" SortExpression="city" />
                         <asp:BoundField DataField="sd_memo" HeaderText="일정별 메모" SortExpression="sd_memo" >
                         </asp:BoundField>
                         <asp:BoundField DataField="tripTime" HeaderText="여행 시간" SortExpression="tripTime" />
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
                 <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:traviewAppConnectionString10 %>" DeleteCommand="DELETE FROM [shcedule] WHERE [no] = @no">
                     <DeleteParameters>
                         <asp:Parameter Name="no" Type="Int32" />
                     </DeleteParameters>
                 </asp:SqlDataSource>
             </td>
             <td style="border:2px solid green;">
                 <asp:Label ID="Label1" runat="server" Text="나라" Font-Bold="True" Font-Names="맑은 고딕" ForeColor="#0066CC"></asp:Label>&nbsp&nbsp
                 <asp:DropDownList ID="ddlCountry" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged">
                     <asp:ListItem>여행 나라를 선택해주세요</asp:ListItem>
                     <asp:ListItem>한국</asp:ListItem>
                     <asp:ListItem>일본</asp:ListItem>
                     <asp:ListItem>중국</asp:ListItem>
                     <asp:ListItem>대만</asp:ListItem>
                     <asp:ListItem>싱가포르</asp:ListItem>
                     <asp:ListItem>필리핀</asp:ListItem>
                     <asp:ListItem>베트남</asp:ListItem>
                     <asp:ListItem>프랑스</asp:ListItem>
                     <asp:ListItem>영국</asp:ListItem>
                     <asp:ListItem>이탈리아</asp:ListItem>
                     <asp:ListItem>스페인</asp:ListItem>
                     <asp:ListItem>미국</asp:ListItem>
                     <asp:ListItem>호주</asp:ListItem>
                 </asp:DropDownList>
                  &nbsp;
                  <br />
                  <br />
                 <asp:Label ID="Label9" runat="server" Text="도시" Font-Bold="True" Font-Names="맑은 고딕" ForeColor="#9999FF"></asp:Label>&nbsp&nbsp
                 <asp:DropDownList ID="ddlCity" runat="server" AutoPostBack="True">
                 </asp:DropDownList>
                  <br />
                  <br />
                 <asp:Label ID="Label10" runat="server" Text="여행시간" Font-Bold="True" Font-Names="맑은 고딕" ForeColor="#6600CC"></asp:Label>&nbsp&nbsp
                 <asp:DropDownList ID="DdlTimelist" runat="server">
                     <asp:ListItem>오전</asp:ListItem>
                     <asp:ListItem>오후</asp:ListItem>
                 </asp:DropDownList> - <asp:DropDownList ID="DdlTime" runat="server">
                     <asp:ListItem>1시</asp:ListItem>
                     <asp:ListItem>2시</asp:ListItem>
                     <asp:ListItem>3시</asp:ListItem>
                     <asp:ListItem>4시</asp:ListItem>
                     <asp:ListItem>5시</asp:ListItem>
                     <asp:ListItem>6시</asp:ListItem>
                     <asp:ListItem>7시</asp:ListItem>
                     <asp:ListItem>8시</asp:ListItem>
                     <asp:ListItem>9시</asp:ListItem>
                     <asp:ListItem>10시</asp:ListItem>
                     <asp:ListItem>11시</asp:ListItem>
                     <asp:ListItem>12시</asp:ListItem>
                 </asp:DropDownList>
                  <br />
                  <br />
                 <asp:Label ID="Label8" runat="server" Font-Bold="True" Font-Names="맑은 고딕" Text="일정별 메모"></asp:Label>
                 <br />
                 <asp:TextBox ID="txtMemo" runat="server" Height="50px" TextMode="MultiLine" Width="70%"></asp:TextBox>

             </td>
         </tr>
         <tr>
             <td colspan="4">

                 &nbsp;</td>
             <td colspan="2">
             </td>
             <td colspan="5" style="text-align:center;">
                 <asp:Button ID="btnCalendar" runat="server" Text="일정등록" width="100px" OnClick="btnCalendar_Click" CssClass="btn btn-primary"/>

             </td>
         </tr>
         <tr>
             <td colspan="12">

                 <asp:Label ID="Label7" runat="server" Font-Bold="True" Text="전체 일정 메모" Font-Names="맑은 고딕" Font-Size="20px"></asp:Label>

             </td>
         </tr>
         <tr>
             <td colspan="12" style="border:2px solid green;">

                 <asp:TextBox ID="txtBigMemo" runat="server" Height="100px" TextMode="MultiLine" Width="100%"></asp:TextBox>

             </td>
         </tr>
         <tr>
             <td colspan="12" style="text-align:right" class="auto-style1">
                 &nbsp&nbsp
                 </td>
         </tr>
         <tr>
             <td colspan="11">
             </td>
             <td style="text-align:right">

                 <asp:Button ID="btnMakeShcedule" runat="server" Text="일정만들기" CssClass="btn btn-success" OnClick="btnMakeShcedule_Click"/>

             </td>
         </tr>
         </table>
    </div>
</asp:Content>
