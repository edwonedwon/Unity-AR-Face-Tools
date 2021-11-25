using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

namespace Edwon.ARFaceTools
{
    public class ARFaceEyeSpriteAnimator : MonoBehaviour
    {
        public float eyeRadius;

        public float upLeft;
        public float downLeft;
        public float upRight;
        public float downRight;

        void OnFaceUpdatedEvent(ARFaceUpdatedEventArgs eventArgs, Dictionary<ARKitBlendShapeLocationSerializable, float> blendShapeValues)
        {   
            blendShapeValues.TryGetValue(ARKitBlendShapeLocationSerializable.EyeLookUpLeft, out upLeft);
            blendShapeValues.TryGetValue(ARKitBlendShapeLocationSerializable.EyeLookDownLeft, out downLeft);
            blendShapeValues.TryGetValue(ARKitBlendShapeLocationSerializable.EyeLookUpRight, out upRight);
            blendShapeValues.TryGetValue(ARKitBlendShapeLocationSerializable.EyeLookDownRight, out downRight);
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