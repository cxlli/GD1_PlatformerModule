using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using NaughtyAttributes;

public class InitializeEvents : MonoBehaviour
{
    [InfoBox("Enable, Start and Awake events serialized")]

    public UnityEvent onEnable;
    public UnityEvent onStart;
    public UnityEvent onAwake;

    private void OnEnable()
    {
        onEnable.Invoke();
    }

    private void Awake()
    {
        onAwake.Invoke();
    }

    // Start is called before the first frame update
    void Start()
    {
        onStart.Invoke(); 
    }


}
