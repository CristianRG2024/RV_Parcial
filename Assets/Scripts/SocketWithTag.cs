using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SocketWithTag : XRSocketInteractor
{
    public string targetTag; // El tag que el objeto debe tener para ser seleccionado

    protected override void Start()
    {
        base.Start();

        // Listener para cuando un objeto es desconectado
        selectExited.AddListener(OnDisconnected);

        // Listener para cuando un objeto es conectado
        selectEntered.AddListener(OnConnected);
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
            // Buscar el controlador de agua en la jerarquía del objeto conectado
            WaterHoseController waterController = args.interactableObject.transform.root.GetComponentInChildren<WaterHoseController>();

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
        // Buscar el controlador de agua en la jerarquía del objeto desconectado
        WaterHoseController waterController = args.interactableObject.transform.root.GetComponentInChildren<WaterHoseController>();

        if (waterController != null)
        {
            waterController.switchConectionState(); // Deshabilitar disparo de agua
            Debug.Log("Manguera desconectada del hidrante. Agua deshabilitada.");
        }
    }
}
