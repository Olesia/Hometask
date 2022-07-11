using Hometask.BLL.Dto;
using Hometask.Common.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Hometask.WebApi.Controllers
{
    /// <summary>
    /// Cart Controller
    /// </summary>
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;

        /// <summary>
        /// Cart Controller Constructor
        /// </summary>
        /// <param name="cartService"></param>
        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        /// <summary>
        /// Gets the cart model
        /// </summary>
        /// <param name="id"> The cart id </param>
        /// <returns> Cart model </returns>
        /// <response code="404"> The selected cart was not found </response>
        [MapToApiVersion("1.0")]
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<CartDto> GetCartInfoV1(string id)
        {
            try
            {
                var result = _cartService.GetCartInfo(id);
                return Ok(result);
            }
            catch (KeyNotFoundException)
            {
                return NotFound($"There is no cart with id: {id}");
            }

        }

        /// <summary>
        /// Gets the list of cart items
        /// </summary>
        /// <param name="id"> The cart id </param>
        /// <returns> List of items in the cart </returns>
        /// <response code="404"> The cart was not found </response>
        [MapToApiVersion("2.0")]
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<CartItemDto>> GetCartInfoV2(string id)
        {
            try
            {
                var result = _cartService.GetCartItems(id);
                return Ok(result);
            }
            catch (KeyNotFoundException)
            {
                return NotFound($"There is no cart with id: {id}");
            }

        }

        /// <summary>
        /// Adds the item to the the cart
        /// </summary>
        /// <param name="id"> The cart id </param>
        /// <param name="item"> The item id </param>
        /// <returns> True if item was added </returns>
        /// <response code="409"> The cart id and item cartId must be the same </response>

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public ActionResult<bool> AddItemToTheCart(string id, CartItemDto item)
        {
            if (id != item.CartId)
            {
                return Conflict(id);
            }
            var result = _cartService.AddCartItem(item);
            return Ok(result);
        }

        /// <summary>
        /// Removes the item from the cart
        /// </summary>
        /// <param name="cartId"> The cart id </param>
        /// <param name="itemId"> The item id </param>
        /// <returns> True if item was deleted </returns>
        /// <response code="404"> The cart item was not found </response>
        
        [HttpDelete("{cartId}/items/{itemId}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<bool> Delete(string cartId, int itemId)
        {
            try
            {
                var result = _cartService.DeleteCartItem(cartId, itemId);
                return Ok(result);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }
    }
}
