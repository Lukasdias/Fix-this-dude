using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleController : MonoBehaviour
{   

    private SpriteRenderer sr;
    public int isConnected;
    public bool isMoving;
    
    public GameObject self;
    public GameObject next;

    public GameObject[] connections;
    public Sprite[] spritesConnection;
    public Sprite[] spritesDisconnection;
    
    public Sprite[] rotations;
    
    public int cur = 0;

    // Start is called before the first frame update
    void Start()
    {   
        
        sr = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("right")) {
            cur++;
            if (cur == rotations.Length) {
                cur = 0;
            }
            sr.sprite = rotations[cur];
        }
        else if (Input.GetKeyDown("left")) {
            cur--;
            if (cur < 0) {
                cur = rotations.Length - 1;
            }
            sr.sprite = rotations[cur];
        }

        if (cur == isConnected) {
            
            isMoving = false;
            for (int i = 0; i < connections.Length; i++) {
                connections[i].GetComponent<SpriteRenderer>().sprite = spritesConnection[i];
            }
            
            //self.GetComponent<PuzzleController>().enabled = false;
            
            //if (next != null) {
              //  next.GetComponent<PuzzleController>().enabled = true;
            //}
        }
        else {
            
            for (int i = 0; i < connections.Length; i++) {
                connections[i].GetComponent<SpriteRenderer>().sprite = spritesDisconnection[i];
            }
        }
    }
}
