#include "Main.h"

char KeyBuffer[256];
char KeyBefore[256];
int MouseBefore = 0;

//---------------------------------------------------------------------------------
//	WinMain
//---------------------------------------------------------------------------------
int WINAPI WinMain( HINSTANCE hInstance, HINSTANCE hPrevInstance, LPSTR lpCmdLine, int nCmdShow )
{
	int Time;

	SetOutApplicationLogValidFlag( FALSE );
	ChangeWindowMode( 0 );
	SetWindowText( "CAT FIGHTER" );
	SetBackgroundColor( 0, 0, 0 );

	SetGraphMode( 640, 480, 32 );

	if( DxLib_Init() == -1 )	return -1;


	SetDrawScreen( DX_SCREEN_BACK );
	SetTransColor( 255, 0, 255 );
	srand( GetNowCount() % RAND_MAX );

	GameInit();

	while( TRUE )
	{
		Time = GetNowCount();
		ClearDrawScreen();

		GetHitKeyStateAll( KeyBuffer );

		GameUpdate();
		GameRender();

		memcpy( KeyBefore, KeyBuffer, sizeof( char ) * 256 );
		MouseBefore = GetMouseInput();

		ScreenFlip();
		while( GetNowCount() - Time < 17 ){}
		if( ProcessMessage() )	break;
		if( CheckHitKey( KEY_INPUT_ESCAPE ) )	break;
	}

	GameExit();

	DxLib_End();
	return 0;

}

//---------------------------------------------------------------------------------
//	キーが押された瞬間を取得する
//---------------------------------------------------------------------------------
bool PushHitKey( int key )
{
	int buffer = KeyBuffer[key];
	int before = KeyBefore[key];
	if( buffer == 1 && before == 0 ){
		return true;
	}
	return false;
}
//---------------------------------------------------------------------------------
//	マウスが押されているかを取得する
//---------------------------------------------------------------------------------
bool CheckMouseInput( void )
{
	if( GetMouseInput() & MOUSE_INPUT_LEFT ){
		return true;
	}
	return false;
}
//---------------------------------------------------------------------------------
//	マウスが押された瞬間を取得する
//---------------------------------------------------------------------------------
bool PushMouseInput( void )
{
	if( GetMouseInput() & MOUSE_INPUT_LEFT ){
		if( MouseBefore == 0 ){
			return true;
		}
	}
	return false;
}
//---------------------------------------------------------------------------------
//	マウスの座標を取得する
//---------------------------------------------------------------------------------
int GetMouseX( void )
{
	int mouse_x;
	int mouse_y;
	GetMousePoint( &mouse_x, &mouse_y );
	return mouse_x;
}
int GetMouseY( void )
{
	int mouse_x;
	int mouse_y;
	GetMousePoint( &mouse_x, &mouse_y );
	return mouse_y;
}
