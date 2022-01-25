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
        if (!(Camera.main.gameObject.transform.position.y > transform.position.y + 20)) {
            gameOver.gameObject.SetActive(false);
            restart.gameObject.SetActive(false);
            back.gameObject.SetActive(false);
            ended = false;
        }else{
            gameOver.gameObject.SetActive(true);
            restart.gameObject.SetActive(true);
            back.gameObject.SetActive(true);
            ended = true;
        }
    }
}
