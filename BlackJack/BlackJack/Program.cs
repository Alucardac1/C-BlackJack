using System;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;

namespace BlackJack
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to C# Black Jack. By David Ewing.");
            bool gameState = true;
            Deck cards = new Deck();
            Hand pHand = new Hand();
            int score = 0;
            //cards.printDeck();
            pHand.addCard(cards);
            pHand.addCard(cards);
            foreach (Card card in pHand)
            {
                score += card.getValue();
            }
            while (gameState == true)
            {
                Console.WriteLine("Hand:");
                pHand.printHand();
                foreach(Card card in pHand)
                {
                    Console.WriteLine(card.getName() + " of " + card.getSuit());
                }
                Console.WriteLine("Score: " + score.ToString());
                Console.SetCursorPosition(0, 1);

                if(Console.ReadKey(true).Key == ConsoleKey.Enter)
                {
                    pHand.addCard(cards);
                }
            }
        }
    }

    public class Card
    {
        private String suit;
        private String name;
        private int value;

        public Card(String nameOfCard, String suitOfCard, int gameValue)
        {
            value = gameValue;
            name = nameOfCard;
            suit = suitOfCard;
        }

        public String getName()
        {
            return name;
        }

        public String getSuit()
        {
            return suit;
        }

        public int getValue()
        {
            return value;
        }
    }

    public class Deck
    {
        private List<Card> cardDeck;
        public Deck()
        {
            cardDeck = new List<Card>(52);
            string[] suits = {"Diamonds", "Spades", "Hearts", "Clubs" };
            foreach (string suit in suits)
            {
                cardDeck.Add(new Card("Ace", suit, 11));
                cardDeck.Add(new Card("Two", suit, 2));
                cardDeck.Add(new Card("Three", suit, 3));
                cardDeck.Add(new Card("Four", suit, 4));
                cardDeck.Add(new Card("Five", suit, 5));
                cardDeck.Add(new Card("Six", suit, 6));
                cardDeck.Add(new Card("Seven", suit, 7));
                cardDeck.Add(new Card("Eight", suit, 8));
                cardDeck.Add(new Card("Nine", suit, 9));
                cardDeck.Add(new Card("Ten", suit, 10));
                cardDeck.Add(new Card("Jack", suit, 10));
                cardDeck.Add(new Card("Queen", suit, 10));
                cardDeck.Add(new Card("King", suit, 10));
            }
        }
        public void removeCard(Card card)
        {
            cardDeck.Remove(card);
        }
        public Card getCard(int card)
        {
            return cardDeck[card];
        }
        public int getDeckSize()
        {
            return cardDeck.Count;
        }
        public void printDeck()
        {
            for (int t = 0; t < 52; t++)
            {
                Debug.WriteLine(cardDeck[t].getName() + " of " + cardDeck[t].getSuit());
            }
        }
    }

    public class Hand : IEnumerable
    {
        private List<Card> playerHand;
        private Random rng = new Random();
        
        public Hand()
        {
            playerHand = new List<Card>(5);
        }

        public void addCard(Deck deck)
        {
        Random rng = new Random();
            int num = rng.Next(deck.getDeckSize());
            Card select = deck.getCard(num);
            playerHand.Add(new Card(select.getName(), select.getSuit(), select.getValue()));
            deck.removeCard(select);
        }

        public void printHand()
        {
            for (int t = 0; t < playerHand.Count; t++)
            {
                Debug.WriteLine(playerHand[t].getName() + " of " + playerHand[t].getSuit());
            }
        }
        public IEnumerator GetEnumerator()
        {
            foreach (Card val in playerHand)
            {
                yield return val;
            }
        }
    }
}
