using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class Guide_show : System.Web.UI.Page
{
    //모듈변수 선언
    AlbumInfo albumInfo; //앨범정보
    GuideInfo guideInfo; //가이드북정보

    static int albId = 50, no = 0;

    static string uploadTable;

    protected void Page_Load(object sender, EventArgs e)
    {
        //제목표시줄에 부착된 앨범/사진번호를 가져옵니다.
        if (!IsPostBack)
        {
            //albId = int.Parse(Request["id"]);
            no = int.Parse(Request["no"]);
            //앨범 및 사진에 해당하는 정보를 가져옵니다.
            Dbhelper myHelper = new Dbhelper();
            //앨범정보
            //albumInfo = myHelper.GetAlbumInfo(albId);
            //사진정보
            guideInfo = myHelper.GetGuideInfo(no);
            //앨범 제목 및 사진 제목 표시
            lblTitle.Text = guideInfo.title;
            lblUser.Text = guideInfo.author;
            lblHits.Text = guideInfo.hits.ToString();
            lblDate.Text = guideInfo.uploaddate;
            lblContents.Text = guideInfo.comment;
            //pname = guideInfo.pname;
            //author = guideInfo.author;
           if (guideInfo.pname.Length > 0)
            {
                lblFname.Text = guideInfo.pname;
                lblFsize.Text = (Math.Round(float.Parse(guideInfo.fsize)/1000000,2)).ToString() + " MB";
                btnDownload.Enabled = true;
            }
            string fileurl = "photos";
            //Image 컨트롤에 사진 표시
            imgMain.ImageUrl = "~/Guidephoto/" + fileurl + "_" + no.ToString() + guideInfo.fname.Substring(guideInfo.fname.IndexOf("."));
            //테이블 이름 및 사진의 파일이름, 작성자 추출

            if (Session["userid"] != null)
            {
                if (Session["userid"].ToString() == guideInfo.author)
                {
                    btnUpdate.Visible = true;
                    btnDelete.Visible = true;
                }
            }
            myHelper.Close();
        }
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        Dbhelper myHelper = new Dbhelper();
        uploadTable = "Guidebook";
        myHelper.RemovePhoto(uploadTable, no);
        myHelper.Close();
        //업로드된 사진삭제 
        //실제 사진이 저장되는 위치 구하기

        Response.Redirect("GuideMap.aspx");

    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        if (Session["userid"].ToString() == lblUser.Text)
        {
            Response.Redirect("Guide_Upload.aspx?id=" + albId + "&md=1&no=" + no);
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {

        Response.Redirect("GuideMap.aspx");
    }


    protected void btnDownload_Click(object sender, EventArgs e)
    {
        Dbhelper myHelper = new Dbhelper();
        guideInfo = myHelper.GetGuideInfo(no);
        string fileurl = "guidebook";
        //데이터베이스에 저장된 파일이름
        string fName = fileurl + "_" + no.ToString() + guideInfo.pname.Substring(guideInfo.pname.LastIndexOf("."));
        string serverFname = Server.MapPath(@"Guidemap\" + fName);
        //실제 다운로드 실행
        myHelper.Close();
        try
        {
            Response.Clear();
            //파일이름 보내기
            Response.AddHeader("Content-Disposition" , "attachment;filename=" + guideInfo.pname);
            //다운로드 타입 지정
            Response.ContentType = "application/vnd.openxmlformats-officedocument.presentationml.presentation";
            
            //서버로부터 파일 전송
            Response.WriteFile(serverFname);
            Response.End();
        }

        catch
        {
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('다운로드 오류가 생겼습니다. ');", true);
        }

    }
}