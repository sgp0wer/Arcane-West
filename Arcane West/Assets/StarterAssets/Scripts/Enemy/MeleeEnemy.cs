using UnityEngine;
using UnityEngine.AI;

public class MeleeEnemy : EnemyBase
{
    [Header("Combat")]
    public float attackRange = 2f;
    public float attackCooldown = 2f;
    public float damage = 20f;


    [Header("Movement")]
    public float chaseRange = 15f;

    private NavMeshAgent agent;
    private float lastAttackTime;

    protected override void Start()
    {
        base.Start();
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (isDead || player == null) return;

        float distance = Vector3.Distance(transform.position, player.position);

        if (distance <= attackRange)
        {
            agent.isStopped = true;
            Attack();
        }
        else if (distance <= chaseRange)
        {
            agent.isStopped = false;
            agent.SetDestination(player.position);
        }

        
    }

    public override void Attack()
    {
        if (Time.time - lastAttackTime >= attackCooldown)
        {
            lastAttackTime = Time.time;
            player.GetComponent<PlayerHealth>()?.TakeDamage(damage);
        }
    }
}

