using System.Drawing.Drawing2D;

namespace CRM.Presentation.Games
{
    public static class GraphicsExtensions
    {
        public static void FillRoundedRectangle(this Graphics g, Brush brush, RectangleF rect, float radius)
        {
            using (var path = new GraphicsPath())
            {
                path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
                path.AddArc(rect.Right - radius, rect.Y, radius, radius, 270, 90);
                path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90);
                path.AddArc(rect.X, rect.Bottom - radius, radius, radius, 90, 90);
                path.CloseFigure();
                g.FillPath(brush, path);
            }
        }
    }

    public enum CardSuit
    {
        Clubs,
        Diamonds,
        Hearts,
        Spades
    }

    public class Card
    {
        public CardSuit Suit { get; set; }
        public int Rank { get; set; } // 2-14 (14 = Ace for most games, 1 = Ace for some)

        public Card(CardSuit suit, int rank)
        {
            Suit = suit;
            Rank = rank;
        }

        public string GetSuitString()
        {
            return Suit switch
            {
                CardSuit.Hearts => "♥",
                CardSuit.Diamonds => "♦",
                CardSuit.Clubs => "♣",
                CardSuit.Spades => "♠",
                _ => "?"
            };
        }

        public string GetSuitName()
        {
            return Suit.ToString();
        }

        public Color GetSuitColor()
        {
            return (Suit == CardSuit.Hearts || Suit == CardSuit.Diamonds)
                ? Color.Crimson
                : Color.Black;
        }

        public Brush GetSuitBrush()
        {
            return (Suit == CardSuit.Hearts || Suit == CardSuit.Diamonds)
                ? Brushes.Crimson
                : Brushes.Black;
        }

        public string GetRankString()
        {
            return Rank switch
            {
                1 => "A",  // Ace low (used in FreeCell)
                11 => "J",
                12 => "Q",
                13 => "K",
                14 => "A", // Ace high (used in most games)
                _ => Rank.ToString()
            };
        }

        public int GetValue()
        {
            // Standard card value for scoring
            if (Rank >= 10) return 10;
            if (Rank == 1) return 1;  // Ace low
            if (Rank == 14) return 1; // Ace high (for Gin Rummy)
            return Rank;
        }

        public int GetHeartsPoints()
        {
            if (Suit == CardSuit.Hearts) return 1;
            if (Suit == CardSuit.Spades && Rank == 12) return 13; // Queen of Spades
            return 0;
        }

        public override string ToString()
        {
            return $"{GetRankString()}{GetSuitString()}";
        }

        public static List<Card> CreateStandardDeck(bool aceHigh = true)
        {
            var deck = new List<Card>();
            int startRank = aceHigh ? 2 : 1;
            int endRank = aceHigh ? 14 : 13;

            foreach (CardSuit suit in Enum.GetValues(typeof(CardSuit)))
            {
                for (int rank = startRank; rank <= endRank; rank++)
                {
                    // Skip ace low if ace high is also included
                    if (aceHigh && rank == 1) continue;
                    deck.Add(new Card(suit, rank));
                }
            }
            return deck;
        }

        public static List<Card> ShuffleDeck(List<Card> deck)
        {
            var rnd = new Random();
            return deck.OrderBy(_ => rnd.Next()).ToList();
        }
    }

    // Deck class for managing a collection of cards
    public class Deck
    {
        public List<Card> Cards { get; private set; }

        public Deck(bool aceHigh = true)
        {
            Cards = Card.CreateStandardDeck(aceHigh);
        }

        public void Shuffle()
        {
            Cards = Card.ShuffleDeck(Cards);
        }

        public Card Draw()
        {
            if (Cards.Count == 0)
                throw new InvalidOperationException("No cards left in deck");

            var card = Cards[0];
            Cards.RemoveAt(0);
            return card;
        }

        public int Count => Cards.Count;
    }
}