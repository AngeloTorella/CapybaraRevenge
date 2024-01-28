using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    [SerializeField] string nextSceneName; // el nombre de la próxima escena
    [SerializeField] float delayInSeconds; // el retraso antes de cambiar de escena

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ChangeSceneAfterDelay());
    }

    IEnumerator ChangeSceneAfterDelay()
    {
        yield return new WaitForSeconds(delayInSeconds); // esperar por el retraso especificado

        // cargar la próxima escena
        SceneManager.LoadScene(nextSceneName);
    }
}