using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using pc = PlayerController;

public class DragNshoot : MonoBehaviour
{
    public float slowDownFactor = 0.05f;
    public float slowDownLength = 2f;

    Vector2 startPos, endPos, direction;
    public float power = 0.1f;
    public Rigidbody2D rb;
    public LineRenderer lr;
    public bool stickedToWall = false;
    public Vector3 stickPosition;


    //can drag only 2 times before sticking to a wall
    private int canDragCounter = 0;
    public bool canDrag = true;
    Camera cam;
    private void Start() {
        cam = Camera.main;
        rb = gameObject.GetComponent<Rigidbody2D>();
        lr = gameObject.GetComponent<LineRenderer>();
    }

    private void Update() {
        if (stickedToWall){
            transform.position = stickPosition;
        }

        if (canDrag && !pc.ended){
            if (Input.GetMouseButtonDown(0)){
                startPos = cam.ScreenToWorldPoint(Input.mousePosition);
                if (Time.timeScale == 1.0f){
                    Time.timeScale = 0.5f ;
                }
                rb.velocity /= 2;
            }
            

            if (Input.GetMouseButton(0)){
                endPos = cam.ScreenToWorldPoint(Input.mousePosition);
                Vector2 _velocity = (startPos - endPos) * power;
                Vector2[] trajectory = Plot(rb, (Vector2)transform.position, _velocity, 100);
                lr.positionCount = trajectory.Length;
                Vector3[] positions = new Vector3[trajectory.Length];

                for (int i = 0; i < positions.Length; i++){
                    positions[i] = trajectory[i];                
                }
                lr.enabled = true;
                lr.SetPositions(positions);
            }

            if (Input.GetMouseButtonUp(0)){
                stickedToWall = false;
                endPos = cam.ScreenToWorldPoint(Input.mousePosition);
                Vector2 _velocity = (startPos - endPos) * power;
                rb.velocity = _velocity;
                Time.timeScale = 1.0f;
                lr.enabled = false;
                canDragCounter += 1;
                if (canDragCounter == 2){
                    canDragCounter = 0;
                    canDrag = false;
                }
        }   
            
        }

    }

    public Vector2[] Plot(Rigidbody2D rigidbody, Vector2 pos, Vector2 velocity, int steps){
        Vector2[] results = new Vector2[steps];

        float timestep = Time.fixedDeltaTime / Physics2D.velocityIterations;
        Vector2 gravityAccel = Physics2D.gravity * rigidbody.gravityScale * timestep * timestep;

        float drag = 1f - timestep * rigidbody.drag;
        Vector2 moveStep = velocity * timestep;

        for (int i = 0; i < steps; i++){
            moveStep += gravityAccel;
            moveStep *= drag;
            pos += moveStep;
            results[i] = pos;
        }

        return results;

    }

    private void OnCollisionEnter2D(Collision2D other) {        
        if (other.gameObject.CompareTag("Wall")){
            canDrag = true;
            canDragCounter = 0;
            stickedToWall = true;
            stickPosition = new Vector3(transform.position.x, 
                                        transform.position.y,
                                        transform.position.z);
        }
        
    }
/*
    private void OnTriggerEnter(Collider other) {
        Vector3 currentPos = transform.position;
        if(other.gameObject.CompareTag("Wall")){
            transform.position = currentPos;
        }
    }
*/

}
