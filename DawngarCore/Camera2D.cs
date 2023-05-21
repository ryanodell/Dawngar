using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DawngarCore
{
    public class Camera2D
    {
        //Some freak'n magical numbers
        private const int MAX_COLUMN_OFFSET = 13;
        private const int MAX_ROW_OFFSET = 7;
        private const int MIN_COLUMN_OFFSET = 14;
        private const int MIN_ROW_OFFSET = 8;
        private const int MIN_WIDTH = 25;
        private const int MIN_HEIGHT = 25;

        private GraphicsDevice _graphicsDevice;
        public Camera2D(GraphicsDevice graphicsDevice)
        {
            _graphicsDevice = graphicsDevice;
            Rotation = 0;
            Zoom = 1;
            Origin = new Vector2(graphicsDevice.Viewport.Width / 2f, graphicsDevice.Viewport.Height / 2f);
            Position = Vector2.Zero;
        }

        public Vector2 Position { get; set; }
        public float Rotation { get; set; }
        public Vector2 Origin { get; set; }
        public float Zoom { get; set; }
        public Vector2 Center => Position + Origin;
        public void Move(Vector2 direction)
        {
            Position += Vector2.Transform(direction, Matrix.CreateRotationZ(-Rotation));
        }

        public void Rotate(float deltaRadians)
        {
            Rotation += deltaRadians;
        }

        public void LookAt(Vector2 position)
        {
            Position = position - new Vector2(_graphicsDevice.Viewport.Width / 2f, _graphicsDevice.Viewport.Height / 2f);
        }

        public Vector2 WorldToScreen(float x, float y)
        {
            return WorldToScreen(new Vector2(x, y));
        }

        public Vector2 WorldToScreen(Vector2 worldPosition)
        {
            var viewport = _graphicsDevice.Viewport;
            return Vector2.Transform(worldPosition + new Vector2(viewport.X, viewport.Y), GetViewMatrix());
        }

        // public void LerpTo(GameTime gameTime, Viewport viewPort, Vector2 lerpToPosition, IDictionary<string, GameCell> cells, bool lockToBounds)
        // {
        //     var delta = (float)gameTime.ElapsedGameTime.TotalSeconds;
        //     Vector2 cameraPosition = Position;
        //     cameraPosition.X += (viewPort.Width / 2);
        //     cameraPosition.Y += (viewPort.Height / 2);
        //     cameraPosition.X = MathHelper.Lerp(cameraPosition.X, lerpToPosition.X, 0.08f);
        //     cameraPosition.Y = MathHelper.Lerp(cameraPosition.Y, lerpToPosition.Y, 0.08f);
        //     cameraPosition.X -= (viewPort.Width / 2);
        //     cameraPosition.Y -= (viewPort.Height / 2);
        //     if(!lockToBounds)
        //     {
        //         Position = cameraPosition;
        //         return;
        //     }
        //     var maxIdx = cells.Values.Last();
        //     var minIdx = cells.Values.First();
        //     var maxColumn = Convert.ToInt32(maxIdx.Idx_x) - MAX_COLUMN_OFFSET;
        //     var maxRow = Convert.ToInt32(maxIdx.Idx_y) - MAX_ROW_OFFSET;
        //     var minColumn = Convert.ToInt32(minIdx.Idx_x) + MIN_COLUMN_OFFSET;
        //     var minRow = Convert.ToInt32(minIdx.Idx_y) + MIN_ROW_OFFSET;
        //     if (Convert.ToInt32(maxIdx.Idx_x) > MIN_HEIGHT || Convert.ToInt32(maxIdx.Idx_y) > MIN_WIDTH)
        //     {
        //         float minX = minColumn * 16 - (viewPort.Width / 2);
        //         float maxX = maxColumn * 16 - (viewPort.Width / 2);
        //         float minY = minRow * 16 - (viewPort.Height / 2);
        //         float maxY = maxRow * 16 - (viewPort.Height / 2);
        //         if (cameraPosition.X <= minX)
        //         {
        //             cameraPosition.X = minX;
        //         }
        //         if (cameraPosition.X >= maxX)
        //         {
        //             cameraPosition.X = maxX;
        //         }
        //         if (cameraPosition.Y <= minY)
        //         {
        //             cameraPosition.Y = minY;
        //         }
        //         if (cameraPosition.Y >= maxY)
        //         {
        //             cameraPosition.Y = maxY;
        //         }
        //     }
        //     Position = cameraPosition;
        // }

        public Matrix GetViewMatrix()
        {
            return
                Matrix.CreateTranslation(new Vector3(-Position, 0.0f)) *
                Matrix.CreateTranslation(new Vector3(-Origin, 0.0f)) *
                Matrix.CreateRotationZ(Rotation) *
                Matrix.CreateScale(Zoom, Zoom, 1) *
                Matrix.CreateTranslation(new Vector3(Origin, 0.0f));
        }

        public Matrix GetInverseViewMatrix()
        {
            return Matrix.Invert(GetViewMatrix());
        }
    }
}