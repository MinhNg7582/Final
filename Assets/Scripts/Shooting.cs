using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePos;
    public GameObject bullet;
    public float timeBetweenShots;
    public bool canShoot = true; 

    public static Shooting instance;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!PauseMenu.instance.isPaused)
        {
            if (Input.GetMouseButtonDown(0) && canShoot)
            {
                Shoot();
                AudioManager.instance.PlaySound(3);
            }
        }

    }

    public void Shoot()
    {
        Instantiate(bullet, firePos.position, firePos.rotation);
        StartCoroutine(ShootDelay());
    }

    IEnumerator ShootDelay()
    {
        canShoot = false;
        yield return new WaitForSeconds(timeBetweenShots);
        canShoot = true;
    }
}
