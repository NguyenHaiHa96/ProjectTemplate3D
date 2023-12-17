using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameScripts.Utility
{
    public class CacheComponent : MonoBehaviour
    {
        private Transform _transform;
        private RectTransform _rectTransform;
        public Transform Transform
        {
            get
            {
                if (_transform != null) return _transform;
                _transform = gameObject.transform;
                return _transform;
            }
        }

        public RectTransform RectTransform
        {
            get
            {
                if (_rectTransform != null) return _rectTransform;
                _rectTransform = gameObject.GetComponent<RectTransform>(); ;
                return _rectTransform;
            }
        }

        public Quaternion Rotation { get => Transform.rotation; set => Transform.rotation = value; }
        public Vector3 WorldPosition { get => Transform.position; set => Transform.position = value; }
        public Vector3 LocalPosition { get => Transform.localPosition; set => Transform.localPosition = value; }
        public Vector3 LocalScale { get => Transform.localScale; set => Transform.localScale = value; }
        public Vector3 EulerAngles { get => Transform.eulerAngles; set => transform.eulerAngles = value; }
        public Vector3 EulerLocalRotation => Transform.localRotation.eulerAngles; 
        public Vector3 AnchoredPosition { get => RectTransform.anchoredPosition; set => RectTransform.anchoredPosition = value; }
        public Vector3 SizeDelta { get => RectTransform.sizeDelta; set => RectTransform.sizeDelta = value; }

        public float DeltaTime => Time.deltaTime; 
        public float FixedDeltaTime => Time.fixedDeltaTime; 
    }
}

