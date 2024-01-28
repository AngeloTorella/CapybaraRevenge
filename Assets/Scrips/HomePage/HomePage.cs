using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomePage : MonoBehaviour
{
    [SerializeField] float pulseSpeed; // velocidad del pulso 
    [SerializeField] float pulseMax; // tamaño máximo del pulso
    [SerializeField] float pulseMin; // tamaño mínimo del pulso

    private Vector3 originalScale; // escala original del objeto

    private void Start()
    {
        originalScale = transform.localScale; // guardar la escala original
        StartCoroutine(Pulse()); // iniciar la corutina de pulso
    }

    public void StartGame()
    {
        SceneManager.LoadScene("VideoScene");
    }

    IEnumerator Pulse()
    {
        while (true) // bucle infinito
        {
            // interpolar suavemente la escala del objeto entre el mínimo y el máximo
            for (float scale = pulseMin; scale <= pulseMax; scale += Time.deltaTime * pulseSpeed)
            {
                transform.localScale = originalScale * scale;
                yield return null; // esperar al siguiente frame
            }

            // interpolar suavemente la escala del objeto entre el máximo y el mínimo
            for (float scale = pulseMax; scale >= pulseMin; scale -= Time.deltaTime * pulseSpeed)
            {
                transform.localScale = originalScale * scale;
                yield return null; // esperar al siguiente frame
            }
        }
    }
}