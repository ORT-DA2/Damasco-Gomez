using System;
using System.Collections.Generic;
using System.Linq;
using BusinessLogicInterface;
using Domain;
using Domain.Entities;
using Filters;
using Microsoft.AspNetCore.Mvc;
using Model;
using Model.In;
using WebApi.Filters;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/houses")]
    public class HouseController : VidlyControllerBase
    {
        private readonly IHouseLogic houseLogic;
        public HouseController(IHouseLogic houseLogic)
        {
            this.houseLogic = houseLogic;
        }
        //..api/houses
        //..api/house?idTP=1
        [HttpGet]
        public IActionResult GetHousesBy([FromQuery]HouseSearchModel houseSearchModel)
        {
            IEnumerable<House> varRet ;
            IEnumerable<HouseBasicModel> basicModels;
            if(houseSearchModel.NotNull())
            {
                HouseSearch houseSearch = houseSearchModel.ToEntity();
                // Get houses by tourist points
                varRet = this.houseLogic.GetHousesBy(houseSearch);
                basicModels = varRet.
                    Select(m => new HouseBasicModel(m,houseSearch)).ToList();
            }
            else
            {
                //Get ALL houses
                varRet = this.houseLogic.GetAll();
                basicModels = varRet.Select( m => new HouseBasicModel(m));
            }
            return Ok(basicModels);
        }
        //...api/houses/{id}
        [HttpGet("{id}",Name="GetHouse")]
        public IActionResult GetBy([FromRoute]int id)
        {
            try
            {
                House elementHouse = this.houseLogic.GetBy(id);
                HouseDetailModel modelHouse = new HouseDetailModel(elementHouse);
                return Ok(modelHouse);
            }
            catch (ArgumentException)
            {
                return BadRequest("There is not a house with that id");
            }
        }
        [HttpPost()]
        [AuthorizationFilter]
        //The post should have HouseModel , but will leave it like this
        public IActionResult Post([FromBody]HouseModel houseModel)
        {
            try
            {
                House house = houseModel.ToEntity();
                house = this.houseLogic.Add(house);
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
        [AuthorizationFilter]
        public IActionResult Put([FromRoute]int id,[FromBody]HouseModel houseModel)
        {
            try
            {
                House house = houseModel.ToEntity();
                house = this.houseLogic.Update(id,house);
                return CreatedAtRoute("GetHouse", new {Id = house.Id} , house);
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
        [AuthorizationFilter]
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
        [AuthorizationFilter]
        public IActionResult Delete()
        {
            this.houseLogic.Delete();
            return Ok();
        }
    }
}
