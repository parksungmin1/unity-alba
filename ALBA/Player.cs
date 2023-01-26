using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public GameManager gameManager; //������ �������� ����
    public float maxSpeed;
    public float jumpPower;
    public float springPower;
    public float AddspringPower;
    public float MorespringPower;

    public bool isPause = false;
    public GameObject scanObject;
    private int step = 0;
    public SoundManager soundmanager;

    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    CapsuleCollider2D Capsulecollider;
    [SerializeField] private AudioSource bgmSoundEffect;
    [SerializeField] private AudioSource attackSoundEffect;
    [SerializeField] private AudioSource finishSoundEffect;
    [SerializeField] private AudioSource damagedSoundEffect;
    [SerializeField] private AudioSource jumpSoundEffect;
    [SerializeField] private AudioSource coinSoundEffect;
    [SerializeField] private AudioSource coffeeSoundEffect;
    Animator anim;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        Capsulecollider = GetComponent<CapsuleCollider2D>();
        anim = GetComponent<Animator>();       
    }
    
    void Update()
    {

        Jump();
        if (Input.GetButtonUp("Horizontal"))
        {
            rigid.velocity = new Vector2(rigid.velocity.normalized.x * 0.5f, rigid.velocity.y);        
        }

        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            spriteRenderer.flipX = true;
          
        }
        else if (Input.GetAxisRaw("Horizontal") > 0)
        {
            spriteRenderer.flipX = false;
            
        }      
    }
    public void Jump()
    {
        anim.SetBool("isUpDown", false);
        if (Input.GetKeyDown(KeyCode.UpArrow) && (step == 0 || step == 2))
        {
            jumpSoundEffect.Play();
            rigid.velocity = new Vector2(rigid.velocity.x, jumpPower);
            step++;
        }
        switch (step)
        {
            case 0: //������ �ִ� ����
                    // �������� ������

            case 1: // 1�� ���� �� �ö󰡰� �ִ� ����
                if (rigid.velocity.y < 0) step = 2;
                break;
            case 2: // 1�� ���� �� �������� �ִ� ���� & �������¿��� �������� ���� ��

            case 3: // 2�� ���� �� �ö󰡰� �ִ� ����
                RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, Vector2.down, 1, LayerMask.GetMask("Platform"));
                if (rayHit.collider != null)
                    if (rayHit.distance < 0.5)
                        step = 0;
                break;
        }
    }
    void FixedUpdate()
    {
        //������
        float h = Input.GetAxisRaw("Horizontal");

        rigid.AddForce(Vector2.right * h, ForceMode2D.Impulse);
        

        if (rigid.velocity.x > maxSpeed)
            rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y);

        else if (rigid.velocity.x < maxSpeed * (-1))
            rigid.velocity = new Vector2(maxSpeed * (-1), rigid.velocity.y);

    
        
        if(isLadder)
        {
            float ver = Input.GetAxis("Vertical");
            rigid.gravityScale = 0;
            rigid.velocity = new Vector2(rigid.velocity.x, ver * maxSpeed);
        }
        else
        {
            rigid.gravityScale = 3f;
        }
    }
    public void IsPause()
    {
        isPause = !isPause;
        if (isPause)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
        Time.fixedDeltaTime = 0.02f * Time.timeScale;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Enemy")
        {
            // �Ʒ��� ������ && ���� ���� �÷��̾ ���� -> ���
            if(rigid.velocity.y < 0 && transform.position.y > collision.transform.position.y)
            {
                OnAttack(collision.transform);
            }
            else
            {
                OnDamaged(collision.transform.position);
            }
        }

        if (collision.gameObject.tag == "Box")
        {
            // �Ʒ��� ������ && ���� ���� �÷��̾ ���� -> ���

            Grow();
        }



        if (collision.gameObject.tag == "Spring")
        {
            // �Ʒ��� ������ && ���� ���� �÷��̾ ���� -> ���
            if (rigid.velocity.y < 0 && transform.position.y > collision.transform.position.y)
            {
                rigid.velocity = new Vector2(rigid.velocity.x, springPower);
            }
           
        }

        if (collision.gameObject.tag == "AddSpring")
        {
            // �Ʒ��� ������ && ���� ���� �÷��̾ ���� -> ���
            if (rigid.velocity.y < 0 && transform.position.y > collision.transform.position.y)
            {
                rigid.velocity = new Vector2(rigid.velocity.x, AddspringPower);
            }

        }

        if (collision.gameObject.tag == "MoreSpring")
        {
            if (rigid.velocity.y < 0 && transform.position.y > collision.transform.position.y)
            {
                rigid.velocity = new Vector2(rigid.velocity.x, MorespringPower);
            }

        }
        if (collision.gameObject.tag == "Finish")
        { 
            finishSoundEffect.Play();
            Debug.Log("���� Ŭ����!");
         
            if (gameManager.coffee == 1 && gameManager.stagePoint>900)
            {             
                SceneManager.LoadScene("Clear1Scene");
            }
            if (gameManager.coffee == 2 && gameManager.stagePoint > 1900)
            {
                SceneManager.LoadScene("Clear2Scene");
            }
            if (gameManager.coffee == 3 && gameManager.stagePoint > 2900)
            {
                SceneManager.LoadScene("Clear3Scene");
            }
        }

        if (collision.gameObject.tag == "Finish2")
        {
            finishSoundEffect.Play();
            Debug.Log("���� Ŭ����!");

            if (gameManager.caramel == 1)
            {
                SceneManager.LoadScene("Clear1NewScene");
            }
            if (gameManager.caramel== 2)
            {
                SceneManager.LoadScene("Clear2NewScene");
            }
            if (gameManager.caramel == 3)
            {
                SceneManager.LoadScene("Clear3NewScene");
            }
        }


    }

    public void Clear1()
    {
        SceneManager.LoadScene("Stage2GameScene");
    }
    public bool isLadder;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Bronze")
        {
            coinSoundEffect.Play();
            //���� ���
            gameManager.stagePoint += 100;
            //������ �����
            collision.gameObject.SetActive(false);
        }

        if (collision.gameObject.tag == "Silver")
        {
            coinSoundEffect.Play();
            //���� ���
            gameManager.stagePoint += 200;
            //������ �����
            collision.gameObject.SetActive(false);
        }

        if (collision.gameObject.tag == "Gold")
        {
            coinSoundEffect.Play();
            //���� ���
            gameManager.stagePoint += 300;
            //������ �����
            collision.gameObject.SetActive(false);
        }
       
       
         if (collision.gameObject.tag == "Coffee")
         {
                coffeeSoundEffect.Play();
                gameManager.stagePoint += 300;
                gameManager.CoffeePlus();

                collision.gameObject.SetActive(false);
               
            }

        if (collision.gameObject.tag == "Caramel")
        {
            coffeeSoundEffect.Play();
            gameManager.stagePoint += 300;
         
            gameManager.CaramelPlus();
            collision.gameObject.SetActive(false);

        }

        if (collision.gameObject.tag == "player")
        {

            gameManager.HealthUp();
            collision.gameObject.SetActive(false);

        }
        if (collision.gameObject.tag == "Ladder")
        {
            anim.SetBool("isUpDown", true);
            isLadder = true;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Ladder")
        {
            isLadder = false;
        }
    }

    void OnAttack(Transform enemy)
    {
        gameManager.stagePoint += 100;
        attackSoundEffect.Play();
        //������ �� ���� �ٱ�
        rigid.AddForce(Vector2.up * 5, ForceMode2D.Impulse);

        Enemy enemyMove = enemy.GetComponent<Enemy>();
        enemyMove.OnDamaged();
    }

    void OnDamaged(Vector2 targetPos)
    {
        gameManager.HealthDown();
        gameObject.layer = 3;
        damagedSoundEffect.Play();
        // �¾����� ���� ���������
        spriteRenderer.color = new Color(1, 1, 1, 0.4f);

        // ƨ��
        int dirc = transform.position.x - targetPos.x > 0 ? 1 : -1;
        rigid.AddForce(new Vector2(dirc, 1) * 7, ForceMode2D.Impulse);

        Invoke("OffDamaged", 1);   
        
    }
    
    void OffDamaged()
    {
        gameObject.layer = 0;
        spriteRenderer.color = new Color(1, 1, 1, 1);
    }

    public void OnDie()
    {
        spriteRenderer.color = new Color(1, 1, 1, 0.4f);

        //��������
        spriteRenderer.flipY = true;
        Capsulecollider.enabled = false;

        //�׾����� �ٱ�
        rigid.AddForce(Vector2.up * 5, ForceMode2D.Impulse);

    }

    public void VelocityZero()
    {
        rigid.velocity = Vector2.zero;
    }

    public void Grow()
    {
        transform.localScale = new Vector3(2, 2, 1);
    }
  

}

