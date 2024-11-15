using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoArea : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && TutorialTaskManager.Instance.currentTask.Equals(TutorialTaskManager.TutorialTask.Move)) {
            TutorialTaskManager.Instance.CompleteTask();
        }
    }
}
