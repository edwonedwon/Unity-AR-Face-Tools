﻿using Unity.Collections;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARKit;


namespace Edwon.ARFaceTools
{
    [RequireComponent(typeof(ARFace))]
    public class ARFaceEventSender : MonoBehaviour
    {
        ARFace arFace;
        ARFaceManager arFaceManager;
        ARKitFaceSubsystem arKitFaceSubsystem;
        Dictionary<ARKitBlendShapeLocation, float> blendShapeValuesToSend;

        void Awake()
        {
            arFace = GetComponent<ARFace>();
            arFaceManager = FindObjectOfType<ARFaceManager>();
            arKitFaceSubsystem = arFaceManager.subsystem as ARKitFaceSubsystem;
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