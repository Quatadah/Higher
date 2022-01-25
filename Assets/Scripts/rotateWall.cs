using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateWall : MonoBehaviour
{
    public float rotationSpeed = 0.1f;
    public float rotation;
    void Start(){
        rotation = transform.rotation.z;
    }
    void Update()
    {
        //randomlyRotate();
    }
    void randomlyRotate(){
        int sign = Random.Range(-1, 1);
        rotation += rotationSpeed;
        transform.Rotate(0, 0, -1 * rotation * Time.deltaTime);
    }
}
