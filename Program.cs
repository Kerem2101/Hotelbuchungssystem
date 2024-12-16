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

            // Menü anzeigen
            ShowMainMenu(rooms, bookings);
        }
        // Hauptmenü
        public static void ShowMainMenu(List<Room> rooms, List<Booking> bookings)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Willkommen im Hotelbuchungssystem!");
                Console.WriteLine("\n1. Zimmer anzeigen");
                Console.WriteLine("2. Zimmer buchen");
                Console.WriteLine("3. Zimmer stornieren");
                Console.WriteLine("4. Belegung anzeigen");
                Console.WriteLine("5. Verfügbarkeit prüfen");
                Console.WriteLine("6. Programm beenden");
                Console.Write("\nWählen Sie eine Option: ");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        DisplayRooms(rooms);
                        break;
                    case "2":
                        BookRoom(rooms, bookings);
                        break;
                    case "3":
                        CancelBooking(rooms, bookings);
                        break;
                    case "4":
                        ShowOccupancy(bookings);
                        break;
                    case "5":
                        CheckAvailability(rooms);
                        break;
                    case "6":
                        return;
                    default:
                        Console.WriteLine("Ungültige Auswahl. Versuchen Sie es erneut.");
                        break;
                }
            }
        }

        // Zimmer anzeigen
        public static void DisplayRooms(List<Room> rooms)
        {
            Console.Clear();
            Console.WriteLine("Zimmer im Hotel:");
            foreach (var room in rooms)
            {
                Console.WriteLine($"\nZimmernummer: {room.RoomNumber}, Kategorie: {room.Category}, Preis: {room.Price:C}, Status: {(room.IsBooked ? "Gebucht" : "Verfügbar")}");
            }
            Console.WriteLine("\n\nDrücken Sie eine beliebige Taste, um zum Menü zurückzukehren.");
            Console.ReadKey();
        }

        // Zimmer buchen
        public static void BookRoom(List<Room> rooms, List<Booking> bookings)
        {
            Console.Clear();
            Console.WriteLine("Zimmer buchen:");
            Console.Write("\nGeben Sie die Zimmernummer ein, die Sie buchen möchten: ");
            int roomNumber = int.Parse(Console.ReadLine());

            var room = rooms.FirstOrDefault(r => r.RoomNumber == roomNumber && !r.IsBooked);
            if (room != null)
            {
                Console.Write("\nGeben Sie Ihren Namen ein: ");
                string guestName = Console.ReadLine();

                Console.Write("\nGeben Sie das Startdatum der Buchung ein (dd.mm.yyyy): ");
                DateTime startDate = DateTime.Parse(Console.ReadLine());

                Console.Write("\nGeben Sie das Enddatum der Buchung ein (dd.mm.yyyy): ");
                DateTime endDate = DateTime.Parse(Console.ReadLine());

                room.IsBooked = true;
                bookings.Add(new Booking
                {
                    Room = room,
                    GuestName = guestName,
                    StartDate = startDate,
                    EndDate = endDate
                });

                Console.WriteLine("\nZimmer erfolgreich gebucht!");
            }
            else
            {
                Console.WriteLine("Das Zimmer ist entweder nicht verfügbar oder existiert nicht.");
            }

            Console.WriteLine("\n\nDrücken Sie eine beliebige Taste, um zum Menü zurückzukehren.");
            Console.ReadKey();
        }

        // Zimmer stornieren
        public static void CancelBooking(List<Room> rooms, List<Booking> bookings)
        {
            Console.Clear();
            Console.WriteLine("Zimmer stornieren:");
            Console.Write("\nGeben Sie die Zimmernummer der Buchung ein, die Sie stornieren möchten: ");
            int roomNumber = int.Parse(Console.ReadLine());
            var booking = bookings.FirstOrDefault(b => b.Room.RoomNumber == roomNumber);
            if (booking != null)
            {
                bookings.Remove(booking);
                booking.Room.IsBooked = false;
                Console.WriteLine("\nBuchung erfolgreich storniert!");
            }
            else
            {
                Console.WriteLine("Keine Buchung für dieses Zimmer gefunden.");
            }

            Console.WriteLine("\n\nDrücken Sie eine beliebige Taste, um zum Menü zurückzukehren.");
            Console.ReadKey();
        }

        // Belegung anzeigen
        public static void ShowOccupancy(List<Booking> bookings)
        {
            Console.Clear();
            Console.WriteLine("Aktuelle Belegung:");
            foreach (var booking in bookings)
            {
                Console.WriteLine($"\nZimmernummer: {booking.Room.RoomNumber}, Gast: {booking.GuestName}, Zeitraum: {booking.StartDate.ToShortDateString()} bis {booking.EndDate.ToShortDateString()}");
            }
            Console.WriteLine("\n\nDrücken Sie eine beliebige Taste, um zum Menü zurückzukehren.");
            Console.ReadKey();
        }

        // Verfügbarkeit prüfen
        public static void CheckAvailability(List<Room> rooms)
        {
            Console.Clear();
            Console.Write("Geben Sie die Zimmernummer ein, die Sie auf Verfügbarkeit prüfen möchten: ");
            int roomNumber = int.Parse(Console.ReadLine());

            var room = rooms.FirstOrDefault(r => r.RoomNumber == roomNumber);
            if (room != null)
            {
                Console.Write("\nGeben Sie das Startdatum der Prüfung ein (dd.mm.yyyy): ");
                DateTime startDate = DateTime.Parse(Console.ReadLine());

                Console.Write("\nGeben Sie das Enddatum der Prüfung ein (dd.mm.yyyy): ");
                DateTime endDate = DateTime.Parse(Console.ReadLine());

                if (room.IsBooked)
                {
                    Console.WriteLine($"\nZimmer {room.RoomNumber} ist für diesen Zeitraum nicht verfügbar.");
                }
                else
                {
                    Console.WriteLine($"\nZimmer {room.RoomNumber} ist für den angegebenen Zeitraum verfügbar.");
                }
            }
            else
            {
                Console.WriteLine("\nZimmer existiert nicht.");
            }

            Console.WriteLine("\n\nDrücken Sie eine beliebige Taste, um zum Menü zurückzukehren.");
            Console.ReadKey();
        }
    }
}
        



