using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointTowardsCenter : MonoBehaviour
{
    public Transform targetPoint;

    // Update is called once per frame
    void Update()
    {

        Vector3 dir = (transform.position - targetPoint.position).normalized;
        // Calculate the angle 
        // We assume the default arrow position at 0° is "up"
        float angle = Mathf.Rad2Deg * Mathf.Acos(Vector3.Dot(dir, Vector3.up));

        // Use the cross product to determine if the angle is clockwise
        // or anticlockwise
        Vector3 cross = Vector3.Cross(dir, Vector3.up);
        angle = -Mathf.Sign(cross.z) * angle;

        // Update the rotation of your arrow
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, angle - 90);
    }
}
