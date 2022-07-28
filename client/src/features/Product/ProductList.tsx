import { Box, Grid } from "@mui/material";
import { useEffect } from "react";
import { useAppDispatch, useAppSelector } from "../../app/store/configureStore";

import {
  fetchProductsAsync,
  productSelector,
  setPageNumber,
} from "./productSlice";
import ProductDetail from "./ProductItem";
import PaginationRounded from "../../app/layout/PaginationRounded";
import LoadingBackdrop from "../../app/layout/LoadingBackdrop";
const ProductList = () => {
  const dispatch = useAppDispatch();
  const { metadata, productLoaded } = useAppSelector((state) => state.product);
  useEffect(() => {
    if (!productLoaded) dispatch(fetchProductsAsync());
  }, [dispatch, productLoaded]);
  const products = useAppSelector(productSelector.selectAll);
  if (!productLoaded) return <LoadingBackdrop message="Products Loaded" />;
  return (
    <Grid container rowSpacing={2} columnSpacing={2} sx={{ my: 3 }}>
      {products.map((product) => (
        <Grid item xs={12} sm={6} md={4} lg={3} key={product.id}>
          <ProductDetail product={product} key={product?.id} />
        </Grid>
      ))}
      <Grid item xs={12}>
        {metadata && (
          <PaginationRounded
            metaData={metadata}
            onPageChange={(page: number) =>
              dispatch(setPageNumber({ pageNumber: page }))
            }
          />
        )}
      </Grid>
    </Grid>
  );
};

export default ProductList;
