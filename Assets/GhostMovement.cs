using UnityEngine;

public class GhostMovement : MonoBehaviour
{
    public float moveSpeed = 2.0f;

    private float minX, maxX, minZ, maxZ;
    private Vector3 moveDirection;

    void Start()
    {

        MazeSpawner mazeSpawner = FindObjectOfType<MazeSpawner>();


        minX = 0;
        maxX = mazeSpawner.Rows * mazeSpawner.CellWidth;
        minZ = 0;
        maxZ = mazeSpawner.Columns * mazeSpawner.CellHeight;

        float randomX = Random.Range(-1f, 1f);
        float randomZ = Random.Range(-1f, 1f);
        moveDirection = new Vector3(randomX, 0f, randomZ).normalized;
    }

    void Update()
    {
        Vector3 newPosition = transform.position + moveDirection * moveSpeed * Time.deltaTime;

        newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);
        newPosition.z = Mathf.Clamp(newPosition.z, minZ, maxZ);

        transform.position = newPosition;

        if (newPosition.x <= minX || newPosition.x >= maxX || newPosition.z <= minZ || newPosition.z >= maxZ)
        {
            float randomX = Random.Range(-1f, 1f);
            float randomZ = Random.Range(-1f, 1f);
            moveDirection = new Vector3(randomX, 0f, randomZ).normalized;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Maze")
        {
            Vector3 oppositeDirection = -moveDirection;
            moveDirection = oppositeDirection.normalized;
        }
    }
}