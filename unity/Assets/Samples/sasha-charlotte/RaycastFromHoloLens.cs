using UnityEngine;

public class RaycastFromHoloLens : MonoBehaviour
{
    private float maxDistance = 20.0f;

    void Update()
    {
        PerformRaycast();
    }

    private void PerformRaycast()
    {
        Vector3 headPosition = Camera.main.transform.position;
        Vector3 gazeDirection = Camera.main.transform.forward;

        RaycastHit hitInfo;

        if (Physics.Raycast(headPosition, gazeDirection, out hitInfo, maxDistance, Physics.DefaultRaycastLayers))
        {
            // Raycast hit something
            float distance = hitInfo.distance;
            Debug.Log("Hit: " + hitInfo.collider.gameObject.name + ", Distance: " + distance);
        }
        else
        {
            // Raycast didn't hit anything
            Debug.Log("No hit");
        }
    }
}
