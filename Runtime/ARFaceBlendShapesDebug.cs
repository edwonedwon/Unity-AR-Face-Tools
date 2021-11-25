using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

namespace Edwon.ARFaceTools
{
    public class ARFaceBlendShapesDebug : MonoBehaviour
    {
        public int fontSize = 30;

        Dictionary<ARKitBlendShapeLocationSerializable, float> blendShapeValues;

        void OnFaceUpdatedEvent(ARFaceUpdatedEventArgs eventArgs, Dictionary<ARKitBlendShapeLocationSerializable, float> blendShapeValues)
        {
            this.blendShapeValues = blendShapeValues;
        }

        void OnGUI()
        {
            if (blendShapeValues == null)
                return;
                
            GUI.skin.label.fontSize = fontSize;
            foreach(KeyValuePair<ARKitBlendShapeLocationSerializable, float> blendShapeValue in blendShapeValues)
            {
                GUILayout.Label(blendShapeValue.Key + " " + blendShapeValue.Value);
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