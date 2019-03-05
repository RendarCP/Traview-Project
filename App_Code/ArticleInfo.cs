using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// ArticleInfo의 요약 설명입니다.
/// </summary>
public class ArticleInfo
{
    public int no;//글번호
    public string title;//제목
    public string contents;//내용
    public string author;//글쓴이 
    public string uploadtime;//업로드 시간
    public int hits;//조회수
    public int bbsId;//게시판 번호
    public string filename;
    public int filesize;
    public string Kategorie;//QnA게시판관련 
    public ArticleInfo()
    {
        //
        // TODO: 여기에 생성자 논리를 추가합니다.
        //
    }
}