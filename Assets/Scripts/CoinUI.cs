using UnityEngine;
using TMPro;
public class CoinUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coinText;

    private void OnEnable()
    {
        PlayerOm.OnCoinCollected += UpdateCoinText;
    }

    private void OnDisable()
    {
        PlayerOm.OnCoinCollected -= UpdateCoinText;
    }

    private void UpdateCoinText(int totalCoins)
    {
        coinText.text = "Moedas: " + totalCoins;
    }
}
