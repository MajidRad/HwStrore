import { RemoveCircleOutline, AddCircleOutline } from "@mui/icons-material";
import { Box, IconButton, SxProps, Typography } from "@mui/material";
import { useState } from "react";
import { updateBasketItemAsync } from "../../features/basket/basketSlice";
import { BasketItem } from "../model/Basket";
import { useAppDispatch, useAppSelector } from "../store/configureStore";

interface Props {
  sxProp?: SxProps;
  prodId?: number;
}
const QuantitySelector = ({ prodId, sxProp }: Props) => {
  const { basket } = useAppSelector((state) => state.basket);

  const dispatch = useAppDispatch();
  const item: BasketItem | undefined = basket
    ? basket?.basketItems.find((x) => x.productId === prodId)
    : undefined;

  function checkNegativity() {
    let result = false;
    if (item) result = item.quantityInBasket - 1 <= 0 ? false : true;
    return !result;
  }
  function checkStockQty() {
    let result = false;
    if (item) result = item.quantityInBasket + 1 > item.quantity ? false : true;
    return !result;
  }
  function handleCountLogic(name: string) {
    if (basket && item) {
      let qty = item.quantityInBasket;
      name === "decrement" ? (qty -= 1) : (qty += 1);
      dispatch(
        updateBasketItemAsync({
          buyerId: basket?.buyerId,
          productId: item?.productId,
          quantity: qty,
        })
      );
    }
  }
  const handleIncrement = () => {};

  return (
    <Box
      sx={{
        display: "flex",
        alignItems: "center",
        ...sxProp,
      }}
    >
      <IconButton
        disabled={checkNegativity()}
        onClick={(name) => handleCountLogic("decrement")}
      >
        <RemoveCircleOutline />
      </IconButton>
      <Typography sx={{ mx: 2 }}>{item?.quantityInBasket}</Typography>
      <IconButton
        disabled={checkStockQty()}
        onClick={(name) => handleCountLogic("increment")}
      >
        <AddCircleOutline />
      </IconButton>
    </Box>
  );
};

export default QuantitySelector;
