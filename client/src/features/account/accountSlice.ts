import { createAsyncThunk, createSlice, isAnyOf } from "@reduxjs/toolkit";
import { FieldValues } from "react-hook-form";
import { User } from "../../app/model/User";
import agent from "../../app/api/agent";
import { setBasket } from "../basket/basketSlice";

interface AccountState {
  User: User | null;
}
const initialState: AccountState = {
  User: null,
};
export const signUpUser = createAsyncThunk<User, FieldValues>(
  "account/signUpUser",
  async (data, thunAPI) => {
    try {
      return await agent.Account.register(data);
    } catch (error: any) {
      thunAPI.rejectWithValue({ error: error.data });
    }
  }
);
export const signInUser = createAsyncThunk<User, FieldValues>(
  "account/loginUser",
  async (data, thunkAPI) => {
    try {
      const userDto = await agent.Account.login(data);
      const { basket, ...user } = userDto;
      if (basket) thunkAPI.dispatch(setBasket(basket));
      localStorage.setItem("user", JSON.stringify(user));
      return user;
    } catch (error: any) {
      return thunkAPI.rejectWithValue({ error: error.data });
    }
  }
);
export const fetchCurrentUser = createAsyncThunk<User>(
  "account/currentUser",
  async (_, thunkAPI) => {
    thunkAPI.dispatch(setUser(JSON.parse(localStorage.getItem("user")!)));
    try {
      const userDto = await agent.Account.currentUser();
      const { basket, ...user } = userDto;
      if(basket)thunkAPI.dispatch(setBasket(basket));
      localStorage.setItem("user", JSON.stringify(user));
      return user;
    } catch (error: any) {
      thunkAPI.rejectWithValue({ error: error.data });
    }
  },
  {
    condition: () => {
      if (!localStorage.getItem("user")) return false;
    },
  }
);
export const AccountSlice = createSlice({
  name: "account",
  initialState: initialState,
  reducers: {
    signOut: (state) => {
      state.User = null;
      localStorage.removeItem("user");
    },
    setUser: (state, action) => {
      state.User = action.payload;
    },
  },
  extraReducers: (builder) => {
    builder.addMatcher(
      isAnyOf(signInUser.fulfilled, fetchCurrentUser.fulfilled),
      (state, action) => {
        state.User = action.payload;
      }
    );
    builder.addMatcher(
      isAnyOf(signInUser.rejected, fetchCurrentUser.rejected),
      (state, action) => {
        console.log(action.error);
      }
    );
  },
});
export const { signOut, setUser } = AccountSlice.actions;
