﻿using System;
using System.Collections.Generic;

namespace HTTP_Web_Services_POST_PUT_DELETE_lecture
{
    class Program
    {
        private static readonly APIService apiService = new APIService("http://localhost:3000/");
        private static readonly ConsoleService console = new ConsoleService();

        static void Main(string[] args)
        {
            Run();
        }
        private static void Run()
        {
            Console.WriteLine("Welcome to Online Hotels! Please make a selection:");
            MenuSelection();
        }

        private static void MenuSelection()
        {
            int menuSelection = -1;
            while (menuSelection != 0)
            {
                Console.WriteLine("");
                Console.WriteLine("Menu:");
                Console.WriteLine("1: List Hotels");
                Console.WriteLine("2: List Reservations for Hotel");
                Console.WriteLine("3: Create new Reservation for Hotel");
                Console.WriteLine("4: Update existing Reservation for Hotel");
                Console.WriteLine("5: Delete Reservation");
                Console.WriteLine("0: Exit");
                Console.WriteLine("---------");
                Console.Write("Please choose an option: ");

                if (!int.TryParse(Console.ReadLine(), out menuSelection))
                {
                    Console.WriteLine("Invalid input. Only input a number.");
                    menuSelection = -1;
                }
                else if (menuSelection == 1)
                {
                    try
                    {
                        List<Hotel> hotels = apiService.GetHotels();
                        if (hotels != null && hotels.Count > 0)
                        {
                            console.PrintHotels(hotels);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"ERROR: {ex.Message}");
                    }
                }
                else if (menuSelection == 2)
                {
                    try
                    {
                        List<Hotel> hotels = apiService.GetHotels();
                        if (hotels != null && hotels.Count > 0)
                        {
                            int hotelId = console.PromptForHotelID(hotels, "list reservations");
                            if (hotelId != 0)
                            {
                                List<Reservation> reservations = apiService.GetReservations(hotelId);
                                if (reservations != null)
                                {
                                    console.PrintReservations(reservations, hotelId);
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"ERROR: {ex.Message}");
                    }
                }
                else if (menuSelection == 3)
                {
                    // Create new reservation
                    try
                    {


                        string newReservationString = console.PromptForReservationData();
                        Reservation reservationToAdd = new Reservation(newReservationString);

                        if (reservationToAdd.IsValid)
                        {
                            Reservation addedReservation = apiService.AddReservation(reservationToAdd);
                            if (addedReservation != null)
                            {
                                Console.WriteLine("Reservation successfully added.");
                            }
                            else
                            {
                                Console.WriteLine("Reservation not added.");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"ERROR: {ex.Message}");
                    }
                }
                else if (menuSelection == 4)
                {
                    // Update an existing reservation
                    try
                    {


                        List<Reservation> reservations = apiService.GetReservations();
                        if (reservations != null)
                        {
                            int reservationId = console.PromptForReservationID(reservations, "update");
                            Reservation oldReservation = apiService.GetReservation(reservationId);
                            if (oldReservation != null)
                            {
                                string updReservationString = console.PromptForReservationData(oldReservation);
                                Reservation reservationToUpdate = new Reservation(updReservationString);

                                if (reservationToUpdate.IsValid)
                                {
                                    Reservation updatedReservation = apiService.UpdateReservation(reservationToUpdate);
                                    if (updatedReservation != null)
                                    {
                                        Console.WriteLine("Reservation successfully updated.");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Reservation not updated.");
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"ERROR: {ex.Message}");
                    }

                }
                else if (menuSelection == 5)
                {
                    // Delete reservation
                    try
                    {


                        List<Reservation> reservations = apiService.GetReservations();
                        if (reservations != null)
                        {
                            int reservationId = console.PromptForReservationID(reservations, "delete");
                            apiService.DeleteReservation(reservationId);
                            Console.WriteLine("Your reservation has been deleted.");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"ERROR: {ex.Message}");
                    }
                }
                else if (menuSelection == 0)
                {
                    Console.WriteLine("Goodbye!");
                    Environment.Exit(0);
                }
            }
        }
    }
}
