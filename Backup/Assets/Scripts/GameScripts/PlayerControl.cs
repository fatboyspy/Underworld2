using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
public class PlayerControl : MonoBehaviour
{    
    public GameObject gamerBody;
    public CharacterController controller;
    public float gravity;
    public float waterLine;
    public MovementState moveState;

    public float rotationSpeed;
    public float moveSpeed;

    string currentAnimation;
	
	public TerrainCollider terrainCollider;
	public GameObject terrainGO;
	public float onAirTimer;
  
    // Use this for initialization
    void Start()
    {
        waterLine = GameObject.FindGameObjectWithTag("water").transform.position.y;
        gamerBody = GameObject.FindGameObjectWithTag("Player");
        controller = gamerBody.GetComponent(typeof(CharacterController)) as CharacterController;
		
		terrainGO=GameObject.FindGameObjectWithTag("terrain");
		terrainCollider=terrainGO.GetComponent(typeof(TerrainCollider)) as TerrainCollider;
		
        moveState = MovementState.Idle;
        rotationSpeed = 200;
        moveSpeed = 5;

        gravity = 5;
        moveState = MovementState.Idle;

    }

    // Update is called once per frame
    void Update()
    {
		AdjustGravity();
        if (Mathf.Abs(Input.GetAxis("Horizontal")) > 0)
        {
            controller.transform.Rotate(0, Input.GetAxis("Horizontal") * Time.deltaTime * rotationSpeed, 0);
            moveState = MovementState.Walk;
        }
        if (Mathf.Abs(Input.GetAxis("Vertical")) > 0)
        {
			
			if(controller.isGrounded)
			{
            	if (Input.GetKey(KeyCode.LeftShift))
            	{
                	moveState = MovementState.Run;
            	}
            	else
            	{
                	moveState = MovementState.Walk;
            	}
            controller.SimpleMove(transform.TransformDirection(Vector3.forward) * Input.GetAxis("Vertical") * moveSpeed);
			}
        }
		else
            moveState = MovementState.Idle;	
		if (isUnderwater())
		{
	       	moveState = MovementState.Swim;	
			controller.SimpleMove(transform.TransformDirection(Vector3.forward) * Input.GetAxis("Vertical") * moveSpeed);
		}
		if (!controller.isGrounded && !isUnderwater())
		{
           	moveState = MovementState.Fall;
			controller.SimpleMove(Vector3.down * Time.deltaTime * gravity);
		}
     		
        SwitchAnimation();
		
        animation[currentAnimation].speed = 0.4f;
        animation.CrossFade(currentAnimation);
    }

    void SwitchAnimation()
    {
        switch (moveState)
        {
            case MovementState.Idle:
                currentAnimation = "idle";
                break;
            case MovementState.Run:
                currentAnimation = "Run_Hand";
                moveSpeed = 6;
                break;
            case MovementState.Walk:
                currentAnimation = "Walk_Hand";
                moveSpeed = 3;
                break;
            case MovementState.Swim:
                currentAnimation = "Swim";
				moveSpeed=2;
                break;
            case MovementState.Fall:
                currentAnimation = "Falling";
                break;
        }
    }
	void AdjustGravity()
	{
		if(isUnderwater())
			gravity=0.1f;
		else
			gravity=8;
	}
	bool isUnderwater()
	{
		return(transform.position.y < waterLine - 2)?true:false;
	}

}
public enum MovementState
{
    Idle,
    Walk,
    Run,
    Fall,
    Swim
}