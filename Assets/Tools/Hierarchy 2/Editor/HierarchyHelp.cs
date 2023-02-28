using UnityEditor;
using UnityEngine;

public class HierarchyHelp : MonoBehaviour
{
    [MenuItem("GameObject/Hierarchy Organiser/Seperator", false, 10)]
    static void AddSeperator(MenuCommand menuCommand)
    {
        GameObject go = new GameObject("------------------");
        // Ensure it gets reparented if this was a context click (otherwise does nothing)
        GameObjectUtility.SetParentAndAlign(go, menuCommand.context as GameObject);
        // Register the creation in the undo system
        Undo.RegisterCreatedObjectUndo(go, "Create " + go.name);
        go.SetActive(false);
    }

    [MenuItem("GameObject/Hierarchy Organiser/Titles/Red Title", false, 10)]
    static void AddRed(MenuCommand menuCommand)
    {
        GameObject go = new GameObject("##FF0000  ");
        // Ensure it gets reparented if this was a context click (otherwise does nothing)
        GameObjectUtility.SetParentAndAlign(go, menuCommand.context as GameObject);
        // Register the creation in the undo system
        Undo.RegisterCreatedObjectUndo(go, "Create " + go.name);
        Selection.activeObject = go;
    }
    [MenuItem("GameObject/Hierarchy Organiser/Titles/Blue Title", false, 10)]
    static void AddBlue(MenuCommand menuCommand)
    {
        GameObject go = new GameObject("##0000FF  ");
        // Ensure it gets reparented if this was a context click (otherwise does nothing)
        GameObjectUtility.SetParentAndAlign(go, menuCommand.context as GameObject);
        // Register the creation in the undo system
        Undo.RegisterCreatedObjectUndo(go, "Create " + go.name);
        Selection.activeObject = go;
    }
    [MenuItem("GameObject/Hierarchy Organiser/Titles/Black Title", false, 10)]
    static void AddBlack(MenuCommand menuCommand)
    {
        GameObject go = new GameObject("##000000  ");
        // Ensure it gets reparented if this was a context click (otherwise does nothing)
        GameObjectUtility.SetParentAndAlign(go, menuCommand.context as GameObject);
        // Register the creation in the undo system
        Undo.RegisterCreatedObjectUndo(go, "Create " + go.name);
        Selection.activeObject = go;
    }
    [MenuItem("GameObject/Hierarchy Organiser/Titles/Purple Title", false, 10)]
    static void AddPurple(MenuCommand menuCommand)
    {
        GameObject go = new GameObject("##A020F0  ");
        // Ensure it gets reparented if this was a context click (otherwise does nothing)
        GameObjectUtility.SetParentAndAlign(go, menuCommand.context as GameObject);
        // Register the creation in the undo system
        Undo.RegisterCreatedObjectUndo(go, "Create " + go.name);
        Selection.activeObject = go;
    }
}
