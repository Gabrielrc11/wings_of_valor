using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public float lifeTime;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(transform.up * speed * Time.fixedDeltaTime, Space.World);
    }
}
