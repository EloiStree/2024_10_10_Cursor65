using UnityEditor;
using UnityEngine;

namespace Eloi { 
[CustomEditor(typeof(Cursor65Mono))]
public class Cursor65MonoEditor : UnityEditor.Editor
{
    public override void OnInspectorGUI()
    {
        BaseCursor65Mono cursor = (BaseCursor65Mono)target;
        if (cursor == null)
            return;
        if (cursor.Cursor == null)
            return;
        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Refresh"))
        {
            cursor.RefreshIfPossible();
            Focus(cursor);

        }
        if (GUILayout.Button("Zero"))
        {
            cursor.Cursor.SetPositionMillimeterXYZ(0, 0, 0);
            cursor.RefreshIfPossible();
            Focus(cursor);

        }
        if (GUILayout.Button("Random"))
        {
            cursor.Cursor.Randomize();
            cursor.RefreshIfPossible();
            Focus(cursor);

        }
        if (GUILayout.Button("Focus"))
        {
        
                Focus(cursor);
            
        }

        GUILayout.EndHorizontal();
        GUILayout.BeginHorizontal();
        if (GUILayout.Button("-x"))
        {
            cursor.Cursor.AddLeftInMeter(1);
            cursor.RefreshIfPossible();
        }
        if (GUILayout.Button("+x"))
        {
            cursor.Cursor.AddRightInMeter(1);
            cursor.RefreshIfPossible();
        }
        if (GUILayout.Button("-y"))
        {
            cursor.Cursor.AddDownInMeter(1);
            cursor.RefreshIfPossible();
        }
        
        if (GUILayout.Button("+y"))
        {
            cursor.Cursor.AddUpInMeter(1);
            cursor.RefreshIfPossible();
        }
        if (GUILayout.Button("-z"))
        {
            cursor.Cursor.AddBackwardInMeter(1);
            cursor.RefreshIfPossible();
        }
        if (GUILayout.Button("+z"))
        {
            cursor.Cursor.AddForwardInMeter(1);
            cursor.RefreshIfPossible();
        }
        GUILayout.EndHorizontal();

        GUILayout.Label($"Radius: {ShortSpaceToolbox.RADIUS_IN_MM}, Diameter: {ShortSpaceToolbox.DIAMETER_IN_MM}");
        base.OnInspectorGUI();
    }

    private static void Focus(BaseCursor65Mono cursor)
    {
        Bounds bounds = new Bounds(cursor.transform.position, new Vector3(1f, 1f, 1f));
        // Focus on the selected object in the Scene view
        SceneView.lastActiveSceneView.Frame(bounds, false);
        Selection.activeGameObject = cursor.gameObject;
        Selection.activeGameObject = cursor.gameObject;
    }
}

}