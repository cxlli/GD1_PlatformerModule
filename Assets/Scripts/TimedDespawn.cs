using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedDespawn : MonoBehaviour
{
    [Tooltip("If true, this will start the timer when the game object becomes enabled")]
    public bool triggerOnEnable;
    [Tooltip("How much time before this object is disabled")]
    public float timeToDespawn;

    private void OnEnable()
    {
        if (triggerOnEnable)
        {
            StartDespawnTimer();
        }
    }

    public void StartDespawnTimer()
    {
        StartCoroutine(DoDespawn());
    }

    public IEnumerator DoDespawn()
    {
        yield return new WaitForSeconds(timeToDespawn);
        gameObject.SetActive(false);
    }
}
