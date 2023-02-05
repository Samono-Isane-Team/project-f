using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class DeleteAllSave : EditorWindow
{

    // * menghapus seluruh playerprefs
    [MenuItem("Window/Delete PlayerPrefs (All)")]
    private static void DeleteAllPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
    }
}
