using System;
using System.Numerics;

namespace Game10003;

public class WitchPotionJuice
{
    // Setting up variables
    public Vector2 potionPosition;
    public Vector2 potionSize;
    public Color color;

    public void DrawPotionJuice()
    {
        // Draw ghosts onto screen
        Draw.FillColor = color;
        Draw.LineSize = 0;
        Draw.Rectangle(potionPosition, potionSize);
    }
}
