using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum MeshShape {Cube, Wedge};


public static class MeshGeneration
{
    
    private enum Face {Back, Left, Right, Front, Top, Bottom, Wedge}
    private enum Plane {Axial, Coronal, Sagittal}
    private readonly static Face[] _faceLookUpTable = { Face.Back, Face.Left, Face.Right, Face.Front, Face.Top, Face.Bottom, Face.Wedge };
    private readonly static Plane[] _facePlanesLookUpTable = { Plane.Coronal, Plane.Sagittal, Plane.Sagittal, Plane.Coronal, Plane.Axial, Plane.Axial };
    private const float PIOVERFOUR = Mathf.PI * 0.25f;
    private const float SQRTOFTWOOVERTWO = 0.707106781f;
    private readonly static float[] _cosLookUpTable = { SQRTOFTWOOVERTWO, -SQRTOFTWOOVERTWO, -SQRTOFTWOOVERTWO, SQRTOFTWOOVERTWO };
    private readonly static float[] _sinLookUpTable = { SQRTOFTWOOVERTWO, SQRTOFTWOOVERTWO, -SQRTOFTWOOVERTWO, -SQRTOFTWOOVERTWO };

    

    private struct MeshParams {
        public Vector3[] vertices;
        public int[] triangles;
    }

    public static Mesh CreateShape(MeshShape shape)
    {
        Mesh mesh = new();
        MeshParams meshParams = GenerateShape(shape);
        Vector3[] vertices = meshParams.vertices;
        int[] triangles = meshParams.triangles;
        

        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();

        return mesh;
    }
    

    private static Vector3[] GenerateFace( bool isWedge, Face face) {
        List<Vector3> _vertices = new();
        int _curAngle = 0;
        const float _radius = 0.5f;
        Plane plane = _facePlanesLookUpTable[(int)face];
        Vector3 faceOffset = GetFaceOffset(face, _radius);
        
        do
        {
            if (isWedge && _curAngle == 0)
            {
                _curAngle++;
                continue;
            }
            Vector3 _nxtPos = GetPosition(plane, _curAngle) + faceOffset;
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


    private static MeshParams GenerateShape(MeshShape shape) {
        MeshParams _value = new();
        List<Vector3> _vertices = new();
        List<int> _triangles = new();
        List<Vector3> _wedgeVerts = new();
        foreach (Face face in _faceLookUpTable)
        {
            bool isWedge = DetermineIfWedge(shape, face);
            if (shape == MeshShape.Wedge && (face == Face.Wedge || face == Face.Front || face == Face.Right)) continue;
            if (shape == MeshShape.Cube && face == Face.Wedge) continue;
            Vector3[] verts = GenerateFace(isWedge, face);
            int[] tris = GenerateTriangles(isWedge, face);
            
            foreach (int tri in tris) {
                _triangles.Add(tri + _vertices.Count);
            }
            foreach (Vector3 vert in verts) {
                _vertices.Add(vert);
            }
        }
        if (shape == MeshShape.Wedge) {
            Vector3[] _wedgeVertices = new Vector3[]{
                new Vector3(-0.5f, 0.5f, 0.5f),
                new Vector3(0.5f, 0.5f, -0.5f),
                new Vector3(0.5f, -0.5f, -0.5f),
                new Vector3(-0.5f, -0.5f, 0.5f),
            };
            int[] _wedgeTriangles = new int[]{
                3, 1, 2, 
                3, 0, 1
            };

            foreach (int tri in _wedgeTriangles) {
                _triangles.Add(tri + _vertices.Count);
            }
            foreach (Vector3 vert in _wedgeVertices) {
                _vertices.Add(vert);
            }
        }

        _value.vertices = _vertices.ToArray();
        _value.triangles = _triangles.ToArray();
        return _value;
    }
    
    private static bool DetermineIfWedge(MeshShape shape, Face face) {
        return shape switch
        {
            MeshShape.Cube => false,
            MeshShape.Wedge => face == Face.Top || face == Face.Bottom,
            _ => false
        };
    }

    private static int[] GenerateTriangles(bool isWedge, Face face) {
        return face switch
        {
            Face.Back => new int[] { 0, 3, 2, 2, 1, 0 },
            Face.Bottom => isWedge ? new int[] { 2, 0, 1} : new int[] {  3, 1, 2, 3, 0, 1 },
            Face.Front => isWedge ? new int[] { } : new int[] { 1, 2, 3, 3, 0, 1 },
            Face.Left => new int[] { 3, 1, 2, 3, 0, 1 },
            Face.Right => isWedge ? new int[] { } : new int[] { 2, 0, 3, 2, 1, 0 },
            Face.Top => isWedge ? new int[] { 0, 2, 1 } : new int[] { 0, 2, 1, 0, 3, 2 },
            _ => new int[] { }
        };
    }
}
