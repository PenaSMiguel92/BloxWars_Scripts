using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshGeneration : MonoBehaviour
{
    MeshFilter _meshFilter;
    Mesh _mesh;
    Vector3[] _vertices;
    int[] _triangles;
    // Start is called before the first frame update
    void Start()
    {
        _mesh = new Mesh();
        _meshFilter = GetComponent<MeshFilter>();
        _meshFilter.mesh = _mesh;

        CreateShape();
        UpdateMesh();

    }

    void CreateShape()
    {
        _vertices = new Vector3[] {
            //Bottom Face
            new Vector3(-0.5f, -0.5f, -0.5f),
            new Vector3(-0.5f, -0.5f, 0.5f),
            new Vector3(0.5f, -0.5f, -0.5f),

            //Forward Face
            new Vector3(-0.5f, -0.5f, 0.5f),
            new Vector3(-0.5f, 0.5f, 0.5f),
            new Vector3(0.5f, 0.5f, -0.5f),
            new Vector3(0.5f, -0.5f, -0.5f),
            
            //Top Face
            new Vector3(-0.5f, 0.5f, -0.5f),
            new Vector3(-0.5f, 0.5f, 0.5f),
            new Vector3(0.5f, 0.5f, -0.5f),

            //Left Face
            new Vector3(-0.5f, -0.5f, -0.5f),
            new Vector3(-0.5f, 0.5f, -0.5f),
            new Vector3(-0.5f, 0.5f, 0.5f),
            new Vector3(-0.5f, -0.5f, 0.5f),
            
            //Back Face
            new Vector3(-0.5f, -0.5f, -0.5f),
            new Vector3(-0.5f, 0.5f, -0.5f),
            new Vector3(0.5f, 0.5f, -0.5f),
            new Vector3(0.5f, -0.5f, -0.5f)
            

        };

        _triangles = new int[]{
            //Bottom Face - 0, 1, 2
            2, 1, 0,
            
            //Forward Face - 3, 4, 5, 6
            5, 4, 3,
            3, 6, 5,

            //Top Face - 7, 8, 9
            7, 8, 9, 

            //Left Face - 10, 11, 12, 13
            12, 11, 10,
            10, 13, 12,

            //Back Face - 14, 15, 16, 17
            14, 15, 16,
            16, 17, 14

        };
    }

    void UpdateMesh(){
        _mesh.Clear();

        _mesh.vertices = _vertices;
        _mesh.triangles = _triangles;
        _mesh.RecalculateNormals();
        
    }

}
