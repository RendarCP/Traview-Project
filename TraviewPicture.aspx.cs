using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class TraviewPicture : System.Web.UI.Page
{
    AlbumInfo albumInfo;
    static string tablename = "photos";
    static int albId = 31; //앨범번호
    static string uploadTable = ""; //자료가 보관된 테이블 이름
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DisplayAlbum();
            //제목 표시줄에 부착된 게시판 번호 가져옴
            //id = int.Parse(Request["id"]);
            Dbhelper myhelper = new Dbhelper();
            if (Session["userid"] != null)
            {

            }

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
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (Session["userid"] == null)
        {
            //로그인이 필요하다는 경고창 발생 
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('로그인이 필요합니다');", true);
        }
        else
        {
            Response.Redirect("~/Photo_Upload.aspx?id=" + albId + "&md=0");
        }
    }
}