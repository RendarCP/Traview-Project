using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class reviewTippage : System.Web.UI.Page
{
    static int id = 21; // 게시판번호
    static BBSinfo bbsInfo; //게시판 정보
    static DataSet DShelper;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //제목 표시줄에 부착된 게시판 번호 가져옴
            //id = int.Parse(Request["id"]);
            Dbhelper myhelper = new Dbhelper();
            bbsInfo = myhelper.GetBbsInfo(id);
            if (Session["userid"] !=null)
            {

            }
            DShelper = myhelper.GetbbsList(bbsInfo.bbsname, id, null, null);
            DisplayList();
            myhelper.Close();
        }
    }
    //게시판 목록 보이기
    private void DisplayList()
    {
        //Dbhelper myhelper = new Dbhelper();
        //데이터셋 형식으로 정보가져와서 그리드뷰에 지정
        //grvBbs.DataSource = myhelper.GetBbsList();
        //페이지번호에 따른 이동
        grvBbs.DataSource = DShelper;
        grvBbs.PageIndex = (Session["bbspage"] == null) ? 0 : (int)Session["bbspage"];
        grvBbs.DataBind();
        //myhelper.Close();
    }
    protected void grvBbs_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        //새로운 페이지번호 현재 페에지에 번호에 저장
        Session["bbspage"] = e.NewPageIndex;
        DisplayList();
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string ktype;
        if (DDlsearch.Text == "닉네임") ktype = "nickname";
        else if (DDlsearch.Text == "내용") ktype = "contents";
        else ktype = "title";

        Dbhelper myhelper = new Dbhelper();
        if(txtSearch.Text.Length==0)
        {
            DShelper = myhelper.GetbbsList(bbsInfo.bbsname, id, null, null);
        }
        else
        {
            DShelper = myhelper.GetbbsList(bbsInfo.bbsname, id, ktype, txtSearch.Text);
        }
        DisplayList();
        myhelper.Close();
    }
    //제목을 클릭하면 이동할 url 제공
    public string GetShowUrl(object no)
    {
        //회원이든 아니든 들어갈수있게 
        if(Session["userid"]==null)
        {
            return "reviewpage.aspx?id=" + id + "&no=" + no.ToString(); 
        }
        else
        {
            return "reviewpage.aspx?id=" + id + "&no=" + no.ToString();
        }
    }

    protected void BtnWrite(object sender, EventArgs e)
    {
        if(Session["userid"]==null)
        {
            //로그인이 필요하다는 경고창 발생 
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('로그인이 필요합니다');",true);
        }
        else
        {
            //로그인된 사용자만 접속가능하게 설정 
            Response.Redirect("travelreviewInput.aspx?id="+id+"&md=0");
        }
    }
}