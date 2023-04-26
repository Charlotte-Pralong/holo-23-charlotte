using UnityEngine;

public class RaycastFromHoloLens : MonoBehaviour
{
    private float maxDistance = 20.0f;

    public GameObject prefab;

    void Update()
    {
        PerformRaycast();
    }

    private void PerformRaycast()
    {
        Vector3 headPosition = transform.position;
        Vector3 gazeDirection = transform.forward;

        RaycastHit hitInfo;

        if (Physics.Raycast(headPosition, gazeDirection, out hitInfo, maxDistance, Physics.DefaultRaycastLayers))
        {
            // check if there is already a door, create a bigger colider on door
            float angle = Vector3.Angle(hitInfo.normal, Vector3.up);
            if (angle > 85 && angle < 95)
            {

                // Raycast hit something
                float distance = hitInfo.distance;
                Debug.Log("Hit: " + hitInfo.collider.gameObject.name + ", Distance: " + distance);

                RaycastHit hitInfoFloor;
                if(Physics.Raycast(hitInfo.point+hitInfo.normal*0.1f,Vector3.down, out hitInfoFloor))
                {
                Instantiate(prefab, hitInfoFloor.point, Quaternion.LookRotation(hitInfo.normal));
                }
            }
        }
        else
        {
            // Raycast didn't hit anything
            Debug.Log("No hit");
        }
    }
}
