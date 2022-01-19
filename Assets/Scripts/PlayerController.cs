using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using static CameraController;

public class PlayerController : MonoBehaviour
{
    public TextMeshProUGUI gameOver;    
    public Button restart;
    public Button back;
    public static bool ended;

    void Start(){
        gameOver.gameObject.SetActive(false);
        restart.gameObject.SetActive(false);
        back.gameObject.SetActive(false);
        ended = false;
    }

    void Update()
    {    
        if (GetComponent<Renderer>().isVisible) {
            Debug.Log("visible");
            gameOver.gameObject.SetActive(false);
            restart.gameObject.SetActive(false);
            back.gameObject.SetActive(false);
            ended = true;
        }else{
            Debug.Log("Invisible");
            gameOver.gameObject.SetActive(true);
            restart.gameObject.SetActive(true);
            back.gameObject.SetActive(true);
        }
    }
}
