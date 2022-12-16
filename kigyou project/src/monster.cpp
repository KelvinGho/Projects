#include "monster.h"
#include "Main.h"
#include "Player.h"
#include "SystemUI.h"

#define RECT_SIZE 43
int walk;
int monster_attack;
int monster_dead;
int monster_dir;
int monster_hp;

float monster_x;
float monster_y;
float monster_speed;
float monster_anim_count = 0.0f;
float monster_dead_count = 0.0f;
float monster_hit_count = 0.0f;

bool monster_hit;
bool monster_IsDead;
void MonsterInit()
{
	monster_dir = (rand() >> 12) & 1;
	if (monster_dir == 0) {
		monster_x = 680;
	}
	else {
		monster_x = -80;
	}	
	monster_hp = 4;
	
	monster_y = 375.0f;
	monster_hit = false;
	monster_IsDead = false;

	walk = LoadGraph("data_enemy/white/monster.png");
	monster_dead = LoadGraph("data_enemy/white/monster_dead.png");
	monster_attack = LoadGraph("data_enemy/white/monster_hit.png");
	
}
void MonsterRespawn()
{
	monster_dir = (rand() >> 12) & 1;
	if (monster_dir == 0) {
		monster_x = 690;
	}
	else {
		monster_x = -100;
	}
	monster_hp = 8;
	monster_hit = false;
	monster_IsDead = false;
}
void MonsterUpdate()
{	
	
	if (Game_stage==1) {
		monster_speed = 5.0f;


		if (monster_dir == 0) {
			monster_x -= monster_speed;

			if (monster_hp < 1) {
				monster_dead_count+=0.1f;
				monster_hit_count = false;
				
				if (monster_dead_count > 5.0f) {				
				
					MonsterRespawn();
					monster_IsDead = true;
				
				}
			}
		
			monster_anim_count += 0.1f;
			if (monster_anim_count > 4.0f) {
				monster_anim_count = 0.0f;
			}
			
			if (monster_x < player_x + 50.0f) {
				monster_x = player_x + 50.0f;
				monster_anim_count = 0.0f;
				monster_hit = true;
				if (monster_hit == true) {
					monster_x -= 15.0f;
				}
				
			}

		}


		if (monster_dir == 1) {
			monster_x += monster_speed;
			if (monster_hp < 1) {
				monster_dead_count+=0.1f;
				monster_hit_count = false;

				if (monster_dead_count > 5.0f) {
					MonsterRespawn();
						
					monster_IsDead=true;
				}
			}
			
			monster_anim_count += 0.1f;
			if (monster_anim_count > 4.0f) {
				monster_anim_count = 0.0f;
			}
			
			if (monster_x > player_x - 30.0f) {
				monster_x =player_x-40.0f;
				monster_anim_count = 0.0f;
				monster_hit = true;
				if (monster_hit == true) {
					monster_x += 15.0f;
				}
			}
			
			
		}
		
	}
	if (Game_stage == 2) {
		MonsterRespawn();
	}
	if (monster_hit==true)
	{
		monster_hit_count += 0.02f;
	}
	if (monster_hit_count >3.0f)
	{
		monster_hit_count = false;
		monster_hit_count += 0.02f;
		
	}

	if (monster_IsDead == true) {
		score++;

		if(monster_IsDead=true){}
		monster_dir = (rand() >> 12) & 1;
		if (monster_dir == 0) {
			monster_x = 600;
		}
		else {
			monster_x = 0;
		}
		monster_hp = 8;
		monster_hit = false;
		monster_IsDead = false;
	}


}

void MonsterDraw()
{
	if (monster_hp < 1) {
		if (monster_dir == 0)
		{
			DrawGraph(monster_x, monster_y,monster_dead, TRUE);
		}
		else
		{
			DrawTurnGraph(monster_x, monster_y, monster_dead, TRUE);
		}
		
	}
	else if(monster_hit==true){
		int image_data[2][3] = {
		{ 0,47,94 },
		{ 0,47,94 },
		};
		int image_u = monster_dir * 65;
		int image_v = image_data[monster_dir][(int)monster_hit_count];
		DrawRectGraphF(monster_x, monster_y, image_v, image_u, RECT_SIZE, 68,monster_attack, TRUE, 0);
	

	}
	else {
		int image_data[2][4] =
		{

		{ 0,43,86,129 },
		{ 0,43,86,129 },
		};
		int image_u = monster_dir * 67;
		int image_v = image_data[monster_dir][(int)monster_anim_count];
		DrawRectGraphF(monster_x, monster_y, image_v, image_u, RECT_SIZE, 67, walk, TRUE, 0);
	}
}

void MonsterExit()
{
	DeleteGraph(walk);
	DeleteGraph(monster_IsDead);
	DeleteGraph(monster_attack);
}
