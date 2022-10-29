using System;
using System.Collections.Generic;
using System.Text;

namespace TestChips
{
    //Класс стола в котором будут храниться все стулья и среднее значение фишек
    public class Table
    {
        private int midChips;

        public Seat[] Seats { private set; get; } // Массив мест или же набор вершин графа

        //Инициализируем стол в виде цикличного графа 
        public Table(List<int> chips)
        {
            midChips = MiddleValue(chips);
            Seats = new Seat[chips.Count];

            for (int i = 0; i < chips.Count; i++) 
            {
                Seats[i] = new Seat(i, chips[i]);
                if (i > 0) 
                {
                    Seats[i].LeftSeat = Seats[i - 1];
                    Seats[i - 1].RightSeat = Seats[i];
                    if (i == chips.Count - 1) 
                    {
                        Seats[0].LeftSeat = Seats[i];
                        Seats[i].RightSeat = Seats[0];
                    }

                }
            }
        }

        /// <summary>
        /// Данная функция считает кол-во шагов для выравнивания фишек по местам
        /// </summary>
        /// <returns>Значение шагов</returns>
        public int GetSteps()
        {
            int countSteps = 0;

            for (int i = 0; i < Seats.Length; i++) 
            {
                //При наличии фишек больше необходимого начинаем перебор соседей чтобы переложить фишки 
                if (Seats[i].Chips > midChips) 
                {
                    int valueOfChips = Seats[i].Chips - midChips;//Кол-во фишек которое можем переложить
                    Seat thisSeat = Seats[i];

                    int j = 1;//Множитель который показывает сколько вершин нужно пройти, чтобы переложить фишку где меньше необходимого

                    //Цикл перебора соседей данного стула, до тех пор пока их не станет необходимое кол-во
                    while (Seats[i].Chips != midChips) 
                    {
                        Seat seatForLeft = thisSeat.LeftSeat;
                        Seat seatForRight = thisSeat.RightSeat;

                        //Блок для левого соседа
                        if (seatForLeft.Chips < midChips) 
                        {
                            int needChips = midChips - seatForLeft.Chips;//Сколько необходимо фишек соседу до необходимого кол-ва
                            if (valueOfChips <= needChips)
                            {
                                Seats[i].Chips -= valueOfChips;
                                seatForLeft.Chips += valueOfChips;
                                countSteps += valueOfChips * j;
                                break;
                            }
                            else
                            {
                                Seats[i].Chips -= needChips;
                                seatForLeft.Chips += needChips;
                                valueOfChips -= needChips;
                                countSteps += needChips * j;
                                thisSeat = seatForLeft; 
                            }
                        }

                        //Блок для правого соседа
                        if (seatForRight.Chips < midChips)
                        {
                            int needChips = midChips - seatForRight.Chips;//Сколько необходимо фишек соседу до необходимого кол-ва
                            if (valueOfChips <= needChips)
                            {
                                Seats[i].Chips -= valueOfChips;
                                seatForRight.Chips += valueOfChips;
                                countSteps += valueOfChips * j;
                                break;
                            }
                            else
                            {
                                Seats[i].Chips -= needChips;
                                seatForLeft.Chips += needChips;
                                valueOfChips -= needChips;
                                countSteps += needChips * j;
                                thisSeat = seatForRight;
                            }
                        }
                        j++;
                    }
                }
            }
            
            return countSteps;
        }


        /// <summary>
        /// Возвращает среднее арифметическое значение
        /// </summary>
        /// <param name="list">Лист значенией, среди которых необходимо найти среднее</param>
        /// <returns>Среднее арифмитческое</returns>
        public int MiddleValue(List<int> list)
        {
            int sum = 0;
            for (int i = 0; i < list.Count; i++)
            {
                sum += list[i];
            }
            return sum / list.Count;
        }
    }
}
