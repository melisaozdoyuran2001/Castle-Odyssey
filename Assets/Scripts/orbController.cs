using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class orbController : MonoBehaviour
{
    public GameObject scorePrefab; 
    [SerializeField] private AudioClip enemyDeathSoundEffect;

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "enemy") {
            Destroy(other.gameObject); 
            ScoreManager.Instance.IncreaseScore(); 
            PlayDeathSound();
        }
        Destroy(gameObject); 
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "odz") {
            Destroy(gameObject);
        }
    }

    private void PlayDeathSound() {
        AudioSource.PlayClipAtPoint(enemyDeathSoundEffect, transform.position);
    }
}

