using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collisions : MonoBehaviour
{
    public Health healthScript;
    public int lives = 4;
    public int attack = 0;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ghost" && attack == 0)
        {
            lives--;


            if (lives <= 0)
            {
                SceneManager.LoadSceneAsync(0);
            }
        }

        if (other.gameObject.tag == "PotionRed")
        {
            lives++;
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "PotionBlue")
        {
            attack = 1;
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "Ghost" && attack == 1)
        {
            attack = 0;
            Destroy(other.gameObject);
        }
    }


}