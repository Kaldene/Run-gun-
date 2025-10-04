using System;
using UnityEngine;

public class CameraInput : MonoBehaviour
{
   [SerializeField] private Vector3 _cameraOffset = new Vector3(0,2,-10);
   [SerializeField] private Transform _target;
   [SerializeField] private float _speedCamera = 2f;

   private void LateUpdate()
   {
      if (_target == null) return;
      
      Vector3 targetPosition = _target.position + _cameraOffset;
      transform.position = Vector3.Lerp(transform.position, targetPosition, _speedCamera * Time.deltaTime);
   }
}
