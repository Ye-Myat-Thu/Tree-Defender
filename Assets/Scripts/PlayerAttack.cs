using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    //public float attackCooldown;
    //public Transform firePoint;
    //public GameObject[] Cherry;

    //private PlayerMovement playerMovement;
    //private float cooldownTimer = Mathf.Infinity;

    //private void Start()
    //{
    //    playerMovement = GetComponent<PlayerMovement>();
    //}

    //private void Update()
    //{
    //    if(Input.GetMouseButton(0) && cooldownTimer > attackCooldown && playerMovement.canAttack())
    //        Attack();

    //    cooldownTimer += Time.deltaTime;
    //}

    //private void Attack()
    //{
    //    cooldownTimer = 0;
    //    Cherry[0].transform.position = firePoint.position;
    //    Cherry[0].GetComponent<Projectile>().SetDirection(Mathf.Sign(transform.localScale.x));

    //}

    public float attackCooldown = 1f;
    public Transform firePoint;
    public GameObject cherryPrefab;

    private float lastShotTime;

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time >= lastShotTime + attackCooldown)
        {
            Shoot();
            lastShotTime = Time.time;
        }
    }

    void Shoot()
    {
        Instantiate(cherryPrefab, firePoint.position, firePoint.rotation);
    }
}
