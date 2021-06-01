using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshGeneration : MonoBehaviour
{
    [SerializeField] private Material mat;
    private float width = 0.2f;
    private float height = 2;

    // Start is called before the first frame update
    private void OnEnable()
    {
        DrawArrow();
    }

    private void DrawArrow()
    {
        MeshFilter meshFilter = gameObject.GetComponent<MeshFilter>();

        Mesh mesh = new Mesh();

        Vector3[] vertices = new Vector3[7]
        {
            new Vector3(-width, 0, 0),
            new Vector3(width, 0, 0),
            new Vector3(width, height, 0),
            new Vector3(1, height, 0),
            new Vector3(0, 3, 0),
            new Vector3(-1, height, 0),
            new Vector3(-width, height, 0)
        };
        mesh.vertices = vertices;

        int[] tris = new int[9]
        {
            1, 0, 6,
            5, 4, 3,
            1, 6, 2
        };
        mesh.triangles = tris;

        meshFilter.mesh = mesh;
        mesh.RecalculateNormals();
    }
}
