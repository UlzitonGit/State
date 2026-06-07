using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HUD: MonoBehaviour
{
   [SerializeField] private TextMeshProUGUI stateText;
   [SerializeField]  private Canvas canvas;
    
    public void UpdateStateText(string stateName)
    {
        if (stateText != null)
            stateText.text = $"State: {stateName}";
    }
    
}