using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour, IAnimationController
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void Jump(float js)
    {
        _animator.SetFloat("YSpeed", js);
    }

    public void Run(float rs)
    {
        _animator.SetFloat("XSpeed", rs);
    }

    public void Wall(bool wb)
    {
        _animator.SetBool("Wall", wb);
    }

    public void Roll(bool rb)
    {
        _animator.SetBool("Roll", rb);
    }

    public void Save(bool save)
    {
        _animator.SetBool("Save", save);
    }
    
    public void Damage(bool damage)
    {
        _animator.SetBool("Damage", damage);
    }
}
