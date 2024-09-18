using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D _player;
    [SerializeField] float _speed;
    Animator _animator;

    private void Start()
    {
        _player = GetComponent<Rigidbody2D>();
        _animator = GetComponentInChildren<Animator>();
    }
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.F))
        //{
        //    _animator.SetTrigger("2_Attack");
        //}
        var her_direction = Input.GetAxis("Horizontal");
        var ver_direction = Input.GetAxis("Vertical");
        var position = new Vector2(her_direction, ver_direction).normalized * _speed * Time.deltaTime;
        if (position != Vector2.zero)
            _animator.SetBool("1_Move", true);
        else
            _animator.SetBool("1_Move", false);
        transform.Translate(position);
    }
    
    private void FixedUpdate()
    {

    }
}
