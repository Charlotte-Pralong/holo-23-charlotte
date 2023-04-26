using UnityEngine;
using System.Collections;

public class DoorController : MonoBehaviour
{
    public Animator doorAnimator;
    private bool isDoorOpen = false;
    private bool isDoorOpening = false;
    private bool isDoorClosing = false;

    public void ToggleDoor()
    {
        if (isDoorOpening || isDoorClosing) return;

        if (isDoorOpen)
        {
            doorAnimator.SetTrigger("CloseDoor");
            StartCoroutine(WaitForAnimation("DoorClose"));
        }
        else
        {
            doorAnimator.SetTrigger("OpenDoor");
            StartCoroutine(WaitForAnimation("DoorOpen"));
        }
        isDoorOpen = !isDoorOpen;
    }

    private IEnumerator WaitForAnimation(string animationName)
    {
        if (animationName == "DoorOpen")
        {
            isDoorOpening = true;
        }
        else if (animationName == "DoorClose")
        {
            isDoorClosing = true;
        }

        yield return new WaitForSeconds(doorAnimator.GetCurrentAnimatorStateInfo(0).length);

        if (animationName == "DoorOpen")
        {
            isDoorOpening = false;
        }
        else if (animationName == "DoorClose")
        {
            isDoorClosing = false;
        }
    }
}
