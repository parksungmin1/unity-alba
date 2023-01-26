using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Rigidbody2D rigid; //물리기반
    SpriteRenderer spriteRenderer;
    CapsuleCollider2D collider;

    public int nextMove; // 행동지표 변수 
    
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        collider = GetComponent<CapsuleCollider2D>();
        Invoke("Think",5); // Think함수를 5초뒤에 호출
    }

    void FixedUpdate()
    {
        rigid.velocity = new Vector2(nextMove, rigid.velocity.y);  //속도 -1 : 왼쪽

        //앞을 봐야함
        Vector2 frontVec = new Vector2(rigid.position.x + nextMove, rigid.position.y);
        Debug.DrawRay(frontVec, Vector3.down, new Color(0, 1, 0));

        //플랫폼에 닿을때 rayhit
        RaycastHit2D rayhit = Physics2D.Raycast(frontVec, Vector3.down, 1, LayerMask.GetMask("Platform"));
        
        if(rayhit.collider == null)
        {
            nextMove *= - 1;
            CancelInvoke();
            Invoke("Think", 5);
        }

        if(nextMove == 1)
        {
            spriteRenderer.flipX = true;
        }
        else if(nextMove == -1)
        {
            spriteRenderer.flipX = false;
        }
    }

    public void OnDamaged()
    {
        spriteRenderer.color = new Color(1, 1, 0, 0.1f);
        
        //뒤집어줌
        spriteRenderer.flipY = true;
        collider.enabled = false;
        
        //죽었을때 뛰기
        rigid.AddForce(Vector2.up * 5, ForceMode2D.Impulse);
       
        //5초뒤에 사라짐
        Invoke("DeActive", 0.1f);
        Debug.Log("적이 죽었습니다.");
    }

    // 왼쪽으로 갈 지 오른쪽으로 갈 지 , 정지할지 알아서 결정
    void Think()
    {
        nextMove = Random.Range(-1, 2); // -1,0,1 사이에서 random 이 쭉 돈다

        float nextThinkTime = Random.Range(2f,5f);
        Invoke("Think", nextThinkTime);
    }

    void DeActive()
    {
        gameObject.SetActive(false);
    }
}
