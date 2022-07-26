import { CloseRounded } from "@mui/icons-material";
import { LoadingButton } from "@mui/lab";
import { motion } from "framer-motion";
import { scaleVariant, slideVariant } from "../../app/util/animateVariant";
import {
  Popover,
  Divider,
  Box,
  Typography,
  IconButton,
  Grid,
} from "@mui/material";
import React, { useState } from "react";
import { cyan } from "@mui/material/colors";
import QuantitySelector from "../../app/components/QuantitySelector";

import { BasketItem } from "../../app/model/Basket";
import PopOverItem from "./PopOverItem";

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
          height: "300px",
          width: "300px",
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
          <Typography variant="h6">Basket Items</Typography>
          <IconButton onClick={handleClose}>
            <CloseRounded />
          </IconButton>
        </Box>
        {items?.map((item) => (
          <PopOverItem item={item} key={item.productId} />
        ))}

        <LoadingButton fullWidth variant="contained">
          CheckOut
        </LoadingButton>
      </Box>
    </Popover>
  );
};

export default PopOverBasket;
