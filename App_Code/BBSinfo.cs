using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// BBSinfo의 요약 설명입니다.
/// </summary>
public class BBSinfo
{
    public string bbsId; // 게시판ID 
    //11번 -> 전문여행기 12번 -> 도시별 여행
    //21번 -> 여행후기/팁 22 -> QnA 
    //31번 ->이벤트
    public string bbsname;//게시판 이름
    public int writeAuth;//쓰기 권한(이벤트페이지용)
    public bool reply;// 댓글 쓰기 권한(안쓸예정)
    public BBSinfo()
    {
        //
        // TODO: 여기에 생성자 논리를 추가합니다.
        //
    }
}