using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class ShapeEnemy : Enemy
{
    [SerializeField]
    private Mesh[] meshes;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<MeshFilter>().mesh = meshes[Random.Range(0, meshes.Length)];
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            OnCollisionWithPlayer(collision.gameObject);
    }

    // POLYMORPHISM
    public override void OnCollisionWithPlayer(GameObject player)
    {
        player.GetComponent<MeshFilter>().mesh = gameObject.GetComponent<MeshFilter>().mesh;
        base.OnCollisionWithPlayer(player);
    }
}
