﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabratEyeTracking
{
    public static class UniversalEyeData
    {
        public static Eye LeftEye { private set; get; }
        public static Eye RightEye { private set; get; }
        public static Eye CombinedEye
        {
            get
            {
                Eye generatedCombinedEye = new Eye()
                {
                    x = (LeftEye.x + RightEye.x) / 2,
                    y = (LeftEye.y + RightEye.y) / 2,
                    Widen = (LeftEye.Widen + RightEye.Widen) / 2
                };
                return generatedCombinedEye;
            }
        }

        public static void UpdateLeftEyeData(Eye data) => LeftEye = data;
        public static void UpdateRightEyeData(Eye data) => RightEye = data;

        public static void UpdateLeftEyeData(float x, float y, float Widen) => LeftEye = new Eye()
        {
            x = x,
            y = y,
            Widen = Widen
        };
        public static void UpdateRightEyeData(float x, float y, float Widen) => LeftEye = new Eye()
        {
            x = x,
            y = y,
            Widen = Widen
        };
    }

    public class Eye
    {
        public float x;
        public float y;
        public float Widen;
    }

    public interface IEyeTracking
    {
        bool EyeTrackingEnabled
        {
            get;
            set;
        }

        void Init();
        void Kill();
    }
}
