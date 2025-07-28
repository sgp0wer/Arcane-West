using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class BulletProjectile : MonoBehaviour
{

    [SerializeField] private Transform vfxHitGreen;
    [SerializeField] private Transform vfxHitRed;
    [SerializeField] public float bulletDamage = 25f;
    private Rigidbody bulletRigidbody;


    private void Awake()
    {
        bulletRigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        float speed = 50f;
        bulletRigidbody.linearVelocity = transform.forward * speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<BulletTarget>() != null)
        {
            Instantiate(vfxHitGreen, transform.position, Quaternion.identity);
            MeleeEnemy enemy = other.GetComponent<MeleeEnemy>();
            if (enemy != null)  
        {
            enemy.TakeDamage(bulletDamage);
        }
        }

        else
        {
            Instantiate(vfxHitRed, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }
}
