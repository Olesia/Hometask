﻿
using Hometask.Shared;

namespace Hometask.DAL.Entities
{
    public class CartItem : BaseEntity
    {
        public Guid CartId { get; set; }
        public Guid ItemId { get; set; }
        public int Quantity { get; set; }
    }
}
