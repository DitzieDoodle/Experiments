using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
using Spine;

public class MothController_Test : MonoBehaviour
{
    public SkeletonAnimation moth;
    public string eventName;
    public AudioSource meow;

    Spine.EventData eventData;

    private void Start()
    {
        eventData = moth.Skeleton.Data.FindEvent(eventName);
        moth.AnimationState.Event += HandleAnimationStateEvent;
        //register animation event callback
    }

    public void GoToIdle()
    {
        moth.AnimationState.SetAnimation(0, "Idle", true);
    }

    public void GoToJump()
    {
        moth.AnimationState.SetAnimation(0, "Jump", true);
    }

    private void HandleAnimationStateEvent(TrackEntry trackEntry, Spine.Event e)
    {
        Debug.Log("Event fired! " + e.Data.Name);
       
        bool eventMatch = (eventData == e.Data);  // Performance recommendation: Match cached reference instead of string.
        if (eventMatch)
        {
            meow.Play();
        }
    }

}
