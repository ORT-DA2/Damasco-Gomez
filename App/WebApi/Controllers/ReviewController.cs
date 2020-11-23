using System.Collections.Generic;
using System.Linq;
using BusinessLogicInterface;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Model.In;
using Model.Out;
using WebApi.Filters;

namespace WebApi.Controllers
{
    [Route("api/reviews")]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewLogic reviewLogic;

        public ReviewController(IReviewLogic reviewLogic)
        {
            this.reviewLogic = reviewLogic;
        }
        /// <summary>
        /// Permite a un usuario obtener información de todas las reviewes del sistema
        /// </summary>
        /// <response code="200">Se devuelve la información requerida</response>
        [HttpGet]
        public IActionResult GetReviewsBy([FromQuery]int houseId)
        {
            IEnumerable<Review> varRet ;
            IEnumerable<ReviewBasicModel> basicModels;
            if(houseId > 0)
            {
                // Get reviews by houseId
                varRet = this.reviewLogic.GetByHouseId(houseId);
                basicModels = varRet.
                    Select(m => new ReviewBasicModel(m)).ToList();
            }
            else
            {
                //Get ALL reviews
                varRet = this.reviewLogic.GetAll();
                basicModels = varRet.Select( m => new ReviewBasicModel(m));
            }
            return Ok(basicModels);
        }
        /// <summary>
        /// Permite a un ususario ver una review del sistema
        /// </summary>
        /// <param name="id">Este parámetro contiene el identificador de la review</param>
        /// <response code="200">Se devuelve la información requerida.</response>
        /// <response code="400">Categoria no existente con ese identificador</response>
        [HttpGet( "{id}" , Name="GetReview" )]
        public IActionResult GetBy([FromRoute]int id)
        {
            var elementReview = this.reviewLogic.GetBy(id);
            ReviewDetailModel reviewsBasic = new ReviewDetailModel(elementReview);
            return Ok(reviewsBasic);
        }
        /// <summary>
        /// Permite a un administrador agregar una review
        /// </summary>
        /// <param name="reviewModel">Este modelo contiene la información de la review</param>
        /// <response code="200">Se devuelve la información requerida.</response>
        /// <response code="400">Categoria no existente con ese identificador</response>
        [HttpPost]
        public IActionResult Post([FromBody]ReviewModel reviewModel)
        {
            Review review = reviewModel.ToEntity();
            review = this.reviewLogic.Add(review);
            ReviewBasicModel reviewsBasic = new ReviewBasicModel(review);
            var creationRoute = CreatedAtRoute("GetReview", new {Id = reviewsBasic.Id} , reviewsBasic);
            return creationRoute;
        }
        /// <summary>
        /// Permite a un administrador modificar una review
        /// </summary>
        /// <param name="id">Este parámetro contiene el identificador de la review</param>
        /// <param name="reviewModel">Este modelo contiene la información de la review</param>
        /// <response code="200">Se devuelve la información requerida.</response>
        /// <response code="400">Categoria no existente con ese identificador</response>
        [HttpPut("{id}")]
        [AuthorizationFilter]
        public IActionResult Put([FromRoute]int id,[FromBody]ReviewModel reviewModel)
        {
            Review review = reviewModel.ToEntity();
            review = this.reviewLogic.Update(id,review);
            ReviewBasicModel reviewsBasic = new ReviewBasicModel(review);
            var creationRoute = CreatedAtRoute("GetReview", new {Id = reviewsBasic.Id} , reviewsBasic);
            return creationRoute;
        }
        /// <summary>
        /// Permite a un administrador eliminar una review
        /// </summary>
        /// <param name="id">Este parámetro contiene el identificador de la review</param>
        /// <response code="200">Se devuelve la información requerida.</response>
        /// <response code="400">Categoria no existente con ese identificador</response>
        [HttpDelete("{id}")]
        [AuthorizationFilter]
        public IActionResult Delete([FromRoute]int id)
        {
            this.reviewLogic.Delete(id);
            return Ok("Element was delete with id "+id);
        }
        /// <summary>
        /// Permite a un administrador eliminar todas las reviewes
        /// </summary>
        /// <response code="200">Se devuelve la información requerida.</response>
        [HttpDelete]
        [AuthorizationFilter]
        public IActionResult Delete()
        {
            this.reviewLogic.Delete();
            return Ok("All data from Review was");
        }
    }
}