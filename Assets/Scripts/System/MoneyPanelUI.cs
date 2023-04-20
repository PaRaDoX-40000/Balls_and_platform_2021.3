using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyPanelUI : MonoBehaviour
{
    [SerializeField] TMP_Text _moneyText;

    public void SetMoneyText(int amountMoney)
    {
        _moneyText.text=amountMoney.ToString();
    }
}
