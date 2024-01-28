using System.Collections;
using UnityEngine;

public class ImageText : MonoBehaviour
{
    [SerializeField] AudioSource audioSource; // el AudioSource que reproducirá el audio
    [SerializeField] AudioClip audioClip; // el clip de audio que se reproducirá
    [SerializeField] float delayInSeconds = 1f; // el retraso antes de reproducir el audio

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PlayAudio());
    }

    IEnumerator PlayAudio()
    {
        // esperar por el retraso especificado
        yield return new WaitForSeconds(delayInSeconds);

        // reproducir el audio
        audioSource.clip = audioClip;
        audioSource.Play();

        // esperar hasta que el audio termine de reproducirse
        yield return new WaitWhile(() => audioSource.isPlaying);
    }
}