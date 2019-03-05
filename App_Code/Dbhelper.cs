using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Web.Security;

/// <summary>
/// Dbhelper의 요약 설명입니다.
/// </summary>
public class Dbhelper
{
    //SQL 서버 
    string Dbsrc = "Server=server-name; uid=user-name; pwd=user-password; database=database-name";
    SqlConnection Conn;

    //DB 열기
    public Dbhelper()
    {
        Conn = new SqlConnection(Dbsrc);
        Conn.Open();
    }
    //DB닫기
    public void Close()
    {
        Conn.Close();
    }

    //결과값이 없는 쿼리문 --> insert,update,delete
    public void ExecuteNonQuery(string sQuery)
    {
        SqlCommand sCmd = new SqlCommand(sQuery, Conn);
        sCmd.ExecuteNonQuery();
    }
    //SQLdataReader 객체 반환 쿼리문 실행 --> SELECT
    public SqlDataReader ExecuteReader(string sQuery)
    {
        SqlCommand sCmd = new SqlCommand(sQuery, Conn);
        return sCmd.ExecuteReader();
    }
    //DataSET 객체 반환 쿼리문 실행 -->SELECT
    public DataSet AdapterFill(string sQuery, string tablename)
    {
        SqlDataAdapter sAdpt = new SqlDataAdapter(sQuery, Conn);
        //table이름을 붙임
        DataSet Ds = new DataSet(tablename);
        sAdpt.Fill(Ds, tablename);
        return Ds;
    }

    //로그인 및 회원가입 메서드
    //-----------------------------------------------
    //+++++++++++++++++++++++++++++++++++++++++++++++++
    public bool Authenticate(string id, string pwd)
    {
        bool isAuthen = false; //초기 리턴값 항상 false -->미인증
        string sQuery = "SELECT passwd, status FROM members WHERE userid= '" + id + "'";
        SqlDataReader sReader = this.ExecuteReader(sQuery);

        //사용자 존재여부
        if (sReader.Read())
        {
            //탈퇴여부확인 -->탈퇴시 무조건 false 
            if (bool.Parse(sReader["status"].ToString())) return false;
            //비밀번호 암호화
            string pwdSHA1 = FormsAuthentication.HashPasswordForStoringInConfigFile(pwd, "SHA1");
            //암호 일치 여부
            if (pwdSHA1 == sReader["passwd"].ToString().TrimEnd())
                isAuthen = true; // 암호 일치


        }
        sReader.Close();
        return isAuthen;
    }

    //userid를 이용 members테이블의 닉네임가져옴
    public string GetNickname(string uid)
    {
        string nickname = null; //초기화
        //쿼리문이용 닉네임 가져옴
        string sQuery = "SELECT nickname FROM members WHERE userid = '" + uid + "'";
        SqlDataReader myReader = this.ExecuteReader(sQuery);
        //userid 존재여부 확인
        if (myReader.Read())
        {
            nickname = myReader["nickname"].ToString().TrimEnd();
        }
        return nickname;//결과 리턴

    }
    //중복검사
    public bool VerifyUserID(string id)
    {
        //결과 반환용
        bool result = true;
        //쿼리문 지정
        string sQuery = "SELECT * FROM members WHERE userid = '" + id + "'";
        //결과
        SqlDataReader myReader = this.ExecuteReader(sQuery);
        if (myReader.Read()) result = false; // 해당아이디 존재
        myReader.Close();
        return result;
    }

    //회원가입 (저장프로시저 이용)
    //--------------------------------------------------------
    //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++

    public int RegisterUser(string uid, string passwd, string name, string nickname, string email)
    {
        //sqlcommand 객체의 형식이 저장프로시저임을 지정
        SqlCommand myCmd = new SqlCommand("procAddMember", Conn);
        myCmd.CommandType = CommandType.StoredProcedure;
        //저장프로시저 실행에 필요한 인수 지정
        SqlParameter param; //객체 생성
        //uid
        param = new SqlParameter("@userid", SqlDbType.Char, 15);
        param.Value = uid;
        myCmd.Parameters.Add(param);
        //passwd --> SHA1 암호
        param = new SqlParameter("@passwd", SqlDbType.Char, 40);
        param.Value = FormsAuthentication.HashPasswordForStoringInConfigFile(passwd, "SHA1");
        //param.Value = passwd;
        myCmd.Parameters.Add(param);
        //name
        param = new SqlParameter("@name", SqlDbType.NChar, 10);
        param.Value = name;
        myCmd.Parameters.Add(param);
        //nickname
        param = new SqlParameter("@nickname", SqlDbType.NChar, 10);
        param.Value = nickname;
        myCmd.Parameters.Add(param);
        //email
        param = new SqlParameter("@email", SqlDbType.Char, 20);
        param.Value = email;
        myCmd.Parameters.Add(param);

        //result --> 회원가입 성공여부 out변수
        SqlParameter paramOut = new SqlParameter("@result", SqlDbType.Int);
        paramOut.Direction = ParameterDirection.Output;
        myCmd.Parameters.Add(paramOut);
        //명령문 실행
        myCmd.ExecuteNonQuery();
        int result = (int)paramOut.Value;
        //결과 반환 0 -> 회원가입 실패 -> 성공
        return result;

    }
    //------------------------------------------
    //게시판(리뷰,자료실,팁) 관련 메서드
    //------------------------------------------
    public DataSet GetBbsList()
    {
        string qrySelect = "SELECT * FROM viewBbs ORDER BY uploadTime DESC";
        return this.AdapterFill(qrySelect, "BBS");
    }

    //게시판(검색기능) 메서드
    public DataSet GetbbsList(string tablename, int id, string ktype, string kword)
    {
        string qrySelect = "SELECT * FROM viewBbs" + " WHERE bbsId=" + id;
        //검색기능
        if (ktype != null)
            qrySelect += " AND " + ktype + " LIKE '%" + kword + "%'";
        //정렬기능
        qrySelect += " ORDER BY no DESC";
        return this.AdapterFill(qrySelect, "BBS");
    }

    //여행정보관련 메서드
    public DataSet GetInfoList(string tablename, int id, string kword)
    {
        string qrySelect = "SELECT * FROM viewBBS" + " WHERE bbsId=" + id;
        qrySelect += " AND contents LIKE '%" + kword + "%' AND title LIKE'%" + kword + "%'";
        //qrySelect += " AND city = '" + kword + "'";
        //정렬기능
        qrySelect += " ORDER BY no DESC";
        return this.AdapterFill(qrySelect, "BBS");
    }
    public DataSet cityInfoList(string tablename, int id, string kword)
    {
        string qrySelect = "SELECT * FROM viewBBS" + " WHERE bbsId=" + id;
        //qrySelect += " AND contents LIKE '%" + kword + "%' AND title LIKE'%" + kword + "%'";
        qrySelect += " AND city = '" + kword + "'";
        //정렬기능
        qrySelect += " ORDER BY no DESC";
        return this.AdapterFill(qrySelect, "BBS");
    }
    public int GetUserGrade(string id)
    {
        //리턴값
        int ugrade = 0;
        string qrySelect = "SELECT ugrade FROM members WHERE userid = '" + id + "'";
        SqlDataReader myReader = this.ExecuteReader(qrySelect);
        //사용자 id 존재여부 확인 및 존재할시 등급확인
        if (myReader.Read())
        {
            ugrade = int.Parse(myReader["ugrade"].ToString().TrimEnd());
        }
        //결과 리턴
        myReader.Close();
        return ugrade;
    }

    //게시판 정보 가져오기
    //게시판정보 클래스 객체 생성 가져감
    public BBSinfo GetBbsInfo(int id)
    {
        string qrySelect = "SELECT * FROM BBSinfo WHERE bbsId=" + id;
        BBSinfo bbsInfo = new BBSinfo();
        SqlDataReader sReader = this.ExecuteReader(qrySelect);

        //데이터
        if (sReader.Read())
        {
            bbsInfo.bbsId = sReader["bbsId"].ToString().TrimEnd();
            //bbsInfo.bbsname = sReader["bbsName"].ToString().TrimEnd();
            bbsInfo.writeAuth = int.Parse(sReader["writeAuth"].ToString().TrimEnd());
            bbsInfo.reply = bool.Parse(sReader["reply"].ToString().TrimEnd());
        }
        sReader.Close();
        //리턴
        return bbsInfo;
    }

    //리뷰게시판 입력용 
    public int InsertNewReview(string tablename, string title, string contents, string author, int bbsId, string filename, int filesize, string cityname)
    {
        //-------저장프로시저 이용해서 넣음----
        string myProc = "procInsert" + tablename;//프로시저 이름결정

        SqlCommand myCmd = new SqlCommand(myProc, Conn);
        myCmd.CommandType = CommandType.StoredProcedure;
        //입력 파라미터
        SqlParameter sParam;
        //title
        sParam = new SqlParameter("@title", SqlDbType.NChar, 20);
        sParam.Value = title;
        myCmd.Parameters.Add(sParam);
        //contents
        sParam = new SqlParameter("@contents", SqlDbType.NVarChar, 500);
        sParam.Value = contents;
        myCmd.Parameters.Add(sParam);
        //author
        sParam = new SqlParameter("@author", SqlDbType.Char, 15);
        sParam.Value = author;
        myCmd.Parameters.Add(sParam);
        //bbsId
        sParam = new SqlParameter("@bbsId", SqlDbType.Int);
        sParam.Value = bbsId;
        myCmd.Parameters.Add(sParam);
        //filename
        sParam = new SqlParameter("@filename", SqlDbType.NVarChar, 100);
        sParam.Value = filename;
        myCmd.Parameters.Add(sParam);
        //filesize
        sParam = new SqlParameter("@filesize", SqlDbType.Int);
        sParam.Value = filesize;
        myCmd.Parameters.Add(sParam);
        //city
        sParam = new SqlParameter("@city", SqlDbType.NChar, 20);
        sParam.Value = cityname;
        myCmd.Parameters.Add(sParam);

        //no 출력을 위한 파라미터
        SqlParameter myParamOut = new SqlParameter("@no", SqlDbType.Int);
        myParamOut.Direction = ParameterDirection.Output;
        myCmd.Parameters.Add(myParamOut);
        //명령문 실행
        myCmd.ExecuteNonQuery();
        //글번호 찾기
        int no = (int)myParamOut.Value;

        //글번호 반환
        return no;
    }
    //저장된 리뷰 수정
    public void UpdateReview(string tablename, string title, string contetns, string filename, int filesize, int no,string kategorie)
    {
        //수정 쿼리 
        string qryUpdate = "UPDATE " + tablename + " SET title='" + title + "',contents='" + contetns + "', city = '" + kategorie +"'";
        if (filename != null && filename != "")
            qryUpdate += ",filename='" + filename + "',filesize=" + filesize;
        qryUpdate += " WHERE no=" + no;
        //데이터베이스 쿼리문 실행
        this.ExecuteNonQuery(qryUpdate);//업데이트 실행
    }
    //QnA게시판용
    public int InsertNewQnA(string tablename, string title, string contents, string author, int bbsId, string Kategorie, string cityname)
    {
        //-------저장프로시저 이용해서 넣음----
        string myProc = "procInsert" + tablename;//프로시저 이름결정

        SqlCommand myCmd = new SqlCommand(myProc, Conn);
        myCmd.CommandType = CommandType.StoredProcedure;
        //입력 파라미터
        SqlParameter sParam;
        //title
        sParam = new SqlParameter("@title", SqlDbType.NChar, 20);
        sParam.Value = title;
        myCmd.Parameters.Add(sParam);
        //contents
        sParam = new SqlParameter("@contents", SqlDbType.NVarChar, 500);
        sParam.Value = contents;
        myCmd.Parameters.Add(sParam);
        //author
        sParam = new SqlParameter("@author", SqlDbType.Char, 15);
        sParam.Value = author;
        myCmd.Parameters.Add(sParam);
        //bbsId
        sParam = new SqlParameter("@bbsId", SqlDbType.Int);
        sParam.Value = bbsId;
        myCmd.Parameters.Add(sParam);
        //Kategorie
        sParam = new SqlParameter("@kategorie", SqlDbType.Char, 10);
        sParam.Value = Kategorie;
        myCmd.Parameters.Add(sParam);
        //city
        sParam = new SqlParameter("@city", SqlDbType.NChar, 20);
        sParam.Value = cityname;
        myCmd.Parameters.Add(sParam);

        //no 출력을 위한 파라미터
        SqlParameter myParamOut = new SqlParameter("@no", SqlDbType.Int);
        myParamOut.Direction = ParameterDirection.Output;
        myCmd.Parameters.Add(myParamOut);
        //명령문 실행
        myCmd.ExecuteNonQuery();
        //글번호 찾기
        int no = (int)myParamOut.Value;

        //글번호 반환
        return no;
    }
    //저장된 리뷰 수정
    public void UpdateQnA(string tablename, string title, string contetns, int no,string Kategorie)
    {
        //수정 쿼리 
        string qryUpdate = "UPDATE " + tablename + " SET title='" + title + "',contents='" + contetns + "', city = '" + Kategorie + "'";
        qryUpdate += " WHERE no=" + no;
        //데이터베이스 쿼리문 실행
        this.ExecuteNonQuery(qryUpdate);//업데이트 실행
    }

    //게시판 테이블에서 상세정보 가져오기
    public ArticleInfo GetDetails(string tablename, int no, bool showpage)
    {
        //조회수 증가
        string qryUpdate = "UPDATE BBS SET hits=hits+1 " + "WHERE no =" + no;

        if (showpage) this.ExecuteNonQuery(qryUpdate);
        string qrySelect = "SELECT * FROM viewBbs WHERE no=" + no;

        ArticleInfo articleInfo = new ArticleInfo();
        SqlDataReader sReader = this.ExecuteReader(qrySelect);
        //데이터 매핑
        if (sReader.Read())
        {
            articleInfo.title = sReader["title"].ToString().TrimEnd();
            articleInfo.contents = sReader["contents"].ToString().TrimEnd();
            articleInfo.filename = sReader["filename"].ToString().TrimEnd();
            articleInfo.filesize = int.Parse(sReader["filesize"].ToString().TrimEnd());
            articleInfo.hits = int.Parse(sReader["hits"].ToString().TrimEnd());
            articleInfo.author = sReader["author"].ToString().TrimEnd();
            articleInfo.no = int.Parse(sReader["no"].ToString().TrimEnd());
            articleInfo.uploadtime = sReader["uploadtime"].ToString().TrimEnd();
            articleInfo.bbsId = int.Parse(sReader["bbsId"].ToString().TrimEnd());
        }
        sReader.Close();
        return articleInfo;
    }
    //QnA게시판 상세정보가져오기
    public ArticleInfo GetDetailsQnA(string tablename, int no, bool showpage)
    {
        //조회수 증가
        string qryUpdate = "UPDATE BBS SET hits=hits+1 " + "WHERE no =" + no;

        if (showpage) this.ExecuteNonQuery(qryUpdate);
        string qrySelect = "SELECT * FROM BBS WHERE no=" + no;

        ArticleInfo articleInfo = new ArticleInfo();
        SqlDataReader sReader = this.ExecuteReader(qrySelect);
        //데이터 매핑
        if (sReader.Read())
        {
            articleInfo.title = sReader["title"].ToString().TrimEnd();
            articleInfo.contents = sReader["contents"].ToString().TrimEnd();
            //articleInfo.filename = sReader["filename"].ToString().TrimEnd();
            // articleInfo.filesize = int.Parse(sReader["filesize"].ToString().TrimEnd());
            articleInfo.hits = int.Parse(sReader["hits"].ToString().TrimEnd());
            articleInfo.author = sReader["author"].ToString().TrimEnd();
            articleInfo.no = int.Parse(sReader["no"].ToString().TrimEnd());
            articleInfo.uploadtime = sReader["uploadtime"].ToString().TrimEnd();
            articleInfo.bbsId = int.Parse(sReader["bbsId"].ToString().TrimEnd());
            articleInfo.Kategorie = sReader["Kategorie"].ToString().TrimEnd();
        }
        sReader.Close();
        return articleInfo;
    }
    //게시판 목록 삭제
    public void RemoveArticle(string tablename, int no)
    {
        //댓글 삭제후 내용삭제
        string qryDelete = "DELETE bbsreply WHERE bbsno= " + no;
        this.ExecuteNonQuery(qryDelete);
        //삭제
       qryDelete
            = "DELETE BBS WHERE no = " + no.ToString();
        //실행
        this.ExecuteNonQuery(qryDelete);
    }
    //게시판 댓글 목록 구하기 
    //-----
    public DataSet GetBbsReplyList(int bno)
    {
        string qrySelect
            = "SELECT br.author ,br.contents,br.uploadtime,me.nickname FROM bbsreply as br JOIN members AS me ON br.author = me.userid WHERE bbsno = " + bno + " ORDER BY br.uploadtime ASC";
        return this.AdapterFill(qrySelect, "bbsreply");
    }
    //댓글 입력처리 
    public void InsertBbsReply(int bno, string author, string contents)
    {
        string qryInsert = "INSERT INTO bbsreply (bbsno,author,contents,uploadtime) VALUES (" + bno + ",'" + author + "','" + contents + "', GETDATE())";
        this.ExecuteNonQuery(qryInsert);
    }

    // 이벤트 전용 게시판 
    ///--------
    ///---------
    //회원 등급번호 가져오기
    public int GetIntGrade(string mgrade)
    {
        int result = 0;

        string qrySelect = "SELECT ugrade FROM usergrade WHERE gradename='" + mgrade + "'";
        SqlDataReader myReader = this.ExecuteReader(qrySelect);
        //값추출
        if (myReader.Read())
        {
            result = int.Parse(myReader["ugrade"].ToString().TrimEnd());
        }
        myReader.Close();
        return result;
    }
    //이벤트 정보 삽입
    //-----------
    public int InsertNewEvent(string title, string contents, string author, string filename, int filesize, string startEvent, string endEvent, string AnnounceEvent)
    {
        //-------저장프로시저 이용해서 넣음----
        string myProc = "InsertEvent";//프로시저 이름결정

        SqlCommand myCmd = new SqlCommand(myProc, Conn);
        myCmd.CommandType = CommandType.StoredProcedure;
        //입력 파라미터
        SqlParameter sParam;
        //title
        sParam = new SqlParameter("@title", SqlDbType.NChar, 20);
        sParam.Value = title;
        myCmd.Parameters.Add(sParam);
        //contents
        sParam = new SqlParameter("@contents", SqlDbType.NVarChar, 50);
        sParam.Value = contents;
        myCmd.Parameters.Add(sParam);
        //author
        sParam = new SqlParameter("@author", SqlDbType.Char, 15);
        sParam.Value = author;
        myCmd.Parameters.Add(sParam);
        //filename
        sParam = new SqlParameter("@filename", SqlDbType.NVarChar, 100);
        sParam.Value = filename;
        myCmd.Parameters.Add(sParam);
        //filesize
        sParam = new SqlParameter("@filesize", SqlDbType.Int);
        sParam.Value = filesize;
        myCmd.Parameters.Add(sParam);
        //startEvent
        sParam = new SqlParameter("@startEvent", SqlDbType.Date);
        sParam.Value = startEvent;
        myCmd.Parameters.Add(sParam);
        //endEvnet
        sParam = new SqlParameter("@endEvent", SqlDbType.Date);
        sParam.Value = endEvent;
        myCmd.Parameters.Add(sParam);
        //AnnounceEvent
        sParam = new SqlParameter("@AnnounceEvent", SqlDbType.Date);
        sParam.Value = endEvent;
        myCmd.Parameters.Add(sParam);

        //no 출력을 위한 파라미터
        SqlParameter myParamOut = new SqlParameter("@no", SqlDbType.Int);
        myParamOut.Direction = ParameterDirection.Output;
        myCmd.Parameters.Add(myParamOut);
        //명령문 실행
        myCmd.ExecuteNonQuery();
        //글번호 찾기
        int no = (int)myParamOut.Value;

        //글번호 반환
        return no;
    }
    //이벤트 정보
    //----------
    //----------
    public EventInfo Eventdetails(int no)
    {
        //조회수 증가
        //string qryUpdate = "UPDATE BBS SET hits=hits+1 " + "WHERE no =" + no;

        //if (showpage) this.ExecuteNonQuery(qryUpdate);
        string qrySelect = "SELECT * FROM Event WHERE no=" + no;

        EventInfo eventInfo = new EventInfo();
        SqlDataReader sReader = this.ExecuteReader(qrySelect);
        //데이터 매핑
        if (sReader.Read())
        {
            eventInfo.title = sReader["title"].ToString().TrimEnd();
            eventInfo.contents = sReader["contents"].ToString().TrimEnd();
            eventInfo.filename = sReader["filename"].ToString().TrimEnd();
            eventInfo.filesize = int.Parse(sReader["filesize"].ToString().TrimEnd());
            eventInfo.author = sReader["author"].ToString().TrimEnd();
            eventInfo.no = int.Parse(sReader["no"].ToString().TrimEnd());
            eventInfo.startEvent = sReader["startEvent"].ToString().TrimEnd();
            eventInfo.endEvent = sReader["endEvent"].ToString().TrimEnd();
            eventInfo.AnnounceEvent = sReader["AnnounceEvent"].ToString().TrimEnd();
        }
        sReader.Close();
        return eventInfo;
    }
    public EventInfo Eventdetailsinfo(string tablename)
    {
        //조회수 증가
        //string qryUpdate = "UPDATE BBS SET hits=hits+1 " + "WHERE no =" + no;

        //if (showpage) this.ExecuteNonQuery(qryUpdate);
        string qrySelect = "SELECT * FROM " + tablename;

        EventInfo eventInfo = new EventInfo();
        SqlDataReader sReader = this.ExecuteReader(qrySelect);
        //데이터 매핑
        if (sReader.Read())
        {
            eventInfo.title = sReader["title"].ToString().TrimEnd();
            eventInfo.contents = sReader["contents"].ToString().TrimEnd();
            eventInfo.filename = sReader["filename"].ToString().TrimEnd();
            eventInfo.filesize = int.Parse(sReader["filesize"].ToString().TrimEnd());
            eventInfo.author = sReader["author"].ToString().TrimEnd();
            eventInfo.no = int.Parse(sReader["no"].ToString().TrimEnd());
            eventInfo.startEvent = sReader["startEvent"].ToString().TrimEnd();
            eventInfo.endEvent = sReader["endEvent"].ToString().TrimEnd();
            eventInfo.AnnounceEvent = sReader["AnnounceEvent"].ToString().TrimEnd();
        }
        sReader.Close();
        return eventInfo;
    }
    public DataSet GetEventList(string tablename)
    {
        string qrySelect = "SELECT * FROM "+tablename +" ORDER BY no DESC";
        return this.AdapterFill(qrySelect, "Event");
    }
    public DataSet GetEventReplyList(int bno)
    {
        string qrySelect
            = "SELECT er.author ,er.contents,er.uploadtime,me.nickname FROM EventReply as er JOIN members AS me ON er.author = me.userid WHERE eventno = " + bno + " ORDER BY er.uploadtime ASC";
        return this.AdapterFill(qrySelect, "bbsreply");
    }
    //댓글 입력처리 
    public void InsertEventReply(int bno, string author, string contents)
    {
        string qryInsert = "INSERT INTO EventReply (eventno,author,contents,uploadtime) VALUES (" + bno + ",'" + author + "','" + contents + "', GETDATE())";
        this.ExecuteNonQuery(qryInsert);
    }
    //이벤트 삭제
    public void RemoveEvent(int no)
    {
        //삭제를 위한 쿼리문 작성
        string qryDelete = "DELETE FROM Event" + " WHERE no =" + no.ToString();
        //실행
        this.ExecuteNonQuery(qryDelete);
    }
    public void UpdateEvent(string tablename, string title, string contetns, string filename, int filesize, int no)
    {
        //수정 쿼리 
        string qryUpdate = "UPDATE " + tablename + " SET title='" + title + "',contents='" + contetns + "'";
        if (filename != null && filename != "")
            qryUpdate += ",filename='" + filename + "',filesize=" + filesize;
        qryUpdate += " WHERE no=" + no;
        //데이터베이스 쿼리문 실행
        this.ExecuteNonQuery(qryUpdate);//업데이트 실행
    }
    //저장된 사진 수정
    //=============================
    //여행정보
    //-----------------
    //------------------

    public int newInfoinsert(string Countryname, string CountrySeason, string CountryElect, string CountryFlying, string Visa, string place, string experience, string food, string filename, int filesize, string festival)
    {
        //-------저장프로시저 이용해서 넣음----
        string myProc = "InsertInfo";//프로시저 이름결정

        SqlCommand myCmd = new SqlCommand(myProc, Conn);
        myCmd.CommandType = CommandType.StoredProcedure;
        //입력 파라미터
        SqlParameter sParam;

        //Countryname
        sParam = new SqlParameter("@Countryname", SqlDbType.NChar, 20);
        sParam.Value = Countryname;
        myCmd.Parameters.Add(sParam);
        //CountrySeason
        sParam = new SqlParameter("@CountrySeason", SqlDbType.NChar, 10);
        sParam.Value = CountrySeason;
        myCmd.Parameters.Add(sParam);
        //CountryElect
        sParam = new SqlParameter("@CountryElect", SqlDbType.NChar, 10);
        sParam.Value = CountryElect;
        myCmd.Parameters.Add(sParam);
        //CountryFlying
        sParam = new SqlParameter("@CountryFlying", SqlDbType.NChar, 20);
        sParam.Value = CountryFlying;
        myCmd.Parameters.Add(sParam);
        //Visa
        sParam = new SqlParameter("@Visa", SqlDbType.NChar, 20);
        sParam.Value = Visa;
        myCmd.Parameters.Add(sParam);
        //place
        sParam = new SqlParameter("@place", SqlDbType.NChar, 30);
        sParam.Value = place;
        myCmd.Parameters.Add(sParam);
        //experience
        sParam = new SqlParameter("@experience", SqlDbType.NChar, 20);
        sParam.Value = experience;
        myCmd.Parameters.Add(sParam);
        //food
        sParam = new SqlParameter("@food", SqlDbType.NChar, 20);
        sParam.Value = food;
        myCmd.Parameters.Add(sParam);
        //festival
        sParam = new SqlParameter("@festival", SqlDbType.NChar, 30);
        sParam.Value = festival;
        myCmd.Parameters.Add(sParam);
        //filename
        sParam = new SqlParameter("@filename", SqlDbType.NVarChar, 100);
        sParam.Value = filename;
        myCmd.Parameters.Add(sParam);
        //filesize
        sParam = new SqlParameter("@filesize", SqlDbType.Int);
        sParam.Value = filesize;
        myCmd.Parameters.Add(sParam);


        //no 출력을 위한 파라미터
        SqlParameter myParamOut = new SqlParameter("@no", SqlDbType.Int);
        myParamOut.Direction = ParameterDirection.Output;
        myCmd.Parameters.Add(myParamOut);
        //명령문 실행
        myCmd.ExecuteNonQuery();
        //글번호 찾기
        int no = (int)myParamOut.Value;

        //글번호 반환
        return no;
    }
    //여행정보페이지 자세히보기
    //--------
    //--------------------------
    public DataSet GetTripInfo(string Countryname)
    {
        string qrySelect = "SELECT * FROM info_table" + " WHERE Countryname='" + Countryname + "'";
        return this.AdapterFill(qrySelect, "info_talbe");
    }
    public TripInfo Tripdetails(string Country)
    {
        //조회수 증가
        //string qryUpdate = "UPDATE BBS SET hits=hits+1 " + "WHERE no =" + no;

        //if (showpage) this.ExecuteNonQuery(qryUpdate);
        string qrySelect = "SELECT * FROM info_table WHERE Countryname ='" + Country + "'";

        TripInfo tripInfo = new TripInfo();
        SqlDataReader sReader = this.ExecuteReader(qrySelect);
        //데이터 매핑
        if (sReader.Read())
        {
            tripInfo.Countryname = sReader["Countryname"].ToString().TrimEnd();
            tripInfo.CountrySeason = sReader["CountrySeason"].ToString().TrimEnd();
            tripInfo.CountryElect = sReader["CountryElect"].ToString().TrimEnd();
            tripInfo.CountryFlying = sReader["CountryFlying"].ToString().TrimEnd();
            tripInfo.Visa = sReader["Visa"].ToString().TrimEnd();
            tripInfo.no = int.Parse(sReader["no"].ToString().TrimEnd());
            tripInfo.place = sReader["place"].ToString().TrimEnd();
            tripInfo.experience = sReader["experience"].ToString().TrimEnd();
            tripInfo.food = sReader["food"].ToString().TrimEnd();
            tripInfo.filename = sReader["filename"].ToString().TrimEnd();
            tripInfo.filesize = int.Parse(sReader["filesize"].ToString().TrimEnd());
            tripInfo.festival = sReader["festival"].ToString().TrimEnd();
        }
        sReader.Close();
        return tripInfo;
    }

    //여행일정페이지 정보들
    //---------------------------------------------------
    //-----------------------------------------------------
    public int insertshcedule (string dayinfo,int sd_id, string country, string city, string sd_memo, string author,int infoId,string triptime)
    {
        //-------저장프로시저 이용해서 넣음----
        string myProc = "insertshcedule";//프로시저 이름결정

        SqlCommand myCmd = new SqlCommand(myProc, Conn);
        myCmd.CommandType = CommandType.StoredProcedure;
        //입력 파라미터
        SqlParameter sParam;
        //dayinfo
        sParam = new SqlParameter("@dayinfo", SqlDbType.NChar, 20);
        sParam.Value = dayinfo;
        myCmd.Parameters.Add(sParam);
        //country
        sParam = new SqlParameter("@country", SqlDbType.NChar, 20);
        sParam.Value = country;
        myCmd.Parameters.Add(sParam);
        //city
        sParam = new SqlParameter("@city", SqlDbType.NChar, 20);
        sParam.Value = city;
        myCmd.Parameters.Add(sParam);
        //sd_memo
        sParam = new SqlParameter("@sd_memo", SqlDbType.NVarChar, 100);
        sParam.Value = sd_memo;
        myCmd.Parameters.Add(sParam);
        //author
        sParam = new SqlParameter("@author", SqlDbType.Char, 15);
        sParam.Value = author;
        myCmd.Parameters.Add(sParam);
        //infoId
        sParam = new SqlParameter("@infoId", SqlDbType.Int);
        sParam.Value = infoId;
        myCmd.Parameters.Add(sParam);
        //triptime
        sParam = new SqlParameter("@tripTime", SqlDbType.NChar,20);
        sParam.Value = triptime;
        myCmd.Parameters.Add(sParam);

        //no 출력을 위한 파라미터
        SqlParameter myParamOut = new SqlParameter("@no", SqlDbType.Int);
        myParamOut.Direction = ParameterDirection.Output;
        myCmd.Parameters.Add(myParamOut);
        //명령문 실행
        myCmd.ExecuteNonQuery();
        //글번호 찾기
        int no = (int)myParamOut.Value;

        //글번호 반환
        return no;
    }
    ///데이터 바인드를 위한 구문 
    ///

    public DataSet GetShceduleList(int no)
    {
        string qrySelect = "SELECT * FROM shcedule WHERE infoId = " + no;
            //"WHERE uploaddate like "+DateTime.Now.ToString("yyyy-MM-dd");
        return this.AdapterFill(qrySelect, "shcedule");
    }
    //큰틀의 여행 일정 정보 삽입
    //-----------------------------------------
    //-----------------------------------------

    public int insertInfoShcedule(string title,string author,string contents)
    {
        //-------저장프로시저 이용해서 넣음----
        string myProc = "insertInfoShcedule";//프로시저 이름결정

        SqlCommand myCmd = new SqlCommand(myProc, Conn);
        myCmd.CommandType = CommandType.StoredProcedure;
        //입력 파라미터
        SqlParameter sParam;
        //title
        sParam = new SqlParameter("@title", SqlDbType.NChar, 20);
        sParam.Value = title;
        myCmd.Parameters.Add(sParam);
        //author
        sParam = new SqlParameter("@author", SqlDbType.Char, 15);
        sParam.Value = author;
        myCmd.Parameters.Add(sParam);
        //contents
        sParam = new SqlParameter("@contents", SqlDbType.NVarChar, 500);
        sParam.Value = contents;
        myCmd.Parameters.Add(sParam);


        //no 출력을 위한 파라미터
        SqlParameter myParamOut = new SqlParameter("@no", SqlDbType.Int);
        myParamOut.Direction = ParameterDirection.Output;
        myCmd.Parameters.Add(myParamOut);
        //명령문 실행
        myCmd.ExecuteNonQuery();
        //글번호 찾기
        int no = (int)myParamOut.Value;

        //글번호 반환
        return no;
    }
    //자신의 여행일정 관련 메서드
    public DataSet GetShceduleinfoList(string author)
    {
        string qrySelect = "SELECT * FROM shcedule_info WHERE status = 0 AND author = '" + author + "'";
        //정렬기능
        qrySelect += " ORDER BY no DESC";
        return this.AdapterFill(qrySelect, "shedule_info");
    }
    public ShceduleInfo Shceduleinfodetails(int no)
    {
        //조회수 증가
        //string qryUpdate = "UPDATE BBS SET hits=hits+1 " + "WHERE no =" + no;

        //if (showpage) this.ExecuteNonQuery(qryUpdate);
        string qrySelect = "SELECT * FROM shcedule_info WHERE no =" + no + "AND status = 0";

        ShceduleInfo shceduleInfo = new ShceduleInfo();
        SqlDataReader sReader = this.ExecuteReader(qrySelect);
        //데이터 매핑
        if (sReader.Read())
        {
            shceduleInfo.title = sReader["title"].ToString().TrimEnd();
            shceduleInfo.auhtor = sReader["author"].ToString().TrimEnd();
            shceduleInfo.contents = sReader["contents"].ToString().TrimEnd();
            shceduleInfo.uploaddate = sReader["uploaddate"].ToString().TrimEnd();
            shceduleInfo.no = int.Parse(sReader["no"].ToString().TrimEnd());
        }
        sReader.Close();
        return shceduleInfo;
    }

    public Shcedule Shceduledetails(int no)
    {
        //조회수 증가
        //string qryUpdate = "UPDATE BBS SET hits=hits+1 " + "WHERE no =" + no;

        //if (showpage) this.ExecuteNonQuery(qryUpdate);
        string qrySelect = "SELECT * FROM shcedule WHERE infoId = " + no;

        Shcedule shcedule = new Shcedule();
        SqlDataReader sReader = this.ExecuteReader(qrySelect);
        //데이터 매핑
        if (sReader.Read())
        {
            shcedule.sd_id = int.Parse(sReader["sd_id"].ToString().TrimEnd());
            shcedule.dayinfo = sReader["dayinfo"].ToString().TrimEnd();
            shcedule.country = sReader["country"].ToString().TrimEnd();
            shcedule.city = sReader["city"].ToString().TrimEnd();
            shcedule.sd_memo = sReader["sd_memo"].ToString().TrimEnd();
            shcedule.no = int.Parse(sReader["no"].ToString().TrimEnd());
            shcedule.author = sReader["author"].ToString().TrimEnd();
            shcedule.datetime = sReader["uploaddate"].ToString().TrimEnd();
            shcedule.infoId = int.Parse(sReader["infoId"].ToString().TrimEnd());
        }
        sReader.Close();
        return shcedule;
    }
    public void RemoveShcedule(int no)
    {
        //삭제
        string qryDelete
            = "DELETE shcedule WHERE no = " + no.ToString();
        //실행
        this.ExecuteNonQuery(qryDelete);
    }
    public void RemoveShceduleInfo(int no)
    {
        string qryUpdate
            = "UPDATE shcedule_info set status = 1 WHERE no = " +no.ToString() ;
        //실행
        this.ExecuteNonQuery(qryUpdate);
    }
    public DataSet GetShceduleList(string tablename, int no)
    {
        string qrySelect = "SELECT * FROM shcedule WHERE infoId = " + no.ToString();
        qrySelect += " ORDER BY no ASC";
        //쿼리문 실행 및 결과 리턴
        return this.AdapterFill(qrySelect, tablename);
    }



    //사진게시판이용
    //-------------------------------------------------------------------
    //--------------------------------------------------------------------
    public AlbumInfo GetAlbumInfo(int albumId)
    {
        //결과를 가져갈 AlbumInfo 클래스의 객체 생성
        AlbumInfo myInfo = new AlbumInfo();
        //쿼리문 지정
        string qrySelect = "SELECT * FROM photosInfo WHERE albumId =" + albumId;
        //실행하여 결과를 SqlDataReader로 받아옴
        SqlDataReader myReader = this.ExecuteReader(qrySelect);
        //결과를 AlbumInfo 클래스로 전달
        if (myReader.Read())
        {
            myInfo.albumId = int.Parse(myReader["albumId"].ToString().TrimEnd());
            myInfo.albumtitle = myReader["title"].ToString().TrimEnd();
        }
        myReader.Close();
        //결과 리턴
        return myInfo;
    }
    public GuideInfo GetGuideInfo(int no)
    {
        //조회수 증가
        string qryUpdate = "UPDATE guidebook SET hits=hits+1 " + "WHERE no =" + no;
        this.ExecuteNonQuery(qryUpdate);
        //결과를 가져갈 PhotoInfo 클래스의 객체 생성
        GuideInfo GuideInfo = new GuideInfo();
        //테이블 이름을 이용하여 ViewPhotos를 만들어옴
        string qrySelect = "SELECT * FROM guidebook" + " WHERE no =" + no.ToString();
        //실행하여 결과를 SqlDataReader로 받아옴
        SqlDataReader myReader = this.ExecuteReader(qrySelect);
        //결과를 PhotoInfo 클래스로 전달
        if (myReader.Read())
        {
            GuideInfo.title = myReader["title"].ToString().TrimEnd();
            GuideInfo.comment = myReader["comment"].ToString().TrimEnd();
            GuideInfo.fname = myReader["fname"].ToString().TrimEnd();
            GuideInfo.pname = myReader["pname"].ToString().TrimEnd();
            GuideInfo.fsize = myReader["fsize"].ToString().TrimEnd();
            GuideInfo.author = myReader["author"].ToString().TrimEnd();
            GuideInfo.hits = int.Parse(myReader["hits"].ToString().TrimEnd());
            GuideInfo.uploaddate = myReader["uploaddate"].ToString().TrimEnd();
        }
        myReader.Close();
        //결과 리턴
        return GuideInfo;
    }
    public DataSet GetGuideList()
    {
        string qrySelect = "SELECT * FROM guidebook";
        return this.AdapterFill(qrySelect, "guidebook");
    }

    public int AddGuidebook(string title, string comment, string fname, string author, string pname, int fsize)
    {
        string myProc = "procinsertguidebook";//프로시저 이름결정
        //저장프로시저 지정
        SqlCommand myCmd = new SqlCommand(myProc, Conn);
        myCmd.CommandType = CommandType.StoredProcedure;

        SqlParameter param = new SqlParameter("@title", SqlDbType.NChar, 20);
        param.Value = title;
        myCmd.Parameters.Add(param);

        param = new SqlParameter("@comment", SqlDbType.NVarChar, 500);
        param.Value = comment;
        myCmd.Parameters.Add(param);

        param = new SqlParameter("@fname", SqlDbType.NChar, 50);
        param.Value = fname;
        myCmd.Parameters.Add(param);

        param = new SqlParameter("@author", SqlDbType.Char, 15);
        param.Value = author;
        myCmd.Parameters.Add(param);

        param = new SqlParameter("@pname", SqlDbType.NChar, 50);
        param.Value = pname;
        myCmd.Parameters.Add(param);

        param = new SqlParameter("@fsize", SqlDbType.Int);
        param.Value = fsize;
        myCmd.Parameters.Add(param);

        SqlParameter outParam = new SqlParameter("@no", SqlDbType.Int);
        outParam.Direction = ParameterDirection.Output;
        myCmd.Parameters.Add(outParam);
        myCmd.ExecuteNonQuery();
        return (int)outParam.Value;
    }
    public DataSet GetPhotoList(string tablename, int albumId)
    {
        string qrySelect = "SELECT * FROM " + tablename + " WHERE albumId = " + albumId;
        //쿼리문 실행 및 결과 리턴
        return this.AdapterFill(qrySelect, tablename);
    }
    public int AddPhoto(string title, string comment, string fname, string author, int albId)
    {
        string myProc = "procinsertphotos";//프로시저 이름결정
        //저장프로시저 지정
        SqlCommand myCmd = new SqlCommand(myProc, Conn);
        myCmd.CommandType = CommandType.StoredProcedure;

        SqlParameter param = new SqlParameter("@title", SqlDbType.NChar, 20);
        param.Value = title;
        myCmd.Parameters.Add(param);

        param = new SqlParameter("@comment", SqlDbType.NVarChar, 500);
        param.Value = comment;
        myCmd.Parameters.Add(param);

        param = new SqlParameter("@fname", SqlDbType.NChar, 50);
        param.Value = fname;
        myCmd.Parameters.Add(param);

        param = new SqlParameter("@author", SqlDbType.Char, 15);
        param.Value = author;
        myCmd.Parameters.Add(param);

        param = new SqlParameter("@albumId", SqlDbType.Int);
        param.Value = albId;
        myCmd.Parameters.Add(param);

        SqlParameter outParam = new SqlParameter("@no", SqlDbType.Int);
        outParam.Direction = ParameterDirection.Output;
        myCmd.Parameters.Add(outParam);
        myCmd.ExecuteNonQuery();
        return (int)outParam.Value;
    }
    public PhotoInfo GetPhotoInfo(int no)
    {
        //조회수 증가
        string qryUpdate = "UPDATE photos SET hits=hits+1 " + "WHERE no =" + no;
        this.ExecuteNonQuery(qryUpdate);
        //결과를 가져갈 PhotoInfo 클래스의 객체 생성
        PhotoInfo photoInfo = new PhotoInfo();
        //테이블 이름을 이용하여 ViewPhotos를 만들어옴
        string qrySelect = "SELECT * FROM photos" + " WHERE no =" + no.ToString();
        //실행하여 결과를 SqlDataReader로 받아옴
        SqlDataReader myReader = this.ExecuteReader(qrySelect);
        //결과를 PhotoInfo 클래스로 전달
        if (myReader.Read())
        {
            photoInfo.title = myReader["title"].ToString().TrimEnd();
            photoInfo.comment = myReader["comment"].ToString().TrimEnd();
            photoInfo.fname = myReader["fname"].ToString().TrimEnd();
            photoInfo.author = myReader["author"].ToString().TrimEnd();
            photoInfo.hits = int.Parse(myReader["hits"].ToString().TrimEnd());
            photoInfo.uploaddate = myReader["uploaddate"].ToString().TrimEnd();
        }
        myReader.Close();
        //결과 리턴
        return photoInfo;
    }
    public void RemovePhoto(string tablename, int no)
    {
        //삭제를 위한 쿼리문 작성
        string qryDelete = "DELETE FROM " + tablename + " WHERE no =" + no.ToString();
        //실행
        this.ExecuteNonQuery(qryDelete);
    }  //저장된 사진 수정
    public void UpdatePhoto(string title, string comment, string fname, int no)
    {
        //수정 쿼리
        string qryUpdate = "UPDATE Photos" + " SET title='" + title + "', comment='" + comment + "',fname='" + fname + "'";
        qryUpdate += " WHERE no=" + no;
        //데이터베이스 쿼리문 실행
        this.ExecuteNonQuery(qryUpdate);//업데이트 실행
    }
    //사진게시판 댓글처리
    public DataSet GetPhotoReplyList(int bno)
    {
        string qrySelect
            = "SELECT pr.author ,pr.contents,pr.uploadtime,me.nickname FROM PhotoReply as pr JOIN members AS me ON pr.author = me.userid WHERE photono = " + bno + " ORDER BY pr.uploadtime ASC";
        return this.AdapterFill(qrySelect, "bbsreply");
    }
    //댓글 입력처리 
    public void InsertPhotoReply(int bno, string author, string contents)
    {
        string qryInsert = "INSERT INTO PhotoReply (photono,author,contents,uploadtime) VALUES (" + bno + ",'" + author + "','" + contents + "', GETDATE())";
        this.ExecuteNonQuery(qryInsert);
    }
    //여행일정에 따른 ID값을 똑같이 부여하기위함 
    //Info에서 1번이라면 스케쥴InfoID값도 1번으로 부여하기위함
    public int GetInfoNo()
    {
        string sQuery = "SELECT COUNT(*) AS [Column] FROM shcedule_info";
        int result=0;
        SqlDataReader myReader = ExecuteReader(sQuery);
        if(myReader.Read())
        {
            result = int.Parse(myReader["Column"].ToString());
        }
        myReader.Close();
        return result+1;
    }

}