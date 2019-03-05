using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Info_traview : System.Web.UI.Page
{
    static int reveiw = 21; //리뷰게시판
    static int QnA = 22; //QnA게시판
    static BBSinfo bbsInfo; //게시판 정보
    static DataSet DShelper;
    static string Country = "";
    static TripInfo tripInfo;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //제목 표시줄에 부착된 게시판 번호 가져옴
            //id = int.Parse(Request["id"]);
            Dbhelper myhelper = new Dbhelper();
            bbsInfo = myhelper.GetBbsInfo(reveiw);
            bbsInfo = myhelper.GetBbsInfo(QnA);
            if (Session["userid"] != null)
            {

            }
            //DShelper = myhelper.GetInfoList(bbsInfo.bbsname, reveiw, Country);
            //DisplayList();
            //DShelper = myhelper.GetInfoList(bbsInfo.bbsname, QnA, Country);
            //DisplayQnA();
            //myhelper.Close();
            if(Request.Url.ToString()== "http://localhost:61040/Info_traview.aspx?country=hong_kong")
            {
                img_Info.ImageUrl = "~/InfoPhotos/Info_홍콩_1.jpg";
                string country = "홍콩";
                myhelper.GetTripInfo(country);
                li_time.Visible = true;
                li_season.Visible = true;
                li_flying.Visible = true;
                li_voltage.Visible = true;
                li_visa.Visible = true;
                lblParallax.Visible = true;
                lblParallax.Text = "(시차 -1시간)";
                tripInfo = myhelper.Tripdetails(country);
                lblCountry.Text = tripInfo.Countryname;
                lblSeason.Text = tripInfo.CountrySeason;
                lblvoltage.Text = tripInfo.CountryElect;
                lblFlying.Text = tripInfo.CountryFlying;
                lblVisa.Text = tripInfo.Visa;
                DShelper = myhelper.cityInfoList(bbsInfo.bbsname, reveiw, country);
                DisplayList();
                DShelper = myhelper.cityInfoList(bbsInfo.bbsname, QnA, country);
                DisplayQnA();
                myhelper.Close();
            }
            else if (Request.Url.ToString() == "http://localhost:61040/Info_traview.aspx?country=osaka")
            {
                img_Info.ImageUrl = "~/InfoPhotos/Info_오사카_2.jpg";
                string country = "오사카";
                myhelper.GetTripInfo(country);
                li_time.Visible = true;
                li_season.Visible = true;
                li_flying.Visible = true;
                li_voltage.Visible = true;
                li_visa.Visible = true;
                tripInfo = myhelper.Tripdetails(country);
                lblCountry.Text = tripInfo.Countryname;
                lblSeason.Text = tripInfo.CountrySeason;
                lblvoltage.Text = tripInfo.CountryElect;
                lblFlying.Text = tripInfo.CountryFlying;
                lblVisa.Text = tripInfo.Visa;
                DShelper = myhelper.cityInfoList(bbsInfo.bbsname, reveiw, country);
                DisplayList();
                DShelper = myhelper.cityInfoList(bbsInfo.bbsname, QnA, country);
                DisplayQnA();
                myhelper.Close();
            }
           else if (Request.Url.ToString() == "http://localhost:61040/Info_traview.aspx?country=fukuoka")
            {
                img_Info.ImageUrl = "~/InfoPhotos/Info_후쿠오카_3.jpg";
                string country = "후쿠오카";
                myhelper.GetTripInfo(country);
                li_time.Visible = true;
                li_season.Visible = true;
                li_flying.Visible = true;
                li_voltage.Visible = true;
                li_visa.Visible = true;
                tripInfo = myhelper.Tripdetails(country);
                lblCountry.Text = tripInfo.Countryname;
                lblSeason.Text = tripInfo.CountrySeason;
                lblvoltage.Text = tripInfo.CountryElect;
                lblFlying.Text = tripInfo.CountryFlying;
                lblVisa.Text = tripInfo.Visa;
                DShelper = myhelper.cityInfoList(bbsInfo.bbsname, reveiw, country);
                DisplayList();
                DShelper = myhelper.cityInfoList(bbsInfo.bbsname, QnA, country);
                DisplayQnA();
                myhelper.Close();
            }
            else if (Request.Url.ToString() == "http://localhost:61040/Info_traview.aspx?country=tokyo")
            {
                img_Info.ImageUrl = "~/InfoPhotos/Info_도쿄_4.jpg";
                string country = "도쿄";
                myhelper.GetTripInfo(country);
                li_time.Visible = true;
                li_season.Visible = true;
                li_flying.Visible = true;
                li_voltage.Visible = true;
                li_visa.Visible = true;
                tripInfo = myhelper.Tripdetails(country);
                lblCountry.Text = tripInfo.Countryname;
                lblSeason.Text = tripInfo.CountrySeason;
                lblvoltage.Text = tripInfo.CountryElect;
                lblFlying.Text = tripInfo.CountryFlying;
                lblVisa.Text = tripInfo.Visa;
                DShelper = myhelper.cityInfoList(bbsInfo.bbsname, reveiw, country);
                DisplayList();
                DShelper = myhelper.cityInfoList(bbsInfo.bbsname, QnA, country);
                DisplayQnA();
                myhelper.Close();
            }
            else if (Request.Url.ToString() == "http://localhost:61040/Info_traview.aspx?country=Beijing")
            {
                img_Info.ImageUrl = "~/InfoPhotos/Info_베이징_5.jpg";
                string country = "베이징";
                myhelper.GetTripInfo(country);
                li_time.Visible = true;
                li_season.Visible = true;
                li_flying.Visible = true;
                li_voltage.Visible = true;
                li_visa.Visible = true;
                lblParallax.Visible = true;
                lblParallax.Text = "(시차 -1시간)";
                tripInfo = myhelper.Tripdetails(country);
                lblCountry.Text = tripInfo.Countryname;
                lblSeason.Text = tripInfo.CountrySeason;
                lblvoltage.Text = tripInfo.CountryElect;
                lblFlying.Text = tripInfo.CountryFlying;
                lblVisa.Text = tripInfo.Visa;
                DShelper = myhelper.cityInfoList(bbsInfo.bbsname, reveiw, country);
                DisplayList();
                DShelper = myhelper.cityInfoList(bbsInfo.bbsname, QnA, country);
                DisplayQnA();
                myhelper.Close();
            }
            else if (Request.Url.ToString() == "http://localhost:61040/Info_traview.aspx?country=Shanghai")
            {
                img_Info.ImageUrl = "~/InfoPhotos/Info_상하이_6.jpg";
                string country = "상하이";
                myhelper.GetTripInfo(country);
                li_time.Visible = true;
                li_season.Visible = true;
                li_flying.Visible = true;
                li_voltage.Visible = true;
                li_visa.Visible = true;
                lblParallax.Visible = true;
                lblParallax.Text = "(시차 -1시간)";
                tripInfo = myhelper.Tripdetails(country);
                lblCountry.Text = tripInfo.Countryname;
                lblSeason.Text = tripInfo.CountrySeason;
                lblvoltage.Text = tripInfo.CountryElect;
                lblFlying.Text = tripInfo.CountryFlying;
                lblVisa.Text = tripInfo.Visa;
                DShelper = myhelper.cityInfoList(bbsInfo.bbsname, reveiw, country);
                DisplayList();
                DShelper = myhelper.cityInfoList(bbsInfo.bbsname, QnA, country);
                DisplayQnA();
                myhelper.Close();
            }
            else if (Request.Url.ToString() == "http://localhost:61040/Info_traview.aspx?country=taipei")
            {
                img_Info.ImageUrl = "~/InfoPhotos/Info_타이베이_7.jpg";
                string country = "타이베이";
                myhelper.GetTripInfo(country);
                li_time.Visible = true;
                li_season.Visible = true;
                li_flying.Visible = true;
                li_voltage.Visible = true;
                li_visa.Visible = true;
                lblParallax.Visible = true;
                lblParallax.Text = "(시차 -1시간)";
                tripInfo = myhelper.Tripdetails(country);
                lblCountry.Text = tripInfo.Countryname;
                lblSeason.Text = tripInfo.CountrySeason;
                lblvoltage.Text = tripInfo.CountryElect;
                lblFlying.Text = tripInfo.CountryFlying;
                lblVisa.Text = tripInfo.Visa;
                DShelper = myhelper.cityInfoList(bbsInfo.bbsname, reveiw, country);
                DisplayList();
                DShelper = myhelper.cityInfoList(bbsInfo.bbsname, QnA, country);
                DisplayQnA();
                myhelper.Close();
            }
            else if (Request.Url.ToString() == "http://localhost:61040/Info_traview.aspx?country=macao")
            {
                img_Info.ImageUrl = "~/InfoPhotos/Info_마카오_8.jpg";
                string country = "마카오";
                myhelper.GetTripInfo(country);
                li_time.Visible = true;
                li_season.Visible = true;
                li_flying.Visible = true;
                li_voltage.Visible = true;
                li_visa.Visible = true;
                lblParallax.Visible = true;
                lblParallax.Text = "(시차 -1시간)";
                tripInfo = myhelper.Tripdetails(country);
                lblCountry.Text = tripInfo.Countryname;
                lblSeason.Text = tripInfo.CountrySeason;
                lblvoltage.Text = tripInfo.CountryElect;
                lblFlying.Text = tripInfo.CountryFlying;
                lblVisa.Text = tripInfo.Visa;
                DShelper = myhelper.cityInfoList(bbsInfo.bbsname, reveiw, country);
                DisplayList();
                DShelper = myhelper.cityInfoList(bbsInfo.bbsname, QnA, country);
                DisplayQnA();
                myhelper.Close();
            }
            else if (Request.Url.ToString() == "http://localhost:61040/Info_traview.aspx?country=Singapore")
            {
                img_Info.ImageUrl = "~/InfoPhotos/Info_싱가포르_9.jpg";
                string country = "싱가포르";
                myhelper.GetTripInfo(country);
                li_time.Visible = true;
                li_season.Visible = true;
                li_flying.Visible = true;
                li_voltage.Visible = true;
                li_visa.Visible = true;
                lblParallax.Visible = true;
                lblParallax.Text = "(시차 -1시간)";
                tripInfo = myhelper.Tripdetails(country);
                lblCountry.Text = tripInfo.Countryname;
                lblSeason.Text = tripInfo.CountrySeason;
                lblvoltage.Text = tripInfo.CountryElect;
                lblFlying.Text = tripInfo.CountryFlying;
                lblVisa.Text = tripInfo.Visa;
                DShelper = myhelper.cityInfoList(bbsInfo.bbsname, reveiw, country);
                DisplayList();
                DShelper = myhelper.cityInfoList(bbsInfo.bbsname, QnA, country);
                DisplayQnA();
                myhelper.Close();
            }
            else if (Request.Url.ToString() == "http://localhost:61040/Info_traview.aspx?country=Bangkok")
            {
                img_Info.ImageUrl = "~/InfoPhotos/Info_방콕_10.jpg";
                string country = "방콕";
                myhelper.GetTripInfo(country);
                li_time.Visible = true;
                li_season.Visible = true;
                li_flying.Visible = true;
                li_voltage.Visible = true;
                li_visa.Visible = true;
                lblParallax.Visible = true;
                lblParallax.Text = "(시차 -2시간)";
                tripInfo = myhelper.Tripdetails(country);
                lblCountry.Text = tripInfo.Countryname;
                lblSeason.Text = tripInfo.CountrySeason;
                lblvoltage.Text = tripInfo.CountryElect;
                lblFlying.Text = tripInfo.CountryFlying;
                lblVisa.Text = tripInfo.Visa;
                DShelper = myhelper.cityInfoList(bbsInfo.bbsname, reveiw, country);
                DisplayList();
                DShelper = myhelper.cityInfoList(bbsInfo.bbsname, QnA, country);
                DisplayQnA();
                myhelper.Close();
            }
            else if (Request.Url.ToString() == "http://localhost:61040/Info_traview.aspx?country=Boracay")
            {
                img_Info.ImageUrl = "~/InfoPhotos/Info_보라카이_11.jpg";
                string country = "보라카이";
                myhelper.GetTripInfo(country);
                li_time.Visible = true;
                li_season.Visible = true;
                li_flying.Visible = true;
                li_voltage.Visible = true;
                li_visa.Visible = true;
                lblParallax.Visible = true;
                lblParallax.Text = "(시차 -1시간)";
                tripInfo = myhelper.Tripdetails(country);
                lblCountry.Text = tripInfo.Countryname;
                lblSeason.Text = tripInfo.CountrySeason;
                lblvoltage.Text = tripInfo.CountryElect;
                lblFlying.Text = tripInfo.CountryFlying;
                lblVisa.Text = tripInfo.Visa;
                DShelper = myhelper.cityInfoList(bbsInfo.bbsname, reveiw, country);
                DisplayList();
                DShelper = myhelper.cityInfoList(bbsInfo.bbsname, QnA, country);
                DisplayQnA();
                myhelper.Close();
            }
            else if (Request.Url.ToString() == "http://localhost:61040/Info_traview.aspx?country=danang")
            {
                img_Info.ImageUrl = "~/InfoPhotos/Info_다낭_12.jpg";
                string country = "다낭";
                myhelper.GetTripInfo(country);
                li_time.Visible = true;
                li_season.Visible = true;
                li_flying.Visible = true;
                li_voltage.Visible = true;
                li_visa.Visible = true;
                lblParallax.Visible = true;
                lblParallax.Text = "(시차 -2시간)";
                tripInfo = myhelper.Tripdetails(country);
                lblCountry.Text = tripInfo.Countryname;
                lblSeason.Text = tripInfo.CountrySeason;
                lblvoltage.Text = tripInfo.CountryElect;
                lblFlying.Text = tripInfo.CountryFlying;
                lblVisa.Text = tripInfo.Visa;
                DShelper = myhelper.cityInfoList(bbsInfo.bbsname, reveiw, country);
                DisplayList();
                DShelper = myhelper.cityInfoList(bbsInfo.bbsname, QnA, country);
                DisplayQnA();
                myhelper.Close();
            }
            else if (Request.Url.ToString() == "http://localhost:61040/Info_traview.aspx?country=hochiminh")
            {
                img_Info.ImageUrl = "~/InfoPhotos/Info_호치민_13.jpg";
                string country = "호치민";
                myhelper.GetTripInfo(country);
                li_time.Visible = true;
                li_season.Visible = true;
                li_flying.Visible = true;
                li_voltage.Visible = true;
                li_visa.Visible = true;
                lblParallax.Visible = true;
                lblParallax.Text = "(시차 -2시간)";
                tripInfo = myhelper.Tripdetails(country);
                lblCountry.Text = tripInfo.Countryname;
                lblSeason.Text = tripInfo.CountrySeason;
                lblvoltage.Text = tripInfo.CountryElect;
                lblFlying.Text = tripInfo.CountryFlying;
                lblVisa.Text = tripInfo.Visa;
                DShelper = myhelper.cityInfoList(bbsInfo.bbsname, reveiw, country);
                DisplayList();
                DShelper = myhelper.cityInfoList(bbsInfo.bbsname, QnA, country);
                DisplayQnA();
                myhelper.Close();
            }
            else if (Request.Url.ToString() == "http://localhost:61040/Info_traview.aspx?country=Laos")
            {
                img_Info.ImageUrl = "~/InfoPhotos/Info_라오스_14.jpg";
                string country = "라오스";
                myhelper.GetTripInfo(country);
                li_time.Visible = true;
                li_season.Visible = true;
                li_flying.Visible = true;
                li_voltage.Visible = true;
                li_visa.Visible = true;
                lblParallax.Visible = true;
                lblParallax.Text = "(시차 -2시간)";
                tripInfo = myhelper.Tripdetails(country);
                lblCountry.Text = tripInfo.Countryname;
                lblSeason.Text = tripInfo.CountrySeason;
                lblvoltage.Text = tripInfo.CountryElect;
                lblFlying.Text = tripInfo.CountryFlying;
                lblVisa.Text = tripInfo.Visa;
                DShelper = myhelper.cityInfoList(bbsInfo.bbsname, reveiw, country);
                DisplayList();
                DShelper = myhelper.cityInfoList(bbsInfo.bbsname, QnA, country);
                DisplayQnA();
                myhelper.Close();
            }
            else if (Request.Url.ToString() == "http://localhost:61040/Info_traview.aspx?country=Paris")
            {
                img_Info.ImageUrl = "~/InfoPhotos/Info_파리_15.jpg";
                string country = "파리";
                myhelper.GetTripInfo(country);
                li_time.Visible = true;
                li_season.Visible = true;
                li_flying.Visible = true;
                li_voltage.Visible = true;
                li_visa.Visible = true;
                lblParallax.Visible = true;
                lblParallax.Text = "(시차 -7시간)";
                tripInfo = myhelper.Tripdetails(country);
                lblCountry.Text = tripInfo.Countryname;
                lblSeason.Text = tripInfo.CountrySeason;
                lblvoltage.Text = tripInfo.CountryElect;
                lblFlying.Text = tripInfo.CountryFlying;
                lblVisa.Text = tripInfo.Visa;
                DShelper = myhelper.cityInfoList(bbsInfo.bbsname, reveiw, country);
                DisplayList();
                DShelper = myhelper.cityInfoList(bbsInfo.bbsname, QnA, country);
                DisplayQnA();
                myhelper.Close();
            }
            else if (Request.Url.ToString() == "http://localhost:61040/Info_traview.aspx?country=Rome")
            {
                img_Info.ImageUrl = "~/InfoPhotos/Info_로마_16.jpg";
                string country = "로마";
                myhelper.GetTripInfo(country);
                li_time.Visible = true;
                li_season.Visible = true;
                li_flying.Visible = true;
                li_voltage.Visible = true;
                li_visa.Visible = true;
                lblParallax.Visible = true;
                lblParallax.Text = "(시차 -7시간)";
                tripInfo = myhelper.Tripdetails(country);
                lblCountry.Text = tripInfo.Countryname;
                lblSeason.Text = tripInfo.CountrySeason;
                lblvoltage.Text = tripInfo.CountryElect;
                lblFlying.Text = tripInfo.CountryFlying;
                lblVisa.Text = tripInfo.Visa;
                DShelper = myhelper.cityInfoList(bbsInfo.bbsname, reveiw, country);
                DisplayList();
                DShelper = myhelper.cityInfoList(bbsInfo.bbsname, QnA, country);
                DisplayQnA();
                myhelper.Close();
            }
            else if (Request.Url.ToString() == "http://localhost:61040/Info_traview.aspx?country=London")
            {
                img_Info.ImageUrl = "~/InfoPhotos/Info_런던_17.jpg";
                string country = "런던";
                myhelper.GetTripInfo(country);
                li_time.Visible = true;
                li_season.Visible = true;
                li_flying.Visible = true;
                li_voltage.Visible = true;
                li_visa.Visible = true;
                lblParallax.Visible = true;
                lblParallax.Text = "(시차 -8시간)";
                tripInfo = myhelper.Tripdetails(country);
                lblCountry.Text = tripInfo.Countryname;
                lblSeason.Text = tripInfo.CountrySeason;
                lblvoltage.Text = tripInfo.CountryElect;
                lblFlying.Text = tripInfo.CountryFlying;
                lblVisa.Text = tripInfo.Visa;
                DShelper = myhelper.cityInfoList(bbsInfo.bbsname, reveiw, country);
                DisplayList();
                DShelper = myhelper.cityInfoList(bbsInfo.bbsname, QnA, country);
                DisplayQnA();
                myhelper.Close();
            }
            else if (Request.Url.ToString() == "http://localhost:61040/Info_traview.aspx?country=Moscow")
            {
                img_Info.ImageUrl = "~/InfoPhotos/Info_모스크바_18.jpg";
                string country = "모스크바";
                myhelper.GetTripInfo(country);
                li_time.Visible = true;
                li_season.Visible = true;
                li_flying.Visible = true;
                li_voltage.Visible = true;
                li_visa.Visible = true;
                lblParallax.Visible = true;
                lblParallax.Text = "(시차 -6시간)";
                tripInfo = myhelper.Tripdetails(country);
                lblCountry.Text = tripInfo.Countryname;
                lblSeason.Text = tripInfo.CountrySeason;
                lblvoltage.Text = tripInfo.CountryElect;
                lblFlying.Text = tripInfo.CountryFlying;
                lblVisa.Text = tripInfo.Visa;
                DShelper = myhelper.cityInfoList(bbsInfo.bbsname, reveiw, country);
                DisplayList();
                DShelper = myhelper.cityInfoList(bbsInfo.bbsname, QnA, country);
                DisplayQnA();
                myhelper.Close();
            }
            else if (Request.Url.ToString() == "http://localhost:61040/Info_traview.aspx?country=New_York")
            {
                img_Info.ImageUrl = "~/InfoPhotos/Info_뉴욕_19.jpg";
                string country = "뉴욕";
                myhelper.GetTripInfo(country);
                li_time.Visible = true;
                li_season.Visible = true;
                li_flying.Visible = true;
                li_voltage.Visible = true;
                li_visa.Visible = true;
                lblParallax.Visible = true;
                lblParallax.Text = "(시차 -13시간)";
                tripInfo = myhelper.Tripdetails(country);
                lblCountry.Text = tripInfo.Countryname;
                lblSeason.Text = tripInfo.CountrySeason;
                lblvoltage.Text = tripInfo.CountryElect;
                lblFlying.Text = tripInfo.CountryFlying;
                lblVisa.Text = tripInfo.Visa;
                DShelper = myhelper.cityInfoList(bbsInfo.bbsname, reveiw, country);
                DisplayList();
                DShelper = myhelper.cityInfoList(bbsInfo.bbsname, QnA, country);
                DisplayQnA();
                myhelper.Close();
            }
            else if (Request.Url.ToString() == "http://localhost:61040/Info_traview.aspx?country=Hawaii")
            {
                img_Info.ImageUrl = "~/InfoPhotos/Info_하와이_20.jpg";
                string country = "하와이";
                myhelper.GetTripInfo(country);
                li_time.Visible = true;
                li_season.Visible = true;
                li_flying.Visible = true;
                li_voltage.Visible = true;
                li_visa.Visible = true;
                lblParallax.Visible = true;
                lblParallax.Text = "(시차 -19시간)";
                tripInfo = myhelper.Tripdetails(country);
                lblCountry.Text = tripInfo.Countryname;
                lblSeason.Text = tripInfo.CountrySeason;
                lblvoltage.Text = tripInfo.CountryElect;
                lblFlying.Text = tripInfo.CountryFlying;
                lblVisa.Text = tripInfo.Visa;
                DShelper = myhelper.cityInfoList(bbsInfo.bbsname, reveiw, country);
                DisplayList();
                DShelper = myhelper.cityInfoList(bbsInfo.bbsname, QnA, country);
                DisplayQnA();
                myhelper.Close();
            }
            else if (Request.Url.ToString() == "http://localhost:61040/Info_traview.aspx?country=San_Francisco")
            {
                img_Info.ImageUrl = "~/InfoPhotos/Info_샌프란시스코_21.jpg";
                string country = "샌프란시스코";
                myhelper.GetTripInfo(country);
                li_time.Visible = true;
                li_season.Visible = true;
                li_flying.Visible = true;
                li_voltage.Visible = true;
                li_visa.Visible = true;
                lblParallax.Visible = true;
                lblParallax.Text = "(시차 -16시간)";
                tripInfo = myhelper.Tripdetails(country);
                lblCountry.Text = tripInfo.Countryname;
                lblSeason.Text = tripInfo.CountrySeason;
                lblvoltage.Text = tripInfo.CountryElect;
                lblFlying.Text = tripInfo.CountryFlying;
                lblVisa.Text = tripInfo.Visa;
                DShelper = myhelper.cityInfoList(bbsInfo.bbsname, reveiw, country);
                DisplayList();
                DShelper = myhelper.cityInfoList(bbsInfo.bbsname, QnA, country);
                DisplayQnA();
                myhelper.Close();
            }
            else if (Request.Url.ToString() == "http://localhost:61040/Info_traview.aspx?country=Las_Vegas")
            {
                img_Info.ImageUrl = "~/InfoPhotos/Info_라스베이거스_22.jpg";
                string country = "라스베이거스";
                myhelper.GetTripInfo(country);
                li_time.Visible = true;
                li_season.Visible = true;
                li_flying.Visible = true;
                li_voltage.Visible = true;
                li_visa.Visible = true;
                lblParallax.Visible = true;
                lblParallax.Text = "(시차 -16시간)";
                tripInfo = myhelper.Tripdetails(country);
                lblCountry.Text = tripInfo.Countryname;
                lblSeason.Text = tripInfo.CountrySeason;
                lblvoltage.Text = tripInfo.CountryElect;
                lblFlying.Text = tripInfo.CountryFlying;
                lblVisa.Text = tripInfo.Visa;
                DShelper = myhelper.cityInfoList(bbsInfo.bbsname, reveiw, country);
                DisplayList();
                DShelper = myhelper.cityInfoList(bbsInfo.bbsname, QnA, country);
                DisplayQnA();
                myhelper.Close();
            }
            else if (Request.Url.ToString() == "http://localhost:61040/Info_traview.aspx?country=seoul")
            {
                img_Info.ImageUrl = "~/InfoPhotos/Info_서울_23.jpg";
                string country = "서울";
                myhelper.GetTripInfo(country);
                li_time.Visible = true;
                li_season.Visible = true;
                li_place.Visible = true;
                li_festival.Visible = true;
                li_experience.Visible = true;
                tripInfo = myhelper.Tripdetails(country);
                lblCountry.Text = tripInfo.Countryname;
                lblSeason.Text = tripInfo.CountrySeason;
                lblplace.Text = tripInfo.place;
                lblFestival.Text = tripInfo.festival;
                lblexperience.Text = tripInfo.experience;
                DShelper = myhelper.cityInfoList(bbsInfo.bbsname, reveiw, country);
                DisplayList();
                DShelper = myhelper.cityInfoList(bbsInfo.bbsname, QnA, country);
                DisplayQnA();
                myhelper.Close();
            }
            else if (Request.Url.ToString() == "http://localhost:61040/Info_traview.aspx?country=busan")
            {
                img_Info.ImageUrl = "~/InfoPhotos/Info_부산_24.jpg";
                string country = "부산";
                myhelper.GetTripInfo(country);
                li_time.Visible = true;
                li_season.Visible = true;
                li_place.Visible = true;
                li_festival.Visible = true;
                li_experience.Visible = true;
                tripInfo = myhelper.Tripdetails(country);
                lblCountry.Text = tripInfo.Countryname;
                lblSeason.Text = tripInfo.CountrySeason;
                lblplace.Text = tripInfo.place;
                lblFestival.Text = tripInfo.festival;
                lblexperience.Text = tripInfo.experience;
                DShelper = myhelper.cityInfoList(bbsInfo.bbsname, reveiw, country);
                DisplayList();
                DShelper = myhelper.cityInfoList(bbsInfo.bbsname, QnA, country);
                DisplayQnA();
                myhelper.Close();
            }
            else if (Request.Url.ToString() == "http://localhost:61040/Info_traview.aspx?country=jeju")
            {
                img_Info.ImageUrl = "~/InfoPhotos/Info_제주_25.jpg";
                string country = "제주";
                myhelper.GetTripInfo(country);
                li_time.Visible = true;
                li_season.Visible = true;
                li_flying.Visible = true;
                li_place.Visible = true;
                li_experience.Visible = true;
                li_food.Visible = true;
                tripInfo = myhelper.Tripdetails(country);
                lblCountry.Text = tripInfo.Countryname;
                lblSeason.Text = tripInfo.CountrySeason;
                lblFlying.Text = tripInfo.CountryFlying;
                lblplace.Text = tripInfo.place;
                lblexperience.Text = tripInfo.experience;
                lblfood.Text = tripInfo.food;
                DShelper = myhelper.cityInfoList(bbsInfo.bbsname, reveiw, country);
                DisplayList();
                DShelper = myhelper.cityInfoList(bbsInfo.bbsname, QnA, country);
                DisplayQnA();
                myhelper.Close();
            }
            else //if (Request.Url.ToString() == "http://localhost:61040/Info_traview.aspx?country=jeonju")
            {
                img_Info.ImageUrl = "~/InfoPhotos/Info_전주_26.jpg";
                string country = "전주";
                myhelper.GetTripInfo(country);
                li_time.Visible = true;
                li_season.Visible = true;
                li_place.Visible = true;
                li_festival.Visible = true;
                li_experience.Visible = true;
                li_food.Visible = true;
                tripInfo = myhelper.Tripdetails(country);
                lblCountry.Text = tripInfo.Countryname;
                lblSeason.Text = tripInfo.CountrySeason;
                lblplace.Text = tripInfo.place;
                lblFestival.Text = tripInfo.festival;
                lblexperience.Text = tripInfo.experience;
                lblfood.Text = tripInfo.food;
                DShelper = myhelper.cityInfoList(bbsInfo.bbsname, reveiw, country);
                DisplayList();
                DShelper = myhelper.cityInfoList(bbsInfo.bbsname, QnA, country);
                DisplayQnA();
                myhelper.Close();
            }

        }
    }
    private void DisplayList()
    {
        //Dbhelper myhelper = new Dbhelper();
        //데이터셋 형식으로 정보가져와서 그리드뷰에 지정
        //grvBbs.DataSource = myhelper.GetBbsList();
        //페이지번호에 따른 이동
        Info_Review.DataSource = DShelper;
        Info_Review.PageIndex = (Session["bbspage"] == null) ? 0 : (int)Session["bbspage"];
        Info_Review.DataBind();
        //myhelper.Close();
    }
    private void DisplayQnA()
    {
        Info_QnA.DataSource = DShelper;
        Info_QnA.PageIndex = (Session["bbspage"] == null) ? 0 : (int)Session["bbspage"];
        Info_QnA.DataBind();
    }

    protected void Timer1_Tick(object sender, EventArgs e)
    {
        lbltime.Text = DateTime.Now.ToString("hh:mm:ss");
        if (Request.Url.ToString() == "http://localhost:61040/Info_traview.aspx?country=hong_kong")
        {
            DateTime hongkong = DateTime.Now.AddHours(-1);
            lbltime.Text = hongkong.ToString("hh:mm:ss");
        }
        else if (Request.Url.ToString() == "http://localhost:61040/Info_traview.aspx?country=taipei")
        {
            DateTime taipei = DateTime.Now.AddHours(-1);
            lbltime.Text = taipei.ToString("hh:mm:ss");
        }
        else if (Request.Url.ToString() == "http://localhost:61040/Info_traview.aspx?country=macao")
        {
            DateTime macao = DateTime.Now.AddHours(-1);
            lbltime.Text = macao.ToString("hh:mm:ss");
        }
        else if (Request.Url.ToString() == "http://localhost:61040/Info_traview.aspx?country=Singapore")
        {
            DateTime Singapore = DateTime.Now.AddHours(-1);
            lbltime.Text = Singapore.ToString("hh:mm:ss");
        }
        else if (Request.Url.ToString() == "http://localhost:61040/Info_traview.aspx?country=Bangkok")
        {
            DateTime Bangkok = DateTime.Now.AddHours(-2);
            lbltime.Text = Bangkok.ToString("hh:mm:ss");
        }
        else if (Request.Url.ToString() == "http://localhost:61040/Info_traview.aspx?country=Boracay")
        {
            DateTime Boracay = DateTime.Now.AddHours(-1);
            lbltime.Text = Boracay.ToString("hh:mm:ss");
        }
        else if (Request.Url.ToString() == "http://localhost:61040/Info_traview.aspx?country=danang")
        {
            DateTime danang = DateTime.Now.AddHours(-2);
            lbltime.Text = danang.ToString("hh:mm:ss");
        }
        else if (Request.Url.ToString() == "http://localhost:61040/Info_traview.aspx?country=hochiminh")
        {
            DateTime hochiminh = DateTime.Now.AddHours(-2);
            lbltime.Text = hochiminh.ToString("hh:mm:ss");
        }
        else if (Request.Url.ToString() == "http://localhost:61040/Info_traview.aspx?country=Laos")
        {
            DateTime Laos = DateTime.Now.AddHours(-2);
            lbltime.Text = Laos.ToString("hh:mm:ss");
        }
        else if (Request.Url.ToString() == "http://localhost:61040/Info_traview.aspx?country=Paris")
        {
            DateTime Paris = DateTime.Now.AddHours(-7);
            lbltime.Text = Paris.ToString("hh:mm:ss");
        }
        else if (Request.Url.ToString() == "http://localhost:61040/Info_traview.aspx?country=Rome")
        {
            DateTime Rome = DateTime.Now.AddHours(-7);
            lbltime.Text = Rome.ToString("hh:mm:ss");
        }
        else if (Request.Url.ToString() == "http://localhost:61040/Info_traview.aspx?country=London")
        {
            DateTime London = DateTime.Now.AddHours(-8);
            lbltime.Text = London.ToString("hh:mm:ss");
        }
        else if (Request.Url.ToString() == "http://localhost:61040/Info_traview.aspx?country=Moscow")
        {
            DateTime Moscow = DateTime.Now.AddHours(-6);
            lbltime.Text = Moscow.ToString("hh:mm:ss");
        }
        else if (Request.Url.ToString() == "http://localhost:61040/Info_traview.aspx?country=New_York")
        {
            DateTime New_York = DateTime.Now.AddHours(-13);
            lbltime.Text = New_York.ToString("hh:mm:ss");
        }
        else if (Request.Url.ToString() == "http://localhost:61040/Info_traview.aspx?country=Hawaii")
        {
            DateTime Hawaii = DateTime.Now.AddHours(-19);
            lbltime.Text = Hawaii.ToString("hh:mm:ss");
        }
        else if (Request.Url.ToString() == "http://localhost:61040/Info_traview.aspx?country=San_Francisco")
        {
            DateTime San_Francisco = DateTime.Now.AddHours(-16);
            lbltime.Text = San_Francisco.ToString("hh:mm:ss");
        }
        else if (Request.Url.ToString() == "http://localhost:61040/Info_traview.aspx?country=Las_Vegas")
        {
            DateTime Las_Vegas = DateTime.Now.AddHours(-16);
            lbltime.Text = Las_Vegas.ToString("hh:mm:ss");
        }  

        else if(Request.Url.ToString() == "http://localhost:61040/Info_traview.aspx?country=osaka")
        {
            DateTime osaka = DateTime.Now.AddHours(0);
            lbltime.Text = osaka.ToString("hh:mm:ss");
        }
        else if (Request.Url.ToString() == "http://localhost:61040/Info_traview.aspx?country=Beijing")
        {
            DateTime Beijing = DateTime.Now.AddHours(-1);
            lbltime.Text = Beijing.ToString("hh:mm:ss");
        }
        else if (Request.Url.ToString() == "http://localhost:61040/Info_traview.aspx?country=Shanghai")
        {
            DateTime Shanghai = DateTime.Now.AddHours(-1);
            lbltime.Text = Shanghai.ToString("hh:mm:ss");
        }

    }
    public string GetShowReview(object no)
    {
        //회원이든 아니든 들어갈수있게 
        if (Session["userid"] == null)
        {
            return "reviewpage.aspx?id=" + reveiw + "&no=" + no.ToString();
        }
        else
        {
            return "reviewpage.aspx?id=" + reveiw + "&no=" + no.ToString();
        }
    }
    public string GetShowQnA(object no)
    {
        //회원이든 아니든 들어갈수있게 
        if (Session["userid"] == null)
        {
            return "QnApage.aspx?id=" + QnA + "&no=" + no.ToString();
        }
        else
        {
            return "QnApage.aspx?id=" + QnA + "&no=" + no.ToString();
        }
    }

    protected void Info_Review_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        Session["bbspage"] = e.NewPageIndex;
        DisplayList();
    }

    protected void Info_QnA_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        Session["bbspage"] = e.NewPageIndex;
        DisplayQnA();
    }
    protected void lkbtnReview_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/reviewTippage.aspx");
    }
    protected void lkbtnQnA_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/TraviewQnA.aspx");
    }
}