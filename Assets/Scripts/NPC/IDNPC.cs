using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public enum IDNPC
    {
        NoNPC = 0,

        Noah = 1,
    }

    public class IDNPCParser
    {
        public static IDNPC FromString(string itemName)
        {
            try
            {
                return (IDNPC)System.Enum.Parse(typeof(IDNPC), itemName);
            }
            catch (ArgumentException e)
            {
                Debug.LogError(e.ToString());
                return IDNPC.NoNPC;
            }
        }
    }

