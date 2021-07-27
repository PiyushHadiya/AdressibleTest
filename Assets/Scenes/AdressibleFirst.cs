using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class AdressibleFirst : MonoBehaviour
{
    public AssetReference Asset;
    public string Name;
    private void Start()
    {
        Asset.InstantiateAsync();
        Debug.Log("Complete");
        //Get();
    }

    private void AdressibleFirst_Completed(UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle<GameObject> obj)
    {
        Debug.Log("Complete");
    }

    private async void Get()
    {
        var location = await Addressables.LoadResourceLocationsAsync(Name).Task;
        foreach (var item in location)
        {
            await Addressables.InstantiateAsync(item).Task;
        }
    }
}
