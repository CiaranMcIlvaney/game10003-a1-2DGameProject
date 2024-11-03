using System;
using System.Numerics;

namespace Game10003;

public class RowTwoGhosts
{

    public Vector2 ghostPosition;
    public Vector2 ghostSize;
    public Color color;
    public Vector2 ghostMovmentSpeed;

    public void DrawGhosts()
    {
        // Draw ghosts onto screen
        Draw.FillColor = color;
        Draw.LineSize = 0;
        Draw.Rectangle(ghostPosition, ghostSize);
    }
    public void Move()
    {
        Vector2 directionSpeed = new Vector2(2, 0);
        ghostMovmentSpeed += directionSpeed * Time.DeltaTime;
        ghostPosition += ghostMovmentSpeed;

        if (ghostPosition.X > 600)
        {
            ghostPosition.X = -100;
            ghostMovmentSpeed = Vector2.Zero;
        }
    }
}
