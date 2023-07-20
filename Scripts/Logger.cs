using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PWN
{
    public static class Logger
    {
        public static void Log(string message)
        {
            if (Constants.EnabledLogging) Debug.Log(message);
        }
        public static void LogError(string message)
        {
            if (Constants.EnabledLogging) Debug.LogError(message);
        }
    }
}

