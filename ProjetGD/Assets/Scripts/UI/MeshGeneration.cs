using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshGeneration : MonoBehaviour
{
    [SerializeField] private Material mat;
    private float width = 1;
    private float height = 1;

    // Start is called before the first frame update
    void Start()
    {
        MeshRenderer meshRenderer = gameObject.AddComponent<MeshRenderer>();
        meshRenderer.sharedMaterial = new Material(Shader.Find("Standard"));

        MeshFilter meshFilter = gameObject.AddComponent<MeshFilter>();

        Mesh mesh = new Mesh();

        Vector3[] vertices = new Vector3[3]
        {
            new Vector3(-1, 0, 0),
            new Vector3(0, 1, 0),
            new Vector3(1, 0, 0)
        };
        mesh.vertices = vertices;

        int[] tris = new int[3]
        {
            // lower left triangle
            0, 1, 2,
            // upper right triangle

        };
        mesh.triangles = tris;

        meshFilter.mesh = mesh;
        mesh.RecalculateNormals();

        meshRenderer.material = mat;
        meshRenderer.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
    }
}
