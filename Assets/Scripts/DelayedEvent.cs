using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DelayedEvent : MonoBehaviour
{
    public bool startEventOnPlay;
    public float defaultDelayTime;

    public UnityEvent onDelayedEvent;

    private bool eventActive;

    // Start is called before the first frame update
    void Start()
    {
        eventActive = false;

        if (startEventOnPlay)
        {
            StartCoroutine(DoDelayEvent(defaultDelayTime));
        }
    }

    public void StartDelayedEvent(float delayTime)
    {
        if (!eventActive)
        {
            StartCoroutine(DoDelayEvent(delayTime));
        }
    }

    IEnumerator DoDelayEvent(float delay)
    {
        eventActive = true;
        yield return new WaitForSeconds(delay);
        onDelayedEvent.Invoke();
        eventActive = false;
    }

}
