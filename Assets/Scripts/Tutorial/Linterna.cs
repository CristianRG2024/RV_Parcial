using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Linterna : MonoBehaviour
{
    public XRGrabInteractable grabInteract;
    private bool firstGrab;
    private bool firstUse;
<<<<<<< Updated upstream
    GameObject luz;
=======
>>>>>>> Stashed changes

    private void Start()
    {
        grabInteract = GetComponent<XRGrabInteractable>();

        grabInteract.selectEntered.AddListener(x => onGrab());
        grabInteract.activated.AddListener(x => onActivate());

        firstGrab = false;
        firstUse = false;
<<<<<<< Updated upstream

        luz = transform.GetChild(0).gameObject;
=======
>>>>>>> Stashed changes
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
<<<<<<< Updated upstream

        luz.SetActive(!luz.activeSelf);
=======
>>>>>>> Stashed changes
    }
}
