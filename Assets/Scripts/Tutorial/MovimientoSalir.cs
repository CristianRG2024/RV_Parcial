using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovimientoSalir : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && TutorialTaskManager.Instance.currentTask.Equals(TutorialTaskManager.TutorialTask.leave)) {
            SceneManager.LoadScene(0);
        }
    }
}
