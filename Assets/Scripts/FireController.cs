using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireController : MonoBehaviour
{
    public float extinguishThreshold = 2.0f; // Tiempo que el agua necesita para apagar el fuego
    private float waterContactTime = 0f;

    void OnParticleCollision(GameObject other)
    {
        Debug.Log(other.name);
        if (other.CompareTag("Water"))
        {
            waterContactTime += Time.deltaTime;
            if (waterContactTime >= extinguishThreshold)
            {
                // Apagar el fuego
                Destroy(gameObject); // O bien, usar SetActive(false) para desactivarlo
            }
        }
    }
}
