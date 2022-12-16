#pragma once

#include <windows.h>
#include <time.h>
#include <math.h>

#pragma warning (disable : 4819)

#include <d3d9.h>
#include <d3dx9.h>

#include <DxLib.h>

#include "Game.h"

bool PushHitKey( int key );
bool CheckMouseInput( void );
bool PushMouseInput( void );
int GetMouseX( void );
int GetMouseY( void );
