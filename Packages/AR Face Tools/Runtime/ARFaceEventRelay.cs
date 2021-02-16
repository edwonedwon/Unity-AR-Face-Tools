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
    public class ARFaceEventRelay : MonoBehaviour
    {
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

        void OnFaceUpdatedEvent(ARFaceUpdatedEventArgs eventArgs, Dictionary<ARKitBlendShapeLocationSerializable, float> blendShapeValues)
        {
            if (blendShapeValues.TryGetValue(ARKitBlendShapeLocationSerializable.BrowDownLeft, out browDownLeft))
                browDownLeftEvent.Invoke(browDownLeft);
            if (blendShapeValues.TryGetValue(ARKitBlendShapeLocationSerializable.BrowDownRight, out browDownRight))
                browDownRightEvent.Invoke(browDownRight);
            if (blendShapeValues.TryGetValue(ARKitBlendShapeLocationSerializable.BrowInnerUp, out browInnerUp))
                browInnerUpEvent.Invoke(browInnerUp);
            if (blendShapeValues.TryGetValue(ARKitBlendShapeLocationSerializable.BrowOuterUpLeft, out browOuterUpLeft))
                browOuterUpLeftEvent.Invoke(browOuterUpLeft);
            if (blendShapeValues.TryGetValue(ARKitBlendShapeLocationSerializable.BrowOuterUpRight, out browOuterUpRight))
                browOuterUpRightEvent.Invoke(browOuterUpRight);
            if (blendShapeValues.TryGetValue(ARKitBlendShapeLocationSerializable.CheekPuff, out cheekPuff))
                cheekPuffEvent.Invoke(cheekPuff);
            if (blendShapeValues.TryGetValue(ARKitBlendShapeLocationSerializable.CheekSquintLeft, out cheekSquintLeft))
                cheekSquintLeftEvent.Invoke(cheekSquintLeft);
            if (blendShapeValues.TryGetValue(ARKitBlendShapeLocationSerializable.CheekSquintRight, out cheekSquintRight))
                cheekSquintRightEvent.Invoke(cheekSquintRight);
            if (blendShapeValues.TryGetValue(ARKitBlendShapeLocationSerializable.EyeBlinkLeft, out eyeBlinkLeft))
                eyeBlinkLeftEvent.Invoke(eyeBlinkLeft);
            if (blendShapeValues.TryGetValue(ARKitBlendShapeLocationSerializable.EyeBlinkRight, out eyeBlinkRight))
                eyeBlinkRightEvent.Invoke(eyeBlinkRight);
            if (blendShapeValues.TryGetValue(ARKitBlendShapeLocationSerializable.EyeLookDownLeft, out eyeLookDownLeft))
                eyeLookDownLeftEvent.Invoke(eyeLookDownLeft);
            if (blendShapeValues.TryGetValue(ARKitBlendShapeLocationSerializable.EyeLookDownRight, out eyeLookDownRight))
                eyeLookDownRightEvent.Invoke(eyeLookDownRight);
            if (blendShapeValues.TryGetValue(ARKitBlendShapeLocationSerializable.EyeLookInLeft, out eyeLookInLeft))
                eyeLookInLeftEvent.Invoke(eyeLookInLeft);
            if (blendShapeValues.TryGetValue(ARKitBlendShapeLocationSerializable.EyeLookInRight, out eyeLookInRight))
                eyeLookInRightEvent.Invoke(eyeLookInRight);
            if (blendShapeValues.TryGetValue(ARKitBlendShapeLocationSerializable.EyeLookOutLeft, out eyeLookOutLeft))
                eyeLookOutLeftEvent.Invoke(eyeLookOutLeft);
            if (blendShapeValues.TryGetValue(ARKitBlendShapeLocationSerializable.EyeLookOutRight, out eyeLookOutRight))
                eyeLookOutRightEvent.Invoke(eyeLookOutRight);
            if (blendShapeValues.TryGetValue(ARKitBlendShapeLocationSerializable.EyeLookUpLeft, out eyeLookUpLeft))
                eyeLookUpLeftEvent.Invoke(eyeLookUpLeft);
            if (blendShapeValues.TryGetValue(ARKitBlendShapeLocationSerializable.EyeLookUpRight, out eyeLookUpRight))
                eyeLookUpRightEvent.Invoke(eyeLookUpRight);
            if (blendShapeValues.TryGetValue(ARKitBlendShapeLocationSerializable.EyeSquintLeft, out eyeSquintLeft))
                eyeSquintLeftEvent.Invoke(eyeSquintLeft);
            if (blendShapeValues.TryGetValue(ARKitBlendShapeLocationSerializable.EyeSquintRight, out eyeSquintRight))
                eyeSquintRightEvent.Invoke(eyeSquintRight);
            if (blendShapeValues.TryGetValue(ARKitBlendShapeLocationSerializable.EyeWideLeft, out eyeWideLeft))
                eyeWideLeftEvent.Invoke(eyeWideLeft);
            if (blendShapeValues.TryGetValue(ARKitBlendShapeLocationSerializable.EyeWideRight, out eyeWideRight))
                eyeWideRightEvent.Invoke(eyeWideRight);
            if (blendShapeValues.TryGetValue(ARKitBlendShapeLocationSerializable.JawForward, out jawForward))
                jawForwardEvent.Invoke(jawForward);
            if (blendShapeValues.TryGetValue(ARKitBlendShapeLocationSerializable.JawLeft, out jawLeft))
                jawLeftEvent.Invoke(jawLeft);
            if (blendShapeValues.TryGetValue(ARKitBlendShapeLocationSerializable.JawOpen, out jawOpen))
                jawOpenEvent.Invoke(jawOpen);
            if (blendShapeValues.TryGetValue(ARKitBlendShapeLocationSerializable.JawRight, out jawRight))
                jawRightEvent.Invoke(jawRight);
            if (blendShapeValues.TryGetValue(ARKitBlendShapeLocationSerializable.MouthClose, out mouthClose))
                mouthCloseEvent.Invoke(mouthClose);
            if (blendShapeValues.TryGetValue(ARKitBlendShapeLocationSerializable.MouthDimpleLeft, out mouthDimpleLeft))
                mouthDimpleLeftEvent.Invoke(mouthDimpleLeft);
            if (blendShapeValues.TryGetValue(ARKitBlendShapeLocationSerializable.MouthDimpleRight, out mouthDimpleRight))
                mouthDimpleRightEvent.Invoke(mouthDimpleRight);
            if (blendShapeValues.TryGetValue(ARKitBlendShapeLocationSerializable.MouthFrownLeft, out mouthFrownLeft))
                mouthFrownLeftEvent.Invoke(mouthFrownLeft);
            if (blendShapeValues.TryGetValue(ARKitBlendShapeLocationSerializable.MouthFrownRight, out mouthFrownRight))
                mouthFrownRightEvent.Invoke(mouthFrownRight);
            if (blendShapeValues.TryGetValue(ARKitBlendShapeLocationSerializable.MouthFunnel, out mouthFunnel))
                mouthFunnelEvent.Invoke(mouthFunnel);
            if (blendShapeValues.TryGetValue(ARKitBlendShapeLocationSerializable.MouthLeft, out mouthLeft))
                mouthLeftEvent.Invoke(mouthLeft);
            if (blendShapeValues.TryGetValue(ARKitBlendShapeLocationSerializable.MouthLowerDownLeft, out mouthLowerDownLeft))
                mouthLowerDownLeftEvent.Invoke(mouthLowerDownLeft);
            if (blendShapeValues.TryGetValue(ARKitBlendShapeLocationSerializable.MouthLowerDownRight, out mouthLowerDownRight))
                mouthLowerDownRightEvent.Invoke(mouthLowerDownRight);
            if (blendShapeValues.TryGetValue(ARKitBlendShapeLocationSerializable.MouthPressLeft, out mouthPressLeft))
                mouthPressLeftEvent.Invoke(mouthPressLeft);
            if (blendShapeValues.TryGetValue(ARKitBlendShapeLocationSerializable.MouthPressRight, out mouthPressRight))
                mouthPressRightEvent.Invoke(mouthPressRight);
            if (blendShapeValues.TryGetValue(ARKitBlendShapeLocationSerializable.MouthPucker, out mouthPucker))
                mouthPuckerEvent.Invoke(mouthPucker);
            if (blendShapeValues.TryGetValue(ARKitBlendShapeLocationSerializable.MouthRight, out mouthRight))
                mouthRightEvent.Invoke(mouthRight);
            if (blendShapeValues.TryGetValue(ARKitBlendShapeLocationSerializable.MouthRollLower, out mouthRollLower))
                mouthRollLowerEvent.Invoke(mouthRollLower);
            if (blendShapeValues.TryGetValue(ARKitBlendShapeLocationSerializable.MouthRollUpper, out mouthRollUpper))
                mouthRollUpperEvent.Invoke(mouthRollUpper);
            if (blendShapeValues.TryGetValue(ARKitBlendShapeLocationSerializable.MouthShrugLower, out mouthShrugLower))
                mouthShrugLowerEvent.Invoke(mouthShrugLower);
            if (blendShapeValues.TryGetValue(ARKitBlendShapeLocationSerializable.MouthShrugUpper, out mouthShrugUpper))
                mouthShrugUpperEvent.Invoke(mouthShrugUpper);
            if (blendShapeValues.TryGetValue(ARKitBlendShapeLocationSerializable.MouthSmileLeft, out mouthSmileLeft))
                mouthSmileLeftEvent.Invoke(mouthSmileLeft);
            if (blendShapeValues.TryGetValue(ARKitBlendShapeLocationSerializable.MouthSmileRight, out mouthSmileRight))
                mouthSmileRightEvent.Invoke(mouthSmileRight);
            if (blendShapeValues.TryGetValue(ARKitBlendShapeLocationSerializable.MouthStretchLeft, out mouthStretchLeft))
                mouthStretchLeftEvent.Invoke(mouthStretchLeft);
            if (blendShapeValues.TryGetValue(ARKitBlendShapeLocationSerializable.MouthStretchRight, out mouthStretchRight))
                mouthStretchRightEvent.Invoke(mouthStretchRight);
            if (blendShapeValues.TryGetValue(ARKitBlendShapeLocationSerializable.MouthUpperUpLeft, out mouthUpperUpLeft))
                mouthUpperUpLeftEvent.Invoke(mouthUpperUpLeft);
            if (blendShapeValues.TryGetValue(ARKitBlendShapeLocationSerializable.MouthUpperUpRight, out mouthUpperUpRight))
                mouthUpperUpRightEvent.Invoke(mouthUpperUpRight);
            if (blendShapeValues.TryGetValue(ARKitBlendShapeLocationSerializable.NoseSneerLeft, out noseSneerLeft))
                noseSneerLeftEvent.Invoke(noseSneerLeft);
            if (blendShapeValues.TryGetValue(ARKitBlendShapeLocationSerializable.NoseSneerRight, out noseSneerRight))
                noseSneerRightEvent.Invoke(noseSneerRight);
            if (blendShapeValues.TryGetValue(ARKitBlendShapeLocationSerializable.TongueOut, out tongueOut))
                tongueOutEvent.Invoke(tongueOut);
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