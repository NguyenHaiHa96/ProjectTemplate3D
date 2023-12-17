using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameScripts.Utility;

namespace  GameScripts.Pattern
{
    public class Singleton<T> : CacheComponent where T : MonoBehaviour
    {
        protected static T instance;

        public static T Instance => instance;
    
        public virtual void Awake()
        {
            if (instance != null)
            {
                DestroyImmediate(gameObject);
            }
            else
            {
                instance = this as T;
                DontDestroyOnLoad(gameObject);
            }
        }
    
        public virtual void OnInit()
        {
    
        }
    
        public virtual void FetchData()
        {
    
        }
    }
}

