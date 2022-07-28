import {
  createAsyncThunk,
  createEntityAdapter,
  createSlice,
} from "@reduxjs/toolkit";
import agent from "../../app/api/agent";
import { MetaData } from "../../app/model/MetaData";
import { Product, ProductParams } from "../../app/model/Product";
import { RootState } from "../../app/store/configureStore";
interface ProductState {
  products: Product[];
  status: string;
  productParams: ProductParams;
  productLoaded: boolean;
  metadata: MetaData | null;
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
    thunkAPI.dispatch(setMetaData(response.metaData));
    return response.items;
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
    status: "idle",
    productParams: initParams(),
    metadata: null,
    productLoaded: false,
  }),
  reducers: {
    setProductParams: (state, action) => {
      state.productParams = {
        ...state.productParams,
        ...action.payload,
        pageNumber: 1,
      };
    },
    resetProductParams: (state, action) => {
      state.productLoaded = false;
      state.productParams = initParams();
    },
    setPageNumber: (state, action) => {
      state.productLoaded = false;
      state.productParams = { ...state.productParams, ...action.payload };
    },
    setMetaData: (state, action) => {
      state.metadata = action.payload;
    },
  },
  extraReducers: (builder) => {
    builder.addCase(fetchProductsAsync.fulfilled, (state, action) => {
      productAdapter.setAll(state, action.payload);
      state.status = "idle";
      state.productLoaded = true;
    });
    builder.addCase(fetchProductsAsync.pending, (state, action) => {
      state.status = "pendingFetchProducts";
    });
    builder.addCase(fetchProductsAsync.rejected, (state, action) => {
      state.status = "idle";
      console.log(action);
    });
    builder.addCase(fetchProductDetail.fulfilled, (state, action) => {
      productAdapter.upsertOne(state, action.payload);
    });
    builder.addCase(fetchProductDetail.pending, (state, action) => {
      state.status = "pendingFetchProduct";
    });
    builder.addCase(fetchProductDetail.rejected, (state, action) => {
      state.status = "idle";
      console.log(action);
    });
  },
});
export const productSelector = productAdapter.getSelectors(
  (state: RootState) => state.product
);

export const {
  setProductParams,
  resetProductParams,
  setPageNumber,
  setMetaData,
} = ProductSlice.actions;
