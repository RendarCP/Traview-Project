using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Photo_Upload : System.Web.UI.Page
{
    //모듈변수 선언
    static int no;
    //앨범 정보
 
    AlbumInfo albumInfo;

    PhotoInfo photoInfo;
    //앨범 번호
    static int albId = 31;
    //테이블 이름
    static string uploadTable = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //albId = int.Parse(Request["id"]);
            //앨범에 해당하는 정보를 가져옵니다.
            Dbhelper myhelper = new Dbhelper();
            photoInfo = myhelper.GetPhotoInfo(albId);
            //테이블 이름을 변수에 표시
            //uploadTable = Session["userid"].ToString();
            //호출한 위치 지정
            Session["returnUrl"] = Request.UrlReferrer.ToString();
           switch (int.Parse(Request["md"]))
            {
                case 0:
                    break;
                case 1:

                    albumInfo = myhelper.GetAlbumInfo(albId);
                    photoInfo = myhelper.GetPhotoInfo(int.Parse(Request["no"]));
                    if (Session["userid"].ToString() != photoInfo.author) return;
                    txtTitle.Text = photoInfo.title;
                    txtComment.Text = photoInfo.comment;
                    break;
            }
            if (Request.UrlReferrer.ToString().IndexOf("Photo_show.aspx") <= 0)
                Session["returnUrl"] = Request.UrlReferrer.ToString();
            myhelper.Close();
        }
        
    }

    protected void btnWrite_Click(object sender, EventArgs e)
    {
        Dbhelper myhelper = new Dbhelper();
        ////새글 입력
        //no = myhelper.InsertNewReview(tablename, txtTitle.Text, txtContents.Text, Session["userid"].ToString(), bbsId, fname, fsize);
        //myhelper.Close();

        string fname = "";
        //AlbumInfo의 테이블 이름으로 호출할 저장프로시저 작성
        //string proc = "procInsert" + uploadTable;
        //데이터베이스에 사진정보를 입력하고, 글번호를 가져옵니다.
        if(txtTitle.Text == "" || txtComment.Text == "")
        {
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('제목과 내용은 빈칸일수없습니다.');", true);
        }
        else if (FileUpload1.HasFile)
        {
            fname = this.GetFilename(FileUpload1.FileName);

            //입력모드에 따른 처리
            switch (int.Parse(Request["md"]))
            {
                case 0:
                    //새글입력
                    no = myhelper.AddPhoto(txtTitle.Text, txtComment.Text,fname , Session["userid"].ToString(), albId);
                    break;
                case 1://수정모드
                    no = int.Parse(Request["no"]);
                    myhelper.UpdatePhoto(txtTitle.Text, txtComment.Text,fname ,no);
                    break;
            }


            if (FileUpload1.HasFile)
                fname = this.GetFilename(FileUpload1.FileName);
            else
            {
                return;
            }
            string fileExt = fname.Substring(fname.LastIndexOf(".")).ToLower();
            bool isFig = fileExt == ".jpg" || fileExt == ".gif" || fileExt == ".png" || fileExt == ".bmp";
            if (!isFig)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('지원하지않은 파일형식입니다.');", true);
                return;
            }
            string fileurl = "photos";
            //업로드 파일이름
            string ufname = Server.MapPath(@"albumphoto\" + fileurl + "_" + no.ToString() +fileExt);
        //실제로 업로드합니다.
        FileUpload1.SaveAs(ufname);
        //완료되면 이동
        Response.Redirect("~/TraviewCommunity.aspx");

        }


    }
    private string GetFilename(String path)
    {
        return path.Substring(path.LastIndexOf(@"\") + 1);
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        //이동
        Response.Redirect("~/TraviewCommunity.aspx");
    }
}