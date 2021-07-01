using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace пасьянс
{
    class Constants
    {
        public const int RANK_COUNT = 13; // количество карт одной масти
        public const int SUIT_COUNT = 4;  // количество мастей

    }

        class Card
    {
        private int suit;     // масть
        private int rank;     // ранг

        public int Suit { get { return suit; } }
        public int Rank { get { return rank; } }

        public int ImageIndex { get { return suit * Constants.RANK_COUNT + rank; } }

        // Конструктор карты
        public Card(int suit, int rank)
        {
            this.suit = suit;
            this.rank = rank;
        }
        // Конструктор карты
        public Card(int index)
        {
            rank = index % Constants.RANK_COUNT;
            suit = index / Constants.RANK_COUNT;
        }
    }





    class Pile // стопка карт
    {
        protected List<Card> cards;
        private int x, y; // координаты стопки

        public int X { get { return x; } set { x = value; } }
        public int Y { get { return y; } set { y = value; } }

        // Возвращает карту заданной позиции стопки
        public Card this[int pos] { get { return (Card)cards[pos]; } }
        // Возвращает количество карт в стопке
        public int Count { get { return cards.Count; } }

        // Конструктор стопки карт
        public Pile()
        {
            cards = new List<Card>();
        }

        // Возвращает верхнюю карту с удалением ее из стопки
        public Card GetCard()
        {
            Card card = null;
            if (cards.Count > 0)
            {
                card = cards[cards.Count - 1];
                cards.RemoveAt(cards.Count - 1);
            }
            return card;
        }

        // Добавление карты в стопку
        public void AddCard(Card card)
        {
            cards.Add(card);
        }
    }

    class Deck : Pile// колода
    {
        // Конструктор колоды
        public Deck()
        {
            
             for (int j = 0; j < Constants.SUIT_COUNT; j++)
             {
                 for (int k = 0; k < Constants.RANK_COUNT; k++)
                 {
                     AddCard(new Card(j, k));
                 }
             }
            
        }

        // Перемешивает карты в колоде
        public void Shuffle()
        {
            int n;
            Card card;
            Random random = new Random();
            for (int i = 0; i < cards.Count; i++)
            {
                int ind1 = i;
                card = cards[i];
                n = random.Next(cards.Count);
                cards[i] = cards[n];
                cards[n] = card;
            }
        }
    }

    class Story // запись хода
    {
        private Pile fromPile;  // взяли из стопки 
        private Pile toPile;    // положили в стопку

        public Pile From { get { return fromPile; } }
        public Pile To { get { return toPile; } }

        public Story(Pile from, Pile to)
        {
            fromPile = from;
            toPile = to;
        }
    }

    class Undo  // история сделанных ходов для возможности отмены
    {
        protected List<Story> hist;

        public int Count { get { return hist.Count; } }
        public Story this[int pos] { get { return (Story)hist[pos]; } }

        public Undo()
        {
            hist = new List<Story>();
        }

        // сохранение перемещения карты
        public void Save(Pile from, Pile to)
        {
            hist.Add(new Story(from, to));
        }

        // восстановление прежнего положения карты
        public void Restore()
        {
            Card card;
            if (hist.Count > 0)
            {
                card = hist[hist.Count - 1].To.GetCard();
                hist[hist.Count - 1].From.AddCard(card);
                hist.RemoveAt(hist.Count - 1);
            }
        }
    }
}
