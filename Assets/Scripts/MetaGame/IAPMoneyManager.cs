using UnityEngine;
using UnityEngine.Purchasing;

namespace MetaGame
{
    public class IAPMoneyManager : MonoBehaviour
    {
        public void OnCoinsPurchased()
        {
            // int purchasedCoinsValue = int.Parse(b.descriptionText.text);
            int purchasedCoinsValue = 100; //TODO: fix
            Debug.Log("Player purchased coins: " + purchasedCoinsValue);
            int newCoinsValue = GameSaveManager.instance.AddCoins(purchasedCoinsValue);
            MetaEvents.UpdateCoinsEvent(newCoinsValue);
        }
    }
}
