using UnityEngine;

public class WireCollision : MonoBehaviour
{
    [SerializeField] private new MeshCollider collider;
    [SerializeField] private new SkinnedMeshRenderer renderer;
    [SerializeField] private GlobalWind globalWind;
    [SerializeField] private Cloth cloth;

    private Mesh _mesh;

    private void Start()
    {
        _mesh = new Mesh();
        collider.sharedMesh = _mesh;
        globalWind.WindChanged += WindChanged;
    }

    private void Update()
    {
        collider.enabled = false;
        var mesh = collider.sharedMesh;
        mesh.MarkDynamic();
        renderer.BakeMesh(mesh, true);
        collider.enabled = true;
    }

    private void WindChanged(Vector3 direction)
    {
        cloth.externalAcceleration = direction;
    }
}
