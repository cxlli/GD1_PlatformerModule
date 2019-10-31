using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;
using Cinemachine;

public class Portal : MonoBehaviour
{
    [Header("Logic")]
    public Portal exit;
    [Tooltip("Game objects with the listed tags and be sent through the portal")]
    public List<string> keys;

    [HideInInspector]
    public bool portalIsExit;

    [Header("Visual")]
    public Transform sprites;
    public float rotSpeed;

    [Header("Events")]

    public UnityEvent OnEnterPortal;
    public UnityEvent OnExitPortal;

    private CinemachineBrain brain;

    private void OnEnable()
    {
        brain = FindObjectOfType<CinemachineBrain>();

        if (exit == null)
        {
            //Debug.LogException(exception)
            Debug.LogError("You forgot to set an exit for " + gameObject.name + "!");
        }

        sprites.DOScale(1.2f, 0.8f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutSine);

    }

    private void OnDisable()
    {
        sprites.transform.localScale = Vector3.one;
        DOTween.Kill(sprites);
    }

    void Update()
    {
        sprites.Rotate(Vector3.forward * rotSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!portalIsExit)
        {
            var tag = collision.transform.root.tag;

            if (keys.Contains(tag))
            {
                //we set the exit of this portal to true so it doesn't become a looped portal
                exit.portalIsExit = true;
                //player or object entered portal
                OnEnterPortal.Invoke();
                //does the teleport logic
                Vector3 warpDelta = collision.transform.position - exit.sprites.position;
                collision.transform.position = exit.sprites.position;

                //Transform target = GetComponent<CinemachineBrain>().ActiveVirtualCamera.
                brain.ActiveVirtualCamera.OnTargetObjectWarped(collision.transform, warpDelta);

                //sends the on exit portal to the exit of this portal
                exit.OnExitPortal.Invoke();
            }
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (portalIsExit)
        {
            var tag = collision.transform.root.tag;

            if (keys.Contains(tag))
            {
                portalIsExit = false;
            }

        }
    }

}
