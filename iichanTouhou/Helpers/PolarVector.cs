namespace IIchanDanmakuProject.Helpers
{
    public struct PolarVector
    {
        public float r;
        public float theta;

        public PolarVector(float r, float theta)
        {
            this.r = r;
            this.theta = theta;
        }

        public PolarVector(double r, double theta)
        {
            this.r = (float)r;
            this.theta = (float)theta;
        }
    }

}
