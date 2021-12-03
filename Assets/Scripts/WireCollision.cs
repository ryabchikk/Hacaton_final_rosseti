using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireCollision : MonoBehaviour
{
    [SerializeField] private new MeshCollider collider;
    [SerializeField] private new SkinnedMeshRenderer renderer;

    private Mesh _mesh;

    private void Start()
    {
        Debug.Log($"First Position {collider.sharedMesh.vertices[0]}");
        _mesh = new Mesh();
        collider.sharedMesh = _mesh;
        
    }

    private void Update()
    {
        collider.enabled = false;
        var mesh = collider.sharedMesh;
        mesh.MarkDynamic();
        renderer.BakeMesh(mesh, true);
        mesh.bounds = renderer.bounds;
        mesh.RecalculateNormals();
        mesh.RecalculateTangents();
        mesh.Optimize();
        collider.enabled = true;
    }
}
