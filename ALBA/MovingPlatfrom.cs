using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatfrom : MonoBehaviour
{
    public Transform startPos;
    public Transform endPos;
    public Transform desPos;
    public float speed;
    public Player player;
    void Start()
    {
        transform.position = startPos.position;
        desPos = endPos;
    }
    void Update()
    {
        
    }
    // Update is called once per frame 
    void FixedUpdate()
    {
       
        transform.position = Vector2.MoveTowards(transform.position,desPos.position,Time.deltaTime*speed);
     
        if(Vector2.Distance(transform.position, desPos.position) <= 0.05f) // �Ÿ��� 0.05f �����϶��� �������� �ٲ���
        {
            if (desPos == endPos) desPos = startPos;
            else desPos = endPos;
        }


    }
}
