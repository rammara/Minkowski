using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;


namespace Minkowski.Code
{
    public static class Settings
    {
        public static Color BaseAxiiColor { get; set; } = Color.FromArgb(255,255,255,255);
        public static Color RelativisticAxiiColor { get; set; } = Color.FromArgb(255, 128, 128, 128);
        public static Color LightConeColor { get; set; } = Color.FromArgb(128, 255, 255, 0);
        public static Color BaseGridColor { get; set; } = Color.FromArgb(128, 32, 32, 32);
        public static Color RelativisticGridColor { get; set; } = Color.FromArgb(255, 0, 32, 0);      


        public static float DefaultViewportLeft { get; set; } = -10.0f;
        public static float DefaultViewportTop { get; set; } = 10.0f;
        public static float DefaultViewportWidth { get; set; } = 20.0f;
        public static float DefaultViewportHeight { get; set; } = 20.0f;

        public static float FontSize { get; set; } = 12.0f;

        public static float ArrowCapSize { get; set; } = 5.0f;

        public static float DotSize { get; set; } = 8f; // pixels

        public static float ZoomPercent { get; set; } = 0.1f;

        public static bool ShowEventNames { get; set; } = true;
        public static bool ShowGrids { get; set; } = true;
        public static bool ShowLightCone { get; set; } = true;

    } // class Settings
} // namespace
