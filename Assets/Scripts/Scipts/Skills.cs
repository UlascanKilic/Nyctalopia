using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skills : MonoBehaviour
{
   public void useFocus()
    {
        if (barCheck())
        {

        }
        else
        {

        }
    }
   public void useShield()
   {
        if (barCheck())
        {

        }
    }
   public void useYumak()
    {
        if (barCheck())
        {

        }
    }
   public bool barCheck()
    {
        // if (sb.currentExp == sb.maxExp)
        // {
        //     //sb.currentExp = 0;
        //     return true;
        // }
        // else
        // {
        //     return false;
        // }           
        return false;
    }
   public void useExp()
    {
        //sb.currentExp = 0;
    }
}
