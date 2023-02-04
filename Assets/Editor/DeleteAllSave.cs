using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class DeleteAllSave : EditorWindow
{
    [MenuItem("Window/Delete PlayerPrefs (All)")]
    private void DeleteAllPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
    }
}
