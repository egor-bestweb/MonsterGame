using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimEnemy : MonoBehaviour
{
    private Animation _anim;
    private Animator _animator;

    void Start()
    {
        _anim = GetComponent<Animation>();
        _animator = GetComponent<Animator>();
        _anim.Play();
        _animator.Play("Enemy");
    }

    void Update()
    {
        
    }
}
