using System.Collections.Generic;
using System.Linq;
using BusinessLogicInterface;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Model;
using WebApi.Filters;

namespace WebApi.Controllers
{
    [Route("api/bookings")]
    public class BookingController : VidlyControllerBase
    {
        private readonly IBookingLogic bookingLogic;
        public BookingController(IBookingLogic bookingLogic)
        {
            this.bookingLogic = bookingLogic;
        }
        /// <summary>
        /// Permite a un usuario obtener información de todas las reservas del sistema
        /// </summary>
        /// <response code="200">Se devuelve la información requerida</response>
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Booking> elementBookings = this.bookingLogic.GetAll();
            IEnumerable<BookingBasicModel> bookingModels =  elementBookings.Select(m => new BookingBasicModel(m));
            return Ok(bookingModels);
        }
        /// <summary>
        /// Permite a un ususario ver una reserva del sistema
        /// </summary>
        /// <param name="id">Este parámetro contiene el identificador de la reserva</param>
        /// <response code="200">Se devuelve la información requerida.</response>
        /// <response code="400">Reserva no existente con ese identificador</response>
        [HttpGet("{id}",Name="GetBooking")]
        public IActionResult GetBy([FromRoute]int id)
        {
            Booking elementBooking = this.bookingLogic.GetBy(id);
            BookingDetailModel bookingModel = new BookingDetailModel(elementBooking);
            return Ok(bookingModel);
        }
        /// <summary>
        /// Permite a un administrador realizar una reserva
        /// </summary>
        /// <param name="bookingModel">Este modelo contiene la información de la reserva</param>
        /// <response code="200">Se devuelve la información requerida.</response>
        /// <response code="400">Reserva no existente con ese identificador</response>
        [HttpPost]
        public IActionResult Post([FromBody]BookingModel bookingModel)
        {
            Booking newBooking = bookingModel.ToEntity();
            newBooking = this.bookingLogic.Add(newBooking);
            BookingBasicModel basicModel = new BookingBasicModel(newBooking);
            return CreatedAtRoute("GetBooking", new {Id = basicModel.Id} , basicModel);
        }
        /// <summary>
        /// Permite a un administrador modificar una reserva
        /// </summary>
        /// <param name="id">Este parámetro contiene el identificador de la reserva</param>
        /// <param name="bookingModel">Este modelo contiene la información de la reserva</param>
        /// <response code="200">Se devuelve la información requerida.</response>
        /// <response code="400">Reserva no existente con ese identificador</response>
        [HttpPut("{id}")]
        [AuthorizationFilter]
        public IActionResult Put([FromRoute]int id,[FromBody]BookingModel bookingModel)
        {
            Booking newBooking = bookingModel.ToEntity(false);
            newBooking = this.bookingLogic.Update(id, newBooking);
            BookingBasicModel basicModel = new BookingBasicModel(newBooking);
            return CreatedAtRoute("GetBooking", new {Id = basicModel.Id} , basicModel);
        }
        /// <summary>
        /// Permite a un administrador eliminar una reserva
        /// </summary>
        /// <param name="id">Este parámetro contiene el identificador de la reserva</param>
        /// <response code="200">Se devuelve la información requerida.</response>
        /// <response code="400">Reserva no existente con ese identificador</response>
        [HttpDelete("{id}")]
        [AuthorizationFilter]
        public IActionResult Delete([FromRoute]int id)
        {
            this.bookingLogic.Delete(id);
            return Ok("Element was delete with id "+id);
        }
        /// <summary>
        /// Permite a un administrador eliminar todas las reservas
        /// </summary>
        /// <response code="200">Se devuelve la información requerida.</response>
        [HttpDelete]
        [AuthorizationFilter]
        public IActionResult Delete()
        {
            this.bookingLogic.Delete();
            return Ok("All data from Booking was");
        }
    }

}