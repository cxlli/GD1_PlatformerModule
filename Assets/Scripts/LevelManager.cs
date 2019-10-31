using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Prime31.TransitionKit;
using UnityEngine.SceneManagement;
using System;

public class LevelManager : MonoBehaviour
{
    public int nextLevelIndex;
    public float delayLoadNextLevel;
    //public GameEvent loadNextLevelEvent;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {
        TransitionKit.onScreenObscured += onScreenObscured;
        TransitionKit.onTransitionComplete += onTransitionComplete;
    }

    private void onTransitionComplete()
    {
        //throw new NotImplementedException();
    }

    private void onScreenObscured()
    {
        //throw new NotImplementedException();
    }

    private void OnDisable()
    {
        TransitionKit.onScreenObscured -= onScreenObscured;
        TransitionKit.onTransitionComplete -= onTransitionComplete;
    }

    public void LoadNextScene()
    {
        //loadNextLevelEvent.Raise();
        StartCoroutine(AnimToNextScene());
    }

    private IEnumerator AnimToNextScene()
    {
        yield return new WaitForSeconds(delayLoadNextLevel);

        var doorway = new DoorwayTransition()
        {
            nextScene = nextLevelIndex,
            duration = 1.0f,
            perspective = 1.1f,
            runEffectInReverse = false
        };
        TransitionKit.instance.transitionWithDelegate(doorway);


    }


}
