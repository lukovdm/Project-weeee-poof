using UnityEngine;
using System.Collections;

public class TrowBomb : MonoBehaviour {

    [SerializeField]
    private Vector3 trowForce;
    private Rigidbody rb;

    void Start() {
        rb = GetComponent<Rigidbody>();
    }

	void FixedUpdate () {
	    if (Input.GetButtonDown("Fire1")) {
            rb.isKinematic = false;
            //rb.AddRelativeForce(trowForce, ForceMode.Impulse);
            transform.SetParent(null);
        }
	}
}
