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
        StartCoroutine(LoadAssetBundle(bundleURL));
    }

    private IEnumerator LoadAssetBundle(string bundleURL)
    {
        UnityWebRequest webRequest = UnityWebRequestAssetBundle.GetAssetBundle(bundleURL);

        yield return webRequest.SendWebRequest();

        Bundle = ((DownloadHandlerAssetBundle)webRequest.downloadHandler).assetBundle;

        GameObject gameObject = Bundle.LoadAsset("Cylinder") as GameObject;
        Instantiate(gameObject);
    }
}
