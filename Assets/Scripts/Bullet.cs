using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Diagnostics;

public class Bullet : MonoBehaviour
{
    [SerializeField] float maxDistance = 10f;
    [SerializeField] private ParticleSystem explosionParticle; 
    public Vector3 startingPosition;

    void Update()
    {
        float currentDistance = Vector3.Distance(startingPosition, transform.position);
        if (currentDistance > maxDistance)
        {
            gameObject.SetActive(false);
        }
    }

    public void Setup(Vector3 shootDir) {
        float angle = Mathf.Atan2(shootDir.y, shootDir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle - 90);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) {
            Explosion();
        }
    }

    void Explosion() {
        GameObject explosion = ObjectPool.Instance.GetParticle();
        explosion.transform.position = transform.position;
        explosion.GetComponent<ParticleSystem>().Play();
    }
}
