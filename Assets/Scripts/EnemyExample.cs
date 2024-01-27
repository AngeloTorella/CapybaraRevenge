using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyExample : MonoBehaviour
{

    public Transform target;
    public float enemySpeed = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Quiero implementar una funcionalidad que me permita hacer que mi enemigo se mueva de un lado a otro
        //Debug.Log("Imprimir ejemplo");
        MoveEnemyToTarget();
    }

    void MoveEnemyToTarget(){

        //Set Position: Change the GameObjecto to the target position
        //transform.position = target.position;

        //Lerp
        Vector3 enemyPosition = transform.position;
        Vector3 targetPosition = target.position;

        //Move towards
        



        Debug.Log("Posision del target: " + MathF.Round(targetPosition.x) );
        Debug.Log("Posicion del Enemigo: " + MathF.Round(enemyPosition.x));
        transform.position = Vector3.Lerp(enemyPosition, targetPosition, Time.deltaTime * enemySpeed);
        
        
        
        
        if (MathF.Round(enemyPosition.x) == MathF.Round(targetPosition.x)){
            
            
            Debug.Log("Entre a mi condicion: ");

        }
    }
}
