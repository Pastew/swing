namespace Utils
{
    public static class MathUtils
    {
        public static float Remap(float a0, float a1, float b0, float b1, float a)
        {
            return b0 + (b1 - b0) * ((a - a0) / (a1 - a0));
        }
    }
}