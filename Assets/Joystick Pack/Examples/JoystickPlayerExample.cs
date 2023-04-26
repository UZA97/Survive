using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickPlayerExample : MonoBehaviour
{
    public float speed;
    public VariableJoystick variableJoystick;
    public SPUM_Prefabs spum;
	private void Start()
	{
        //variableJoystick.SetMode(JoystickType.Floating);
	}
	public void FixedUpdate()
    {
        Vector3 direction = Vector3.up * variableJoystick.Vertical + Vector3.right * variableJoystick.Horizontal;
        this.transform.position += direction*speed;
		if(variableJoystick.Horizontal > 0)
			this.transform.rotation =new Quaternion(0,-180,0,0);
		else if(variableJoystick.Horizontal < 0)
			this.transform.rotation =new Quaternion(0,0,0,0);


        if(direction != new Vector3(0, 0, 0))
			spum.PlayAnimation(1);
		else
			spum.PlayAnimation(0);

		//rb.AddForce(direction * speed * Time.fixedDeltaTime, ForceMode.VelocityChange);
		//Vector2 direction = Vector3.forward * variableJoystick.Vertical + Vector3.right * variableJoystick.Horizontal;
		//this.transform.position = direction;
	}

}