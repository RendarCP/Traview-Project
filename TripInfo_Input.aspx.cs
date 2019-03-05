using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class TripInfo_Input : System.Web.UI.Page
{
    static int no;//글번호
    static string name;
    static TripInfo tripInfo;
    static string uploadTable = "Info";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Dbhelper myhelper = new Dbhelper();
            //직접들어올경우대비
            if (Session["userid"] == null)//로그인 되지않음
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('관리자만 접속가능합니다.');", true);
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
            }
            if (Request.UrlReferrer.ToString().IndexOf("Info_master.aspx") <= 0)
                Session["returnUrl"] = Request.UrlReferrer.ToString();
            myhelper.Close();
        }
    }
    private string GetFilename(string path)
    {
        return path.Substring(path.LastIndexOf(@"\") + 1);
    }


    protected void btnInfoinput_Click(object sender, EventArgs e)
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
                    no = myhelper.newInfoinsert(txtCountry.Text, ddlSeason1.SelectedValue + "~" + ddlSeason2.SelectedValue, ddlElect.SelectedValue,"("+txtFlyingtype.Text+")"+ddltime1.SelectedValue + "시간" + ddltime2.SelectedValue + "분", ddlVisa.SelectedValue+"일", txtplace.Text, txtexprience.Text, txtfood.Text, fname, fsize, txtfestival.Text);
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

            name = txtCountry.Text;
            //업로드 파일 이름
            string ufname = Server.MapPath(@"InfoPhotos\" + uploadTable+"_"+name + "_" + no.ToString() + fileExt);
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
                    no = myhelper.newInfoinsert(txtCountry.Text, ddlSeason1.SelectedValue + "~" + ddlSeason2.SelectedValue, ddlElect.SelectedValue,"("+txtFlyingtype.Text+")"+ddltime1.SelectedValue + "시간" + ddltime2.SelectedValue + "분", ddlVisa.SelectedValue+"일", txtplace.Text, txtexprience.Text, txtfood.Text, fname, fsize, txtfestival.Text);
                    break;
            }
            myhelper.Close();

            Response.Redirect(Session["returnUrl"].ToString());
        }
    }
}