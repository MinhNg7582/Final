using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth;

    public static PlayerHealth instance;

    public HealthBar healthBar;

    public SpriteRenderer sr;

    public void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(currentHealth);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DealDamage()
    {
        currentHealth -= 1;
        StartCoroutine(BloodEffect());

        healthBar.SetHealth(currentHealth);

        if(currentHealth <= 0)
        {
            Die();
        }
    }

    IEnumerator BloodEffect()
    {
        sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 0.2f);
        yield return new WaitForSeconds(1);
        sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 0f);
    }

    void Die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
