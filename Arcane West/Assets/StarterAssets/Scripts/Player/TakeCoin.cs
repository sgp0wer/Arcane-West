using UnityEngine;

public class TakeCoin : MonoBehaviour
{
    [Header("Стоимость монеты")]
    public int coinCost = 300;

   private void OnTriggerEnter(Collider other)
{
    if (other.CompareTag("Player"))
    {
        PlayerHealth player = other.GetComponent<PlayerHealth>();
        if (player != null)
        {
            player.AddMoney(coinCost);
            Destroy(gameObject);
        }
    }
}
}
