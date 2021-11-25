using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Edwon.ARFaceTools;
using UnityEngine.XR.ARKit;
using UnityEngine.XR.ARFoundation;
using UnityEngine.Events;
using Edwon.Tools;

namespace Edwon.ARFaceTools
{
    public class ARFaceBlendShapesReceiver : MonoBehaviour
    {
        public bool showEyeEvents = true;
        public bool showCheekEvents = true;
        public bool showBrowEvents = true;
        public bool showJawEvents = true;
        public bool showMouthEvents = true;
        public bool showOtherEvents = true;

        #region EVENTS
        public UnityEventFloat browDownLeftEvent;
        public UnityEventFloat browDownRightEvent;
        public UnityEventFloat browInnerUpEvent;
        public UnityEventFloat browOuterUpLeftEvent;
        public UnityEventFloat browOuterUpRightEvent;
        public UnityEventFloat cheekPuffEvent;
        public UnityEventFloat cheekSquintLeftEvent;
        public UnityEventFloat cheekSquintRightEvent;
        public UnityEventFloat eyeBlinkLeftEvent;
        public UnityEventFloat eyeBlinkRightEvent;       
        public UnityEventFloat eyeLookDownLeftEvent;     
        public UnityEventFloat eyeLookDownRightEvent;    
        public UnityEventFloat eyeLookInLeftEvent;       
        public UnityEventFloat eyeLookInRightEvent;      
        public UnityEventFloat eyeLookOutLeftEvent;      
        public UnityEventFloat eyeLookOutRightEvent;    
        public UnityEventFloat eyeLookUpLeftEvent;     
        public UnityEventFloat eyeLookUpRightEvent;     
        public UnityEventFloat eyeSquintLeftEvent;     
        public UnityEventFloat eyeSquintRightEvent;     
        public UnityEventFloat eyeWideLeftEvent;         
        public UnityEventFloat eyeWideRightEvent;        
        public UnityEventFloat jawForwardEvent;          
        public UnityEventFloat jawLeftEvent;             
        public UnityEventFloat jawOpenEvent;      
        public UnityEventFloat jawRightEvent;            
        public UnityEventFloat mouthCloseEvent;       
        public UnityEventFloat mouthDimpleLeftEvent;     
        public UnityEventFloat mouthDimpleRightEvent;    
        public UnityEventFloat mouthFrownLeftEvent;      
        public UnityEventFloat mouthFrownRightEvent;     
        public UnityEventFloat mouthFunnelEvent;     
        public UnityEventFloat mouthLeftEvent;           
        public UnityEventFloat mouthLowerDownLeftEvent;  
        public UnityEventFloat mouthLowerDownRightEvent; 
        public UnityEventFloat mouthPressLeftEvent;      
        public UnityEventFloat mouthPressRightEvent;     
        public UnityEventFloat mouthPuckerEvent;    
        public UnityEventFloat mouthRightEvent;          
        public UnityEventFloat mouthRollLowerEvent;     
        public UnityEventFloat mouthRollUpperEvent; 
        public UnityEventFloat mouthShrugLowerEvent; 
        public UnityEventFloat mouthShrugUpperEvent;
        public UnityEventFloat mouthSmileLeftEvent;      
        public UnityEventFloat mouthSmileRightEvent;     
        public UnityEventFloat mouthStretchLeftEvent;    
        public UnityEventFloat mouthStretchRightEvent;   
        public UnityEventFloat mouthUpperUpLeftEvent;    
        public UnityEventFloat mouthUpperUpRightEvent;   
        public UnityEventFloat noseSneerLeftEvent;       
        public UnityEventFloat noseSneerRightEvent;      
        public UnityEventFloat tongueOutEvent;
        #endregion

        #region VALUES
        float browDownLeft;
        float browDownRight;
        float browInnerUp;
        float browOuterUpLeft;
        float browOuterUpRight;
        float cheekPuff;
        float cheekSquintLeft;
        float cheekSquintRight;
        float eyeBlinkLeft;
        float eyeBlinkRight;       
        float eyeLookDownLeft;     
        float eyeLookDownRight;    
        float eyeLookInLeft;       
        float eyeLookInRight;      
        float eyeLookOutLeft;      
        float eyeLookOutRight;    
        float eyeLookUpLeft;     
        float eyeLookUpRight;     
        float eyeSquintLeft;     
        float eyeSquintRight;     
        float eyeWideLeft;         
        float eyeWideRight;        
        float jawForward;          
        float jawLeft;             
        float jawOpen;      
        float jawRight;            
        float mouthClose;       
        float mouthDimpleLeft;     
        float mouthDimpleRight;    
        float mouthFrownLeft;      
        float mouthFrownRight;     
        float mouthFunnel;     
        float mouthLeft;           
        float mouthLowerDownLeft;  
        float mouthLowerDownRight; 
        float mouthPressLeft;      
        float mouthPressRight;     
        float mouthPucker;    
        float mouthRight;          
        float mouthRollLower;     
        float mouthRollUpper; 
        float mouthShrugLower; 
        float mouthShrugUpper;
        float mouthSmileLeft;      
        float mouthSmileRight;     
        float mouthStretchLeft;    
        float mouthStretchRight;   
        float mouthUpperUpLeft;    
        float mouthUpperUpRight;   
        float noseSneerLeft;       
        float noseSneerRight;      
        float tongueOut;
        #endregion

        Dictionary<ARKitBlendShapeLocationSerializable, float> blendShapeValues;

        void OnFaceUpdatedEvent(ARFaceUpdatedEventArgs eventArgs, Dictionary<ARKitBlendShapeLocationSerializable, float> _blendShapeValues)
        {
            this.blendShapeValues = _blendShapeValues;

            InvokeEvent(ARKitBlendShapeLocationSerializable.BrowDownLeft, browDownLeftEvent, out browDownLeft);
            InvokeEvent(ARKitBlendShapeLocationSerializable.BrowDownRight, browDownRightEvent, out browDownRight);
            InvokeEvent(ARKitBlendShapeLocationSerializable.BrowInnerUp, browInnerUpEvent, out browInnerUp);
            InvokeEvent(ARKitBlendShapeLocationSerializable.BrowOuterUpLeft, browOuterUpLeftEvent, out browOuterUpLeft);
            InvokeEvent(ARKitBlendShapeLocationSerializable.BrowOuterUpRight, browOuterUpRightEvent, out browOuterUpRight);
            InvokeEvent(ARKitBlendShapeLocationSerializable.CheekPuff, cheekPuffEvent, out cheekPuff);
            InvokeEvent(ARKitBlendShapeLocationSerializable.CheekSquintLeft, cheekSquintLeftEvent, out cheekSquintLeft);
            InvokeEvent(ARKitBlendShapeLocationSerializable.CheekSquintRight, cheekSquintRightEvent, out cheekSquintRight);
            InvokeEvent(ARKitBlendShapeLocationSerializable.EyeBlinkLeft, eyeBlinkLeftEvent, out eyeBlinkLeft);
            InvokeEvent(ARKitBlendShapeLocationSerializable.EyeBlinkRight, eyeBlinkRightEvent, out eyeBlinkRight);
            InvokeEvent(ARKitBlendShapeLocationSerializable.EyeLookDownLeft, eyeLookDownLeftEvent, out eyeLookDownLeft);
            InvokeEvent(ARKitBlendShapeLocationSerializable.EyeLookDownRight, eyeLookDownRightEvent, out eyeLookDownRight);
            InvokeEvent(ARKitBlendShapeLocationSerializable.EyeLookInLeft, eyeLookInLeftEvent, out eyeLookInLeft);
            InvokeEvent(ARKitBlendShapeLocationSerializable.EyeLookInRight, eyeLookInRightEvent, out eyeLookInRight);
            InvokeEvent(ARKitBlendShapeLocationSerializable.EyeLookOutLeft, eyeLookOutLeftEvent, out eyeLookOutLeft);
            InvokeEvent(ARKitBlendShapeLocationSerializable.EyeLookOutRight, eyeLookOutRightEvent, out eyeLookOutRight);
            InvokeEvent(ARKitBlendShapeLocationSerializable.EyeLookUpLeft, eyeLookUpLeftEvent, out eyeLookUpLeft);
            InvokeEvent(ARKitBlendShapeLocationSerializable.EyeLookUpRight, eyeLookUpRightEvent, out eyeLookUpRight);
            InvokeEvent(ARKitBlendShapeLocationSerializable.EyeSquintLeft, eyeSquintLeftEvent, out eyeSquintLeft);
            InvokeEvent(ARKitBlendShapeLocationSerializable.EyeSquintRight, eyeSquintRightEvent, out eyeSquintRight);
            InvokeEvent(ARKitBlendShapeLocationSerializable.EyeWideLeft, eyeWideLeftEvent, out eyeWideLeft);
            InvokeEvent(ARKitBlendShapeLocationSerializable.EyeWideRight, eyeWideRightEvent, out eyeWideRight);
            InvokeEvent(ARKitBlendShapeLocationSerializable.JawForward, jawForwardEvent, out jawForward);
            InvokeEvent(ARKitBlendShapeLocationSerializable.JawLeft, jawLeftEvent, out jawLeft);
            InvokeEvent(ARKitBlendShapeLocationSerializable.JawOpen, jawOpenEvent, out jawOpen);
            InvokeEvent(ARKitBlendShapeLocationSerializable.JawRight, jawRightEvent, out jawRight);
            InvokeEvent(ARKitBlendShapeLocationSerializable.MouthClose, mouthCloseEvent, out mouthClose);
            InvokeEvent(ARKitBlendShapeLocationSerializable.MouthDimpleLeft, mouthDimpleLeftEvent, out mouthDimpleLeft);
            InvokeEvent(ARKitBlendShapeLocationSerializable.MouthDimpleRight, mouthDimpleRightEvent, out mouthDimpleRight);
            InvokeEvent(ARKitBlendShapeLocationSerializable.MouthFrownLeft, mouthFrownLeftEvent, out mouthFrownLeft);
            InvokeEvent(ARKitBlendShapeLocationSerializable.MouthFrownRight, mouthFrownRightEvent, out mouthFrownRight);
            InvokeEvent(ARKitBlendShapeLocationSerializable.MouthFunnel, mouthFunnelEvent, out mouthFunnel);
            InvokeEvent(ARKitBlendShapeLocationSerializable.MouthLeft, mouthLeftEvent, out mouthLeft);
            InvokeEvent(ARKitBlendShapeLocationSerializable.MouthLowerDownLeft, mouthLowerDownLeftEvent, out mouthLowerDownLeft);
            InvokeEvent(ARKitBlendShapeLocationSerializable.MouthLowerDownRight, mouthLowerDownRightEvent, out mouthLowerDownRight);
            InvokeEvent(ARKitBlendShapeLocationSerializable.MouthPressLeft, mouthPressLeftEvent, out mouthPressLeft);
            InvokeEvent(ARKitBlendShapeLocationSerializable.MouthPressRight, mouthPressRightEvent, out mouthPressRight);
            InvokeEvent(ARKitBlendShapeLocationSerializable.MouthPucker, mouthPuckerEvent, out mouthPucker);
            InvokeEvent(ARKitBlendShapeLocationSerializable.MouthRight, mouthRightEvent, out mouthRight);
            InvokeEvent(ARKitBlendShapeLocationSerializable.MouthRollLower, mouthRollLowerEvent, out mouthRollLower);
            InvokeEvent(ARKitBlendShapeLocationSerializable.MouthRollUpper, mouthRollUpperEvent, out mouthRollUpper);
            InvokeEvent(ARKitBlendShapeLocationSerializable.MouthShrugLower, mouthShrugLowerEvent, out mouthShrugLower);
            InvokeEvent(ARKitBlendShapeLocationSerializable.MouthShrugUpper, mouthShrugUpperEvent, out mouthShrugUpper);
            InvokeEvent(ARKitBlendShapeLocationSerializable.MouthSmileLeft, mouthSmileLeftEvent, out mouthSmileLeft);
            InvokeEvent(ARKitBlendShapeLocationSerializable.MouthSmileRight, mouthSmileRightEvent, out mouthSmileRight);
            InvokeEvent(ARKitBlendShapeLocationSerializable.MouthStretchLeft, mouthStretchLeftEvent, out mouthStretchLeft);
            InvokeEvent(ARKitBlendShapeLocationSerializable.MouthStretchRight, mouthStretchRightEvent, out mouthStretchRight);
            InvokeEvent(ARKitBlendShapeLocationSerializable.MouthUpperUpLeft, mouthUpperUpLeftEvent, out mouthUpperUpLeft);
            InvokeEvent(ARKitBlendShapeLocationSerializable.MouthUpperUpRight, mouthUpperUpRightEvent, out mouthUpperUpRight);
            InvokeEvent(ARKitBlendShapeLocationSerializable.NoseSneerLeft, noseSneerLeftEvent, out noseSneerLeft);
            InvokeEvent(ARKitBlendShapeLocationSerializable.NoseSneerRight, noseSneerRightEvent, out noseSneerRight);
            InvokeEvent(ARKitBlendShapeLocationSerializable.TongueOut, tongueOutEvent, out tongueOut);
        }

        void InvokeEvent(ARKitBlendShapeLocationSerializable blendShape, UnityEventFloat e, out float f)
        {
            if (!Utils.EventHasTarget(e))
            {
                f = 0;
                return;
            }

            if (blendShapeValues.TryGetValue(blendShape, out f))
                e.Invoke(f);
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