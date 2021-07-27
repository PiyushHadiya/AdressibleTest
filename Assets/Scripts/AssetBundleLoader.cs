using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using UnityEngine;
using UnityEngine.Networking;

public class AssetBundleLoader : MonoBehaviour
{
    public AssetBundle Bundle;
    public string bundleURL = "D:/StandaloneWindows64/";
    //https://firebasestorage.googleapis.com/v0/b/fir-two-1aeaa.appspot.com/o/StandaloneWindows64%2Fcontainer?alt=media&token=790240c4-c429-418d-8f72-17888a1c67da
    private void Start()
    {
        StartCoroutine(LoadAssetBundle(bundleURL));
    }

    private IEnumerator LoadAssetBundle(string bundleURL)
    {
        UnityWebRequest webRequest = UnityWebRequestAssetBundle.GetAssetBundle(bundleURL);
        yield return webRequest.SendWebRequest();
        
        var downloadHandle = ((DownloadHandlerAssetBundle)webRequest.downloadHandler);
        Bundle = downloadHandle.assetBundle;

        string tempPath = Path.Combine(Application.persistentDataPath, "AssetBundles", "container");
        byte[] assetBundleData = downloadHandle.data;

        SaveAssetBundel(tempPath, assetBundleData);

        GameObject gameObject = Bundle.LoadAsset("Cylinder") as GameObject;
        Instantiate(gameObject);
    }

    private void SaveAssetBundel(string path, byte[] assetBundleData)
    {
        if (!Directory.Exists(Path.GetDirectoryName(path)))
        {
            Directory.CreateDirectory(Path.GetDirectoryName(path));
        }

        try
        {
            File.WriteAllBytes(path, assetBundleData);
        }
        catch (System.Exception)
        {
            Debug.Log("Failed to Save AssetBundel!");
        }
    }
}
