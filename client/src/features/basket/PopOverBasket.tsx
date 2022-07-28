import { CloseRounded } from "@mui/icons-material";
import { LoadingButton } from "@mui/lab";
import { Popover, Box, Typography, IconButton } from "@mui/material";
import React, { useEffect, useState } from "react";
import { teal } from "@mui/material/colors";
import { BasketItem } from "../../app/model/Basket";
import PopOverItem from "./PopOverItem";
import { Link as routerLink } from "react-router-dom";

interface Props {
  handleClose: () => void;
  open: boolean;
  anchorEl?: null | HTMLElement;
  setAnchorEl?: (value: React.SetStateAction<HTMLElement | null>) => void;
  isAnimate: boolean;
  items: BasketItem[] | undefined;
}

const PopOverBasket = ({
  handleClose,
  open,
  anchorEl,
  isAnimate,
  items,
}: Props) => {
  useEffect(() => {
    basketSummary();
    popoverHeight();
  }, [basketSummary, popoverHeight]);
  const [totalPrice, setTotalPrice] = useState(0);
  const [height, setHeight] = useState(200);

  function popoverHeight() {
    if (items) items?.length > 1 ? setHeight(350) : setHeight(200);
  }

  function basketSummary() {
    let prices: number[] = [];
    if (items !== undefined) {
      for (const item of items) {
        let price = item.price * item.quantityInBasket;
        prices.push(price);
      }

      prices.length > 1 &&
        setTotalPrice(prices.reduce((prev, cur) => prev + cur));
    }
  }

  return (
    <Popover
      open={open}
      onClose={handleClose}
      anchorEl={anchorEl}
      anchorOrigin={{
        vertical: "bottom",
        horizontal: "left",
      }}
      sx={{
        background: "rgba(31, 70, 144,0.2)",
        backdropFilter: "blur(4px)",
        boxShadow: "rgba(99, 99, 99, 0.2) 0px 2px 8px 0px",
      }}
    >
      <Box
        sx={{
          m: 2,
          height: `${height}px`,
          width: "320px",
          display: "flex",
          flexDirection: "column",
          justifyContent: "space-between",
        }}
      >
        <Box
          sx={{
            display: "flex",
            alignItems: "center",
            justifyContent: "space-between",
          }}
        >
          <Typography variant="h6" color={`${teal[300]}`}>
            Basket TotalPrice: {totalPrice}$
          </Typography>
          <IconButton onClick={handleClose}>
            <CloseRounded />
          </IconButton>
        </Box>
        {items?.map((item) => (
          <PopOverItem item={item} key={item.productId} />
        ))}

        <LoadingButton
          component={routerLink}
          to="/checkout"
          fullWidth
          variant="contained"
        >
          CheckOut
        </LoadingButton>
      </Box>
    </Popover>
  );
};

export default PopOverBasket;
