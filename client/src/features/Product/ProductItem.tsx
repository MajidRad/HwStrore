import Card from "@mui/material/Card";
import React from "react";
import CardActions from "@mui/material/CardActions";
import CardContent from "@mui/material/CardContent";
import CardMedia from "@mui/material/CardMedia";
import Button from "@mui/material/Button";
import Typography from "@mui/material/Typography";
import { Product } from "../../app/model/Product";
import { Box, IconButton, Rating } from "@mui/material";
import { AddShoppingCartRounded } from "@mui/icons-material";
import { Link as RouterLink } from "react-router-dom";
interface Props {
  product: Product;
}
const ProductItem = ({ product }: Props) => {
  return (
    <Card sx={{ maxWidth: 345 }}>
      <Box
        component={RouterLink}
        to={`/Products/${product.id}`}
        sx={{ textDecoration: "none" }}
      >
        <CardMedia
          component="img"
          height="250"

          image={product.images&&`/${product.images[0].path}.jpg`}
          alt={`${product.name}`}
        />
        <CardContent>
          <Typography gutterBottom variant="h5" component="div">
            {product.name}
          </Typography>
          <Typography variant="body2" color="text.secondary">
            {product.description}
          </Typography>
          <Box sx={{ mt: 3 }}>
            <Rating name="read-only" value={3} readOnly />
            <Typography variant="h5" color="secondary">
              {product.price}$
            </Typography>
          </Box>
        </CardContent>
      </Box>
      <CardActions sx={{ display: "flex", justifyContent: "space-between" }}>
        <Button size="small">Learn More</Button>
        <IconButton>
          <AddShoppingCartRounded />
        </IconButton>
      </CardActions>
    </Card>
  );
};

export default ProductItem;
