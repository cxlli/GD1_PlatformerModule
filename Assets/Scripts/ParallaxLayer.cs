using UnityEngine;
using System.Collections;
using NaughtyAttributes;


/// <summary>
/// Add this to a GameObject to have it move in parallax 
/// </summary>

public class ParallaxLayer : MonoBehaviour
{
    [Header("Behaviour")]
    [InfoBox("This component will make this GameObject move in parallax (when the camera moves) if the camera's CameraController component has been set to move parallax elements. Here you can determine the relative horizontal and vertical speed, and in which direction the element should move.")]

    /// horizontal speed of the layer
    public float HorizontalSpeed;
    /// vertical speed of the layer
    public float VerticalSpeed;
    /// defines if the layer moves in the same direction as the camera or not
    public bool MoveInOppositeDirection = true;

    // private stuff
    protected Vector3 _previousCameraPosition;
    protected bool _previousMoveParallax;
    protected Camera _camera;
    protected Transform _cameraTransform;


    protected virtual void OnEnable()
    {
        if (Camera.main == null)
            return;

        _camera = Camera.main;
        if (_camera != null)
        {
            _cameraTransform = _camera.transform;
            _previousCameraPosition = _cameraTransform.position;
        }
    }

    /// <summary>
    /// Every frame, we move the parallax layer according to the camera's position
    /// </summary>
    protected virtual void LateUpdate()
    {

        Vector3 distance = _cameraTransform.position - _previousCameraPosition;
        float direction = (MoveInOppositeDirection) ? -1f : 1f;
        transform.position += Vector3.Scale(distance, new Vector3(HorizontalSpeed, VerticalSpeed)) * direction;
        _previousCameraPosition = _cameraTransform.position;
    }
}
