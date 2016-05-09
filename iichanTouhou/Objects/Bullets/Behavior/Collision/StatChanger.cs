namespace IIchanDanmakuProject.Objects.Bullets.Behavior.Collision
{
    class StatChanger
    {
        private readonly int _valueOfChangeOfXp;
        private readonly float _valueOfChangeOfPower;
        private readonly int _valueOfChangeOfScore;
        private readonly int _valueOfChangeOfcountOfLives;


        public StatChanger(int valueOfChangeOfXp, float valueOfChangeOfPower, int valueOfChangeOfScore, int valueOfChangeOfcountOfLives)
        {
            _valueOfChangeOfXp = valueOfChangeOfXp;
            _valueOfChangeOfPower = valueOfChangeOfPower;
            _valueOfChangeOfScore = valueOfChangeOfScore;
            _valueOfChangeOfcountOfLives = valueOfChangeOfcountOfLives;
        }

        public StatChanger(int valueOfChangeOfXp, float valueOfChangeOfPower, int valueOfChangeOfScore)
            :this(valueOfChangeOfXp,valueOfChangeOfPower,valueOfChangeOfScore,0)
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
                mainObject.CountOfLives += _valueOfChangeOfcountOfLives;
            }
            else
                collidedObject.XP += _valueOfChangeOfXp;
        }
    }
}
