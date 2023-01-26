using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Rigidbody2D rigid; //�������
    SpriteRenderer spriteRenderer;
    CapsuleCollider2D collider;

    public int nextMove; // �ൿ��ǥ ���� 
    
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        collider = GetComponent<CapsuleCollider2D>();
        Invoke("Think",5); // Think�Լ��� 5�ʵڿ� ȣ��
    }

    void FixedUpdate()
    {
        rigid.velocity = new Vector2(nextMove, rigid.velocity.y);  //�ӵ� -1 : ����

        //���� ������
        Vector2 frontVec = new Vector2(rigid.position.x + nextMove, rigid.position.y);
        Debug.DrawRay(frontVec, Vector3.down, new Color(0, 1, 0));

        //�÷����� ������ rayhit
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
        
        //��������
        spriteRenderer.flipY = true;
        collider.enabled = false;
        
        //�׾����� �ٱ�
        rigid.AddForce(Vector2.up * 5, ForceMode2D.Impulse);
       
        //5�ʵڿ� �����
        Invoke("DeActive", 0.1f);
        Debug.Log("���� �׾����ϴ�.");
    }

    // �������� �� �� ���������� �� �� , �������� �˾Ƽ� ����
    void Think()
    {
        nextMove = Random.Range(-1, 2); // -1,0,1 ���̿��� random �� �� ����

        float nextThinkTime = Random.Range(2f,5f);
        Invoke("Think", nextThinkTime);
    }

    void DeActive()
    {
        gameObject.SetActive(false);
    }
}
