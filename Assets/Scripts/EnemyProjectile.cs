using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public float speed;


    private void Awake()
    {
        Destroy(gameObject, 3f);
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" ) 
        {
            PlayerHealth.instance.DealDamage();
            AudioManager.instance.PlaySound(2);

            Destroy(gameObject);
        }
    }
}
