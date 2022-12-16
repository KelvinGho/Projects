#include "SystemUI.h"
#include "Main.h"
#include "Player.h"
#include "monster.h"
int HP_box;
int health_counter[9];
int Player_death;
int health_x;

int Death_monster_box;

int Special_box;
int Special_power;
float Special_x = 97;

int title;
int title_y;
int Game_stage;

int score;

int score_x;

int Color = GetColor(229, 20, 55);


void UIInit()
{
	Game_stage = 0;
	title_y = -50;
	score = 0;
	score_x = 540;
	health_x = 120;
	HP_box = LoadGraph("data_UI/info/HP.png");
	for (int i = 0; i < 9; i++) {
		health_counter[i] = LoadGraph("data_UI/info/heart.png");
	}
		Death_monster_box = LoadGraph("data_UI/info/monster_death.png");
		Special_box = LoadGraph("data_UI/info/special_bar.png");
		Special_power = LoadGraph("data_UI/info/special_power.png");
		title = LoadGraph("data_UI/catfighter.png");
		Player_death = LoadGraph("data_UI/info/Death.png");
		
		
		player_HP = 9;
		score = 0;
		Special_x = 98;
}
void UIUpdate()
{
	
	if (score > 9) {
		score_x = 520;
	}
	if (score > 99) {
		score_x = 500;
	}
	
	if (Game_stage == 0) {
		title_y++;
		if (title_y > 60) {
			if (PushHitKey(KEY_INPUT_SPACE)) {
				
				Game_stage = 1;
				
			}
		}
	}
	if (Special_x > 400) {
		Special_x = 400;
	}
	
	if (Game_stage == 1) {
		if (CheckHitKey(KEY_INPUT_DOWN)) {

			
			Special_x += 0.5;

		}
		if (PushHitKey(KEY_INPUT_SPACE)) {
			
		}
	}
	if (Game_stage == 2) {
		if (PushHitKey(KEY_INPUT_SPACE)) {
			player_HP = 9;
			score = 0;
			Special_x = 98;
			
		}
		
	}
	
}
void UIDraw()
{
	if (Game_stage == 0) //game title
	{
		DrawGraph(110,title_y, title, TRUE);
		if (title_y > 60) {
			title_y = 60;
			SetFontSize(25);
			DrawString(180, 280, "Press Space To Start", Color);
			DrawString(180, 320, "Press Escape To Exit", Color);
		}
	}
	
	if (Game_stage == 1) //game start
	{
		DrawGraph(97, 70, Special_box, TRUE);
		DrawFillBox(98, 74, Special_x, 105, Color);
		DrawGraph(97, 70, Special_power, TRUE);

		DrawGraph(0, 0, HP_box, TRUE);
		
		DrawGraph(500, 0, Death_monster_box, TRUE);
		for (int i = 0; i < player_HP; i++) {
			DrawGraph(30*i+health_x, 20, health_counter[i], TRUE);
			
		}
		
		char text[32];
		SetFontSize(60);
		sprintf(text, "%dx", score);
		DrawString(score_x, 80, text, GetColor(255, 255, 0));

		
		if (player_HP < 1) {
			
			Game_stage = 2;

		}
	}
	
	if (Game_stage==2)//game over
	{
		

		
		DrawGraph(97, 70, Special_box, TRUE);
		DrawFillBox(98, 74, Special_x, 105, Color);
		DrawGraph(97, 70, Special_power, TRUE);
		DrawGraph(500, 0, Death_monster_box, TRUE);
		DrawGraph(0, 0, Player_death, TRUE);
		
		char text[32];
		SetFontSize(60);
		sprintf(text, "%dx", score);
		DrawString(score_x, 80, text, GetColor(255, 255, 0));
	

		SetFontSize(25);
		DrawString(180, 280, "Press Space To Retry", Color);
		SetFontSize(100);
		sprintf(text, "%d", score);
		DrawString(290, 195, text, GetColor(255, 255, 0));

		if (PushHitKey(KEY_INPUT_SPACE)) {
			Game_stage = 1;
			
		}

	}
}
void UIExit() 
{

}

