using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.U2D;
using RPGM.Core;


public class CharacterController : MonoBehaviour
{
    public enum State { move, stopping, idle ,dropping,dialog}

    //GameModel model = Schedule.GetModel<GameModel>();
    public State state = State.idle;

    public GameObject bom;
    private GameObject bomb_instance;
   
    public float speed = 1;
    public float dropSpeed = 3f;

    Vector2 velo;
    public float acceleration = 2;
    public float nextMoveCommand;//inputControllerによって更新される。
    public float preMoveCommand;
                                   // public Animator animator;
    public bool flipX = false;
    
    public new Rigidbody2D rigidbody2D;
    SpriteRenderer spriteRenderer;
    PixelPerfectCamera pixelPerfectCamera;

    public bool stop_bool = false;
    public Transform preTransform;//動く前の座標取得
    public int tomarubasyo;

     Vector2 colSize;
bool isSetBomb=false;
    public GameObject particleBomb_pre;
    public void SetBomb()
    {
        if (isSetBomb||state==State.dropping)
        {
            return;
        }
            isSetBomb = true;
        bomb_instance=    Instantiate(bom, new Vector3(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y), Mathf.Round(transform.position.z)), Quaternion.identity);
        //Schedule.SetModel<GameObject>( bomb_instance);
    }
    public bool isGameOver = false;
    public void ExplodeBomb()
    {
        if (!isSetBomb) { return; }
        Instantiate(particleBomb_pre, bomb_instance.transform.position,Quaternion.identity);
        if (isGameOver) { 
            stageController.GameOver();
            state = State.dialog;
        }
        bomb_instance.GetComponent<BombController>().MyDestroy();
        isSetBomb = false;
    }
    public StageController stageController;
    private void GameOver()
    {
        Debug.Log("GameOver");

    }

    private void MoveState()
    {
        if (nextMoveCommand == 0) { state = State.stopping;return; }
        // velo = Vector2.zero;
        // rigidbody2D.AddForce(Vector3.down);
        //    preSpeed = rigidbody2D.velocity.x;
        //if (rigidbody2D.position.y - preY < 0)
        //{

        //    velo.y = Mathf.Clamp(rigidbody2D.velocity.y * 1.6f, -7, 0);
        //    velo.x = 0f;
        //}



        //if (stop_bool && Mathf.Abs(rigidbody2D.position.x - tomarubasyo) <= 0.1)
        //{
        //    //rigidbody2D.velocity = Vector2.zero;
        //    //rigidbody2D.velocity = new Vector2(0, -10);
        //    velo.x = 0;
        //    nextMoveCommand = 0;
        //    stop_bool = false;


        //}
        // if (!stop_bool)
        {
            //rigidbody2D.velocity = new Vector2(speed * nextMoveCommand, -10);
            velo.x = speed * nextMoveCommand;

        }
       // preY = rigidbody2D.position.y;
        //rigidbody2D.velocity = velo;

       
    }
    private void StoppingState() {
        //velo.x = speed * nextMoveCommand;
        if (Mathf.Abs(rigidbody2D.position.x - tomarubasyo) <= 0.1)
        {
           
            //rigidbody2D.velocity = Vector2.zero;
            //rigidbody2D.velocity = new Vector2(0, -10);
            velo.x = 0;
            //  nextMoveCommand = 0;
            // stop_bool = false;
            state = State.idle;

        }
        if (nextMoveCommand != 0) { state = State.move; }
      
       if (Mathf.Approximately(rigidbody2D.velocity.x, 0)) { state = State.idle; }
    }
    //idleからしかMovingできない
    //MovingからしかStoppingできない
    private void IdleState()
    {
    }
    
    private void Dropping()
    {
        velo.x = 0;
        velo.y = - dropSpeed;
        if(CheckGround() == true){ state = State.idle; }
    }
    public LayerMask layerMask;
    bool CheckGround()
    {
        bool isGround = false;
        Vector2 rayPos1 = new Vector2(rigidbody2D.position.x- colSize.x/2f , rigidbody2D.position.y -( colSize.y / 2f) );
        Vector2 rayPos2 = new Vector2(rigidbody2D.position.x + colSize.x / 2f , rigidbody2D.position.y - (colSize.y / 2f));
        RaycastHit2D hit1  =  Physics2D.Raycast(rayPos1 , Vector2.down,0.1f , layerMask);
        RaycastHit2D hit2 = Physics2D.Raycast(rayPos2, Vector2.down, 0.1f, layerMask);
        Debug.DrawRay(rayPos1, Vector2.down*0.1f);
        Debug.DrawRay(rayPos2, Vector2.down * 0.1f);

        if (hit1.collider!=null || hit2.collider!=null){
            
            isGround = true;
        
        }
        return isGround;
    }
    private void FixedUpdate()
    {
        //velo = Vector2.zero;
        bool isGround = CheckGround();
        //Debug.Log(isGround);
        if (isGround == false) { state = State.dropping; }
        else if(state==State.idle && nextMoveCommand != 0)
        {
            state = State.move;
        }

        switch (state)
        {
            case State.dropping:
                Dropping();
                break;
            case State.idle:
                IdleState();
                break;
            case State.move:
                MoveState();
                break;
            case State.stopping:
                StoppingState();
                break;
            case State.dialog:
                velo = Vector2.zero;
                break;
        }
        rigidbody2D.velocity = velo;    
    }
    
    //void Update()
    //{
    //   // rigidbody2D.velocity = new Vector2(speed * nextMoveCommand, 0);
    //    //    rigidbody2D.AddForce(Vector3.down*10);
    //}
    void LateUpdate()
    {
        if (pixelPerfectCamera != null)
        {
            transform.position = pixelPerfectCamera.RoundToPixel(transform.position);
        }
       
    }
    void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        pixelPerfectCamera = GameObject.FindObjectOfType<PixelPerfectCamera>();
        BoxCollider2D col = GetComponent<BoxCollider2D>();
        colSize = col.size + col.edgeRadius*Vector2.one;//collisionのedge分考慮
    }
}
