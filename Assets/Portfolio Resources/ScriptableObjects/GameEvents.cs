using System;
using UnityEngine;

[CreateAssetMenu(fileName = "GameEvents", menuName = "Scriptable Objects/UnityUIResourceSystem/GameEvents")]
public class GameEvents : ScriptableObject
{
    public event Action<ResourceData> OnStepsChanged;
    public event Action<ResourceData> OnFishingAttemptsChanged;

    public void CallStepsChanged(ResourceData data) => OnStepsChanged?.Invoke(data);
    public void CallFishingAttemptsChanged(ResourceData data) => OnFishingAttemptsChanged?.Invoke(data);
}
