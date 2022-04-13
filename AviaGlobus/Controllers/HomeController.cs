using AviaGlobus.Models;
using AviaGlobus.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace AviaGlobus.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationContext db;
        public User LoggedUser;

        public HomeController(ApplicationContext context)
        {
            db = context;
        }

        public IActionResult Users(User admin, string lastname, int? id, string login, SortState sortOrder = SortState.IdAsc)
        {
            IQueryable<User> users = db.Users;
            IQueryable<Role> roles = db.Roles;

            //Фльтрация или поиск
            if (id != null && id > 0)
                users = users.Where(p => p.ID_User == id);

            if (!String.IsNullOrEmpty(lastname))
                users = users.Where(p => p.Lastname.Contains(lastname));

            if (!String.IsNullOrEmpty(login))
                users = users.Where(p => p.Login.Contains(login));

            //Сортровка
            switch (sortOrder)
            {
                case SortState.IdAsc:
                    {
                        users = users.OrderBy(m => m.ID_User);
                        break;
                    }
                case SortState.IdDesc:
                    {
                        users = users.OrderByDescending(m => m.ID_User);
                        break;
                    }
                case SortState.LastnameAsc:
                    {
                        users = users.OrderBy(m => m.Lastname);
                        break;
                    }
                case SortState.LastnameDesc:
                    {
                        users = users.OrderByDescending(m => m.Lastname);
                        break;
                    }
                case SortState.LoginAsc:
                    {
                        users = users.OrderBy(m => m.Login);
                        break;
                    }
                case SortState.LoginDesc:
                    {
                        users = users.OrderByDescending(m => m.Login);
                        break;
                    }
                default:
                    {
                        users = users.OrderBy(m => m.ID_User);
                        break;
                    }
            }

            UserViewModel userViewModel = new UserViewModel
            {
                Users = users.ToList(),
                Roles = roles,
                Admin = admin,
                FilterUserViewModel = new FilterUserViewModel(id, lastname, login),
                SortUserViewModel = new SortUserViewModel(sortOrder)
            };
            LoggedUser = admin;
            return View(userViewModel);
        }

        public IActionResult Flights(User admin, int? id, string departurePoint, string arrivalPoint, SortStateFlight sortOrder = SortStateFlight.IdAsc)
        {
            IQueryable<Flight> flights = db.Flight;
            IQueryable<FlightType> flightTypes = db.FlightType;
            IQueryable<Status> statuses = db.Status;
            IQueryable<PlaneType> planeTypes = db.PlaneType;
            IQueryable<User> users = db.Users;

            foreach (var flight in flights)
            {
                if (flight.Departure_Date < DateTime.Today)
                {
                    flight.Status_ID = 4;
                }
                db.Flight.Update(flight);
                db.SaveChangesAsync();
            }

            //Фльтрация или поиск
            if (id != null && id > 0)
                flights = flights.Where(p => p.ID_Flight == id);

            if (!String.IsNullOrEmpty(departurePoint))
                flights = flights.Where(p => p.Departure_Point.Contains(departurePoint));

            if (!String.IsNullOrEmpty(arrivalPoint))
                flights = flights.Where(p => p.Arrival_Point.Contains(arrivalPoint));

            //Сортровка
            switch (sortOrder)
            {
                case SortStateFlight.IdAsc:
                    {
                        flights = flights.OrderBy(m => m.ID_Flight);
                        break;
                    }
                case SortStateFlight.IdDesc:
                    {
                        flights = flights.OrderByDescending(m => m.ID_Flight);
                        break;
                    }
                case SortStateFlight.DeparturePointAsc:
                    {
                        flights = flights.OrderBy(m => m.Departure_Point);
                        break;
                    }
                case SortStateFlight.DeparturePointDesc:
                    {
                        flights = flights.OrderByDescending(m => m.Departure_Point);
                        break;
                    }
                case SortStateFlight.DepartureDateAsc:
                    {
                        flights = flights.OrderBy(m => m.Departure_Date);
                        break;
                    }
                case SortStateFlight.DepartureDateDesc:
                    {
                        flights = flights.OrderByDescending(m => m.Departure_Date);
                        break;
                    }
                case SortStateFlight.ArrivalPointAsc:
                    {
                        flights = flights.OrderBy(m => m.Arrival_Point);
                        break;
                    }
                case SortStateFlight.ArrivalPointDesc:
                    {
                        flights = flights.OrderByDescending(m => m.Arrival_Point);
                        break;
                    }
                default:
                    {
                        flights = flights.OrderBy(m => m.ID_Flight);
                        break;
                    }
            }

            FlightsViewModel flightsView = new FlightsViewModel
            {
                Flight = flights,
                FlightTypes = flightTypes,
                Statuses = statuses,
                PlaneTypes = planeTypes,
                Admin = admin,
                FilterFlightViewModel = new FilterFlightViewModel(id, departurePoint, arrivalPoint),
                SortFlightViewModel = new SortFlightViewModel(sortOrder)
            };
            LoggedUser = admin;
            return View(flightsView);
        }

        public IActionResult Cashier(User admin, int? id, string departurePoint, string arrivalPoint, SortStateFlight sortOrder = SortStateFlight.IdAsc)
        {
            IQueryable<Flight> flights = db.Flight;
            IQueryable<FlightType> flightTypes = db.FlightType;
            IQueryable<Status> statuses = db.Status;
            IQueryable<PlaneType> planeTypes = db.PlaneType;
            IQueryable<User> users = db.Users;

            foreach (var flight in flights)
            {
                if (flight.Departure_Date < DateTime.Today)
                {
                    flight.Status_ID = 4;
                }
                db.Flight.Update(flight);
                db.SaveChangesAsync();
            }

            //Фльтрация или поиск
            if (id != null && id > 0)
                flights = flights.Where(p => p.ID_Flight == id);

            if (!String.IsNullOrEmpty(departurePoint))
                flights = flights.Where(p => p.Departure_Point.Contains(departurePoint));

            if (!String.IsNullOrEmpty(arrivalPoint))
                flights = flights.Where(p => p.Arrival_Point.Contains(arrivalPoint));

            //Сортровка
            switch (sortOrder)
            {
                case SortStateFlight.IdAsc:
                    {
                        flights = flights.OrderBy(m => m.ID_Flight);
                        break;
                    }
                case SortStateFlight.IdDesc:
                    {
                        flights = flights.OrderByDescending(m => m.ID_Flight);
                        break;
                    }
                case SortStateFlight.DeparturePointAsc:
                    {
                        flights = flights.OrderBy(m => m.Departure_Point);
                        break;
                    }
                case SortStateFlight.DeparturePointDesc:
                    {
                        flights = flights.OrderByDescending(m => m.Departure_Point);
                        break;
                    }
                case SortStateFlight.DepartureDateAsc:
                    {
                        flights = flights.OrderBy(m => m.Departure_Date);
                        break;
                    }
                case SortStateFlight.DepartureDateDesc:
                    {
                        flights = flights.OrderByDescending(m => m.Departure_Date);
                        break;
                    }
                case SortStateFlight.ArrivalPointAsc:
                    {
                        flights = flights.OrderBy(m => m.Arrival_Point);
                        break;
                    }
                case SortStateFlight.ArrivalPointDesc:
                    {
                        flights = flights.OrderByDescending(m => m.Arrival_Point);
                        break;
                    }
                default:
                    {
                        flights = flights.OrderBy(m => m.ID_Flight);
                        break;
                    }
            }

            FlightsViewModel flightsView = new FlightsViewModel
            {
                Flight = flights,
                FlightTypes = flightTypes,
                Statuses = statuses,
                PlaneTypes = planeTypes,
                Admin = admin,
                FilterFlightViewModel = new FilterFlightViewModel(id, departurePoint, arrivalPoint),
                SortFlightViewModel = new SortFlightViewModel(sortOrder)
            };
            LoggedUser = admin;
            return View(flightsView);
        }

        public IActionResult TicketSales(int id)
        {
            TicketViewModel ticketModel = new TicketViewModel
            {
                ID_Flyght = id,
                Flight = db.Flight,
                PassportType = db.PassportType,
                SelectFlight = db.Flight.Where(o => o.ID_Flight == id).FirstOrDefault()
            };
            return View(ticketModel);
        }

        public IActionResult AddUser()
        {
            IQueryable<Role> roles = db.Roles;
            AddUserViewModel addUserViewModel = new AddUserViewModel
            {
                Roles = roles,
                LoggedUser = LoggedUser
            };
            return View(addUserViewModel);
        }

        public AddFlightViewModel ReturnFlight(AddFlightViewModel flight)
        {
            flight.Statuses = db.Status;
            flight.FlightTypes = db.FlightType;
            flight.PlaneTypes = db.PlaneType;
            flight.LoggedUser = this.LoggedUser;

            return flight;
        }
        public IActionResult AddFlight()
        {
            AddFlightViewModel addFlightModel = new AddFlightViewModel
            {
                Statuses = db.Status,
                FlightTypes = db.FlightType,
                PlaneTypes = db.PlaneType,
                LoggedUser = this.LoggedUser
            };
            return View(addFlightModel);
        }
        [HttpPost]
        public async Task<IActionResult> AddFlight(AddFlightViewModel flight, DateTime departureDate, DateTime arrivalDate, int cost, string arrivalTime, string departureTime, int places, int status, int flight_type, int plane_type)
        {
            if (ModelState.IsValid)
            {

                if (flight.Departure_Point == flight.Arrival_Point ||
                   flight.Departure_Point == flight.Transfer_Point ||
                   flight.Transfer_Point == flight.Arrival_Point)
                {
                    flight = ReturnFlight(flight);
                    ModelState.AddModelError("departure_point", "Пункты отправления, прибытия и пересадки не могут повторятсья!");
                    return View(flight);
                }
                if (departureDate == arrivalDate && departureTime == arrivalTime)
                {
                    flight = ReturnFlight(flight);
                    ModelState.AddModelError("departure_point", "Проверьте время отправления и время прилета!");
                    return View(flight);
                }
                if (departureDate > arrivalDate)
                {
                    flight = ReturnFlight(flight);
                    ModelState.AddModelError("departure_point", "Дата прилета не может быть раньше даты вылета!");
                    return View(flight);
                }
                if (cost < 1000)
                {
                    flight = ReturnFlight(flight);
                    ModelState.AddModelError("departure_point", "Цена билета должна быть больше 1000!");
                    return View(flight);
                }
                DateTime time = DateTime.Parse(departureTime, System.Globalization.CultureInfo.CurrentCulture);
                Console.WriteLine(time.ToString("HH:mm"));
                if (time.Hour > 23 || time.Hour < 3)
                {
                    cost = (int)(cost * 0.85);
                }

                db.Flight.Add(new Flight
                {
                    Ticket_Cost = Convert.ToDecimal(cost),
                    Departure_Point = flight.Departure_Point,
                    Arrival_Point = flight.Arrival_Point,
                    Departure_Date = Convert.ToDateTime(departureDate.ToShortDateString()),
                    Arrival_Date = Convert.ToDateTime(arrivalDate.ToShortDateString()),
                    Departure_Time = departureTime,
                    Places_Left = places,
                    Arrival_Time = arrivalTime,
                    Transfer_Point = flight.Transfer_Point,
                    Status_ID = status,
                    Flight_Type_ID = flight_type,
                    Plane_Type_ID = plane_type,
                });
                await db.SaveChangesAsync();
                return RedirectToAction("Flights", LoggedUser);
            }
            flight.Statuses = db.Status;
            flight.FlightTypes = db.FlightType;
            flight.PlaneTypes = db.PlaneType;
            flight.LoggedUser = this.LoggedUser;
            return View(flight);
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(AddUserViewModel user, int role)
        {
            if (ModelState.IsValid)
            {
                User u = db.Users.Where(o => o.Login == user.Login).FirstOrDefault();

                if (u == null)
                {
                    db.Users.Add(new User
                    {
                        Login = user.Login,
                        Password = user.Password,
                        Lastname = user.Lastname,
                        Firstname = user.Firstname,
                        Patronymic = user.Patronymic,
                        Role_ID = role
                    });

                    await db.SaveChangesAsync();
                    return RedirectToAction("Users", LoggedUser);
                }
                return RedirectToAction("Users", LoggedUser);
            }

            IQueryable<Role> roles = db.Roles;
            AddUserViewModel addUserViewModel = new AddUserViewModel
            {
                Roles = roles,
                LoggedUser = LoggedUser
            };
            return View(addUserViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> TicketSales(TicketViewModel ticket)
        {
            if (ModelState.IsValid)
            {
                var flight = db.Flight.FirstOrDefault(o => o.ID_Flight == ticket.ID_Flyght);
                int passport_type = (flight.Flight_Type_ID == 1) ? 1 : 2;
                ticket.SelectFlight = db.Flight.Where(o => o.ID_Flight == ticket.ID_Flyght).FirstOrDefault();

                if (passport_type == 2 && ticket.Passport_Series.Length != 2)
                {
                    ModelState.AddModelError("passport_series", "Серия загран паспорта должна иметь только 2 цифры");
                    return View(ticket);
                }
                if (passport_type == 2 && ticket.Passport_Number.Length != 7)
                {
                    ModelState.AddModelError("passport_number", "Номер загран паспорта должен иметь только 7 цифр");
                    return View(ticket);
                }
                if (passport_type == 1 && ticket.Passport_Series.Length != 4)
                {
                    ModelState.AddModelError("passport_series", "Серия паспорта должна иметь только 4 цифры");
                    return View(ticket);
                }
                if (passport_type == 1 && ticket.Passport_Number.Length != 6)
                {
                    ModelState.AddModelError("passport_number", "Номер паспорта должен иметь только 6 цифр");
                    return View(ticket);
                }

                db.Passenger.Add(new Passenger
                {
                    Lastname = ticket.Lastname,
                    Firstname = ticket.Firstname,
                    Patronymic = ticket.Patronymic,
                    Passport_Series = ticket.Passport_Series.ToString(),
                    Passport_Number = ticket.Passport_Number.ToString(),
                    Flight_ID = ticket.ID_Flyght,
                    Passport_Type_ID = passport_type
                });

                flight.Places_Left--;
                db.Flight.Update(flight);

                ticket.SelectFlight = db.Flight.Where(o => o.ID_Flight == ticket.ID_Flyght).FirstOrDefault();
                await db.SaveChangesAsync();
                return RedirectToAction("Export", ticket);
            }
            ticket.SelectFlight = db.Flight.Where(o => o.ID_Flight == ticket.ID_Flyght).FirstOrDefault();
            ticket.Flight = db.Flight;
            ticket.PassportType = db.PassportType;
            return View(ticket);
        }

        [HttpGet("export")]
        public IActionResult Export(TicketViewModel ticket)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            ticket.SelectFlight = db.Flight.Where(o => o.ID_Flight == ticket.ID_Flyght).FirstOrDefault();

            using var package = new ExcelPackage();

            var sheet = package.Workbook.Worksheets.Add("Data");

            sheet.Cells["A1"].Value = "№ Рейса:";
            sheet.Cells["A2"].Value = "Пункт отправления:";
            sheet.Cells["A3"].Value = "Пункт прибытия:";
            sheet.Cells["A4"].Value = "Пункт пересадки:";
            sheet.Cells["A5"].Value = "Дата отправления:";
            sheet.Cells["A6"].Value = "Время отправления:";
            sheet.Cells["A7"].Value = "Дата прибытия:";
            sheet.Cells["A8"].Value = "Время прибытия:";
            sheet.Cells["A9"].Value = "ФИО:";
            sheet.Cells["A10"].Value = "Серия паспорта:";
            sheet.Cells["A11"].Value = "Номер паспорта:";
            sheet.Cells["A12"].Value = "Цена билета:";

            sheet.Cells["A1:A12"].Style.Font.Bold = true;

            sheet.Cells["B1"].Value = ticket.SelectFlight.ID_Flight;
            sheet.Cells["B2"].Value = ticket.SelectFlight.Departure_Point;
            sheet.Cells["B3"].Value = ticket.SelectFlight.Arrival_Point;
            sheet.Cells["B4"].Value = ticket.SelectFlight.Transfer_Point;
            sheet.Cells["B5"].Value = ticket.SelectFlight.Departure_Date.ToString("dd.MM.yyyy");
            sheet.Cells["B6"].Value = ticket.SelectFlight.Departure_Time;
            sheet.Cells["B7"].Value = ticket.SelectFlight.Arrival_Date.ToString("dd.MM.yyyy");
            sheet.Cells["B8"].Value = ticket.SelectFlight.Arrival_Time;
            sheet.Cells["B9"].Value = $"{ticket.Lastname} {ticket.Firstname} {ticket.Patronymic}";
            sheet.Cells["B10"].Value = ticket.Passport_Series;
            sheet.Cells["B11"].Value = ticket.Passport_Number;
            sheet.Cells["B12"].Value = ticket.SelectFlight.Ticket_Cost;

            var range = sheet.Cells["A1:B12"];
            range.AutoFitColumns();
            range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

            var bytes = package.GetAsByteArray();
            var result = new FileContentResult(bytes, "application/octet-stream")
            {
                FileDownloadName = $"Билет:{ticket.Lastname} - {ticket.SelectFlight.Departure_Date.ToString("dd.MM.yyyy")}.xlsx"
            };
            return result;
        }

        [HttpGet] //Удаление пользователя без подтверждения
        public async Task<IActionResult> DeleteUser(int? id)
        {
            if (id != null)
            {
                User user = await db.Users.FirstOrDefaultAsync(predicate => predicate.ID_User == id);
                if (user != null)
                {
                    db.Users.Remove(user);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Users");
                }
            }
            return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> DeleteFlight(int? id)
        {
            if (id != null)
            {
                Flight flight = await db.Flight.FirstOrDefaultAsync(predicate => predicate.ID_Flight == id);
                if (flight != null)
                {
                    foreach (var passenger in db.Passenger)
                    {
                        if (passenger.Flight_ID == id)
                            db.Passenger.Remove(passenger);
                    }
                    db.Flight.Remove(flight);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Flights");
                }
            }
            return NotFound();
        }

        public async Task<IActionResult> EditUser(int? id)
        {
            if (id != null)
            {
                User user = await db.Users.FirstOrDefaultAsync(predicate => predicate.ID_User == id);
                AddUserViewModel addUserViewModel = new AddUserViewModel
                {
                    Login = user.Login,
                    Password = user.Password,
                    Lastname = user.Lastname,
                    Firstname = user.Firstname,
                    Patronymic = user.Patronymic,
                    Role_ID = user.Role_ID,
                    LoggedUser = LoggedUser,
                    Roles = db.Roles
                };
                if (user != null)
                {
                    return View(addUserViewModel);
                }
            }
            return NotFound();
        }    

        public async Task<IActionResult> EditFlight(int? id)
        {
            if (id != null)
            {
                Flight flight = await db.Flight.FirstOrDefaultAsync(predicate => predicate.ID_Flight == id);
                AddFlightViewModel addFlightViewModel = new AddFlightViewModel
                {
                    Ticket_Cost = flight.Ticket_Cost,
                    Departure_Date = flight.Departure_Date,
                    Departure_Point = flight.Departure_Point,
                    Departure_Time = flight.Departure_Time,
                    Arrival_Date = flight.Arrival_Date,
                    Arrival_Point = flight.Arrival_Point,
                    Arrival_Time = flight.Arrival_Time,
                    Transfer_Point = flight.Transfer_Point,
                    Places_Left = flight.Places_Left,
                    FlightTypes = db.FlightType,
                    PlaneTypes = db.PlaneType,
                    Statuses = db.Status,
                    Flight_Type_ID = flight.Flight_Type_ID,
                    Plane_Type_ID = flight.Plane_Type_ID,
                    Status_ID = flight.Status_ID,
                    LoggedUser = LoggedUser
                };
                if (flight != null)
                {
                    return View(addFlightViewModel);
                }
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> EditFlight(AddFlightViewModel flight,
            DateTime departureDate, DateTime arrivalDate, int cost,
            string arrivalTime, string departureTime, int places, int status,
            int flight_type, int plane_type)
        {
            if (flight.Departure_Point == flight.Arrival_Point ||
                   flight.Departure_Point == flight.Transfer_Point ||
                   flight.Transfer_Point == flight.Arrival_Point)
            {
                flight = ReturnFlight(flight);
                ModelState.AddModelError("departure_point", "Пункты отправления, прибытия и пересадки не могут повторятсья!");
                return View(flight);
            }
            if (departureDate == arrivalDate && departureTime == arrivalTime)
            {
                flight = ReturnFlight(flight);
                ModelState.AddModelError("departure_point", "Проверьте время отправления и время прилета!");
                return View(flight);
            }
            if (departureDate > arrivalDate)
            {
                flight = ReturnFlight(flight);
                ModelState.AddModelError("departure_point", "Дата прилета не может быть раньше даты вылета!");
                return View(flight);
            }
            if (cost < 1000)
            {
                flight = ReturnFlight(flight);
                ModelState.AddModelError("departure_point", "Цена билета должна быть больше 1000!");
                return View(flight);
            }
            DateTime time = DateTime.Parse(departureTime, System.Globalization.CultureInfo.CurrentCulture);
            Console.WriteLine(time.ToString("HH:mm"));
            if (time.Hour > 23 || time.Hour < 3)
            {
                cost = (int)(cost * 0.85);
            }
            Flight updateFlight = new Flight
            {
                ID_Flight = flight.ID,
                Ticket_Cost = Convert.ToDecimal(cost),
                Departure_Date = Convert.ToDateTime(departureDate.ToShortDateString()),
                Arrival_Date = Convert.ToDateTime(arrivalDate.ToShortDateString()),
                Departure_Point = flight.Departure_Point,
                Departure_Time = departureTime,
                Arrival_Point = flight.Arrival_Point,
                Arrival_Time = arrivalTime,
                Transfer_Point = flight.Transfer_Point,
                Places_Left = places,
                Flight_Type_ID = flight_type,
                Plane_Type_ID = plane_type,
                Status_ID = status
            };
            db.Flight.Update(updateFlight);
            await db.SaveChangesAsync();
            return RedirectToAction("Flights", LoggedUser);
        }


        // public IActionResult Privacy()
        // {
        //     foreach (var roles in db.Roles)
        //     {
        //         Role role = roles;
        //         Console.WriteLine(role.Title);
        //     }
        //     return View();
        // }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}