﻿namespace Tools.Patterns.Singleton
{
    public class Singleton<T> where T : class, new()
    {
        protected Singleton()
        {
        }

        public static T Instance { get; private set; } = CreateInstance();

        static T CreateInstance() => Instance ?? (Instance = new T());

        public void InjectInstance(T instance)
        {
            if (instance != null)
                Instance = instance;
        }
    }
}