using TMPro;
using UnityEngine;

public class ResourcePopup : MonoBehaviour
{
    [SerializeField] private ResourcePopupVisualSettings visualSettings;

    private TextMeshProUGUI popupText;
    private float timer;
    private Vector3 direction;

    public void Initialization(int amount, Color color)
    {
        popupText = GetComponent<TextMeshProUGUI>();
        popupText.text = amount > 0 ? $"(+{amount})" : $"({amount.ToString()})";
        popupText.color = color;

        direction = amount > 0 ? Vector3.up : Vector3.down;

        transform.localScale = Vector3.one * visualSettings.StartScaleMultiplier;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        float progress = timer / visualSettings.Duration;

        transform.localPosition += direction * visualSettings.Speed * Time.deltaTime;

        transform.localScale = Vector3.Lerp(Vector3.one * visualSettings.StartScaleMultiplier, Vector3.one / visualSettings.EndScaleDivider, progress);

        if (popupText != null)
        {
            Color color = popupText.color;
            color.a = Mathf.Lerp(1f, 0f, progress);
            popupText.color = color;
        }

        if (timer >= visualSettings.Duration) Destroy(gameObject);
    }
}
