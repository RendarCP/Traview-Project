using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class QnAinput : System.Web.UI.Page
{
    //모듈변수
    static int no;//글번호
    int bbsId = 22; //QnA 
    string tablename = "QnA";
    static BBSinfo bbsInfo;
    static string uploadTable = "";
    static ArticleInfo articleInfo;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //no = int.Parse(Request["no"].ToString());
            Dbhelper myhelper = new Dbhelper();
            //직접들어올경우대비
            if (Session["userid"] == null)//로그인 되지않음
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('로그인이 필요합니다');", true);
                Response.Redirect("TraviewQnA.aspx");
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
                    articleInfo = myhelper.GetDetailsQnA("BBS", int.Parse(Request["no"]), false);
                    //myhelper.GetDetails(tablename, int.Parse(Request["no"]), false);
                    //작성자만 수정
                    if (Session["userid"].ToString() != articleInfo.author) return;
                    //제목,글 표시
                    txtTitle.Text = articleInfo.title;
                    txtContents.Text = articleInfo.contents;
                    DDlkategorie.SelectedValue = articleInfo.Kategorie;
                    break;
            }
            if (Request.UrlReferrer.ToString().IndexOf("QnApage.aspx") <= 0)
                Session["returnUrl"] = Request.UrlReferrer.ToString();
            myhelper.Close();
        }
    }

    protected void btnQnAEn_Click(object sender, EventArgs e)
    {
        Dbhelper myhelper = new Dbhelper();
        //no = myhelper.InsertNewReview(tablename, txtTitle.Text, txtContents.Text, Session["userid"].ToString(), bbsId, "", 0);
        //입력모드에 따른 처리
        if(txtTitle.Text == "" || txtContents.Text == "")
        {
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('제목과 내용은 빈칸일수없습니다.');", true);
        }
        else
        {
          switch (int.Parse(Request["md"]))
          {
              case 0:
                  //새글입력
                  no = myhelper.InsertNewQnA(tablename, txtTitle.Text, txtContents.Text, Session["userid"].ToString(), bbsId,DDlkategorie.SelectedValue.ToString(),ddlCityQnA.SelectedValue.ToString());
                  break;
              case 1://수정모드
                  no = int.Parse(Request["no"]);
                  myhelper.UpdateQnA("BBS", txtTitle.Text, txtContents.Text.ToString().Replace("'","`"), no,DDlkategorie.SelectedValue);
                  break;
          }
          Response.Redirect(Session["returnUrl"].ToString());
        }

        myhelper.Close();

    }
}