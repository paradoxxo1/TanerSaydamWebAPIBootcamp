using Newtonsoft.Json;

namespace Project.WEBAPI.Models.ShoppingTools
{
    [Serializable]
    public class Cart
    {
        [JsonProperty("_myCart")]
        Dictionary<int, CartItem> _myCart;

        public Cart()
        {
            _myCart = new Dictionary<int, CartItem>();
        }

        [JsonProperty("MyCart")]
        public List<CartItem> MyCart
        {
            get
            {
                return _myCart.Values.ToList();
            }
        }

        public void AddToCart(CartItem item)
        {
            if (_myCart.ContainsKey(item.Id))
            {
                _myCart[item.Id].Amount++;
                return;
            }
            _myCart.Add(item.Id, item);
        }

        public void RemoveFromCart(int id)
        {
            if (_myCart[id].Amount > 1)
            {
                _myCart[id].Amount--;
                return;
            }

            _myCart.Remove(id);
        }

        [JsonProperty("TotalPrice")]
        public decimal? TotalPrice
        {
            get
            {
                return _myCart.Sum(x => x.Value.SubTotal);
            }
        }
    }
}
