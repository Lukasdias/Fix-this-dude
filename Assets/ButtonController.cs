using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    private PuzzleController atual;
    private bool isActive;

    private Color colorActive;
    private Color colorUnactive;

    public GameObject[] botoes;
    public int cur = 0;

    // Start is called before the first frame update
    void Start()
    {
        colorActive = Color.green;
        colorUnactive = new Color(0.12f, 0.56f, 0.14f, 1f);
        isActive = true;
        botoes[cur].GetComponent<SpriteRenderer>().color = colorUnactive;
    }

    // Update is called once per frame
    void Update()
    {   
        atual = botoes[cur].transform.GetChild(0).gameObject.GetComponent<PuzzleController>();
        
        if (isActive) 
        {
            if (Input.GetKeyDown("right")) 
            {
                cur++;
                if (cur >= botoes.Length) 
                {
                    cur = 0;
                }
                updateColor();
                botoes[cur].GetComponent<SpriteRenderer>().color = colorUnactive;
            }
            else if (Input.GetKeyDown("left")) 
            {
                cur--;
                if (cur < 0) 
                {
                    cur = botoes.Length-1;
                }
                updateColor();
                botoes[cur].GetComponent<SpriteRenderer>().color = colorUnactive;
            }
            else if (Input.GetKeyDown("space")) 
            {
                botoes[cur].GetComponent<SpriteRenderer>().color = colorActive;
                    atual.enabled = !(atual.enabled);
                isActive = false;
            }
        }
        else 
        {
            if (Input.GetKeyDown("space")) 
            {
                botoes[cur].GetComponent<SpriteRenderer>().color = colorUnactive;
                atual.enabled = false;
                isActive = true;
            }
        }

        
    }

    void updateColor() {
        for (int i = 0; i < botoes.Length; i++) {
            botoes[i].GetComponent<SpriteRenderer>().color = Color.white;
        }
    }
}
