using UnityEngine;
using UnityEngine.UI;

public class Wallet : MonoBehaviour
{
    public IntData walletData;
    public Text walletText;

    private void Start()
    {
        walletData.SetValue(30);
    }

    private void Update()
    {
        UpdateWalletText();
    }

    void UpdateWalletText()
    {
        walletText.text = walletData.value.ToString();
    }
}
