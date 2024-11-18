using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    // Estructura para mantener el progreso de tareas completadas
    private Dictionary<string, int> tareasCompletadasPorEscena = new Dictionary<string, int>();
    public int totalTareas = 0; // N�mero total de tareas que deben completarse

    private void Awake()
    {
        // Asegurarse de que solo haya una instancia de GameManager
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // M�todo para registrar una tarea completada en una escena
    public void RegistrarTareaCompletada(string escena)
    {
        if (tareasCompletadasPorEscena.ContainsKey(escena))
        {
            tareasCompletadasPorEscena[escena]++;
        }
        else
        {
            tareasCompletadasPorEscena[escena] = 1;
        }
    }

    // M�todo para obtener el total de tareas completadas
    public int ObtenerTareasCompletadas()
    {
        int totalCompletadas = 0;
        foreach (var tareas in tareasCompletadasPorEscena.Values)
        {
            totalCompletadas += tareas;
        }
        return totalCompletadas;
    }

    // M�todo para mostrar el conteo de tareas en el lobby
    public void MostrarProgresoEnLobby()
    {
        Debug.Log("Tareas completadas: " + ObtenerTareasCompletadas() + " de " + totalTareas);
    }
}
