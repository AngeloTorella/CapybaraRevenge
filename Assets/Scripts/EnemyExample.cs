using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyExample : MonoBehaviour
{

    public Transform target;
    public float enemySpeed;
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

        
        transform.position = Vector3.Lerp(enemyPosition, targetPosition, Time.deltaTime * enemySpeed);
        if (enemyPosition == targetPosition){
            Vector3 data = new Vector3(-1f,1f,1f);
            target.position = target.position.x * data;
        }
    }
}
