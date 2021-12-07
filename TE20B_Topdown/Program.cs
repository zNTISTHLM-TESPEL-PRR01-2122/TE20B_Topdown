using System;
using System.Numerics;
using Raylib_cs;

Raylib.InitWindow(800, 600, "2D-topdown game");
Raylib.SetTargetFPS(60);

float speed = 2.3f;
Vector2 textPos = new Vector2(50, 25);

Texture2D playerImage = Raylib.LoadTexture("happy.png");
Rectangle playerRect = new Rectangle(100, 70, playerImage.width, playerImage.height);

Font comic = Raylib.LoadFont("ComicNeue.ttf");
Rectangle doorRect = new Rectangle(200, 200, 32, 32);

string level = "start";

while (!Raylib.WindowShouldClose())
{
  if (level == "start" || level == "corridor")
  {
    playerRect = ReadMovement(playerRect, speed);
  }

  if (level == "start")
  {
    if (Raylib.CheckCollisionRecs(playerRect, doorRect))
    {
      level = "end";
    }
    if (playerRect.x > 800)
    {
      level = "corridor";
      playerRect.x = 0;
    }
  }
  else if (level == "corridor")
  {
    if (playerRect.x < 0)
    {
      level = "start";
      playerRect.x = 800 - playerRect.width;
    }
  }

  Raylib.BeginDrawing();

  // Raylib.DrawText(playerRect.x.ToString(), 100, 100, 40, Color.DARKBLUE);
  Raylib.DrawTextEx(comic, "HEJ", textPos, 80, 0, Color.BEIGE);

  if (level == "start")
  {
    Raylib.ClearBackground(Color.BLUE);
    Raylib.DrawRectangleRec(doorRect, Color.BLACK);
  }
  else if (level == "end")
  {
    Raylib.ClearBackground(Color.PINK);
  }
  else if (level == "corridor")
  {
    Raylib.ClearBackground(Color.YELLOW);
  }

  if (level == "start" || level == "corridor")
  {
    Raylib.DrawTexture(playerImage, (int)playerRect.x, (int)playerRect.y, Color.WHITE);
  }


  Raylib.EndDrawing();
}


static Rectangle ReadMovement(Rectangle playerRect, float speed)
{
  if (Raylib.IsKeyDown(KeyboardKey.KEY_W)) playerRect.y -= speed;
  if (Raylib.IsKeyDown(KeyboardKey.KEY_S)) playerRect.y += speed;
  if (Raylib.IsKeyDown(KeyboardKey.KEY_A)) playerRect.x -= speed;
  if (Raylib.IsKeyDown(KeyboardKey.KEY_D)) playerRect.x += speed;

  return playerRect;
}