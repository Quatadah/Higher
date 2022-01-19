using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CameraController : MonoBehaviour
{
    public TextMeshPro score;
    public double scoreCounter = 0f;
    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + 0.05f, transform.position.z);
        scoreCounter += 0.01f;
        score.text = "" + (int)scoreCounter;
    }
}
