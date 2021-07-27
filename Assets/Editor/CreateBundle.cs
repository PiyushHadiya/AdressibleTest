using UnityEngine;
using UnityEditor;
using System.IO;

public class CreateBundle
{
    [MenuItem("Assets/Build AssetBundle")]
    static void BuildAllAssetBundles()
    {
        string assetBundleDirectory = @"D:\StandaloneWindows64\";
        if (!Directory.Exists(Application.streamingAssetsPath))
        {
            Directory.CreateDirectory(assetBundleDirectory);
        }
        BuildPipeline.BuildAssetBundles(assetBundleDirectory, BuildAssetBundleOptions.ChunkBasedCompression, BuildTarget.StandaloneWindows64);
    }
}