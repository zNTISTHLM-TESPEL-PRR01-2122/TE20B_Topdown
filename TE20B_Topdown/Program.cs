using System;
using Raylib_cs;

Raylib.InitWindow(800, 600, "2D-topdown game");
Raylib.SetTargetFPS(60);

float speed = 2.3f;

Texture2D playerImage = Raylib.LoadTexture("happy.png");
Rectangle playerRect = new Rectangle(100, 70, playerImage.width, playerImage.height);

Rectangle r1 = new Rectangle(200, 200, 50, 50);
Rectangle r2 = new Rectangle(125, 225, 50, 50);

Color r2Color = Color.DARKBROWN;

while (!Raylib.WindowShouldClose())
{
  if (Raylib.IsKeyDown(KeyboardKey.KEY_W)) playerRect.y -= speed;
  if (Raylib.IsKeyDown(KeyboardKey.KEY_S)) playerRect.y += speed;
  if (Raylib.IsKeyDown(KeyboardKey.KEY_A)) playerRect.x -= speed;
  if (Raylib.IsKeyDown(KeyboardKey.KEY_D)) playerRect.x += speed;

  if (Raylib.CheckCollisionRecs(r1, r2))
  {
    r2Color = Color.BEIGE;
  }
  else
  {
    r2Color = Color.RED;
  }

  r2.x += 0.25f;

  
  Raylib.BeginDrawing();

  Raylib.ClearBackground(Color.BLUE);

  Raylib.DrawRectangleRec(r1, Color.GREEN);
  Raylib.DrawRectangleRec(r2, r2Color);


  Raylib.DrawRectangleRec(playerRect, Color.LIME);

  Raylib.DrawTexture(playerImage, (int)playerRect.x, (int)playerRect.y, Color.WHITE);

  Raylib.EndDrawing();
}