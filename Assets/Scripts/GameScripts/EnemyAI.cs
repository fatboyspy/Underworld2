using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
public class EnemyAI : MonoBehaviour {
    public Mob mob;
	public GameObject enemyBody;
	public GameObject gamer;
    public string name;
    string currentAnimation;
    public MobState mobState;
    public float moveSpeed;

	// Use this for initialization
	void Start () {
   
        mob = MobsLibrary.GetMobByName(name);
        mob.CurrentHealthPoints = mob.HealthPoints;
        gamer = GameObject.FindGameObjectWithTag("Player");
        mobState = MobState.Idle;
        animation.wrapMode = WrapMode.Loop;
  
	}
	
	// Update is called once per frame
	void Update () {
        if (mobState != MobState.Die)
        {
            if (!((CharacterController)enemyBody.GetComponent(typeof(CharacterController))).isGrounded)
            {
                ((CharacterController)enemyBody.GetComponent(typeof(CharacterController))).Move(Vector3.down * Time.deltaTime*50);
            }
            if (Vector3.Distance(gamer.transform.position, transform.position) >= 2 && Vector3.Distance(gamer.transform.position, transform.position) <= 20)
            {
                mobState = MobState.Run;
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(gamer.transform.position - transform.position), 3 * Time.deltaTime);
                transform.position += transform.forward * (mob.RunSpeed / 3) * Time.deltaTime;
            }
            if (Vector3.Distance(gamer.transform.position, transform.position) > 20)
                mobState = MobState.Idle;
            if (Vector3.Distance(gamer.transform.position, transform.position) <= 2.5f)
            {
                mobState = MobState.Attack;
            }
        }
        if (mob.CurrentHealthPoints <= 0)
        {
            mobState = MobState.Die;
        }
        SwitchAnimation();      
        animation.CrossFade(currentAnimation);	
	}
    void LateUpdate()
    {
        if (mobState == MobState.Die)
        {
            ((PlayerControl)gamer.GetComponent(typeof(PlayerControl))).target = null;
            ((PlayerControl)gamer.GetComponent(typeof(PlayerControl))).showMobInfo = false;


        }

    }
	void OnGUI()
	{
       
	}
    void OnMouseEnter()
    {
    }
    void OnMouseDown()
    {
        ((PlayerControl)gamer.GetComponent(typeof(PlayerControl))).target = enemyBody;
        ((PlayerControl)gamer.GetComponent(typeof(PlayerControl))).showMobInfo = true;
       

    }
    void OnMouseExit()
    {

    }
    void OnMouseUp()
    {
    }
    void SwitchAnimation()
    {
        switch (mobState)
        {
            case MobState.Idle:
                currentAnimation = "idle";
                animation[currentAnimation].speed = 0.4f;
                break;
            case MobState.Run:
                currentAnimation = "run";
                moveSpeed = mob.RunSpeed / 2.5f;
                animation[currentAnimation].speed = moveSpeed / 8;
                break;
            case MobState.Walk:
                currentAnimation = "Walk";
                moveSpeed = mob.WalkSpeed / 2;
                animation[currentAnimation].speed = moveSpeed / 8;
                break;
            case MobState.Die:
                currentAnimation = "death";
                moveSpeed = mob.WalkSpeed / 2;
                animation[currentAnimation].speed = 0.4f;
                animation.wrapMode = WrapMode.Once;
                break;
            case MobState.Attack:
                currentAnimation = "atk01";
                animation[currentAnimation].speed = mob.PhisicalAttackSpeed/3;
                break;
        }
    }

    
}
public enum MobState
{
    Idle,
    Walk,
    Run,
    Attack,
    Die
}
