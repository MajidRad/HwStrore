import { Grid } from "@mui/material";
import { useEffect } from "react";
import { useAppDispatch, useAppSelector } from "../../app/store/configureStore";

import { fetchProductsAsync, productSelector } from "./productSlice";
import ProductDetail from "./ProductItem";
const ProductList = () => {
  const dispatch = useAppDispatch();
  useEffect(() => {
    dispatch(fetchProductsAsync());
  }, []);
  const products = useAppSelector(productSelector.selectAll);
  return (
    <Grid container rowSpacing={2} columnSpacing={2} sx={{ my: 3 }}>
      {products.map((product) => (
        <Grid item xs={12} sm={6} md={4} lg={3} key={product.id}>
          <ProductDetail product={product} />
        </Grid>
      ))}
    </Grid>
  );
};

export default ProductList;
