#include <stdio.h>

#define max_bridges			30

typedef struct point
{
	double	x, y;
}POINT;

typedef struct bridge
{
	int	id;
	POINT	p1, p2;
}BRIDGE;

int getMax(int cross_num[], int bridge_num)
{
	int i, max = 0, index = -1;

	for (i = 0; i<bridge_num; i++)
	{
		if (cross_num[i] > max)
		{
			max = cross_num[i];
			index = i;
		}
	}
	return index;
}

double min(double v1, double v2)
{
	return v1<v2 ? v1 : v2;
}
double max(double v1, double v2)
{
	return v1>v2 ? v1 : v2;
}
int is_OnSegment(POINT p, POINT p1, POINT p2)
{
	if (min(p1.x, p2.x) <= p.x && p.x <= max(p1.x, p2.x))
	{
		if (min(p1.y, p2.y) <= p.y && p.y <= max(p1.y, p2.y))
		{
			return 1;
		}
	}
	return 0;
}

int Check_intersect(BRIDGE b1, BRIDGE b2)
{
	double	dirt1, dirt2, dirt3, dirt4;

	dirt1 = (b2.p1.x - b1.p1.x)*(b2.p2.y - b1.p1.y) - (b2.p1.y - b1.p1.y)*(b2.p2.x - b1.p1.x);
	dirt2 = (b2.p1.x - b1.p2.x)*(b2.p2.y - b1.p2.y) - (b2.p1.y - b1.p2.y)*(b2.p2.x - b1.p2.x);
	if ((dirt1<0 && dirt2<0) || (dirt1>0 && dirt2>0))
		return 0;
	if (dirt1 == 0)
	if (is_OnSegment(b1.p1, b2.p1, b2.p2))
		return 1;
	if (dirt2 == 0)
	if (is_OnSegment(b1.p2, b2.p1, b2.p2))
		return 1;
	if ((dirt1 == 0) && (dirt2 == 0))
	{
		if (is_OnSegment(b2.p1, b1.p1, b1.p2) || is_OnSegment(b2.p2, b1.p1, b1.p2))
			return 1;
		else return 0;
	}

	dirt3 = (b1.p1.x - b2.p1.x)*(b1.p2.y - b2.p1.y) - (b1.p1.y - b2.p1.y)*(b1.p2.x - b2.p1.x);
	dirt4 = (b1.p1.x - b2.p2.x)*(b1.p2.y - b2.p2.y) - (b1.p1.y - b2.p2.y)*(b1.p2.x - b2.p2.x);
	if ((dirt3<0 && dirt4<0) || (dirt3>0 && dirt4>0))
		return 0;
	if (dirt3 == 0)
	if (is_OnSegment(b1.p1, b2.p1, b2.p2) == 0)
		return 0;
	if (dirt4 == 0)
	if (is_OnSegment(b1.p2, b2.p1, b2.p2) == 0)
		return 0;

	return 1;
}

void Final_Bridge(BRIDGE bridge[], int bridge_num)
{
	char	matrix_buff[max_bridges*max_bridges] = { 0 };
	char	*cross_matrix[max_bridges];
	int		cross_num[max_bridges] = { 0 };
	int		i, j;

	for (i = 0; i<bridge_num; i++)
		cross_matrix[i] = matrix_buff + i * bridge_num;

	for (i = 0; i<bridge_num - 1; i++)
	{
		for (j = i + 1; j<bridge_num; j++)
		{
			if (Check_intersect(bridge[i], bridge[j]))
			{
				cross_matrix[i][j] = 1;
				cross_matrix[j][i] = 1;
				cross_num[i] ++;
				cross_num[j] ++;
			}
		}
	}

	while ((i = getMax(cross_num, bridge_num)) >= 0)
	{
		bridge[i].id *= -1;
		cross_num[i] *= -1;
		for (j = 0; j<bridge_num; j++)
		{
			if (bridge[j].id < 0)
				continue;
			if (cross_matrix[i][j])
				cross_num[j] --;
		}
	}
}

int main(int argc, char *argv[])
{
	FILE *file = fopen(argv[1], "r");
	BRIDGE	bridge[max_bridges], *ValuesB;
	int			bridge_num = 0, i;
	char		s[40];

	//file = fopen (argv[1], "r");
	if (file == NULL)
	{
		printf("Can not open the file.\n");
		return -1;
	}

	ValuesB = bridge;
	while (!feof(file))	//read the input line by line 
	{
		i = fscanf(file, "%d%[^'[']%*c%lf,%lf%[^'[']%*c%lf,%lf", &(ValuesB->id), s,
			&(ValuesB->p1.x), &(ValuesB->p1.y), s, &(ValuesB->p2.x), &(ValuesB->p2.y));
		if (i == 7)
		{
			ValuesB++;
			bridge_num++;
			fscanf(file, "%s\n", s);
		}
	}

	fclose(file);

	Final_Bridge(bridge, bridge_num);

	for (i = 0; i<bridge_num; i++)
	{
		if (bridge[i].id > 0)
			printf("%d\n", bridge[i].id);
	}

	return 0;
}