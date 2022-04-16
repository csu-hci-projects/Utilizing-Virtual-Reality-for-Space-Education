using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Studio Transform Area")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        if (other.gameObject.name == "Apartment Transform Area")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
        }

        if (other.gameObject.name == "House Transform Area")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
        }

        if (other.gameObject.name == "Return to Main Menu") 
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - SceneManager.GetActiveScene().buildIndex);
        }
    }
}
