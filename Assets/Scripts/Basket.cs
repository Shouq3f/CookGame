using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Basket : MonoBehaviour
{
    [SerializeField]
    private float speed = 3.5f;
    private int score = 0;
    public Text scoreText;
    public GameObject[] foodPrefabs;

    void Start()
    {
        transform.position = new Vector3(0, -3, 0);
    }

    void Update()
    {
        CalculateMovement();
    }

    void CalculateMovement()
    {
        float hI = Input.GetAxis("Horizontal");
        Vector3 direction = new Vector3(hI, 0, 0);

        transform.Translate(direction * speed * Time.deltaTime);

        // Bound Y
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -3.8f, 0), 0);

        // Wrap X
        if (transform.position.x > 11.3f)
        {
            transform.position = new Vector3(-11.3f, transform.position.y, 0);
        }

        if (transform.position.x < -11.3f)
        {
            transform.position = new Vector3(11.3f, transform.position.y, 0);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Food"))
        {
            Debug.Log("Food collected!");
            Destroy(other.gameObject); // Destroy the collected food object
            UpdateScore(1); // Increase the score by 1

            // Instantiate a random food prefab from the array
            GameObject randomFoodPrefab = foodPrefabs[Random.Range(0, foodPrefabs.Length)];
            Instantiate(randomFoodPrefab, new Vector3(Random.Range(-10f, 10f), 6f, 0), Quaternion.identity);
        }
    }

    void UpdateScore(int amount)
    {
        score += amount;
        scoreText.text = "Score: " + score;
    }
}