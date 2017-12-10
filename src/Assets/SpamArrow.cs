using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpamArrow : MonoBehaviour
{

    private Rigidbody2D _body;
    void Awake()
    {
        _body = GetComponent<Rigidbody2D>();
    }
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _body.AddForce(transform.up * 10f);
    }
}
