using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomMesh : MonoBehaviour {
    [SerializeField] private MeshShape _shapeToUse;
    MeshFilter _filter;

    void Awake() {
        _filter = GetComponent<MeshFilter>();
        _filter.mesh = MeshGeneration.CreateShape(_shapeToUse);
    }
}