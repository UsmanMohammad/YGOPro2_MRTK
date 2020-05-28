using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class iTweenExtensions
{
    public static void MoveToAction(GameObject target, Vector3 position, float time, Action act,
        float delay = 0)
    {
        if (delay == 0)
        {
            iTween.MoveTo(target, iTween.Hash("position", position, "time", time, "oncomplete", act));
        }
        else
        {
            iTween.MoveTo(target, iTween.Hash("position", position, "time", time, "delay", delay, "oncomplete", act));
        }
    }

    public static void MoveToLocal(GameObject target, Vector3 position, float time)
    {
        iTween.MoveTo(target, iTween.Hash("position", position, "time", time, "islocal", true));
    }

    public static float easeOutQuad(float start, float end, float value)
    {
        end -= start;
        return -end * value * (value - 2) + start;
    }

    public static void ScaleToE(GameObject target, Vector3 scale, float time)
    {
        iTween.ScaleTo(target, iTween.Hash("scale", scale, "time", time, "easeType", iTween.EaseType.spring));
    }

    public static void ScaleToAction(GameObject target, Vector3 scale, float time, Action act, float delay = 0)
    {
        if (delay == 0)
        {
            iTween.ScaleTo(target, iTween.Hash("scale", scale, "time", time, "oncomplete", act));
        }
        else
        {
            iTween.ScaleTo(target, iTween.Hash("scale", scale, "time", time, "delay", delay, "oncomplete", act));
        }

    }
}
