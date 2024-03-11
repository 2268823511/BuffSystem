using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 成长buff 永久性的 没有倒计时也不能叠层
/// </summary>
public class Buff10006 : BuffBase
{
    public override void GetBuff()
    {
        bfHierarchy = 1;
    }


    public override void DecreaseBuff()
    {
        base.DecreaseBuff();
        
    }

    public override void UpdateBuff()
    {
        base.UpdateBuff();
    }
}
