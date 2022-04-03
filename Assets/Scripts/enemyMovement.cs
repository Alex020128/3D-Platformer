using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class enemyMovement : MonoBehaviour
{
    //Enemy stats
    public float moveSpeed = 4.0f;
    Rigidbody rb;
    //Player's position
    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").transform;
        rb = GetComponent<Rigidbody>();
    }

    //When collide with player
    public void OnCollisionStay(Collision collision)
    {
        //Shakes the screen when collide
        if (collision.collider.gameObject.tag == "Player")
        {
            Camera.main.transform.DOShakePosition(0.5f, new Vector3(0.25f, 0.25f, 0.25f));
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Keeps following the player
        Vector3 pos = Vector3.MoveTowards(this.transform.position, player.position, moveSpeed * Time.fixedDeltaTime);
        rb.MovePosition(pos);
        //Faces the player
        transform.LookAt(player);
    }
}
