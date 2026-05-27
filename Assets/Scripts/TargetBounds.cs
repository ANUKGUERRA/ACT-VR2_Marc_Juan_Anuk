using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;

[CustomEditor(typeof(TargetBounds))]
public class DianaEditor : Editor
{
    private void OnSceneGUI()
    {
        TargetBounds diana = (TargetBounds)target;
        Transform t = diana.transform;

        Vector3 topLeft = new Vector3(diana.min.x, 0, diana.min.z);
        Vector3 topRight = new Vector3(diana.max.x, 0, diana.min.z);
        Vector3 botLeft = new Vector3(diana.min.x, 0, diana.max.z);
        Vector3 botRight = new Vector3(diana.max.x, 0, diana.max.z);

        DrawPoint(diana, ref diana.min, t);
        DrawPoint(diana, ref diana.max, t);
    }

    private void DrawPoint(TargetBounds diana, ref Vector3 localPoint, Transform t)
    {
        Vector3 worldPos = t.TransformPoint(localPoint);

        EditorGUI.BeginChangeCheck();
        Vector3 newWorld = Handles.PositionHandle(worldPos, Quaternion.identity);

        if (EditorGUI.EndChangeCheck())
        {
            Undo.RecordObject(diana, "Move Corner");
            localPoint = t.InverseTransformPoint(newWorld);
        }
    }
}
#endif

public class TargetBounds : MonoBehaviour
{
    public static TargetBounds Instance { get; private set; }

    public Vector3 min;
    public Vector3 max;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            DestroyImmediate(this);
            return;
        }

        Instance = this;
    }
}