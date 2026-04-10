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
        PlayerWallet.OnBalanceUpdate += DisplayWallet;
    }
    private void OnDisable()
    {
        PlayerWallet.OnBalanceUpdate -= DisplayWallet;
    }
}
