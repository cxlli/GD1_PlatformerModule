using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class KillLine : MonoBehaviour
{
    [InfoBox("If the player is below this line, the kill event is called", InfoBoxType.Normal)]

    private Transform player;
    public GameEvent killPlayerEvent;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>().transform;
        InvokeRepeating("CheckKillLine", 1, 0.2f);
    }

    //checks to see if player is below the kill line. If true then we kill the player
    public void CheckKillLine()
    {
        if(player.position.y < transform.position.y)
        {
            killPlayerEvent.Raise();
        }
    }
    //// Update is called once per frame
    //void Update()
    //{

    //}
}
