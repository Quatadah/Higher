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

    private void Start() {
        InvokeRepeating("addWalls", 0.0f, 1.0f);
    }
    void Update(){
        

    }

    void addWalls(){
        y += wallPrefab.transform.position.y;
        y += Random.Range(2, 5);
        positionRight = new Vector3(xEdge, y ,wallPrefab.transform.position.z);
        Instantiate(wallPrefab, positionRight , wallPrefab.transform.rotation);
        y += Random.Range(2, 5);    
        positionLeft = new Vector3(-xEdge, y ,wallPrefab.transform.position.z);
        Instantiate(wallPrefab, positionLeft , wallPrefab.transform.rotation);
    }



}
