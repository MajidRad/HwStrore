import { Basket } from "./Basket";

export interface User {
  email: string;
  userName: string;
  token: string;
  id: string;
  basket:Basket
}

// email: string;
// token: string;
// basket?: Basket;
// roles?: string[];