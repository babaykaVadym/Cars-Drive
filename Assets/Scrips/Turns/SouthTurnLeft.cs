using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(CarLight))]
[RequireComponent(typeof(MoveScript))]
public class SouthTurnLeft : MonoBehaviour
{
    private Rigidbody rb;
    private float eulerAngleVelocity;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        GetComponent<CarLight>().showObject = 1;
    }

    void FixedUpdate()
    {
        leftTurn();
    }

    void leftTurn()
    {
        float carRotation = Mathf.Floor(transform.eulerAngles.y);
        if (transform.localPosition.x <= 5.5f && carRotation != 180f)
        {
            if (carRotation >= 179f && carRotation <= 184f)
            {
                transform.localRotation = Quaternion.Euler(new Vector3(0, 180f, 0));
                return;
            }
            eulerAngleVelocity = GetComponent<MoveScript>().speed * 9f;
            Quaternion deltaRotation = Quaternion.Euler(new Vector3(0, -eulerAngleVelocity, 0) * Time.fixedDeltaTime);
            rb.MoveRotation(rb.rotation * deltaRotation);
        }
    }
}
