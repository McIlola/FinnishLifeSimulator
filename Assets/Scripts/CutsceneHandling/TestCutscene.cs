using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCutscene : CutsceneBase
{
    public override void Execute()
    {
        StartCoroutine(WaitAndAdvance());
        Debug.Log("Script in execution:" + name);
    }
}
