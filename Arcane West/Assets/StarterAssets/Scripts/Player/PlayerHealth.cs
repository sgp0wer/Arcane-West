using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
     public float [] healthLevels = { 100f, 130f, 165f, 200f };
    private ShopManager shopManager;
    int hpUpgradeLevel = 0;

    [Header("Характеристики игрока")]
    public float maxHealth = 100f;
    private float currentHealth;
    public float CurrentHealth => currentHealth;

    [Header("Валюта игрока")]
    public int Money { get; private set; } = 0;


    
    void Start()
    {
        currentHealth = maxHealth;
        shopManager = FindFirstObjectByType<ShopManager>();
        if (shopManager != null)
            hpUpgradeLevel = shopManager.GetCurrentLevel(3);
        
        maxHealth = healthLevels[hpUpgradeLevel];
        currentHealth = maxHealth;
    }

    void Update()
    {
        
    }

    public void ApplyHealthUpgrade(int newLevel)
    {
    int level = shopManager.GetCurrentLevel(0); // индекс бонуса "здоровье"
    maxHealth = healthLevels[level];
    currentHealth = Mathf.Max(currentHealth, maxHealth);
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        Debug.Log("Player damaged! HP: " + currentHealth);

        if (currentHealth <= 0)
        {
            Debug.Log("Player is dead!");
            RestartScene();
        }
    }

    public void AddMoney(int amount)
    {
        Money += amount;
        Debug.Log("Player earned money! Total: " + Money);
    }

    private void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public bool SpendMoney(int amount)
    {
        if (Money >= amount)
        {
            Money -= amount;
            Debug.Log("ВВы проебали {amount} денег. Осталось {amount} денег");
            return true;
        }
        return false;
    }
}