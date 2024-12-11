namespace Hotelbuchungssystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        //Zimmerklasse
        public class Room
        {
            public int RoomNumber { get; set; }
            public string Category { get; set; }
            public decimal Price { get; set; }
            public bool IsBooked { get; set; } //true = gebucht, false = verfügbar
        }

        //Buchungsklasse
        public class Booking
        {
            public Room Room { get; set; }
            public string GuestName { get; set; }
            public DateTime StartDate { get; set; }
            public DateTime EndDate { get; set; }
        }
        static void Main(string[] args)
        {
            //Beispielzimmer erstellen
            List<Room> rooms = new List<Room>
        {
            new Room { RoomNumber = 101, Category = "Einzelzimmer", Price = 50.00m, IsBooked = false },
            new Room { RoomNumber = 102, Category = "Doppelzimmer", Price = 90.00m, IsBooked = false },
            new Room { RoomNumber = 103, Category = "Einzelzimmer", Price = 55.00m, IsBooked = false },
            new Room { RoomNumber = 104, Category = "Doppelzimmer", Price = 100.00m, IsBooked = false },
        };

            List<Booking> bookings = new List<Booking>();

            //Menü anzeigen
            ShowMainMenu(rooms, bookings);
        }

