/*
 * Name: Ciaran McIlvaney
 * Date: October 30th 2024
 */

using Game1000;
using System;
using System.Numerics;

namespace Game10003;

public class Game
{
    // Setting up colors 
    Color catColor = new Color(0x00, 0x01, 0x43);
    Color roadBackground = new Color(0x10, 0x08, 0x20);
    Color ghostsColor = new Color(0xf0, 0xf8, 0xe0);
    Color safeZone = new Color(0xa2, 0x2f, 0xc9);
    Color candyBarOneAndThreeColor = new Color(0xad, 0x0b, 0x42);
    Color candyBarTwoColor = new Color(0x87, 0x67, 0xbd);
    Color endLocationColor = new Color(0xff, 0x8b, 0x40);
    Color witchPotionJuiceColor = new Color(0x0a, 0x77, 0x7a);
    Color gameOverBackgroundColor = new Color(0x96, 0x00, 0x88);
    Color winBackgroundColor = new Color(0x2f, 0xa7, 0x1c);

    // Calling classes
    Player player = new Player();
    RowOneGhosts[] ghostsRowOne = new RowOneGhosts[6];
    RowTwoGhosts[] ghostsRowTwo = new RowTwoGhosts[6];
    RowThreeGhosts[] ghostsRowThree = new RowThreeGhosts[6];
    WitchPotionJuice witchPotionJuice = new WitchPotionJuice();
    RowOneCandyBar candyBarRowOne = new RowOneCandyBar();
    RowTwoCandyBar candyBarOneRowTwo = new RowTwoCandyBar();
    RowTwoCandyBar candyBarTwoRowTwo = new RowTwoCandyBar();
    RowThreeCandyBar candyBarRowThree = new RowThreeCandyBar();
    EndLocation endLocation = new EndLocation();

    // Game state flags
    bool isGameOver = false;
    bool isWin = false;

    public void Setup()
    {
        // Reset game state flags
        isGameOver = false;
        isWin = false;

        // Set up window screen size and title 
        Window.SetTitle("Halloween Frogger");
        Window.SetSize(600, 800);

        // Player starting position
        player.playerPosition.X = Window.Width / 2;
        player.playerPosition.Y = 750;
        player.playerSize = Vector2.One * 35;
        player.playerSpeed = 150;
        player.color = catColor;

        // Draw witch potion juice position
        witchPotionJuice.potionPosition.X = 0;
        witchPotionJuice.potionPosition.Y = 90;
        witchPotionJuice.potionSize = new Vector2(600, 280);
        witchPotionJuice.color = witchPotionJuiceColor;

        // Draw row one candy bar positom
        candyBarRowOne.candyBarPosition.X = 150;
        candyBarRowOne.candyBarPosition.Y = 290;
        candyBarRowOne.candyBarSize = new Vector2(300, 80);
        candyBarRowOne.color = candyBarOneAndThreeColor;

        Vector2 rowTwoCandyBarSize = new Vector2(200, 100);
        // Draw row two candy bar one position
        candyBarOneRowTwo.candyBarPosition.X = 50;
        candyBarOneRowTwo.candyBarPosition.Y = 190;
        candyBarOneRowTwo.candyBarSize = rowTwoCandyBarSize;
        candyBarOneRowTwo.color = candyBarTwoColor;
        // Draw row two candy bar one position
        candyBarTwoRowTwo.candyBarPosition.X = 350;
        candyBarTwoRowTwo.candyBarPosition.Y = 190;
        candyBarTwoRowTwo.candyBarSize = rowTwoCandyBarSize;
        candyBarTwoRowTwo.color = candyBarTwoColor;

        // Draw row three candy bar position
        candyBarRowThree.candyBarPosition.X = 150;
        candyBarRowThree.candyBarPosition.Y = 90;
        candyBarRowThree.candyBarSize = new Vector2(280, 100);
        candyBarRowThree.color = candyBarOneAndThreeColor;

        // Draw end location 
        endLocation.endLocationPosition.X = 0;
        endLocation.endLocationPosition.Y = 0;
        endLocation.endLocationSize = new Vector2(600, 90);
        endLocation.color = endLocationColor;

        // Set up row one of ghosts 
        for (int i = 0; i < ghostsRowOne.Length; i++)
        {
            RowOneGhosts ghostRowOne = new RowOneGhosts();
            ghostRowOne.color = ghostsColor;
            ghostRowOne.ghostSize = new Vector2(100, 30);
            ghostRowOne.ghostPosition.X = Random.Float(0, 600);
            ghostRowOne.ghostPosition.Y = 660;
            ghostsRowOne[i] = ghostRowOne;
        }

        // Set up row two of ghosts 
        for (int i = 0; i < ghostsRowTwo.Length; i++)
        {
            RowTwoGhosts ghostRowTwo = new RowTwoGhosts();
            ghostRowTwo.color = ghostsColor;
            ghostRowTwo.ghostSize = new Vector2(100, 30);
            ghostRowTwo.ghostPosition.X = Random.Float(0, 600);
            ghostRowTwo.ghostPosition.Y = 560;
            ghostsRowTwo[i] = ghostRowTwo;
        }

        // Set up row three of ghosts 
        for (int i = 0; i < ghostsRowThree.Length; i++)
        {
            RowThreeGhosts ghostRowThree = new RowThreeGhosts();
            ghostRowThree.color = ghostsColor;
            ghostRowThree.ghostSize = new Vector2(100, 30);
            ghostRowThree.ghostPosition.X = Random.Float(0, 600);
            ghostRowThree.ghostPosition.Y = 460;
            ghostsRowThree[i] = ghostRowThree;
        }
    }

    public void Update()
    {
        // If isGameOver equals true display game over screen 
        if (isGameOver)
        {
            DrawGameOver();
            // If player presses space reset game
            if (Input.IsKeyboardKeyDown(KeyboardInput.Space))
            {
                Setup(); // Reset game on space bar press
            }
            return; // Stop any further code from running in update
        }

        // If isWin equals true display win screemn
        if (isWin)
        {
            DrawWin();
            // If player presses space reset the game
            if (Input.IsKeyboardKeyDown(KeyboardInput.Space))
            {
                Setup(); // Reset game on space bar press
            }
            return; // Stop any further code from running in update
        }
       
        // Safe Zone One
        Draw.FillColor = safeZone;
        Draw.LineSize = 0;
        Draw.Rectangle(0, 740, 600, 60);
        // Safe Zone Two 
        Draw.FillColor = safeZone;
        Draw.LineSize = 0;
        Draw.Rectangle(0, 370, 600, 60);

        // Draw Road
        Draw.FillColor = roadBackground;
        Draw.LineSize = 0;
        Draw.Rectangle(0, 430, 600, 310);

        // Draw the ghosts as many times there are in the array
        for (int i = 0; i < ghostsRowOne.Length; i++)
        {
            // Bools for each row collision detection
            bool doesRowOneGhostHitPlayer = player.DoesPlayerHitRowOneGhosts(ghostsRowOne[i]);
            bool doesRowTwoGhostHitPlayer = player.DoesPlayerHitRowTwoGhosts(ghostsRowTwo[i]);
            bool doesRowThreeGhostHitPlayer = player.DoesPlayerHitRowThreeGhosts(ghostsRowThree[i]);

            // If player hits any of these objects make isGameOver equal to true
            if (doesRowOneGhostHitPlayer || doesRowTwoGhostHitPlayer || doesRowThreeGhostHitPlayer)
            {
                isGameOver = true;
                return; // Stop any further code from running in update
            }

            // Draws and moves ghosts from row one
            ghostsRowOne[i].DrawGhosts();
            ghostsRowOne[i].Move();

            // Draws and moves ghosts from row two
            ghostsRowTwo[i].DrawGhosts();
            ghostsRowTwo[i].Move();

            // Draws and moves ghosts from row three
            ghostsRowThree[i].DrawGhosts();
            ghostsRowThree[i].Move();
        }

        // If player hits witchPotionJuice make isGameOver equal to true
        bool doesWitchPotionJuiceHitPlayer = player.DoesPlayerHitWitchPotionJuice(witchPotionJuice);
        if (doesWitchPotionJuiceHitPlayer)
        {
            isGameOver = true;
            return; // Stop any further code from running in update
        }
        // Draw potion juice
        witchPotionJuice.DrawPotionJuice();

        // Draw and moves candy bar from row one
        candyBarRowOne.DrawCandyBar();
        candyBarRowOne.Move();

        // Draw and moves candy bars from row two
        candyBarOneRowTwo.DrawCandyBar();
        candyBarOneRowTwo.Move();
        candyBarTwoRowTwo.DrawCandyBar();
        candyBarTwoRowTwo.Move();

        // Draws and moves candy bar from row three
        candyBarRowThree.DrawCandyBar();
        candyBarRowThree.Move();

        // If player hits endLocation make isWin equal to true
        bool doesEndLocationHitPlayer = player.DoesPlayerHitEndLocation(endLocation);
        if (doesEndLocationHitPlayer)
        {
            isWin = true;
            return; // Stop any further code from running in update
        }
        // Draw end location
        endLocation.DrawEndLocation();

        // Draw and move player
        player.DrawPlayer();
        player.Move();
    }

    // Function for game over display
    void DrawGameOver()
    {
        Window.ClearBackground(gameOverBackgroundColor);
        Text.Size = 100;
        Text.Color = Color.Black;
        Text.Draw("Game Over!", 50, 200);
        Text.Size = 40;
        Text.Draw("Press SPACE to restart", 65, 300);
    }

    // Function for win display
    void DrawWin()
    {
        Window.ClearBackground(winBackgroundColor);
        Text.Size = 100;
        Text.Color = Color.White;
        Text.Draw("You Win!", 85, 200);
        Text.Size = 40;
        Text.Draw("Press SPACE to restart", 65, 300);
    }
}