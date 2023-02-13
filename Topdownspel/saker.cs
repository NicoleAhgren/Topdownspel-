using System;
using Raylib_cs;

namespace Topdownspel;

public class saker
{
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
}
