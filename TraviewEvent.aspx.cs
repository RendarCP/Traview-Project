using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class TraviewReview : System.Web.UI.Page
{
    EventInfo eventInfo;
    static int admin = 0;// 관리자 등급
    static int ugrade = 0;//사용자 등급
    static string tablename = "Event";
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            DisplayAlbum();
            //관리자 등급 구해오고 관리자만 작성가능
            string stadmin = "관리자";
            Dbhelper myhelper = new Dbhelper();
            admin = myhelper.GetIntGrade(stadmin);
            //사용자 등급 구함
            if(Session["userid"] != null)
            {
                ugrade = myhelper.GetUserGrade(Session["userid"].ToString());
                //관리자면 쓰기 버튼 활성화
                if (ugrade == admin) btnEvent.Visible = true;
            }

            eventInfo = myhelper.Eventdetailsinfo(tablename);
            
        }
    }
    private void DisplayAlbum()
    {
        //Dbhelper 객체를 생성, 사진관련 정보를 데이터셋으로 가져오고,
        //이를 GridView의 DataSource로 지정
        Dbhelper myhelper = new Dbhelper();
        DdlEvent.DataSource = myhelper.GetEventList(tablename);
        //데이터 바인드
        DdlEvent.DataBind();
    }

    public string GetImageUrl(object no, object filename)
    {
        //사진의 확장자를 가져옴
        Dbhelper myhelper = new Dbhelper();
        return @"~\Event\" + "Event_" + no.ToString() + filename.ToString().Substring(filename.ToString().IndexOf("."));

    }

    public string GetShowUrl(object no)
    {
        //회원이든 아니든 들어갈수있게 
        if (Session["userid"] == null)
        {
            return "Eventdetail.aspx?detail" + "&no=" + no.ToString();
        }
        else
        {
            return "Eventdetail.aspx?detail" + "&no=" + no.ToString();
        }
    }

    protected void btnEvent_Click(object sender, EventArgs e)
    {
        Response.Redirect("EventInputpage.aspx?md=0");
    }
}