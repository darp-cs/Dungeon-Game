using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : MonoBehaviour {

    private Animator animator;
    private Transform target;
    public Transform origin;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float maxRange;
    [SerializeField]
    private float minRange;
    void Start(){
        animator = GetComponent<Animator>();
        target = FindObjectOfType<playerController>().transform;
    }

    void Update() {

        if(Vector3.Distance(target.position, transform.position) <= maxRange && Vector3.Distance(target.position, transform.position)>= minRange){
            FollowPlayer();
        } else if(Vector3.Distance(target.position, transform.position) >= maxRange){Return();}
        

    }

    public void FollowPlayer(){
        animator.SetBool("isMoving", true);
        animator.SetFloat("moveX", (target.position.x -transform.position.x));
        animator.SetFloat("moveY", (target.position.y -transform.position.y));
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.fixedDeltaTime);
    }
     
     public void Return(){
         animator.SetFloat("moveX", (origin.position.x -transform.position.x));
         animator.SetFloat("moveY", (origin.position.y -transform.position.y));
         transform.position = Vector3.MoveTowards(transform.position, origin.position, speed * Time.fixedDeltaTime);

         if(Vector3.Distance(transform.position, origin.position) == 0){
             animator.SetBool("isMoving", false);
         }
     }

     private void OnTriggerEnter2D(Collider2D other){

         if(other.tag == "MyWeapon"){
             Vector2 difference = transform.position  - other.transform.position;
             transform.position = new Vector2(transform.position.x+difference.x, transform.position.y+difference.y);
         }
     }
}
