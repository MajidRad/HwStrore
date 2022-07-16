import { Image } from "../model/Image";
import { Category } from "./Category";
import { Specification } from "./Specification";
import { Brand } from "./Brand";

export interface Product {
  id: number;
  name: string;
  quantity: number;
  description: number;
  price: number;
  images?: Image[];
  category?: Category;
  brand?: Brand;
  specifications?: Specification[];
}

export interface ProductParams {
  pageNumber: number;
  pageSize: number;
}
