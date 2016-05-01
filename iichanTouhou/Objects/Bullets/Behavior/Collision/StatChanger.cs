namespace IIchanDanmakuProject.Objects.Bullets.Behavior.Collision
{
    class StatChanger
    {
        private readonly int _valueOfChangeOfXp;
        private readonly int _valueOfChangeOfPower;
        private readonly int _valueOfChangeOfScore;


        
        public StatChanger(int valueOfChangeOfXp, int valueOfChangeOfPower, int valueOfChangeOfScore)
        {
            _valueOfChangeOfXp = valueOfChangeOfXp;
            _valueOfChangeOfPower = valueOfChangeOfPower;
            _valueOfChangeOfScore = valueOfChangeOfScore;
        }

        public StatChanger(int valueOfChangeOfXp):this (valueOfChangeOfXp,0,0) { }

        public void ChangeStats(GameObject collidedObject)
        {
            MainObject mainObject = collidedObject as MainObject;
            if (mainObject != null)
            {
                mainObject.XP += _valueOfChangeOfXp;
                mainObject.Power += _valueOfChangeOfPower;
                mainObject.Score += _valueOfChangeOfScore;
            }
            else
                collidedObject.XP += _valueOfChangeOfXp;
        }
    }
}
