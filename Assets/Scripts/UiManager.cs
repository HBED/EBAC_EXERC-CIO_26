using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.Core.Singleton;

public class UiManager : Singleton<UiManager>
{
    public ParticleSystem particleEnd;
    public Animator animation;

    public bool DoEffect(UiEffectType uiEffectType, Transform elementTransform)
    {

        if (uiEffectType == UiEffectType.SuperGrowth)
        {
            Debug.Log("OI");
        }
        else if(uiEffectType == UiEffectType.Mask)
        {
            Debug.Log("OI1");
        }
        else if(uiEffectType == UiEffectType.ParticleEnd)
        {
            particleEnd.transform.position = elementTransform.position;
            particleEnd.Play();
        }

        return true;
    }
}

public enum UiEffectType
{
    SuperGrowth,
    Mask,
    ParticleEnd
}