using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEventListenerWithDelay : GameEventListener
{
    public float delay;

    public override void OnEventRaised()
    {
        //base.OnEventRaised();
        StartCoroutine(RaiseWithDelay());
    }

    IEnumerator RaiseWithDelay()
    {
        yield return new WaitForSeconds(delay);
        gameEvent.Raise();
    }
}
