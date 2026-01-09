using UnityEngine;

public struct ResourceData
{
    public int current;
    public int max;
    public int delta;

    public ResourceData(int current, int max, int delta)
    {
        this.current = current;
        this.max = max;
        this.delta = delta;
    }
}

public class RunController : MonoBehaviour
{
    [Header("Events")]
    [SerializeField] private GameEvents gameEvents;

    [Header("Settings")]
    [SerializeField] private int maxSteps = 10;
    [SerializeField] private int maxFishingAttempts = 5;

    private int stepsLeft;
    private int fishingAttemptsLeft;

    private void Start()
    {
        stepsLeft = maxSteps;
        fishingAttemptsLeft = maxFishingAttempts;

        gameEvents.CallStepsChanged(new ResourceData(stepsLeft, maxSteps, 0));
        gameEvents.CallFishingAttemptsChanged(new ResourceData(fishingAttemptsLeft, maxFishingAttempts, 0));
    }

    public void ChangeSteps(int amount)
    {
        stepsLeft += amount;
        gameEvents.CallStepsChanged(new ResourceData(stepsLeft, maxSteps, amount));
    }

    public void ChangeFishingAttempts(int amount)
    {
        fishingAttemptsLeft += amount;
        gameEvents.CallFishingAttemptsChanged(new ResourceData(fishingAttemptsLeft, maxFishingAttempts, amount));
    }
}
