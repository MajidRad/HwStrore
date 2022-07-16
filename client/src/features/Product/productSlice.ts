import {
  createAsyncThunk,
  createEntityAdapter,
  createSlice,
} from "@reduxjs/toolkit";
import agent from "../../app/api/agent";
import { Product, ProductParams } from "../../app/model/Product";
import { RootState } from "../../app/store/configureStore";
interface ProductState {
  products: Product[];
  productParams: ProductParams;
}
const productAdapter = createEntityAdapter<Product>();
function getAxiosParams(productParams: ProductParams) {
  const params = new URLSearchParams();
  params.append("pageNumber", productParams.pageNumber.toString());
  params.append("pageSize", productParams.pageSize.toString());
  return params;
}
export const fetchProductsAsync = createAsyncThunk<
  Product[],
  void,
  { state: RootState }
>("product/fetchProductsAsync", async (_, thunkAPI) => {
  const params = getAxiosParams(thunkAPI.getState().product.productParams);
  try {
    const response = await agent.Product.getAll(params);
    return response;
  } catch (error: any) {
    return thunkAPI.rejectWithValue({ error: error.data });
  }
});

export const fetchProductDetail = createAsyncThunk<
  Product,
  number,
  { state: RootState }
>("productDetail/FetchProductById", async (ProductId, thunkAPI) => {
  try {
    return await agent.Product.details(ProductId);
  } catch (error: any) {
    thunkAPI.rejectWithValue({ error: error.data });
  }
});

function initParams() {
  return {
    pageNumber: 1,
    pageSize: 5,
  };
}
export const ProductSlice = createSlice({
  name: "product",
  initialState: productAdapter.getInitialState<ProductState>({
    products: [],
    productParams: initParams(),
  }),
  reducers: {
    setProductParams: (state, action) => {
      state.productParams = { ...state.productParams, ...action.payload };
    },
    resetProductParams: (state, action) => {
      state.productParams = initParams();
    },
  },
  extraReducers: (builder) => {
    builder.addCase(fetchProductsAsync.fulfilled, (state, action) => {
      productAdapter.setAll(state, action.payload);
    });
    builder.addCase(fetchProductDetail.fulfilled, (state, action) => {
      productAdapter.upsertOne(state, action.payload);
    });
  },
});
export const productSelector = productAdapter.getSelectors(
  (state: RootState) => state.product
);

export const { setProductParams, resetProductParams } = ProductSlice.actions;
