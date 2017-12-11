using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilePhysics : MonoBehaviour {

    #region Variables

    private Rigidbody2D _bullet;
    public float Shotspeed = 10;
    public int Damage = 1;

    private Vector3 _debugStartPos;
    #endregion Variables

    // Use this for initialization
    void Start () {
        DontDestroyOnLoad(this);

        _bullet = GetComponent<Rigidbody2D>();
        _debugStartPos = _bullet.velocity;
        Destroy(gameObject, 4);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnDestroy()
    {
        Debug.DrawLine(_debugStartPos, GetComponent<Rigidbody2D>().velocity);
    }
}
