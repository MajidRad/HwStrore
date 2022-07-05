import { createSlice } from "@reduxjs/toolkit";
interface Products {
  products: Product[];
}
export const ProductSlice = createSlice({
  name: "product",
  initialState: initialState,
  reducers: {},
});
