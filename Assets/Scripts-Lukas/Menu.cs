using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public Sprite[] TelasMenu;
    public GameObject Painel;
    private int i;
    // Start is called before the first frame update
    void Start()
    {
        i = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Painel.GetComponent<Image>().sprite = TelasMenu[i];
        if(Input.anyKeyDown){
            if(i == TelasMenu.Length-1){
                SceneManager.LoadScene("TudoJunto");
            }else{
                i++;
            }
        }
    }
}
