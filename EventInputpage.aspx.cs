using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EventInputpage : System.Web.UI.Page
{
    static int no;//글번호
    static EventInfo eventInfo; //모듈변수
    string tablename = "Event";
    static string uploadTable = "Event";
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            //no = int.Parse(Request["no"].ToString());
            Dbhelper myhelper = new Dbhelper();
            //직접들어올경우대비
            if (Session["userid"] == null)//로그인 되지않음
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('관리자만 접속 가능한 페이지입니다.');", true);
                Response.Redirect("TraviewEvent.aspx");
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

                    //bbsInfo = myhelper.GetBbsInfo(bbsId);
                    eventInfo = myhelper.Eventdetails(int.Parse(Request["no"]));
                    //myhelper.GetDetails(tablename, int.Parse(Request["no"]), false);
                    //작성자만 수정
                    if (Session["userid"].ToString() != eventInfo.author) return;
                    //제목,글 표시
                    txtEventtitle.Text = eventInfo.title;
                    txtEventContent.Text = eventInfo.contents;
                    break;
            }
            if (Request.UrlReferrer.ToString().IndexOf("Eventpage.aspx") <= 0)
                Session["returnUrl"] = Request.UrlReferrer.ToString();
            myhelper.Close();
        }
    }
    private string GetFilename(string path)
    {
        return path.Substring(path.LastIndexOf(@"\") + 1);
    }

    protected void btnEventUpload_Click(object sender, EventArgs e)
    {
        //업로드할 파일과 관련한 처리
        string fname = "";
        int fsize = 0;
        //파일업로드로 부터 지정된 파일 확인
        if (FileUpload1.HasFile)
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
                    no = myhelper.InsertNewEvent(txtEventtitle.Text, txtEventContent.Text, Session["userid"].ToString(), fname, fsize, TxtStart.Text, TxtEnd.Text, TxtAnnouce.Text);
                    break;
                case 1://수정모드
                    no = int.Parse(Request["no"]);
                    myhelper.UpdateEvent(tablename, txtEventtitle.Text, txtEventContent.Text, fname, fsize, no);
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
            if (!isFig)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('지원하지않은 파일형식입니다.');", true);
                return;
            }


            //업로드 파일 이름
            string ufname = Server.MapPath(@"Event\" + uploadTable + "_" + no.ToString() + fileExt);
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
                    no = myhelper.InsertNewEvent(txtEventtitle.Text, txtEventContent.Text, Session["userid"].ToString(), fname, fsize, TxtStart.Text,TxtEnd.Text,TxtAnnouce.Text);
                    //no = myhelper.InsertNewReview(tablename, txtTitle.Text, txtContent.InnerText, Session["userid"].ToString(), bbsId, fname, fsize);
                    break;
                case 1://수정모드
                    no = int.Parse(Request["no"]);
                    myhelper.UpdateEvent(tablename, txtEventtitle.Text, txtEventContent.Text, fname, fsize, no);
                    break;
            }
            myhelper.Close();

            Response.Redirect(Session["returnUrl"].ToString());
        }
    }

    protected void CldStart_SelectionChanged(object sender, EventArgs e)
    {
        TxtStart.Text = Convert.ToString(CldStart.SelectedDate.Year)+ "-" + Convert.ToString(CldStart.SelectedDate.Month) + "-" + Convert.ToString(CldStart.SelectedDate.Day);
    }

    protected void CldEnd_SelectionChanged(object sender, EventArgs e)
    {
        TxtEnd.Text = Convert.ToString(CldEnd.SelectedDate.Year) + "-" + Convert.ToString(CldEnd.SelectedDate.Month) + "-" + Convert.ToString(CldEnd.SelectedDate.Day);

    }

    protected void CldAnnounce_SelectionChanged(object sender, EventArgs e)
    {
        TxtAnnouce.Text = Convert.ToString(CldAnnounce.SelectedDate.Year) + "-" + Convert.ToString(CldAnnounce.SelectedDate.Month) + "-" + Convert.ToString(CldAnnounce.SelectedDate.Day);
    }
}