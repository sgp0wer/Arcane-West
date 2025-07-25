using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    [Header("UI элементы")]
    public Slider healthBar;
    public TextMeshProUGUI moneyText;

    private PlayerHealth player;

    void Start()
    {
        player = GetComponent<PlayerHealth>();
        if (player != null)
        {
            healthBar.maxValue = player.maxHealth;
            healthBar.value = player.maxHealth;
            UpdateMoney(player.Money);
        }
    }

    void Update()
    {
        if (player != null)
        {
            healthBar.value = player.CurrentHealth;
            moneyText.text = " " + player.Money;
        }
    }

    public void UpdateMoney(int amount)
    {
        if (moneyText != null)
            moneyText.text = " " + amount;
    }
}