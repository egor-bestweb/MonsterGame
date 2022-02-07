using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyDevice : MonoBehaviour
{
    [SerializeField] private GameObject _target;
    private float _speed;
    private float _angle;
   // private float _dist;
    private Rigidbody2D rb;
    private Vector2 deltaMove;
    private LayerMask mask_coll;
    private LayerMask mask_hero;
    private float _rot;
    private Animator _anim;


    private void Start()
    {
        mask_coll = LayerMask.GetMask("rc"); // game objects are attached this mask, can react to raycast
        mask_hero = LayerMask.GetMask("hero"); 
        _speed = 30f; // speed of enemy
        _angle = 90f; // angle of rotation enemy
       // _dist = 20.0f; // distance that ray will react to object
        rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
    }

    private void Update()
    {
        //-------------------------------------------------------------//
        //-----------------Device(When Noticed = false)----------------//
        if (!hero_devicing.plManager.Noticed)
        {
            _rot = CastLine(40.0f);
            float deltaX = _speed * Mathf.Cos((rb.rotation + 90f) * Mathf.PI / 180.0f) * Time.fixedDeltaTime;
            float deltaY = _speed * Mathf.Sin((rb.rotation + 90f) * Mathf.PI / 180.0f) * Time.fixedDeltaTime;
            deltaMove = new Vector2(deltaX, deltaY);
        }
        //-------------------------------------------------------------//
        //-------------Device(When Noticed = true)---------------------//
        else
        {
            _rot = CastLine(20.0f); // если препятствия нет, то возвращается 0
            if (_rot == 0f)
            {
                transform.up = Vector3.Lerp(transform.up, (_target.transform.position - transform.position), Time.deltaTime);
            }

            float deltaX = _speed * Mathf.Cos((rb.rotation + 90f) * Mathf.PI / 180.0f) * Time.fixedDeltaTime;
            float deltaY = _speed * Mathf.Sin((rb.rotation + 90f) * Mathf.PI / 180.0f) * Time.fixedDeltaTime;
            deltaMove = new Vector2(deltaX, deltaY);

            if (NearHero())
            {
                _target.BroadcastMessage("ApplyDamage");
                _anim.SetBool("Touching", true);
            }
            else _anim.SetBool("Touching", false);
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + deltaMove);
        rb.MoveRotation(rb.rotation + _rot);
    }

    // возвращает угол, на который нужно повернуться enemy, чтоб избежать столкновения
    private float Check(float _dist)
    {
        float angle = 0;
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector2.up) * _dist, Color.red);
        RaycastHit2D hit = Physics2D.CircleCast(transform.position, 13.25f, transform.TransformDirection(Vector2.up), _dist, mask_coll);
        if (hit)
        {
            if (hit.distance < _dist)
                angle = _angle * 2 * Time.fixedDeltaTime;
            else angle = _angle * Time.fixedDeltaTime;

            if (hit.distance == 0f)
                angle = 180f * Time.fixedDeltaTime;
        }
        else angle = 0f;

        return angle;
    }

    /// <summary>
    /// Достаем ли мы до героя мечом
    /// </summary>
    /// <returns></returns>
    public bool NearHero()
    {
        bool discover = false;
        RaycastHit2D hit = Physics2D.CircleCast(transform.position, 13.25f, transform.TransformDirection(Vector2.up), 20.0f, mask_hero);
        if (hit && hit.collider.name == _target.transform.name && hit.distance <= 3f)
        {
            discover = true;
        }
        else discover = false;

        return discover;
    }

    private float CastLine(float _dist)
    {
        float angle = 0f;
        float delta = 5f;
        float deltaX = delta * Mathf.Cos(rb.rotation * Mathf.PI / 180f);
        float deltaY = - 1f * delta * Mathf.Sin(rb.rotation * Mathf.PI/ 180f);



        Vector2 pos1 = new Vector2(transform.position.x + deltaX, transform.position.y - deltaY);
        Vector2 pos2 = new Vector2(transform.position.x - deltaX, transform.position.y + deltaY);

        // нужно будет бросать два луча (левый и правый) какой луч заденет - оттуда и поворачиваемся
        Debug.DrawRay(pos1, transform.TransformDirection(Vector2.up) * _dist, Color.red); // right
        Debug.DrawRay(pos2, transform.TransformDirection(Vector2.up) * _dist, Color.green); // left


        RaycastHit2D hit1 = Physics2D.CircleCast(pos1, 3f, transform.TransformDirection(Vector2.up), _dist, mask_coll); // правый 
        RaycastHit2D hit2 = Physics2D.CircleCast(pos2, 3f, transform.TransformDirection(Vector2.up), _dist, mask_coll); // левый

        if (hit1)
        {
            if (hit1.distance < _dist / 2)
                angle = _angle * 4 * Time.fixedDeltaTime;
            else angle = _angle * 4 * Time.fixedDeltaTime;
        }

        if (hit2)
        {
            if (hit1.distance < _dist / 2)
                angle = -1 * _angle * 4 * Time.fixedDeltaTime;
            else angle = -1 * _angle * 4 * Time.fixedDeltaTime;
        }

        if (hit1 && hit2)
        {
            angle = _angle * 4 * Time.fixedDeltaTime;
        }

        if (!hit1 && !hit2)
        {
            angle = 0f;
        }
        // мне кажется! объекты, меньшие самого героя, будут игнорироваться этим способом, тк мы проверяем только область по краям, а непосредственно перед героем - нет

        return angle;
    }


}

