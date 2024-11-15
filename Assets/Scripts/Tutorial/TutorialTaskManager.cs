using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialTaskManager : MonoBehaviour
{
    public static TutorialTaskManager Instance;
    public enum TutorialTask
    {
        None,
        Move,
        GrabObject,
        UseObject,
        leave
    }

    public TutorialTask currentTask = TutorialTask.None; // Tarea actual
    public Text instructionsText; // UI para mostrar las instrucciones

    private bool taskCompleted = false;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        StartCoroutine(startTutorial());
    }

    void Update()
    {
        if (taskCompleted) {
            finishActualTask();
        }
    }

    private void finishActualTask() {
        switch (currentTask)
        {
            case TutorialTask.Move:
                SetTask(TutorialTask.GrabObject); // Si se complet�, pasa a la siguiente tarea
                break;

            case TutorialTask.GrabObject:
                SetTask(TutorialTask.UseObject); // Si se complet�, pasa a la siguiente tarea
                break;

            case TutorialTask.UseObject: // Si se complet�, pasa a la siguiente tarea
                SetTask(TutorialTask.leave);
                break;
        }
    }

    // Funci�n para actualizar la tarea activa y mostrar las instrucciones
    private void SetTask(TutorialTask newTask)
    {
        AudioClip audio;
        AudioClip audio2;
        currentTask = newTask;
        taskCompleted = false; // Reinicia la verificaci�n de la tarea

        // Muestra instrucciones espec�ficas para la tarea actual
        switch (currentTask)
        {
            case TutorialTask.Move:

                audio = Resources.Load<AudioClip>("Audios/Tutorial/Tarea 2 Tutorial");
                AudioManager.instance.playAudio(audio);
                
                instructionsText.text = "Usa el joystick izquierdo para moverte hacia la zona verde.";
                break;

            case TutorialTask.GrabObject:

                audio = Resources.Load<AudioClip>("Audios/Tutorial/Tarea 2 Tutorial Completada");
                audio2 = Resources.Load<AudioClip>("Audios/Tutorial/Tarea 3 Tutorial");
                StartCoroutine(congratsAndNextTask(audio, audio2));

                instructionsText.text = "Ac�rcate a la linterna sobre la mesa y usa el gatillo para agarrarla.";
                break;

            case TutorialTask.UseObject:

                audio = Resources.Load<AudioClip>("Audios/Tutorial/Tarea 4 Tutorial");
                AudioManager.instance.playAudio(audio);

                instructionsText.text = "Usa el bot�n sobre el gatillo para encender la linterna.";
                break;

            case TutorialTask.leave:
                audio = Resources.Load<AudioClip>("Audios/Tutorial/Tarea 4 Tutorial Completada");
                audio2 = Resources.Load<AudioClip>("Audios/Tutorial/Finalizar Tutorial");
                StartCoroutine(congratsAndNextTask(audio, audio2));

                instructionsText.text = "�Tutorial completado! Sal de la zona de tutorial para comenzar tu entrenamiento";
                break;
        }
    }

    // Funci�n para marcar una tarea como completada (se llamar� cuando el jugador complete la tarea)
    public void CompleteTask()
    {
        taskCompleted = true;
    }

    private IEnumerator startTutorial() {
        yield return new WaitForSeconds(2);

        AudioClip audio = Resources.Load<AudioClip>("Audios/Tutorial/Inicio Tutorial");
        AudioManager.instance.playAudio(audio);
        
        yield return new WaitForSeconds(audio.length+1.5f);

        audio = Resources.Load<AudioClip>("Audios/Tutorial/Tarea 1 Tutorial");
        AudioManager.instance.playAudio(audio);

        yield return new WaitForSeconds(audio.length+1.5f);
        SetTask(TutorialTask.Move);
    }

    private IEnumerator congratsAndNextTask(AudioClip actualAudio, AudioClip nextAudio) {

        AudioManager.instance.playAudio(actualAudio);

        yield return new WaitForSeconds(actualAudio.length+1.5f);

        AudioManager.instance.playAudio(nextAudio);
    }
}
