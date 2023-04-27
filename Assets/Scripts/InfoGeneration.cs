using OpenAi;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class InfoGeneration : MonoBehaviour
{
    public GameObject selectionUI, InfoUI;
    public static string question = "Generate any very short Information about Traffic Rules";
    public static string image = "Traffic Rules";

    public OpenAiImageReplace openAiImageReplace;
    private bool isPrefab = false;

    private void Start()
    {
        selectionUI.SetActive(true);
        InfoUI.SetActive(false);
    }

    public void SwitchScene()
    {
        selectionUI.SetActive(false);
        InfoUI.SetActive(true);
    }

    public void UpdateImage()
    {
        EditorGUI.BeginDisabledGroup(openAiImageReplace.requestPending);
        if (!checkPromt())
        {
            string assetPath = AssetDatabase.GetAssetPath(openAiImageReplace.gameObject);
            isPrefab = assetPath != "";

            if (isPrefab)
            {
                EditorUtility.SetDirty(openAiImageReplace);
                GameObject prefabRoot = PrefabUtility.LoadPrefabContents(assetPath);
                OpenAiImageReplace prefabTarget = prefabRoot.GetComponent<OpenAiImageReplace>();
                prefabTarget.ReplaceImage(() =>
                {
                    PrefabUtility.SaveAsPrefabAsset(prefabRoot, assetPath, out bool success);
                    PrefabUtility.UnloadPrefabContents(prefabRoot);
                });
            }
            else
            {
                openAiImageReplace.ReplaceImage();
            }
        }
    }

    public bool checkPromt()
    {
        bool promptShown = false;

        if (Configuration.GlobalConfig.ApiKey == "")
        {
            Configuration.GlobalConfig = OpenAiApi.ReadConfigFromUserDirectory();
            promptShown = true;

        }

        return promptShown;
    }
}
