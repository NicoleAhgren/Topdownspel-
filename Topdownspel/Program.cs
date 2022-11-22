using Raylib_cs;
using System.Numerics;

Raylib.InitWindow(800, 600, "Najkel");
Raylib.SetTargetFPS(60);

// Vector2 Position = new Vector2(20f, 30.5f);
// Vector2 movement = new Vector2(0.1f, 0.1f);

// Position += movement;
Color LjusGrön = new Color(53, 191, 104, 1);

Texture2D Gubbe = Raylib.LoadTexture("Gubbe.png");
Texture2D RosaFjäril = Raylib.LoadTexture("RosaFjaril.png");
Texture2D BlåFjäril = Raylib.LoadTexture("BlaFjaril.png");
Texture2D LilaFjäril = Raylib.LoadTexture("LilaFaril.png");
Texture2D Geting = Raylib.LoadTexture("Geting.png");

Rectangle bla = new Rectangle(50, 60, 50, 50);
float speed = 5f; //Bestämmer hur snabbt gubben rör sig 
Rectangle rosa = new Rectangle(600, 450, RosaFjäril.width, RosaFjäril.height);
Rectangle blabla = new Rectangle(100, 100, BlåFjäril.width, BlåFjäril.height);
Rectangle lila = new Rectangle (600, 400, LilaFjäril.width, LilaFjäril.height);
Rectangle geting = new Rectangle (250, 250, Geting.width, Geting.height);

string Level = "Start";

while (Raylib.WindowShouldClose() == false)
{
    if (Level == "Start")
    {
        if (Raylib.IsKeyPressed(KeyboardKey.KEY_ENTER)) //När man trycker ENTER startar level 1
        {
            Level = "Spel";
        }
    }

    else if (Level == "Spel")
    {
        if (Raylib.CheckCollisionRecs(bla, rosa)) //När man åker in i fjärilen så startar nästa level
        {
            Level = "Spel2";
        }
    }
    else if (Level == "Spel2")
    {
        if (Raylib.CheckCollisionRecs(bla, blabla))
        {
            Level = "Spel3";
        }
    }
    if (Level == "Spel" || Level == "Spel2" || Level == "Spel3")
    {
        if (Raylib.CheckCollisionRecs(bla, geting))
        {
            Level = "GameOver";
        }
    }
    //     else if (Level == "GameOver")
    // {
    //     if (Raylib.IsKeyPressed(KeyboardKey.KEY_SPACE)) //När man trycker SPACE startar spelet om
    //     {
    //         Level = "Start";
    //     }
    // }
    if (Level == "Spel" || Level == "Spel2" || Level == "Spel3")
    {
        if (Raylib.IsKeyDown(KeyboardKey.KEY_UP)) //Bestämmer vilken knapp du ska trycka på för att röra gubben
        {
            bla.y -= speed;
        }
        if (Raylib.IsKeyDown(KeyboardKey.KEY_DOWN))
        {
            bla.y += speed;
        }
        if (Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT))
        {
            bla.x += speed;
        }
        if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT))
        {
            bla.x -= speed;
        }
    }

    Raylib.BeginDrawing();

    if (Level == "Start")
    {
        Raylib.ClearBackground(Color.PINK);
        Raylib.DrawText("Tryck ENTER för att spela", 150, 300, 30, Color.BLACK);

    }

    if (Level == "Spel")
    {
        Raylib.ClearBackground(Color.PURPLE);
        Raylib.DrawTexture(Gubbe, (int)bla.x, (int)bla.y, Color.BLACK);
        Raylib.DrawTexture(RosaFjäril, (int)rosa.x, (int)rosa.y, Color.PINK);
        Raylib.DrawTexture(Geting, (int)geting.x, (int)geting.y, Color.YELLOW);
        
    }

    if (Level == "Spel2")
    {
        Raylib.ClearBackground(Color.PINK);
        Raylib.DrawTexture(Gubbe, (int)bla.x, (int)bla.y, Color.BLACK);
        Raylib.DrawTexture(BlåFjäril, (int)blabla.x, (int)blabla.y, Color.BLUE);

    }
    else if (Level == "Spel3")
    {
        Raylib.ClearBackground(LjusGrön);
        Raylib.DrawTexture(Gubbe, (int)bla.x, (int)bla.y, Color.BLACK);
        Raylib.DrawTexture(LilaFjäril, (int)lila.x, (int)lila.y, Color.PURPLE);
    }
    if (Level == "GameOver")
    {
        Raylib.ClearBackground(Color.BLACK);
        Raylib.DrawText("Du dog! Getingen åt upp dig!", 175, 300, 30, Color.RED);    
        // Raylib.DrawText("Du dog! Getingen åt upp dig!", 175, 250, 30, Color.RED);  
        // Raylib.DrawText("Tryck på SPACE för att spela igen", 125, 285, 30, Color.RED);            
    }


    Raylib.EndDrawing();

}




/*   
    if (Level2 = "Spel2")
    {
    Raylib.ClearBackground(Color.PINK);
    Raylib.DrawTexture(Gubbe, (int)bla.x, (int)bla.y, Color.BLACK);
    Raylib.DrawTexture(BlåFjäril, (int)blabla.x, (int)blabla.y, Color.BLUE);
    }
if (Level == "END")
    { 
    if (Raylib.IsKeyPressed(KeyboardKey.KEY_HOME))
     {
        Level = "Start";
     }
    }


        if (Level == "END")
    {
        Raylib.ClearBackground(Color.GREEN);
        Raylib.DrawText("DU VANN!", 260, 250, 50, Color.BLACK);
        Raylib.DrawText("Tryck PAUSE för att spela igen", 135, 400, 30, Color.BLACK);
    }
 */  