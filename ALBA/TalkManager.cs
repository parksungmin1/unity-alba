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
        //��� ���� 
        talkData.Add(1000, new string[] { "��? �̷����� �����?!?!:1", 
            "�����! \n�� �� �����ּ���:0",
            "�� ���� ���� �輼��?:1", 
            "���� �� �𸣰ھ��. \n���� �ƹ����� �� �̻��ؼ���:0",
            "���� ��� �ص帮�� �ɱ��?:1", "���͵��� ���踦 ������ �־��. \n" +
            "�װ��� ���ش� �ֽø� ���� ���� ����� �˷��帱�Կ�!:0", "��! ��ø� ��ٸ�����:1" });

        portraitData.Add(1000 + 0, portraitArr[0]);
        portraitData.Add(1000 + 1, portraitArr[1]);
    }

    public string GetTalk(int id, int talkIndex) //Object�� id , string�迭�� index
    {
        if (talkIndex == talkData[id].Length)
            return null;
        else
            return talkData[id][talkIndex]; //�ش� ���̵��� �ش�

    }

    public Sprite GetPortrait(int id, int portraitIndex)
    {
        //id�� NPC�ѹ� , portraitIndex : ǥ����ȣ(?)
        return portraitData[id + portraitIndex];
    }
}