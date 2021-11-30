using System;
using Raylib_cs;

Raylib.InitWindow(800, 600, "2D-topdown game");
Raylib.SetTargetFPS(60);

float speed = 2.3f;

Texture2D playerImage = Raylib.LoadTexture("happy.png");
Rectangle playerRect = new Rectangle(100, 70, playerImage.width, playerImage.height);

while (!Raylib.WindowShouldClose())
{
  if (Raylib.IsKeyDown(KeyboardKey.KEY_W)) playerRect.y -= speed;
  if (Raylib.IsKeyDown(KeyboardKey.KEY_S)) playerRect.y += speed;
  if (Raylib.IsKeyDown(KeyboardKey.KEY_A)) playerRect.x -= speed;
  if (Raylib.IsKeyDown(KeyboardKey.KEY_D)) playerRect.x += speed;
  
  Raylib.BeginDrawing();

  Raylib.ClearBackground(Color.BLUE);

  Raylib.DrawRectangleRec(playerRect, Color.LIME);

  Raylib.DrawTexture(playerImage, (int)playerRect.x, (int)playerRect.y, Color.WHITE);

  Raylib.EndDrawing();
}