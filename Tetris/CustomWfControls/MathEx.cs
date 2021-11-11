using System;
using System.Collections.Generic;
using System.Text;

namespace Tetris.CustomWfControls
{
    public static class MathEx
    {
        public static float Lerp(float startV, float endV, float time)
        {
            time = Math.Clamp(time, 0, 1);
            return startV + (endV - startV) * time;
        }

        public static int Lerp(int startV, int endV, float time)
        {
            time = Math.Clamp(time, 0, 1);
            return startV + (int)MathF.Round((endV - startV) * time);
        }

        public static float Clamp01(float value)
        {
            return Math.Clamp(value, 0, 1);
        }
    }
}
