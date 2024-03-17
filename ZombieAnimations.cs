using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Networking.PlayerConnection;
using UnityEngine;

// Z = Zombie

public class ZombieAnimations : MonoBehaviour
{
    Animator animator;
    Rigidbody2D RBody;
    SpriteRenderer Sprite;
    
    
    Transform PointL, PointR;               //edges of platform or walkabkle area

    private bool isPlayerinXRange = false;
    private bool isPlayerinYRange = false;
    float DistancetoPlayer;                   //distance between enemy and player (only X row)
    bool isNexttoPlayer=false;

    public float MoveSpeed=1.5f, RunSpeed=3f;
    private bool isReachedPoint=false;       // if Z touch the edge points of platform
    int MoveDirection = 1;                    // movel eft or right
    GameObject PlayerGO;


    void Start()
    {
        PlayerGO = GameObject.FindGameObjectWithTag("Player");
        PointL =transform.parent.GetChild(1);
        PointR =transform.parent.GetChild(2);

        RBody = GetComponent<Rigidbody2D>(); // cache rigid body
        animator = GetComponent<Animator>();   //animator cache
        Sprite = GetComponent<SpriteRenderer>(); // cache sprite


    }

    void FixedUpdate()
    {

        DistancetoPlayer = PlayerGO.transform.position.x - transform.position.x;       //distance between player to enemy


        if (CheckPlayer() && !isReachedPoint)
        {
            if (MoveDirection == -1 && DistancetoPlayer <= 0)
            {
                if (Mathf.Abs(DistancetoPlayer) <= 1.5f && !isNexttoPlayer)
                {
                    animator.SetBool("nextPlayer", true);
                    isNexttoPlayer = true;
                    Movement(0, true);
                    StartCoroutine(Attack());
                    
                }
                else if(!isNexttoPlayer)
                {
                    Chase();
                }
            }
            if (MoveDirection == 1 && DistancetoPlayer > 0)
            {
                if (Mathf.Abs(DistancetoPlayer) <= 1.5f && !isNexttoPlayer)
                {
                    animator.SetBool("nextPlayer", true);
                    isNexttoPlayer = true;
                    Movement(0, true);
                    StartCoroutine(Attack());
                    
                }
                else if(!isNexttoPlayer) {
                    Chase();
                }
                
            }
        }
        else if(!isReachedPoint && !isNexttoPlayer)
        {
             Movement(MoveSpeed,false);
        }
        else
        {
            animator.SetBool("nextPlayer", false);
        }
      

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PointR"))           // riht point
        {
            Movement(0);                 // set stop value
            isReachedPoint = true;                   // reached edge
            animator.SetBool("Point", true);         // set idle anim
            StartCoroutine(Turn(-1,true));

        }
        else if (collision.gameObject.CompareTag("PointL")){      //left point

            Movement(0);
            isReachedPoint = true;
            animator.SetBool("Point", true);
            StartCoroutine(Turn(1,false));

        }
       
    }
    IEnumerator Turn(int MDirection, bool Turnbo)                  // turn Z to the left or right
    {
        yield return new WaitForSeconds(2);
        MoveDirection = MDirection;                     // Turn Z
        Sprite.flipX = Turnbo;                          // turn sprite
        isReachedPoint = false;

    }

    bool CheckPlayer() {     // if player in walkable are range. with X and Y Vectors
        isPlayerinYRange = transform.position.y-1.5f<=PlayerGO.transform.position.y && PlayerGO.transform.position.y<= transform.position.y+1.5f;
        isPlayerinXRange = PointL.position.x <= PlayerGO.transform.position.x && PlayerGO.transform.position.x <= PointR.position.x;
        if (isPlayerinXRange && isPlayerinYRange)
        {
            return true;
        }
        else 
            return false;

        
    }

    void Movement(float MovSpeed, bool isReached=false)         //move Z
    {
        RBody.velocity = (new Vector3(MovSpeed * MoveDirection, 0, 0));
        animator.SetBool("Point", isReached);         // Move anim
        isReachedPoint = false;
    }

    void Chase()                       //chase player if detected
    {
        Movement(RunSpeed,true);
        animator.Play("Run");                // RUn anim
    }
    IEnumerator Attack()
    {
        yield return new WaitForSeconds(1f);
        animator.Play("Attack1");
        isNexttoPlayer = false;
        yield return new WaitForSeconds(0.2f);
        print("gothit");
    }


}
