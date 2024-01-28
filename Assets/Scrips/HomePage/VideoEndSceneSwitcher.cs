using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

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
        // Cargar la próxima escena cuando el video termine de reproducirse
        SceneManager.LoadScene(nextSceneName);
    }
}