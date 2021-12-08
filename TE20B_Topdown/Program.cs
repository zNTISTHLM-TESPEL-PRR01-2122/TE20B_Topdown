using System;
using System.Numerics;
using Raylib_cs;

Raylib.InitWindow(800, 600, "2D-topdown game");
Raylib.SetTargetFPS(60);

float speed = 2.3f;

Texture2D playerImage = Raylib.LoadTexture("happy.png");
Rectangle playerRect = new Rectangle(100, 70, playerImage.width, playerImage.height);

// Vector2 textPos = new Vector2(50, 25);
// Font comic = Raylib.LoadFont("ComicNeue.ttf");

Rectangle doorRect = new Rectangle(200, 200, 32, 32);

int points = 0;

Rectangle pointRect = new Rectangle(256, 64, 16, 16);
bool pointTaken = false;

bool undoX = false;
bool undoY = false;
Vector2 movement = new Vector2();

string level = "start";

while (!Raylib.WindowShouldClose())
{
  undoX = false;
  undoY = false;

  if (level == "start" || level == "corridor")
  {
    movement = ReadMovement(speed);

    playerRect.x += movement.X;
    playerRect.y += movement.Y;

    if (playerRect.x < 0 || playerRect.x + playerRect.width > Raylib.GetScreenWidth())
    {
      undoX = true;
    }
    if (playerRect.y < 0 || playerRect.y + playerRect.height > Raylib.GetScreenHeight())
    {
      undoY = true;
    }



  }

  if (level == "start")
  {
    if (Raylib.CheckCollisionRecs(playerRect, doorRect) && points == 1)
    {
      level = "end";
    }
    if (Raylib.CheckCollisionRecs(playerRect, pointRect) && pointTaken == false)
    {
      points++;
      pointTaken = true;
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

  if (undoX == true) playerRect.x -= movement.X;
  if (undoY == true) playerRect.y -= movement.Y;

  Raylib.BeginDrawing();

  // Raylib.DrawText(playerRect.x.ToString(), 100, 100, 40, Color.DARKBLUE);
  // Raylib.DrawTextEx(comic, "HEJ", textPos, 80, 0, Color.BEIGE);

  if (level == "start")
  {
    Raylib.ClearBackground(Color.BLUE);
    if (points == 1)
    {
      Raylib.DrawRectangleRec(doorRect, Color.BLACK);
    }
    if (pointTaken == false)
    {
      Raylib.DrawRectangleRec(pointRect, Color.YELLOW);
    }
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
    Raylib.DrawText(points.ToString(), 10, 10, 40, Color.BLACK);
  }

  Raylib.EndDrawing();
}

static Vector2 ReadMovement(float speed)
{
  Vector2 movement = new Vector2();
  if (Raylib.IsKeyDown(KeyboardKey.KEY_W)) movement.Y = -speed;
  if (Raylib.IsKeyDown(KeyboardKey.KEY_S)) movement.Y = speed;
  if (Raylib.IsKeyDown(KeyboardKey.KEY_A)) movement.X = -speed;
  if (Raylib.IsKeyDown(KeyboardKey.KEY_D)) movement.X = speed;

  return movement;
}