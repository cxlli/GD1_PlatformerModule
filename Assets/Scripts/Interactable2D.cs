using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using NaughtyAttributes;
//using DG.Tweening;

public class Interactable2D : MonoBehaviour
{
    [Tooltip("If true, the condtion will check for the gameObjects tag instead of its name")]
    //public bool useTags;
    ////public string[] keys;
    //public List<string> keys;

    public string key;

    [Header("Events")]

    public UnityEvent TriggerEnter;
    public UnityEvent TriggerExit;
    public UnityEvent TriggerStay;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(key))
        {
            TriggerEnter.Invoke();
        }
        //if (useTags)
        //{
        //    var tag = collision.transform.root.tag;

        //    if (keys.Contains(tag))
        //    {
        //        TriggerEnter.Invoke();
        //    }
        //}

        //else
        //{
        //    var parent = collision.transform.root;

        //    if (keys.Contains(parent.name))
        //    {
        //        TriggerEnter.Invoke();
        //    }
        //}
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(key))
        {
            TriggerExit.Invoke();
        }
        //if (useTags)
        //{
        //    var tag = collision.transform.root.tag;

        //    if (keys.Contains(tag))
        //    {
        //        TriggerExit.Invoke();
        //    }
        //}

        //else
        //{
        //    var parent = collision.transform.root;

        //    if (keys.Contains(parent.name))
        //    {
        //        TriggerExit.Invoke();
        //    }
        //}
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag(key))
        {
            TriggerStay.Invoke();
        }
        //if (useTags)
        //{
        //    var tag = collision.transform.root.tag;

        //    if (keys.Contains(tag))
        //    {
        //        TriggerStay.Invoke();
        //    }
        //}

        //else
        //{
        //    var parent = collision.transform.root;

        //    if (keys.Contains(parent.name))
        //    {
        //        TriggerStay.Invoke();
        //    }
        //}
    }


}
