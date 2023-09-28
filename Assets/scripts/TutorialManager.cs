using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public GameObject tutorialImage;

    private bool tutorialActivated = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!tutorialActivated && other.CompareTag("Player"))
        {
            tutorialImage.SetActive(true);
            tutorialActivated = true;
        }
    }
}