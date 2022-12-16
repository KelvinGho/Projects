#include "Main.h"
#include "Player.h"
#include "monster.h"
#include "SystemUI.h"


//---------------------------------------------------------------------------------
//	初期化処理　
//---------------------------------------------------------------------------------
void GameInit( void )
{
	srand(time(NULL));

	PlayerInit();
	MonsterInit();
	UIInit();
}
//---------------------------------------------------------------------------------
//	終了処理
//---------------------------------------------------------------------------------
void GameExit( void )
{
	PlayerExit();
	MonsterExit();
	UIExit();
}
//---------------------------------------------------------------------------------
//	更新処理
//---------------------------------------------------------------------------------
void GameUpdate( void )
{

	PlayerUpdate();
	///HITBOX/////
	static const float MONSTER_ADJ_X = 35.f;	// hit adjust to monster x.
	static const float MONSTER_ADJ_Y = 55.f;	// hit adjust to monster y.
	static const float PLAYER_ADJ_X = 15.f;		// hit adjust to monster y.
	static const float PLAYER_ADJ_Y = 55.f;		// hit adjust to monster y.

	if (hit_counter > 0.0f) {
		float attack_x;
		float attack_y;

		if (hit_counter < 0.2f) {
			if (player_dir == 0) {
				attack_x = player_x + PLAYER_ADJ_X + 10.f;
				attack_y = player_y + PLAYER_ADJ_Y;
				if (attack_x >= monster_x - 25.0f  && attack_x <= monster_x) {
					if (attack_y >= monster_y && attack_y <= monster_y + MONSTER_ADJ_Y) {
						//	モンスターやられる
						monster_hp--;


					}

				}
			}
			if (player_dir == 1) {
				attack_x = player_x - PLAYER_ADJ_X;
				attack_y = player_y + PLAYER_ADJ_Y;
				if (attack_x > monster_x && attack_x < monster_x + MONSTER_ADJ_X) {
					if (attack_y >= monster_y && attack_y <= monster_y + MONSTER_ADJ_Y) {
						//	モンスターやられる
						monster_hp--;

					}
				}

			}

			/*DrawBox(player_x, player_y, attack_x, attack_y, GetColor(0, 0, 255), FALSE);*/	
		}




	}

	// Debug code
	/*DrawBox(monster_x, monster_y, monster_x + MONSTER_ADJ_X, monster_y + MONSTER_ADJ_Y, GetColor(255, 0, 0), FALSE);
*/
	MonsterUpdate();
	
	if (monster_hit_count >2.3f) {
		float monster_attack_x;
		float monster_attack_y;

		if (monster_hit_count < 2.32f) {
			if (monster_dir == 0) {
				monster_attack_x = player_x + PLAYER_ADJ_X + 10.f;
				monster_attack_y = player_y + PLAYER_ADJ_Y;
				if (monster_attack_x >= monster_x - 25.0f  && monster_attack_x <= monster_x) {
					if (monster_attack_y >= monster_y && monster_attack_y <= monster_y + MONSTER_ADJ_Y) {
						//	モンスターやられる
						player_HP--;


					}

				}
			}
			if (monster_dir == 1) {
				monster_attack_x = player_x - PLAYER_ADJ_X;
				monster_attack_y = player_y + PLAYER_ADJ_Y;
				if (monster_attack_x > monster_x && monster_attack_x < monster_x + MONSTER_ADJ_X) {
					if (monster_attack_y >= monster_y && monster_attack_y <= monster_y + MONSTER_ADJ_Y) {
						//	モンスターやられる
						player_HP --;

					}
				}

			}
		}

		




	}
	UIUpdate();
}
//---------------------------------------------------------------------------------
//	描画処理
//---------------------------------------------------------------------------------
void GameRender( void )
{
	UIDraw();
	PlayerDraw();
	MonsterDraw();
	
}
