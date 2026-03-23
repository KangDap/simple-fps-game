using UnityEngine;
using TMPro;

public class HitsCounter : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI hitsText;

    private int totalHits = 0;

    void Start()
    {
        UpdateText();
    }

    public void addHit()
    {
        totalHits++;
        UpdateText();
    }

    void UpdateText()
    {
        hitsText.text = $"Hits: {totalHits}";
    }
}
