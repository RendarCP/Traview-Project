using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class shcedulepage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void BtnShcedule_Click(object sender, EventArgs e)
    {
        if (Session["userid"] == null)
        {
            //로그인이 필요하다는 경고창 발생 
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('로그인이 필요합니다');", true);
        }
        else
        {
            //로그인된 사용자만 접속가능하게 설정 
            Response.Redirect("travelinput.aspx?shcedule&md=0");
        }
    }

    protected void BtnMyshcedule_Click(object sender, EventArgs e)
    {
        if (Session["userid"] == null)
        {
            //로그인이 필요하다는 경고창 발생 
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('로그인이 필요합니다');", true);
        }
        else
        {
            //로그인된 사용자만 접속가능하게 설정 
            Response.Redirect("ShceduleShow.aspx");
        }
    }
}