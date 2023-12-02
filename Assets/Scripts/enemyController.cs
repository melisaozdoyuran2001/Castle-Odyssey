using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class enemyController : MonoBehaviour
{
    public float moveDistance = 3.0f; 
    public float speed = 2.0f;
    public float direction = 1.0f; 
    private float moved = 0.0f; 
    void Update()
    {
        float moveThisFrame = speed * Time.deltaTime * direction;
        moved += Mathf.Abs(moveThisFrame);
        transform.Translate(moveThisFrame, 0, 0);

        if (moved >= moveDistance)
        {
            direction *= -1;
            moved = 0; 
            Vector3 newScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z); 
            transform.localScale = newScale; 
        }
    }
}
