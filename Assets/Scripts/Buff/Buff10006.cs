using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �ɳ�buff �����Ե� û�е���ʱҲ���ܵ���
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
