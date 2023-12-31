using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]

public class HexMesh : MonoBehaviour
{   
    MeshCollider meshCollider;
    Mesh hexMesh;
    public List<Vector3> vertices;
    public List<int> triangles;
    // Update is called once per frame
    void Awake()
    {   
        hexMesh = new Mesh();
        GetComponent<MeshFilter>().mesh = hexMesh;
        meshCollider = gameObject.AddComponent<MeshCollider>();
        hexMesh.name = "Hex Mesh";
        vertices = new List<Vector3>();
        triangles = new List<int>();
    }


    void TriangulateCell(HexCell cell)
    {
        Vector3 center = cell.transform.localPosition;
        for (int i = 0; i < 6; i++)
        {
            AddTriangle(
                center,
                center + HexMetrics.corners[i],
                center + HexMetrics.corners[i + 1]
            );
        }
    }
    

    public void Triangulate (HexCell[] cells) {
        meshCollider.sharedMesh = hexMesh;
        hexMesh.Clear();
        vertices.Clear();
        triangles.Clear();
        

        for(int i = 0; i < cells.Length; i++) {
            TriangulateCell(cells[i]);

        }
        hexMesh.vertices = vertices.ToArray();
        hexMesh.triangles = triangles.ToArray();

    }
    void AddTriangle (Vector3 v1, Vector3 v2, Vector3 v3) {
        int vertexIndex = vertices.Count;
        vertices.Add(v1);
        vertices.Add(v2);
        vertices.Add(v3);
        triangles.Add(vertexIndex);
        triangles.Add(vertexIndex + 1);
        triangles.Add(vertexIndex + 2);
    }
    
}
