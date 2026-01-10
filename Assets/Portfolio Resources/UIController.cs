using TMPro;
using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public struct ResourceUIElement
{
    public ResourceType type;
    public TextMeshProUGUI text;
}

public class UIController : MonoBehaviour
{
    [SerializeField] private GameEvents gameEvents;
    [SerializeField] private ResourcePopupVisualSettings visualSettings;
    [SerializeField] private List<ResourceUIElement> uIElements;

    private void OnEnable() => gameEvents.OnResourceChanged += HandleResourceChange;
    private void OnDisable() => gameEvents.OnResourceChanged -= HandleResourceChange;

    private void HandleResourceChange(ResourceType type, ResourceData data)
    {
        foreach (var element in uIElements)
        {
            if (element.type == type)
            {
                UpdateResourceUI(element.text, data);
                break;
            }
        }
    }

    private void UpdateResourceUI(TextMeshProUGUI text, ResourceData data)
    {
        text.text = $"{data.current}/{data.max}";
        if (data.delta != 0) SpawnPopup(text.transform, data.delta);
    }

    private void SpawnPopup(Transform parent, int amount)
    {
        if (visualSettings.PopupPrefab == null) return;

        GameObject go = Instantiate(visualSettings.PopupPrefab, parent);

        go.transform.localPosition = RandomOffset(visualSettings.SpawnRadius);
        go.transform.localRotation = RandomTurn(visualSettings.Turn);

        var popup = go.GetComponent<ResourcePopup>();

        Color finalColor;
        if (amount > 0) finalColor = visualSettings.PositiveColor;
        else
        {
            float intensity = Mathf.InverseLerp(0, 5, Mathf.Abs(amount));
            finalColor = Color.Lerp(visualSettings.NegativeLight, visualSettings.NegativeDark, intensity);
        }

        popup.Initialization(amount, finalColor);
    }

    private Vector3 RandomOffset(float offsetRange)
    {
        float randomOffset = Random.Range(-offsetRange, offsetRange);
        return new Vector3(randomOffset, randomOffset, 0f);
    }

    private Quaternion RandomTurn(float turnRange)
    {
        float randomTurn = Random.Range(-turnRange, turnRange);
        return Quaternion.Euler(0f, 0f, randomTurn);
    }
}
