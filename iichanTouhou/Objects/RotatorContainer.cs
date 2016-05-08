using System;
using SFML.Graphics;

namespace IIchanDanmakuProject.Objects
{
    class RotatorContainer
    {
        public GameObject OwnerObject;

        public Danmaku Danmaku;

        private RectangleShape _rotatedRectangle;

        public RotatorContainer(Danmaku danmaku, GameObject ownerObject)
        {
            Danmaku = danmaku;
            OwnerObject = ownerObject;
        }

        public void CreateRotatedRectangle()
        {
            _rotatedRectangle = new RectangleShape(OwnerObject.RectangleShape);
            _rotatedRectangle.Origin = _rotatedRectangle.Size*0.5f;
        }

        public bool IsRotatedShapeNotExist()
        {
            return _rotatedRectangle == null;
        }

        public float Rotation
        {
            get
            {
                if (_rotatedRectangle == null)
                    throw new Exception("RotatedShape does not exist");
                return _rotatedRectangle.Rotation;
            }
            set
            {
                if (_rotatedRectangle == null)
                    throw new Exception("RotatedShape does not exist");
                _rotatedRectangle.Rotation = value;
            }
        }

        public void Update()
        {
            if (_rotatedRectangle != null)
                _rotatedRectangle.Position = OwnerObject.CenterCoordinates;
        }

        public void Render()
        {
            if (_rotatedRectangle != null)
                Danmaku.window.Draw(_rotatedRectangle);
        }
    }
}
