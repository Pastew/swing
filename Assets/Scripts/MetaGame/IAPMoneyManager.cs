using UnityEngine;
using UnityEngine.Purchasing;

namespace MetaGame
{
    public class IAPMoneyManager : MonoBehaviour
    {
        public void OnCoinsPurchased(IAPButton b)
        {
            int purchasedCoinsValue = int.Parse(b.descriptionText.text);
            Debug.Log("Player purchased coins: " + purchasedCoinsValue);
            int newCoinsValue = GameSaveManager.instance.AddCoins(purchasedCoinsValue);
            MetaEvents.UpdateCoinsEvent(newCoinsValue);
        }
    }
}
