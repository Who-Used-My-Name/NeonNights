using UnityEngine;
using TMPro;

public class BankrollUI : MonoBehaviour
{
    public TextMeshProUGUI bankrollText;

    //Add bankroll value to UI component
    void Update()
    {
        int bankroll = PlayerPrefs.GetInt("Bankroll", 0);
        bankrollText.text = "$"+bankroll.ToString();
    }
}