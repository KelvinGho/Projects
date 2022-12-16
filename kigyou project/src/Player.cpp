#include "Main.h"
#include "Player.h"
#include "monster.h"
#include "SystemUI.h"
#define RECT_SIZE 43

float	player_x;
float	player_y;
float player_anim_count;
int player_HP;


int jump;
float player_jump = 0.0f;
float gravity = 0.5f;
float jump_counter;
bool jump_active = false;
bool jump2;

int player_death;

//////////ATTACKS////////
int idle;
int hit;
int hit2;
int hit3;
int crouch;
int ultimate;


bool punch;
bool punch2;
bool kick;	
bool crouch1;
bool ultimate1;

int fireball;

float hit_counter;
///////////////////////////

int player_dir;
int	attack;

////////////////////////

void PlayerInit()
{
	player_HP = 9;
	player_x = 300.0f;
	player_y = 370.0f;
	player_dir = 0;
	player_anim_count = 0.0f;

	/////////////////////////////////////
	idle = LoadGraph("data_player/idle.png");
	hit = LoadGraph("data_player/punch.png");
	hit2 = LoadGraph("data_player/punch2.png");
	hit3 = LoadGraph("data_player/kick.png");
	ultimate = LoadGraph("data_player/ultimate.png");
	crouch = LoadGraph("data_player/crouch.png");
	jump = LoadGraph("data_player/jump.png");
	player_death = LoadGraph("data_player/player_dead.png");
	
	fireball = LoadGraph("data_player/fireball.png");
	/////////////////////////////////////

	//////////////ATTACKS////////////
	punch = false;
	punch2 = false;
	kick = false;
	crouch1 = false;
	jump2 = false;
	ultimate1 = false;
	fireball = false;

	jump_counter = 0.0f;
	hit_counter = 0.0f;
	//////////////////////////////
}

void PlayerUpdate()
{
	
	

	if (Game_stage == 1) {
		
		player_y += player_jump;
		player_jump += gravity;
		attack = rand() % 3 + 1;
		/////////////////////////////////////

		if (CheckHitKey(KEY_INPUT_DOWN)) {

			crouch1 = true;
			Special_x += 0.5;

		}
		
		if (Special_x == 400) {
			if (PushHitKey(KEY_INPUT_SPACE)) {
				ultimate1 = true;
				Special_x = 98;
			}			
		}
		
		if (PushHitKey(KEY_INPUT_LEFT)) {

			player_dir = 1;

			if (attack == 1) {
				punch = true;
			}
			if (attack == 2) {
				punch2 = true;
			}
			if (attack == 3) {
				kick = true;
			}
		}
		if (PushHitKey(KEY_INPUT_RIGHT)) {

			player_dir = 0;
			if (attack == 1) {
				punch = true;
			}
			if (attack == 2) {
				punch2 = true;
			}
			if (attack == 3) {
				kick = true;
			}

		}
		if (player_y > 370.0f) {
			if (jump_active == false) {
				if (PushHitKey(KEY_INPUT_UP)) {
					player_jump = -8.0;
					player_jump--;
					jump_active = true;
					jump2 = true;

				}
			}
		}

		if (jump_active == true) {
			jump_active = false;
		}


		if (player_x, player_y, 1, monster_x, monster_y, 0) {
			monster_x -= 2;
		}
	}
	///////////////////////////////////////

	////////////////////////////////////////////

	if (punch)
	{
		hit_counter += 0.1f;
	}
	if (hit_counter > 2.0f)
	{
		punch = false;
		hit_counter = 0.0f;
	}
	if (punch2)
	{
		hit_counter += 0.1f;
	}
	if (hit_counter > 2.0f)
	{
		punch2 = false;
		hit_counter = 0.0f;
	}

	if (kick)
	{
		hit_counter += 0.1f;
	}
	if (hit_counter > 2.0f)
	{
		kick = false;
		hit_counter = 0.0f;
	}
	if (ultimate1)
	{
		hit_counter += 0.1f;
	}
	if (hit_counter > 2.0f)
	{
		ultimate1 = false;
		hit_counter = 0.0f;
	}
	if (jump2) {
		jump_counter += 0.1f;
		if (hit_counter > 0.8f)
		{
			kick = false;
			punch2 = false;
			punch = false;
			ultimate1 = false;
			hit_counter = 0.0f;
		}

	}
	if (jump_counter > 4.0f) {
		jump2 = false;
		jump_counter = 0.0f;

	}
	if (ultimate1 == true) {
		crouch1 = false;
		punch = false;
		punch2 = false;
		kick = false;
	}

	if (punch == true) {
		crouch1 = false;
	}
	if (punch2 == true) {
		crouch1 = false;
	}if (kick == true) {
		crouch1 = false;
	}
	if (jump2 == true) {
		crouch1 = false;
	}
	if (Game_stage == 2) {
		crouch1 = false;
		punch = false;
		punch2 = false;
		kick = false;
		jump2 = false;
		ultimate1 = false;
	}


	if (player_y >370.0f) {
		player_y = 370.0f;
	}

	//////////////////////////////////////////////////
}


void PlayerDraw()
{
	///punch

	if (punch)
	{
		if (player_dir == 0)
		{
			DrawGraph(player_x + 10, player_y - 3, hit, TRUE);
		}
		else
		{
			DrawTurnGraph(player_x - 20, player_y - 3, hit, TRUE);
		}

	}
	///kick
	else if (kick)
	{
		if (player_dir == 0)
		{
			DrawGraph(player_x + 10, player_y - 3, hit2, TRUE);
		}
		else
		{
			DrawTurnGraph(player_x - 20, player_y - 3, hit2, TRUE);
		}

	}
	else if (punch2) {

		if (player_dir == 0)
		{
			DrawGraph(player_x + 10, player_y - 3, hit3, TRUE);
		}
		else
		{
			DrawTurnGraph(player_x - 20, player_y - 3, hit3, TRUE);
		}

	}

	else if (crouch1) {
		if (player_dir == 0)
		{
			DrawGraph(player_x, player_y + 15, crouch, TRUE);
		}
		else
		{
			DrawTurnGraph(player_x, player_y + 15, crouch, TRUE);
		}
	}
	else if (ultimate1) {
		if (player_dir == 0)
		{
			DrawGraph(player_x, player_y , ultimate, TRUE);
			DrawGraph(400, 300, fireball, TRUE);
			fireball = true;
		}
		else
		{
			DrawTurnGraph(player_x-5.0f, player_y , ultimate, TRUE);
			DrawTurnGraph(400, 300, fireball, TRUE);
			fireball = true;
		}
	}
	else if (jump2) {
		if (player_dir == 0)
		{
			DrawGraph(player_x, player_y, jump, TRUE);
		}
		else
		{
			DrawTurnGraph(player_x, player_y, jump, TRUE);
		}
	}
	else if (Game_stage == 2) {
		if (player_dir == 0)
		{
			DrawGraph(player_x - 50, player_y + 28, player_death, TRUE);
		}
		else
		{
			DrawTurnGraph(player_x, player_y+28  , player_death, TRUE);
		}
	
	}
	
	else
	{
		player_anim_count += 0.1f;
		if (player_anim_count > 4.0f) {
			player_anim_count = 0.0f;
		}
		int image_data[2][4] =
		{
		{ 0,46,92,138 },
		{ 0,46,92,138 },
		};	
		int image_u = player_dir * 77;
		int image_v = image_data[player_dir][(int)player_anim_count];
		DrawRectGraphF(player_x, player_y, image_v, image_u, RECT_SIZE, 77, idle, TRUE, 0);

	}	
	

	///idle

	


}

void PlayerExit()
{
	DeleteGraph(idle);
	DeleteGraph(hit);

}
