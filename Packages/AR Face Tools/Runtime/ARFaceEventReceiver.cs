using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Edwon.ARFaceTools;
using UnityEngine.XR.ARKit;
using UnityEngine.XR.ARFoundation;

namespace Edwon.ARFaceTools
{
    public class ARFaceEventReceiver : MonoBehaviour
    {
        void OnFaceUpdatedEvent(ARFaceUpdatedEventArgs eventArgs, Dictionary<ARKitBlendShapeLocationSerializable, float> blendShapeValues)
        {
            float poo;
            blendShapeValues.TryGetValue(ARKitBlendShapeLocationSerializable.BrowDownRight, out poo);
            Debug.Log("right brow: " + poo);
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