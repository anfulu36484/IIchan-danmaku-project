using System.Runtime.CompilerServices;
using IIchanDanmakuProject.Helpers;
using SFML.System;

namespace IIchanDanmakuProject.Objects.Bullets.Behavior.DirectionOfMovement
{
    class MovementFromObject :DeterminantOfDirectionOfMovementBase
    {
        private readonly GameObject _gameObject;

        public Vector2f DisplacementOfTheCenterOfTheObject;

        public MovementFromObject(GameObject gameObject)
            :this(gameObject,new Vector2f(0,0))
        {
            _gameObject = gameObject;
        }

        public MovementFromObject(GameObject gameObject, Vector2f displacementOfTheCenterOfTheObject)
        {
            _gameObject = gameObject;
            DisplacementOfTheCenterOfTheObject = displacementOfTheCenterOfTheObject;
        }

        public override void Move()
        {
            Bullet.Speed = (Bullet.CenterCoordinates - (_gameObject.CenterCoordinates+ DisplacementOfTheCenterOfTheObject)).Normalize() * SpeedFactor;
        }
    }
}
