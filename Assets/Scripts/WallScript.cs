using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallScript : MonoBehaviour
{
    private void Update() {
        if (Camera.main.gameObject.transform.position.y > transform.position.y + 10){
            Destroy(gameObject);
        }
    }
}
