﻿using System;
using Avalonia.Media;
using RefactorMe.Common;

namespace RefactorMe
{
    class Draw
    {
        static float X, Y;
        static IGraphics graphics;

        public static void Initialize(IGraphics newGraphic)
        {
            graphics = newGraphic;
            //grafika.SmoothingMode = SmoothingMode.None;
            ClearScreen();
        }
                public static void SetPosition(float x0, float y0)
        {
            X = x0;
            Y = y0;
        }

        public static void makeIt(Pen ruchka, double dlina, double ugol)
        public static void DrawLine(Pen ruchka, double dlina, double ugol)
        {
        //Делает шаг длиной dlina в направлении ugol и рисует пройденную траекторию
            var x1 = (float)(X + dlina * Math.Cos(ugol));
            var y1 = (float)(Y + dlina * Math.Sin(ugol));
            graphics.DrawLine(ruchka, X, Y, x1, y1);
            X = x1;
            Y = y1;
        }

                    X = (float)(X + dlina * Math.Cos(ugol));
            Y = (float)(Y + dlina * Math.Sin(ugol));
        }

        private static void ClearScreen()
        {
            x = (float)(x + dlina * Math.Cos(ugol)); 
           y = (float)(y + dlina * Math.Sin(ugol));
           }
            graphics.Clear(Colors.Black);
        }
    }
    
    public class ImpossibleSquare
{
    public static void Draw(int shirina, int visota, double ugolPovorota, IGraphics grafika)
    {
        // ugolPovorota пока не используется, но будет использоваться в будущем
                private static void DrawSide(float sideLength, float thickness, double angle)
        {
            Draw.DrawLine(new Pen(Brushes.Yellow), sideLength, angle);
            Draw.DrawLine(new Pen(Brushes.Yellow), thickness * Math.Sqrt(2), angle + Math.PI / 4);
            Draw.DrawLine(new Pen(Brushes.Yellow), sideLength, angle + Math.PI);
            Draw.DrawLine(new Pen(Brushes.Yellow), sideLength - thickness, angle + Math.PI / 2);
        }

            public static void Draw(int shirina, int visota, double ugolPovorota, IGraphics graphics)
        {
            Draw.Initialize(graphics);

        Risovatel.Change(sz * 0.04f, -Math.PI);
        Risovatel.Change(sz * 0.04f * Math.Sqrt(2), 3 * Math.PI / 4);

        var diagonalLength = Math.Sqrt(2) * ((SIDE_LENGTH + THICKNESS) / 2);
            var x0 = (float)(diagonalLength * Math.Cos(Math.PI / 4 + Math.PI)) + shirina / 2f;
            var y0 = (float)(diagonalLength * Math.Sin(Math.PI / 4 + Math.PI)) + visota / 2f;

        Draw.SetPosition(x0, y0);

        DrawSide(SIDE_LENGTH, THICKNESS, 0);
        Draw.Change(THICKNESS, -Math.PI);
        Draw.Change(THICKNESS * Math.Sqrt(2), 3 * Math.PI / 4);

        DrawSide(SIDE_LENGTH, THICKNESS, -Math.PI / 2);
        Draw.Change(THICKNESS, -Math.PI / 2 - Math.PI);
        Draw.Change(THICKNESS * Math.Sqrt(2), -Math.PI / 2 + 3 * Math.PI / 4);

        DrawSide(SIDE_LENGTH, THICKNESS, Math.PI / 2);
        Draw.Change(THICKNESS, Math.PI / 2 - Math.PI);
        Draw.Change(THICKNESS * Math.Sqrt(2), Math.PI / 2 + 3 * Math.PI / 4);
        }

        DrawSide(SIDE_LENGTH, THICKNESS, Math.PI / 2);
        Draw.Change(THICKNESS, Math.PI / 2 - Math.PI);
        Draw.Change(THICKNESS * Math.Sqrt(2), Math.PI / 2 + 3 * Math.PI / 4);
        }

}
}
