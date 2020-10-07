using System;
using System.Collections.Generic;
using System.Linq;
using BusinessLogicInterface;
using Domain;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Model;
using Model.In;

namespace WebApi.Controllers
{
    [Route("api/houses")]
    public class HouseController : VidlyControllerBase
    {
        private readonly IHouseLogic houseLogic;
        public HouseController(IHouseLogic houseLogic)
        {
            this.houseLogic = houseLogic;
        }
        public IActionResult Get()
        {
            var elementHouse = this.houseLogic.GetAll();
            return Ok(elementHouse);
        }

        [HttpGet("{id}",Name="GetHouse")]
        public IActionResult GetBy([FromRoute]int id)
        {
            try
            {
                var elementHouse = this.houseLogic.GetBy(id);
                return Ok(elementHouse);
            }
            catch (ArgumentException)
            {
                return BadRequest("There is not a house with that id");
            }
        }
        [HttpPost()]
        //The post should have HouseModel , but will leave it like this
        public IActionResult Post([FromBody]House house)
        {
            try
            {
                this.houseLogic.Add(house);
                return CreatedAtRoute("GetHouse", new {Id = house.Id}, house);
            }
            catch (AggregateException)
            {
                return BadRequest("The house was already added");
            }
            catch (ArgumentException e)
            {
                return BadRequest("Error while validate " +  e.ToString());
            }
            catch (Exception e)
            {
                return BadRequest("The server had an error" +  e.ToString());
            }
        }
        [HttpPut("{id}")]
        //The put should have HouseModel , but will leave it like this
        public IActionResult Put([FromRoute]int id,[FromBody]House house)
        {
            try
            {
                this.houseLogic.Update(id,house);
                return CreatedAtRoute("GetHouse", new {Id = house.Id} , house);
                //return Ok(house);
            }
            catch(ArgumentException e)
            {
                return BadRequest("Error while validate : "+ e.Message.ToString());
            }
            catch (Exception e)
            {
                return BadRequest("Internal server error"  + e.Message.ToString());
            }
        }
        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute]int id)
        {
            if (this.houseLogic.GetBy(id) == null)
            {
                return NotFound();
            }
            this.houseLogic.Delete(id);
            return Ok();
        }
        [HttpDelete()]
        public IActionResult Delete()
        {
            this.houseLogic.Delete();
            return Ok();
        }
        [HttpGet() ]
        public IActionResult GetHousesBy([FromQuery] HouseSearchModel houseSearchModel)
        {
           
            var houseSearch = houseSearchModel.ToEntity();
            var varRet = this.houseLogic.GetHousesBy(houseSearch);
            var result = varRet.Select(m => new HouseSearchResultModel(m,houseSearch)).ToList();
            return Ok(result);
           
        }
    }
}
