using UnityEngine;
using System.Collections;

public class Explode : MonoBehaviour
{
    private Renderer rn;

    void Start() {
        rn = GetComponent<Renderer>();
    }

    [SerializeField]
    private float explodeRange;
	[SerializeField]
	private float explodePower;

    void OnCollisionEnter(Collision collision) {
        rn.material.color = Color.red;
        Mesh m = collision.gameObject.GetComponent<MeshFilter>().mesh;
        MeshCollider mc = collision.gameObject.GetComponent<MeshCollider>();
        Vector3[] vertices = m.vertices;
        Vector3[] normals = m.normals;
        int i = 0;
        while (i < vertices.Length) {
			if (Vector3.Distance(vertices[i], collision.gameObject.transform.InverseTransformPoint(collision.contacts[0].point)) <= explodeRange) {
				vertices[i] += collision.gameObject.transform.rotation * Vector3.down * -1 * explodePower;
            }
            i++;
        }
        m.vertices = vertices;
        m.RecalculateBounds();
        mc.sharedMesh = m;
    }
}