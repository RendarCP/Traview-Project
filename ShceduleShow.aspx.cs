using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class ShceduleShow : System.Web.UI.Page
{
    static ShceduleInfo shceduleInfo; //게시판 정보
    static DataSet DShelper;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //제목 표시줄에 부착된 게시판 번호 가져옴
            //id = int.Parse(Request["id"]);
            Dbhelper myhelper = new Dbhelper();
            if (Session["userid"] != null)
            {

            }
            DShelper = myhelper.GetShceduleinfoList(Session["userid"].ToString());
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
        grvScdule.DataSource = DShelper;
        grvScdule.PageIndex = (Session["bbspage"] == null) ? 0 : (int)Session["bbspage"];
        grvScdule.DataBind();
        //myhelper.Close();
    }

    public string GetShowUrl(object no)
    {
        //회원이든 아니든 들어갈수있게 
        if (Session["userid"] == null)
        {
            return "myShcedule.aspx?detail" + "&no=" + no.ToString();
        }
        else
        {
            return "myShcedule.aspx?detail" + "&no=" + no.ToString();
        }
    }
}