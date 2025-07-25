using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [Header("Характеристики игрока")]
    public float maxHealth = 100f;
    private float currentHealth;
    public float CurrentHealth => currentHealth;

    [Header("Валюта игрока")]
    public int Money { get; private set; } = 0;

    void Start()
    {
        currentHealth = maxHealth;
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
}