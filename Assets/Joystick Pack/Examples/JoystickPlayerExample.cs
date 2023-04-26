using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickPlayerExample : MonoBehaviour
{
    public float speed;
    public VariableJoystick variableJoystick;

    public void FixedUpdate()
    {
        Vector3 direction = Vector3.up * variableJoystick.Vertical + Vector3.right * variableJoystick.Horizontal;
        this.transform.position += direction*speed;
        //rb.AddForce(direction * speed * Time.fixedDeltaTime, ForceMode.VelocityChange);

        //Vector2 direction = Vector3.forward * variableJoystick.Vertical + Vector3.right * variableJoystick.Horizontal;
        //this.transform.position = direction;
    }
	private void OnCollisionExit2D(Collision2D collision)
	{

    }

	private void OnCollisionEnter2D(Collision2D collision)
	{

    }
}