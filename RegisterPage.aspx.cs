using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class RegisterPage : System.Web.UI.Page
{
    //모듈변수 선언 -->클래스 전체 사용가능
    //ID중복검사 여부 --> 중복검사안하면 회원가입 x

    static bool isIdDuChecked = false;
    //Dbhelper 클래스 객체
    Dbhelper myhelper;
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnIDcheck_Click(object sender, EventArgs e)
    {
        myhelper = new Dbhelper();
        //사용자 id받아서 중복확인
        string id = txtId.Text;

        //id값이 입력되있지 않으면 실행 x 

        //중복검사 결과

        if(txtId.Text=="")
        {
            lblIDCheckmessage.Text = "ID는  필수 입력값입니다.";
        }
       else if (isIdDuChecked = myhelper.VerifyUserID(id))
        {
            //중복검사 통과 ->포커스 이메일
            lblIDCheckmessage.Text = "ID를 사용할 수 있습니다";
            this.txtEmailID.Focus();
        }
        else
        {
            //중복검사 실패
            lblIDCheckmessage.Text = "ID가 중복입니다.";
            this.txtId.Text = "";
            this.txtId.Focus();
        }
        myhelper.Close();
    }

    protected void btnRegister_Click(object sender, EventArgs e)
    {
        //ID 중복체크 확인
        if (!isIdDuChecked)
        {
            lblIDCheckmessage.Text = "ID 중복검사를 먼저해주세요";
            return;
        }
        else if (txtnickname.Text == "관리자" || txtnickname.Text == "master")
        {
            lblresultmessage.Text = "이 닉네임은 사용할 수 없는 닉네임입니다.";
            txtnickname.Text = "";
            txtnickname.Focus();
        }
        //DB연결
        myhelper = new Dbhelper();
        int result = myhelper.RegisterUser(txtId.Text, txtPw.Text, txtname.Text, txtnickname.Text, txtEmailID.Text + "@" + txtEmail.Text);
        //Db닫기
        myhelper.Close();
        if (result == 1) Response.Redirect("mainMasterpage.aspx");
        else lblresultmessage.Text = "회원가입에 실패했습니다.";
    }

    protected void DdlEmail_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtEmail.Text = DdlEmail.SelectedValue.ToString();
        if(DdlEmail.SelectedValue.ToString() == "직접입력")
        {
            txtEmail.ReadOnly = false;
            txtEmail.Focus();
        }
    }
}