using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public Vector3 moveDirection;
    public float MoveDistance;
    private Vector3 startPos;
    private bool movingToStart;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
    
        if (movingToStart)
        {
            transform.position = Vector3.MoveTowards(transform.position, 
                startPos,
                speed * Time.deltaTime);
            if (transform.position == startPos)
            {
                movingToStart = false;
                Debug.Log(movingToStart);
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, startPos + (moveDirection * MoveDistance), speed * Time.deltaTime);
            if (transform.position == startPos + (moveDirection * MoveDistance))
            {
                movingToStart = true;
                Debug.Log(movingToStart);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Player>().GameOver();
        }
    }
}
