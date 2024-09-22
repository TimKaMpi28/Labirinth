using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] Transform _target;
    [SerializeField] GameObject bullet;
    [SerializeField] float cooldown = 5f;
    private float _passedTime;
    [SerializeField] LayerMask attackMask;
    // Start is called before the first frame update
    void Start()
    {
        _passedTime = 0f;
        Debug.Log(attackMask.value);
    }

    void FixedUpdate()
    {
        //Debug.Log(_passedTime);
        if (_passedTime >= cooldown)
        {
            RaycastHit2D hit;
            var pos =  _target.position - transform.position;
            //var angle = Vector2.Angle(transform.forward, pos);
            //Ray ray = new Ray(transform.position, _target.position - transform.position);
            hit = Physics2D.Raycast(transform.position, pos, 50f, LayerMask.GetMask("Default"));
            if (hit.collider != null)
            {
                if (hit.collider.gameObject == _target.gameObject)
                {
                    var crBullet = Instantiate(bullet, transform.position + pos / 10, Quaternion.identity);
                    crBullet.GetComponent<Rigidbody2D>().velocity = pos.normalized * 20f;
                    _passedTime = 0f;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        _passedTime += Time.deltaTime;
        Debug.DrawLine(transform.position, _target.position, Color.yellow);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.gameObject.layer);
        if (other.gameObject.layer == 6)
        {
            Destroy(gameObject);
        }
    }
}
