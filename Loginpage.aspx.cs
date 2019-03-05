using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Loginpage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
         //처음 방문시 실행
         if(IsPostBack)
        {
            //textbox엔터키 처리
            txtpwd.Attributes["onkeyPress"] = "if (event.keyCode==13){" +
          Page.GetPostBackEventReference(btnLogin) + "; return false;}";


            //나를 호출한 페이지 조사
            if (Request.Url != null)
            {
                //로그인 성공후 해당페이지 이동
                string caller = Request.UrlReferrer.ToString();
                if (caller.IndexOf("RegiserPage") < 0) Session["returnUrl"] = caller;
                else Session["returnUrl"] = "mainMasterpage.aspx"; 
            }
        }
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        Dbhelper myhelper = new Dbhelper();
        bool IsAuthenticated = myhelper.Authenticate(txtid.Text, txtpwd.Text);
        myhelper.Close();

        //인증여부 처리
        if(IsAuthenticated)
        {
            //인증성공 --> userid 세션에 저장
            Session["userid"] = txtid.Text;
            //호출한 페이지 이동
            Response.Redirect("mainMasterPage.aspx");

        }
        else
        {
            lblmessage.Text = "ID와 비밀번호를 확인해주세요";
        }
    }

    protected void btnRegister_Click(object sender, EventArgs e)
    {
        Response.Redirect("RegisterPage.aspx");
    }
}