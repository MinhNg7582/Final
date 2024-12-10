using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePos;

    public float timeBetweenShot;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ShootRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePos.position, firePos.rotation);
    }

    IEnumerator ShootRoutine()
    {
        while (true)
        {
            Shoot();
            yield return new WaitForSeconds(timeBetweenShot);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            AudioManager.instance.PlaySound(0);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
