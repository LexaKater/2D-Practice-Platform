using TMPro;
using UnityEngine;

public class WalletView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _coinView;
    [SerializeField] private Wallet _wallet;

    private void OnEnable() => _wallet.AmountChenged += ShowCoin;

    private void OnDisable() => _wallet.AmountChenged -= ShowCoin;

    private void ShowCoin() => _coinView.text = _wallet.CountCoin.ToString();
}
