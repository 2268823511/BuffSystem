using UnityEngine;
/// <summary>
/// Buff种类
/// </summary>
public enum BuffType{
    additivity=1,   //可叠加
    mutual=-1,   //互斥
    concurrence=0   //可共生
}

public class BuffBase{
    //id
    public int bfId;
    //类型
    public BuffType bfType;
    //buff时间
    public int existTime;
    //剩下的时间
    public int reTime;
    //名称
    public string bfName;
    //描述
    public string bfDescribe;
    //层数
    public int bfHierarchy;
    //持有者
    public GameObject bfOwner;
    //提供者
    public string bfProvider;
    //图标名
    public string bfIcon;
    //减少规则
    public int bfDecreaseRule;
    //增加规则
    public int bfIncreaseRule;

    //buff基础伤害
    public float Power;


    /// <summary>
    /// 初始化函数
    /// </summary>
    /// <param name="id"></param>
    public virtual void Initbuff(GameObject owner,string Provider,int id)
    {
        bfId = Player_Buff.Get(id).buff_id;
        bfType = (BuffType)Player_Buff.Get(id).buff_type;
        existTime = Player_Buff.Get(id).buff_time;
        //不确定要不要这样写 最好给子类自己时间 因为有些buff会刷新时间,有些buff不刷新时间
        reTime = existTime;
        bfName = Player_Buff.Get(id).buff_name;
        bfDescribe = Player_Buff.Get(id).buff_info;
        bfHierarchy = 1;
        //bfOwner = Player_Buff.config.buff_owner;
        bfIcon = Player_Buff.Get(id).buff_icon;
        bfDecreaseRule = Player_Buff.Get(id).buff_decrease;
        bfIncreaseRule = Player_Buff.Get(id).buff_increase;

        bfOwner=owner;
        bfProvider=Provider;
        Power = Player_Buff.Get(bfId).buff_harm ;
    }


    /// <summary>
    /// 增加层数
    /// </summary>
    public virtual void GetBuff(){
        if (bfType == BuffType.additivity)
        {
            bfHierarchy += 1;
        }
    }

    /// <summary>
    /// 更新时间
    /// </summary>
    public virtual void UpdateBuff(){
        if (reTime >= 0) {
            reTime -= 1;
        }

        //float power= Player_Buff.Get(bfId).buff_harm;
        //如果子类的buff伤害计算不一样 则自己重写
        //totalPower = power * (existTime - reTime);
    }

    public virtual void ExitBuff(GameObject owner, int buffid)
    {
        BuffMgr.GetInstance().RemoveBuff(owner, buffid);
    }
    /// <summary>
    /// 增加层数规则 刷新或者不刷新时间
    /// </summary>
    public virtual void InCreateBuff()
    {
        if (bfIncreaseRule == 1) {

            reTime = existTime;
        }
    }

    public virtual void DecreaseBuff(){
       
    }
 
}

