using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public float speed;
    public GameObject target;

    void Update()
    {

        if (Input.GetMouseButton(0))
        {
            transform.RotateAround(
                target.transform.position,
                target.transform.up,
                Input.GetAxis("Mouse X") * speed);
            transform.RotateAround(
                target.transform.position,
                target.transform.right,
                Input.GetAxis("Mouse Y") * speed);
        }
        transform.LookAt(target.transform, target.transform.up);

        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            GetComponent<Transform>().position = new Vector3(
                transform.position.x,
                transform.position.y - 0.4f,
                transform.position.z + 0.4f);
            //  transform.Rotate(-4, 0, 0);
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            GetComponent<Transform>().position = new Vector3(
                transform.position.x,
                transform.position.y + 0.4f,
                transform.position.z - 0.4f);
            //  transform.Rotate(-2, 0, 0);
        }
    }
}
