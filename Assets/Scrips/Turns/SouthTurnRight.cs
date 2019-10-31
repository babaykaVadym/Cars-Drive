using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CarLight))]
[RequireComponent(typeof(MoveScript))]
public class SouthTurnRight : MonoBehaviour
{
    private Rigidbody rb;
    private float eulerAngleVelocity;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        GetComponent<CarLight>().showObject = 0;
    }

    void FixedUpdate()
    {
        leftTurn();
    }

    void leftTurn()
    {
        float carRotation = Mathf.Floor(transform.eulerAngles.y);
        if (transform.localPosition.x <= 8.5f && carRotation != 0f)
        {
            if (carRotation >= -1f && carRotation <= 4f)
            {
                transform.localRotation = Quaternion.Euler(new Vector3(0, 0f, 0));
                return;
            }
            eulerAngleVelocity = GetComponent<MoveScript>().speed * 9f;
            Quaternion deltaRotation = Quaternion.Euler(new Vector3(0, eulerAngleVelocity, 0) * Time.fixedDeltaTime);
            rb.MoveRotation(rb.rotation * deltaRotation);
        }
    }
}
