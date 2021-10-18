using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARKit;

namespace Edwon.ARFaceTools
{
    public static class ARFaceTrackingUtils 
    {
        public delegate void OnFaceUpdatedEvent(ARFaceUpdatedEventArgs eventArgs, Dictionary<ARKitBlendShapeLocationSerializable, float> blendShapeValues);
        public static event OnFaceUpdatedEvent onFaceUpdatedEvent;

        public static Dictionary<ARKitBlendShapeLocationSerializable, ARKitBlendShapeLocation> blendShapeIndexMapToARKit;
        public static Dictionary<ARKitBlendShapeLocation, ARKitBlendShapeLocationSerializable> blendShapeIndexMapToSerializable;

        public static void InvokeOnFaceUpdatedEvent(ARFaceUpdatedEventArgs eventArgs, Dictionary<ARKitBlendShapeLocationSerializable, float> blendShapesSerializable)
        {
            if (onFaceUpdatedEvent != null)
                onFaceUpdatedEvent(eventArgs, blendShapesSerializable);
        }

        public static void InvokeOnFaceUpdatedEvent(ARFaceUpdatedEventArgs eventArgs, Dictionary<ARKitBlendShapeLocation, float> blendShapes)
        {
            if (blendShapesConverted == null)
            {
                InitBlendShapesConverted();
                InitBlendShapeLocationIndexMaps();
            }

            if (onFaceUpdatedEvent != null)
                onFaceUpdatedEvent(eventArgs, ConvertARKitBlendShapeLocationDictionaryToSerializable(blendShapes));
        }

        public static Dictionary<ARKitBlendShapeLocationSerializable, float> blendShapesConverted;
        static void InitBlendShapesConverted()
        {
            blendShapesConverted = new Dictionary<ARKitBlendShapeLocationSerializable, float>();
            int totalBlendShapes = Enum.GetNames(typeof(ARKitBlendShapeLocationSerializable)).Length;
            for(int i = 0; i < totalBlendShapes; i++)
                blendShapesConverted.Add((ARKitBlendShapeLocationSerializable)i, 0);
        }

        static Dictionary<ARKitBlendShapeLocationSerializable, float> ConvertARKitBlendShapeLocationDictionaryToSerializable(Dictionary<ARKitBlendShapeLocation, float> blendShapeValues)
        {
            foreach(KeyValuePair<ARKitBlendShapeLocation, float> entry in blendShapeValues)
            {
                ARKitBlendShapeLocationSerializable locationSerializable = blendShapeIndexMapToSerializable[entry.Key];
                blendShapesConverted[locationSerializable] = entry.Value;
            }
            return blendShapesConverted;
        }

        // creates the blendShapeIndexMap that can be used to 
        // convert from ARKitBlendShapeLocation to ARKitBlendShapeLocationSerializable
        static void InitBlendShapeLocationIndexMaps()
        {
            #if UNITY_IOS

            // init ToARKit
            if (blendShapeIndexMapToARKit != null)
                return;
                
            blendShapeIndexMapToARKit = new Dictionary<ARKitBlendShapeLocationSerializable, ARKitBlendShapeLocation>();
            int totalBlendShapes = Enum.GetNames(typeof(ARKitBlendShapeLocation)).Length;
            for (int i = 0; i < totalBlendShapes; i++)
                blendShapeIndexMapToARKit.Add((ARKitBlendShapeLocationSerializable)i, (ARKitBlendShapeLocation)i);

            // init ToSerializable
            if (blendShapeIndexMapToSerializable != null)
                return;

            blendShapeIndexMapToSerializable = new Dictionary<ARKitBlendShapeLocation, ARKitBlendShapeLocationSerializable>();
            for (int i = 0; i < totalBlendShapes; i++)
                blendShapeIndexMapToSerializable.Add((ARKitBlendShapeLocation)i, (ARKitBlendShapeLocationSerializable)i);

            #endif
        }
    }
        
    public enum ARKitBlendShapeLocationSerializable
    {
        BrowDownLeft        ,
        BrowDownRight       ,
        BrowInnerUp         ,
        BrowOuterUpLeft     ,
        BrowOuterUpRight    ,
        CheekPuff           ,
        CheekSquintLeft     ,
        CheekSquintRight    ,
        EyeBlinkLeft        ,
        EyeBlinkRight       ,
        EyeLookDownLeft     ,
        EyeLookDownRight    ,
        EyeLookInLeft       ,
        EyeLookInRight      ,
        EyeLookOutLeft      ,
        EyeLookOutRight     ,
        EyeLookUpLeft       ,
        EyeLookUpRight      ,
        EyeSquintLeft       ,
        EyeSquintRight      ,
        EyeWideLeft         ,
        EyeWideRight        ,
        JawForward          ,
        JawLeft             ,
        JawOpen             ,
        JawRight            ,
        MouthClose          ,
        MouthDimpleLeft     ,
        MouthDimpleRight    ,
        MouthFrownLeft      ,
        MouthFrownRight     ,
        MouthFunnel         ,
        MouthLeft           ,
        MouthLowerDownLeft  ,
        MouthLowerDownRight ,
        MouthPressLeft      ,
        MouthPressRight     ,
        MouthPucker         ,
        MouthRight          ,
        MouthRollLower      ,
        MouthRollUpper      ,
        MouthShrugLower     ,
        MouthShrugUpper     ,
        MouthSmileLeft      ,
        MouthSmileRight     ,
        MouthStretchLeft    ,
        MouthStretchRight   ,
        MouthUpperUpLeft    ,
        MouthUpperUpRight   ,
        NoseSneerLeft       ,
        NoseSneerRight      ,
        TongueOut
    }
}