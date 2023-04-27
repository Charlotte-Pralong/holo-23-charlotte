using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
   public float targetRotation = 0;
    float rotation = 0;
    void Update()
    {
         rotation = Mathf.LerpAngle(rotation, targetRotation, Time.deltaTime * 2);
        transform.localRotation = Quaternion.Euler(0, 0, rotation);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("HandOpen"))
        {
            targetRotation = -90;
        }
    }
}
