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

        public bool matchPosition = true;
        public bool matchRotation = true;
        
        void OnFaceUpdatedEvent(ARFaceUpdatedEventArgs eventArgs, Dictionary<ARKitBlendShapeLocationSerializable, float> _blendShapeValues)
        {
            switch (poseType)
            {
                case PoseType.Head:
                if (matchPosition)
                    transform.position = eventArgs.face.transform.position;
                if (matchRotation)
                    transform.rotation = eventArgs.face.transform.rotation;
                break;
                case PoseType.LeftEye:
                if (matchPosition)
                    transform.position = eventArgs.face.leftEye.position;
                if (matchRotation)
                    transform.rotation = eventArgs.face.leftEye.rotation;
                break;
                case PoseType.RightEye:
                if (matchPosition)
                    transform.position = eventArgs.face.rightEye.position;
                if (matchRotation)
                    transform.rotation = eventArgs.face.rightEye.rotation;
                break;
                case PoseType.FixationPoint:
                if (matchPosition)
                    transform.position = eventArgs.face.fixationPoint.position;
                if (matchRotation)
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
