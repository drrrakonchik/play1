using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game15
{
    class Game
    {
        int size;
        int[,] map; 
        int space_x, space_y; 
        static Random rand = new Random();
        public Game (int size) // 2 размеры 
        {
            if (size < 2) size = 2; 
            if (size > 5) size = 5;
            this.size = size;
            map =new  int[size, size];
        }

        public void start () // 2 перебираем значения
        {
            for (int x = 0; x < size; x++)
                for (int y = 0; y < size; y++)
                    map[x, y] = coords_to_position(x, y) + 1;
            space_x = size - 1; 
            space_y = size - 1;
            map[space_x, space_y] = 0; 

        }

        public void shift (int position) //8 создаем перемещение . которые при нажатии и тд
        {
            int x, y;
            position_to_coords(position, out x, out y);
            if (Math.Abs(space_x - x) + Math.Abs(space_y - y) != 1) // 9Math.Abs это модуль. сделаем так что ходить можно будет тоолько соседними цифрами.
                return;
            map[space_x, space_y] = map[x, y];
            map[x, y] = 0;
            space_x = x;
            space_y = y;

        }

        public void shift_random() // 10 функция создает одно случайно перемещение 
        {
           int a = rand.Next(0, 4); // пишем 4 так как максимум можно сделать 4 хода
            int x = space_x;
            int y = space_y;
            switch (a)
            {
                case 0: x--; break;
                case 1: x++; break;
                case 2: y--; break;
                case 3: y++; break;

            }
            shift(coords_to_position(x, y));
        }
        public bool check_numbers() // 12 проверка не закончена ли игра
        {
            if (!(space_x == size - 1 && 
                space_y == size - 1))
                return false;
            for (int x = 0; x < size; x++)
                for (int y = 0; y < size; y++)
                    if (x == size - 1 && y == size - 1) // 12 отдельная проверка для пустой клетки
                        return true;
                    else
                    if (map[x, y] != coords_to_position(x, y) + 1)
                        return false;
            return true;
          
        }

        public int get_number (int position) // 4 что должно быть написанно на кнопочке 
        {
            int x, y;
            position_to_coords(position, out x, out y);
            if (x < 0 || x >= size) return 0;
            if (y < 0 || y >= size) return 0;
            return map[x, y]; // переводим в массив
        }
        private int coords_to_position (int x, int y)  // 3перевод координат в позицию
        {
            if (x < 0) x = 0; // 11 если спайс у и х вышли за пределы массива пррописываем это для избежания 
            if (x > size - 1) x = size - 1;
            if (y < 0) y = 0;
            if (y > size - 1) y = size - 1;
            return y * size + x;
        }
        private void position_to_coords (int position, out int x, out int y) // 3 обратный перевод
        {
            if (position < 0) position = 0; // 11 если спайс у и х вышли за пределы массива пррописываем это для избежания  проверка
            if (position > size * size - 1) position = size * size - 1;
            x = position % size;
            y = position / size;
        }
    }

}
