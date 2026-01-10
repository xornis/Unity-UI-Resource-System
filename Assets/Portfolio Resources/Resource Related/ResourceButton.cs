using UnityEngine;

public class ResourceButton : MonoBehaviour
{
    [SerializeField] private RunController runController;
    [SerializeField] private ResourceType type;
    [SerializeField] private int amount;

    public void ExecuteChange()
    {
        if (runController != null)
            runController.ChangeResource(type, amount);
    }
}
