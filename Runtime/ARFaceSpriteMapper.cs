using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using UnityEngine.XR.ARFoundation;

namespace Edwon.ARFaceTools
{
    [Serializable]
    public class ARFaceSpriteMapping
    {
        [HorizontalGroup("Mapping", 50)]
        [HideLabel]
        [PreviewField]
        public Sprite sprite;
        [HorizontalGroup("Mapping", 0, 0, 15)]
        public ARFaceBlendShapeTarget[] blendShapeTargets;
        [HideInInspector]
        public float sum;
    }

    [Serializable]
    public class ARFaceBlendShapeTarget
    {
        [HorizontalGroup]
        [HideLabel]
        public ARKitBlendShapeLocationSerializable blendShapeLocation;
        [HorizontalGroup]
        [HideLabel]
        [Range(0,1)]
        public float targetValue;
    }

    public class ARFaceSpriteMapper : MonoBehaviour
    {
        public SpriteRenderer spriteRenderer;
        public ARFaceSpriteMapping[] spriteMappings;
        float[] differencesTemp;
        int[] sums;

        void Awake()
        {
            differencesTemp = new float[52];
        }

        void OnFaceUpdated(ARFaceUpdatedEventArgs eventArgs, Dictionary<ARKitBlendShapeLocationSerializable, float> blendShapes)
        {
            // compare these to the tracked blendShapes
            for (int i = 0; i < spriteMappings.Length; i++) 
            {
                // get the difference between each blend shape target and it's tracked
                for (int j = 0; j < spriteMappings[i].blendShapeTargets.Length; j++) 
                {
                    ARFaceBlendShapeTarget currentBlendShapeTarget =  spriteMappings[i].blendShapeTargets[j];
                    differencesTemp[j] = Mathf.Abs(currentBlendShapeTarget.targetValue - blendShapes[currentBlendShapeTarget.blendShapeLocation]);
                }

                // get the sum of the all temp differences
                float sum = 0;
                for (int j = 0; j < differencesTemp.Length; j++)
                {
                    sum += differencesTemp[j];
                }
                // add the sum to this sprite mapping
                spriteMappings[i].sum = sum;
            }

            int indexOfLowestSum = FindLowestSumInSpriteMappings();
            spriteRenderer.sprite = spriteMappings[indexOfLowestSum].sprite;
        }

        int FindLowestSumInSpriteMappings()
        {
            int pos = 0;
            for (int i = 0; i < spriteMappings.Length; i++)
            {
                if (spriteMappings[i].sum < spriteMappings[pos].sum) { pos = i; }
            }
            return pos;
        }

        void OnEnable()
        {
            ARFaceTrackingUtils.onFaceUpdatedEvent += OnFaceUpdated;
        }

        void OnDisable()
        {
            ARFaceTrackingUtils.onFaceUpdatedEvent -= OnFaceUpdated;
        }
    }
}
