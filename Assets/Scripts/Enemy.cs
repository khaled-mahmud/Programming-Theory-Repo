using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    private GameManager gameManager;
    [SerializeField]
    private int pointValue;
    [SerializeField]
    protected float speed;
    [SerializeField]
    private float maxMoveZAxis;
    public UnityEvent<int> onDestroyed;



    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 enemyPosition = transform.position;

        if (enemyPosition.z > -maxMoveZAxis)
        {
            enemyPosition.z -= speed * Time.deltaTime;
            transform.position = enemyPosition;
        }
        else
        {
            gameManager.GameOver();
            Destroy(gameObject);
        }

    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            onDestroyed.Invoke(pointValue);
            Destroy(gameObject);
        }

    }

    // void OnDestroy()
    // {
    //     onDestroyed.Invoke(pointValue);
    //     gameManager.GameOver();
    // }
}
