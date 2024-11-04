using System;
using System.Numerics;

namespace Game10003;

public class EndLocation
{
    // Setting up variables
    public Vector2 endLocationPosition;
    public Vector2 endLocationSize;
    public Color color;

    public void DrawEndLocation()
    {
        // Draw ghosts onto screen
        Draw.FillColor = color;
        Draw.LineSize = 0;
        Draw.Rectangle(endLocationPosition, endLocationSize);
    }
}
