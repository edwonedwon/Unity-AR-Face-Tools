using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

namespace Edwon.ARFaceTools
{
    public class ARFacePoseReceiver : MonoBehaviour
    {
        [System.Serializable]
        public enum PoseType
        {
            Head, LeftEye, RightEye, FixationPoint
        }

        public PoseType poseType;
        
        void OnFaceUpdatedEvent(ARFaceUpdatedEventArgs eventArgs, Dictionary<ARKitBlendShapeLocationSerializable, float> _blendShapeValues)
        {
            switch (poseType)
            {
                case PoseType.Head:
                transform.position = eventArgs.face.transform.position;
                transform.rotation = eventArgs.face.transform.rotation;
                break;
                case PoseType.LeftEye:
                transform.position = eventArgs.face.leftEye.position;
                transform.rotation = eventArgs.face.leftEye.rotation;
                break;
                case PoseType.RightEye:
                transform.position = eventArgs.face.rightEye.position;
                transform.rotation = eventArgs.face.rightEye.rotation;
                break;
                case PoseType.FixationPoint:
                transform.position = eventArgs.face.fixationPoint.position;
                transform.rotation = eventArgs.face.fixationPoint.rotation;
                break;
            }
        }

        void OnEnable()
        {
            ARFaceTrackingUtils.onFaceUpdatedEvent += OnFaceUpdatedEvent;
        }

        void OnDisable()
        {
            ARFaceTrackingUtils.onFaceUpdatedEvent -= OnFaceUpdatedEvent;
        }
    }
}
