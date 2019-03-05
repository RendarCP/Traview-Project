<%@ Page Title="" Language="C#" MasterPageFile="~/PJ_traview/TraviewMaster.master" AutoEventWireup="true" CodeFile="mainMasterpage.aspx.cs" Inherits="PJ_traview_mainMasterpage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <style>
* {box-sizing: border-box}
body {font-family: Verdana, sans-serif; margin:0}
.mySlides {display: none}
img {vertical-align: middle;}

/* 슬라이드쇼 컨테이너 */
.slideshow-container {
  max-width: 1920px;
  position: relative;
  margin: auto;
}

/* 이전,다음버튼  */
.prev, .next {
  cursor: pointer;
  position: absolute;
  top: 50%;
  width: auto;
  padding: 16px;
  margin-top: -22px;
  color: white;
  font-weight: bold;
  font-size: 18px;
  transition: 0.6s ease;
  border-radius: 0 3px 3px 0;
}

/* 다음버튼 위치 오른쪽*/
.next {
  right: 0;
  border-radius: 3px 0 0 3px;
}

/* 이전 다음버튼 마우스 올라갈시 */
.prev:hover, .next:hover {
  background-color: rgba(0,0,0,0.8);
}

/* 작은사이즈텍스트 */
.text {
  color: #ffc044;
  font-size: 20px;
  padding: 8px 12px;
  position: absolute;
  bottom: 8px;
  width: 100%;
  text-align: center;
  font-weight: bold;
}
/* 큰사이즈 텍스트 */
.text h3 {
  color: #f2f2f2;
  font-size: 50px;
  padding: 8px 12px;
  position: absolute;
  bottom: 8px;
  width: 100%;
  text-align: center;
}

/* Number text (1/3 etc) */
.numbertext {
  color: #f2f2f2;
  font-size: 12px;
  padding: 8px 12px;
  position: absolute;
  top: 0;
}

/* The dots/bullets/indicators */
.dot {
  cursor: pointer;
  height: 15px;
  width: 15px;
  margin: 0 2px;
  background-color: #bbb;
  border-radius: 50%;
  display: inline-block;
  transition: background-color 0.6s ease;
}

.active, .dot:hover {
  background-color: #717171;
}

/* Fading animation */
.fade {
  -webkit-animation-name: fade;
  -webkit-animation-duration: 1.5s;
  animation-name: fade;
  animation-duration: 1.5s;
}

@-webkit-keyframes fade {
  from {opacity: .4} 
  to {opacity: 1}
}

@keyframes fade {
  from {opacity: .4} 
  to {opacity: 1}
}

/* On smaller screens, decrease text size */
@media only screen and (max-width: 300px) {
  .prev, .next,.text {font-size: 11px}
}
</style>
    <div class="slideshow-container">

<div class="mySlides fade">
  <img src="image/재미있는여행.jpg" style="width:100%">
  <div class="text"><h3>신나고 재미있는 여행</h3></div>
  <div class="text">설레이고 기대되는 여행기간</div>
</div>

<div class="mySlides fade">
  <img src="image/여행계획.jpg" style="width:100%">
    <div class="text"><h3>트레뷰와 함께해요</h3></div>
  <div class="text">여행계획과 정보등을 함께 공유해봐요</div>
</div>

<div class="mySlides fade">
  <img src="image/신나는여행.jpg" style="width:100%">
    <div class="text"><h3>신나는 여행</h3></div>
  <div class="text">트레뷰와 함께 마지막까지 신나는 여행이 되어봐요</div>
</div>

<a class="prev" onclick="plusSlides(-1)">&#10094;</a>
<a class="next" onclick="plusSlides(1)">&#10095;</a>

</div>
<div style="text-align:center"> 
  <span class="dot" onclick="currentSlide(1)"></span> 
  <span class="dot" onclick="currentSlide(2)"></span> 
  <span class="dot" onclick="currentSlide(3)"></span> 
</div>
 <script> //자동으로 슬라이드되는 스크립트 지정 
    var slideIndex = 1;
      showSlides(slideIndex);

       function plusSlides(n) {
        showSlides(slideIndex += n);
        }
       function currentSlide(n) {
        showSlides(slideIndex = n);
        }
       function showSlides(n) {
         var i;
         var slides = document.getElementsByClassName("mySlides");
         var dots = document.getElementsByClassName("dot");
         if (n > slides.length) {slideIndex = 1}
         if (n < 1) {slideIndex = slides.length}
         for (i = 0; i < slides.length; i++) {
            slides[i].style.display = "none";
          }
         for (i = 0; i < dots.length; i++) {
            dots[i].className = dots[i].className.replace(" active", "");
          }
         if (slideIndex> slides.length) {slideIndex = 1}
          slides[slideIndex-1].style.display = "block";
          dots[slideIndex-1].className += " active";
          }
         setInterval(plusSlides, 5000, 1); // 다음으로 넘어갈 초 지정

</script>
    <center>
    <div>
       <table>
        <tr>
            <td>
               <asp:DataList ID="Dlschedule" runat="server"></asp:DataList>
            </td>
            <td>
                <%--여백 발생을 위해서 --%>
            </td>
            <td>
                <asp:GridView ID="grvQnA" runat="server"></asp:GridView>
            </td>
            <td>
                <%--여백 발생을 위해서 --%>
            </td>
            <td>
                <asp:GridView ID="grvEvent" runat="server"></asp:GridView>
            </td>
        </tr>
       </table>
    </div>
    <div>
        <table>
            <tr>
                <td>
                   <asp:DataList ID="Dlcitytour" runat="server"></asp:DataList>
                 </td>
                <td><%--여백 발생을 위해서 --%></td>
                <td><%--여백 발생을 위해서 --%></td>
                <td><%--여백 발생을 위해서 --%></td>
                <td><%--여백 발생을 위해서 --%></td>
                <td>
                    <asp:GridView ID="grvReview" runat="server"></asp:GridView>
                </td>
            </tr>
        </table>
    </div>
        </center>

</asp:Content>

