using Raylib_cs;

Raylib.InitWindow(800, 600,"Najkel");
Raylib.SetTargetFPS(60);

Rectangle bla = new Rectangle (50, 60, 50, 50);
float speed = 5f;
Rectangle blå = new Rectangle (100, 100, 100, 100);

Texture2D Gubbe = Raylib.LoadTexture("Gubbe.png");
Texture2D BlåFjäril = Raylib.LoadTexture("BlåFjäril.png");
// bool areOverlapping = Raylib.CheckCollisionRecs(bla, blå);

while (Raylib.WindowShouldClose() == false)
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

    Raylib.BeginDrawing();

    Raylib.ClearBackground(Color.PURPLE);
//  Raylib.DrawRectangleRec(bla, Color.GREEN);
    Raylib.DrawTexture(Gubbe, (int)bla.x, (int)bla.y, Color.BLACK);
    
    Raylib.DrawTexture(BlåFjäril, (int)blå.x, (int)blå.y, Color.BLACK);

    Raylib.EndDrawing();
}