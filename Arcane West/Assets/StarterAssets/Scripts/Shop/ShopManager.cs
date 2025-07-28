using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public UpgradeData upgradeData;

    private int[] currentUpgradeLevels = new int[5];
    public int GetCurrentLevel(int bonusIndex)
    {
        return currentUpgradeLevels[bonusIndex];
    }

    public bool TryUpgrade(int bonusIndex, int playerMoney, out int cost)
    {
        int currentLevel = currentUpgradeLevels[bonusIndex];

        if (currentLevel >= 3)
        {
            cost = 0;
            return false; // уже максимальный уровень
        }

        cost = upgradeData.upgrades[bonusIndex].levelCosts[currentLevel];

        if (playerMoney >= cost)
        {
            currentUpgradeLevels[bonusIndex]++;
            return true;
        }

        return false; // недостаточно валюты    

    }   
}
