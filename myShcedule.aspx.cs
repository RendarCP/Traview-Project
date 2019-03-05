using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class myShcedule : System.Web.UI.Page
{
    static int no;//글번호
    //static Shcedule shcedule;
    static ShceduleInfo shceduleInfo;
    static string tablename = "shcedule";
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            no = int.Parse(Request["no"].ToString());
            DisplayShcedule();
            //url에서 no를 뽑아옴


            Dbhelper myhelper = new Dbhelper();
            //shcedule = myhelper.Shceduledetails(no);
            shceduleInfo = myhelper.Shceduleinfodetails(no);

            lblauthor.Text = shceduleInfo.auhtor;
            lbltitle.Text = shceduleInfo.title;
            lbluploaddate.Text = shceduleInfo.uploaddate;
            lblcontents.Text = shceduleInfo.contents.Replace("\r\n", "<br>");
            myhelper.Close();

        }
    }
    private void DisplayShcedule()
    {
        //Dbhelper 객체를 생성, 사진관련 정보를 데이터셋으로 가져오고,
        //이를 GridView의 DataSource로 지정
        Dbhelper myhelper = new Dbhelper();
        DDlShcedule.DataSource = myhelper.GetShceduleList(tablename, no);
        //데이터 바인드
        DDlShcedule.DataBind();
        myhelper.Close();
    }

    protected void btndelte_Click(object sender, EventArgs e)
    {
        Dbhelper myhelper = new Dbhelper();
        //myhelper.RemoveShcedule(no);
        myhelper.RemoveShceduleInfo(no);
        myhelper.Close();
        Response.Redirect("ShceduleShow.aspx");
    }
    protected void btnlist_Click(object sender, EventArgs e)
    {
        Response.Redirect("ShceduleShow.aspx");
    }
}