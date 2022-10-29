using System;
using System.Collections.Generic;
using System.Text;

namespace TestChips
{
    public class Seat
    {
        //Это класс для места, в нем будет хранится следующая информация

        public int Id { get; set; }// Личный ID
        public int Chips { get; set; }// Кол-во фишек
        public Seat LeftSeat { get; set; }// Ссылка на соседнее место слева
        public Seat RightSeat { get; set; }// Ссылка на соседнее место справа

        public Seat(int id, int chips)
        {
            Id = id;
            Chips = chips;
        }

        //Данный класс можно рассматривать как вершину графа Table
    }
}
