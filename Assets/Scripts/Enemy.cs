using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

    [HideInInspector]
    public float speed;

    public float startSpeed = 10f;
    public float health;
    public float startHealth = 100;
    public int cash = 50;

    public Image healthBar;
    public GameObject deathEffect;

    private Transform target;
    private int wavepointIndex = 0;

    public bool isDead = false;

    void Start()
    {
        target = Waypoints.points[0];
        speed = startSpeed;
        health = startHealth;
    }

    public void TakeDamage(float amount)
    {
        health -= amount;

        healthBar.fillAmount = health / startHealth;

        if (healthBar.fillAmount <= .5f && healthBar.fillAmount > .2f)
        {
            healthBar.color = Color.yellow;
        }
        else if (healthBar.fillAmount <= .2f)
            {
            healthBar.color = Color.red;
        }else
        {
            healthBar.color = Color.green;
        }
            
        

        if (health <= 0 && !isDead)
        {
            Die();
        }
    }
    public void Slow(float pct)
    {
        speed = startSpeed * (1f - pct);
    }

    void Die()
    {
        isDead = true;

        PlayerStats.money += cash;

        GameObject effect = (GameObject) Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);

        WaveSpawner.EnemyAlive--;
        Destroy(gameObject);
    }

    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if(Vector3.Distance(transform.position,target.position)<0.2)
        {
            GetNextWaypoint();
        }

        speed = startSpeed;
    }

    void GetNextWaypoint()
    {
        if(wavepointIndex >= Waypoints.points.Length-1)
        {
            EndPath();
        }
        wavepointIndex++;
        target = Waypoints.points[wavepointIndex];

       
    }

    void EndPath()
    {
        if(PlayerStats.lives>0)
        PlayerStats.lives--;

        WaveSpawner.EnemyAlive--;
        Destroy(gameObject);
    }
}
