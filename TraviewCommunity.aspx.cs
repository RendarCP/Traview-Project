using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class TraviewCommunity : System.Web.UI.Page
{
    //모듈변수
    AlbumInfo albumInfo;
    static string tablename = "photos";
    static int albId = 31; //앨범번호
    static string uploadTable = ""; //자료가 보관된 테이블 이름

    static int reveiw = 21; //리뷰게시판
    static int QnA = 22; //QnA게시판
    static BBSinfo bbsInfo; //게시판 정보
    static DataSet DShelper;
    static int no;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DisplayAlbum();
            //제목 표시줄에 부착된 게시판 번호 가져옴
            //id = int.Parse(Request["id"]);
            Dbhelper myhelper = new Dbhelper();
            bbsInfo = myhelper.GetBbsInfo(reveiw);
            bbsInfo = myhelper.GetBbsInfo(QnA);
            if (Session["userid"] != null)
            {

            }
            DShelper = myhelper.GetInfoList(bbsInfo.bbsname, reveiw, null);
            DisplayList();
            DShelper = myhelper.GetInfoList(bbsInfo.bbsname, QnA, null);
            DisplayQnA();

            albumInfo = myhelper.GetAlbumInfo(albId);
            //lblAlbumTitle.Text += "(" + albumInfo.albumtitle + ")";
            myhelper.Close();
        }
    }
    private void DisplayAlbum()
    {
        //Dbhelper 객체를 생성, 사진관련 정보를 데이터셋으로 가져오고,
        //이를 GridView의 DataSource로 지정
        Dbhelper myhelper = new Dbhelper();
        dblCommunity.DataSource = myhelper.GetPhotoList(tablename, albId);
        //데이터 바인드
        dblCommunity.DataBind();
    }
    //사진의 주소를 가져옵니다.
    public string GetImageUrl(object no, object fname)
    {
        //사진의 확장자를 가져옴
        Dbhelper myhelper = new Dbhelper();
        return @"~\albumphoto\" + "photos_" + no.ToString() + fname.ToString().Substring(fname.ToString().IndexOf("."));

    }
    public string GetShowUrl(object no)
    {
        //회원이든 아니든 들어갈수있게 
        if (Session["userid"] == null)
        {
            return "Photo_show.aspx?id=" + albId + "&no=" + no.ToString();
        }
        else
        {
            return "Photo_show.aspx?id=" + albId + "&no=" + no.ToString();
        }
    }
    private void DisplayList()
    {
        //Dbhelper myhelper = new Dbhelper();
        //데이터셋 형식으로 정보가져와서 그리드뷰에 지정
        //grvBbs.DataSource = myhelper.GetBbsList();
        //페이지번호에 따른 이동
        CommunityRV.DataSource = DShelper;
        CommunityRV.PageIndex = (Session["bbspage"] == null) ? 0 : (int)Session["bbspage"];
        CommunityRV.DataBind();
        //myhelper.Close();
    }
    private void DisplayQnA()
    {
        CommunityQnA.DataSource = DShelper;
        CommunityQnA.PageIndex = (Session["bbspage"] == null) ? 0 : (int)Session["bbspage"];
        CommunityQnA.DataBind();
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

    protected void CommunityRV_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        Session["bbspage"] = e.NewPageIndex;
        DisplayList();
    }

    protected void CommunityQnA_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        Session["bbspage"] = e.NewPageIndex;
        DisplayList();
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/reviewTippage.aspx");
    }
    protected void lkbtnQnA_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/TraviewQnA.aspx");
    }
    protected void lkbtnPic_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/TraviewPicture.aspx");
    }
}
