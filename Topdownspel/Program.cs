// Ha kvar så att två getingar jagar gubben eller gör så att det finns hinder på banan istället
// och ha endast en geting. Hinder kan vara bikupor som man dör om man råkar nudda.
// kan göra en lista på geting, gubbe och bakgrund -- (Texture2D)?? !!!!!!!

using Raylib_cs;
using System.Numerics;

Raylib.InitWindow(1000, 800, "Najkel"); // 1000 = bredden 800 = höjden
Raylib.SetTargetFPS(60);

int points = 0; // Räknar poäng och gör så att poängen börjar på 0
Color LjusGrön = new Color(53, 191, 104, 1); // min egna färg

//List <Texture2D> Avatars = new List<Texture2D>();

Texture2D Bakgrund, Gubbe, RosaFjäril, RosaFjäril2, BlåFjäril, LilaFjäril, GulFjäril, Geting, Bikupa, Bikupa2;

NewMethod(out Bakgrund, out Gubbe, out RosaFjäril, out RosaFjäril2, out BlåFjäril, out LilaFjäril, out GulFjäril, out Geting, out Bikupa, out Bikupa2);

//List <Rectangle> Avatars = new List<Rectangle>();

Rectangle background = new Rectangle(0, 0, Bakgrund.width, Bakgrund.height);
Rectangle avatar = new Rectangle(50, 600, 50, 50);
float speed = 5f; //Bestämmer hur snabbt gubben rör sig 
Rectangle rosa = new Rectangle(800, 650, RosaFjäril.width, RosaFjäril.height);
Rectangle rosa2 = new Rectangle(200, 550, RosaFjäril.width, RosaFjäril.height);
Rectangle blabla = new Rectangle(100, 100, BlåFjäril.width, BlåFjäril.height);
Rectangle lila = new Rectangle(700, 350, LilaFjäril.width, LilaFjäril.height);
Rectangle gul = new Rectangle(450, 300, GulFjäril.width, GulFjäril.height);
Rectangle geting = new Rectangle(700, 500, Geting.width, Geting.height);
//Rectangle geting2 = new Rectangle(800, 650, Geting2.width, Geting2.height);
Rectangle bikupa = new Rectangle(100, 500, Bikupa.width, Bikupa.height);
Rectangle bikupa2 = new Rectangle(300, 450, Bikupa.width, Bikupa.height);


Vector2 GetingFlyga = new Vector2(1, 0);
float GetingFart = 2f;
//Vector2 GetingFlyga2 = new Vector2 (1, 0);
//float GetingFart2 = 2f;

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
            Level = "Spel2";
            points++; // Lägger till 1 poäng när man åker in i fjärilen

        }
    }
    else if (Level == "Spel2")
    {
        if (Raylib.CheckCollisionRecs(avatar, blabla))
        {
            Level = "Spel3";
            points++;
        }
    }
    else if (Level == "Spel3")
    {
        if (Raylib.CheckCollisionRecs(avatar, lila))
        {
            Level = "Spel4";
            points++;
        }
    }
    else if (Level == "Spel4")
    {
        if (Raylib.CheckCollisionRecs(avatar, gul))
        {
            Level = "Spel5";
            points++;
        }
    }
    if (Level == "GameOver")
    {
        if (Raylib.IsKeyPressed(KeyboardKey.KEY_SPACE))
        {

            Level = "Start";
        }
    }

    if (Level == "Spel" || Level == "Spel2" || Level == "Spel3" || Level == "Spel4" || Level == "Spel5")
    {
        if (Raylib.CheckCollisionRecs(avatar, geting))
        {
            Level = "GameOver"; // Spelet slutar när getingen åker in i dig
        }
    }
    if (Level == "Spel4" || Level == "Spel5")
    {
        if (Raylib.CheckCollisionRecs(avatar, bikupa))
        {
            Level = "GameOver";
        }
    }
    if (Level == "Spel5")
    {
        if (Raylib.CheckCollisionRecs(avatar, bikupa2))
        {
            Level = "GameOver";
        }
        if (Raylib.CheckCollisionRecs(avatar, rosa2))
        {
            Level = "Winner";
            points++;
        }
    }

    if (Level == "Spel" || Level == "Spel2" || Level == "Spel3" || Level == "Spel4" || Level == "Spel5")
    {
        Vector2 playerMovement = new Vector2();


        if (Raylib.IsKeyDown(KeyboardKey.KEY_UP) || Raylib.IsKeyDown(KeyboardKey.KEY_W)) //Bestämmer vilken knapp du ska trycka på för att röra gubben
        {
            playerMovement.Y = -speed;
        }
        if (Raylib.IsKeyDown(KeyboardKey.KEY_DOWN) || Raylib.IsKeyDown(KeyboardKey.KEY_S))
        {
            playerMovement.Y = +speed;
            // avatar.y += speed;
        }
        if (Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT) || Raylib.IsKeyDown(KeyboardKey.KEY_D))
        {
            playerMovement.X = +speed;
        }
        if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT) || Raylib.IsKeyDown(KeyboardKey.KEY_A))
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

        // [ Denna kod under är tagen från facit, koden om vector2 ]

        Vector2 GubbePosition = new Vector2(avatar.x, avatar.y); //skapar en vector för gubbens postion
        Vector2 GetingPosition = new Vector2(geting.x, geting.y);
        //Vector2 GetingPosition2 = new Vector2(geting2.x, geting2.y);

        Vector2 hej = GubbePosition - GetingPosition; //Gör så att getingen följer efter gubben
        Vector2 Getingbla = Vector2.Normalize(hej);
        //Vector2 Hej = GubbePosition - GetingPosition2;
        //Vector2 Getingbla2 = Vector2.Normalize(Hej);


        GetingFlyga = Getingbla * GetingFart;
        //GetingFlyga2 = Getingbla * GetingFart2;

        geting.x += GetingFlyga.X;
        geting.y += GetingFlyga.Y;

        //geting2.x += GetingFlyga2.X;
        //geting2.y += GetingFlyga2.Y;
    }

    Raylib.BeginDrawing();

    if (Level == "Start")
    {
        Raylib.ClearBackground(Color.PINK);
        Raylib.DrawText("Tryck ENTER för att spela", 275, 400, 30, Color.BLACK);

    }

    if (Level == "Spel")
    {
        Raylib.ClearBackground(Color.WHITE);
        Raylib.DrawTexture(Bakgrund, (int)background.x, (int)background.y, Color.WHITE); //Ritar ut bakgrund
        Raylib.DrawTexture(Gubbe, (int)avatar.x, (int)avatar.y, Color.BLACK); // Ritar ut avatar
        Raylib.DrawTexture(RosaFjäril, (int)rosa.x, (int)rosa.y, Color.PINK); // Ritar ut fjäril
        Raylib.DrawTexture(Geting, (int)geting.x, (int)geting.y, Color.WHITE); // Ritar ut geting
        Raylib.DrawText(points.ToString(), 50, 50, 50, Color.BLACK); // skriver ut hur många poäng man har
    }

    if (Level == "Spel2")
    {
        Raylib.ClearBackground(Color.WHITE);
        Raylib.DrawTexture(Bakgrund, (int)background.x, (int)background.y, Color.WHITE);
        Raylib.DrawTexture(Gubbe, (int)avatar.x, (int)avatar.y, Color.BLACK);
        Raylib.DrawTexture(BlåFjäril, (int)blabla.x, (int)blabla.y, Color.BLUE);
        Raylib.DrawTexture(Geting, (int)geting.x, (int)geting.y, Color.WHITE);
        Raylib.DrawText(points.ToString(), 50, 50, 50, Color.BLACK);

    }
    if (Level == "Spel3")
    {
        Raylib.ClearBackground(Color.WHITE);
        Raylib.DrawTexture(Bakgrund, (int)background.x, (int)background.y, Color.WHITE);
        Raylib.DrawTexture(Gubbe, (int)avatar.x, (int)avatar.y, Color.BLACK);
        Raylib.DrawTexture(LilaFjäril, (int)lila.x, (int)lila.y, Color.PURPLE);
        Raylib.DrawTexture(Geting, (int)geting.x, (int)geting.y, Color.WHITE);
        Raylib.DrawText(points.ToString(), 50, 50, 50, Color.BLACK);
    }
    if (Level == "Spel4")
    {
        Raylib.ClearBackground(Color.WHITE);
        Raylib.DrawTexture(Bakgrund, (int)background.x, (int)background.y, Color.WHITE);
        Raylib.DrawTexture(Gubbe, (int)avatar.x, (int)avatar.y, Color.BLACK);
        Raylib.DrawTexture(GulFjäril, (int)gul.x, (int)gul.y, Color.YELLOW);
        Raylib.DrawTexture(Geting, (int)geting.x, (int)geting.y, Color.WHITE);
        Raylib.DrawTexture(Bikupa, (int)bikupa.x, (int)bikupa.y, Color.WHITE);
        Raylib.DrawText(points.ToString(), 50, 50, 50, Color.BLACK);
        //Raylib.DrawTexture(Geting2, (int)geting2.x, (int)geting2.y, Color.WHITE);      
    }
    if (Level == "Spel5") // om man klarar denhär leveln så vinner man eller nåt
    {
        Raylib.ClearBackground(Color.WHITE);
        Raylib.DrawTexture(Bakgrund, (int)background.x, (int)background.y, Color.WHITE);
        Raylib.DrawTexture(Gubbe, (int)avatar.x, (int)avatar.y, Color.BLACK);
        Raylib.DrawTexture(RosaFjäril2, (int)rosa2.x, (int)rosa2.y, Color.PINK);
        Raylib.DrawTexture(Geting, (int)geting.x, (int)geting.y, Color.WHITE);
        Raylib.DrawTexture(Bikupa, (int)bikupa.x, (int)bikupa.y, Color.WHITE);
        Raylib.DrawTexture(Bikupa2, (int)bikupa2.x, (int)bikupa2.y, Color.WHITE);
        Raylib.DrawText(points.ToString(), 50, 50, 50, Color.BLACK);
    }


    if (Level == "GameOver")
    {
        Raylib.ClearBackground(Color.BLACK);
        Raylib.DrawText("Du dog! Getingen åt upp dig!", 250, 300, 30, Color.RED);
        Raylib.DrawText("Du fick: " + points + " Poäng", 350, 350, 30, Color.RED);
        Raylib.DrawText("Tryck SPACE för att spela igen", 250, 400, 30, Color.RED);


        // Raylib.DrawText("Tryck på SPACE för att spela igen", 125, 285, 30, Color.RED);            
    }
    if (Level == "Winner")
    {
        Raylib.ClearBackground(Color.PURPLE);
        Raylib.DrawText("Grattis du vann!", 350, 350, 30, Color.BLACK);
        Raylib.DrawText("Du fick: " + points + " Poäng", 350, 400, 30, Color.BLACK);

    }

    Raylib.EndDrawing();

}

static void NewMethod(out Texture2D Bakgrund, out Texture2D Gubbe, out Texture2D RosaFjäril, out Texture2D RosaFjäril2, out Texture2D BlåFjäril, out Texture2D LilaFjäril, out Texture2D GulFjäril, out Texture2D Geting, out Texture2D Bikupa, out Texture2D Bikupa2)
{
    Bakgrund = Raylib.LoadTexture("Bakgrund.png");
    Gubbe = Raylib.LoadTexture("Gubbe.png");
    RosaFjäril = Raylib.LoadTexture("RosaFjaril.png");
    RosaFjäril2 = Raylib.LoadTexture("RosaFjaril.png");
    BlåFjäril = Raylib.LoadTexture("BlaFjaril.png");
    LilaFjäril = Raylib.LoadTexture("LilaFaril.png");
    GulFjäril = Raylib.LoadTexture("GulFjaril.png");
    Geting = Raylib.LoadTexture("Geting.png");
    //Texture2D Geting2 = Raylib.LoadTexture("Geting2.png");
    Bikupa = Raylib.LoadTexture("Bikupa2.png");
    Bikupa2 = Raylib.LoadTexture("Bikupa2.png");
}


// Texture2D Bakgrund = Raylib.LoadTexture("Bakgrund.png");
// Texture2D Gubbe = Raylib.LoadTexture("Gubbe.png");
// Texture2D RosaFjäril = Raylib.LoadTexture("RosaFjaril.png");
// Texture2D RosaFjäril2 = Raylib.LoadTexture("RosaFjaril.png");
// Texture2D BlåFjäril = Raylib.LoadTexture("BlaFjaril.png");
// Texture2D LilaFjäril = Raylib.LoadTexture("LilaFaril.png");
// Texture2D GulFjäril = Raylib.LoadTexture("GulFjaril.png");
// Texture2D Geting = Raylib.LoadTexture("Geting.png");
// //Texture2D Geting2 = Raylib.LoadTexture("Geting2.png");
// Texture2D Bikupa = Raylib.LoadTexture("Bikupa2.png");
// Texture2D Bikupa2 = Raylib.LoadTexture("Bikupa2.png");




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