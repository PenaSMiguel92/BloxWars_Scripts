using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum MeshShape {Cube, Wedge};
public static class MeshGeneration
{
    private enum Face {Back, Left, Right, Front, Top, Bottom}
    private enum Plane {Axial, Coronal, Sagittal}
    private const float PIOVERFOUR = Mathf.PI * 0.25f;
    private const float PIOVERTWO = Mathf.PI * 0.5f;
    //private static MeshFilter _meshFilter;
    //private static Mesh _mesh;
    //private static Vector3[] _vertices;
    //private static int[] _triangles;
    // Start is called before the first frame update
    // void Start()
    // {
    //     _mesh = new Mesh();
    //     _meshFilter = GetComponent<MeshFilter>();
    //     _meshFilter.mesh = _mesh;

    //     CreateShape();
    //     UpdateMesh();

    // }


    // private static Vector3[] GenerateVertices(MeshShape shape) {
    //     List<Vector3> _vertices;

    //     switch(shape)
    //     {
    //         case MeshShape.Cube:
    //             break;
    //         case MeshShape.Wedge:
    //             break;

    //     }

    //     return _vertices.ToArray();

    // }

    private static Vector3[] GenerateFace(Plane plane, bool IsWedge) {
        List<Vector3> _vertices = new List<Vector3>();
        int _curAngle = 0;
        const float _radius = 0.5f;

        do
        {
            if (IsWedge && _curAngle == 0)
            {
                _curAngle++;
                continue;
            }
            Vector3 _nxtPos = new Vector3();
            switch (plane) {
                case Plane.Axial:
                    _nxtPos = new Vector3(_radius * Mathf.Cos(_curAngle*PIOVERTWO), 0, _radius * Mathf.Sin(_curAngle*PIOVERTWO));
                    break;
                case Plane.Coronal:
                    _nxtPos = new Vector3(_radius * Mathf.Cos(_curAngle*PIOVERTWO), _radius * Mathf.Sin(_curAngle*PIOVERTWO), 0);
                    break;
                case Plane.Sagittal:
                    _nxtPos = new Vector3(0, _radius * Mathf.Sin(_curAngle*PIOVERTWO), _radius * Mathf.Cos(_curAngle*PIOVERTWO));
                    break;
            }
            Debug.Log(_nxtPos);
            _vertices.Add(_nxtPos);
            _curAngle++;
        } while (_curAngle < 4);
        return _vertices.ToArray();
    }

    // public static Mesh CreateShape()
    // {
    //     _vertices = new Vector3[] {
    //         //Bottom Face
    //         new Vector3(-0.5f, -0.5f, -0.5f),
    //         new Vector3(-0.5f, -0.5f, 0.5f),
    //         new Vector3(0.5f, -0.5f, -0.5f),

    //         //Forward Face
    //         new Vector3(-0.5f, -0.5f, 0.5f),
    //         new Vector3(-0.5f, 0.5f, 0.5f),
    //         new Vector3(0.5f, 0.5f, -0.5f),
    //         new Vector3(0.5f, -0.5f, -0.5f),
            
    //         //Top Face
    //         new Vector3(-0.5f, 0.5f, -0.5f),
    //         new Vector3(-0.5f, 0.5f, 0.5f),
    //         new Vector3(0.5f, 0.5f, -0.5f),

    //         //Left Face
    //         new Vector3(-0.5f, -0.5f, -0.5f),
    //         new Vector3(-0.5f, 0.5f, -0.5f),
    //         new Vector3(-0.5f, 0.5f, 0.5f),
    //         new Vector3(-0.5f, -0.5f, 0.5f),
            
    //         //Back Face
    //         new Vector3(-0.5f, -0.5f, -0.5f),
    //         new Vector3(-0.5f, 0.5f, -0.5f),
    //         new Vector3(0.5f, 0.5f, -0.5f),
    //         new Vector3(0.5f, -0.5f, -0.5f)
            

    //     };

    //     _triangles = new int[]{
    //         //Bottom Face - 0, 1, 2
    //         2, 1, 0,
            
    //         //Forward Face - 3, 4, 5, 6
    //         5, 4, 3,
    //         3, 6, 5,

    //         //Top Face - 7, 8, 9
    //         7, 8, 9, 

    //         //Left Face - 10, 11, 12, 13
    //         12, 11, 10,
    //         10, 13, 12,

    //         //Back Face - 14, 15, 16, 17
    //         14, 15, 16,
    //         16, 17, 14

    //     };
    // }

    // void UpdateMesh(){
    //     _mesh.Clear();

    //     _mesh.vertices = _vertices;
    //     _mesh.triangles = _triangles;
    //     _mesh.RecalculateNormals();
        
    // }

}
