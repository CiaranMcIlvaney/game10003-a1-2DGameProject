using System;
using System.Numerics;

namespace Game10003;

public class RowThreeCandyBar
{
    // Setting up variables
    public Vector2 candyBarPosition;
    public Vector2 candyBarSize;
    public Color color;
    public Vector2 candyBarMovmentSpeed;

    public void DrawCandyBar()
    {
        // Draw ghosts onto screen
        Draw.FillColor = color;
        Draw.LineSize = 0;
        Draw.Rectangle(candyBarPosition, candyBarSize);
    }
    public void Move()
    {
        // Allows to bypass the no floats allowed in vectors
        Vector2 directionSpeed = new Vector2(1, 0);
        float speedMultiplier = 0.5f;
        Vector2 movement = directionSpeed * speedMultiplier;

        // Candy bar speed
        candyBarMovmentSpeed += movement * Time.DeltaTime;
        candyBarPosition -= candyBarMovmentSpeed;

        // Reset back to position -190 if candy bar goes past 890
        if (candyBarPosition.X < -290)
        {
            candyBarPosition.X = 600;
            candyBarMovmentSpeed = Vector2.Zero;
        }
    }
}
