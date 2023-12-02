using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class orbController : MonoBehaviour
{
    public GameObject scorePrefab; 

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "enemy") {
            Destroy(other.gameObject); 
            ScoreManager.Instance.IncreaseScore(); 
        }
        Destroy(gameObject); 
    }
}
