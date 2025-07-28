using UnityEngine;
using TMPro;
using StarterAssets;

public class BonusShopTrigger : MonoBehaviour
{
    [Header("Настройки бонуса")]
    public int bonusIndex; // 0–4
    public TextMeshPro levelText;

    private ShopManager shopManager;

    private void Start()
    {
        shopManager = FindFirstObjectByType<ShopManager>();
        UpdateLevelText();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth player = other.GetComponent<PlayerHealth>();
            ThirdPersonController sprintSpeed = other.GetComponent<ThirdPersonController>();
            ThirdPersonController jumpHeight = other.GetComponent<ThirdPersonController>();


            if (player == null || shopManager == null) return;

            int cost;
            bool upgraded = shopManager.TryUpgrade(bonusIndex, player.Money, out cost);

            if (upgraded)
            {
                player.SpendMoney(cost);
                UpdateLevelText();
                Debug.Log($"Бонус {bonusIndex} улучшен! Новый уровень: {shopManager.GetCurrentLevel(bonusIndex)}");

                // Если игрок прокачивает Здоровье
                if (bonusIndex == 0)
                {
                    int newLevel = shopManager.GetCurrentLevel(bonusIndex);
                    player.ApplyHealthUpgrade(newLevel);
                    
                }

                // Если игрок прокачивает Спринт
                if (bonusIndex == 1)
                {
                    int newLevel = shopManager.GetCurrentLevel(bonusIndex);
                    sprintSpeed.ApplySprintSpeedUpgrade(newLevel);
                }

                // Если игрок прокачивает Прыжок
                if (bonusIndex == 2)
                {
                    int newLevel = shopManager.GetCurrentLevel(bonusIndex);
                    jumpHeight.ApplyJumpHeightUpgrade(newLevel);

                }

                // Если игрок прокачивает Дебафы оружия
                if (bonusIndex == 3)
                {

                }

                 // Если игрок прокачивает Уворот
                if (bonusIndex == 4)
                {

                } 
                
            }
            else
            {
                Debug.Log("Не хватает валюты или достигнут максимальный уровень.");
            }
        }


    }

    private void UpdateLevelText()
    {
        if (levelText != null)
        {
            int level = shopManager.GetCurrentLevel(bonusIndex);
            levelText.text = $"Уровень: {level + 1}";
        }
    }


}
