using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour {
    private int TypeofGame;
    public bool isActive;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() {
        
    }

    public void setType(int type){
        TypeofGame = type;
    }

    public bool getState(){
        return isActive;
    }

    public void setState(bool state){
        isActive = state;
    }
}
