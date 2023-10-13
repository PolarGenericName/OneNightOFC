using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using TMPro;

public class BirirbaControler : MonoBehaviour
{
    SpriteRenderer sprite;

    public GameObject Pedra;
    public Transform spawPedra;
    public TextMeshProUGUI bulletCountText;
    public Image bulletIcon;
    public int maxBullets = 10;
    public int currentBullets = 10;

    public float reloadTime = 2.0f;
    private float reloadTimer = 0.0f;

    
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();   
    }

    // Update is called once per frame
    void Update()
    {
       Aim();
       Shoot();

       
        if (reloadTimer > 0)
        {
            reloadTimer -= Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.R) && reloadTimer <= 0)
        {
            Reload();
            reloadTimer = reloadTime;
        }
    }

    void Shoot()
    {
        if (Input.GetButtonDown("Fire1") && currentBullets > 0)
        {
            Instantiate(Pedra, spawPedra.position, transform.rotation);
            currentBullets--;
            UpdateUI(); // Atualize a UI após disparar
        }
    }
     void UpdateUI()
    {
        bulletCountText.text = + currentBullets + "|" + maxBullets;
    }

    void Reload()
    {
        if (currentBullets < maxBullets)
        {
            int bulletsToReload = maxBullets - currentBullets;
            currentBullets += bulletsToReload;
            UpdateUI();
        }
    }

    void Aim()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 screenPoint = Camera.main.WorldToScreenPoint(transform.position);

        Vector2 offset = new Vector2 (mousePos.x - screenPoint.x, mousePos.y - screenPoint.y);

        float angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);

        sprite.flipY = (mousePos.x < screenPoint.x);
    }
}