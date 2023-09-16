using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float maxDistance = 10f;
    public Vector3 startingPosition; 

    void Update()
    {
        float currentDistance = Vector3.Distance(startingPosition, transform.position);
        if (currentDistance > maxDistance)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) {
            gameObject.SetActive(false);
            collision.gameObject.SetActive(false);
        }
    }
}
