using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SocketWithTag : XRSocketInteractor
{
    public string targetTag; // El tag que el objeto debe tener para ser seleccionado
    private WaterHoseController waterController;

    protected override void Start()
    {
        base.Start();

        // Listener para cuando un objeto es desconectado
        selectExited.AddListener(OnDisconnected);

        // Listener para cuando un objeto es conectado
        selectEntered.AddListener(OnConnected);

        waterController = GameObject.Find("Manguera").transform.GetChild(2).GetComponent<WaterHoseController>();
    }

    public override bool CanHover(IXRHoverInteractable interactable)
    {
        return base.CanHover(interactable) && interactable.transform.CompareTag(targetTag);
    }

    public override bool CanSelect(IXRSelectInteractable interactable)
    {
        return base.CanSelect(interactable) && interactable.transform.CompareTag(targetTag);
    }

    private void OnConnected(SelectEnterEventArgs args)
    {
        if (args.interactableObject.transform.CompareTag(targetTag))
        {
            if (waterController != null)
            {
                waterController.switchConectionState(); // Permitir disparar agua
                Debug.Log("Manguera conectada al hidrante. Agua habilitada.");
            }
            else
            {
                Debug.LogWarning("No se encontró un WaterHoseController en la jerarquía del objeto conectado.");
            }
        }
    }

    private void OnDisconnected(SelectExitEventArgs args)
    {
        if (waterController != null)
        {
            waterController.switchConectionState(); // Deshabilitar disparo de agua
            Debug.Log("Manguera desconectada del hidrante. Agua deshabilitada.");
        }
    }
}
