using IIchanDanmakuProject.Helpers;
using SFML.System;

namespace IIchanDanmakuProject.Objects.Bullets.Behavior.DirectionOfMovement
{
    class MovementToNearestTargetObject :DeterminantOfDirectionOfMovementBase
    {
        private readonly Vector2f _directionInTheAbsenceOfObjects;

        public MovementToNearestTargetObject(Vector2f directionInTheAbsenceOfObjects)
        {
            _directionInTheAbsenceOfObjects = directionInTheAbsenceOfObjects;
        }

        GameObject GetNearestTargetObject()
        {
            if (Bullet.TargetObjects.Count > 0)
            {
                float minDistance = (Bullet.TargetObjects[0].CenterCoordinates - Bullet.CenterCoordinates).Length();
                GameObject nearestTargetObject = Bullet.TargetObjects[0];

                for (int i = 0; i < Bullet.TargetObjects.Count; i++)
                {
                    float distance = (Bullet.TargetObjects[i].CenterCoordinates - Bullet.CenterCoordinates).Length();
                    if (distance < minDistance)
                    {
                        minDistance = distance;
                        nearestTargetObject = Bullet.TargetObjects[i];
                    }
                }
                return nearestTargetObject;
            }
            return null;
        }

        public override void Move()
        {
            GameObject nearestTargetObject = GetNearestTargetObject();
            if (nearestTargetObject != null)
                Bullet.Speed = (nearestTargetObject.CenterCoordinates - Bullet.CenterCoordinates).Normalize()*
                               SpeedFactor;
            else
                Bullet.Speed = _directionInTheAbsenceOfObjects.Normalize()*SpeedFactor;
        }
    }
}
