using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MovableObject : MonoBehaviour
{
    public void StopMove(){
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }
}
