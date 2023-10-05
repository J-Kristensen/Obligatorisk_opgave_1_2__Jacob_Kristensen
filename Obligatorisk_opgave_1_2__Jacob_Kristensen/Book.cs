namespace Obligatorisk_opgave_1_2__Jacob_Kristensen
{
    public class Book
    {
		public int Id { get; set; }
        public string? Title { get; set; }
        public int Price { get; set; }

        public Book(int id, string title, int price)
        {
            Id = id;
            Title = title;
            Price = price;
        }
        public Book()
        { 
        }   

        /// <summary>
        /// Returns key values of Book
        /// </summary>
        /// <returns>ID, Title, Price</returns>
        public override string ToString()
        {
            return $"Id: {Id}, Title: {Title}, Price: {Price}";
        }


        /// <summary>
        /// Validates the length of the title based on the specifications
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        public void ValidateTitle()
        {
            if (Title == null)
            {
                throw new ArgumentNullException("Title is null");
            }
            if (Title.Length < 3)
            {
                throw new ArgumentOutOfRangeException("Title is too short");
            }
        }

        /// <summary>
        /// Validates price to be between 0 and 1200 based on specifications
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void ValidatePrice()
        {
            if (Price < 1)
            {
                throw new ArgumentOutOfRangeException("Price is too low");
            }
            if (Price > 1200)
            {
                throw new ArgumentOutOfRangeException("Price is too high");
            }
        }


        /// <summary>
        /// Validates Book title and price using the ValidateTitle and ValidatePrice methods
        /// </summary>
        public void ValidateBook()
        {
            ValidateTitle();
            ValidatePrice();
        }
	}
}