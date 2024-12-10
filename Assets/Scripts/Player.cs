using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float movementSpeed;
    private Rigidbody2D rb;
    private float direction;
    public float bonusTime;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        direction = Input.GetAxis("Vertical");
        rb.velocity = new Vector2(rb.velocity.x, direction * movementSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bonus")
        {
            Destroy(collision.gameObject);
            StartCoroutine(BonusTime());
        }
    }

    IEnumerator BonusTime()
    {
        Shooting.instance.timeBetweenShots -= 0.5f;
        yield return new WaitForSeconds(bonusTime);
        Shooting.instance.timeBetweenShots += 0.5f;
    }
}
