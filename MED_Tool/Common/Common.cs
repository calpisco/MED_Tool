using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MED_Tool.Common
{
    static class Common
    {
        public enum THEME_COLOR
        {
            LIGHT, DARK
        }
        public enum LANGUAGE
        {
            JAPANESE, ENGLISH
        }

        public enum ADVANCEMENT_FLG
        {
            ACQUIRE_HARDWARE =      0b100000000,
            NETHER =                0b010000000,
            THOSE_WERE_THE_DAYS =  0b001000000,
            OH_SHINY =              0b000100000,
            A_TERRIBLE_FORTRESS =   0b000010000,
            INTO_FIRE =             0b000001000,
            EYE_SPY =               0b000000100,
            THE_END =               0b000000010,
            FREE_THE_END =          0b000000001
        }

        public const int FOUR_K_WIDTH = 3840;

        public const int ADVANCEMENT_ICON_SIZE_MAX = 128;
        public const int ADVANCEMENT_ICON_SIZE_MIN = 16;
    }
}
