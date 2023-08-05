using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum MeshShape {Cube, Wedge};
public static class MeshGeneration
{
    private enum Face {Back, Left, Right, Front, Top, Bottom}
    private enum Plane {Axial, Coronal, Sagittal}
    private readonly static Plane[] _facePlanesLookUpTable = { Plane.Coronal, Plane.Sagittal, Plane.Sagittal, Plane.Coronal, Plane.Axial, Plane.Axial };
    private const float PIOVERFOUR = Mathf.PI * 0.25f;
    private const float SQRTOFTWOOVERTWO = 0.707106781f;
    private readonly static float[] _cosLookUpTable = { SQRTOFTWOOVERTWO, -SQRTOFTWOOVERTWO, -SQRTOFTWOOVERTWO, SQRTOFTWOOVERTWO };
    private readonly static float[] _sinLookUpTable = { SQRTOFTWOOVERTWO, SQRTOFTWOOVERTWO, -SQRTOFTWOOVERTWO, -SQRTOFTWOOVERTWO };
    
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

    private static Vector3[] GenerateFace( bool IsWedge, Face face) {
        List<Vector3> _vertices = new();
        int _curAngle = 0;
        const float _radius = 0.5f;
        Plane plane = _facePlanesLookUpTable[(int)face];
        Vector3 faceOffset = GetFaceOffset(face, _radius);
        
        do
        {
            if (IsWedge && _curAngle == 0)
            {
                _curAngle++;
                continue;
            }
            Vector3 _nxtPos = GetPosition(plane, _curAngle) + faceOffset;
            
            Debug.Log(_nxtPos);
            _vertices.Add(_nxtPos);
            _curAngle++;
        } while (_curAngle < 4);
        return _vertices.ToArray();
    }

    static Vector3 GetFaceOffset(Face face, float radius) {

        return face switch
        {
            Face.Back => new Vector3(0, 0, -radius),
            Face.Bottom => new Vector3(0, -radius, 0),
            Face.Front => new Vector3(0, 0, radius),
            Face.Left => new Vector3(-radius, 0, 0),
            Face.Right => new Vector3(radius, 0, 0),
            Face.Top => new Vector3(0, radius, 0),
            _ => Vector3.zero
        };
    }

    static Vector3 GetPosition(Plane plane, int curAngle) {
        return plane switch
        {
            Plane.Axial => new Vector3(SQRTOFTWOOVERTWO * _cosLookUpTable[curAngle], 0, SQRTOFTWOOVERTWO * _sinLookUpTable[curAngle]),
            Plane.Coronal => new Vector3(SQRTOFTWOOVERTWO * _cosLookUpTable[curAngle], SQRTOFTWOOVERTWO * _sinLookUpTable[curAngle], 0),
            Plane.Sagittal => new Vector3(0, SQRTOFTWOOVERTWO * _sinLookUpTable[curAngle], SQRTOFTWOOVERTWO * _cosLookUpTable[curAngle]),
            _ => Vector3.zero
        };
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
