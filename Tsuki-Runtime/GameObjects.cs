﻿using Lunari.Tsuki.Misc;
using UnityEngine;
using UnityEngine.Events;

namespace Lunari.Tsuki {
    public static class GameObjects {
        public static Tuple<GameObject, T> CreateWith<T>(
            UnityAction<T> initializer = null
        ) where T : Component {
            return CreateWith($"GameObject ({typeof(T).Name})", initializer);
        }

        public static Tuple<GameObject, T> CreateWith<T>(
            string name,
            UnityAction<T> initializer = null
        ) where T : Component {
            var obj = new GameObject(name);
            var comp = obj.AddComponent<T>();
            initializer?.Invoke(comp);

            return new Tuple<GameObject, T>(obj, comp);
        }

        public static Tuple<GameObject, A, B> CreateWith<A, B>(
            UnityAction<A, B> initializer = null
        ) where A : Component where B : Component {
            return CreateWith($"GameObject ({typeof(A).Name}, {typeof(B).Namespace})", initializer);
        }

        public static Tuple<GameObject, A, B> CreateWith<A, B>(
            string name,
            UnityAction<A, B> initializer = null
        ) where A : Component where B : Component {
            var obj = new GameObject(name);
            var compA = obj.AddComponent<A>();
            var compB = obj.AddComponent<B>();
            initializer?.Invoke(compA, compB);

            return new Tuple<GameObject, A, B>(obj, compA, compB);
        }
    }
}