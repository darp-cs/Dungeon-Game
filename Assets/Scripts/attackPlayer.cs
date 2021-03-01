using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class attackPlayer : MonoBehaviour
{

    private HealthManager health;
    public float waitToHurt = 2f;
    public bool touching;

    [SerializeField]
    private int damage= 10;

    // Start is called before the first frame update
    void Start()
    {
        health = FindObjectOfType<HealthManager>();
    }

    // Update is called once per frame
    void Update()
    {
    
        // if(reloading){
        //     waitToLoad  -= Time.fixedDeltaTime;
        //     if(waitToLoad <= 0){
        //         SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //     }
        // }
        
            if(touching){
                waitToHurt -= Time.fixedDeltaTime;
                if(waitToHurt <= 0){
                    health.GiveDamage(damage);
                    waitToHurt= 1f;
                }
            }



    }

    private void OnCollisionEnter2D(Collision2D other){
        if(other.collider.tag == "Player"){
            // Destroy(other.gameObject);
            // other.gameObject.SetActive(false);
            other.gameObject.GetComponent<HealthManager>().GiveDamage(damage);
            // reloading = true;
            
        }
    }

    private void OnCollisionStay2D(Collision2D other){

        if(other.collider.tag == "Player"){
            touching = true;
        }
        
    }

    private void OnCollisionExit2D(Collision2D other){
        if(other.collider.tag == "Player"){
            touching = false;
            waitToHurt = 2f;
        }
    }
}
