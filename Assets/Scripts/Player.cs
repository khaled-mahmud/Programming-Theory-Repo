using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float maxMoveXAxis;
    [SerializeField]
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameManager.m_GameOver)
            Move();
    }

    private void Move()
    {
        float inputPosition = Input.GetAxis("Horizontal");

        Vector3 playerPosition = transform.position;
        playerPosition.x += inputPosition * speed * Time.deltaTime;

        if (playerPosition.x > maxMoveXAxis)
            playerPosition.x = maxMoveXAxis;
        else if (playerPosition.x < -maxMoveXAxis)
            playerPosition.x = -maxMoveXAxis;

        transform.position = playerPosition;
    }
}
