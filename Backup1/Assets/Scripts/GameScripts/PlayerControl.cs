using UnityEngine;
using System.Collections;
using System;

[RequireComponent(typeof(CharacterController))]
public class PlayerControl : MonoBehaviour
{
    public Gamer gamerTarget;
    public GameObject gamerBody;
    public CharacterController controller;
    public float gravity;
    public float waterLine;
    public CharacterState characterState;
    public float rotationSpeed;
    public float moveSpeed;
    string currentAnimation; 
	public float onAirTimer;
	
	public GameObject target;
  
    // Use this for initialization
    void Start()
    {
        waterLine = GameObject.FindGameObjectWithTag("water").transform.position.y;
        gamerBody = GameObject.FindGameObjectWithTag("Player");
        controller = gamerBody.GetComponent(typeof(CharacterController)) as CharacterController;
        LoadPersonage();
		
        characterState = CharacterState.Idle;
        rotationSpeed = 200;
        moveSpeed =gamerTarget.WalkSpeed/3;

        gravity = 15;
        characterState = CharacterState.Idle;
    }

    // Update is called once per frame
    void Update()
    {
        
		AdjustGravity();     		
		
        if (Mathf.Abs(Input.GetAxis("Horizontal")) > 0)
        {
            controller.transform.Rotate(0, Input.GetAxis("Horizontal") * Time.deltaTime * rotationSpeed, 0);
            characterState = CharacterState.Walk;
        }
        if (Mathf.Abs(Input.GetAxis("Vertical")) > 0)
        {		
			if(!isUnderwater())
			{
            	if (Input.GetKey(KeyCode.LeftShift))
            	{
                	characterState = CharacterState.Run;
            	}
            	else
            	{
                	characterState = CharacterState.Walk;
            	}
            controller.SimpleMove(transform.TransformDirection(Vector3.forward) * Input.GetAxis("Vertical") * moveSpeed);
			}
        }
		else
            characterState = CharacterState.Idle;	
		
        if (isUnderwater())
        {
           	characterState = CharacterState.Swim;
           	controller.SimpleMove(transform.TransformDirection(Vector3.forward) * Input.GetAxis("Vertical") * moveSpeed);
        }
		/*if(Input.GetKey(KeyCode.R))
		{
			characterState=CharacterState.Attack;
		}*/
		SwitchAnimation();
        animation.CrossFade(currentAnimation);
    }

    void SwitchAnimation()
    {
        switch (characterState)
        {
            case CharacterState.Idle:
                currentAnimation = "idle";
                animation[currentAnimation].speed = 0.4f;
                break;
            case CharacterState.Run:
                currentAnimation = "Run_Hand";
                moveSpeed = gamerTarget.RunSpeed/2.5f;
                animation[currentAnimation].speed = moveSpeed/10;
                break;
            case CharacterState.Walk:
                currentAnimation = "Walk_Hand";
                moveSpeed = gamerTarget.WalkSpeed/2;
                animation[currentAnimation].speed = moveSpeed / 10;
                break;
            case CharacterState.Swim:
                currentAnimation = "Swim";
				moveSpeed=gamerTarget.WalkSpeed/2;
                animation[currentAnimation].speed = moveSpeed / 10;
                break;
            case CharacterState.Attack:
                currentAnimation = "Atk01_Hand";
                animation[currentAnimation].speed = gamerTarget.PhisicalAttackSpeed / 10;
                break;
        }
    }
	void AdjustGravity()
	{
		if(isUnderwater())
			gravity=0.1f;
		else
			gravity=15;
	}
	bool isUnderwater()
	{
		return(transform.position.y < waterLine - 2)?true:false;
	}
    void LoadPersonage()
    {
        string[] gamerInfo = PlayerPrefs.GetString("underworld_character").Split(';');
        gamerTarget = new Gamer(gamerInfo[0], (PlayerRace)Convert.ToInt32(gamerInfo[1]), (CreatureGender)Convert.ToInt32(gamerInfo[2]), (PlayerOccupation)Convert.ToInt32(gamerInfo[3]), Convert.ToInt32(gamerInfo[4]), Convert.ToInt32(gamerInfo[5]), Convert.ToInt32(gamerInfo[6]), Convert.ToInt32(gamerInfo[7]), Convert.ToInt32(gamerInfo[8]), Convert.ToInt32(gamerInfo[9]), Convert.ToInt32(gamerInfo[10]), Convert.ToInt32(gamerInfo[11]));
    }
}

public enum CharacterState
{
    Idle,
    Walk,
    Run,
    Swim,
    Attack
}