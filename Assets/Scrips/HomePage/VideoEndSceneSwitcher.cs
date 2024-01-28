using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
using System.Collections;

public class VideoEndSceneSwitcher : MonoBehaviour
{
    [SerializeField] VideoPlayer videoPlayer; // el reproductor de video
    [SerializeField] string nextSceneName; // el nombre de la próxima escena

    private void Start()
    {
        // Suscribirse al evento loopPointReached del VideoPlayer
        videoPlayer.loopPointReached += OnVideoEnded;
    }

    private void OnVideoEnded(VideoPlayer source)
    {
        // Iniciar una corrutina que cargará la próxima escena después de un retraso
        StartCoroutine(LoadNextSceneAfterDelay());
    }

    private IEnumerator LoadNextSceneAfterDelay()
    {
        yield return new WaitForSeconds(20f); // esperar 16 segundos

        // cargar la próxima escena
        SceneManager.LoadScene(nextSceneName);
    }
}