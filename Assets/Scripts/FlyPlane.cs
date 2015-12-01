using UnityEngine;
using System.Collections;

public class FlyPlane : MonoBehaviour {

    [SerializeField]
    private float initalVelocity;
    [SerializeField]
    private float accelaration;
    [SerializeField]
    private float lift;
    [SerializeField]
    private float rotationSpeed;
    [SerializeField]
    private float noseSpeed;
    [SerializeField]
    private float drag;
    [SerializeField]
    private Vector3 velocity;
    private Rigidbody rb;

    void Start() {
        rb = gameObject.GetComponent<Rigidbody>();
        rb.velocity = Vector3.forward * initalVelocity;
    }
	
	void FixedUpdate () {
        //Position
        rb.AddRelativeForce(Vector3.forward * Input.GetAxis("Vertical") * (accelaration/transform.InverseTransformDirection(rb.velocity).z), ForceMode.Force);

        rb.AddRelativeForce(Vector3.back * Mathf.Pow(transform.InverseTransformDirection(rb.velocity).z, 2) * 1.225f * 0.5f * 8 * 0.095f, ForceMode.Force);

        if (transform.InverseTransformDirection(rb.velocity).z > 0) {
            rb.AddRelativeForce(Vector3.up * Mathf.Pow(transform.InverseTransformDirection(rb.velocity).z, 2) * 1.225f * 14 * 0.55f * 0.5f, ForceMode.Force);
            Debug.Log("Lift: " + Mathf.Pow(transform.InverseTransformDirection(rb.velocity).z, 2) * 1.225f * 14 * 0.55f * 0.5f);
        }
        Debug.Log("A - Fd: " + ((Input.GetAxis("Vertical") * accelaration) - Mathf.Pow(transform.InverseTransformDirection(rb.velocity).z, 2) * 1.225f * 0.5f * 14) + "Lift: " + Mathf.Pow(transform.InverseTransformDirection(rb.velocity).z, 2) * 1.225f * 14 * 0.55f * 0.5f);
        velocity = transform.InverseTransformDirection(rb.velocity);

        //Rotation
        rb.MoveRotation(rb.rotation * Quaternion.Euler(0, 0, Input.GetAxis("Mouse X") * rotationSpeed));
        rb.MoveRotation(rb.rotation * Quaternion.Euler(Input.GetAxis("Mouse Y") * noseSpeed, 0, 0));

        rb.velocity = transform.TransformDirection(Vector3.forward * rb.velocity.magnitude);
    }
}
