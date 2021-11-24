using System;
using Raylib_cs;

Raylib.InitWindow(800, 600, "2D-topdown game");
Raylib.SetTargetFPS(60);

Texture2D playerImage = Raylib.LoadTexture("happy.png");
Rectangle playerRect = new Rectangle(10, 10, 32, 32);

while (!Raylib.WindowShouldClose())
{
  Raylib.BeginDrawing();

  // Raylib.DrawRectangle(10, 10, 32, 32, Color.RAYWHITE);

  Raylib.ClearBackground(Color.BLUE);
  Raylib.DrawRectangleRec(playerRect, Color.LIME);
  
  Raylib.DrawTexture(playerImage, 45, 70, Color.WHITE);

  Raylib.EndDrawing();
}