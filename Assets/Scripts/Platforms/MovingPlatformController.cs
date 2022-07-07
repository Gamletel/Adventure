using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformController : MonoBehaviour
{
    private SliderJoint2D slider;
    private JointMotor2D motor;
    [SerializeField] private bool goUp = true;
    [SerializeField] private bool canElevate = true;
    private void Awake()
    {
        slider = GetComponent<SliderJoint2D>();
        motor = slider.motor;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (goUp && canElevate)
                    StartCoroutine(Elevate(1));
                if (!goUp && canElevate)
                    StartCoroutine(Elevate(-1));
            }
    }
    private IEnumerator Elevate(int speed)
    {
        canElevate = false;
        motor.motorSpeed = speed;
        goUp = !goUp;
        slider.motor = motor;
        yield return new WaitForSeconds(1f);
        canElevate = true;
    }

}