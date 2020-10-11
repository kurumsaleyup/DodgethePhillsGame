using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 rotation;
    public float fowardForce = 400f;

    private void Awake()
    {
        rotation = new Vector3(90, -30, 30);
        rb = gameObject.GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        this.transform.Rotate(rotation, rotation.magnitude * Time.deltaTime);
        rb.AddForce(0, 0, -fowardForce * Time.deltaTime);
        if (this.transform.position.z <= -10f)
        {
            Destroy(gameObject);
        }
    }

}
