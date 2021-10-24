using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

/*
 * Saves the GameObject as a prefab and deletes the GameObject. 
 * Only works in the editor because we use PrefabUtility.
 * Does not like the script created meshes IfcImporter.RuntimeImport() uses.
 * Usage: PrefabSaver.savePrefab()
 * Usually called from IfcProcessor.OnPostProcess() or IfcEditorExtension.OnGUI()
*/
public class PrefabSaver : MonoBehaviour
{
    public static void savePrefab(GameObject root_object, string assetPath)
    {
        //Save the prefab and get rid of the game object
        string prefab_path =  "Assets/" + System.IO.Path.GetFileNameWithoutExtension(assetPath) + ".prefab";
        PrefabUtility.SaveAsPrefabAsset(root_object, prefab_path);
        AssetDatabase.ImportAsset(prefab_path, ImportAssetOptions.ForceUpdate);
        DestroyImmediate(root_object);
    }
    
}
