using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class travelinput : System.Web.UI.Page
{
    Dbhelper myhelper = new Dbhelper();
    static DataSet DShelper;
   static int no;
    DataTable dt = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (ViewState["data"] == null)
        //{
        //    DataTable dataTable = new DataTable();
        //    dataTable.Columns.Add("shcedule");
        //    ViewState["data"] = dataTable;
        //}
       // no = myhelper.GetInfoNo();
        if (!IsPostBack)
        {
            //no = int.Parse(Request["no"].ToString());
            ++no;
            Dbhelper myhelper = new Dbhelper();
            //직접들어올경우대비
            no = myhelper.GetInfoNo();
            if (Session["userid"] == null)//로그인 되지않음
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('로그인이 필요합니다');", true);
                Response.Redirect("TraviewQnA.aspx");
            }
            else //로그인되어있음
            {
                Session["returnUrl"] = Request.UrlReferrer.ToString();
            }
            switch (int.Parse(Request["md"]))
            {
                case 0://새글 
                    break;
                //case 1://수정

                    //bbsInfo = myhelper.GetBbsInfo(bbsId);
                    //articleInfo = myhelper.GetDetailsQnA(bbsInfo.bbsname, int.Parse(Request["no"]), false);
                    ////myhelper.GetDetails(tablename, int.Parse(Request["no"]), false);
                    ////작성자만 수정
                    //if (Session["userid"].ToString() != articleInfo.author) return;
                    ////제목,글 표시
                    //txtTitle.Text = articleInfo.title;
                    //txtContents.Text = articleInfo.contents;
                    //DDlkategorie.SelectedValue = articleInfo.Kategorie;
                    //break;
            }
            if (Request.UrlReferrer.ToString().IndexOf("shcedulepage.aspx") <= 0)
                Session["returnUrl"] = Request.UrlReferrer.ToString();
            DShelper = myhelper.GetShceduleList(no);
            DisplayList();
            myhelper.Close();

            //DataTable dt = new DataTable();
            //dt.Columns.AddRange(new DataColumn[5] { new DataColumn("no"), new DataColumn("shcedule"),new DataColumn("country"),new DataColumn("city"),new DataColumn("memo") });
            //ViewState["Traview"] = dt;
            //this.BindGrid();
        }
        DisplayList();
    }
    //protected void BindGrid()
    //{
    //    grvTour.DataSource = (DataTable)ViewState["Traview"];
    //    grvTour.DataBind();
    //}
    //protected void Insert(object sender, EventArgs e)
    //{
    //    int i;
    //    DataTable dt = (DataTable)ViewState["Customers"];
    //    dt.Rows.Add(i,libShcedule.SelectedValue.ToString(),ddlCountry.SelectedValue.ToString(), ddlCity.SelectedValue.ToString(),txtMemo.Text.Trim());
    //    ViewState["Customers"] = dt;
    //    this.BindGrid();
    //    txtMemo.Text = string.Empty;
    //}
    //게시판 목록 보이기
    private void DisplayList()
    {
        //Dbhelper myhelper = new Dbhelper();
        //데이터셋 형식으로 정보가져와서 그리드뷰에 지정
        //grvBbs.DataSource = myhelper.GetBbsList();
        //페이지번호에 따른 이동
        //grvTour.DataSource = DShelper;
        //grvTour.PageIndex = (Session["bbspage"] == null) ? 0 : (int)Session["bbspage"];
        //SqlDataSource1.SelectCommand = "select * from shcedule";
        //SqlDataSource1.Select(DataSourceSelectArguments.Empty);
        //SqlDataSource1.DataBind();
        Dbhelper myhelper = new Dbhelper();
        myhelper.GetShceduleList(no);
        //SqlDataSource1.DataBind();
        SqlDataSource1.SelectCommand = "SELECT * FROM shcedule WHERE infoId = " + no + " AND author = '" + Session["userid"] + "'";
        SqlDataSource1.Select(DataSourceSelectArguments.Empty);
        SqlDataSource1.DataBind();
        grvTour.DataBind();
        myhelper.Close();
    }

    protected void btnScdelte_Click(object sender, EventArgs e)
    {
        libShcedule.Items.Remove(libShcedule.SelectedItem);
    }

    protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(ddlCountry.SelectedValue== "한국")
        {
            ddlCity.Items.Clear();
            ddlCity.Items.Add("서울");
            ddlCity.Items.Insert(1, "부산");
            ddlCity.Items.Insert(2, "전주");
            ddlCity.Items.Insert(3, "제주");
            ddlCity.Items.Insert(4, "강릉");
            ddlCity.Items.Insert(5, "기타(선택지외의 도시/장소)");
        }
        else if(ddlCountry.SelectedValue == "일본")
        {
            ddlCity.Items.Clear();
            ddlCity.Items.Add("도쿄");
            ddlCity.Items.Add("오사카");
            ddlCity.Items.Add("후쿠오카");
            ddlCity.Items.Add("삿포로");
            ddlCity.Items.Add("기타(선택지외의 도시/장소)/장소)");
        }
        else if (ddlCountry.SelectedValue == "일본")
        {
            ddlCity.Items.Clear();
            ddlCity.Items.Add("도쿄");
            ddlCity.Items.Add("오사카");
            ddlCity.Items.Add("후쿠오카");
            ddlCity.Items.Add("삿포로");
            ddlCity.Items.Add("기타(선택지외의 도시/장소)");
        }
        else if (ddlCountry.SelectedValue == "중국")
        {
            ddlCity.Items.Clear();
            ddlCity.Items.Add("베이징");
            ddlCity.Items.Add("홍콩");
            ddlCity.Items.Add("마카오");
            ddlCity.Items.Add("상하이");
            ddlCity.Items.Add("광저우");
            ddlCity.Items.Add("기타(선택지외의 도시/장소)");
        }
        else if (ddlCountry.SelectedValue == "대만")
        {
            ddlCity.Items.Clear();
            ddlCity.Items.Add("타이베이");
            ddlCity.Items.Add("가오슝");
            ddlCity.Items.Add("타이난");
            ddlCity.Items.Add("타이중");
            ddlCity.Items.Add("기타(선택지외의 도시/장소)");
        }
        else if (ddlCountry.SelectedValue == "싱가포르")
        {
            ddlCity.Items.Clear();
            ddlCity.Items.Add("주룽");
            ddlCity.Items.Add("앙 모 키오");
            ddlCity.Items.Add("클레멘티");
            ddlCity.Items.Add("우드랜즈");
            ddlCity.Items.Add("유니버셜스튜디오");
            ddlCity.Items.Add("기타(선택지외의 도시/장소)");
        }
        else if (ddlCountry.SelectedValue == "필리핀")
        {
            ddlCity.Items.Clear();
            ddlCity.Items.Add("마닐라");
            ddlCity.Items.Add("세부");
            ddlCity.Items.Add("보라카이");
            ddlCity.Items.Add("따가이따이");
            ddlCity.Items.Add("기타(선택지외의 도시/장소)");
        }
        else if (ddlCountry.SelectedValue == "베트남")
        {
            ddlCity.Items.Clear();
            ddlCity.Items.Add("하노이");
            ddlCity.Items.Add("호찌민");
            ddlCity.Items.Add("다낭");
            ddlCity.Items.Add("호이안");
            ddlCity.Items.Add("기타(선택지외의 도시/장소)");
        }
        else if (ddlCountry.SelectedValue == "프랑스")
        {
            ddlCity.Items.Clear();
            ddlCity.Items.Add("파리");
            ddlCity.Items.Add("리옹");
            ddlCity.Items.Add("마르세유");
            ddlCity.Items.Add("몽펠리에");
            ddlCity.Items.Add("보르도");
            ddlCity.Items.Add("기타(선택지외의 도시/장소)");
        }
        else if (ddlCountry.SelectedValue == "영국")
        {
            ddlCity.Items.Clear();
            ddlCity.Items.Add("런던");
            ddlCity.Items.Add("옥스퍼드");
            ddlCity.Items.Add("맨체스터");
            ddlCity.Items.Add("버밍엄");
            ddlCity.Items.Add("에든버러");
            ddlCity.Items.Add("케임브리지");
            ddlCity.Items.Add("리버풀");
            ddlCity.Items.Add("기타(선택지외의 도시/장소)");
        }
        else if (ddlCountry.SelectedValue == "이탈리아")
        {
            ddlCity.Items.Clear();
            ddlCity.Items.Add("로마");
            ddlCity.Items.Add("베네치아");
            ddlCity.Items.Add("피렌체");
            ddlCity.Items.Add("밀라노");
            ddlCity.Items.Add("베로나");
            ddlCity.Items.Add("토리노");
            ddlCity.Items.Add("기타(선택지외의 도시/장소)");
        }
        else if (ddlCountry.SelectedValue == "스페인")
        {
            ddlCity.Items.Clear();
            ddlCity.Items.Add("마드리드");
            ddlCity.Items.Add("세비야");
            ddlCity.Items.Add("바르셀로나");
            ddlCity.Items.Add("말라가");
            ddlCity.Items.Add("발렌시아");
            ddlCity.Items.Add("기타(선택지외의 도시/장소)");
        }
        else if (ddlCountry.SelectedValue == "미국")
        {
            ddlCity.Items.Clear();
            ddlCity.Items.Add("뉴욕");
            ddlCity.Items.Add("시카고");
            ddlCity.Items.Add("샌프란시스코");
            ddlCity.Items.Add("로스앤젤레스");
            ddlCity.Items.Add("시애틀");
            ddlCity.Items.Add("애틀랜타");
            ddlCity.Items.Add("마이애미");
            ddlCity.Items.Add("워싱턴D.C");
            ddlCity.Items.Add("하와이");
            ddlCity.Items.Add("알레스카");
            ddlCity.Items.Add("기타(선택지외의 도시/장소)");
        }
        else if (ddlCountry.SelectedValue == "호주")
        {
            ddlCity.Items.Clear();
            ddlCity.Items.Add("시드니");
            ddlCity.Items.Add("멜버른");
            ddlCity.Items.Add("캔버라");
            ddlCity.Items.Add("브리즈번");
            ddlCity.Items.Add("기타(선택지외의 도시/장소)");
        }
        else
        {
            ddlCity.Items.Clear();
        }
    }

    ///---------------------일차 등록버튼 했을시 데이터베이스없이 그리드뷰 입력시 코드 
    //    Button4.Attributes.Add("AutoPostback", "true");
    //    //foreach(listitem li in libshcedule.items)
    //    //{
    //    //    if (li.selected)
    //    //    {
    //    //        ddlcity.selectedvalue
    //    //    }
    //    //}
    //    if (i == 0)
    //    {
    //        ++i;
    //        //++i;
    //        DataTable dt = (DataTable)ViewState["Traview"];
    //        dt.Rows.Add(i, libShcedule.SelectedValue.ToString(), ddlCountry.SelectedValue.ToString(), ddlCity.SelectedValue.ToString(), txtMemo.Text.Trim());
    //        //i++;
    //        ViewState["Traview"] = dt;
    //        this.BindGrid();
    //        txtMemo.Text = string.Empty;
    //        ++i;
    //    }
    //    else if(i >1)
    //    {
    //        //++i;
    //        DataTable dt = (DataTable)ViewState["Traview"];
    //        dt.Rows.Add(i, libShcedule.SelectedValue.ToString(), ddlCountry.SelectedValue.ToString(), ddlCity.SelectedValue.ToString(), txtMemo.Text.Trim());
    //        // i++;
    //        ViewState["Traview"] = dt;
    //        this.BindGrid();
    //        txtMemo.Text = string.Empty;
    //        ++i;
    //    }
    //    //DataTable dt = (DataTable)ViewState["Traview"];
    //    //dt.Rows.Add(i, libShcedule.SelectedValue.ToString(), ddlCountry.SelectedValue.ToString(), ddlCity.SelectedValue.ToString(), txtMemo.Text.Trim());
    //    //i++;
    //    //ViewState["Traview"] = dt;
    //    //this.BindGrid();
    //    //txtMemo.Text = string.Empty;


    protected void btnCalendar_Click(object sender, EventArgs e)
    {
        DisplayList();
        if (libShcedule.SelectedValue == "" || ddlCountry.SelectedValue == "여행 나라를 선택해주세요" || ddlCity.SelectedValue == null || ddlCountry.SelectedValue == "" || txtMemo.Text == "" )
        {
            if (libShcedule.SelectedValue == "")
            {
                lblErrormessage.Text = "일정 목록(선택)은 필수입니다.";
            }
            else if (ddlCountry.SelectedValue == "여행 나라를 선택해주세요" || ddlCountry.SelectedValue == "")
            {
                lblErrormessage.Text = "나라선택를 선택해 주세요.";
            }
            else if (ddlCity.SelectedValue == null)
            {
                lblErrormessage.Text = "도시를 선택해주세요.";
            }
            else
            {
                lblErrormessage.Text = "메모를 입력해주세요 (필수)";
            }
            lblErrormessage.Text = "제목,메모,일정목록(선택),나라,도시,메모는 빈칸으로 입력될수 없습니다";
        }
        else
        {
            Dbhelper myHelper = new Dbhelper();
            int infoid = myHelper.GetInfoNo();
            myHelper.insertshcedule(libShcedule.SelectedValue.ToString(), int.Parse(libShcedule.SelectedIndex.ToString()), ddlCountry.SelectedValue.ToString(), ddlCity.SelectedValue.ToString(), txtMemo.Text, Session["userid"].ToString(), infoid, DdlTimelist.SelectedValue + " - " + DdlTime.SelectedValue);
            DShelper = myHelper.GetShceduleList(no);
            DisplayList();
            myHelper.Close();
        }
        //else {
        //    Dbhelper myHelper = new Dbhelper();
        //    Response.Write(myHelper.GetInfoNo().ToString());
        //}
    }

    protected void btnShceduleAdd_Click(object sender, EventArgs e)
    {
        if (txtbox.Text == "")
        {
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('일정 입력은 필수입니다.');", true);
        }
        else
        {
            libShcedule.Items.Add(txtbox.Text);
        }
        //dt = (DataTable)ViewState["data"];
        //string _value = txtbox.Text.Trim();
        //dt.Rows.Add(_value);

        //libShcedule.DataSource = dt;
        //libShcedule.DataTextField = "shcedule";
        //libShcedule.DataValueField = "shcedule";
        //libShcedule.DataBind();

        //txtbox.Text = "";
    }

    protected void btnMakeShcedule_Click(object sender, EventArgs e)
    {
        Dbhelper myHelper = new Dbhelper();
        if (txtTitle.Text == "" || txtBigMemo.Text == "")
        {
            if(txtTitle.Text == "")
            {
                lblErrormessage.Text = "제목은 필수 입력사항입니다.";
            }
            else if(txtBigMemo.Text == "")
            {
                lblErrormessage.Text = "메모는 필수 입력사항입니다.";
            }
        }
        else
        {
            switch (int.Parse(Request["md"]))
            {
                case 0:
                    no = myHelper.insertInfoShcedule(txtTitle.Text, Session["userid"].ToString(), txtBigMemo.Text);
                    break;
            }
            Response.Redirect("shcedulepage.aspx");
        }
        myHelper.Close();
    }


    //protected void grvTour_SelectedIndexChanged1(object sender, EventArgs e)
    //{
    //    Dbhelper myhelper = new Dbhelper();
    //    //myhelper.GetShceduleList(no);
    //    //SqlDataSource1.DataBind();
    //    SqlDataSource1.SelectCommand = "DELETE FROM shcedule WHERE no = " + no;
    //    SqlDataSource1.Select(DataSourceSelectArguments.Empty);
    //    SqlDataSource1.DataBind();
    //    grvTour.DataBind();
    //    myhelper.Close();
    //    DisplayList();
    //}
}