using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Info_master : System.Web.UI.Page
{
    static int admin = 0;// 관리자 등급
    static int ugrade = 0;//사용자 등급
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //관리자 등급 구해오고 관리자만 작성가능
            string stadmin = "관리자";
            Dbhelper myhelper = new Dbhelper();
            admin = myhelper.GetIntGrade(stadmin);
            //사용자 등급 구함
            if (Session["userid"] != null)
            {
                ugrade = myhelper.GetUserGrade(Session["userid"].ToString());
                //관리자면 쓰기 버튼 활성화
                if (ugrade == admin) btnInputinfo.Visible = true;
            }
        }
    }

    protected void btnInputinfo_Click(object sender, EventArgs e)
    {
        Response.Redirect("TripInfo_Input.aspx?md=0");
    }
}