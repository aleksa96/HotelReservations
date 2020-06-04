using System;

namespace RoomReservations
{
    class Hotel
    {
        private int size;
        private int days;
        private int[,] calendar;

        public Hotel(int size)
        {
            // Validation
            if (size > 1000)
            {
                Console.WriteLine("The size of hotel must be 1000 or less.");
                return;
            }

            this.size = size;
            this.days = 365;
            Console.WriteLine("Reservation days " + days + "; Number of rooms " + size);
            calendar = makeHotelCalendar(size, days);
        }

        public Hotel(int size, int days)
        {
            // Validation
            if (days <= 0)
            {
                Console.WriteLine("Reservation days must be more than 0.");
                return;
            }
            if (days > 365)
            {
                Console.WriteLine("Bookings are limited to one year(365 days).");
                return;
            }
            if (size > 1000)
            {
                Console.WriteLine("The size of hotel must be 1000 or less.");
                return;
            }
            if (size <= 0)
            {
                Console.WriteLine("The size of hotel must more then 0.");
                return;
            }

            this.days = days;
            this.size = size;
            Console.WriteLine("Reservation days " + days + "; Number of rooms " + size);
            calendar = makeHotelCalendar(size, days);
        }

        public void printCalendar()
        {
            Console.WriteLine("Hotel Calendar:");
            for (int room = 0; room < calendar.GetLength(0); room++)
            {
                for (int day = 0; day < calendar.GetLength(1); day++)
                {
                    Console.Write(calendar[room, day] + "\t");
                }
                Console.WriteLine();
            }
        }

        private int[,] makeHotelCalendar(int rooms, int days)
        {
            calendar = new int[rooms, days];
            for (int room = 0; room < rooms; room++)
            {
                for (int day = 0; day < days; day++)
                {
                    calendar[room, day] = 0;
                }
            }
            return calendar;
        }

        public void reservation(int startDay, int endDay)
        {
            int room = -1;

            // Validation
            if (startDay < 0)
            {
                Console.WriteLine("Start day must be positive.");
                return;
            }
            if (startDay > endDay)
            {
                Console.WriteLine("Start day must be equal as end date or less.");
                return;
            }
            if (endDay > days)
            {
                Console.WriteLine("End day must be less then " + days + ".");
                return;
            }

            // Check if room is available
            bool isRoomAvailable = true;
            for (int roomNumber = 0; roomNumber < calendar.GetLength(0); roomNumber++)
            {
                isRoomAvailable = true;
                for (int day = startDay; day <= endDay; day++)
                {
                    // Check out and check in can be in same day
                    if (day != startDay && calendar[roomNumber, day] == 1)
                    {
                        isRoomAvailable = false;
                        break;
                    }
                }
                if (isRoomAvailable)
                {
                    room = roomNumber;
                    break;
                }
            }

            // If room is available make reservation, 
            // else show message that there are no rooms available for selected dates
            if (isRoomAvailable)
            {
                for (int day = startDay; day <= endDay; day++)
                {
                    calendar[room, day] = 1;
                }
                Console.WriteLine("Reservation from: " + startDay + " to: " + endDay +
                    " ---> Accept! Room: " + (room + 1));
            }
            else
            {
                Console.WriteLine("Reservation from: " + startDay + " to: " + endDay +
                    " ---> Dennied! No rooms available for chosen dates.");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // test case 1a/1b
            Console.WriteLine("\nTest case 1a/1b");
            Hotel hotelOne = new Hotel(1);
            hotelOne.reservation(-4, 2);
            hotelOne.reservation(200, 400);

            // test case 2
            Console.WriteLine("\nTest case 2");
            Hotel hotelTwo = new Hotel(3);
            hotelTwo.reservation(0, 5);
            hotelTwo.reservation(7, 13);
            hotelTwo.reservation(3, 9);
            hotelTwo.reservation(5, 7);
            hotelTwo.reservation(6, 6);
            hotelTwo.reservation(0, 4);

            // test case 3
            Console.WriteLine("\nTest case 3");
            Hotel hotelThree = new Hotel(3);
            hotelThree.reservation(1, 3);
            hotelThree.reservation(2, 5);
            hotelThree.reservation(1, 9);
            hotelThree.reservation(0, 15);

            // test case 4
            Console.WriteLine("\nTest case 4");
            Hotel hotelFour = new Hotel(3);
            hotelFour.reservation(1, 3);
            hotelFour.reservation(0, 15);
            hotelFour.reservation(1, 9);
            hotelFour.reservation(2, 5);
            hotelFour.reservation(4, 9);

            // test case 5
            Console.WriteLine("\nTest case 5");
            Hotel hotelFive = new Hotel(2);
            hotelFive.reservation(1, 3);
            hotelFive.reservation(0, 4);
            hotelFive.reservation(2, 3);
            hotelFive.reservation(5, 5);
            hotelFive.reservation(4, 10);
            hotelFive.reservation(10, 10);
            hotelFive.reservation(6, 7);
            hotelFive.reservation(8, 10);
            hotelFive.reservation(8, 9);

            // hotelFive.printCalendar ();

        }
    }
}