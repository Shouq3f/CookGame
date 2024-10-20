using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket : MonoBehaviour
{

    [SerializeField]
    private float speed = 3.5f;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, -2, 0);

    }

    // Update is called once per frame
    void Update()
    {
         CalculateMovement();
    }

    void CalculateMovement()
    {
        float hI = Input.GetAxis("Horizontal");
       // float vI = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(hI, 0, 0);

        transform.Translate(direction * speed * Time.deltaTime);

        //Bound Y
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -3.8f, 0), 0);
        //Wrap X

        if (transform.position.x > 11.3f)
        {
            transform.position = new Vector3(-11.3f, transform.position.y, 0);
        }

        if (transform.position.x < -11.3f)
        {
            transform.position = new Vector3(11.3f, transform.position.y, 0);
        }
    }
}
