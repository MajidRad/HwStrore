import { configureStore } from "@reduxjs/toolkit";
import { TypedUseSelectorHook, useDispatch, useSelector } from "react-redux";
import { AccountSlice } from "../../features/account/accountSlice";
import { ProductSlice } from "../../features/Product/productSlice";

export const store = configureStore({
  reducer: {
    account: AccountSlice.reducer,
    product: ProductSlice.reducer,
  },
});
export type RootState = ReturnType<typeof store.getState>;
export type AppDispatch = typeof store.dispatch;

export const useAppDispatch = () => useDispatch<AppDispatch>();
export const useAppSelector: TypedUseSelectorHook<RootState> = useSelector;
