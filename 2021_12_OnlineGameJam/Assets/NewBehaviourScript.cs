using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Transform player;
    public float weight = 1;
    public float offset;
    void LateUpdate()
    {
        var pos = transform.position;
        pos.y = (player.position.y- offset) * weight;
        transform.position = pos;

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        var rigid =GetComponent<Rigidbody2D>();
        rigid.AddForce(Vector2.right * Vector2.Dot(Vector2.right, collision.contacts[0].normal));
        
    }
}
