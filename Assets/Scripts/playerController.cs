using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;
    [SerializeField]
    private float speed;
    private float attackTime = .25f;
    private float attackCounter = .25f;
    private bool isAttacking;


    void Start(){
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    

    void Update(){
        rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"))* speed * Time.fixedDeltaTime;

        animator.SetFloat("moveX", rb.velocity.x);
        animator.SetFloat("moveY", rb.velocity.y);

        if(Input.GetAxisRaw("Horizontal")== 1 || Input.GetAxisRaw("Horizontal") == -1 || Input.GetAxisRaw("Vertical")== 1 || Input.GetAxisRaw("Vertical")== -1){
            animator.SetFloat("lastMoveX", Input.GetAxisRaw("Horizontal"));
            animator.SetFloat("lastMoveY", Input.GetAxisRaw("Vertical"));
        }

        if(isAttacking){
            rb.velocity = Vector2.zero;
            attackCounter -= Time.fixedDeltaTime;
            if(attackCounter <= 0){
                animator.SetBool("isAttacking", false);
                isAttacking = false;
            }
        }
        if(Input.GetKeyDown(KeyCode.P)){
            attackCounter = attackTime;
            animator.SetBool("isAttacking", true);
            isAttacking=true;
        }

    }


    
}
