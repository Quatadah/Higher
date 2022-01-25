using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SpawnManager : MonoBehaviour
{
    
    public GameObject wallPrefab;
    float xEdge = 4.36f;
    float y;
    Vector3 positionRight;
    Vector3 positionLeft;
    Quaternion rotationLeft;
    Quaternion rotationRight;

    private void Start() {
        InvokeRepeating("addWalls", 0.0f, 1.0f);
    }

    void addWalls(){
        y += wallPrefab.transform.position.y;
        y += Random.Range(2, 5);
        positionRight = new Vector3(xEdge, y ,wallPrefab.transform.position.z);
        rotationLeft = new Quaternion();
        rotationRight = new Quaternion();
        rotationLeft = Quaternion.Euler(0, 0, Random.Range(-90, 90));
        rotationRight = Quaternion.Euler(0, 0, Random.Range(-90, 90));
        //rotationLeft.Set(0, 0, Random.Range(0f, PI/2), 0);
        //rotationRight.Set(0, 0, Random.Range(0f, PI/2), 0);
        Instantiate(wallPrefab, positionRight , rotationRight);
        y += Random.Range(2, 5);    
        positionLeft = new Vector3(-xEdge, y ,wallPrefab.transform.position.z);
        Instantiate(wallPrefab, positionLeft , rotationLeft);
    }



}
