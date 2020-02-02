using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    // public Camera MainCamera;
    // public GameObject World;
    // public Camera PacManCamera;
    // public GameObject PacmanCanvas;   
    public GameController Game;
    private CharacterController controller;
    private Animator animator;
    private Vector3 MoveVelocity;
    private Rigidbody rb;
    public float Speed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        // rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update() {
        Movement();
        // rb.MovePosition(rb.position+MoveVelocity*Time.deltaTime);   
    }

    void Movement() {
        float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis ("Vertical");
        if(Mathf.Abs(moveVertical) > 0 || Mathf.Abs(moveHorizontal) > 0) {
            animator.SetBool("Moving", true);
        }else {
            animator.SetBool("Moving", false);
        }
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        if(movement != Vector3.zero) {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(-movement.normalized), 0.7F);
        }
        transform.Translate (movement * Speed * Time.deltaTime, Space.World);
    }

    private void OnTriggerStay(Collider other) {
        if (other.gameObject.tag == "Mesa") {
            if(Input.GetKeyDown("e")){
                Debug.Log(other.gameObject.name + " é " + other.gameObject.GetComponent<Room>().isActive); 
                if(!Game.Blocked){
                    if(other.gameObject.GetComponent<Room>().getState()){
                        Debug.Log("minigame");
                        Game.AtivaMinigame();
                        Game.Blocked = true;
                    }
                }
                
                
                // PacManCamera.gameObject.tag = "MainCamera";
                // PacManCamera.gameObject.SetActive(true);
                // MainCamera.gameObject.tag = "Untagged";
                // MainCamera.gameObject.SetActive(false);
                // World.gameObject.SetActive(false);
                // PacmanCanvas.gameObject.SetActive(true);
                // PacmanCanvas.transform.localPosition=Vector3.zero;
            }
        }
    }
}
