using UnityEngine;
using System.Collections;

public class WaterForce : MonoBehaviour {

    [SerializeField]
    private float floatiness;

    void OnTriggerStay(Collider other) {
        if (other.tag != "Player")
            return;

        Rigidbody rb = other.GetComponent<Rigidbody>();
        rb.AddForce(Vector3.up * floatiness, ForceMode.Force);
        Debug.Log(rb.velocity);
    }
}
