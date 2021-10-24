using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using Custom.TouchRotation;
using Lean.Touch;
using UnityEditor;
using UnityEngine;
using SFB;
using UnityEngine.Rendering;


public class ModelUploader : MonoBehaviour
{
    private string path;
    [SerializeField] private GameObject currentModel;
    public async void UploadModel()
    {
        
        path = StandaloneFileBrowser.OpenFilePanel("Выберите файл IFC для импорта:", "", "ifc", false)[0];
         if (!string.IsNullOrEmpty(path))
         {
             if (currentModel != null) Destroy(currentModel);
             currentModel = IfcImporter.RuntimeImport(path);
             SetModel();
         }
    }

    private IEnumerator ImportModel(Action onFinish)
    {
        
        yield return null;
    }

    public void SetModel()
    {
        currentModel.AddComponent<ModelRotationOneFinger>();
        currentModel.AddComponent<LeanPinchScale>();
    }
}
