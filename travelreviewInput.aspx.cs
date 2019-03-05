using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class travelreviewInput : System.Web.UI.Page
{
    //모듈변수
    static int no;//글번호
    int bbsId = 21; //리뷰 
    string tablename = "Review";
    static BBSinfo bbsInfo;
    static string uploadTable = "Review";
    static ArticleInfo articleInfo;
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            //no = int.Parse(Request["no"].ToString());
            Dbhelper myhelper = new Dbhelper();
            //직접들어올경우대비
            if (Session["userid"]==null)//로그인 되지않음
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('로그인이 필요합니다');", true);
                Response.Redirect("reviewTippage.aspx");
            }
            else //로그인되어있음
            {
                Session["returnUrl"] = Request.UrlReferrer.ToString();
            }
            switch (int.Parse(Request["md"]))
            {
                case 0://새글 
                    break;
                case 1://수정

                    bbsInfo = myhelper.GetBbsInfo(bbsId);
                    articleInfo = myhelper.GetDetails(bbsInfo.bbsname, int.Parse(Request["no"]) , false);
                    //myhelper.GetDetails(tablename, int.Parse(Request["no"]), false);
                    //작성자만 수정
                    if (Session["userid"].ToString() != articleInfo.author) return;
                    //제목,글 표시
                    txtTitle.Text = articleInfo.title;
                    txtContents.Text = articleInfo.contents;
                    break;
            }
            if (Request.UrlReferrer.ToString().IndexOf("reviewpage.aspx") <= 0)
                Session["returnUrl"] = Request.UrlReferrer.ToString();
            myhelper.Close();
        }
    }
    //경로를 제외한 파일이름 구하기
    private string GetFilename(string path)
    {
        return path.Substring(path.LastIndexOf(@"\") + 1);
    }


    protected void btnRewEn_Click(object sender, EventArgs e)
    {
        //업로드할 파일과 관련한 처리
        string fname = "";
        int fsize = 0;
        //파일업로드로 부터 지정된 파일 확인
        if(txtTitle.Text == "" || txtContents.Text == "")
        {
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('제목과 내용입력은 필수입니다.');", true);
        }
        else if(FileUpload1.HasFile)
        {
            fname = this.GetFilename(FileUpload1.FileName);//경로제외
            fsize = (int)FileUpload1.FileContent.Length;//파일크기

            Dbhelper myhelper = new Dbhelper();
            ////새글 입력
            //no = myhelper.InsertNewReview(tablename, txtTitle.Text, txtContents.Text, Session["userid"].ToString(), bbsId, fname, fsize);
            //myhelper.Close();

            //입력모드에 따른 처리
            switch (int.Parse(Request["md"]))
            {
                case 0:
                    //새글입력
                    no = myhelper.InsertNewReview(tablename, txtTitle.Text, txtContents.Text, Session["userid"].ToString(), bbsId, fname, fsize,ddlCity.SelectedValue);
                    break;
                case 1://수정모드
                    no = int.Parse(Request["no"]);
                    myhelper.UpdateReview("BBS", txtTitle.Text, txtContents.Text.ToString().Replace("'","`"), fname, fsize, no, ddlCity.SelectedValue);
                    break;
            }
            myhelper.Close();

            if (FileUpload1.HasFile)
                fname = this.GetFilename(FileUpload1.FileName);
            else
            {
                return;
            }
            //그림파일만 업로드 가능
            string fileExt = fname.Substring(fname.LastIndexOf(".")).ToLower();
            bool isFig = fileExt == ".jpg" || fileExt == ".gif" || fileExt == ".png" || fileExt == ".bmp";
            if(!isFig)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('지원하지않은 파일형식입니다.');", true);
                return;
            }


            //업로드 파일 이름
            string ufname = Server.MapPath(@"Photos\" + uploadTable + "_" + no.ToString() + fileExt);
            //업로드
            FileUpload1.SaveAs(ufname);
            //작업완료시 목록으로
            Response.Redirect(Session["returnUrl"].ToString());
        }
        else
        {
            Dbhelper myhelper = new Dbhelper();
            //no = myhelper.InsertNewReview(tablename, txtTitle.Text, txtContents.Text, Session["userid"].ToString(), bbsId, "", 0);
            //입력모드에 따른 처리
            switch (int.Parse(Request["md"]))
            {
                case 0:
                    //새글입력
                    no = myhelper.InsertNewReview(tablename, txtTitle.Text, txtContents.Text, Session["userid"].ToString(), bbsId, fname, fsize,ddlCity.SelectedValue);
                    //no = myhelper.InsertNewReview(tablename, txtTitle.Text, txtContent.InnerText, Session["userid"].ToString(), bbsId, fname, fsize);
                    break;
                case 1://수정모드
                    no = int.Parse(Request["no"]);
                    myhelper.UpdateReview("BBS", txtTitle.Text, txtContents.Text.ToString().Replace("'", "`"), fname, fsize, no, ddlCity.SelectedValue);
                    break;
            }
            myhelper.Close();

            Response.Redirect(Session["returnUrl"].ToString());
        }
    }
}