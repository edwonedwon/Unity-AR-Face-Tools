using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

namespace Edwon.ARFaceTools
{
    public class ARFacePoseReceiver : MonoBehaviour
    {
        void OnFacePoseUpdated(Transform faceTransform)
        {
            Debug.Log("GLOBAL: " + faceTransform.rotation.eulerAngles);
            Debug.Log("LOCAL: " + faceTransform.localRotation.eulerAngles);
            transform.rotation = faceTransform.rotation;
        }

        void OnEnable()
        {
            ARFacePoseSender.onFacePoseUpdatedEvent += OnFacePoseUpdated;
        }

        void OnDisable()
        {
            ARFacePoseSender.onFacePoseUpdatedEvent -= OnFacePoseUpdated;
        }
    }
}
