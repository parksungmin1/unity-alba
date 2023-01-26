using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//Text field�� ����� �� �ֵ��� �ϴ� header
using UnityEngine.SceneManagement;

[System.Serializable] //���� ���� class�� ������ �� �ֵ��� ����. 
public class Dialogue
{
    [TextArea]//���� ���� ���� �� �� �� �ְ� ����
    public string dialogue;
    public Sprite cg; // ��ü�� �̹���

}
public class dialog : MonoBehaviour
{
    //SerializeField : inspectorâ���� ���� ������ �� �ֵ��� �ϴ� ������.
    [SerializeField] private SpriteRenderer sprite_StandingCG; //ĳ���� �̹���(YK)�� �����ϱ� ���� ����
    [SerializeField] private SpriteRenderer sprite_DialogueBox; //���â �̹���(crop)�� �����ϱ� ���� ����
    [SerializeField] private Text txt_Dialogue; // �ؽ�Ʈ�� �����ϱ� ���� ����

    private bool isDialogue = false; //��ȭ�� ���������� �˷��� ����
    private int count; //��簡 �󸶳� ����ƴ��� �˷��� ����

    [SerializeField] private Dialogue[] dialogue;

    public void ShowDialogue()
    {
      
        count = 0;
        NextDialogue(); //ȣ����ڸ��� ��簡 ����� �� �ֵ��� 
    }

    private void NextDialogue()
    {
        //ù��° ���� ù��° cg���� ��� ���� cg�� ����Ǹ鼭 ȭ�鿡 ���̰� �ȴ�. 
        txt_Dialogue.text = dialogue[count].dialogue;
        sprite_StandingCG.sprite = dialogue[count].cg;
        count++; //���� ���� cg�� �������� 

    }

    void Update()
    {

        sprite_DialogueBox.gameObject.SetActive(true);
        sprite_StandingCG.gameObject.SetActive(true);
        txt_Dialogue.gameObject.SetActive(true);
        isDialogue = true;

        //spacebar ���� ������ ��簡 ����ǵ���. 
        if (isDialogue) //Ȱ��ȭ�� �Ǿ��� ���� ��簡 ����ǵ���
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //��ȭ�� ���� �˾ƾ���.
                if (count < dialogue.Length) NextDialogue(); //���� ��簡 �����
                else
                {
                    sprite_DialogueBox.gameObject.SetActive(false);
                    sprite_StandingCG.gameObject.SetActive(false);
                    txt_Dialogue.gameObject.SetActive(false);
                    isDialogue = false;
                    SceneManager.LoadScene("Stage1GameScene");
                    //��簡 ����
                }
            }
        }

    }
}