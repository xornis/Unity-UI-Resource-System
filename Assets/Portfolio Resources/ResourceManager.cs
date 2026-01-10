using UnityEngine;
using System.Collections.Generic;

public class ResourceManager : MonoBehaviour
{
    [SerializeField] private ResourceEvents resourceEvents;

    [System.Serializable]
    public struct ResourceSetup
    {
        public ResourceType type;
        public int maxValue;
    }

    [SerializeField] private List<ResourceSetup> initialResourceSetup;

    private Dictionary<ResourceType, ResourceData> resources = new();

    private void Awake()
    {
        foreach (var resource in initialResourceSetup)
            resources[resource.type] = new(resource.maxValue, resource.maxValue, 0);
    }
    private void Start()
    {
        foreach (var resource in resources)
            resourceEvents.CallResourceChanged(resource.Key, resource.Value);
    }

    public void ChangeResource(ResourceType type, int amount)
    {
        if (resources.TryGetValue(type, out ResourceData data))
        {
            data.current += amount;
            data.delta = amount;
            resources[type] = data;

            resourceEvents.CallResourceChanged(type, data);
        }
    }
}
