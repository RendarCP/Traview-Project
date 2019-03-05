using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class TraviewMaster : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //처음 접속할 경우 실행
        if(!IsPostBack)
        {
            //로그인 여부 확인 --> 성공시 세션 변수에 userid 저장
            if(Session["userid"]==null)
            {
                //로그인 되지 않은 상태 --> 로그인 표시 유지 
                ibtnLoginToggle.ImageUrl = "~/image/로그인.jpg";

            }
            else
            {
                //로그인 표시 안보이게
                ibtnLoginToggle.ImageUrl = "~/image/로그아웃.jpg";
                //데이터베이스 정보가져옴
                Dbhelper myhelper = new Dbhelper();
                lblLoginInfo.Text = myhelper.GetNickname(Session["userid"].ToString()) + " 님";
                myhelper.Close();
            }

        }
    }

    protected void ibtnLogo_Click(object sender, ImageClickEventArgs e)
    {
        //로고이미지 클릭시 메인페이지로 이동
        Response.Redirect("~/mainMasterpage.aspx");
    }

    protected void ibtntarvelInfo_Click(object sender, ImageClickEventArgs e)
    {
        //여행 정보페이지 
        Response.Redirect("~/Info_master.aspx");
    }

    protected void ibtnComunity_Click(object sender, ImageClickEventArgs e)
    {
        //커뮤니티 페이지 
        Response.Redirect("~/TraviewCommunity.aspx");
    }

    protected void ibtnShcedule_Click(object sender, ImageClickEventArgs e)
    {
        //여행 일정 페이지
        Response.Redirect("~/shcedulePage.aspx");
    }

    protected void ibtnGuidbook_Click(object sender, ImageClickEventArgs e)
    {
        //가이드북 페이지
        Response.Redirect("~/GuideMap.aspx");

    }

    protected void ibtnEvent_Click(object sender, ImageClickEventArgs e)
    {
        //이벤트 페이지
        Response.Redirect("~/TraviewEvent.aspx");

    }

    protected void ibtnRegister_Click(object sender, ImageClickEventArgs e)
    {
        //회원가입 페이지
        Response.Redirect("~/RegisterPage.aspx");
    }

    protected void ibtnLogin_Click(object sender, ImageClickEventArgs e)
    {
        //로그인 페이지
        //로그인 여부 확인 -- 로그인 성공시 저장
        if (Session["userid"] == null)
        {
            //로그인 되지 않은 상태 --> 로그인 페이지 호출
            Response.Redirect("Loginpage.aspx");
        }
        else
        {
            //로그인된 상태 --> 로그아웃처리 
            Session["userid"] = null;
            ibtnLoginToggle.ImageUrl = "~/image/로그아웃.jpg";
        }
    }
}
