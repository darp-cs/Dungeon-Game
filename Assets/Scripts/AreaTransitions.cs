using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaTransitions : MonoBehaviour
{

    private cameraController camera;
    public Vector2 newCamMinPos;
    public Vector2 newCamMaxPos;
    public Vector3 movePlayer;
    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main.GetComponent<cameraController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other){
        Debug.Log(other.tag);
        if(other.tag == "Player"){
            Debug.Log("Touched");
            camera.minPosition = newCamMinPos;
            camera.maxPosition = newCamMaxPos;
            other.transform.position += movePlayer;
        }
    }
}
