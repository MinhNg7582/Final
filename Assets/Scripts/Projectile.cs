using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float bulletSpeed;
    public Rigidbody2D rb;

    public GameObject ExplosionEffect;

    // Start is called before the first frame update
    private void Awake()
    {
        Destroy(gameObject, 3f);
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * bulletSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Obstacles")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "Enemy")
        {
            AudioManager.instance.PlaySound(0);
            Instantiate(ExplosionEffect, transform.position, Quaternion.identity);

            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
