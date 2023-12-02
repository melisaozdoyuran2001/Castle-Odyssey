using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class orbController : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "enemy") {
            Destroy(other.gameObject); 
        }
        Destroy(gameObject); 
    }
}
