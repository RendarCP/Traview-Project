using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// EventInfo의 요약 설명입니다.
/// </summary>
public class EventInfo
{
    public int no; //글번호
    public string title; // 이벤트 제목
    public string contents; //이벤트 내용
    public string author; // 이벤트 작성자(관리자)
    public string filename;
    public int filesize;
    public string startEvent; //이벤트 시작일
    public string endEvent; //이벤트 종료일
    public string AnnounceEvent; //이벤트 발표일
    public int writeAuth; // 작성자 제한(관리자만 작성)
    public EventInfo()
    {
        //
        // TODO: 여기에 생성자 논리를 추가합니다.
        //
    }
}