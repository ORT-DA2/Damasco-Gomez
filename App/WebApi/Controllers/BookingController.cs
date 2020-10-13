using System.Collections.Generic;
using System.Linq;
using BusinessLogicInterface;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Model;
using WebApi.Filters;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/bookings")]
    public class BookingController : VidlyControllerBase
    {
        private readonly IBookingLogic bookingLogic;
        public BookingController(IBookingLogic bookingLogic)
        {
            this.bookingLogic = bookingLogic;
        }
        public IActionResult Get()
        {
            IEnumerable<Booking> elementBookings = this.bookingLogic.GetAll();
            IEnumerable<BookingBasicModel> bookingModels =  elementBookings.Select(m => new BookingBasicModel(m));
            return Ok(bookingModels);
        }

        [HttpGet("{id}",Name="GetBooking")]
        public IActionResult GetBy([FromRoute]int id)
        {
            Booking elementBooking = this.bookingLogic.GetBy(id);
            BookingDetailModel bookingModel = new BookingDetailModel(elementBooking);
            return Ok(bookingModel);
        }
        [HttpPost]
        [AuthorizationFilter]
        public IActionResult Post([FromBody]BookingModel booking)
        {
            Booking newBooking = booking.ToEntity();
            newBooking = this.bookingLogic.Add(newBooking);
            BookingBasicModel basicModel = new BookingBasicModel(newBooking);
            return CreatedAtRoute("GetBooking", new {Id = basicModel.Id} , basicModel);
        }
        [HttpPut("{id}")]
        [AuthorizationFilter]
        public IActionResult Put([FromRoute]int id,[FromBody]BookingModel booking)
        {
            Booking newBooking = booking.ToEntity();
            newBooking = this.bookingLogic.Update(id, newBooking);
            BookingBasicModel basicModel = new BookingBasicModel(newBooking);
            return CreatedAtRoute("GetBooking", new {Id = basicModel.Id} , basicModel);
        }
        [HttpDelete("{id}")]
        [AuthorizationFilter]
        public IActionResult Delete([FromRoute]int id)
        {
            this.bookingLogic.Delete(id);
            return Ok("Element was delete with id "+id);
        }
        [HttpDelete]
        [AuthorizationFilter]
        public IActionResult Delete()
        {
            this.bookingLogic.Delete();
            return Ok("All data from Booking was");
        }
    }

}