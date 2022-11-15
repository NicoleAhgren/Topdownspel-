using Raylib_cs;

Raylib.InitWindow(800, 600,"Najkel");
Raylib.SetTargetFPS(60);

Texture2D Gubbe = Raylib.LoadTexture("Gubbe.png");
Texture2D RosaFjäril = Raylib.LoadTexture("RosaFjaril.png");
Texture2D BlåFjäril = Raylib.LoadTexture("BlaFjaril.png");

Rectangle bla = new Rectangle (50, 60, 50, 50);
float speed = 5f;
Rectangle rosa = new Rectangle (600, 450, RosaFjäril.width, RosaFjäril.height);
Rectangle blabla = new Rectangle (100, 100, BlåFjäril.width, BlåFjäril.height);

string Level = "Start";

while (Raylib.WindowShouldClose() == false)
{
if (Level == "Start")
{
    if (Raylib.IsKeyPressed(KeyboardKey.KEY_ENTER))
    {
        Level = "Spel";
    
    }
}

if (Level == "Spel" || Level == "Spel2")
{  
    if (Raylib.IsKeyDown(KeyboardKey.KEY_UP))
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
    }
    

    if (Raylib.CheckCollisionRecs(bla, rosa)) //Något fel med den!!!! 
    //När man går bort från platsen av rosa fjärilen så börjar spelet hacka och ge epelepsianfall
    {
        Level = "Spel2";
    { 
        if (Level == "Spel2")
        {
    Raylib.ClearBackground(Color.PINK);
    Raylib.DrawTexture(Gubbe, (int)bla.x, (int)bla.y, Color.BLACK);
    Raylib.DrawTexture(BlåFjäril, (int)blabla.x, (int)blabla.y, Color.BLUE);

        }
    }
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