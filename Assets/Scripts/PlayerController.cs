using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Transform shootingPivot;
    [SerializeField] private float timeBetweenFiring;
    [SerializeField] private float power;

    [SerializeField] private Animator gunAnimator;

    private Vector2 direction;
    private float timer;
    private bool canFire = true;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (!(GameController.Instance.isPaused || GameController.Instance.isEnded))
        {
            AimRotation();
            Shoot();
        }
    }

    void AimRotation() {
        direction = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }

    void Shoot() {
        if (!canFire) {
            timer += Time.deltaTime;
            if (timer > timeBetweenFiring) {
                timer = 0;
                canFire = true;
            }
            gunAnimator.SetBool("Shoot", false);
        }

        if (Input.GetMouseButton(0) && canFire) { 
            canFire = false;

            GameObject bullet = ObjectPool.Instance.GetPooledBullet();

            if (bullet != null) { 
                gunAnimator.SetBool("Shoot", true);
                
                bullet.transform.position = shootingPivot.position;
                bullet.GetComponent<Bullet>().startingPosition = shootingPivot.position;
                bullet.GetComponent<Bullet>().Setup(direction);
                bullet.SetActive(true);
                bullet.GetComponent<Rigidbody2D>().AddForce(direction.normalized * power, ForceMode2D.Impulse);
               
            }
        }
    }

}
