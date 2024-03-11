
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;


public class InputTest : MonoBehaviour
{
    public delegate string BuffNameDelegate(GameObject obj) ;
    BuffNameDelegate myDelegate;


    public delegate float BufftotalPowerDelegate(GameObject obj);
    BufftotalPowerDelegate powerdelegate;



    public bool isFinishBuff;
    public GameObject playerobj;
    public GameObject BuffObj;


    // Update is called once per frame

    private void Start()
    {
        myDelegate = BuffMgr.GetInstance().GetBuffName;
        powerdelegate = BuffMgr.GetInstance().GetBuffPower;
        isFinishBuff = true;
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.F1))
        {
            playerobj.GetComponent<Player>().NowHp += 500;
        }

        //buff10001-10006
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            InputUItest<Buff10001>(playerobj,"test", 10001);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            InputUItest<Buff10002>(playerobj, "test", 10002);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            InputUItest<Buff10003>(playerobj, "test", 10003);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            InputUItest<Buff10004>(playerobj, "test", 10004);
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            InputUItest<Buff10005>(playerobj, "test", 10005);
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            InputUItest<Buff10006>(playerobj, "test", 10006);
        }

        //Çå¿ÕËùÓÐbuff
        if (Input.GetKeyDown(KeyCode.Space))
        {
            BuffMgr.GetInstance().DelectDicBuff(playerobj);
            playerobj.GetComponent<Player>().BuffName = myDelegate(playerobj);
            isFinishBuff = false;
            BuffMgr.GetInstance().ClearallBuffobj();
        }
    }

    private void FixedUpdate()
    {
        float tempharm = powerdelegate(playerobj);
        if (tempharm > 0)
        {
            playerobj.GetComponent<Player>().NowHp -= tempharm;
            return; 
        }
        else if(!isFinishBuff)
        {
                        
            playerobj.GetComponent<Player>().BuffName = myDelegate(playerobj);
            isFinishBuff = true;
           
        }
        
    }


    public void InputUItest<T>(GameObject Owner,string provider,int number) where T : BuffBase, new()
    {
        BuffMgr.GetInstance().AddBuff<T>(Owner, provider, number);
        playerobj.GetComponent<Player>().BuffName = myDelegate(playerobj);
        BuffMgr.GetInstance().GetBuffObj(Owner,number);
        foreach (GameObject obj in BuffMgr.GetInstance().uibuff)
        {
            obj.transform.SetParent(BuffObj.transform);
        }
        isFinishBuff = false;
    }
}
