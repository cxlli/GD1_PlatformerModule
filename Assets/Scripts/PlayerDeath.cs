using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerDeath : MonoBehaviour
{
    public Transform respawnPoint;
    public float respawnTimer;

    [Space(20)]

    //[fo]
    public UnityEvent onDeath;
    public UnityEvent onRespawn;


    private Vector3 origin;
    private bool playerIsDead;

    // Start is called before the first frame update
    void Start()
    {
        //we save origin just incase the designer hasn't set a respawn point
        origin = transform.position;
        playerIsDead = false;
    }

    public void SetRespawnPoint(Transform t)
    {
        respawnPoint = t;
    }

    public void DoKillPlayer()
    {
        if (!playerIsDead)
        {
            playerIsDead = true;
            onDeath.Invoke();
            StartCoroutine(KillPlayerActual());
        }

    }

    IEnumerator KillPlayerActual()
    {


        yield return new WaitForSeconds(respawnTimer);

        if(respawnPoint == null)
        {
            transform.position = origin;
        }
        else
        {
            transform.position = respawnPoint.position;
        }

        onRespawn.Invoke();
        playerIsDead = false;
    }
}
