using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buff10003 : BuffBase
{

    public override void GetBuff()
    {
        bfHierarchy = 1;
    }


    public override void DecreaseBuff()
    {
       
        base.DecreaseBuff();
        //if (reTime >= 0) return;
        bfHierarchy -= 1;
        if (bfHierarchy == 0)
        {

            base.ExitBuff(bfOwner, bfId);
        }
        else
        {
            reTime = existTime;
        }

    }

}

