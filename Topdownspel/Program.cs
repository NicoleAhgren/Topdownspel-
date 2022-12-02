using Raylib_cs;
using System.Numerics;


Raylib.InitWindow(1000, 800, "Najkel");
Raylib.SetTargetFPS(60);

// Vector2 Position = new Vector2(20f, 30.5f);
// Vector2 movement = new Vector2(0.1f, 0.1f);

// Position += movement;
int points = 0;
String Points = Convert.ToString(points);
//SByte Points = Convert.ToSByte(points);
Color LjusGrön = new Color(53, 191, 104, 1);

Texture2D Bakgrund = Raylib.LoadTexture("Bakgrund.png");
Texture2D Gubbe = Raylib.LoadTexture("Gubbe.png");
Texture2D RosaFjäril = Raylib.LoadTexture("RosaFjaril.png");
Texture2D BlåFjäril = Raylib.LoadTexture("BlaFjaril.png");
Texture2D LilaFjäril = Raylib.LoadTexture("LilaFaril.png");
Texture2D Geting = Raylib.LoadTexture("Geting.png");

Rectangle background = new Rectangle(0, 0, Bakgrund.width, Bakgrund.height);
Rectangle avatar = new Rectangle(50, 600, 50, 50);
float speed = 5f; //Bestämmer hur snabbt gubben rör sig 
Rectangle rosa = new Rectangle(800, 650, RosaFjäril.width, RosaFjäril.height);
Rectangle blabla = new Rectangle(100, 100, BlåFjäril.width, BlåFjäril.height);
Rectangle lila = new Rectangle(700, 350, LilaFjäril.width, LilaFjäril.height);
Rectangle geting = new Rectangle(700, 500, Geting.width, Geting.height);

Vector2 GetingFlyga = new Vector2(1, 0);
float GetingFart = 2f;

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
        if (Raylib.CheckCollisionRecs(avatar, rosa)) //När man åker in i fjärilen så startar nästa level
        {
            points ++;
            Level = "Spel2";
            
        }
    }
    else if (Level == "Spel2")
    {
        if (Raylib.CheckCollisionRecs(avatar, blabla))
        {
            Level = "Spel3";
            points ++;
        }
    }
    if (Level == "Spel" || Level == "Spel2" || Level == "Spel3")
    {
        if (Raylib.CheckCollisionRecs(avatar, geting))
        {
            Level = "GameOver";
        }
    }

    if (Level == "Spel" || Level == "Spel2" || Level == "Spel3")
    {
        Vector2 playerMovement = new Vector2();
    

        if (Raylib.IsKeyDown(KeyboardKey.KEY_UP)) //Bestämmer vilken knapp du ska trycka på för att röra gubben
        {
            playerMovement.Y = -speed;
        }
        if (Raylib.IsKeyDown(KeyboardKey.KEY_DOWN))
        {
            playerMovement.Y = +speed;
            // avatar.y += speed;
        }
        if (Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT))
        {
            playerMovement.X = +speed;
        }
        if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT))
        {
            playerMovement.X = -speed;
        }

        avatar.x += playerMovement.X;
        avatar.y += playerMovement.Y;
        //gör så att gubben inte kan gå utanför skärmen
        if (avatar.x < 0 || avatar.x > Raylib.GetScreenWidth() - avatar.width)
        {
            avatar.x -= playerMovement.X;
        }
        if (avatar.y < 0 || avatar.y > Raylib.GetScreenHeight() - avatar.height)
        {
        avatar.y -= playerMovement.Y;
        }

        Vector2 GubbePosition = new Vector2(avatar.x, avatar.y); //skapar en vector för gubbens postion
        Vector2 GetingPosition = new Vector2(geting.x, geting.y);

        Vector2 hej = GubbePosition - GetingPosition; //Gör så att getingen följer efter gubben
        Vector2 Getingbla = Vector2.Normalize(hej);

        GetingFlyga = Getingbla * GetingFart;

        geting.x += GetingFlyga.X;
        geting.y += GetingFlyga.Y;
    }

    Raylib.BeginDrawing();
    if (Level == "Spel" || Level == "Spel2" || Level == "Spel3")
    {
        Raylib.DrawText(Points, 50, 50, 50, Color.BLACK);
    }
    if (Level == "Start")
    {
        Raylib.ClearBackground(Color.PINK);
        Raylib.DrawText("Tryck ENTER för att spela", 150, 300, 30, Color.BLACK);

    }

    if (Level == "Spel")
    {
        Raylib.ClearBackground(Color.WHITE);
        Raylib.DrawTexture(Bakgrund, (int)background.x, (int)background.y, Color.WHITE);
        Raylib.DrawTexture(Gubbe, (int)avatar.x, (int)avatar.y, Color.BLACK);
        Raylib.DrawTexture(RosaFjäril, (int)rosa.x, (int)rosa.y, Color.PINK);
        Raylib.DrawTexture(Geting, (int)geting.x, (int)geting.y, Color.WHITE);
        //Raylib.DrawText(Raylib.TextFormat(), 50, 50, 50, Color.BLACK);
        //Raylib.DrawText((Points* Points*), 20, 20, 40, Color.BLACK);
        Raylib.DrawText(Points, 50, 50, 50, Color.BLACK);
    }

    if (Level == "Spel2")
    {
        Raylib.ClearBackground(Color.WHITE);
        Raylib.DrawTexture(Bakgrund, (int)background.x, (int)background.y, Color.WHITE);
        Raylib.DrawTexture(Gubbe, (int)avatar.x, (int)avatar.y, Color.BLACK);
        Raylib.DrawTexture(BlåFjäril, (int)blabla.x, (int)blabla.y, Color.BLUE);
        Raylib.DrawTexture(Geting, (int)geting.x, (int)geting.y, Color.WHITE);
        Raylib.DrawText(Points, 50, 50, 50, Color.BLACK);

    }
    else if (Level == "Spel3")
    {
        Raylib.ClearBackground(Color.WHITE);
        Raylib.DrawTexture(Bakgrund, (int)background.x, (int)background.y, Color.WHITE);
        Raylib.DrawTexture(Gubbe, (int)avatar.x, (int)avatar.y, Color.BLACK);
        Raylib.DrawTexture(LilaFjäril, (int)lila.x, (int)lila.y, Color.PURPLE);
        Raylib.DrawTexture(Geting, (int)geting.x, (int)geting.y, Color.WHITE);
        Raylib.DrawText(Points, 50, 50, 50, Color.BLACK);
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