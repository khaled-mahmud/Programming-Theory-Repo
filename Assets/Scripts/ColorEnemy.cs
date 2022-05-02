using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorEnemy : Enemy
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<MeshRenderer>().material.color = new Color(
            Random.Range(0f, 1.0f),
            Random.Range(0f, 1.0f),
            Random.Range(0f, 1.0f)
        );
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            OnCollisionWithPlayer(collision.gameObject);
    }

    // Method OverRidding
    public override void OnCollisionWithPlayer(GameObject player)
    {
        player.GetComponent<MeshRenderer>().material.color = GetComponent<MeshRenderer>().material.color;
        base.OnCollisionWithPlayer(player);
    }
}
