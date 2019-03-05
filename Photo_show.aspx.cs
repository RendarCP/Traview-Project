using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Photo_show : System.Web.UI.Page
{
    //모듈변수 선언
    AlbumInfo albumInfo; //앨범정보
    PhotoInfo photoInfo; //사진정보
    static DataSet myDs;

    static int albId = 31, no = 0;

    static string uploadTable, fname, author;

    protected void Page_Load(object sender, EventArgs e)
    {
        //제목표시줄에 부착된 앨범/사진번호를 가져옵니다.
        if (!IsPostBack)
        {
            albId = int.Parse(Request["id"]);
            no = int.Parse(Request["no"]);
            //앨범 및 사진에 해당하는 정보를 가져옵니다.
            Dbhelper myHelper = new Dbhelper();
            //앨범정보
            albumInfo = myHelper.GetAlbumInfo(albId);
            myDs = myHelper.GetPhotoReplyList(no);
            //사진정보
            photoInfo = myHelper.GetPhotoInfo(no);
            //앨범 제목 및 사진 제목 표시
            lblTitle.Text = photoInfo.title;
            lblUser.Text = photoInfo.author;
            lblHits.Text = photoInfo.hits.ToString();
            lblDate.Text = photoInfo.uploaddate;
            lblContents.Text = photoInfo.comment;
            

            string fileurl = "photos";
            //Image 컨트롤에 사진 표시
            imgMain.ImageUrl = "~/albumphoto/" + fileurl + "_" + no.ToString() + photoInfo.fname.Substring(photoInfo.fname.IndexOf("."));
            //테이블 이름 및 사진의 파일이름, 작성자 추출
            fname = photoInfo.fname;
            author = photoInfo.author;

            if (Session["userid"] != null)
            {
                if (Session["userid"].ToString() == photoInfo.author)
                {
                    btnUpdate.Visible = true;
                    btnDelete.Visible = true;
                }
            }
            myHelper.Close();
        }
        DisplayReply();
    }
    private void DisplayReply()
    {
        DDlreply.DataSource = myDs;
        DDlreply.DataBind();
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
            Dbhelper myHelper = new Dbhelper();
            uploadTable = "photos";
            myHelper.RemovePhoto(uploadTable, no);
            myHelper.Close();
            //업로드된 사진삭제 
            //실제 사진이 저장되는 위치 구하기

            Response.Redirect("TraviewCommunity.aspx");

    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        if (Session["userid"].ToString() == lblUser.Text)
        {
            Response.Redirect("Photo_upload.aspx?id=" + albId + "&md=1&no=" + no);
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {

        Response.Redirect("TraviewCommunity.aspx");
    }

    protected void btnReply_Click(object sender, EventArgs e)
    {
        if (Session["userid"] == null)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('댓글 작성에는 로그인이 필요합니다');", true);
        }
        else
        {
            Dbhelper myhelper = new Dbhelper();
            myhelper.InsertPhotoReply(no, Session["userid"].ToString(), txtReply.Text);
            myDs = myhelper.GetBbsReplyList(no);
            myhelper.Close();
            //댓글작성후 텍스트박스 지우고 목록 보이기
            txtReply.Text = "";
            DisplayReply();
        }
    }
}