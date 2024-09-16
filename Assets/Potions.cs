using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Potions : MonoBehaviour
{
    public Vector3 minPosition;
    public Vector3 maxPosition;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "player")
        {

            Destroy(gameObject);

            Vector3 randomPosition = new Vector3(
                Random.Range(minPosition.x, maxPosition.x),
                Random.Range(minPosition.y, maxPosition.y),
                Random.Range(minPosition.z, maxPosition.z)
            );
            Instantiate(gameObject, randomPosition, Quaternion.identity);
        }
    }
}
