import {
  Box,
  Divider,
  Grid,
  IconButton,
  Rating,
  Table,
  TableBody,
  TableCell,
  TableRow,
  Typography,
} from "@mui/material";
import React, { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import { useAppDispatch, useAppSelector } from "../../app/store/configureStore";
import { fetchProductDetail, productSelector } from "./productSlice";
import { teal } from "@mui/material/colors";
import ThumbGallery from "../../app/components/ThumbGallery";
import { LoadingButton } from "@mui/lab";
import QuantitySelector from "../../app/components/QuantitySelector";
import {
  addBasketItemAsync,
  removeBasketItemAsync,
} from "../basket/basketSlice";
import { BasketItem } from "../../app/model/Basket";
import { Delete } from "@mui/icons-material";
import ProductItem from "./ProductItem";
import LoadingBackdrop from "../../app/layout/LoadingBackdrop";
const ProductDetails = () => {
  const dispatch = useAppDispatch();
  const { id } = useParams<{ id: string }>();
  const [basketItem, setBasketItem] = useState<BasketItem>();
  const [displayAddBasket, setDisplayAddBasket] = useState(true);

  const { basket, status } = useAppSelector((state) => state.basket);
  const productDetails = useAppSelector((state) =>
    productSelector.selectById(state, id ? id : -1)
  );

  type Props = { children?: JSX.Element | JSX.Element[] };

  useEffect(() => {
    if (id !== undefined) {
      dispatch(fetchProductDetail(parseInt(id)));
    }
  }, [dispatch]);

  useEffect(() => {
    if (productDetails) {
      const item = basket?.basketItems.find(
        (x) => x.productId === productDetails.id
      );
      setBasketItem(item);
      if (basketItem) setDisplayAddBasket(false);
    }
  }, [basket]);

  function addToBasket() {
    if (productDetails) {
      const productId = productDetails?.id;
      dispatch(addBasketItemAsync({ productId }));
      setDisplayAddBasket(false);
    }
  }

  function handleRemove() {
    if (basketItem)
      dispatch(
        removeBasketItemAsync({
          productId: basketItem?.productId,
        })
      );
    setBasketItem(undefined);
    setDisplayAddBasket(true);
  }
  if ((status === "pending"))
    return <LoadingBackdrop message="Loading product detail" />;
  return (
    <Grid container sx={{ my: 2 }} columnSpacing={2} rowSpacing={4}>
      <Grid item xs={12} md={4}>
        <Box
          sx={{
            display: "flex",
            flexDirection: "column",
            justifyContent: "space-between",
            height: "100%",
          }}
        >
          <Typography variant="h5" color="secondary">
            {productDetails?.brand?.name.toUpperCase()}
          </Typography>
          <Divider variant="fullWidth" />
          <Typography variant="h6">{productDetails?.name}</Typography>
          <Typography variant="body1" color="red">
            {productDetails && productDetails?.quantity > 0
              ? "Available In Store"
              : "Not Available In Store"}
          </Typography>
          <Divider variant="middle" />
          <Rating
            name="read-only"
            value={3}
            readOnly
            sx={{ justifyContent: "center" }}
          />
          <Box
            sx={{
              display: "flex",
              alignItems: "center",
              justifyContent: "space-around",
              p: 2,
              borderRadius: 2,
              background: `${teal[50]}`,
            }}
          >
            <Typography variant="h6">{productDetails?.price}$</Typography>
          </Box>
          {displayAddBasket ? (
            <LoadingButton
              loading={status.includes("pending")}
              onClick={addToBasket}
              fullWidth
              variant="contained"
            >
              Add To Basket
            </LoadingButton>
          ) : (
            <Box
              sx={{
                display: "flex",
                alignItems: "center",
                justifyContent: "space-between",
              }}
            >
              <QuantitySelector prodId={parseInt(id!)} />
              <Typography> {basketItem?.quantityInBasket} Unit =</Typography>
              <Typography>
                {basketItem
                  ? basketItem?.quantityInBasket * basketItem?.price
                  : 0}
                $
              </Typography>
              <IconButton onClick={handleRemove}>
                <Delete />
              </IconButton>
            </Box>
          )}
        </Box>
      </Grid>
      <Grid item xs={12} md={4}>
        <Box>
          <Typography variant="h5">{productDetails?.name}</Typography>
          <Typography variant="body1" color="GrayText" sx={{ my: 2 }}>
            {productDetails?.description}
          </Typography>
        </Box>
      </Grid>
      <Grid item xs={12} md={4}>
        <ThumbGallery images={productDetails?.images} />
      </Grid>
      {/* <Grid item xs={12}>
        <Item>
          <div>Similar product</div>
        </Item>
      </Grid> */}
      <Grid item xs={12}>
        <Divider variant="middle" />
        <Typography variant="h4">Product Specification</Typography>
        <Table>
          <TableBody>
            {productDetails?.specifications?.map((item) => (
              <React.Fragment key={item.id}>
                <TableRow>
                  <TableCell>{item.specLabel}</TableCell>
                  <TableCell>{item.specValue}</TableCell>
                </TableRow>
              </React.Fragment>
            ))}
          </TableBody>
        </Table>
      </Grid>
    </Grid>
  );
};

export default ProductDetails;
