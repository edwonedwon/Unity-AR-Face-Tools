using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

namespace Edwon.ARFaceTools
{
    public class ARFaceEyeSpriteAnimator : MonoBehaviour
    {
        float leftEyeUp;
        float leftEyeDown;
        float leftEyeIn;
        float leftEyeOut;
        float rightEyeUp;
        float rightEyeDown;
        float rightEyeIn;
        float rightEyeOut;

        public enum Side {Left, Right}
        public Side side;
        public Transform eyeCenter;
        public Transform pupil;
        public float eyeWhiteRadius;

        void Update()
        {
            float x = 0;
            float y = 0;
            if (side == Side.Left)
            {
                x = leftEyeOut - leftEyeIn;
                y = leftEyeUp - leftEyeDown;
            }
            else if (side == Side.Right)
            {
                x = rightEyeIn - rightEyeOut;
                y = rightEyeUp - rightEyeDown;
            }
            Vector2 eyePos = new Vector2(x,y);
            eyePos = Vector2.ClampMagnitude(eyePos, eyeWhiteRadius);
            pupil.localPosition = eyePos;
        }

        void OnFaceUpdatedEvent(ARFaceUpdatedEventArgs eventArgs, Dictionary<ARKitBlendShapeLocationSerializable, float> blendShapeValues)
        {   
            blendShapeValues.TryGetValue(ARKitBlendShapeLocationSerializable.EyeLookUpLeft, out leftEyeUp);
            blendShapeValues.TryGetValue(ARKitBlendShapeLocationSerializable.EyeLookDownLeft, out leftEyeDown);
            blendShapeValues.TryGetValue(ARKitBlendShapeLocationSerializable.EyeLookInLeft, out leftEyeIn);
            blendShapeValues.TryGetValue(ARKitBlendShapeLocationSerializable.EyeLookOutLeft, out leftEyeOut);
            blendShapeValues.TryGetValue(ARKitBlendShapeLocationSerializable.EyeLookUpRight, out rightEyeUp);
            blendShapeValues.TryGetValue(ARKitBlendShapeLocationSerializable.EyeLookDownRight, out rightEyeDown);
            blendShapeValues.TryGetValue(ARKitBlendShapeLocationSerializable.EyeLookInRight, out rightEyeIn);
            blendShapeValues.TryGetValue(ARKitBlendShapeLocationSerializable.EyeLookOutRight, out rightEyeOut);
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