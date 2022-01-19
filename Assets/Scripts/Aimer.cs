using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aimer : MonoBehaviour
{

    public bool isAiming = false;
    Vector3 startPos, currentPos, endPos;
    Rigidbody2D rb;
    Camera cam;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)){
            startAiming();
        }
        else if (Input.GetMouseButtonUp(0)){
            stopAiming();
        }
        if (isAiming){
            updateAiming();
        }
    }

    void startAiming(){
        isAiming = true;
        startPos = cam.ScreenToWorldPoint(Input.mousePosition);
        currentPos = startPos;
    }

    void stopAiming(){
        isAiming = false;
    }

    void updateAiming(){
        currentPos = cam.ScreenToWorldPoint(Input.mousePosition);
        rb.position = startPos - currentPos;
    }
}
