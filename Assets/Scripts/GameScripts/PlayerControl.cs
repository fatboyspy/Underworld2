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
	
	public GameObject target=null;
    public bool showMobInfo;
    public Rect mobInfoRect;

    GameObject gameView;
    public GUISkin customSkin;

    float restoreTime;
    // Use this for initialization
    void Start()
    {
        showMobInfo = false;
        mobInfoRect = new Rect(300, 150, 200, 100);
        waterLine = GameObject.FindGameObjectWithTag("water").transform.position.y;
        gamerBody = GameObject.FindGameObjectWithTag("Player");
        controller = gamerBody.GetComponent(typeof(CharacterController)) as CharacterController;
        LoadPersonage();
		
        characterState = CharacterState.Idle;
        rotationSpeed = 200;
        moveSpeed =gamerTarget.WalkSpeed/3;

        gravity = 15;
        characterState = CharacterState.Idle;

        gameView = GameObject.FindGameObjectWithTag("MainCamera");

        restoreTime = 2;

        customSkin = (GUISkin)Resources.Load("NecromancerGUI/NecromancerGUI");
    }

    // Update is called once per frame
    void Update()
    {       

        if (target == null)
            showMobInfo = false;
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
        if (Input.GetKeyUp(KeyCode.R))
        {
            if (target != null && Vector3.Distance(target.transform.position, transform.position) <= 2.5f)
            {
                ((EnemyAI)target.GetComponent(typeof(EnemyAI))).mob.CurrentHealthPoints -= 10;
                if (((EnemyAI)target.GetComponent(typeof(EnemyAI))).mob.CurrentHealthPoints <=0)
                {
                    ((EnemyAI)target.GetComponent(typeof(EnemyAI))).mob.CurrentHealthPoints = 0;
                    gamerTarget.Expirience += ((EnemyAI)target.GetComponent(typeof(EnemyAI))).mob.ExpirienceForKill;
                    ((GameView)gameView.GetComponent(typeof(GameView))).targetGamer.Expirience = gamerTarget.Expirience;
                }

            }
        }
		SwitchAnimation();
        animation.CrossFade(currentAnimation);

        RestoreEnergie();
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

    void OnGUI()
    {
        if(showMobInfo)
            mobInfoRect = GUI.Window(10, mobInfoRect, MobInfoWindow, ((EnemyAI)target.GetComponent(typeof(EnemyAI))).name);

    }

    void MobInfoWindow(int windowID)
    {
        if (GUI.Button(new Rect(180, 5, 10, 10), GUIContent.none))
        {
            target = null;
        }
        if (target != null)
        {
            EnemyAI enemtAI = (EnemyAI)target.GetComponent(typeof(EnemyAI));

            GUI.Label(new Rect(5, 20, 190, 20), "Level - " + enemtAI.mob.Level,customSkin.GetStyle("Title"));
            GUI.Box(new Rect(5, 20 * 2, 190 * enemtAI.mob.CurrentHealthPoints / enemtAI.mob.HealthPoints, 20), "", customSkin.GetStyle("HealthBar"));
            GUI.Box(new Rect(5, 20 * 2, 190, 20), enemtAI.mob.CurrentHealthPoints.ToString() + "/" + enemtAI.mob.HealthPoints.ToString(), customSkin.GetStyle("BarBorder"));

            GUI.Box(new Rect(5, 20 * 3, 190 * enemtAI.mob.CurrentManaPoints / enemtAI.mob.ManaPoints, 20), "", customSkin.GetStyle("ManaBar"));
            GUI.Box(new Rect(5, 20 * 3, 190, 20), enemtAI.mob.CurrentManaPoints +"/"+ enemtAI.mob.ManaPoints, customSkin.GetStyle("BarBorder"));
        }
        GUI.DragWindow(new Rect(0, 0, 10000, 10000));
    }

    void RestoreEnergie()
    {
        if (restoreTime > 0)
        {
            restoreTime -= Time.deltaTime;
        }
        else
        {
            gamerTarget.CurrentHealthPoints+=3;
            if (gamerTarget.CurrentHealthPoints > gamerTarget.HealthPoints)
            {
                gamerTarget.CurrentHealthPoints = gamerTarget.HealthPoints;
            }

            gamerTarget.CurrentManaPoints += 2;
            if (gamerTarget.CurrentManaPoints > gamerTarget.ManaPoints)
            {
                gamerTarget.CurrentManaPoints = gamerTarget.ManaPoints;
            }
            restoreTime = 2;
        }        

        ((GameView)gameView.GetComponent(typeof(GameView))).targetGamer.CurrentHealthPoints = gamerTarget.CurrentHealthPoints;
        ((GameView)gameView.GetComponent(typeof(GameView))).targetGamer.CurrentManaPoints = gamerTarget.CurrentManaPoints;
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