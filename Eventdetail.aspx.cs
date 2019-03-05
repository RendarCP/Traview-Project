using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Eventdetail : System.Web.UI.Page
{
    static int no;//글번호
    static DataSet myDs;
    static EventInfo eventInfo;
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            no = int.Parse(Request["no"].ToString());

            Dbhelper myhelper = new Dbhelper();

            eventInfo = myhelper.Eventdetails(no);
            myDs = myhelper.GetEventReplyList(no);
            myhelper.Close();
            DateTime startdate = DateTime.Parse(eventInfo.startEvent);
            DateTime enddate = DateTime.Parse(eventInfo.endEvent);
            DateTime announcedate = DateTime.Parse(eventInfo.AnnounceEvent);
            lblTitle.Text = eventInfo.title;
            lblUser.Text = eventInfo.author;
            //lblstart.Text = eventInfo.startEvent;
            //lblend.Text = eventInfo.endEvent;
            lblstart.Text = string.Format("{0:yy-MM-dd}", startdate);
            lblend.Text = string.Format("{0:yy-MM-dd}", enddate);
            lblannounce.Text = string.Format("{0:yy-MM-dd}", announcedate);
            //lblannounce.Text = eventInfo.AnnounceEvent;
            lblContents.Text = eventInfo.contents.Replace("\r\n", "<br>");
            if (eventInfo.filename != "")
            {
                imgEvnet.ImageUrl = "~/Event/" + "Event_" + no.ToString() + eventInfo.filename.Substring(eventInfo.filename.IndexOf("."));
            }

            if (Session["userid"] != null)
            {
                if (Session["userid"].ToString() == eventInfo.author)
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
            Response.Redirect("EventInputpage.aspx?md=1&no=" + no);
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        if (Session["userid"].ToString() == eventInfo.author)
        {
            Dbhelper myhelper = new Dbhelper();
            myhelper.RemoveEvent(no);
            if (eventInfo.filename != "")
            {
                string path = Request.PhysicalApplicationPath + "Event\\" + "Event_" + no.ToString() + eventInfo.filename.Substring(eventInfo.filename.IndexOf("."));
            }
            btnDelete.Visible = true;
            //Dbhelper myhelper = new Dbhelper();
            //myhelper.RemoveArticle(bbsInfo.bbsname, no);
            myhelper.Close();
            Response.Redirect("TraviewEvent.aspx");
        }
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
            myhelper.InsertBbsReply(no, Session["userid"].ToString(), txtReply.Text);
            myDs = myhelper.GetBbsReplyList(no);
            myhelper.Close();
            //댓글작성후 텍스트박스 지우고 목록 보이기
            txtReply.Text = "";
            DisplayReply();
        }
    }
}