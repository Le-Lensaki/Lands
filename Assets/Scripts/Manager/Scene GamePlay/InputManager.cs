using Assets.Scripts.Item.IDItem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : Singleton<InputManager>
{
    protected Vector2 inputVector;
    public Vector2 InputVector { get { return inputVector; } }

    protected Vector3 mouseWorldPos;
    public Vector3 MouseWorldPos { get => mouseWorldPos; }

    protected bool speedUp;
    public bool SpeedUp { get { return speedUp; } }

    protected bool action;
    public bool Action { get { return action; } }

    [SerializeField] protected JoystickController joystick;

    protected override void Awake()
    {
        base.Awake();
        inputVector = Vector2.zero;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadJoystickController();
    }

    protected virtual void LoadJoystickController()
    {
        if (joystick != null) return;

        joystick = GameObject.Find("UIJoyStick").GetComponent<JoystickController>();

        Debug.Log(transform.name + ": LoadJoystickController", gameObject);
    }

    private void Update()
    {
        GetVector();
        //ActionKeyOnPC();
        GetMousePos();
    }

    protected virtual void GetMousePos()
    {
        //Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //this.mouseWorldPos = pos;

        if (Input.touchCount > 0)
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            pos.z = 0;
            this.mouseWorldPos = pos;
        }
        else
        {
            return;
        }
    }

    void GetVector()
    {
        //inputVector.x = Input.GetAxis("Horizontal");
        //inputVector.y = Input.GetAxis("Vertical");

        inputVector = joystick.InputVector;
    }
    
    public virtual void Speed()
    {
        speedUp = !speedUp;
    }
    public void PlayerAction()
    {
        action = true;
    }
    public void PlayerStop()
    {
        action = false;
    }

    //void ActionKeyOnPC()
    //{
    //    if (Input.GetKey(KeyCode.LeftShift))
    //    {
    //        Speed();
    //    }
    //    else if (Input.GetKey(KeyCode.Space))
    //    {
    //        action = true;
    //    }
    //    else if (Input.GetKeyDown(KeyCode.Alpha1))
    //    {
    //        PlayerController.Instance.PlayerSetItemUse(IDKeyNumber.Holding1);
    //    }
    //    else if (Input.GetKeyDown(KeyCode.Alpha2))
    //    {
    //        PlayerController.Instance.PlayerSetItemUse(IDKeyNumber.Holding2);
    //    }
    //    else if (Input.GetKeyDown(KeyCode.Alpha3))
    //    {
    //        PlayerController.Instance.PlayerSetItemUse(IDKeyNumber.Holding3);
    //    }
    //    else if (Input.GetKeyDown(KeyCode.Alpha4))
    //    {
    //        PlayerController.Instance.PlayerSetItemUse(IDKeyNumber.Holding4);
    //    }
    //    else if (Input.GetKeyDown(KeyCode.Alpha5))
    //    {
    //        PlayerController.Instance.PlayerSetItemUse(IDKeyNumber.Holding5);
    //    }
    //    else if (Input.GetKeyDown(KeyCode.Alpha6))
    //    {
    //        PlayerController.Instance.PlayerSetItemUse(IDKeyNumber.Holding6);
    //    }
    //    else if (Input.GetKeyDown(KeyCode.Alpha7))
    //    {
    //        PlayerController.Instance.PlayerSetItemUse(IDKeyNumber.Holding7);
    //    }
    //    else if (Input.GetKeyDown(KeyCode.B))
    //    {
    //        UIManagerSceneMainGame.Instance.OpenInventory();
    //    }
    //    else if (Input.GetKeyDown(KeyCode.F))
    //    {
    //        //PlayerController.Instance.TalkNormal();
    //        WorldTime.Instance.WakeUP();
    //    }
    //    else if (Input.GetKeyDown(KeyCode.Z))
    //    {
    //        BoatController.Instance.RunBoat();
    //    }
    //    else
    //    {
    //        action = false;
    //        return;
    //    }
    //}    

}
