import { createAsyncThunk, createSlice, isAnyOf } from "@reduxjs/toolkit";

import agent from "../../app/api/agent";
import { Basket } from "../../app/model/Basket";
import { getCookie } from "../../app/util/util";

interface BasketState {
  basket: Basket | null;
  status: string;
}
const initialState: BasketState = {
  basket: null,
  status: "idle",
};
export const fetchBasketAsync = createAsyncThunk<Basket>(
  "basket/fetchBasketAsync",
  async (_, thunkAPI) => {
    try {
      return await agent.Basket.get();
    } catch (err: any) {
      return thunkAPI.rejectWithValue({ error: err.data });
    }
  },
  {
    condition: () => {
      if (!getCookie("buyerId")) return false;
    },
  }
);
export const addBasketItemAsync = createAsyncThunk<
  Basket,
  { productId: number; quantity: number }
>("basket/addBasketItem", async ({ productId, quantity }, thunkAPI) => {
  try {
    var basket = await agent.Basket.addItem(productId, quantity);

    return basket;
  } catch (error: any) {
    return thunkAPI.rejectWithValue({ error: error.data });
  }
});
export const updateBasketItemAsync = createAsyncThunk<
  Basket,
  { buyerId: string; productId: number; quantity: number }
>("basket/updateItem", async ({ buyerId, productId, quantity }, thunkAPI) => {
  try {
    var basket = await agent.Basket.updateItem(buyerId, productId, quantity);
    return basket;
  } catch (err: any) {
    thunkAPI.rejectWithValue({ error: err.data });
  }
});
export const removeBasketItemAsync = createAsyncThunk<
  Basket,
  { productId: number; quantity: number }
>("basket/removeItemAsync", async ({ productId, quantity }, thunkAPI) => {
  try {
    return await agent.Basket.removeItem(productId, quantity);
  } catch (err: any) {
    return thunkAPI.rejectWithValue({ error: err.data });
  }
});

export const basketSlice = createSlice({
  name: "basket",
  initialState,
  reducers: {
    setBasket: (state, action) => {
      state.basket = action.payload;
    },
    clearBasket: (state, action) => {
      state.basket = null;
    },
  },
  extraReducers: (builder) => {
    builder.addCase(fetchBasketAsync.pending, (state, action) => {
      state.status = "pending";
    });
    builder.addCase(removeBasketItemAsync.fulfilled, (state, action) => {
      const { productId, quantity } = action.meta.arg;
      state.status = "idle";
      let existProduct = state.basket?.basketItems.findIndex(
        (x) => x.productId === productId
      );
      if (existProduct === undefined || existProduct === -1) return;
      if (state.basket) {
        state.basket.basketItems[existProduct].quantityInBasket -= quantity;
      }
      state.basket = action.payload;
    });
    builder.addMatcher(
      isAnyOf(addBasketItemAsync.pending, updateBasketItemAsync.pending),
      (state, action) => {
        state.status = "pendingAddItem" + action.meta.arg.productId;
      }
    );
    builder.addMatcher(
      isAnyOf(
        addBasketItemAsync.rejected,
        fetchBasketAsync.rejected,
        updateBasketItemAsync.rejected
      ),
      (state, action) => {
        console.log(action.payload);
        state.status = "idle";
      }
    );
    builder.addMatcher(
      isAnyOf(
        addBasketItemAsync.fulfilled,
        fetchBasketAsync.fulfilled,
        updateBasketItemAsync.fulfilled
      ),
      (state, action) => {
        state.status = "idle";
        state.basket = action.payload;
      }
    );
  },
});
