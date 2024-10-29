using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    [SerializeField]
    private float _speed = 4.5f;

    void Start()
    {
        float randomX = Random.Range(-8f, 8f);
        transform.position = new Vector3(randomX, 7, 0);
    }

    void Update()
    {
        MoveFood();
    }

    void MoveFood()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);

        if (transform.position.y < -5f)
        {
            Respawn();
        }
    }

    void Respawn()
    {
        float randomX = Random.Range(-8f, 8f);
        transform.position = new Vector3(randomX, 7, 0);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == ("Basket"))
        {
            Destroy(this.gameObject);
        }
    }
}