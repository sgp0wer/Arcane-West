using UnityEngine;

[CreateAssetMenu(fileName = "UpgradeDataList", menuName = "StarterAssets/Scripts/Shop", order = 1)]
public class UpgradeData : ScriptableObject
{
    [System.Serializable]
    public class UpgradeInfo
    {
        public string bonusName;
        public int[] levelCosts = new int[4]; // 4 уровня прокачки
    }

    public UpgradeInfo[] upgrades = new UpgradeInfo[5]; // 5 бонусов
}
