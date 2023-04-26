using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SPUM_Prefabs : MonoBehaviour
{
    float fKnockTime = 0.5f;
    public float speed = 1;
    public VariableJoystick variableJoystick;
    public SPUM_SpriteList _spriteOBj;
    public bool EditChk;
    public bool isKnock = false;
    public string _code;
    public Animator _anim;


	private void Update()
	{
        if (Input.GetKeyDown(KeyCode.A))
		{
			EditChk = false;
			PlayAnimation(2);
		}
		else if (Input.GetKeyDown(KeyCode.S))
		{
            Debug.Log("s");
            isKnock = true;
		}
		else if (Input.GetKeyDown(KeyCode.D))
			PlayAnimation(4);
		else if (Input.GetKeyDown(KeyCode.F))
			PlayAnimation(5);
		else if (Input.GetKeyDown(KeyCode.G))
			PlayAnimation(6);
		else if (Input.GetKeyDown(KeyCode.H))
			PlayAnimation(7);
		else if (Input.GetKeyDown(KeyCode.Q))
		{
			EditChk = true;
			_anim.SetBool("EditChk", EditChk);
		}
	}
	private void FixedUpdate()
	{
        if (!isKnock)
        {
            Vector3 direction = Vector3.up * variableJoystick.Vertical + Vector3.right * variableJoystick.Horizontal;
            this.transform.position += direction * speed;
            if (variableJoystick.Horizontal > 0)
                this.transform.rotation = new Quaternion(0, -180, 0, 0);
            else if (variableJoystick.Horizontal < 0)
                this.transform.rotation = new Quaternion(0, 0, 0, 0);

            if (direction != new Vector3(0, 0, 0))
                PlayAnimation(1);
            else
                PlayAnimation(0);
        }
        else
        {
            PlayAnimation(3);
            fKnockTime -= Time.deltaTime;
            if (fKnockTime <= 0)
            {
                fKnockTime = 0.5f;
                isKnock = false;
            }
        }
    }
	public void PlayAnimation (int num)
    {
        switch(num)
        {
            case 0: //Idle
            _anim.SetFloat("RunState",0f);
            break;

            case 1: //Run
            _anim.SetFloat("RunState",0.5f);
            break;

            case 2: //Death
            _anim.SetTrigger("Die");
            _anim.SetBool("EditChk",EditChk);
            break;

            case 3: //Stun
            _anim.SetFloat("RunState",1.0f);
            break;

            case 4: //Attack Sword
            _anim.SetTrigger("Attack");
            _anim.SetFloat("AttackState",0.0f);
            _anim.SetFloat("NormalState",0.0f);
            break;

            case 5: //Attack Bow
            _anim.SetTrigger("Attack");
            _anim.SetFloat("AttackState",0.0f);
            _anim.SetFloat("NormalState",0.5f);
            break;

            case 6: //Attack Magic
            _anim.SetTrigger("Attack");
            _anim.SetFloat("AttackState",0.0f);
            _anim.SetFloat("NormalState",1.0f);
            break;

            case 7: //Skill Sword
            _anim.SetTrigger("Attack");
            _anim.SetFloat("AttackState",1.0f);
            _anim.SetFloat("NormalState",0.0f);
            break;

            case 8: //Skill Bow
            _anim.SetTrigger("Attack");
            _anim.SetFloat("AttackState",1.0f);
            _anim.SetFloat("NormalState",0.5f);
            break;

            case 9: //Skill Magic
            _anim.SetTrigger("Attack");
            _anim.SetFloat("AttackState",1.0f);
            _anim.SetFloat("NormalState",1.0f);
            break;
        }
    }
}
