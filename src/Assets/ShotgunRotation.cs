using UnityEngine;
using UnityStandardAssets._2D;

public class ShotgunRotation : MonoBehaviour
{
    public int maxRotation = 55;
    private MainCharacterMovementControl _mainCharacterMovement;

    void Awake()
    {
        _mainCharacterMovement = transform.GetComponentInParent<MainCharacterMovementControl>();
        if (_mainCharacterMovement == null)
        {
            Debug.LogError("Character movement is missing");
        }
    }

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 difference = mousePos - transform.position;
            difference.Normalize();

            if (!_mainCharacterMovement.facingRight)
            {
                difference *= -1;
            }

            float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

            if (rotationZ <= -maxRotation) // down
            {
                rotationZ = -maxRotation;
            }
            else if (rotationZ >= maxRotation) // up
            {
                rotationZ = maxRotation;
            }

            transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);
        }
    }
}
