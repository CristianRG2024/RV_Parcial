using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Linterna : MonoBehaviour
{
    public XRGrabInteractable grabInteract;
    private bool firstGrab;
    private bool firstUse;
    GameObject luz;

    private void Start()
    {
        grabInteract = GetComponent<XRGrabInteractable>();

        grabInteract.selectEntered.AddListener(x => onGrab());
        grabInteract.activated.AddListener(x => onActivate());

        firstGrab = false;
        firstUse = false;

        luz = transform.GetChild(0).gameObject;
    }

    public void onGrab()
    {
        if (!firstGrab && TutorialTaskManager.Instance.currentTask.Equals(TutorialTaskManager.TutorialTask.GrabObject)) {
            firstGrab = true;
            TutorialTaskManager.Instance.CompleteTask();
        }
    }

    public void onActivate()
    {
        if (!firstUse && TutorialTaskManager.Instance.currentTask.Equals(TutorialTaskManager.TutorialTask.UseObject))
        {
            firstUse = true;
            TutorialTaskManager.Instance.CompleteTask();
        }

        luz.SetActive(!luz.activeSelf);
    }
}
