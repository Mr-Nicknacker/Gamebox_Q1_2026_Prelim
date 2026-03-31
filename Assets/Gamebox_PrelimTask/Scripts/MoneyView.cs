using TMPro;
using UnityEngine;

public class MoneyView : MonoBehaviour
{
    [SerializeField] TMP_Text _moneyText;
    private void DisplayWallet(int moneyBalance)
    {
        _moneyText.text = moneyBalance.ToString();
    }
    private void OnEnable()
    {
        Wallet.OnBalanceUpdate += DisplayWallet;
    }
    private void OnDisable()
    {
        Wallet.OnBalanceUpdate -= DisplayWallet;
    }
}
