using UnityEngine;
using UnityEngine.Tilemaps;

public class Hareket : MonoBehaviour
{
    public float speed = 10.0f; // Hareket hızı
    public float jump = 5.0f; // Zıplama gücü
    private float a;//geçici yavşlatma için
    public float AttackWS = 2;//saldır anında harket hızı
    public float speedF=2;
    private bool Yerde=true;

    private Rigidbody2D rb; // Rigidbody2D bileşeni
    private SpriteRenderer sprite;//SpriteRenderer bileşeni
    private Animator anim;//Animator bileşeni
    private BoxCollider2D coll;//BoxCollider2D bileşeni

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Rigidbody2D bileşenini al
        sprite = GetComponent<SpriteRenderer>();//SpriteRenderer bileşeni al
        anim = GetComponent<Animator>();//Animator bileşenini al
        coll = GetComponent<BoxCollider2D>();//BoxCollider2D bileşenini al
        a = speed;
    }

    void FixedUpdate()
    {
        #region Yatay hareket
            // Yatay hareket
            float yatayHareket = Input.GetAxis("Horizontal"); // Yatay eksen okuması
            if(yatayHareket != 0){
                if(Input.GetKey(KeyCode.LeftShift))
                {
                    rb.velocity = new Vector2(yatayHareket * speed * speedF, rb.velocity.y); // Hız vektörünü ayarla
                    anim.SetBool("Run",true);
                }
                else
            {
                rb.velocity = new Vector2(yatayHareket * speed, rb.velocity.y); // Hız vektörünü ayarla
                anim.SetBool("Run",false);
            }
                anim.SetFloat("Speed",2);
            }
            else
            {
                anim.SetFloat("Speed",0);
            }
        #endregion
        #region  Zıplama
            if (Input.GetKeyDown(KeyCode.Space) && Yerde) // Zıplama tuşu kontrolü
            {
                rb.AddForce(Vector2.up * jump, ForceMode2D.Impulse); // Zıplama kuvveti uygula
                Yerde = false;
                anim.SetBool("Jump",true);
            }
        #endregion
        #region Attack
            if(Input.GetKey(KeyCode.L))
            {
                anim.SetBool("Attack",true);
                speed = AttackWS;
            }
            else
        {
            anim.SetBool("Attack",false);
            speed = a;
        }
        #endregion
    }
    void Update()
    {
        #region bakisY
        if (0<Input.GetAxis("Horizontal"))
        {
            sprite.flipX = false;
        }
        if(0>Input.GetAxis("Horizontal"))
        {
            sprite.flipX = true;
        }
        #endregion
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        // Zeminle çarpışma kontrolü
        if (col.gameObject.tag == "yer")
        {
            Yerde = true;
            anim.SetBool("Jump",false);
        }
    }
}
