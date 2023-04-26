using UnityEngine;

public class CubeButtonController : MonoBehaviour
{
    public DoorController doorController;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject == this.gameObject)
                {
                    doorController.ToggleDoor();
                }
            }
        }
    }
}
