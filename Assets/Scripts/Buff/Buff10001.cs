using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buff10001 : BuffBase
{
   
    public override void GetBuff()
    {
        bfHierarchy = 1; 
    }



    public override void DecreaseBuff()
    {
        base.DecreaseBuff();
        bfHierarchy = 0;
        base.ExitBuff(bfOwner, bfId);
        
    }


    

}
