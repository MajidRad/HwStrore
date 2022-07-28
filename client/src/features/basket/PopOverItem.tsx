import { CloseRounded } from "@mui/icons-material";
import { IconButton, Typography, Divider, Grid, Box } from "@mui/material";
import { cyan } from "@mui/material/colors";
import { motion } from "framer-motion";
import { useState } from "react";

import QuantitySelector from "../../app/components/QuantitySelector";
import { BasketItem } from "../../app/model/Basket";
import { useAppDispatch } from "../../app/store/configureStore";
import { scaleVariant, slideVariant } from "../../app/util/animateVariant";
import { removeBasketItemAsync } from "./basketSlice";
interface Props {
  item: BasketItem;
}
const PopOverItem = ({ item }: Props) => {
  const dispatch = useAppDispatch();
  const [isRemoved, setRemoved] = useState(false);

  const handleRemove = () => {
    setRemoved(true);
    dispatch(
      removeBasketItemAsync({
        productId: item.productId,
      })
    );
  };

  return (
    <Grid
      component={motion.div}
      variants={isRemoved ? scaleVariant : slideVariant}
      initial="initial"
      animate={isRemoved ? "initial" : "stop"}
      transition={{ delay: 0.2 }}
      container
      sx={{
        boxShadow: "rgba(0, 0, 0, 0.1) 0px 4px 12px",
        borderRadius: "20px",
        mb: 2,
      }}
    >
      <Grid item xs={2} sx={{ my: "auto" }}>
        <IconButton
          component={motion.div}
          variants={scaleVariant}
          whileHover={{ rotate: 90 }}
          onClick={handleRemove}
        >
          <CloseRounded />
        </IconButton>
      </Grid>
      <Grid
        item
        component={motion.div}
        variants={slideVariant}
        initial="start"
        animate={isRemoved ? "initial" : "start"}
        xs={10}
        sx={{ background: cyan[50], borderRadius: "10px" }}
      >
        <Grid item>
          <Box
            sx={{
              display: "flex",
              alignItems: "center",
              justifyContent: "space-between",
            }}
          >
            <Box>
              <Typography>{item.name}</Typography>
            </Box>
            <Box>
              <Typography
                variant="subtitle2"
                color="error"
                sx={{ textDecoration: "line-through" }}
              >
                In Stock:{item.quantity}
              </Typography>
            </Box>
            <img src={`/${item.imageUrl}.jpg`} style={{ width: "60px" }} />
          </Box>
        </Grid>
        <Divider />
        <Grid item>
          <Box
            sx={{
              display: "flex",
              alignItems: "center",
              justifyContent: "space-between",
            }}
          >
            <Typography>Unit Price : {item.price}$</Typography>
            <QuantitySelector prodId={item.productId} />
          </Box>
          <Box>
            <Divider variant="inset" />

            <Typography variant="subtitle2" color="secondary">
              {item.quantityInBasket} Unit {item.name}=
              {item.quantityInBasket * item.price}$
            </Typography>
          </Box>
        </Grid>
      </Grid>
    </Grid>
  );
};

export default PopOverItem;
