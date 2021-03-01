using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCombat : MonoBehaviour
{
    // Start is called before the first frame update

    public Animator animator;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space)){
            Attack();
        }
        
    }

    void Attack(){

        //Play an attack animation
        animator.SetTrigger("Attack");
        //Detect enemies in range of attack
        //Damage them
    }
}
