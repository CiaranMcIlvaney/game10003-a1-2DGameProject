/*
 * Name: Ciaran McIlvaney
 * Date: October 30th 2024
 */

using System;
using System.Numerics;

// The namespace your code is in.
namespace Game10003
{
    public class Game
    {
        // Setting up colors 
        Color cat = new Color(0x00, 0x01, 0x43);
        Color roadBackground = new Color(0x10, 0x08, 0x20);
        Color ghosts = new Color(0xf0, 0xf8, 0xe0);
        Color safeZone = new Color(0xa2, 0x2f, 0xc9);
        Color candyBarOneAndTwoOutside = new Color(0xad, 0x0b, 0x42);
        Color candyBarOneAndTwoInside = new Color(0xf4, 0xd0, 0xa7);                                
        Color candyBarTwoOutside = new Color(0x87, 0x67, 0xbd);
        Color candyBarTwoInside = new Color(0xff, 0xd5, 0x80);
        Color endingArea = new Color(0xff, 0x8b, 0x40);
        Color witchPotionJuice = new Color(0x0a, 0x77, 0x7a);

        public void Setup()
        {
            Window.SetTitle("Halloween Frogger");
            Window.SetSize(600, 800);
        }
 
        public void Update()
        {
            Window.ClearBackground(Color.OffWhite);

            // Draw Safe Zones
            // Safe Zone One
            Draw.FillColor = safeZone;
            Draw.LineSize = 0;
            Draw.Rectangle(0, 740, 600, 60);
            // Safe Zone Two 
            Draw.FillColor = safeZone;
            Draw.LineSize = 0;
            Draw.Rectangle(0,370,600,60);

            // Draw Road
            Draw.FillColor = roadBackground;
            Draw.LineSize = 0;
            Draw.Rectangle(0, 430, 600, 310);

            //Draw Witch Potion Juice Area
            Draw.FillColor = witchPotionJuice;
            Draw.LineSize = 0;
            Draw.Rectangle(0, 90, 600, 280);

            // Draw Win Area 
            Draw.FillColor = endingArea;
            Draw.LineSize = 0;
            Draw.Rectangle(0, 0, 600, 90);

            // Draw cat
            Draw.FillColor = cat;
            Draw.LineSize = 0;
            Draw.Ellipse(300, 785, 20, 30); // Body
            Draw.Ellipse(300, 760, 20, 20); // Head

            // Draw Ghosts 
            // Line 1 Ghost 1
            Draw.FillColor = ghosts;
            Draw.LineSize = 0;
            Draw.Rectangle(480, 460, 100, 30);
            Draw.Circle(480, 475, 15);
            Draw.Triangle(580, 460, 580, 470, 590, 465);
            Draw.Triangle(580, 470, 580, 480, 590, 475);
            Draw.Triangle(580, 480, 580, 490, 590, 485);

            // Line 1 Ghost 2
            Draw.FillColor = ghosts;
            Draw.LineSize = 0;
            Draw.Rectangle(120, 460, 100, 30);
            Draw.Circle(120, 475, 15);
            Draw.Triangle(220, 460, 220, 470, 230, 465);
            Draw.Triangle(220, 470, 220, 480, 230, 475);
            Draw.Triangle(220, 480, 220, 490, 230, 485);

            // Line 2 Ghost 1
            Draw.FillColor = ghosts;
            Draw.LineSize = 0;
            Draw.Rectangle(180, 560, 100, 30);
            Draw.Circle(280, 575, 15);
            Draw.Triangle(180, 560, 180, 570, 170, 565);
            Draw.Triangle(180, 570, 180, 580, 170, 575);
            Draw.Triangle(180, 580, 180, 590, 170, 585);

            // Line 2 Ghost 2
            Draw.FillColor = ghosts;
            Draw.LineSize = 0;
            Draw.Rectangle(410,560,100,30);
            Draw.Circle(510,575,15);
            Draw.Triangle(410, 560, 410, 570, 400, 565);
            Draw.Triangle(410, 570, 410, 580, 400, 575);
            Draw.Triangle(410, 580, 410, 590, 400, 585);

            // Line 3 Ghost 1
            Draw.FillColor = ghosts;
            Draw.LineSize = 0;
            Draw.Rectangle(370,660,100,30);
            Draw.Circle(370, 675, 15);
            Draw.Triangle(470, 660, 470, 670, 480, 665);
            Draw.Triangle(470, 670, 470, 680, 480, 675);
            Draw.Triangle(470, 680, 470, 690, 480, 685);

            // Line 3 Ghost 2 
            Draw.FillColor = ghosts;
            Draw.LineSize = 0;
            Draw.Rectangle(80, 660, 100, 30);
            Draw.Circle(80, 675, 15);
            Draw.Triangle(180, 660, 180, 670, 190, 665);
            Draw.Triangle(180, 670, 180, 680, 190, 675);
            Draw.Triangle(180, 680, 180, 690, 190, 685);

            // Draw Candy Bars
            // Line 1 Candy Bar 
            Draw.FillColor = candyBarOneAndTwoOutside;
            Draw.LineSize = 0;
            Draw.Rectangle(150, 290, 300, 80);
            Draw.Triangle(150, 290, 150, 310, 130, 300);
            Draw.Triangle(150, 310, 150, 330, 130, 320);
            Draw.Triangle(150, 330, 150, 350, 130, 340);
            Draw.Triangle(150, 350, 150, 370, 130, 360);
            Draw.Triangle(450, 290, 450, 310, 470, 300);
            Draw.Triangle(450, 310, 450, 330, 470, 320);
            Draw.Triangle(450, 330, 450, 350, 470, 340);
            Draw.Triangle(450, 350, 450, 370, 470, 360);
            Draw.FillColor = candyBarOneAndTwoInside;
            Draw.LineSize = 0;
            Draw.Rectangle(200, 310, 200, 40);

            // Line 2 Candy bar 1
            Draw.FillColor = candyBarTwoOutside;
            Draw.LineSize = 0;
            Draw.Rectangle(50, 190, 200, 100);
            Draw.Triangle(50, 190, 50, 210, 30, 200);
            Draw.Triangle(50, 210, 50, 230, 30, 220);
            Draw.Triangle(50, 230, 50, 250, 30, 240);
            Draw.Triangle(50, 250, 50, 270, 30, 260);
            Draw.Triangle(50, 270, 50, 290, 30, 280);
            Draw.Triangle(250, 190, 250, 210, 270, 200);
            Draw.Triangle(250, 210, 250, 230, 270, 220);
            Draw.Triangle(250, 230, 250, 250, 270, 240);
            Draw.Triangle(250, 250, 250, 270, 270, 260);
            Draw.Triangle(250, 270, 250, 290, 270, 280);
            Draw.FillColor = candyBarTwoInside;
            Draw.LineSize = 0;
            Draw.Rectangle(80, 220, 140, 40);

            // Line 2 Candy bar 2
            Draw.FillColor = candyBarTwoOutside;
            Draw.LineSize = 0;
            Draw.Rectangle(350, 190, 200, 100);
            Draw.Triangle(350, 190, 350, 210, 330, 200);
            Draw.Triangle(350, 210, 350, 230, 330, 220);
            Draw.Triangle(350, 230, 350, 250, 330, 240);
            Draw.Triangle(350, 250, 350, 270, 330, 260);
            Draw.Triangle(350, 270, 350, 290, 330, 280);
            Draw.Triangle(550, 190, 550, 210, 570, 200);
            Draw.Triangle(550, 210, 550, 230, 570, 220);
            Draw.Triangle(550, 230, 550, 250, 570, 240);
            Draw.Triangle(550, 250, 550, 270, 570, 260);
            Draw.Triangle(550, 270, 550, 290, 570, 280);
            Draw.FillColor = candyBarTwoInside;
            Draw.LineSize = 0;
            Draw.Rectangle(380, 220, 140, 40);

            // Line 3 Candy Bar
            Draw.FillColor = candyBarOneAndTwoOutside;
            Draw.LineSize = 0;
            Draw.Rectangle(20,90,280,100);
            Draw.Triangle(20,90,20,110,0,100);
            Draw.Triangle(20, 110, 20, 130, 0, 120);
            Draw.Triangle(20, 130, 20, 150, 0, 140);
            Draw.Triangle(20, 150, 20, 170, 0, 160);
            Draw.Triangle(20, 170, 20, 190, 0, 180);
            Draw.Triangle(300, 90, 300, 110, 320, 100);
            Draw.Triangle(300, 110, 300, 130, 320, 120);
            Draw.Triangle(300, 130, 300, 150, 320, 140);
            Draw.Triangle(300, 150, 300, 170, 320, 160);
            Draw.Triangle(300, 170, 300, 190, 320, 180);
            Draw.FillColor = candyBarOneAndTwoInside;
            Draw.LineSize = 0;
            Draw.Rectangle(50, 120, 220, 40);



        }
    }
}
