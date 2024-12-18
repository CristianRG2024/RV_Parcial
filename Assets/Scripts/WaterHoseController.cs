using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class WaterHoseController : MonoBehaviour
{
    public XRGrabInteractable grabInteract;

    public ParticleSystem waterParticles;
    public AudioSource waterSound; // Opcional, para agregar sonido al usar la manguera
    private bool isConected;

    void Start()
    {
        grabInteract = GetComponent<XRGrabInteractable>();

        if (waterParticles != null)
        {
            waterParticles.Stop(); // Asegurarse de que est� desactivado al inicio
        }

        grabInteract.activated.AddListener(x => onPressing());
        grabInteract.deactivated.AddListener(x => onReleasing());
        grabInteract.selectExited.AddListener(x => onThrow());

        isConected = false;

    }

    public void onPressing() {
        if (isConected) {
            waterParticles.Play();
            waterSound.Play();
        }
    }

    public void onReleasing() {
        waterParticles.Stop(true, ParticleSystemStopBehavior.StopEmitting);
        waterSound.Stop();
    }

    public void onThrow() {
        waterParticles.Stop(true, ParticleSystemStopBehavior.StopEmitting);
        waterSound.Stop();
    }

    public void switchConectionState() {
        isConected = !isConected;
    }
}
