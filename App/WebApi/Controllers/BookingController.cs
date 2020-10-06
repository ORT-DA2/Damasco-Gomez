using System;
using BusinessLogicInterface;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Model;

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
        public IActionResult Get()
        {
            var elementBooking = this.bookingLogic.GetAll();
            return Ok(elementBooking);
        }

        [HttpGet("{id}",Name="GetBooking")]
        public IActionResult GetBy([FromRoute]int id)
        {
            try
            {
                var elementBooking = this.bookingLogic.GetBy(id);
                return Ok(elementBooking);
            }
            catch (ArgumentException)
            {
                return BadRequest("There is not a booking with that id");
            }
        }
        [HttpPost()]
        public IActionResult Post([FromBody]BookingModel booking)
        {
            try
            {
                Booking newBooking = booking.ToEntity();
                var bookingAdded = this.bookingLogic.Add(newBooking);
                return CreatedAtRoute("GetBooking", new {Id = bookingAdded.Id} , bookingAdded);
            }
            catch (AggregateException)
            {
                return BadRequest("The booking was already added");
            }
            catch (ArgumentException e )
            {
                return BadRequest("Error while validate : "+ e.Message.ToString());
            }
            catch (Exception)
            {
                return BadRequest("The server had an error");
            }
        }
        [HttpPut("{id}")]
        public IActionResult Put([FromRoute]int id,[FromBody]BookingModel booking)
        {
            try
            {
                Booking newBooking = booking.ToEntity();
                newBooking = this.bookingLogic.Update(id, newBooking);
                return CreatedAtRoute("GetBooking", new {Id = newBooking.Id} , newBooking);
            }
            catch(ArgumentException e)
            {
                return BadRequest("Error while validate : "+ e.Message.ToString());
            }
            catch (Exception)
            {
                return BadRequest("Internal server error");
            }
        }
        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute]int id)
        {
            if (this.bookingLogic.GetBy(id) == null)
            {
                return NotFound();
            }
            this.bookingLogic.Delete(id);
            return Ok();
        }
        [HttpDelete()]
        public IActionResult Delete()
        {
            this.bookingLogic.Delete();
            return Ok();
        }
    }

}