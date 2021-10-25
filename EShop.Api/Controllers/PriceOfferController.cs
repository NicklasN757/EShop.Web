using EShop.Api.Models;
using EShop.Service.DataTransferObjects;
using EShop.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EShop.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PriceOfferController : ControllerBase
    {
        private readonly IPriceOfferService _priceOfferService;

        public PriceOfferController(IPriceOfferService priceOfferService)
        {
            _priceOfferService = priceOfferService;
        }

        [HttpGet]
        public async Task<List<PriceOfferDTO>> GetAllPriceOffers() => await _priceOfferService.GetAllAsync();

        [HttpGet]
        [Route("{id}")]
        public async Task<PriceOfferDTO> GetPriceOffer(int id) => await _priceOfferService.GetByIdAsync(id);

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> UpdatePriceOffer(PriceOfferModel priceOfferModel)
        {
            try
            {
                PriceOfferDTO updatedPriceOffer = new();
                updatedPriceOffer.ProductId = priceOfferModel.ProductId;
                updatedPriceOffer.DateEnding = priceOfferModel.DateEnding;
                updatedPriceOffer.NewPrice = priceOfferModel.NewPrice;
                updatedPriceOffer.OfferReason = priceOfferModel.OfferReason;

                await _priceOfferService.UpdateAsync(updatedPriceOffer);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("Create")]
        public async Task<IActionResult> CreatePriceOffer(PriceOfferModel priceOfferModel)
        {
            try
            {
                PriceOfferDTO newPriceOffer = new();
                newPriceOffer.ProductId = priceOfferModel.ProductId;
                newPriceOffer.DateStarted = priceOfferModel.DateStarted;
                newPriceOffer.DateEnding = priceOfferModel.DateEnding;
                newPriceOffer.NewPrice = priceOfferModel.NewPrice;
                newPriceOffer.OfferReason = priceOfferModel.OfferReason;

                await _priceOfferService.CreateAsync(newPriceOffer);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}