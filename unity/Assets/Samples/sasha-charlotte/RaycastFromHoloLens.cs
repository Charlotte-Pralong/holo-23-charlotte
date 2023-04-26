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
            // check if there is already a door, create a bigger collider on door
            float angle = Vector3.Angle(hitInfo.normal, Vector3.up);
            if (angle > 85 && angle < 95)
            {
                // Raycast hit something
                float distance = hitInfo.distance;
                Debug.Log("Hit: " + hitInfo.collider.gameObject.name + ", Distance: " + distance);

                RaycastHit hitInfoFloor;
                if (Physics.Raycast(hitInfo.point + hitInfo.normal * 0.1f, Vector3.down, out hitInfoFloor))
                {
                    // Check if there is an existing prefab within 1 meter
                    float checkDistance = 1.0f;
                    Vector3 halfExtents = new Vector3(checkDistance, checkDistance, checkDistance);
                    Collider[] nearbyColliders = Physics.OverlapBox(hitInfoFloor.point, halfExtents);

                    bool existingPrefabFound = false;
                    foreach (Collider collider in nearbyColliders)
                    {
                        if (collider.gameObject.name.StartsWith(prefab.name))
                        {
                            existingPrefabFound = true;
                            break;
                        }
                    }

                    // Instantiate the prefab only if no existing prefab is found within the specified distance
                    if (!existingPrefabFound)
                    {
                        Instantiate(prefab, hitInfoFloor.point, Quaternion.LookRotation(hitInfo.normal));
                    }
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
