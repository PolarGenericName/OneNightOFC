using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float Speed;
    public GameObject tutorialImage;

    //var de animaçao
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && tutorialImage.activeSelf)
        {
            tutorialImage.SetActive(false);
        }
        {
            Move();
        }
        void Move()
        {
            Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f);
            transform.position += movement * Time.deltaTime * Speed;

            //animaçao
            if (Input.GetAxis("Horizontal") > 0 || Input.GetAxis("Vertical") < 0)
            {
                animator.SetBool("Andando", true);

                transform.eulerAngles = new Vector3(0f, 180f, 0f);
            }
            if (Input.GetAxis("Horizontal") < 0 || Input.GetAxis("Vertical") > 0)
            {
                animator.SetBool("Andando", true);

                transform.eulerAngles = new Vector3(0f, 0f, 0f);
            }
            if (Input.GetAxis("Horizontal") == 0f && Input.GetAxis("Vertical") == 0f)
            {
                animator.SetBool("Andando", false);
            }



        }
    }
}
