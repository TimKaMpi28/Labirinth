using System.Collections;
using System.Collections.Generic;
using System.Net.Mail;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D _player;
    [SerializeField] float _speed;
    Animator _animator;

    [SerializeField] Collider2D attackCol;

    private void Start()
    {
        _player = GetComponent<Rigidbody2D>();
        _animator = GetComponentInChildren<Animator>();
        attackCol.gameObject.SetActive(false);
    }
    void Update()
    {
        if (_animator.GetAnimatorTransitionInfo(0).IsName("ATTACK -> IDLE"))
        {
            attackCol.gameObject.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            _animator.SetTrigger("2_Attack");
            attackCol.gameObject.SetActive(true);
        }
        else
        {
            var hor_direction = Input.GetAxis("Horizontal");
            var ver_direction = Input.GetAxis("Vertical");
            var position = new Vector2(hor_direction, ver_direction).normalized * _speed * Time.deltaTime;
            if (position != Vector2.zero)
                _animator.SetBool("1_Move", true);
            else{
                _animator.SetBool("1_Move", false);
                _player.velocity = Vector2.zero;
            }
            _player.AddForce(position * 100);
            if(hor_direction < 0)
            {
                gameObject.transform.localScale = new Vector3(1, 1, 1);
            }
            if(hor_direction > 0)
            {
                gameObject.transform.localScale = new Vector3(-1, 1, 1);
            }
        }
    }
    
    private void FixedUpdate()
    {
        if (_player.velocity.magnitude > _speed)
        {
            var vel = _player.velocity.normalized * _speed;
            _player.velocity = vel;
        }
        //Debug.Log(_player.velocity);
    }

    void OnCollisionExit2D(Collision2D hit)
    {
        if (hit.gameObject.TryGetComponent<MovableObject>(out MovableObject obj))
        {
            obj.StopMove();
            Debug.Log("Stopped moving box!");
        }
    }
}
