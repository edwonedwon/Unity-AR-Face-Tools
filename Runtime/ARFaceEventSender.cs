using Unity.Collections;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARKit;
#if UNITY_EDITOR && EDWON_ARFOUNDATIONREMOTE
using ARKitFaceSubsystem = ARFoundationRemote.Runtime.FaceSubsystem;
#endif

namespace Edwon.ARFaceTools
{
    [RequireComponent(typeof(ARFace))]
    public class ARFaceEventSender : MonoBehaviour
    {
        ARFace arFace;
        ARFaceManager arFaceManager;
        #if UNITY_EDITOR && EDWON_ARFOUNDATIONREMOTE
        ARKitFaceSubsystem arKitFaceSubsystem;
        #endif
        Dictionary<ARKitBlendShapeLocation, float> blendShapeValuesToSend;

        void Awake()
        {
            arFace = GetComponent<ARFace>();
            arFaceManager = FindObjectOfType<ARFaceManager>();
            #if UNITY_EDITOR && EDWON_ARFOUNDATIONREMOTE
            arKitFaceSubsystem = (ARKitFaceSubsystem)arFaceManager.subsystem;
            #endif
            blendShapeValuesToSend = new Dictionary<ARKitBlendShapeLocation, float>();
        }

        void OnFaceUpdated(ARFaceUpdatedEventArgs eventArgs)
        {
            using (NativeArray<ARKitBlendShapeCoefficient> blendShapes = arKitFaceSubsystem.GetBlendShapeCoefficients(arFace.trackableId, Allocator.Temp))
            {
                foreach(ARKitBlendShapeCoefficient blendShape in blendShapes)
                {
                    if (blendShapeValuesToSend.ContainsKey(blendShape.blendShapeLocation))
                    {
                        blendShapeValuesToSend[blendShape.blendShapeLocation] = blendShape.coefficient;
                    }
                    else
                    {
                        blendShapeValuesToSend.Add(blendShape.blendShapeLocation, blendShape.coefficient);
                    }
                }
            }

            ARFaceTrackingUtils.InvokeOnFaceUpdatedEvent(eventArgs, blendShapeValuesToSend);
        }

        void OnEnable()
        {
            arFace.updated += OnFaceUpdated;
        }

        void OnDisable()
        {
            arFace.updated -= OnFaceUpdated;
        }
    }
}