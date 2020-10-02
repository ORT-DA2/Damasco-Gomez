using System;
using BusinessLogicInterface;
using Domain;
using Microsoft.AspNetCore.Mvc;

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
            var elementBooking = this.bookingLogic.GetBy(id);
            return Ok(elementBooking);
        }
        [HttpPost()]
        //The post should have BookingModel , but will leave it like this
        public IActionResult Post([FromBody]Booking booking)
        {
            try
            {
                this.bookingLogic.Add(booking);
                return CreatedAtRoute("GetBooking", booking.Id, booking);
            }
            catch (AggregateException)
            {
                return BadRequest("The booking was already added");
            }
            catch (ArgumentException)
            {
                return BadRequest("Error while validate ");
            }
            catch (Exception)
            {
                return BadRequest("The server had an error");
            }
        }
        [HttpPut("{id}")]
        //The put should have BookingModel , but will leave it like this
        public IActionResult Put([FromRoute]int id,[FromBody]Booking booking)
        {
            try
            {
                this.bookingLogic.Update(id, booking);
                return CreatedAtRoute("GetBooking", booking.Id, booking);
                //return Ok(booking);
            }
            catch(ArgumentException)
            {
                return BadRequest("Error while validate");
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