using UnityEngine;

[ExecuteInEditMode]
public class CullLayers : MonoBehaviour
{
    public bool useUpdate = true;

    [Space(10)]
    public float[] distances = new float[32];
    
    private Camera mainCamera;

    // The Layers that have zero values doesn't do any cull
    void Start ()
    {
        mainCamera = Camera.main;
        mainCamera.layerCullDistances = distances;
    }

    // Prevent to update de camera cull distances every frame!!!
    void Update ()
    {
        if (!useUpdate) { return; }
        mainCamera.layerCullDistances = distances;
    }
}