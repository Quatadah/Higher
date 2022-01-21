using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using pc = PlayerController;
using TMPro;

public class CameraController : MonoBehaviour
{
    public TextMeshPro score;
    public double scoreCounter = 0f;
    public TextMeshProUGUI yourScore;
    private float maxspeed = 0.025f;
    private float speed = 0.008f;
    private float acceleration = 0.0000001f;
    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + speed, transform.position.z);
        if (pc.ended){
            Debug.Log("the game is over from camera");
        }else{
            scoreCounter += 0.01f;
        }
        score.text = "" + (int)scoreCounter;
        yourScore.text = "Your score : " + (int)scoreCounter;
        
        if (speed <= maxspeed){
            speed += acceleration;
        }
    }
}
