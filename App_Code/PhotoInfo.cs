using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// PhotoInfo의 요약 설명입니다.
/// </summary>
public class PhotoInfo
{
    //사진의 정보를 전달하기 위한 클래스
    public string title; //사진 제목
    public string comment; //사진 설명
    public string fname; //파일이름
    public string author; //사진 올린 사람 ID
    public int hits;//조회수
    public string uploaddate;//올린날짜

    public PhotoInfo()
    {
        //
        // TODO: 여기에 생성자 논리를 추가합니다.
        //
    }
}