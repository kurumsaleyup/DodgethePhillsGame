using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Vector3 rotation;
    private Vector3 screenPoint;
    private Vector3 offset;
    private Vector3 curPosition;
    Camera cam;
    public PlayerCollisions collisions;

    private void Awake()
    {
        cam = Camera.main;
    }
    private void Update()
    {
        //rotation
        this.transform.Rotate(rotation, rotation.magnitude * Time.deltaTime);
    }
    private void OnMouseDown()
    {
        screenPoint = cam.WorldToScreenPoint(this.transform.position);
        offset = this.transform.position - cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }
    void OnMouseDrag()
    {
        if (!collisions.getCollisionFlag())
        {
            Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
            curPosition = cam.ScreenToWorldPoint(curScreenPoint) + offset;
            transform.position = new Vector3(Mathf.Clamp(curPosition.x, -5f, 5f), Mathf.Clamp(curPosition.y, -2f, 6f), 0);
        }
        else
        {
            Debug.Log("collision occur.");
            return;
        }


    }
}
