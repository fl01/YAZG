using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunRotation : MonoBehaviour
{
    public int maxRotation = 45;
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            difference.Normalize();
            float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

            if (rotationZ <= -maxRotation) // down
            {
                rotationZ = -maxRotation;
            }
            else if (rotationZ >= maxRotation) // up
            {
                rotationZ = maxRotation;
            }

            transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);
        }
    }
}
