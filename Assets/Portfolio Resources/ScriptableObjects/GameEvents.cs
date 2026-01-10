using UnityEngine;

[CreateAssetMenu(fileName = "GameEvents", menuName = "Scriptable Objects/UnityUIResourceSystem/GameEvents")]
public class GameEvents : ScriptableObject
{
    public event System.Action<ResourceType, ResourceData> OnResourceChanged;

    public void CallResourceChanged(ResourceType type, ResourceData data) => OnResourceChanged?.Invoke(type, data);
}