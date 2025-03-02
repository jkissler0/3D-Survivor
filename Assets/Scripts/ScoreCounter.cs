using TMPro;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    public TextMeshProUGUI eliminationsText; // Assign in the Inspector
    private int eliminations = 0;

    private void Start()
    {
        // Try to find the UI Text object automatically if not assigned
        if (eliminationsText == null)
        {
            eliminationsText = GameObject.Find("Eliminations").GetComponent<TextMeshProUGUI>();
        }

        UpdateEliminationsText();
    }

    public void AddElimination()
    {
        eliminations++;
        UpdateEliminationsText();
    }

    private void UpdateEliminationsText()
    {
        eliminationsText.text = "Eliminations: " + eliminations.ToString();
    }
}
