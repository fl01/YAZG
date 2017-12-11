using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets._2D
{
    [RequireComponent(typeof (MainCharacterMovementControl))]
    public class MainCharacterControl : MonoBehaviour
    {
        private MainCharacterMovementControl m_Character;
        private bool m_Jump;


        private void Awake()
        {
            m_Character = GetComponent<MainCharacterMovementControl>();
        }


        private void Update()
        {
            if (!m_Jump)
            {
                // Read the jump input in Update so button presses aren't missed.
                m_Jump = CrossPlatformInputManager.GetButtonDown("Jump");
            }

            if (Input.GetButton("Fire1"))
            {
                transform.Find("PlayerWeapon").GetComponent<Weapon>().Shoot();
            }                
        }


        private void FixedUpdate()
        {
            // Read the inputs.
            bool crouch = Input.GetKey(KeyCode.LeftControl);
            float h = CrossPlatformInputManager.GetAxis("Horizontal");
            // Pass all parameters to the character control script.
            m_Character.Move(h, crouch, m_Jump);
            m_Jump = false;
        }
    }
}
