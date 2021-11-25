#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Edwon.ARFaceTools;
using UnityEngine.XR.ARKit;
using UnityEngine.XR.ARFoundation;
using UnityEngine.Events;
using Edwon.Tools;

// only render currently used events in inspector
namespace Edwon.ARFaceTools
{
	using UnityEditor;

	[CanEditMultipleObjects]
	[CustomEditor(typeof(ARFaceBlendShapesReceiver))]
	public class ARFaceBlendShapesReceiverEditor : Editor
	{
        SerializedProperty showEyeEvents;
        SerializedProperty showCheekEvents;
        SerializedProperty showBrowEvents;
        SerializedProperty showJawEvents;
        SerializedProperty showMouthEvents;
        SerializedProperty showOtherEvents;
		private bool showUnusedEvents = false;    

        ARFaceBlendShapesReceiver script;

        void OnEnable()
        {
            script = (ARFaceBlendShapesReceiver)target;

            showEyeEvents = serializedObject.FindProperty("showEyeEvents");
            showCheekEvents = serializedObject.FindProperty("showCheekEvents");
            showBrowEvents = serializedObject.FindProperty("showBrowEvents");
            showJawEvents = serializedObject.FindProperty("showJawEvents");
            showMouthEvents = serializedObject.FindProperty("showMouthEvents");
            showOtherEvents = serializedObject.FindProperty("showOtherEvents");
        }

		// Draw the whole inspector
		public override void OnInspectorGUI()
		{
            serializedObject.Update();

			EditorGUILayout.Separator();
            EditorGUILayout.PropertyField(showEyeEvents);
            EditorGUILayout.PropertyField(showCheekEvents);
            EditorGUILayout.PropertyField(showBrowEvents);
            EditorGUILayout.PropertyField(showJawEvents);
            EditorGUILayout.PropertyField(showMouthEvents);
            EditorGUILayout.PropertyField(showOtherEvents);
			
            EditorGUILayout.Separator();

			showUnusedEvents = EditorGUILayout.Foldout(showUnusedEvents, "Unused Events");

            if (showBrowEvents.boolValue)
            {
                DrawIfEventUsed(script.browDownLeftEvent, "browDownLeftEvent");
                DrawIfEventUsed(script.browDownRightEvent, "browDownRightEvent");
                DrawIfEventUsed(script.browInnerUpEvent, "browInnerUpEvent");
                DrawIfEventUsed(script.browOuterUpLeftEvent, "browOuterUpLeftEvent");
                DrawIfEventUsed(script.browOuterUpRightEvent, "browOuterUpRightEvent");
            }
            if (showCheekEvents.boolValue)
            {
                DrawIfEventUsed(script.cheekPuffEvent, "cheekPuffEvent");
                DrawIfEventUsed(script.cheekSquintLeftEvent, "cheekSquintLeftEvent");
                DrawIfEventUsed(script.cheekSquintRightEvent, "cheekSquintRightEvent");
            }
            if (showEyeEvents.boolValue)
            {
                DrawIfEventUsed(script.eyeBlinkLeftEvent, "eyeBlinkLeftEvent");
                DrawIfEventUsed(script.eyeBlinkRightEvent, "eyeBlinkRightEvent");
                DrawIfEventUsed(script.eyeLookDownLeftEvent, "eyeLookDownLeftEvent");
                DrawIfEventUsed(script.eyeLookDownRightEvent, "eyeLookDownRightEvent");
                DrawIfEventUsed(script.eyeLookInLeftEvent, "eyeLookInLeftEvent");
                DrawIfEventUsed(script.eyeLookInRightEvent, "eyeLookInRightEvent");
                DrawIfEventUsed(script.eyeLookOutLeftEvent, "eyeLookOutLeftEvent");
                DrawIfEventUsed(script.eyeLookOutRightEvent, "eyeLookOutRightEvent");
                DrawIfEventUsed(script.eyeLookUpLeftEvent, "eyeLookUpLeftEvent");
                DrawIfEventUsed(script.eyeLookUpRightEvent, "eyeLookUpRightEvent");
                DrawIfEventUsed(script.eyeSquintLeftEvent, "eyeSquintLeftEvent");
                DrawIfEventUsed(script.eyeSquintRightEvent, "eyeSquintRightEvent");
                DrawIfEventUsed(script.eyeWideLeftEvent, "eyeWideLeftEvent");
                DrawIfEventUsed(script.eyeWideRightEvent, "eyeWideRightEvent");
            }
            if (showJawEvents.boolValue)
            {
                DrawIfEventUsed(script.jawForwardEvent, "jawForwardEvent");
                DrawIfEventUsed(script.jawLeftEvent, "jawLeftEvent");
                DrawIfEventUsed(script.jawOpenEvent, "jawOpenEvent");
                DrawIfEventUsed(script.jawRightEvent, "jawRightEvent");
            }
            if (showMouthEvents.boolValue)
            {
                DrawIfEventUsed(script.mouthCloseEvent, "mouthCloseEvent");
                DrawIfEventUsed(script.mouthDimpleLeftEvent, "mouthDimpleLeftEvent");
                DrawIfEventUsed(script.mouthDimpleRightEvent, "mouthDimpleRightEvent");
                DrawIfEventUsed(script.mouthFrownLeftEvent, "mouthFrownLeftEvent");
                DrawIfEventUsed(script.mouthFrownRightEvent, "mouthFrownRightEvent");
                DrawIfEventUsed(script.mouthFunnelEvent, "mouthFunnelEvent");
                DrawIfEventUsed(script.mouthLeftEvent, "mouthLeftEvent");
                DrawIfEventUsed(script.mouthLowerDownLeftEvent, "mouthLowerDownLeftEvent");
                DrawIfEventUsed(script.mouthLowerDownRightEvent, "mouthLowerDownRightEvent");
                DrawIfEventUsed(script.mouthPressLeftEvent, "mouthPressLeftEvent");
                DrawIfEventUsed(script.mouthPressRightEvent, "mouthPressRightEvent");
                DrawIfEventUsed(script.mouthPuckerEvent, "mouthPuckerEvent");
                DrawIfEventUsed(script.mouthRightEvent, "mouthRightEvent");
                DrawIfEventUsed(script.mouthRollLowerEvent, "mouthRollLowerEvent");
                DrawIfEventUsed(script.mouthRollUpperEvent, "mouthRollUpperEvent");
                DrawIfEventUsed(script.mouthShrugLowerEvent, "mouthShrugLowerEvent");
                DrawIfEventUsed(script.mouthShrugUpperEvent, "mouthShrugUpperEvent");
                DrawIfEventUsed(script.mouthSmileLeftEvent, "mouthSmileLeftEvent");
                DrawIfEventUsed(script.mouthSmileRightEvent, "mouthSmileRightEvent");
                DrawIfEventUsed(script.mouthStretchLeftEvent, "mouthStretchLeftEvent");
                DrawIfEventUsed(script.mouthStretchRightEvent, "mouthStretchRightEvent");
                DrawIfEventUsed(script.mouthUpperUpLeftEvent, "mouthUpperUpLeftEvent");
                DrawIfEventUsed(script.mouthUpperUpRightEvent, "mouthUpperUpRightEvent");
            }
            if (showOtherEvents.boolValue)
            {
                DrawIfEventUsed(script.noseSneerLeftEvent, "noseSneerLeftEvent");
                DrawIfEventUsed(script.noseSneerRightEvent, "noseSneerRightEvent");
                DrawIfEventUsed(script.tongueOutEvent, "tongueOutEvent");
            }

            serializedObject.ApplyModifiedProperties();
		}

        void DrawIfEventUsed<T>(UnityEventEdwonBase<T> e, string eventName)
        {
			if (Utils.EventHasTarget(e) || showUnusedEvents == true)
				Draw(eventName);
        }

        void Draw(string propertyName)
        {
            EditorGUILayout.PropertyField(serializedObject.FindProperty(propertyName));
        }
	}

}
#endif