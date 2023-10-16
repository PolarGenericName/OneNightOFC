using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using TMPro;

public class BirirbaControler : MonoBehaviour
{
    public TextMeshProUGUI bulletCountText;
    public TextMeshProUGUI maxBulletText;
    public Image bulletIcon;
    public Image maxBulletIcon;

    public int maxBullets = 10;
    public int currentBullets = 10;

    public float reloadTime = 2.0f;
    public float shotDelay = 0.5f; // Tempo de atraso entre os tiros
    private float reloadTimer = 0.0f;
    private float shotTimer = 0.0f; // Temporizador para controlar o atraso entre os tiros

    public GameObject Pedra;
    public Transform spawPedra;

    void Start()
    {
        UpdateUI();
    }

    void Update()
    {
        Aim();

        if (reloadTimer > 0)
        {
            reloadTimer -= Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.R) && reloadTimer <= 0)
        {
            Reload();
            reloadTimer = reloadTime;
        }

        // Atualize o temporizador do tiro
        if (shotTimer > 0)
        {
            shotTimer -= Time.deltaTime;
        }

        // Verifique se pode atirar
        if (Input.GetButtonDown("Fire1") && currentBullets > 0 && shotTimer <= 0)
        {
            Shoot();
            shotTimer = shotDelay; // Configure o atraso após o tiro
        }
    }

    void Shoot()
    {
        Instantiate(Pedra, spawPedra.position, transform.rotation);
        currentBullets--;

        if (currentBullets == 0)
        {
            // Altere o ícone ou sprite aqui, se necessário
        }

        UpdateUI();
    }

    void Reload()
    {
        if (currentBullets < maxBullets)
        {
            int bulletsToReload = maxBullets - currentBullets;
            currentBullets += bulletsToReload;

            if (currentBullets > 0)
            {
                // Altere o ícone ou sprite aqui, se necessário
            }

            UpdateUI();
        }
    }

    void Aim()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 screenPoint = Camera.main.WorldToScreenPoint(transform.position);

        Vector2 offset = new Vector2(mousePos.x - screenPoint.x, mousePos.y - screenPoint.y);

        float angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    void UpdateUI()
    {
        bulletCountText.text = currentBullets.ToString();
        maxBulletText.text = maxBullets.ToString();
    }
}