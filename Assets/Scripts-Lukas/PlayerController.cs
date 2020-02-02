using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;

    public Rigidbody2D rb;
    Vector2 movement;
    public GameObject inimigo_certo;
    public Sprite sprite;
    public GameController Game;
    // Start is called before the first frame update
    void Start()
    {
        Game = GameObject.Find("GameManager").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);        
    }

    void OnTriggerEnter2D(Collider2D co) {
        if (co.name == "Goal") {
            inimigo_certo.GetComponent<SpriteRenderer>().sprite = sprite;
            inimigo_certo.GetComponent<EnemyController>().isVunerable = true;
            Destroy(co.gameObject);
            // Game.DesativaPacMan();
        }
    }

}
