using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorManager : MonoBehaviour
{
    public Animator Animator;
    public List<AnimatorSetup> animatorSetups;

    public enum animationType
    {
        IDLE,
        RUN,
        DEAD
    }

    public void Play(animationType type, float currentSpeedFactor = 1f)
    {
        foreach (var animation in animatorSetups)
        {
            if (animation.type == type)
            {
                Animator.SetTrigger(animation.trigger);
                Animator.speed = animation.speed * currentSpeedFactor;
                break;
            }
        }
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Play(animationType.IDLE);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Play(animationType.RUN);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Play(animationType.DEAD);
        }
    }



    [System.Serializable]
    public class AnimatorSetup
    {
        public AnimatorManager.animationType type;
        public string trigger;
        public float speed = 1f;
    }


}
