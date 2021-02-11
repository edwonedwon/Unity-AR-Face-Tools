﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Puppetoon
{
    public class ARFacePoseSender : MonoBehaviour
    {
        public delegate void OnFacePoseUpdatedEvent(Transform faceTransform);
        public static event OnFacePoseUpdatedEvent onFacePoseUpdatedEvent;

        void Update()
        {
            if (onFacePoseUpdatedEvent != null)
                onFacePoseUpdatedEvent(transform);
        }
    }
}
