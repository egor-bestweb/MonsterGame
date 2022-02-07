using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// этот сценарий привязан к hero 

public class hero_devicing : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _rotSpeed;
    static public PlayerManager plManager;

    private Rigidbody2D rb;

    private float angle = 0;
    private float angle2 = 0;
    private Vector2 nextPoint;
    private float deltaX;
    private float deltaY;


    private void Start()
    {
        plManager = GetComponent<PlayerManager>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        angle = rb.rotation + 90f;
        angle = angle * Mathf.PI / 180.0f;

        deltaX = Input.GetAxisRaw("Vertical") * Mathf.Cos(angle) * _speed * Time.fixedDeltaTime;
        deltaY = Input.GetAxisRaw("Vertical") * Mathf.Sin(angle) * _speed * Time.fixedDeltaTime;

        nextPoint = new Vector2(deltaX, deltaY);

        angle2 = Input.GetAxisRaw("Horizontal") * _rotSpeed * Time.deltaTime;
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + nextPoint);
        rb.MoveRotation(rb.rotation - angle2);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "key")
        {
            Destroy(collision.gameObject);
            plManager.Access = true;
        }
    }

}
