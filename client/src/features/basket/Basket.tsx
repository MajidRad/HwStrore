import { IconButton, Tooltip } from "@mui/material";
import React, { useState } from "react";
import { ShoppingCart } from "@mui/icons-material";
import PopOverBasket from "./PopOverBasket";
import { useAppSelector } from "../../app/store/configureStore";
export interface BasketDialogProps {
  open: boolean;
  selectedValue: string;
  onClose: (value: string) => void;
}

const Basket = () => {
  const { basket } = useAppSelector((state) => state.basket);
  // if (!basket) return <Typography>Your Basket is Empty</Typography>;

  const [anchorEl, setAnchorEl] = useState<null | HTMLElement>(null);
  const [isAnimate, setIsAnimate] = useState(false);
  const handleClick = (event: React.MouseEvent<HTMLElement>) => {
    setAnchorEl(event.currentTarget);
    setIsAnimate(true);
  };
  const open = Boolean(anchorEl);
  const handleClose = () => {
    setAnchorEl(null);
  };
  return (
    <>
      <Tooltip title="Basket" sx={{ mx: 2 }}>
        <IconButton color="inherit" onClick={handleClick} size="large">
          <ShoppingCart />
        </IconButton>
      </Tooltip>
      <PopOverBasket
        items={basket?.basketItems}
        open={open}
        handleClose={handleClose}
        anchorEl={anchorEl}
        setAnchorEl={setAnchorEl}
        isAnimate={isAnimate}
      />
    </>
  );
};

export default Basket;
