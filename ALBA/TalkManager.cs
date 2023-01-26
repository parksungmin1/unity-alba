using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData;
    Dictionary<int, Sprite> portraitData;
    public Sprite[] portraitArr;

    void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        portraitData = new Dictionary<int, Sprite>();
        GenerateData();
    }

    void GenerateData()
    {
        //대사 생성 
        talkData.Add(1000, new string[] { "엥? 이런곳에 사람이?!?!:1", 
            "저기요! \n저 좀 도와주세요:0",
            "왜 여기 갇혀 계세요?:1", 
            "저도 잘 모르겠어요. \n저희 아버지가 좀 이상해서요:0",
            "제가 어떻게 해드리면 될까요?:1", "몬스터들이 열쇠를 가지고 있어요. \n" +
            "그것을 구해다 주시면 제가 좋은 기술을 알려드릴게요!:0", "네! 잠시만 기다리세요:1" });

        portraitData.Add(1000 + 0, portraitArr[0]);
        portraitData.Add(1000 + 1, portraitArr[1]);
    }

    public string GetTalk(int id, int talkIndex) //Object의 id , string배열의 index
    {
        if (talkIndex == talkData[id].Length)
            return null;
        else
            return talkData[id][talkIndex]; //해당 아이디의 해당

    }

    public Sprite GetPortrait(int id, int portraitIndex)
    {
        //id는 NPC넘버 , portraitIndex : 표정번호(?)
        return portraitData[id + portraitIndex];
    }
}