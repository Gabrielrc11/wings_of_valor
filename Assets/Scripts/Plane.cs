using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline.Actions;
using UnityEngine;
using UnityEngine.UIElements;

public class Plane : MonoBehaviour
{
    public float speed;
    public SpriteRenderer Bullet;
    public Transform firePoint;
    public float fireTime;

    private Rigidbody2D rig;
    private Vector2 _direction;
    private bool canFire = true;

    public Vector2 direction
    {
        get { return _direction; }
        set { _direction = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        OnInput();
        if(Input.GetKeyDown(KeyCode.LeftControl) && canFire == true)
        {
            canFire = false;
            Instantiate(Bullet, firePoint.position, firePoint.rotation );
            Invoke("CDBullet", fireTime);
        }
    }

    private void FixedUpdate() {
        OnMove();
    }

    void OnInput()
    {
        _direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }

    void OnMove() 
    {
        rig.MovePosition(rig.position + _direction * speed * Time.fixedDeltaTime);
    }

    void CDBullet()
    {
        canFire = true;
    }
}
