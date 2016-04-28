using IIchanDanmakuProject.Helpers;

namespace IIchanDanmakuProject.Objects.Bullets.Behavior.DirectionOfMovement
{
    class MovementToNearestTargetObject :DeterminantOfDirectionOfMovementBase
    {

        GameObject GetNearestTargetObject()
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

        public override void Move()
        {
            Bullet.Speed = (GetNearestTargetObject().CenterCoordinates - Bullet.CenterCoordinates).Normalize() * SpeedFactor;
        }
    }
}
