using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Arma : MonoBehaviour
{
    SpriteRenderer sprite;

    public GameObject bullet;

    public Transform spawnBullet;
    void Start()
    {
        sprite = gameObject.GetComponent<SpriteRenderer>();
    }


    void Update()
    {
        Aim();

        Shoot();
    }
     
     void Shoot()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(bullet , spawnBullet.position , transform.rotation);
        }

    }
     void Aim()
     {
        //rotação da arma 
        Vector3 mousePos = Input.mousePosition;
        Vector3 screenPoint = Camera.main.WorldToScreenPoint(transform.position);

        Vector2 offset = new Vector2(mousePos.x - screenPoint.x, mousePos.y - screenPoint.y);

        float angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, angle);
        //ajuste do sprite

        sprite.flipY = (mousePos.x < screenPoint.x);
    }
        
        

 }

