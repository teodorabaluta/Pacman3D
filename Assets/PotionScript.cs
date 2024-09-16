using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionScript : MonoBehaviour
{
    public GameObject potionPrefab;
    public float spawnRate = 20.0f;
    public float moveSpeed = 4.0f;
    public GameObject maze;


    private Collider2D mazeCollider;

    void Start()
    {

    }

    void Update()
    {
        Vector3 randomPosition = GetRandomPositionInMaze();

        if (randomPosition != Vector3.zero)
        {
            GameObject potionInstance = Instantiate(potionPrefab, randomPosition, Quaternion.identity);
            PotionMovement potionMovement = potionInstance.AddComponent<PotionMovement>();

            potionMovement.moveSpeed = moveSpeed;


        }

    }

    Vector3 GetRandomPositionInMaze()
    {
        int maxAttempts = 100;
        for (int i = 0; i < maxAttempts; i++)
        {
            Vector3 randomPosition = new Vector3(Random.Range(-50f, 50f), Random.Range(-50f, 50f), 0f);


        }

        return Vector3.zero;
    }
}
