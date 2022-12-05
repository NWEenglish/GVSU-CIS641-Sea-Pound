using UnityEngine;

namespace Assets.Scripts.Helpers
{
    public static class ColorHelper
    {
        public static Color GetFadedColor(Color color)
        {
            var fadedColor = color;
            fadedColor.a = 0.5f;

            return fadedColor;
        }
    }
}
