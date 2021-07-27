using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class AssetBundleLoader : MonoBehaviour
{
    public AssetBundle Bundle;
    public string bundleURL = "D:/StandaloneWindows64/";
    private void Start()
    {
        LoadAssetBundle(bundleURL);
    }

    private void LoadAssetBundle(string bundleURL)
    {
        Bundle = AssetBundle.LoadFromFile(bundleURL);
    }
}
