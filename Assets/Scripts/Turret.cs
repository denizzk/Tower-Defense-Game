using UnityEngine;
using System.Collections;

public class Turret : MonoBehaviour {

    private Transform target;

    [Header("Attributes")]

    public float range = 15f;
    public float fireRate = 1f;
    private float fireCountdown = 0f;
    public bool useLaser = false;
    public LineRenderer lineRend;
    public float damagePerSec = 30f;
    public float slowPct = .3f;
    public ParticleSystem impactEffect;
    public ParticleSystem glow;
    public Light plight;


    [Header("Unity Setup")]

    public string enemyTag = "Enemy";

    public Transform partToRotate;
    public float turnSpeed = 10f;

    public GameObject bulletPrefab;
    public Transform firePoint;
    


	void Start () {
        InvokeRepeating("UpdateTarget", 0f, 0.1f);
	}
	
    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if(distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }
        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }
        else
            target = null;
    }

	void Update ()
    {
        if (target == null)
        {
            if (useLaser)
            {
                if (lineRend.enabled)
                {
                    lineRend.enabled = false;
                    impactEffect.Stop();
                    glow.Stop();
                    plight.enabled = false;
                }
            }
           return;
        }

        LockOnTarget();

        if (useLaser)
        {
            Laser();
            

        }
        else
        {
            if (fireCountdown <= 0f)
            {
                Shoot();
                fireCountdown = 1f / fireRate;
            }

            fireCountdown -= Time.deltaTime;

        }
    }

    void LockOnTarget()
    {
        
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    void Laser()
    {

        target.GetComponent<Enemy>().TakeDamage(damagePerSec * Time.deltaTime);
        target.GetComponent<Enemy>().Slow(slowPct);

        if (!lineRend.enabled)
        {
            lineRend.enabled = true;
            impactEffect.Play();
            glow.Play();
            plight.enabled = true;
        }
           
   
        lineRend.SetPosition(0, firePoint.position);
        lineRend.SetPosition(1, target.position);

        Vector3 dir = firePoint.position - target.position;
        impactEffect.transform.position = target.position + dir.normalized;
        impactEffect.transform.rotation = Quaternion.LookRotation(dir);
    }

    void Shoot()
    {
        GameObject bulletGO = (GameObject) Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();
        if(bullet != null)
        {
            bullet.Chase(target);
        }
            
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
