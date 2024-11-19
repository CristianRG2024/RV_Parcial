using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class WaterHoseController : MonoBehaviour
{
    public XRGrabInteractable grabInteract;

    private ParticleSystem waterParticles;
    public AudioSource waterSound; // Opcional, para agregar sonido al usar la manguera
    public bool isConected;

    void Start()
    {
        grabInteract = transform.parent.GetComponent<XRGrabInteractable>();

        waterParticles = GetComponent<ParticleSystem>();

        if (waterParticles != null)
        {
            waterParticles.Stop(); // Asegurarse de que esté desactivado al inicio
        }

        grabInteract.activated.AddListener(x => onPressing());
        grabInteract.deactivated.AddListener(x => onReleasing());
        grabInteract.selectExited.AddListener(x => onThrow());

        isConected = false;

    }

    public void onPressing() {
        if (isConected) waterParticles.Play();
    }

    public void onReleasing() {
        //if (waterParticles.isPlaying)
        //{
        //    waterParticles.Stop(true, ParticleSystemStopBehavior.StopEmitting);

        //    if (waterSound != null) waterSound.Stop();
        //}
        waterParticles.Stop(true, ParticleSystemStopBehavior.StopEmitting);
    }

    public void onThrow() {
        waterParticles.Stop(true, ParticleSystemStopBehavior.StopEmitting);
    }

    public void switchConectionState() {
        isConected = !isConected;
    }
}
