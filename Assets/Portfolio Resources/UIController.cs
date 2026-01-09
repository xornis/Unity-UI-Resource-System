using System.Collections;
using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [Header("Events")]
    [SerializeField] private GameEvents gameEvents;

    [Header("Settings")]
    [SerializeField] private TextMeshProUGUI stepsText;
    [SerializeField] private TextMeshProUGUI fishText;

    [Header("Popup Settings")]
    [SerializeField] private GameObject popupPrefab;
    [SerializeField] private Color positiveColor = new Color(0.35f, 1f, 0.3f);
    [SerializeField] private Color negativeLight = new Color(1f, 0.4f, 0.4f);
    [SerializeField] private Color negativeDark = new Color(0.5f, 0f, 0f);

    private void OnEnable()
    {
        gameEvents.OnStepsChanged += UpdateStepsUIText;
        gameEvents.OnFishingAttemptsChanged += UpdateFishUIText;
    }

    private void OnDisable()
    {
        gameEvents.OnStepsChanged -= UpdateStepsUIText;
        gameEvents.OnFishingAttemptsChanged -= UpdateFishUIText;
    }

    private void SpawnPopup(Transform parent, int amount)
    {
        if (popupPrefab == null) return;

        GameObject go = Instantiate(popupPrefab, parent);
        go.transform.localPosition = new Vector3(-45f, 0f, 0f);

        var popup = go.GetComponent<ResourcePopup>();

        Color finalColor;
        if (amount > 0) finalColor = positiveColor;
        else
        {
            float intensity = Mathf.InverseLerp(0, 5, Mathf.Abs(amount));
            finalColor = Color.Lerp(negativeLight, negativeDark, intensity);
        }

        popup.Initialization(amount, finalColor);
    }

    private void UpdateResourceUI(TextMeshProUGUI text, ResourceData data)
    {
        text.text = $"{data.current}/{data.max}";

        if (data.delta != 0) SpawnPopup(text.transform, data.delta);
    }

    private void UpdateStepsUIText(ResourceData data) => UpdateResourceUI(stepsText, data);
    private void UpdateFishUIText(ResourceData data) => UpdateResourceUI(fishText, data);
}
