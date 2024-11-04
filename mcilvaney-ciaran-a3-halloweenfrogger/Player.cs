using System;
using System.Drawing;
using System.Numerics;

namespace Game10003;

public class Player
{
    // Setting up variables 
    public Vector2 playerPosition;
    public Vector2 playerSize;
    public float playerSpeed;
    public Color color;

    // Function for drawing the playeron the board
    public void DrawPlayer()
    {
        // Draw cat
        Draw.FillColor = color;
        Draw.LineSize = 0;
        Draw.Rectangle(playerPosition, playerSize);
    }
    
    // Does Player Collide with Ghosts Row One
    public bool DoesPlayerHitRowOneGhosts(RowOneGhosts rowOneGhosts)
    {
        float playerLeft = playerPosition.X;
        float playerRight = playerPosition.X + playerSize.X;
        float playerTop = playerPosition.Y;
        float playerBottom = playerPosition.Y + playerSize.Y;

        float ghostLeft = rowOneGhosts.ghostPosition.X;
        float ghostRight = rowOneGhosts.ghostPosition.X + rowOneGhosts.ghostSize.X;
        float ghostTop = rowOneGhosts.ghostPosition.Y;
        float ghostBottom = rowOneGhosts.ghostPosition.Y + rowOneGhosts.ghostSize.Y;

        bool isWithinRowOneGhostLeftEdge = playerRight > ghostLeft;
        bool isWithinRowOneGhostRightEdge = playerLeft < ghostRight;
        bool isWithinRowOneGhostTopEdge = playerBottom > ghostTop;
        bool isWithinRowOneGhostBottomEdge = playerTop < ghostBottom;
        bool isColliding = isWithinRowOneGhostLeftEdge && isWithinRowOneGhostRightEdge && isWithinRowOneGhostTopEdge && isWithinRowOneGhostBottomEdge;

        return isColliding;
    }

    // Does Player Collide with Ghosts Row Two
    public bool DoesPlayerHitRowTwoGhosts(RowTwoGhosts rowTwoGhosts)
    {
        float playerLeft = playerPosition.X;
        float playerRight = playerPosition.X + playerSize.X;
        float playerTop = playerPosition.Y;
        float playerBottom = playerPosition.Y + playerSize.Y;

        float ghostLeft = rowTwoGhosts.ghostPosition.X;
        float ghostRight = rowTwoGhosts.ghostPosition.X + rowTwoGhosts.ghostSize.X;
        float ghostTop = rowTwoGhosts.ghostPosition.Y;
        float ghostBottom = rowTwoGhosts.ghostPosition.Y + rowTwoGhosts.ghostSize.Y;

        bool isWithinRowTwoGhostLeftEdge = playerRight > ghostLeft;
        bool isWithinRowTwoGhostRightEdge = playerLeft < ghostRight;
        bool isWithinRowTwoGhostTopEdge = playerBottom > ghostTop;
        bool isWithinRowTwoGhostBottomEdge = playerTop < ghostBottom;
        bool isColliding = isWithinRowTwoGhostLeftEdge && isWithinRowTwoGhostRightEdge && isWithinRowTwoGhostTopEdge && isWithinRowTwoGhostBottomEdge;

        return isColliding;
    }

    // Does Player Collide with Ghosts Row Three
    public bool DoesPlayerHitRowThreeGhosts(RowThreeGhosts rowThreeGhosts)
    {
        float playerLeft = playerPosition.X;
        float playerRight = playerPosition.X + playerSize.X;
        float playerTop = playerPosition.Y;
        float playerBottom = playerPosition.Y + playerSize.Y;

        float ghostLeft = rowThreeGhosts.ghostPosition.X;
        float ghostRight = rowThreeGhosts.ghostPosition.X + rowThreeGhosts.ghostSize.X;
        float ghostTop = rowThreeGhosts.ghostPosition.Y;
        float ghostBottom = rowThreeGhosts.ghostPosition.Y + rowThreeGhosts.ghostSize.Y;

        bool isWithinRowThreeGhostLeftEdge = playerRight > ghostLeft;
        bool isWithinRowThreeGhostRightEdge = playerLeft < ghostRight;
        bool isWithinRowThreeGhostTopEdge = playerBottom > ghostTop;
        bool isWithinRowThreeGhostBottomEdge = playerTop < ghostBottom;
        bool isColliding = isWithinRowThreeGhostLeftEdge && isWithinRowThreeGhostRightEdge && isWithinRowThreeGhostTopEdge && isWithinRowThreeGhostBottomEdge;

        return isColliding;
    }

    // Does Player Collide with Witch Potion Juice
    public bool DoesPlayerHitWitchPotionJuice(WitchPotionJuice witchPotionJuice)
    {
        float playerLeft = playerPosition.X;
        float playerRight = playerPosition.X + playerSize.X;
        float playerTop = playerPosition.Y;
        float playerBottom = playerPosition.Y + playerSize.Y;

        float potionLeft = witchPotionJuice.potionPosition.X;
        float potionRight = witchPotionJuice.potionPosition.X + witchPotionJuice.potionSize.X;
        float potionTop = witchPotionJuice.potionPosition.Y;
        float potionBottom = witchPotionJuice.potionPosition.Y + witchPotionJuice.potionSize.Y;

        bool isWithinWitchPotionJuiceLeftEdge = playerRight > potionLeft;
        bool isWithinWitchPotionJuiceRightEdge = playerLeft < potionRight;
        bool isWithinWitchPotionJuiceTopEdge = playerBottom > potionTop;
        bool isWithinWitchPotionJuiceBottomEdge = playerTop < potionBottom;
        bool isColliding = isWithinWitchPotionJuiceLeftEdge && isWithinWitchPotionJuiceRightEdge && isWithinWitchPotionJuiceTopEdge && isWithinWitchPotionJuiceBottomEdge;

        return isColliding;
    }

    // Does Player Collide with End Location
    public bool DoesPlayerHitEndLocation(EndLocation endLocation)
    {
        float playerLeft = playerPosition.X;
        float playerRight = playerPosition.X + playerSize.X;
        float playerTop = playerPosition.Y;
        float playerBottom = playerPosition.Y + playerSize.Y;

        float endLocationLeft = endLocation.endLocationPosition.X;
        float endLocationRight = endLocation.endLocationPosition.X + endLocation.endLocationSize.X;
        float endLocationTop = endLocation.endLocationPosition.Y;
        float endLocationBottom = endLocation.endLocationPosition.Y + endLocation.endLocationSize.Y;

        bool isWithinEndLocationLeftEdge = playerRight > endLocationLeft;
        bool isWithinEndLocationRightEdge = playerLeft < endLocationRight;
        bool isWithinEndLocationTopEdge = playerBottom > endLocationTop;
        bool isWithinEndLocationBottomEdge = playerTop < endLocationBottom;
        bool isColliding = isWithinEndLocationLeftEdge && isWithinEndLocationRightEdge && isWithinEndLocationTopEdge && isWithinEndLocationBottomEdge;

        return isColliding;
    }

    public void Move()
    {
        // Up
        if (Input.IsKeyboardKeyDown(KeyboardInput.W))
        {
            playerPosition.Y -= playerSpeed * Time.DeltaTime;
        }

        // Down
        if (Input.IsKeyboardKeyDown(KeyboardInput.S))
        {
            playerPosition.Y += playerSpeed * Time.DeltaTime;
        }

        // Left
        if (Input.IsKeyboardKeyDown(KeyboardInput.A))
        {
            playerPosition.X -= playerSpeed * Time.DeltaTime;
        }

        // Right
        if (Input.IsKeyboardKeyDown(KeyboardInput.D))
        {
            playerPosition.X += playerSpeed * Time.DeltaTime;
        }

        // Constrain player from going off screen left
        if (playerPosition.X < 0)
        {
            playerPosition.X = 0;
        }
        
        // Constrain player from going off screen right
        if (playerPosition.X > 565)
        {
            playerPosition.X = 565;
        }

        // Constrain player from going off screen top 
        if (playerPosition.Y < 0)
        {
            playerPosition.Y = 0;
        }

        // Constrain player from going off screen bottom
        if (playerPosition.Y > 765)
        {
            playerPosition.Y = 765;
        }
    }
}
