using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class GuideMap : System.Web.UI.Page
{
    //모듈변수
    AlbumInfo albumInfo;
    static string tablename = "guidebook";
    static int albId = 50; //앨범번호
    static string uploadTable = ""; //자료가 보관된 테이블 이름
    static int admin = 0;// 관리자 등급
    static int ugrade = 0;//사용자 등급

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //관리자 등급 구해오고 관리자만 작성가능
            string stadmin = "관리자";


            //albId = int.Parse(Request["id"]);
            //앨범정보를 가져옴


            //앨범 목록 보이기
            DisplayAlbum();
            Dbhelper myhelper = new Dbhelper();

            admin = myhelper.GetIntGrade(stadmin);
            //사용자 등급 구함
            if (Session["userid"] != null)
            {
                ugrade = myhelper.GetUserGrade(Session["userid"].ToString());
                //관리자면 쓰기 버튼 활성화
                if (ugrade == admin) btnSave.Visible = true;
            }

            albumInfo = myhelper.GetAlbumInfo(albId);
            
            myhelper.Close();
        }

    }
    private void DisplayAlbum()
    {
        //Dbhelper 객체를 생성, 사진관련 정보를 데이터셋으로 가져오고,
        //이를 GridView의 DataSource로 지정
        Dbhelper myhelper = new Dbhelper();
        dblGuideMap.DataSource = myhelper.GetGuideList();
        //데이터 바인드
        dblGuideMap.DataBind();
        myhelper.Close();
    }
    //사진의 주소를 가져옵니다.
    public string GetImageUrl(object no, object fname)
    {
        //사진의 확장자를 가져옴
        Dbhelper myhelper = new Dbhelper();
        return @"~\Guidephoto\" + "photos_" + no.ToString() + fname.ToString().Substring(fname.ToString().IndexOf("."));
        

    }
    public string GetShowUrl(object no)
    {
        //회원이든 아니든 들어갈수있게 
        if (Session["userid"] == null)
        {
            return "Guide_show.aspx?id=" + albId + "&no=" + no.ToString();
        }
        else
        {
            return "Guide_show.aspx?id=" + albId + "&no=" + no.ToString();
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Guide_Upload.aspx?id=" + albId + "&md=0");
    }
}