using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cameraFollow : MonoBehaviour
{
    //Camera stats
    public float followSpeed = 4.75f;
    public float yPos;
    
    //Player's position
    public Transform player;
    private Vector3 offset;

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
    }

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Follows the player, keeps lerping towards
        Vector3 targetPos = player.transform.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetPos, followSpeed * Time.deltaTime);
    }

    private void Update()
    {
    
    }
}
