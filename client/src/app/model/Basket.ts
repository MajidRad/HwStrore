export interface Basket {
  id: number;
  buyerId: string;
  basketItems: BasketItem[];
}
export interface BasketItem {
  productId: number;
  name: string;
  price: number;
  imageUrl: string;
  quantity: number;
  quantityInBasket: number;
}
