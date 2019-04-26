using FishShopServiceDAL.BindingModels;
using FishShopServiceDAL.Interfaces;
using System;
using System.Web.Http;
namespace FishShopRestApi.Controllers
{
    public class CanFoodController : ApiController
    {
        private readonly ICanFoodService _service;
        public CanFoodController(ICanFoodService service)
        {
            _service = service;
        }
        [HttpGet]
        public IHttpActionResult GetList()
        {
            var list = _service.GetList();
            if (list == null)
            {
                InternalServerError(new Exception("Нет данных"));
            }
            return Ok(list);
        }
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var element = _service.GetElement(id);
            if (element == null)
            {
                InternalServerError(new Exception("Нет данных"));
            }
            return Ok(element);
        }
        [HttpPost]
        public void AddElement(CanFoodBindingModel model)
        {
            _service.AddElement(model);
        }
        [HttpPost]
        public void UpdElement(CanFoodBindingModel model)
        {
            _service.UpdElement(model);
        }
        [HttpPost]
        public void DelElement(CanFoodBindingModel model)
        {
            _service.DelElement(model.Id);
        }
    }
}