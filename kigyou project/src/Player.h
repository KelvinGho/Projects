#pragma once

void PlayerInit();
void PlayerUpdate();
void PlayerDraw();
void PlayerExit();

extern int idle;
extern float	player_x;
extern float	player_y;
extern float player_anim_count;
extern int player_dir;
extern int player_HP;

extern float hit_counter;
