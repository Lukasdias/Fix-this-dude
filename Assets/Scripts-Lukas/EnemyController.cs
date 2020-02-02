using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{   
    
    public Transform[] waypoints;
    public int cur = 0;
    public float speed;
    public float waitTime = 0.9f;
    public float timer = 0f;
    public Rigidbody2D rb;
    
    public bool isVunerable = false;
// Use this for initialization
    void Start () {
 
    }
    
    void OnTriggerEnter2D(Collider2D co) {
        if (co.name == "Player") {
            if (isVunerable) {
                co.gameObject.GetComponent<PlayerController>().Game.MinigameConcluido();
                Destroy(gameObject);
            }
            else {
                co.gameObject.GetComponent<PlayerController>().Game.MinigameFalho();
                Destroy(co.gameObject);
                
            }
        } 
    }
    
    void Update()
    {   

        

        
        
    }

    void FixedUpdate () {
    
        // move-se até o objetivo
        
        if (Vector3.Distance(transform.position,waypoints[cur].position) > 0.5) {
            Vector2 p = Vector2.MoveTowards(transform.position, waypoints[cur].position, speed * Time.fixedDeltaTime);
            rb.MovePosition(p);
            
        }else{
            Debug.Log(gameObject.name+" Chegou no Destino");
            timer += Time.fixedDeltaTime;
            if (timer > waitTime){
                if (cur < waypoints.Length-1) {
                    cur++;
                }
                else {
                    cur = 0;
                }
                timer = timer - waitTime;
            }
        }
    
    }
}