using UnityEngine;

public abstract class EnemyBase : MonoBehaviour
{
    [Header("Base Stats")]
    public float maxHealth = 100f;
    protected float currentHealth;
    [SerializeField] public int maxKilledCount;
    [SerializeField] private Transform CoinModel;
    private static int currentKilledCount;


    protected Transform player;
    protected bool isDead = false;

    protected virtual void Start()
    {
        currentHealth = maxHealth;
        currentKilledCount = 0;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public virtual void TakeDamage(float amount)
    {
        if (isDead) return;

        currentHealth -= amount;
        if (currentHealth <= 0)
            Die();
    }

    protected virtual void Die()
    {
        isDead = true;
        Destroy(gameObject);
            currentKilledCount++;
        Debug.Log(currentKilledCount);
        if (currentKilledCount == maxKilledCount)
        {
            currentKilledCount = 0;
            DropCoin();
        }
    }

    public void DropCoin()
    {
        Instantiate(CoinModel, transform.position, Quaternion.identity);
    }


    public abstract void Attack();
}

