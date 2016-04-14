namespace iichanTouhou.Objects.Bullets.ObjectsDeath
{
    abstract class WayOfDying
    {
        protected GameObject DyingObject;

        protected WayOfDying(GameObject dyingObject)
        {
            DyingObject = dyingObject;
        }
    }

}
