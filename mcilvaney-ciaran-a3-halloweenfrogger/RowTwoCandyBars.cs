using Game10003;
using System;
using System.Numerics;

namespace Game1000;

public class RowTwoCandyBar
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
        float speedMultiplier = 0.8f;
        Vector2 movement = directionSpeed * speedMultiplier;

        // Candy bar speed
        candyBarMovmentSpeed += movement * Time.DeltaTime;
        candyBarPosition -= candyBarMovmentSpeed;

        // Reset back to position -190 if candy bar goes past 890
        if (candyBarPosition.X < -190)
        {
            candyBarPosition.X = 600;
            candyBarMovmentSpeed = Vector2.Zero;
        }
    }
}
