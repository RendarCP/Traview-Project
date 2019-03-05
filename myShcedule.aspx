<%@ Page Title="" Language="C#" MasterPageFile="~/PJ_traview/TraviewMaster.master" AutoEventWireup="true" CodeFile="myShcedule.aspx.cs" Inherits="myShcedule" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
          <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1">
  <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
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
        .Indivin{
            display:inline-block;
            width:50%;
            height:100%;
            padding:10px;
            text-align:center;
          display: inline-block;
          vertical-align:middle;
        }
        /*데이터리스트 css지정*/
        .gridview{
                display: inline-block;
                margin:0 auto;
               width:500px;
               text-align:center;
        }
    </style>

     <div class="outdiv">
        <div class="indiv">
            <div style="text-align:left; border:3px solid gray;">
                <asp:Label ID="lbltitle" runat="server" Text="" Font-Bold="True" Font-Names="한컴 고딕" Font-Size="20pt"></asp:Label>
                <br />
                &nbsp&nbsp<asp:Label ID="lblauthor" runat="server" Text=""></asp:Label> | [<asp:Label ID="lbluploaddate" runat="server" Text=""></asp:Label>]
            </div>
            <br />
            <div  class="gridview" style="border:1px solid green; text-align:center">
                <!--데이터리스트 지정 -->
                <asp:DataList ID="DDlShcedule" runat="server" RepeatColumns="3" CellPadding="3" RepeatDirection="Horizontal" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" ForeColor="Black" GridLines="Vertical">
                    <AlternatingItemStyle BackColor="#CCCCCC" />
                    <FooterStyle BackColor="#CCCCCC" />
                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                    <ItemTemplate>
                        <div style="text-align:left"><asp:Label ID="lbldayinfo" runat="server" Font-Bold="True" Font-Names="맑은 고딕"><%#Eval("dayinfo") %></asp:Label>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lbldate" runat="server"><%#Eval("uploaddate","{0:yyyy/MM/dd}") %></asp:Label>
                            <br />
                            <asp:Label ID="lbltriptime" runat="server"><%#Eval("tripTime") %></asp:Label>
                        </div>
                        <br />
                        <hr />
                        <div style="text-align:center">                        
                            &nbsp
                            <asp:Label ID="Label3" runat="server" Text="나라" Font-Names="맑은 고딕" Font-Size="20px" ForeColor="#009933"></asp:Label> - <asp:Label ID="lblcountry" runat="server" Font-Names="맑은 고딕"><%#Eval("country") %></asp:Label>
                            <br />                        &nbsp
                            <asp:Label ID="Label5" runat="server" Text="도시" Font-Names="맑은 고딕" Font-Size="20px" ForeColor="#0066CC"></asp:Label> - <asp:Label ID="lblcity" runat="server" Font-Names="맑은 고딕"><%#Eval("city") %></asp:Label>
                            <br />
                            <asp:Label ID="Label6" runat="server" Text="일정메모" Font-Names="맑은 고딕" Font-Size="20px"></asp:Label>
                            <br />
                            -<asp:Label ID="lblmemo" runat="server" Font-Names="맑은 고딕"><%#Eval("sd_memo") %></asp:Label>-
                            <hr />
                    </ItemTemplate>
                    <SelectedItemStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                </asp:DataList>
            </div><br />
            <br />
    <asp:Label ID="lblcontents" runat="server" Text=""></asp:Label>
            <br />
            <div style="text-align:right">
                <asp:Button ID="btnlist" runat="server" Text="목록" Width="100px" Font-Bold="True" Font-Names="맑은 고딕" OnClick="btnlist_Click" BackColor="#0099CC" ForeColor="White"/>
                &nbsp<asp:Button ID="btndelte" runat="server" Text="삭제" Font-Bold="True" Font-Names="맑은 고딕" OnClick="btndelte_Click" Width="100px" BackColor="#CC0000" ForeColor="White"/></div>
   </div>
                </div>
</asp:Content>

