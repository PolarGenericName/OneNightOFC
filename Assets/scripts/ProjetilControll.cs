using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjetilControll : MonoBehaviour
{
    [SerializeField] float speed;
    void Start()
    {
        
    }

   
    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * speed);
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.layer == 7 )
        {

            Destroy(gameObject);
        }
    }
}
