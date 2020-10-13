using System.Collections.Generic;
using System.Linq;
using BusinessLogicInterface;
using Domain;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Model;
using Model.In;
using WebApi.Filters;

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
        //..api/houses
        //..api/house?idTP=1
        [HttpGet]
        public IActionResult GetHousesBy([FromQuery]HouseSearchModel houseSearchModel)
        {
            IEnumerable<House> varRet ;
            IEnumerable<HouseBasicModel> basicModels;
            if(houseSearchModel.NotNull())
            {
                houseSearchModel.CheckAllParameters();
                HouseSearch houseSearch = houseSearchModel.ToEntity();
                // Get houses by tourist point
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
            House elementHouse = this.houseLogic.GetBy(id);
            HouseDetailModel modelHouse = new HouseDetailModel(elementHouse);
            return Ok(modelHouse);
        }
        [HttpPost]
        [AuthorizationFilter]
        public IActionResult Post([FromBody]HouseModel houseModel)
        {
            House house = houseModel.ToEntity();
            house = this.houseLogic.Add(house);
            HouseBasicModel basicModel = new HouseBasicModel(house);
            return CreatedAtRoute("GetHouse", new {Id = basicModel.Id}, basicModel);
        }
        [HttpPut("{id}")]
        [AuthorizationFilter]
        public IActionResult Put([FromRoute]int id,[FromBody]HouseModel houseModel)
        {
            House house = houseModel.ToEntity(false);
            house = this.houseLogic.Update(id,house);
            HouseBasicModel basicModel = new HouseBasicModel(house);
            return CreatedAtRoute("GetHouse", new {Id = basicModel.Id} , basicModel);
        }
        [HttpDelete("{id}")]
        [AuthorizationFilter]
        public IActionResult Delete([FromRoute]int id)
        {
            this.houseLogic.Delete(id);
            return Ok("Element was delete with id "+id);
        }
        [HttpDelete]
        [AuthorizationFilter]
        public IActionResult Delete()
        {
            this.houseLogic.Delete();
            return Ok("All data from House was");
        }
    }
}
