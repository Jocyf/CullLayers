using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(CullLayers))]
public class CullLayersEditor : Editor
{
    private CullLayers _target;

    private bool numbered = false;
    private bool useUpdate = true;
    private int i = 0;

    public override void OnInspectorGUI()
    {
        _target = (CullLayers)target;
        EditorGUILayout.Separator();
        EditorGUILayout.LabelField("by Jocyf", string.Empty);
        EditorGUILayout.Separator();

        GUIContent contentCullLayers = new GUIContent("Use Update: ", "Update every frame. For test purposes only!");
        _target.useUpdate = EditorGUILayout.Toggle(contentCullLayers, _target.useUpdate);
        EditorGUILayout.Separator();

        numbered = EditorGUILayout.Toggle("Use numbered Layers?", numbered);
        for (i = 0; i < 32; i++)
        {
            if (numbered)
                _target.distances[i] = EditorGUILayout.FloatField("Layer" + i.ToString() + " - " + LayerMask.LayerToName(i) + " : ", _target.distances[i]);
            else
                _target.distances[i] = EditorGUILayout.FloatField(LayerMask.LayerToName(i) + " : ", _target.distances[i]);
        }

        if (GUI.changed)
        {
            EditorUtility.SetDirty(target);
        }
    }

}
