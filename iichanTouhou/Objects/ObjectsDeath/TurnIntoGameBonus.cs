using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iichanTouhou.Helpers;

namespace iichanTouhou.Objects.Bullets.ObjectsDeath
{
    class TurnIntoGameBonus :WayOfDying
    {
        public TurnIntoGameBonus(GameObject dyingObject) : base(dyingObject)
        {
            DyingObject.Texture = TextureGenerator.Generate(Properties.Resources.Bonus, ImageFormat.Png);
        }


        public override void GoTheWay()
        {
            DyingObject.Update();
        }
    }
}
