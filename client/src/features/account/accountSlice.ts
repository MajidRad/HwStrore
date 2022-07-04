import { createAsyncThunk, createSlice } from "@reduxjs/toolkit";
import { FieldValues } from "react-hook-form";
import { User } from "../../app/model/User";
import agent from "../../app/api/agent";

interface AccountState {
  User: User | null;
}
const initialState: AccountState = {
  User: null,
};

export const SignInUser = createAsyncThunk<User, FieldValues>(
  "account/loginUser",
  async (data, thunkAPI) => {
    try {
      const user = await agent.Account.login(data);
      localStorage.setItem("user", JSON.stringify(user));
      return user;
    } catch (error: any) {
      return thunkAPI.rejectWithValue({ error: error.data });
    }
  }
);

export const AccountSlice = createSlice({
  name: "account",
  initialState: initialState,
  reducers: {
    signOut: (state) => {},
  },
  extraReducers:(builder)=>{
    builder.addCase(SignInUser.fulfilled,(state,action)=>{
      
    })
  }
});
export const { signOut } = AccountSlice.actions;
