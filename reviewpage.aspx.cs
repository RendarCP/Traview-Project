using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;

public partial class reviewpage : System.Web.UI.Page
{
    static int no;//글번호
    static BBSinfo bbsInfo;
    static ArticleInfo articleInfo;//상세정보
    static DataSet myDs;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //url에서 bbsId와 no를 뽑아옴
            int bbsId = int.Parse(Request["id"].ToString());
            no = int.Parse(Request["no"].ToString());

            Dbhelper myhelper = new Dbhelper();
            //게시판 설정
            bbsInfo = myhelper.GetBbsInfo(bbsId);

            articleInfo = myhelper.GetDetails(bbsInfo.bbsname, no, true);
            myDs = myhelper.GetBbsReplyList(no);
            myhelper.Close();
            lblUser.Text = articleInfo.author;
            lblTitle.Text = articleInfo.title;
            lblDate.Text = articleInfo.uploadtime;
            //lblContents.Text += "~/Photos/"+"_" + no.ToString() + articleInfo.filename.Substring(articleInfo.filename.IndexOf("."));
            //lblContents.Text += "<img src='Photos/" + "_" + no.ToString() + articleInfo.filename.Substring(articleInfo.filename.IndexOf(".")) +"'></img>";\
            if (articleInfo.filename != "")
            {
                Image1.ImageUrl = "~/Photos/" + "Review_" + no.ToString() + articleInfo.filename.Substring(articleInfo.filename.IndexOf("."));
            }
            lblContents.Text = articleInfo.contents.Replace("\r\n","<br>");
            lblHits.Text = articleInfo.hits.ToString();

            if(Session["userid"] != null)
            {
                if(Session["userid"].ToString() == articleInfo.author)
                {
                    btnUpdate.Visible = true;
                    btnDelete.Visible = true;
                }
            }
        }
        DisplayReply();
    }
    private void DisplayReply()
    {
        DDlreply.DataSource = myDs;
        DDlreply.DataBind();
    }


    protected void btnUpdate_Click(object sender, EventArgs e)
    {
            if (Session["userid"].ToString() == lblUser.Text)
            {
            Response.Redirect("travelreviewInput.aspx?id=" + bbsInfo.bbsId + "&md=1&no=" + no);
            }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        if(Session["userid"].ToString() == articleInfo.author)
        {
            Dbhelper myhelper = new Dbhelper();
            myhelper.RemoveArticle(bbsInfo.bbsname, no);
            if (articleInfo.filename != "")
            {
                string path = Request.PhysicalApplicationPath + "Photos\\" + "Review_" + no.ToString() + articleInfo.filename.Substring(articleInfo.filename.IndexOf("."));
            }
            btnDelete.Visible = true;
            //Dbhelper myhelper = new Dbhelper();
            //myhelper.RemoveArticle(bbsInfo.bbsname, no);
            myhelper.Close();
            Response.Redirect("reviewTippage.aspx");
        }


        //Dbhelper myhelper = new Dbhelper();
        //myhelper.RemoveArticle(bbsInfo.bbsname, no);
        //myhelper.Close();
    }

    protected void btnReply_Click(object sender, EventArgs e)
    {
        if (Session["userid"] == null)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('댓글 작성에는 로그인이 필요합니다');", true);
        }
        else if (txtReply.Text == "")
        {
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('댓글 내용은 빈칸일 수 없습니다.');", true);
        }
        else
        {
            Dbhelper myhelper = new Dbhelper();
            myhelper.InsertBbsReply(no, Session["userid"].ToString(), txtReply.Text);
            myDs = myhelper.GetBbsReplyList(no);
            myhelper.Close();
            //댓글작성후 텍스트박스 지우고 목록 보이기
            txtReply.Text = "";
            DisplayReply();
        }
    }
}