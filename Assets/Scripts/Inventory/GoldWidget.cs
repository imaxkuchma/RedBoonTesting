using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GoldWidget : MonoBehaviour
{
    private static GoldWidget m_instance;

    public static GoldWidget Instance => m_instance;

    [SerializeField] private TextMeshProUGUI m_goldAmountText;

    private int m_currentAmountGold;

    public int AmountGold => m_currentAmountGold;

    private void Awake()
    {
        if(m_instance != null && m_instance != this)
        {
            Destroy(m_instance.gameObject);
        }
        m_instance = this;
    }

    public void Init(int amount)
    {
        m_currentAmountGold = amount;
        UpdateUI();
    }

    public void AddGold(int amount)
    {
        m_currentAmountGold += amount;
        UpdateUI();
    }

    public bool TrySpendGold(int amount)
    {
        if(m_currentAmountGold >= amount)
        {
            m_currentAmountGold -= amount;
            UpdateUI();
            return true;
        }
        else
        {
            return false;
        }   
    }

    private void UpdateUI()
    {
        m_goldAmountText.text = $"Gold: {m_currentAmountGold}";
    }
}
