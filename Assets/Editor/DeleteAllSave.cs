using UnityEditor;
using UnityEngine;

public class DeleteAllSaveEditor
{
    [MenuItem("Tools/Delete All Save")]
    static void DeleteAllSaveData()
    {
        PlayerPrefs.DeleteAll();
        Debug.Log("All save data deleted.");
    }
}