using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private UnityEvent enemyDestroyed;
    [SerializeField] private UnityEvent earthDestroyed;

    // Start is called before the first frame update
    void Start()
    {
        enemyDestroyed.AddListener(GameController.Instance.IncreaseScore);
        enemyDestroyed.AddListener(UIController.Instance.UpdateScore);

        earthDestroyed.AddListener(UIController.Instance.EndGame);
        earthDestroyed.AddListener(GameController.Instance.EndGame);
    }

    private void Update()
    {
        if (transform.position.y < -10) { 
            gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            enemyDestroyed.Invoke();
            collision.gameObject.SetActive(false);
        }
        else if (collision.gameObject.CompareTag("Earth")) { 
            earthDestroyed.Invoke();
        }
    }

    public void EnemyDestroy() {
        gameObject.SetActive(false);
    }

    public void EarthDestroy() {
        Debug.Log("Earth Destroyed");
        gameObject.SetActive(false);
    }
}
