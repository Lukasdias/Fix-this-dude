using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Canvas[] myCanvas;
    public GameObject[] myRooms;
    public int TypeOfGame;
    public GameObject[] variationsOfWire;
    public GameObject[] variationsOfPacMan;
    // public int VariationsOfGame;
    public int RandomRoom;
    public float startWaitTime;
    private float waitTime;
    private GameObject aux;
    [Header("Jogo")]
    public int ChamadosCompletos;
    public int ChamadosFalhados;
    public bool Blocked = false;
    private TimeScript Timer;

    [Header("Telas")]
    public Camera MainCamera;
    public GameObject World;
    public Camera PacManCamera;
    private GameObject PacmanCanvas; 
    [Header("Prefab Minigames")]
    public GameObject PacMan1;
    public GameObject PacMan2;
    public GameObject PacMan3;
    public GameObject Wires1;
    public GameObject Wires2;
    public GameObject Wires3;
    [Header("UI Minigames")]

    public GameObject Sucesso;
    public GameObject Falha;
    public GameObject Fim;
    public Transform SpawnMinigame;
    void Start() {
        Timer = GetComponent<TimeScript>();
        aux = new GameObject();
        Sucesso.SetActive(false);
        Falha.SetActive(false);
        Fim.SetActive(false);
        Debug.Log("Começou...");

        waitTime = startWaitTime;
        RandomRoom = Random.Range(0, myCanvas.Length);
        TypeOfGame = Random.Range(0, 2);
        if(TypeOfGame == 0){
            myCanvas[RandomRoom].transform.Find ("VirusError").gameObject.SetActive(false);
            myCanvas[RandomRoom].transform.Find ("InternetError").gameObject.SetActive(true);
        }else {
            myCanvas[RandomRoom].transform.Find ("InternetError").gameObject.SetActive(false);
            myCanvas[RandomRoom].transform.Find ("VirusError").gameObject.SetActive(true);
        }
        myCanvas[RandomRoom].gameObject.SetActive(true);
        myRooms[RandomRoom].SendMessage("setState", true, SendMessageOptions.DontRequireReceiver);
    }

    // Update is called once per frame
    void Update() {
        if(waitTime < 0){
            myCanvas[RandomRoom].gameObject.SetActive(false);
            myRooms[RandomRoom].SendMessage("setState", false, SendMessageOptions.DontRequireReceiver);
            RandomRoom = Random.Range(0, myCanvas.Length);
            TypeOfGame = Random.Range(0, 2);
            if(TypeOfGame == 0){
                myCanvas[RandomRoom].transform.Find ("VirusError").gameObject.SetActive(false);
                myCanvas[RandomRoom].transform.Find ("InternetError").gameObject.SetActive(true);
            }else {
                myCanvas[RandomRoom].transform.Find ("InternetError").gameObject.SetActive(false);
                myCanvas[RandomRoom].transform.Find ("VirusError").gameObject.SetActive(true);
            }
            Debug.Log(RandomRoom);
            myCanvas[RandomRoom].gameObject.SetActive(true);
            myRooms[RandomRoom].SendMessage("setState", true, SendMessageOptions.DontRequireReceiver);
            waitTime = startWaitTime;
        }else {
            waitTime -= Time.deltaTime;
        }

        if(Timer.tempoRestante <= 0){
            StartCoroutine(FimDeJogo());
        }
    }

    
    public void DesativaMinigame(){
        Destroy(aux);
        
        MainCamera.gameObject.tag = "MainCamera";
        MainCamera.gameObject.SetActive(true);
        World.gameObject.SetActive(true);
        Blocked = false;
    }
    public void MinigameConcluido(){
        ChamadosCompletos += 1;
        StartCoroutine(MostrarSucesso());
    }
    public void MinigameFalho(){
        ChamadosFalhados += 1;
        StartCoroutine(MostrarSucesso());
    }
    public void AtivaMinigame(){
        int variation;
        if(TypeOfGame == 0){
            if(!GameObject.Find("Wires Camera(Clone)")){
                variation = Random.Range(0, variationsOfWire.Length);
                aux = Instantiate(variationsOfWire[variation],SpawnMinigame.position,Quaternion.identity);
            }else{
                aux = GameObject.Find("Wires Camera(Clone)");
                PacManCamera = aux.GetComponent<Camera>();
                PacmanCanvas = GameObject.Find("Wires");
                MainCamera = GameObject.Find("MainCamera").GetComponent<Camera>();

                PacManCamera.gameObject.tag = "MainCamera";
                PacManCamera.gameObject.SetActive(true);
                MainCamera.gameObject.tag = "Untagged";
                MainCamera.gameObject.SetActive(false);
                World.gameObject.SetActive(false);
                PacmanCanvas.gameObject.SetActive(true);
            }
        }else{
            if(!GameObject.Find("PacMan Camera(Clone)")) {
                variation = Random.Range(0, variationsOfPacMan.Length + 1);
                aux = Instantiate(variationsOfPacMan[variation],SpawnMinigame.position,Quaternion.identity);
            }else{
                aux = GameObject.Find("PacMan Camera(Clone)");
                PacManCamera = aux.GetComponent<Camera>();
                PacmanCanvas = GameObject.Find("PacMan");
                MainCamera = GameObject.Find("MainCamera").GetComponent<Camera>();

                PacManCamera.gameObject.tag = "MainCamera";
                PacManCamera.gameObject.SetActive(true);
                MainCamera.gameObject.tag = "Untagged";
                MainCamera.gameObject.SetActive(false);
                World.gameObject.SetActive(false);
                PacmanCanvas.gameObject.SetActive(true);
            }
        }
    }
    

    public IEnumerator MostrarSucesso(){
        Sucesso.SetActive(true);
        yield return new WaitForSeconds(1f);
        DesativaMinigame();
        Sucesso.SetActive(false);
    }
    public IEnumerator MostrarFalha(){
        Falha.SetActive(true);
        yield return new WaitForSeconds(1f);
        DesativaMinigame();
        Falha.SetActive(false);
    }
    public IEnumerator FimDeJogo(){
        Fim.SetActive(true);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Menu");
    }
}
